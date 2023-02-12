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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDebugControlsVisibility(False)
        PopulateCLCombo()
        PopulateNumThreadsCombo()
        PopulateCPortCombo()
        ReadOrCreateConfigFile()
        CorrectMissingConfigFileEntries()
    End Sub

    Private Sub SetDebugControlsVisibility(visible As Boolean)
        DebugPM.Visible = visible
        DebugKValue.Visible = visible
        DebugCL.Visible = visible
        DebugNPlots.Visible = visible
        DebugTempDir1.Visible = visible
        DebugTempDir2.Visible = visible
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

    Private Sub ReadOrCreateConfigFile()
        If System.IO.File.Exists(configFilePath) Then
            ReadConfigFile()
        Else
            CreateConfigFile()
        End If
    End Sub

    Private Sub ReadConfigFile()
        ' Read the config file
        Dim configContent As String = System.IO.File.ReadAllText(configFilePath)
        ' Parse the config content into a dictionary
        For Each line As String In configContent.Split(Environment.NewLine)
            Dim parts As String() = line.Split("=")
            If parts.Length = 2 Then
                cliPrograms(parts(0)) = parts(1)
            End If
        Next
        ' Check if the file paths for each program are present and valid
        For Each program In cliPrograms
            Dim filePath As String = ""
            If cliPrograms.TryGetValue(program.Key, filePath) Then
                If System.IO.File.Exists(filePath) Then
                    ' The file path is valid, move on to the next program
                    Continue For
                End If
            End If

            ' The file path is not present or invalid
            ' Prompt the user to select the correct path using the Windows File Explorer dialog box
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
    End Sub

    Private Sub CreateConfigFile()
        For Each program In cliPrograms
            Dim openFileDialog As New OpenFileDialog With {
                .Filter = program.Value & "|" & program.Value,
                .Title = "Select " & program.Value
            }
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Update the file path in the dictionary
                Dim filePath As String = openFileDialog.FileName
                cliPrograms(program.Key) = filePath
            End If
        Next
        ' Write the file paths to the new config file
        Dim configBuilder As New StringBuilder()
        For Each argument In cliPrograms
            configBuilder.AppendLine(argument.Key & "=" & argument.Value)
        Next
        System.IO.File.WriteAllText(configFilePath, configBuilder.ToString())
    End Sub

    Private Sub CorrectMissingConfigFileEntries()
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

            ' Check if the file paths for each program are present and valid
            For Each program In cliPrograms
                Dim filePath As String = ""
                If cliPrograms.TryGetValue(program.Key, filePath) Then
                    If System.IO.File.Exists(filePath) Then
                        ' The file path is valid, move on to the next program
                        Continue For
                    End If
                End If

                ' The file path is not present or invalid
                ' Prompt the user to select the correct path using the Windows File Explorer dialog box
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
            ' Create a new config file and prompt the user to select the correct path for each program
            For Each program In cliPrograms
                Dim openFileDialog As New OpenFileDialog With {
                    .Filter = program.Value & "|" & program.Value,
                    .Title = "Select " & program.Value
                }
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    ' Update the file path in the dictionary
                    Dim filePath As String = openFileDialog.FileName
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

    Private Sub DebugModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugModeToolStripMenuItem.Click
        DebugModeToolStripMenuItem.Checked = Not DebugModeToolStripMenuItem.Checked
        DebugPM.Visible = DebugModeToolStripMenuItem.Checked
        DebugKValue.Visible = DebugModeToolStripMenuItem.Checked
        DebugCL.Visible = DebugModeToolStripMenuItem.Checked
        DebugNPlots.Visible = DebugModeToolStripMenuItem.Checked
        DebugTempDir1.Visible = DebugModeToolStripMenuItem.Checked
        DebugTempDir2.Visible = DebugModeToolStripMenuItem.Checked
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
            MaxMemText.Text = "8"
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
        Debug.WriteLine(arguments("-x"))
    End Sub

    Private Sub CPortText_TextChanged(sender As Object, e As EventArgs) Handles CPortText.TextChanged
        If CPortCombo.SelectedItem.ToString() = "Other" AndAlso Not String.IsNullOrEmpty(CPortText.Text) Then
            portValues("Other") = CInt(CPortText.Text)
            arguments("-x") = CInt(CPortText.Text)
        End If
        If arguments.ContainsKey("-x") Then
            DebugCPort.Text = "-x " & arguments("-x")
        Else
            DebugCPort.Text = "No port selected"
        End If
        Debug.WriteLine(arguments("-x"))
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

    Private Sub TempDir1Check_CheckedChanged(sender As Object, e As EventArgs) Handles TempDir1Check.CheckedChanged
        Dim checkbox As CheckBox = DirectCast(sender, CheckBox)

        If checkbox.Checked Then
            TempDir1Text.Text = Path.GetTempPath()
            TempDir1Text.Enabled = False
        Else
            TempDir1Text.Enabled = True
        End If
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
            TempDir2Text.Text = Path.GetTempPath()
            TempDir2Text.Enabled = False
        Else
            TempDir2Text.Enabled = True
        End If
    End Sub

    Private Sub DebugTempDir2_Click(sender As Object, e As EventArgs) Handles DebugTempDir2.Click

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

    Private Sub FinalDirCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FinalDirCheck.CheckedChanged
        Dim checkbox As CheckBox = DirectCast(sender, CheckBox)

        If checkbox.Checked Then
            FinalDirText.Text = Path.GetTempPath()
            FinalDirText.Enabled = False
        Else
            FinalDirText.Enabled = True
        End If
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
                If mem < 8 Then
                End If
                arguments("-M") = MaxMemText.Text.ToString()
            Catch ex As FormatException
                MessageBox.Show("Invalid input. Please enter a valid integer.")
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

    Private Sub PlotButton_Click(sender As Object, e As EventArgs) Handles PlotButton.Click
        Dim argumentsString As String = ""
        Dim plotFilePath As String = Path.Combine(arguments("-plp").ToString(), arguments("-pl").ToString())
        Dim plotDirectory As String = Path.GetDirectoryName(plotFilePath)

        Dim commonArguments() As String = {"-k", "-C", "-x", "-n", "-t", "-2", "-d", "-p", "-c", "-f"}

        If PMGPURadio.Checked Then
            For Each arg In commonArguments
                If arguments.ContainsKey(arg) AndAlso arguments(arg) <> "" Then
                    argumentsString &= " " & arg & " " & arguments(arg)
            End If
            Next
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
        ElseIf PMCPURadio.Checked Then
            For Each arg In commonArguments
                If arguments.ContainsKey(arg) AndAlso arguments(arg) <> "" Then
                    argumentsString &= " " & arg & " " & arguments(arg)
            End If
            Next
            If arguments.ContainsKey("-r") AndAlso arguments("-r") <> "" Then
                argumentsString &= " -r " & arguments("-r")
            End If
            If arguments.ContainsKey("-u") AndAlso arguments("-u") <> "" Then
                argumentsString &= " -u " & arguments("-u")
            End If
            If arguments.ContainsKey("-v") AndAlso arguments("-v") <> "" Then
                argumentsString &= " -v " & arguments("-v")
            End If
            End If

            Dim processStartInfo As New ProcessStartInfo(plotFilePath, argumentsString)
            processStartInfo.WorkingDirectory = plotDirectory
            Dim cmdProcess As New Process()
            cmdProcess.StartInfo = processStartInfo
            cmdProcess.Start()
    End Sub

End Class
