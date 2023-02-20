Imports System.Drawing.Text
Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Text
Imports System.Threading

Public Class Form1
    Dim arguments As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private Const configFileName As String = "config.app" 'Name of the config file
    Private Shared configFilePath As String = Path.Combine(Application.StartupPath, configFileName) 'Full path to the config file
    Private cliPrograms As New Dictionary(Of String, String) From {
    {"chia_plot", "chia_plot.exe"},
    {"chia_plot_k34", "chia_plot_k34.exe"},
    {"cuda_plot_k26", "cuda_plot_k26.exe"},
    {"cuda_plot_k29", "cuda_plot_k29.exe"},
    {"cuda_plot_k30", "cuda_plot_k30.exe"},
    {"cuda_plot_k31", "cuda_plot_k31.exe"},
    {"cuda_plot_k32", "cuda_plot_k32.exe"},
    {"cuda_plot_k33", "cuda_plot_k33.exe"},
    {"cuda_plot_k34", "cuda_plot_k34.exe"}
    }
    Private Const CHIA_VALUE As Integer = 8444
    Private Const MMX_VALUE As Integer = 11337

    Private ReadOnly portValues As New Dictionary(Of String, Integer)() From {
    {"Chia", CHIA_VALUE},
    {"MMX", MMX_VALUE}
    }

    Private Declare Function AllocConsole Lib "kernel32" () As Boolean
    Private Declare Function FreeConsole Lib "kernel32" () As Boolean
    Private Declare Function ShowWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean

    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 5
    Private Const FOREGROUND_BLUE As Short = &H1
    Private Const BACKGROUND_BLUE As Short = &H10

    Private cmdProcess As Process
    Private consoleWindowHandle As IntPtr

    Private Declare Function GenerateConsoleCtrlEvent Lib "kernel32.dll" (dwCtrlEvent As Integer, dwProcessGroupId As Integer) As Boolean
    Private Const CTRL_C_EVENT As Integer = 0

    Private Declare Function OpenThread Lib "kernel32.dll" (dwDesiredAccess As Integer, bInheritHandle As Boolean, dwThreadId As Integer) As IntPtr
    Private Declare Function SuspendThread Lib "kernel32.dll" (hThread As IntPtr) As Integer
    Private Declare Function ResumeThread Lib "kernel32.dll" (hThread As IntPtr) As Integer
    Private Declare Function CloseHandle Lib "kernel32.dll" (hObject As IntPtr) As Boolean


    Private Const THREAD_ALL_ACCESS As Integer = &H1F03FF

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDebugControlsVisibility(False)
        PopulateCLCombo()
        PopulateNumThreadsCombo()
        PopulateCPortCombo()
        AdvancedOptionsCheck.Checked = False
        RemoteCopyPortLabel.Enabled = False
        arguments("-z") = ""
        RemoteCopyPortText.Text = ""
        DebugRemoteCopyPort.Text = ""
        RemoteCopyPortText.Enabled = False
        DebugRemoteCopyPort.Enabled = False
        arguments("-w") = ""
        WaitforCopyCheck.Checked = False
        WaitforCopyCheck.Enabled = False
        DebugWaitforCopy.Text = ""
        DebugWaitforCopy.Enabled = False
        arguments("-Z") = ""
        UniquePlotCheck.Checked = False
        UniquePlotCheck.Enabled = False
        DebugUniquePlot.Text = ""
        DebugUniquePlot.Enabled = False
        ThreadMultiplierP2Label.Enabled = False
        arguments("-K") = ""
        ThreadMultiplierP2Text.Text = ""
        ThreadMultiplierP2Text.Enabled = False
        DebugThreadMultiplierP2.Text = ""
        DebugThreadMultiplierP2.Enabled = False
        arguments("-D") = ""
        DirectInFinalDirCheck.Checked = False
        DirectInFinalDirCheck.Enabled = False
        DebugDirectInFinalDir.Text = ""
        DebugDirectInFinalDir.Enabled = False
        arguments("-G") = ""
        AlternateTempDirCheck.Checked = False
        AlternateTempDirCheck.Enabled = False
        DebugAlternateTempDir.Text = ""
        DebugAlternateTempDir.Enabled = False
        StageDirectoryLabel.Enabled = False
        arguments("-s") = ""
        StageDirectoryText.Text = ""
        StageDirectoryText.Enabled = False
        StageDirectoryButton.Enabled = False
        DebugStageDirectory.Text = ""
        DebugStageDirectory.Enabled = False
        MaxPlotstoCacheinTempDirLabel.Enabled = False
        arguments("-Q") = ""
        MaxPlotsCacheTempDirText.Text = ""
        MaxPlotsCacheTempDirText.Enabled = False
        DebugMaxPlotsCacheTempDir.Text = ""
        DebugMaxPlotsCacheTempDir.Enabled = False
        arguments("-W") = ""
        MaxParallelCopiesCheck.Checked = False
        MaxParallelCopiesCheck.Enabled = False
        DebugMaxParalleCopies.Text = ""
        DebugMaxParalleCopies.Enabled = False
        ResumeButton.Enabled = False

        Dim allValid As Boolean = True
        For Each program In cliPrograms
            Dim filePath As String = ""
            If cliPrograms.TryGetValue(program.Key, filePath) Then
                If System.IO.File.Exists(filePath) Then
                    ' The file path is valid, move on to the next program
                    Continue For
                End If
            End If

            ' Check the folder the program is run from for the program
            Dim currentDirectory As String = System.IO.Directory.GetCurrentDirectory()
            filePath = System.IO.Path.Combine(currentDirectory, program.Value)
            If System.IO.File.Exists(filePath) Then
                ' The file path is valid, update the file path in the dictionary
                cliPrograms(program.Key) = filePath
                Continue For
            End If

            ' If the file path is not found or is invalid, set allValid to False
            allValid = False
        Next

        If Not allValid Then
            Try
                Dim result As DialogResult = MessageBox.Show("One or more paths to PoST Plotters has not been found or is invalid. Would you like to update the paths now?", "Error", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    ' User does not want to update the paths, exit the config process
                    Return
                End If
            Catch ex As Exception
                ' Handle the exception here
            End Try
        End If

        If System.IO.File.Exists(configFilePath) Then
            ' Read the config file
            Dim configContent As String = System.IO.File.ReadAllText(configFilePath)
            ' Parse the config content into a dictionary
            For Each line As String In configContent.Split(Environment.NewLine)
                Dim parts As String() = line.Split("=")
                If parts.Length = 2 Then
                    cliPrograms(parts(0)) = parts(1)
                End If
            Next

            ' Prompt the user to select the correct path for each program
            For Each program In cliPrograms
                Dim filePath As String = ""
                If cliPrograms.TryGetValue(program.Key, filePath) Then
                    If System.IO.File.Exists(filePath) Then
                        ' The file path is already set, move on to the next program
                        Continue For
                    End If
                End If

                Dim openFileDialog As New OpenFileDialog With {
                    .Filter = program.Value & "|" & program.Value,
                    .Title = "Select " & program.Value
                }
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    ' Update the file path in the config file
                    filePath = openFileDialog.FileName
                    cliPrograms(program.Key) = filePath
                End If
            Next
            ' Write the updated file paths to the config file
            Dim configBuilder As New StringBuilder()
            For Each argument In cliPrograms
                configBuilder.AppendLine(argument.Key & "=" & argument.Value)
            Next
            System.IO.File.WriteAllText(configFilePath, configBuilder.ToString())
        Else
            ' The config file does not exist
            ' Prompt the user to select the correct path for each program
            For Each program In cliPrograms
                Dim filePath As String = ""
                ' Check the folder the program is run from for the program
                Dim currentDirectory As String = System.IO.Directory.GetCurrentDirectory()
                filePath = System.IO.Path.Combine(currentDirectory, program.Value)
                If System.IO.File.Exists(filePath) Then
                    ' The file path is valid, update the file path in the dictionary
                    cliPrograms(program.Key) = filePath
                    Continue For
                End If

                Dim openFileDialog As New OpenFileDialog With {
                .Filter = program.Value & "|" & program.Value,
                .Title = "Select " & program.Value
            }
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    ' Update the file path in the dictionary
                    filePath = openFileDialog.FileName
                    cliPrograms(program.Key) = filePath
                End If
            Next
            ' Write the file paths to the new config file
            Dim configBuilder As New StringBuilder()
            For Each argument In cliPrograms
                configBuilder.AppendLine(argument.Key & "=" & argument.Value)
            Next
            System.IO.File.WriteAllText(configFilePath, configBuilder.ToString())
        End If
    End Sub

    Private Sub SetDebugControlsVisibility(visible As Boolean)
        DebugPM.Visible = visible
        DebugKValue.Visible = visible
        DebugCL.Visible = visible
        DebugNPlots.Visible = visible
        DebugTempDir1.Visible = visible
        DebugTempDir2.Visible = visible
        DebugTempDir3.Visible = visible
        DebugFinalDir.Visible = visible
        DebugPoolKey.Visible = visible
        DebugContractKey.Visible = visible
        DebugFarmerKey.Visible = visible
        DebugNumThreads.Visible = visible
        DebugBuckets.Visible = visible
        DebugBucketsP23.Visible = visible
        DebugCudaDevice.Visible = visible
        DebugNumCuda.Visible = visible
        DebugStreams.Visible = visible
        DebugMaxMem.Visible = visible
        DebugPlotterPath.Visible = visible
        DebugPlotter.Visible = visible
        DebugCPort.Visible = visible
        DebugRemoteCopyPort.Visible = visible
        DebugWaitforCopy.Visible = visible
        DebugUniquePlot.Visible = visible
        DebugThreadMultiplierP2.Visible = visible
        DebugStageDirectory.Visible = visible
        DebugDirectInFinalDir.Visible = visible
        DebugAlternateTempDir.Visible = visible
        DebugMaxPlotsCacheTempDir.Visible = visible
        DebugMaxParalleCopies.Visible = visible
    End Sub

    Private Sub PopulateCLCombo()
        For i As Integer = 1 To 9
            CLCombo.Items.Add(i.ToString())
        Next
        ContractKeyRadio.Checked = True
    End Sub

    Private Sub PopulateNumThreadsCombo()
        Dim numThreads As Integer = System.Environment.ProcessorCount
        NumThreadsCombo.Items.Clear()
        For i As Integer = 1 To numThreads - 1
            NumThreadsCombo.Items.Add(i)
        Next
    End Sub

    Private Sub PopulateCPortCombo()
        CPortCombo.Items.AddRange({"Chia", "MMX", "Other"})
    End Sub

    Private Sub DebugModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugModeToolStripMenuItem.Click
        DebugModeToolStripMenuItem.Checked = Not DebugModeToolStripMenuItem.Checked
        DebugPM.Visible = DebugModeToolStripMenuItem.Checked
        DebugKValue.Visible = DebugModeToolStripMenuItem.Checked
        DebugCL.Visible = DebugModeToolStripMenuItem.Checked
        DebugNPlots.Visible = DebugModeToolStripMenuItem.Checked
        DebugTempDir1.Visible = DebugModeToolStripMenuItem.Checked
        DebugTempDir2.Visible = DebugModeToolStripMenuItem.Checked
        DebugTempDir3.Visible = DebugModeToolStripMenuItem.Checked
        DebugFinalDir.Visible = DebugModeToolStripMenuItem.Checked
        DebugPoolKey.Visible = DebugModeToolStripMenuItem.Checked
        DebugContractKey.Visible = DebugModeToolStripMenuItem.Checked
        DebugFarmerKey.Visible = DebugModeToolStripMenuItem.Checked
        DebugNumThreads.Visible = DebugModeToolStripMenuItem.Checked
        DebugBuckets.Visible = DebugModeToolStripMenuItem.Checked
        DebugBucketsP23.Visible = DebugModeToolStripMenuItem.Checked
        DebugCudaDevice.Visible = DebugModeToolStripMenuItem.Checked
        DebugNumCuda.Visible = DebugModeToolStripMenuItem.Checked
        DebugStreams.Visible = DebugModeToolStripMenuItem.Checked
        DebugMaxMem.Visible = DebugModeToolStripMenuItem.Checked
        DebugPlotterPath.Visible = DebugModeToolStripMenuItem.Checked
        DebugPlotter.Visible = DebugModeToolStripMenuItem.Checked
        DebugCPort.Visible = DebugModeToolStripMenuItem.Checked
        DebugRemoteCopyPort.Visible = DebugModeToolStripMenuItem.Checked
        DebugWaitforCopy.Visible = DebugModeToolStripMenuItem.Checked
        DebugUniquePlot.Visible = DebugModeToolStripMenuItem.Checked
        DebugThreadMultiplierP2.Visible = DebugModeToolStripMenuItem.Checked
        DebugStageDirectory.Visible = DebugModeToolStripMenuItem.Checked
        DebugDirectInFinalDir.Visible = DebugModeToolStripMenuItem.Checked
        DebugAlternateTempDir.Visible = DebugModeToolStripMenuItem.Checked
        DebugMaxPlotsCacheTempDir.Visible = DebugModeToolStripMenuItem.Checked
        DebugMaxParalleCopies.Visible = DebugModeToolStripMenuItem.Checked
    End Sub

    Private Sub PMCPURadio_CheckedChanged(sender As Object, e As EventArgs) Handles PMCPURadio.CheckedChanged
        If PMCPURadio.Checked Then
            UpdateProcessingMode("CPU")
        End If
    End Sub

    Private Sub PMGPURadio_CheckedChanged(sender As Object, e As EventArgs) Handles PMGPURadio.CheckedChanged
        If PMGPURadio.Checked Then
            UpdateProcessingMode("GPU")
        End If
    End Sub

    Private Sub UpdateProcessingMode(mode As String)
        arguments("-PM") = mode
        If mode = "CPU" Then
            KValueCombo.Items.Clear()
            For i As Integer = 26 To 40
                KValueCombo.Items.Add(i)
            Next
            If arguments.ContainsKey("-k") Then
                arguments.Remove("-k") 'remove the previous k value if exists
                KValueCombo.Text = "" 'reset k value combo box text
                DebugKValue.Text = "No K-Value selected" 'reset debug  k value label text
            End If
            CudaDeviceText.Text = ""
            NumCudaText.Text = ""
            StreamsText.Text = ""
            MaxMemText.Text = ""
            NumThreadsCombo.Text = "4"
            BucketsText.Text = "256"
            BucketsP23Text.Text = BucketsText.Text
            CPUOptions.Enabled = True
            GPUOptions.Enabled = False
        ElseIf mode = "GPU" Then
            KValueCombo.Items.Clear()
            For Each i In {26, 29, 30, 31, 32, 33, 34}
                KValueCombo.Items.Add(i)
            Next
            If arguments.ContainsKey("-k") Then
                arguments.Remove("-k") 'remove the previous k value if exists
                KValueCombo.Text = "" 'reset k value combo box text
                DebugKValue.Text = "No K-Value selected" 'reset debug  k value label text
            End If
            NumThreadsCombo.Text = ""
            BucketsText.Text = ""
            BucketsP23Text.Text = ""
            CudaDeviceText.Text = "0"
            NumCudaText.Text = "1"
            StreamsText.Text = "4"
            MaxMemText.Text = "0"
            GPUOptions.Enabled = True
            CPUOptions.Enabled = False
        End If
        If arguments.ContainsKey("-PM") Then
            DebugPM.Text = "-PM " & arguments("-PM").ToString()
        Else
            DebugPM.Text = "No processing mode selected"
        End If
        Debug.WriteLine("-PM " & arguments("-PM"))
    End Sub

    Private Sub DebugPM_Click(sender As Object, e As EventArgs) Handles DebugPM.Click

    End Sub

    Private Sub KValueCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KValueCombo.SelectedIndexChanged
        arguments("-k") = KValueCombo.SelectedItem.ToString()
        If arguments.ContainsKey("-k") Then
            DebugKValue.Text = "-k " & arguments("-k").ToString()
        Else
            DebugKValue.Text = "No K-Value selected"
        End If
        Debug.WriteLine("-k " & arguments("-k"))
        If arguments.ContainsKey("-PM") AndAlso arguments.ContainsKey("-k") Then
            If arguments("-PM").Equals("CPU") Then
                If Integer.Parse(arguments("-k")) <= 32 Then
                    Dim plotter As String = cliPrograms("chia_plot")
                    Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                    arguments("-plp") = Path.GetDirectoryName(plotterPath)
                    arguments("-pl") = Path.GetFileName(plotter)
                Else
                    Dim plotter As String = cliPrograms("chia_plot_k34")
                    Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                    arguments("-plp") = Path.GetDirectoryName(plotterPath)
                    arguments("-pl") = Path.GetFileName(plotter)
                End If
            ElseIf arguments("-PM").Equals("GPU") Then
                Select Case Integer.Parse(arguments("-k"))
                    Case 26
                        Dim plotter As String = cliPrograms("cuda_plot_k26")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 29
                        Dim plotter As String = cliPrograms("cuda_plot_k29")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 30
                        Dim plotter As String = cliPrograms("cuda_plot_k30")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 31
                        Dim plotter As String = cliPrograms("cuda_plot_k31")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 32
                        Dim plotter As String = cliPrograms("cuda_plot_k32")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 33
                        Dim plotter As String = cliPrograms("cuda_plot_k33")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                    Case 34
                        Dim plotter As String = cliPrograms("cuda_plot_k34")
                        Dim plotterPath As String = Path.Combine(Application.StartupPath, plotter)
                        arguments("-plp") = Path.GetDirectoryName(plotterPath)
                        arguments("-pl") = Path.GetFileName(plotter)
                End Select
            End If
        End If
        DebugPlotterPath.Text = arguments("-plp").ToString()
        DebugPlotter.Text = arguments("-pl").ToString()
        Debug.WriteLine($"{arguments("-plp")}")
        Debug.WriteLine($"{arguments("-pl")}")
    End Sub

    Private Sub DebugKValue_Click(sender As Object, e As EventArgs) Handles DebugKValue.Click

    End Sub

    Private Sub CLCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CLCombo.SelectedIndexChanged
        If CLCombo.SelectedIndex >= 0 Then
            arguments("-C") = CLCombo.SelectedItem.ToString()
        Else
            Debug.WriteLine("No Compression Level selected")
        End If
        If arguments.ContainsKey("-C") Then
            DebugCL.Text = "-C " & arguments("-C").ToString()
        Else
            DebugCL.Text = "No K-Value selected"
        End If
        Debug.WriteLine("-C " & arguments("-C"))
    End Sub

    Private Sub DebugCL_Click(sender As Object, e As EventArgs) Handles DebugCL.Click

    End Sub

    Private Sub CPortCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CPortCombo.SelectedIndexChanged
        If CPortCombo.SelectedItem.ToString() = "Other" Then
            CPortText.Enabled = True
            If Not String.IsNullOrEmpty(CPortText.Text) Then
                arguments("-x") = CPortText.Text
            Else
                Debug.WriteLine("No Other port value entered")
            End If
        Else
            CPortText.Enabled = False
            Dim selectedPort As String = CPortCombo.SelectedItem.ToString()
            arguments("-x") = portValues(selectedPort).ToString()
        End If
        If arguments.ContainsKey("-x") Then
            DebugCPort.Text = "-x " & arguments("-x")
        Else
            DebugCPort.Text = "No port selected"
        End If
    End Sub

    Private Sub CPortText_TextChanged(sender As Object, e As EventArgs) Handles CPortText.TextChanged
        If CPortCombo.SelectedItem.ToString() = "Other" AndAlso Not String.IsNullOrEmpty(CPortText.Text) Then
            Dim portValue As Integer
            If Integer.TryParse(CPortText.Text, portValue) Then
                portValues("Other") = portValue
                arguments("-x") = portValue
            Else
                CPortText.Text = ""
                arguments.Remove("-x") ' Remove the "-x" key if non-integer values are entered
                DebugCPort.Text = "No port selected"
                Return
            End If
        End If
        If arguments.ContainsKey("-x") Then
            DebugCPort.Text = "-x " & arguments("-x")
            Debug.WriteLine(arguments("-x"))
        Else
            DebugCPort.Text = "No port selected"
        End If
    End Sub

    Private Sub DebugCPort_Click(sender As Object, e As EventArgs) Handles DebugCPort.Click

    End Sub

    Private Sub NPlotsText_TextChanged(sender As Object, e As EventArgs) Handles NPlotsText.TextChanged
        Dim nValue As Integer
        If NPlotsCheck.Checked Then
            nValue = -1
        Else
            If Not Integer.TryParse(NPlotsText.Text, nValue) Then
                DebugNPlots.Text = "Invalid Plot Number entered"
                Return
            End If
        End If
        arguments("-n") = nValue
        If arguments.ContainsKey("-n") Then
            DebugNPlots.Text = "-n " & arguments("-n").ToString()
        Else
            DebugNPlots.Text = "No Plot Number Entered"
        End If
        Debug.WriteLine("-n " & arguments("-n"))
    End Sub

    Private Sub NPlotsCheck_CheckedChanged(sender As Object, e As EventArgs) Handles NPlotsCheck.CheckedChanged
        NPlotsText.Enabled = Not NPlotsCheck.Checked
        Dim nValue As Integer
        If NPlotsCheck.Checked Then
            NPlotsText.Text = ""
            nValue = -1
            arguments("-n") = nValue
        Else
            If Not Integer.TryParse(NPlotsText.Text, nValue) Then
                DebugNPlots.Text = "Invalid Plot Number entered"
                Return
            End If
            arguments("-n") = nValue
        End If
        If arguments.ContainsKey("-n") Then
            DebugNPlots.Text = "-n " & arguments("-n").ToString()
        Else
            DebugNPlots.Text = "No Plot Number Entered"
        End If
        Debug.WriteLine("-n " & arguments("-n"))
    End Sub

    Private Sub DebugNPlots_Click(sender As Object, e As EventArgs) Handles DebugNPlots.Click

    End Sub

    Private Sub TempDir1Text_TextChanged(sender As Object, e As EventArgs) Handles TempDir1Text.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim path As String = textbox.Text
        If Not String.IsNullOrEmpty(path) AndAlso path.EndsWith("\") Then
            arguments("-t") = path
        Else
            DebugTempDir1.Text = "Invalid Path"
        End If
        If arguments.ContainsKey("-t") Then
            DebugTempDir1.Text = "-t " & arguments("-t").ToString()
        Else
            DebugTempDir1.Text = "Invalid Path"
        End If
        Debug.WriteLine("-t " & arguments("-t"))
    End Sub

    Private Sub TempDir1Button_Click(sender As Object, e As EventArgs) Handles TempDir1Button.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = DialogResult.OK Then
                Dim path As String = fbd.SelectedPath
                If path <> String.Empty AndAlso Not path.EndsWith("\") Then '<-- Check for empty string
                    path &= "\" '<-- Append to end of path
                End If
                If System.IO.Directory.Exists(path) Then '<-- Check if folder exists
                    TempDir1Text.Text = path '<-- set text to path
                Else
                    Debug.Print("Invalid Path")
                End If
            End If
        End Using
    End Sub

    Private Sub DebugTempDir1_Click(sender As Object, e As EventArgs) Handles DebugTempDir1.Click

    End Sub

    Private Sub TempDir2Text_TextChanged(sender As Object, e As EventArgs) Handles TempDir2Text.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim path As String = textbox.Text
        If Not String.IsNullOrEmpty(path) AndAlso path.EndsWith("\") Then
            arguments("-2") = path
        Else
            DebugTempDir2.Text = "Invalid Path"
        End If
        If arguments.ContainsKey("-2") Then
            DebugTempDir2.Text = "-2 " & arguments("-2").ToString()
        Else
            DebugTempDir2.Text = "Invalid Path"
        End If
        Debug.WriteLine("-2 " & arguments("-2"))
    End Sub

    Private Sub TempDir2Button_Click(sender As Object, e As EventArgs) Handles TempDir2Button.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = DialogResult.OK Then
                Dim path As String = fbd.SelectedPath
                If path <> String.Empty AndAlso Not path.EndsWith("\") Then '<-- Check for empty string
                    path &= "\" '<-- Append to end of path
                End If
                If System.IO.Directory.Exists(path) Then '<-- Check if folder exists
                    TempDir2Text.Text = path '<-- set text to path
                Else
                    Debug.Print("Invalid Path")
                End If
            End If
        End Using
    End Sub

    Private Sub TempDir2Check_CheckedChanged(sender As Object, e As EventArgs) Handles TempDir2Check.CheckedChanged
        Dim checkbox As CheckBox = DirectCast(sender, CheckBox)

        If checkbox.Checked Then
            TempDir2Text.Text = ""
            arguments("-2") = ""
            TempDir2Text.Enabled = False
            TempDir2Button.Enabled = False
        Else
            TempDir2Text.Enabled = True
            TempDir2Button.Enabled = True
        End If
        If arguments.ContainsKey("-2") Then
            DebugTempDir2.Text = "-2 " & arguments("-2").ToString()
        Else
            DebugTempDir2.Text = "Invalid Path"
        End If
        Debug.WriteLine("-2 " & arguments("-2"))
    End Sub

    Private Sub DebugTempDir2_Click(sender As Object, e As EventArgs) Handles DebugTempDir2.Click

    End Sub

    Private Sub TempDir3Text_TextChanged(sender As Object, e As EventArgs) Handles TempDir3Text.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim path As String = textbox.Text
        If Not String.IsNullOrEmpty(path) AndAlso path.EndsWith("\") Then
            arguments("-3") = path
        Else
            DebugTempDir3.Text = "Invalid Path"
        End If
        If arguments.ContainsKey("-3") Then
            DebugTempDir3.Text = "-3 " & arguments("-3").ToString()
        Else
            DebugTempDir3.Text = "Invalid Path"
        End If
        Debug.WriteLine("-3 " & arguments("-3"))
    End Sub

    Private Sub TempDir3Button_Click(sender As Object, e As EventArgs) Handles TempDir3Button.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = DialogResult.OK Then
                Dim path As String = fbd.SelectedPath
                If path <> String.Empty AndAlso Not path.EndsWith("\") Then '<-- Check for empty string
                    path &= "\" '<-- Append to end of path
                End If
                If System.IO.Directory.Exists(path) Then '<-- Check if folder exists
                    TempDir3Text.Text = path '<-- set text to path
                Else
                    Debug.Print("Invalid Path")
                End If
            End If
        End Using
    End Sub

    Private Sub TempDir3Check_CheckedChanged(sender As Object, e As EventArgs) Handles TempDir3Check.CheckedChanged
        Dim checkbox As CheckBox = DirectCast(sender, CheckBox)

        If checkbox.Checked Then
            TempDir2Text.Text = ""
            arguments("-3") = ""
            TempDir3Text.Enabled = False
            TempDir3Button.Enabled = False
        Else
            TempDir3Text.Enabled = True
            TempDir3Button.Enabled = True
        End If
        If arguments.ContainsKey("-3") Then
            DebugTempDir3.Text = "-3 " & arguments("-3").ToString()
        Else
            DebugTempDir2.Text = "Invalid Path"
        End If
        Debug.WriteLine("-3 " & arguments("-3"))
    End Sub

    Private Sub DebugTempDir3_Click(sender As Object, e As EventArgs) Handles DebugTempDir3.Click

    End Sub

    Private Sub FinalDirText_TextChanged(sender As Object, e As EventArgs) Handles FinalDirText.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim path As String = textbox.Text
        If Not String.IsNullOrEmpty(path) AndAlso path.EndsWith("\") Then
            arguments("-d") = path
        Else
            DebugFinalDir.Text = "Invalid Path"
        End If
        If arguments.ContainsKey("-d") Then
            DebugFinalDir.Text = "-d " & arguments("-d").ToString()
        Else
            DebugFinalDir.Text = "Invalid Path"
        End If
        Debug.WriteLine("-d " & arguments("-d"))
    End Sub

    Private Sub FinalDirButton_Click(sender As Object, e As EventArgs) Handles FinalDirButton.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = DialogResult.OK Then
                Dim path As String = fbd.SelectedPath
                If path <> String.Empty AndAlso Not path.EndsWith("\") Then '<-- Check for empty string
                    path &= "\" '<-- Append to end of path
                End If
                If System.IO.Directory.Exists(path) Then '<-- Check if folder exists
                    FinalDirText.Text = path '<-- set text to path
                Else
                    Debug.Print("Invalid Path")
                End If
            End If
        End Using
    End Sub

    Private Sub DebugFinalDir_Click(sender As Object, e As EventArgs) Handles DebugFinalDir.Click

    End Sub

    Private Sub PoolKeyText_TextChanged(sender As Object, e As EventArgs) Handles PoolKeyText.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim addy As String = textbox.Text
        If Not String.IsNullOrEmpty(addy) Then
            arguments("-p") = addy
        Else
            arguments("-p") = ""
            DebugPoolKey.Text = "Invalid Address"
        End If
        If arguments.ContainsKey("-p") Then
            DebugPoolKey.Text = "-p " & arguments("-p").ToString()
        Else
            DebugPoolKey.Text = "Invalid Address"
        End If
        Debug.WriteLine("-p " & arguments("-p"))
    End Sub

    Private Sub PoolKeyRadio_CheckedChanged(sender As Object, e As EventArgs) Handles PoolKeyRadio.CheckedChanged
        If PoolKeyRadio.Checked Then
            ContractKeyText.Enabled = False
            ContractKeyRadio.Checked = False
            ContractKeyText.Text = ""
        Else
            ContractKeyText.Enabled = True
        End If
    End Sub

    Private Sub ContractKeyText_TextChanged(sender As Object, e As EventArgs) Handles ContractKeyText.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim addy As String = textbox.Text
        If Not String.IsNullOrEmpty(addy) Then
            arguments("-c") = addy
        Else
            arguments("-c") = ""
            DebugContractKey.Text = "Invalid Address"
        End If
        If arguments.ContainsKey("-c") Then
            DebugContractKey.Text = "-c " & arguments("-c").ToString()
        Else
            DebugContractKey.Text = "Invalid Address"
        End If
        Debug.WriteLine("-c " & arguments("-c"))
    End Sub

    Private Sub FarmerKeyText_TextChanged(sender As Object, e As EventArgs) Handles FarmerKeyText.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim addy As String = textbox.Text
        If Not String.IsNullOrEmpty(addy) Then
            arguments("-f") = addy
        Else
            arguments("-f") = ""
            DebugFarmerKey.Text = "Invalid Address"
        End If
        If arguments.ContainsKey("-f") Then
            DebugFarmerKey.Text = "-f " & arguments("-f").ToString()
        Else
            DebugFarmerKey.Text = "Invalid Address"
        End If
        Debug.WriteLine("-f " & arguments("-f"))
    End Sub

    Private Sub ContractKeyRadio_CheckedChanged(sender As Object, e As EventArgs) Handles ContractKeyRadio.CheckedChanged
        If ContractKeyRadio.Checked Then
            PoolKeyText.Enabled = False
            PoolKeyRadio.Checked = False
            PoolKeyText.Text = ""
        Else
            PoolKeyText.Enabled = True
        End If
    End Sub

    Private Sub NumThreadsCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NumThreadsCombo.SelectedIndexChanged
        arguments("-r") = NumThreadsCombo.SelectedItem.ToString()
        If arguments.ContainsKey("-r") Then
            DebugNumThreads.Text = "-r " & arguments("-r").ToString()
        Else
            DebugNumThreads.Text = "Invalid Value"
        End If
        Debug.WriteLine("-r " & arguments("-r"))
    End Sub

    Private Sub DebugNumThreads_Click(sender As Object, e As EventArgs) Handles DebugNumThreads.Click

    End Sub

    Private Sub BucketsText_TextChanged(sender As Object, e As EventArgs) Handles BucketsText.TextChanged
        arguments("-u") = BucketsText.Text.ToString()
        If arguments.ContainsKey("-u") Then
            DebugBuckets.Text = "-u " & arguments("-u").ToString()
        Else
            DebugBuckets.Text = "Invalid Value"
        End If
        Debug.WriteLine("-u " & arguments("-u"))
        BucketsP23Text.Text = BucketsText.Text
    End Sub

    Private Sub DebugBuckets_Click(sender As Object, e As EventArgs) Handles DebugBuckets.Click

    End Sub

    Private Sub BucketsP23Text_TextChanged(sender As Object, e As EventArgs) Handles BucketsP23Text.TextChanged
        arguments("-v") = BucketsP23Text.Text.ToString()
        If arguments.ContainsKey("-v") Then
            DebugBucketsP23.Text = "-v " & arguments("-v").ToString()
        Else
            DebugBucketsP23.Text = "Invalid Value"
        End If
        Debug.WriteLine("-v " & arguments("-v"))
    End Sub

    Private Sub DebugBucketsP23_Click(sender As Object, e As EventArgs) Handles DebugBucketsP23.Click

    End Sub

    Private Sub CudaDeviceText_TextChanged(sender As Object, e As EventArgs) Handles CudaDeviceText.TextChanged
        Dim previousText As String = CudaDeviceText.Text
        For Each c As Char In CudaDeviceText.Text
            If Not Char.IsDigit(c) AndAlso c <> "," Then
                CudaDeviceText.Text = previousText
                Exit Sub
            End If
        Next
        arguments("-g") = CudaDeviceText.Text.ToString()
        If arguments.ContainsKey("-g") Then
            DebugCudaDevice.Text = "-g " & arguments("-g").ToString()
        Else
            DebugCudaDevice.Text = "Invalid Value"
        End If
        Debug.WriteLine("-g " & arguments("-g"))
    End Sub

    Private Sub NumCudaText_TextChanged(sender As Object, e As EventArgs) Handles NumCudaText.TextChanged
        Dim previousText As String = NumCudaText.Text
        For Each c As Char In NumCudaText.Text
            If Not Char.IsDigit(c) Then
                NumCudaText.Text = previousText
                Exit Sub
            End If
        Next
        arguments("-r2") = NumCudaText.Text.ToString()
        If arguments.ContainsKey("-r2") Then
            DebugNumCuda.Text = "-r " & arguments("-r2").ToString()
        Else
            DebugNumCuda.Text = "Invalid Value"
        End If
        Debug.WriteLine("-r " & arguments("-r2"))
    End Sub

    Private Sub DebugNumCuda_Click(sender As Object, e As EventArgs) Handles DebugNumCuda.Click

    End Sub

    Private Sub StreamsText_TextChanged(sender As Object, e As EventArgs) Handles StreamsText.TextChanged
        If StreamsText.Text = "" Then
            arguments("-S") = StreamsText.Text.ToString()
        ElseIf Not Integer.TryParse(StreamsText.Text, Nothing) Then
            StreamsText.Text = 2
        Else
            If CInt(StreamsText.Text) < 2 Then
                StreamsText.Text = 2
            End If
            arguments("-S") = StreamsText.Text.ToString()
        End If
        If arguments.ContainsKey("-S") Then
            DebugStreams.Text = "-S " & arguments("-S").ToString()
        Else
            DebugStreams.Text = "Invalid Streams Value"
        End If
        Debug.WriteLine("-S " & arguments("-S"))
    End Sub

    Private Sub DebugStreams_Click(sender As Object, e As EventArgs) Handles DebugStreams.Click

    End Sub

    Private Sub MaxMemText_TextChanged(sender As Object, e As EventArgs) Handles MaxMemText.TextChanged
        If MaxMemText.Text = "" Then
            arguments("-M") = MaxMemText.Text.ToString()
        Else
            Try
                Dim mem As Integer = Integer.Parse(MaxMemText.Text)
                If mem < 0 Then
                End If
                arguments("-M") = MaxMemText.Text.ToString()
            Catch ex As FormatException
                MessageBox.Show("Invalid input. Please enter a valid amount of memory.")
            End Try
        End If
        If arguments.ContainsKey("-M") Then
            DebugMaxMem.Text = "-M " & arguments("-M").ToString()
        Else
            DebugMaxMem.Text = "Invalid Value"
        End If
        Debug.WriteLine("-M " & arguments("-M"))
    End Sub

    Private Sub DebugMaxMem_Click(sender As Object, e As EventArgs) Handles DebugMaxMem.Click

    End Sub

    Private Sub OpenConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConfigToolStripMenuItem.Click
        Process.Start("notepad.exe", configFilePath)
    End Sub

    Private Sub OpenConfigLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConfigLocationToolStripMenuItem.Click
        Process.Start("explorer.exe", "/select," & configFilePath)
    End Sub

    Private Sub ClearConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearConfigToolStripMenuItem.Click
        Dim clearConfigDialog As New DialogResult
        clearConfigDialog = MessageBox.Show("Are you sure you want to clear the contents of the config file? This action will restart the application and any unsaved changes will be lost. Do you wish to continue?", "Warning", MessageBoxButtons.YesNo)
        If clearConfigDialog = DialogResult.Yes Then
            System.IO.File.WriteAllText(configFilePath, String.Empty)
            Application.Restart()
        End If
    End Sub

    Private Sub DebugPlotterPath_Click(sender As Object, e As EventArgs) Handles DebugPlotterPath.Click

    End Sub

    Private Sub DebugPlotter_Click(sender As Object, e As EventArgs) Handles DebugPlotter.Click

    End Sub

    Private Sub StartPlotProcess()
        Dim argumentsString As String = ""
        Dim plotFilePath As String = Path.Combine(arguments("-plp").ToString(), arguments("-pl").ToString())
        Dim plotDirectory As String = Path.GetDirectoryName(plotFilePath)

        Dim commonArguments() As String = {"-C", "-x", "-n", "-t", "-2", "-d", "-z", "-p", "-c", "-f"}

        If PMGPURadio.Checked Then
            For Each arg In commonArguments
                If arguments.ContainsKey(arg) AndAlso arguments(arg) <> "" Then
                    argumentsString &= " " & arg & " " & arguments(arg)
                End If
            Next
            If arguments.ContainsKey("-3") AndAlso arguments("-3") <> "" Then
                argumentsString &= " -3 " & arguments("-3")
            End If
            If arguments.ContainsKey("-g") AndAlso arguments("-g") <> "" Then
                argumentsString &= " -g " & arguments("-g")
            End If
            If arguments.ContainsKey("-r2") AndAlso arguments("-r2") <> "" Then
                argumentsString &= " -r " & arguments("-r2")
            End If
            If arguments.ContainsKey("-S") AndAlso arguments("-S") <> "" Then
                argumentsString &= " -S " & arguments("-S")
            End If
            If arguments.ContainsKey("-M") AndAlso arguments("-M") <> "" Then
                argumentsString &= " -M " & arguments("-M")
            End If
            If arguments.ContainsKey("-Q") AndAlso arguments("-Q") <> "" Then
                argumentsString &= " -Q " & arguments("-Q")
            End If
            If arguments.ContainsKey("-w") AndAlso arguments("-w") <> "" Then
                argumentsString &= arguments("-w")
            End If
            If arguments.ContainsKey("-Z") AndAlso arguments("-Z") <> "" Then
                argumentsString &= arguments("-Z")
            End If
            If arguments.ContainsKey("-W") AndAlso arguments("-W") <> "" Then
                argumentsString &= arguments("-W")
            End If
        ElseIf PMCPURadio.Checked Then
            For Each arg In commonArguments
                If arguments.ContainsKey(arg) AndAlso arguments(arg) <> "" Then
                    argumentsString &= " " & arg & " " & arguments(arg)
                End If
            Next
            If arguments.ContainsKey("-k") AndAlso arguments("-k") <> "" Then
                argumentsString &= " -k " & arguments("-k")
            End If
            If arguments.ContainsKey("-r") AndAlso arguments("-r") <> "" Then
                argumentsString &= " -r " & arguments("-r")
            End If
            If arguments.ContainsKey("-u") AndAlso arguments("-u") <> "" Then
                argumentsString &= " -u " & arguments("-u")
            End If
            If arguments.ContainsKey("-v") AndAlso arguments("-v") <> "" Then
                argumentsString &= " -v " & arguments("-v")
            End If
            If arguments.ContainsKey("-s") AndAlso arguments("-s") <> "" Then
                argumentsString &= " -s " & arguments("-s")
            End If
            If arguments.ContainsKey("-K") AndAlso arguments("-K") <> "" Then
                argumentsString &= " -K " & arguments("-K")
            End If
            If arguments.ContainsKey("-w") AndAlso arguments("-w") <> "" Then
                argumentsString &= arguments("-w")
            End If
            If arguments.ContainsKey("-Z") AndAlso arguments("-Z") <> "" Then
                argumentsString &= arguments("-Z")
            End If
            If arguments.ContainsKey("-D") AndAlso arguments("-D") <> "" Then
                argumentsString &= arguments("-D")
            End If
            If arguments.ContainsKey("-G") AndAlso arguments("-G") <> "" Then
                argumentsString &= arguments("-G")
            End If
        End If

        ' Start the process and redirect the output
        Dim processStartInfo As New ProcessStartInfo(plotFilePath, argumentsString)
        processStartInfo.WorkingDirectory = plotDirectory
        processStartInfo.RedirectStandardOutput = True
        processStartInfo.RedirectStandardError = True
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = True ' suppress console window
        cmdProcess = New Process()
        cmdProcess.StartInfo = processStartInfo
        AddHandler cmdProcess.OutputDataReceived, AddressOf ConsoleOutputReceived
        AddHandler cmdProcess.ErrorDataReceived, AddressOf ConsoleOutputReceived
        cmdProcess.Start()

        cmdProcess.BeginOutputReadLine()
        cmdProcess.BeginErrorReadLine()
    End Sub

    Private Sub ConsoleOutputReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then
            ' Append the new console output to the TextBox on the UI thread
            ConsolePrintOutTextBox.Invoke(Sub() ConsolePrintOutTextBox.AppendText(e.Data & vbCrLf))
        End If
    End Sub

    Private Sub PlotButton_Click(sender As Object, e As EventArgs) Handles PlotButton.Click
        StartPlotProcess()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFormToolStripMenuItem.Click
        PMCPURadio.Checked = True
        PMGPURadio.Checked = False
        arguments("-k") = ""
        KValueCombo.Text = ""
        DebugKValue.Text = ""
        arguments("-C") = ""
        CLCombo.Text = ""
        DebugCL.Text = ""
        arguments("-x") = ""
        CPortCombo.Text = ""
        CPortText.Text = ""
        DebugCPort.Text = ""
        arguments("-n") = ""
        NPlotsCheck.Checked = False
        DebugNPlots.Text = ""
        arguments("-t") = ""
        TempDir1Text.Text = ""
        DebugTempDir1.Text = ""
        arguments("-2") = ""
        TempDir2Text.Text = ""
        DebugTempDir2.Text = ""
        TempDir2Check.Checked = False
        arguments("-3") = ""
        TempDir3Text.Text = ""
        DebugTempDir3.Text = ""
        TempDir3Check.Checked = False
        arguments("-d") = ""
        FinalDirText.Text = ""
        DebugFinalDir.Text = ""
        arguments("-p") = ""
        PoolKeyText.Text = ""
        PoolKeyRadio.Checked = False
        DebugPoolKey.Text = ""
        arguments("-c") = ""
        ContractKeyText.Text = ""
        ContractKeyRadio.Checked = True
        DebugContractKey.Text = ""
        arguments("-f") = ""
        FarmerKeyText.Text = ""
        DebugFarmerKey.Text = ""
        arguments("-Q") = ""
        MaxPlotsCacheTempDirText.Text = ""
        DebugMaxPlotsCacheTempDir.Text = ""
        arguments("-z") = ""
        RemoteCopyPortText.Text = ""
        DebugRemoteCopyPort.Text = ""
        arguments("-w") = ""
        WaitforCopyCheck.Checked = False
        DebugWaitforCopy.Text = ""
        arguments("-Z") = ""
        UniquePlotCheck.Checked = False
        DebugUniquePlot.Text = ""
        arguments("-K") = ""
        ThreadMultiplierP2Text.Text = ""
        DebugThreadMultiplierP2.Text = ""
        arguments("-s") = ""
        StageDirectoryText.Text = ""
        DebugStageDirectory.Text = ""
        arguments("-D") = ""
        DirectInFinalDirCheck.Checked = False
        DebugDirectInFinalDir.Text = ""
        arguments("-G") = ""
        AlternateTempDirCheck.Checked = False
        DebugAlternateTempDir.Text = ""
        arguments("-W") = ""
        MaxParallelCopiesCheck.Checked = False
        DebugMaxParalleCopies.Text = ""
        arguments("-r") = NumThreadsCombo.SelectedItem.ToString()
        NumThreadsCombo.Text = "4"
        DebugNumThreads.Text = "-r " & arguments("-r").ToString()
        arguments("-u") = BucketsText.Text.ToString()
        BucketsText.Text = "256"
        DebugBuckets.Text = "-u " & arguments("-u").ToString()
        arguments("-v") = BucketsP23Text.Text.ToString()
        BucketsP23Text.Text = BucketsText.Text
        DebugBucketsP23.Text = "-v " & arguments("-v").ToString()
        DebugPlotterPath.Text = ""
        DebugPlotter.Text = ""
    End Sub

    Private Sub AdvancedOptionsCheck_CheckedChanged(sender As Object, e As EventArgs) Handles AdvancedOptionsCheck.CheckedChanged
        If AdvancedOptionsCheck.Checked = True Then
            RemoteCopyPortLabel.Enabled = True
            RemoteCopyPortText.Enabled = True
            DebugRemoteCopyPort.Enabled = True
            WaitforCopyCheck.Enabled = True
            DebugWaitforCopy.Enabled = True
            UniquePlotCheck.Enabled = True
            DebugUniquePlot.Enabled = True
            ThreadMultiplierP2Label.Enabled = True
            ThreadMultiplierP2Text.Enabled = True
            DebugThreadMultiplierP2.Enabled = True
            DirectInFinalDirCheck.Enabled = True
            DebugDirectInFinalDir.Enabled = True
            AlternateTempDirCheck.Enabled = True
            DebugAlternateTempDir.Enabled = True
            StageDirectoryLabel.Enabled = True
            StageDirectoryText.Enabled = True
            StageDirectoryButton.Enabled = True
            DebugStageDirectory.Enabled = True
            MaxPlotstoCacheinTempDirLabel.Enabled = True
            MaxPlotsCacheTempDirText.Enabled = True
            DebugMaxPlotsCacheTempDir.Enabled = True
            MaxParallelCopiesCheck.Enabled = True
            DebugMaxParalleCopies.Enabled = True
        Else
            RemoteCopyPortLabel.Enabled = False
            arguments("-z") = ""
            RemoteCopyPortText.Text = ""
            DebugRemoteCopyPort.Text = ""
            RemoteCopyPortText.Enabled = False
            DebugRemoteCopyPort.Enabled = False
            arguments("-w") = ""
            WaitforCopyCheck.Checked = False
            WaitforCopyCheck.Enabled = False
            DebugWaitforCopy.Text = ""
            DebugWaitforCopy.Enabled = False
            arguments("-Z") = ""
            UniquePlotCheck.Checked = False
            UniquePlotCheck.Enabled = False
            DebugUniquePlot.Text = ""
            DebugUniquePlot.Enabled = False
            ThreadMultiplierP2Label.Enabled = False
            arguments("-K") = ""
            ThreadMultiplierP2Text.Text = ""
            ThreadMultiplierP2Text.Enabled = False
            DebugThreadMultiplierP2.Text = ""
            DebugThreadMultiplierP2.Enabled = False
            arguments("-D") = ""
            DirectInFinalDirCheck.Checked = False
            DirectInFinalDirCheck.Enabled = False
            DebugDirectInFinalDir.Text = ""
            DebugDirectInFinalDir.Enabled = False
            arguments("-G") = ""
            AlternateTempDirCheck.Checked = False
            AlternateTempDirCheck.Enabled = False
            DebugAlternateTempDir.Text = ""
            DebugAlternateTempDir.Enabled = False
            StageDirectoryLabel.Enabled = False
            arguments("-s") = ""
            StageDirectoryText.Text = ""
            StageDirectoryText.Enabled = False
            StageDirectoryButton.Enabled = False
            DebugStageDirectory.Text = ""
            DebugStageDirectory.Enabled = False
            MaxPlotstoCacheinTempDirLabel.Enabled = False
            arguments("-Q") = ""
            MaxPlotsCacheTempDirText.Text = ""
            MaxPlotsCacheTempDirText.Enabled = False
            DebugMaxPlotsCacheTempDir.Text = ""
            DebugMaxPlotsCacheTempDir.Enabled = False
            arguments("-W") = ""
            MaxParallelCopiesCheck.Checked = False
            MaxParallelCopiesCheck.Enabled = False
            DebugMaxParalleCopies.Text = ""
            DebugMaxParalleCopies.Enabled = False
        End If
    End Sub

    Private Sub RemoteCopyPortText_TextChanged(sender As Object, e As EventArgs) Handles RemoteCopyPortText.TextChanged
        arguments("-z") = CInt(RemoteCopyPortText.Text)
        If arguments.ContainsKey("-z") Then
            DebugRemoteCopyPort.Text = "-z " & arguments("-z")
        Else
            DebugRemoteCopyPort.Text = "No port selected"
        End If
        Debug.WriteLine(arguments("-z"))
    End Sub

    Private Sub DebugRemoteCopyPort_Click(sender As Object, e As EventArgs) Handles DebugRemoteCopyPort.Click

    End Sub

    Private Sub WaitforCopyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles WaitforCopyCheck.CheckedChanged
        If WaitforCopyCheck.Checked = True Then arguments("-w") = "-w"
        If arguments.ContainsKey("-w") Then
            DebugWaitforCopy.Text = arguments("-w")
        Else
            DebugWaitforCopy.Text = "No port selected"
        End If
        Debug.WriteLine(arguments("-w"))
    End Sub

    Private Sub UniquePlotCheck_CheckedChanged(sender As Object, e As EventArgs) Handles UniquePlotCheck.CheckedChanged
        If WaitforCopyCheck.Checked = True Then arguments("-Z") = "-Z"
        If arguments.ContainsKey("-Z") Then
            DebugWaitforCopy.Text = arguments("-Z")
        Else
            DebugWaitforCopy.Text = "Error"
        End If
        Debug.WriteLine(arguments("-Z"))
    End Sub

    Private Sub ThreadMultiplierP2Text_TextChanged(sender As Object, e As EventArgs) Handles ThreadMultiplierP2Text.TextChanged
        If Not String.IsNullOrEmpty(ThreadMultiplierP2Text.Text) Then
            Dim multiplierValue As Integer
            If Integer.TryParse(ThreadMultiplierP2Text.Text, multiplierValue) Then
                arguments("-K") = multiplierValue
                DebugThreadMultiplierP2.Text = "-K " & multiplierValue
                Debug.WriteLine(arguments("-K"))
            Else
                ThreadMultiplierP2Text.Text = ""
                arguments.Remove("-K") ' Remove the "-K" key if non-integer values are entered
                DebugThreadMultiplierP2.Text = "No multiplier"
                Debug.WriteLine("Invalid multiplier")
            End If
        Else
            arguments.Remove("-K") ' Remove the "-K" key if the text box is empty
            DebugThreadMultiplierP2.Text = "No multiplier"
        End If
    End Sub


    Private Sub DebugThreadMultiplierP2_Click(sender As Object, e As EventArgs) Handles DebugThreadMultiplierP2.Click

    End Sub

    Private Sub StageDirectoryText_TextChanged(sender As Object, e As EventArgs) Handles StageDirectoryText.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        Dim path As String = textbox.Text
        If Not String.IsNullOrEmpty(path) AndAlso path.EndsWith("\") Then
            arguments("-s") = path
        Else
            DebugStageDirectory.Text = "Invalid Path"
        End If
        If arguments.ContainsKey("-s") Then
            DebugStageDirectory.Text = "-s " & arguments("-s").ToString()
        Else
            DebugStageDirectory.Text = "Invalid Path"
        End If
        Debug.WriteLine("-s " & arguments("-s"))
    End Sub

    Private Sub StageDirectoryButton_Click(sender As Object, e As EventArgs) Handles StageDirectoryButton.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = DialogResult.OK Then
                Dim path As String = fbd.SelectedPath
                If path <> String.Empty AndAlso Not path.EndsWith("\") Then '<-- Check for empty string
                    path &= "\" '<-- Append to end of path
                End If
                If System.IO.Directory.Exists(path) Then '<-- Check if folder exists
                    StageDirectoryText.Text = path '<-- set text to path
                Else
                    Debug.Print("Invalid Path")
                End If
            End If
        End Using
    End Sub

    Private Sub DebugStageDirectory_Click(sender As Object, e As EventArgs) Handles DebugStageDirectory.Click

    End Sub

    Private Sub DirectInFinalDirCheck_CheckedChanged(sender As Object, e As EventArgs) Handles DirectInFinalDirCheck.CheckedChanged
        If DirectInFinalDirCheck.Checked = True Then arguments("-D") = "-D"
        If arguments.ContainsKey("-D") Then
            DebugDirectInFinalDir.Text = arguments("-D")
        Else
            DebugDirectInFinalDir.Text = "Error"
        End If
        Debug.WriteLine(arguments("-D"))
    End Sub

    Private Sub DebugDirectInFinalDir_Click(sender As Object, e As EventArgs) Handles DebugDirectInFinalDir.Click

    End Sub

    Private Sub AlternateTempDirCheck_CheckedChanged(sender As Object, e As EventArgs) Handles AlternateTempDirCheck.CheckedChanged
        If AlternateTempDirCheck.Checked = True Then arguments("-D") = "-D"
        If arguments.ContainsKey("-G") Then
            DebugAlternateTempDir.Text = arguments("-G")
        Else
            DebugAlternateTempDir.Text = "Error"
        End If
        Debug.WriteLine(arguments("-G"))
    End Sub

    Private Sub DebugAlternateTempDir_Click(sender As Object, e As EventArgs) Handles DebugAlternateTempDir.Click

    End Sub

    Private Sub MaxPlotsCacheTempDirText_TextChanged(sender As Object, e As EventArgs) Handles MaxPlotsCacheTempDirText.TextChanged
        If Not String.IsNullOrEmpty(MaxPlotsCacheTempDirText.Text) Then
            Dim cacheValue As Integer
            If Integer.TryParse(MaxPlotsCacheTempDirText.Text, cacheValue) Then
                arguments("-Q") = cacheValue
                DebugMaxPlotsCacheTempDir.Text = "-Q " & cacheValue.ToString()
                Debug.WriteLine("-Q " & cacheValue)
            Else
                MaxPlotsCacheTempDirText.Text = ""
                arguments.Remove("-Q") ' Remove the "-Q" key if non-integer values are entered
                DebugMaxPlotsCacheTempDir.Text = "Invalid Entry"
                Debug.WriteLine("Invalid cache value")
            End If
        Else
            arguments.Remove("-Q") ' Remove the "-Q" key if the text box is empty
            DebugMaxPlotsCacheTempDir.Text = "Invalid Entry"
        End If
    End Sub


    Private Sub DebugMaxPlotsCacheTempDir_Click(sender As Object, e As EventArgs) Handles DebugMaxPlotsCacheTempDir.Click

    End Sub

    Private Sub MaxParallelCopiesCheck_CheckedChanged(sender As Object, e As EventArgs) Handles MaxParallelCopiesCheck.CheckedChanged
        If MaxParallelCopiesCheck.Checked = True Then arguments("-W") = "-W"
        If arguments.ContainsKey("-W") Then
            DebugMaxParalleCopies.Text = arguments("-W")
        Else
            DebugMaxParalleCopies.Text = "Error"
        End If
        Debug.WriteLine(arguments("-W"))
    End Sub

    Private Sub DebugMaxParalleCopies_Click(sender As Object, e As EventArgs) Handles DebugMaxParalleCopies.Click

    End Sub

    Private Sub ConsolePrintOutTextBox_TextChanged(sender As Object, e As EventArgs) Handles ConsolePrintOutTextBox.TextChanged
        ' Scroll the TextBox control to the bottom to show the latest output
        ConsolePrintOutTextBox.SelectionStart = ConsolePrintOutTextBox.Text.Length
        ConsolePrintOutTextBox.ScrollToCaret()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cleanup the hidden window when the form is closing
        FreeConsole()
        If consoleWindowHandle <> IntPtr.Zero Then
            ShowWindow(consoleWindowHandle, SW_SHOW)
        End If
    End Sub

    Private Sub SoftStopButton_Click(sender As Object, e As EventArgs) Handles SoftStopButton.Click
        If cmdProcess IsNot Nothing AndAlso Not cmdProcess.HasExited Then
            ' Send the Ctrl+C signal to the process
            GenerateConsoleCtrlEvent(CTRL_C_EVENT, cmdProcess.SessionId)

            ' Wait for the process to exit
            cmdProcess.WaitForExit()

            ' Cleanup the process resources
            cmdProcess.Close()
            cmdProcess.Dispose()
            cmdProcess = Nothing
        End If
    End Sub

    Private Sub HardStopButton_Click(sender As Object, e As EventArgs) Handles HardStopButton.Click
        If cmdProcess IsNot Nothing AndAlso Not cmdProcess.HasExited Then
            ' Kill the process
            cmdProcess.Kill()

            ' Wait for the process to exit
            cmdProcess.WaitForExit()

            ' Cleanup the process resources
            cmdProcess.Close()
            cmdProcess.Dispose()
            cmdProcess = Nothing

            PauseButton.Enabled = True
            ResumeButton.Enabled = False
        End If
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        If cmdProcess IsNot Nothing AndAlso Not cmdProcess.HasExited Then
            ' Suspend the main thread of the process
            Dim hThread As IntPtr = OpenThread(THREAD_ALL_ACCESS, False, cmdProcess.Threads(0).Id)
            SuspendThread(hThread)

            ' Update the GUI to indicate that the process is paused
            PauseButton.Enabled = False
            ResumeButton.Enabled = True

            ' Cleanup the thread handle
            CloseHandle(hThread)
        End If
    End Sub

    Private Sub ResumeButton_Click(sender As Object, e As EventArgs) Handles ResumeButton.Click
        If cmdProcess IsNot Nothing AndAlso Not cmdProcess.HasExited Then
            ' Resume the main thread of the process
            Dim hThread As IntPtr = OpenThread(THREAD_ALL_ACCESS, False, cmdProcess.Threads(0).Id)
            ResumeThread(hThread)

            ' Update the GUI to indicate that the process is resumed
            PauseButton.Enabled = True
            ResumeButton.Enabled = False

            ' Cleanup the thread handle
            CloseHandle(hThread)
        End If
    End Sub
End Class
