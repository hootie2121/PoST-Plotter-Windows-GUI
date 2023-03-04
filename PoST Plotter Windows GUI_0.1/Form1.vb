Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.Threading
Imports System.Windows.Forms

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

    Private cmdProcess As Process
    Private consoleWindowHandle As IntPtr

    Private Declare Function OpenThread Lib "kernel32.dll" (dwDesiredAccess As Integer, bInheritHandle As Boolean, dwThreadId As Integer) As IntPtr
    Private Declare Function SuspendThread Lib "kernel32.dll" (hThread As IntPtr) As Integer
    Private Declare Function ResumeThread Lib "kernel32.dll" (hThread As IntPtr) As Integer
    Private Declare Function CloseHandle Lib "kernel32.dll" (hObject As IntPtr) As Boolean

    Private Const THREAD_ALL_ACCESS As Integer = &H1F03FF

    Private PlotProgress As Integer = 0

    Dim currentDirectory As String = Environment.CurrentDirectory
    Private longestPlotTime As Double = 0.0
    Private shortestPlotTime As Double = Double.PositiveInfinity
    Private totalPlotTime As Double = 0.0
    Private plotTimeCount As Integer = 0

    Private WithEvents Timer1 As New System.Windows.Forms.Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDebugControlsVisibility(False)
        PopulateCLCombo()
        PopulateNumThreadsCombo()
        PopulateCPortCombo()
        SourcePlotForm()
        TempDir2Check.Checked = True
        TempDir3Check.Checked = True
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
        PlotControls.Enabled = False

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

        ' Get the current version number from the VersioningToolStripMenuItem
        Dim currentVersion As String = VersioningToolStripMenuItem.Text.Replace("Version ", "")

        ' Define the URL of the latest release information
        Dim url As String = "https://api.github.com/repos/hootie2121/PoST-Plotter-Windows-GUI/releases/latest"

        ' Use HttpClient to download the latest release information as JSON
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0")
        Dim response As HttpResponseMessage = client.GetAsync(url).Result
        Dim json As String = response.Content.ReadAsStringAsync().Result

        ' Parse the JSON to get the latest version number and release URL
        Dim latestRelease As JObject = JObject.Parse(json)
        Dim latestVersion As String = latestRelease("tag_name").ToString()
        Dim latestUrl As String = latestRelease("assets")(0)("browser_download_url").ToString()

        Dim latestVersionValid As Boolean = Version.TryParse(latestVersion, Nothing)

        If Not latestVersionValid Then
            ' Handle error: latest version is not in the correct format
            DebugPlotterGUIUpdater.Text = "Error"
            DebugPlotterGUIUpdater.ForeColor = Color.Red
            DebugPlotterGUIUpdater.Font = New Font(DebugPlotterGUIUpdater.Font, FontStyle.Regular)
            DebugPlotterGUIUpdater.Cursor = Cursors.Default
        ElseIf String.Compare(currentVersion, latestVersion) < 0 Then ' Check if latest version is greater than the current version
            ' Display a message to the user that an update is available
            DebugPlotterGUIUpdater.Text = "Update Available"
            DebugPlotterGUIUpdater.ForeColor = Color.Blue
            DebugPlotterGUIUpdater.Font = New Font(DebugPlotterGUIUpdater.Font, FontStyle.Underline)
            DebugPlotterGUIUpdater.Cursor = Cursors.Hand
        ElseIf String.Compare(currentVersion, latestVersion) = 0 Then ' Check if latest version is the same as the current version
            ' Display a message to the user that the program is up to date
            DebugPlotterGUIUpdater.Text = "Up-to-Date"
            DebugPlotterGUIUpdater.ForeColor = Color.Black
            DebugPlotterGUIUpdater.Font = New Font(DebugPlotterGUIUpdater.Font, FontStyle.Regular)
            DebugPlotterGUIUpdater.Cursor = Cursors.Default
        Else
            ' Display a message to the user that a beta build is available
            DebugPlotterGUIUpdater.Text = "Beta-Build"
            DebugPlotterGUIUpdater.ForeColor = Color.Orange
            DebugPlotterGUIUpdater.Font = New Font(DebugPlotterGUIUpdater.Font, FontStyle.Regular)
            DebugPlotterGUIUpdater.Cursor = Cursors.Default
        End If

        Debug.WriteLine("currentversion: " & currentVersion)
        Debug.WriteLine("latestVersion: " & latestVersion)

        ' Set up a timer to check for updates once per day
        Dim updateTimer As New System.Windows.Forms.Timer()
        AddHandler updateTimer.Tick, AddressOf UpdateTimer_Tick
        updateTimer.Interval = 86400000 ' One day in milliseconds
        updateTimer.Start()
    End Sub

    Private Function GetLatestVersion() As String
        ' Define the URL of the latest release information
        Dim url As String = "https://api.github.com/repos/hootie2121/PoST-Plotter-Windows-GUI/releases/latest"

        ' Use HttpClient to download the latest release information as JSON
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0")
        Dim response As HttpResponseMessage = client.GetAsync(url).Result
        Dim json As String = response.Content.ReadAsStringAsync().Result

        ' Parse the JSON to get the latest version number and release URL
        Dim latestRelease As JObject = JObject.Parse(json)
        Dim latestVersion As String = latestRelease("tag_name").ToString()

        Return latestVersion
    End Function

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

    Private Sub SourcePlotForm()
        ' Set the timer to update the grid every 5 minutes
        Timer1.Interval = 500000000
        Timer1.Enabled = True

        AddSourceButton.Enabled = False

        ' Add the "SourceDirectory" column
        Dim sourceDirectoryColumn As New DataGridViewTextBoxColumn()
        sourceDirectoryColumn.HeaderText = "Source Directory"
        sourceDirectoryColumn.Name = "SourceDirectory"
        SourcePlotDataGrid.Columns.Add(sourceDirectoryColumn)

        ' Add the "PercentAvailableSpace" column
        Dim percentAvailableSpaceColumn As New DataGridViewTextBoxColumn()
        percentAvailableSpaceColumn.HeaderText = "Available Space (%)"
        percentAvailableSpaceColumn.Name = "PercentAvailableSpace"
        SourcePlotDataGrid.Columns.Add(percentAvailableSpaceColumn)

        ' Add the "GBAvailableSpace" column
        Dim gbAvailableSpaceColumn As New DataGridViewTextBoxColumn()
        gbAvailableSpaceColumn.HeaderText = "Available Space (GB)"
        gbAvailableSpaceColumn.Name = "GBAvailableSpace"
        SourcePlotDataGrid.Columns.Add(gbAvailableSpaceColumn)

        ' Add columns for K30 to K34
        For Each kSize In Enumerable.Range(30, 5)
            Dim columnHeaderText As String = "K" & kSize.ToString()
            Dim column As New DataGridViewTextBoxColumn()
            column.HeaderText = columnHeaderText
            column.Name = columnHeaderText
            column.Visible = False
            SourcePlotDataGrid.Columns.Add(column)
            Debug.WriteLine($"Added column: {columnHeaderText}")
        Next

        ' Add the "TotalPlots" column
        Dim totalPlotsColumn As New DataGridViewTextBoxColumn()
        totalPlotsColumn.HeaderText = "Total Plots"
        totalPlotsColumn.Name = "TotalPlots"
        SourcePlotDataGrid.Columns.Add(totalPlotsColumn)
        Debug.WriteLine("Added column: TotalPlots")

        ' Add the "Remove" button column
        Dim removeButtonColumn As New DataGridViewButtonColumn()
        removeButtonColumn.Text = "Delete"
        removeButtonColumn.UseColumnTextForButtonValue = True
        removeButtonColumn.Name = "RemoveButton"
        removeButtonColumn.HeaderText = ""
        SourcePlotDataGrid.Columns.Add(removeButtonColumn)

        ' Set the default cell style for the DataGridView to remove underlining
        Dim cellStyle As New DataGridViewCellStyle()
        cellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
        cellStyle.BackColor = Color.White
        cellStyle.SelectionBackColor = Color.LightGray
        cellStyle.SelectionForeColor = Color.Black
        cellStyle.WrapMode = DataGridViewTriState.True
        cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        cellStyle.Font = New Font(cellStyle.Font, FontStyle.Regular) ' remove underlining

        SourcePlotDataGrid.DefaultCellStyle = cellStyle
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

    Private Sub PMCPURadio_CheckedChanged(sender As Object, e As EventArgs)
        If PMCPURadio.Checked Then
            UpdateProcessingMode("CPU")
        End If
    End Sub

    Private Sub PMGPURadio_CheckedChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugPM_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub KValueCombo_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugKValue_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CLCombo_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugCL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CPortCombo_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    Private Sub CPortText_TextChanged(sender As Object, e As EventArgs)
        If CPortCombo.SelectedItem IsNot Nothing AndAlso CPortCombo.SelectedItem.ToString() = "Other" AndAlso Not String.IsNullOrEmpty(CPortText.Text) Then
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

    Private Sub DebugCPort_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NPlotsText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub NPlotsCheck_CheckedChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugNPlots_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TempDir1Text_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub TempDir1Button_Click(sender As Object, e As EventArgs)
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

    Private Sub DebugTempDir1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TempDir2Text_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub TempDir2Button_Click(sender As Object, e As EventArgs)
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

    Private Sub TempDir2Check_CheckedChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugTempDir2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TempDir3Text_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub TempDir3Button_Click(sender As Object, e As EventArgs)
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

    Private Sub TempDir3Check_CheckedChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugTempDir3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FinalDirText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub FinalDirButton_Click(sender As Object, e As EventArgs)
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

    Private Sub DebugFinalDir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PoolKeyText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub PoolKeyRadio_CheckedChanged(sender As Object, e As EventArgs)
        If PoolKeyRadio.Checked Then
            ContractKeyText.Enabled = False
            ContractKeyRadio.Checked = False
            ContractKeyText.Text = ""
        Else
            ContractKeyText.Enabled = True
        End If
    End Sub

    Private Sub ContractKeyText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub FarmerKeyText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub ContractKeyRadio_CheckedChanged(sender As Object, e As EventArgs)
        If ContractKeyRadio.Checked Then
            PoolKeyText.Enabled = False
            PoolKeyRadio.Checked = False
            PoolKeyText.Text = ""
        Else
            PoolKeyText.Enabled = True
        End If
    End Sub

    Private Sub NumThreadsCombo_SelectedIndexChanged(sender As Object, e As EventArgs)
        arguments("-r") = NumThreadsCombo.SelectedItem.ToString()
        If arguments.ContainsKey("-r") Then
            DebugNumThreads.Text = "-r " & arguments("-r").ToString()
        Else
            DebugNumThreads.Text = "Invalid Value"
        End If
        Debug.WriteLine("-r " & arguments("-r"))
    End Sub

    Private Sub DebugNumThreads_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BucketsText_TextChanged(sender As Object, e As EventArgs)
        arguments("-u") = BucketsText.Text.ToString()
        If arguments.ContainsKey("-u") Then
            DebugBuckets.Text = "-u " & arguments("-u").ToString()
        Else
            DebugBuckets.Text = "Invalid Value"
        End If
        Debug.WriteLine("-u " & arguments("-u"))
        BucketsP23Text.Text = BucketsText.Text
    End Sub

    Private Sub DebugBuckets_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BucketsP23Text_TextChanged(sender As Object, e As EventArgs)
        arguments("-v") = BucketsP23Text.Text.ToString()
        If arguments.ContainsKey("-v") Then
            DebugBucketsP23.Text = "-v " & arguments("-v").ToString()
        Else
            DebugBucketsP23.Text = "Invalid Value"
        End If
        Debug.WriteLine("-v " & arguments("-v"))
    End Sub

    Private Sub DebugBucketsP23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CudaDeviceText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub NumCudaText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugNumCuda_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StreamsText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugStreams_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaxMemText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugMaxMem_Click(sender As Object, e As EventArgs)

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

    Private Sub DebugPlotterPath_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugPlotter_Click(sender As Object, e As EventArgs)

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

        ' Reset the progress bar and the total progress variable
        PlotProgress = 0
        PlotProgressBar.Value = 0

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

            ' Check for progress phrases in the console output
            If e.Data.Contains("Plot Name:") Then
                PlotProgress = 0
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Setup took") Then
                PlotProgress = 3
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 1") Then
                PlotProgress = 6
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 2") Then
                PlotProgress = 9
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 3") Then
                PlotProgress = 13
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 4") Then
                PlotProgress = 16
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 5") Then
                PlotProgress = 19
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 6") Then
                PlotProgress = 22
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P1] Table 7") Then
                PlotProgress = 25
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("Phase 1 took") Then
                PlotProgress = 28
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P2] Setup took") Then
                PlotProgress = 31
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P2] Table 7") Then
                PlotProgress = 34
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P2] Table 6") Then
                PlotProgress = 38
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P2] Table 5") Then
                PlotProgress = 41
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("Phase 2 took") Then
                PlotProgress = 44
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Setup took") Then
                PlotProgress = 47
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 4 LPSK") Then
                PlotProgress = 50
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 4 NSK") Then
                PlotProgress = 53
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 5 PDSK") Then
                PlotProgress = 56
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 5 LPSK") Then
                PlotProgress = 59
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 5 LPSK") Then
                PlotProgress = 63
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 6 PDSK") Then
                PlotProgress = 66
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 6 LPSK") Then
                PlotProgress = 69
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 6 NSK") Then
                PlotProgress = 72
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 7 PDSK") Then
                PlotProgress = 75
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 7 LPSK") Then
                PlotProgress = 78
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P3] Table 7 NSK") Then
                PlotProgress = 81
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("Phase 3 took") Then
                PlotProgress = 84
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P4] Setup took") Then
                PlotProgress = 88
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P4] total_p7_parks") Then
                PlotProgress = 91
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("[P4] total_c3_parks") Then
                PlotProgress = 94
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("Phase 4 took") Then
                PlotProgress = 97
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            ElseIf e.Data.Contains("Total plot creation time was") Then
                PlotProgress = 100
                PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)
            End If
            ' Check for progress phrases in the console output
            If e.Data.Contains("Crafting plot") Then
                ' Extract the plot number from the line
                Dim plotNum As Integer = Integer.Parse(e.Data.Split(" "c)(2))
                ' Add the unit "Plot" or "Plots" based on whether the plot number is singular or plural
                Dim unit As String = If(plotNum = 1, "Plot", "Plots")
                ' Update the DebugNumPlotsCreated label with the extracted plot number and unit
                DebugNumPlotsCreated.Invoke(Sub() DebugNumPlotsCreated.Text = plotNum.ToString() & " " & unit)
            End If
            If e.Data.Contains("Total plot creation time was") Then
                ' Extract the time value from the line
                Dim timeStr As String = e.Data.Split("("c)(1).Split(" "c)(0)
                Dim time As Double = Double.Parse(timeStr)
                ' Update the longestPlotTime variable if the new time value is higher
                longestPlotTime = Math.Max(longestPlotTime, time)
                ' Update the DebugLongestPlotTime label with the highest time value seen so far
                DebugLongestPlotTime.Invoke(Sub() DebugLongestPlotTime.Text = longestPlotTime.ToString() & " Minutes")
            End If
            ' Check for progress phrases in the console output
            If e.Data.Contains("Total plot creation time was") Then
                ' Extract the time value from the line
                Dim timeStr As String = e.Data.Split("("c)(1).Split(" "c)(0)
                Dim time As Double = Double.Parse(timeStr)
                ' Update the shortestPlotTime variable if the new time value is shorter
                shortestPlotTime = Math.Min(shortestPlotTime, time)
                ' Update the DebugShortestPlotTime label with the shortest time value seen so far
                DebugShortestPlotTime.Invoke(Sub() DebugShortestPlotTime.Text = shortestPlotTime.ToString() & " Minutes")
            End If
            If e.Data.Contains("Total plot creation time was") Then
                ' Extract the time value from the message
                Dim timeStr As String = e.Data.Split("("c)(1).Split(" "c)(0)
                Dim time As Double = Double.Parse(timeStr)
                ' Update the lastPlotTime label with the new time value
                DebugLastPlotTime.Invoke(Sub() DebugLastPlotTime.Text = String.Format("{0:F5} Minutes", time))
            End If
            ' Check for progress phrases in the console output
            If e.Data.Contains("Total plot creation time was") Then
                ' Extract the time value from the line
                Dim timeStr As String = e.Data.Split("("c)(1).Split(" "c)(0)
                Dim time As Double = Double.Parse(timeStr)
                ' Update the totalPlotTime and plotTimeCount variables
                totalPlotTime += time
                plotTimeCount += 1
                ' Calculate the average plot time with 5 decimal places and update the DebugAveragePlotTime label
                Dim averagePlotTime As Double = totalPlotTime / plotTimeCount
                DebugAveragePlotTime.Invoke(Sub()
                                                DebugAveragePlotTime.Text = averagePlotTime.ToString("F5") & " Minutes"
                                                ' Calculate the plots per hour
                                                Dim plotsPerHour As Integer = Math.Floor(60 / averagePlotTime)
                                                If plotsPerHour < 1 Then
                                                    plotsPerHour = 0
                                                End If
                                                ' Determine the correct unit based on the result
                                                Dim unit As String
                                                If plotsPerHour = 1 Then
                                                    unit = "Plot/Hour"
                                                Else
                                                    unit = "Plots/Hour"
                                                End If
                                                ' Update the label with the plots per hour
                                                DebugEstPlotsPerHour.Text = plotsPerHour.ToString() & " " & unit
                                                ' Calculate the plots per day
                                                Dim plotsPerDay As Integer = Math.Floor(1440 / averagePlotTime)
                                                If plotsPerDay < 1 Then
                                                    plotsPerDay = 0
                                                End If
                                                ' Determine the correct unit based on the result
                                                If plotsPerDay = 1 Then
                                                    unit = "Plot/Day"
                                                Else
                                                    unit = "Plots/Day"
                                                End If
                                                ' Update the label with the plots per day
                                                DebugEstPlotsPerDay.Text = plotsPerDay.ToString() & " " & unit
                                            End Sub)
            End If
        End If
    End Sub

    Private Sub PlotButton_Click(sender As Object, e As EventArgs)
        StartPlotProcess()
        PlotControls.Enabled = True
        DebugLongestPlotTime.Text = ""
        DebugShortestPlotTime.Text = ""
        DebugAveragePlotTime.Text = ""
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFormToolStripMenuItem.Click
        PMCPURadio.Checked = True
        PMGPURadio.Checked = False
        For Each arg As String In {"-k", "-C", "-x", "-n", "-t", "-2", "-3", "-d", "-p", "-c", "-f", "-Q", "-z", "-w", "-Z", "-K", "-s", "-D", "-G", "-W", "-r", "-u", "-v"}
            arguments(arg) = ""
        Next
        For Each textControl As TextBox In {CPortText, TempDir1Text, TempDir2Text, TempDir3Text, FinalDirText, PoolKeyText, ContractKeyText, FarmerKeyText, MaxPlotsCacheTempDirText, RemoteCopyPortText, ThreadMultiplierP2Text, StageDirectoryText, BucketsText, BucketsP23Text}
            textControl.Text = ""
        Next
        For Each checkControl As CheckBox In {NPlotsCheck, TempDir2Check, TempDir3Check, WaitforCopyCheck, UniquePlotCheck, DirectInFinalDirCheck, AlternateTempDirCheck, MaxParallelCopiesCheck}
            checkControl.Checked = False
        Next
        KValueCombo.SelectedItem = ""
        CLCombo.SelectedItem = ""
        NumThreadsCombo.Text = "4"
        BucketsText.Text = "256"
        BucketsP23Text.Text = BucketsText.Text
        DebugKValue.Text = ""
        DebugCL.Text = ""
        DebugCPort.Text = ""
        DebugNPlots.Text = ""
        DebugTempDir1.Text = ""
        DebugTempDir2.Text = ""
        DebugTempDir3.Text = ""
        DebugFinalDir.Text = ""
        DebugPoolKey.Text = ""
        PoolKeyRadio.Checked = False
        DebugContractKey.Text = ""
        ContractKeyRadio.Checked = True
        DebugFarmerKey.Text = ""
        DebugMaxPlotsCacheTempDir.Text = ""
        DebugRemoteCopyPort.Text = ""
        DebugWaitforCopy.Text = ""
        DebugUniquePlot.Text = ""
        DebugThreadMultiplierP2.Text = ""
        DebugStageDirectory.Text = ""
        DebugDirectInFinalDir.Text = ""
        DebugAlternateTempDir.Text = ""
        DebugMaxParalleCopies.Text = ""
        DebugNumThreads.Text = "-r 4"
        DebugBuckets.Text = "-u 256"
        DebugBucketsP23.Text = "-v 256"
        DebugPlotterPath.Text = ""
        DebugPlotter.Text = ""
    End Sub

    Private Sub AdvancedOptionsCheck_CheckedChanged(sender As Object, e As EventArgs)
        Dim controls() As Control = {RemoteCopyPortLabel, RemoteCopyPortText, DebugRemoteCopyPort, WaitforCopyCheck, DebugWaitforCopy, UniquePlotCheck, DebugUniquePlot, ThreadMultiplierP2Label, ThreadMultiplierP2Text, DebugThreadMultiplierP2, DirectInFinalDirCheck, DebugDirectInFinalDir, AlternateTempDirCheck, DebugAlternateTempDir, StageDirectoryLabel, StageDirectoryText, StageDirectoryButton, DebugStageDirectory, MaxPlotstoCacheinTempDirLabel, MaxPlotsCacheTempDirText, DebugMaxPlotsCacheTempDir, MaxParallelCopiesCheck, DebugMaxParalleCopies}
        For Each control As Control In controls
            control.Enabled = AdvancedOptionsCheck.Checked
            If Not AdvancedOptionsCheck.Checked Then
                If TypeOf control Is CheckBox Then
                    CType(control, CheckBox).Checked = False
                ElseIf TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            End If
        Next
        If Not AdvancedOptionsCheck.Checked Then
            arguments("-z") = ""
            arguments("-w") = ""
            arguments("-Z") = ""
            arguments("-K") = ""
            arguments("-D") = ""
            arguments("-G") = ""
            arguments("-s") = ""
            arguments("-Q") = ""
            arguments("-W") = ""
            For Each debugControl As Control In {DebugRemoteCopyPort, DebugWaitforCopy, DebugUniquePlot, DebugThreadMultiplierP2, DebugDirectInFinalDir, DebugAlternateTempDir, DebugStageDirectory, DebugMaxPlotsCacheTempDir, DebugMaxParalleCopies}
                debugControl.Enabled = False
                debugControl.Text = ""
            Next
        End If
    End Sub

    Private Sub RemoteCopyPortText_TextChanged(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(RemoteCopyPortText.Text) Then
            Dim portValue As Integer
            If Integer.TryParse(RemoteCopyPortText.Text, portValue) Then
                arguments("-z") = portValue
                DebugRemoteCopyPort.Text = "-z " & portValue.ToString()
                Debug.WriteLine("-z " & portValue)
            Else
                RemoteCopyPortText.Text = ""
                arguments.Remove("-z") ' Remove the "-z" key if non-integer values are entered
                DebugRemoteCopyPort.Text = "No port selected"
                Debug.WriteLine("Invalid port value")
            End If
        Else
            arguments.Remove("-z") ' Remove the "-z" key if the text box is empty
            DebugRemoteCopyPort.Text = "No port selected"
        End If
    End Sub

    Private Sub DebugRemoteCopyPort_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WaitforCopyCheck_CheckedChanged(sender As Object, e As EventArgs)
        If WaitforCopyCheck.Checked = True Then arguments("-w") = "-w"
        If arguments.ContainsKey("-w") Then
            DebugWaitforCopy.Text = arguments("-w")
        Else
            DebugWaitforCopy.Text = "Error"
        End If
        Debug.WriteLine(arguments("-w"))
    End Sub

    Private Sub UniquePlotCheck_CheckedChanged(sender As Object, e As EventArgs)
        If WaitforCopyCheck.Checked = True Then arguments("-Z") = "-Z"
        If arguments.ContainsKey("-Z") Then
            DebugUniquePlot.Text = arguments("-Z")
        Else
            DebugUniquePlot.Text = "No port selected"
        End If
        Debug.WriteLine(arguments("-Z"))
    End Sub

    Private Sub DebugUniquePlot_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ThreadMultiplierP2Text_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugThreadMultiplierP2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StageDirectoryText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub StageDirectoryButton_Click(sender As Object, e As EventArgs)
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

    Private Sub DebugStageDirectory_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DirectInFinalDirCheck_CheckedChanged(sender As Object, e As EventArgs)
        If DirectInFinalDirCheck.Checked = True Then arguments("-D") = "-D"
        If arguments.ContainsKey("-D") Then
            DebugDirectInFinalDir.Text = arguments("-D")
        Else
            DebugDirectInFinalDir.Text = "Error"
        End If
        Debug.WriteLine(arguments("-D"))
    End Sub

    Private Sub DebugDirectInFinalDir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AlternateTempDirCheck_CheckedChanged(sender As Object, e As EventArgs)
        If AlternateTempDirCheck.Checked = True Then arguments("-G") = "-G"
        If arguments.ContainsKey("-G") Then
            DebugAlternateTempDir.Text = arguments("-G")
        Else
            DebugAlternateTempDir.Text = "Error"
        End If
        Debug.WriteLine(arguments("-G"))
    End Sub

    Private Sub DebugAlternateTempDir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaxPlotsCacheTempDirText_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub DebugMaxPlotsCacheTempDir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaxParallelCopiesCheck_CheckedChanged(sender As Object, e As EventArgs)
        If MaxParallelCopiesCheck.Checked = True Then arguments("-W") = "-W"
        If arguments.ContainsKey("-W") Then
            DebugMaxParalleCopies.Text = arguments("-W")
        Else
            DebugMaxParalleCopies.Text = "Error"
        End If
        Debug.WriteLine(arguments("-W"))
    End Sub

    Private Sub DebugMaxParalleCopies_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConsolePrintOutTextBox_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub StopPlotButton_Click(sender As Object, e As EventArgs)
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
            PlotControls.Enabled = False
            PlotProgress = 0
            PlotProgressBar.Invoke(Sub() PlotProgressBar.Value = PlotProgress)

            ' Delete any remaining files in the temp directories
            If arguments.ContainsKey("-t") AndAlso Directory.Exists(arguments("-t")) Then
                For Each filePath In Directory.GetFiles(arguments("-t"))
                    File.Delete(filePath)
                Next
            End If

            If arguments.ContainsKey("-2") AndAlso Directory.Exists(arguments("-2")) Then
                For Each filePath In Directory.GetFiles(arguments("-2"))
                    File.Delete(filePath)
                Next
            End If

            If arguments.ContainsKey("-3") AndAlso Directory.Exists(arguments("-3")) Then
                For Each filePath In Directory.GetFiles(arguments("-3"))
                    File.Delete(filePath)
                Next
            End If
        End If
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs)
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

    Private Sub ResumeButton_Click(sender As Object, e As EventArgs)
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

    Private Sub PlotProgressBar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReadMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadMeToolStripMenuItem.Click
        ' Define the URL
        Dim url As String = "https://github.com/hootie2121/PoST-Plotter-Windows-GUI/blob/master/README.md"

        ' Use the Process.Start method to open the default browser with the URL as an argument
        Process.Start("cmd", "/c start " & url)
    End Sub

    Private Sub GitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GitHubToolStripMenuItem.Click
        ' Define the URL
        Dim url As String = "https://github.com/hootie2121/PoST-Plotter-Windows-GUI"

        ' Use the Process.Start method to open the default browser with the URL as an argument
        Process.Start("cmd", "/c start " & url)
    End Sub

    Private Sub UpdateCheckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateCheckToolStripMenuItem.Click
        ' Define the URL of the latest release information
        Dim url As String = "https://api.github.com/repos/hootie2121/PoST-Plotter-Windows-GUI/releases/latest"

        ' Use HttpClient to download the latest release information as JSON
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0")
        Dim response As HttpResponseMessage = client.GetAsync(url).Result
        Dim json As String = response.Content.ReadAsStringAsync().Result

        ' Parse the JSON to get the latest version number and release URL
        Dim latestRelease As JObject = JObject.Parse(json)
        Dim latestVersion As String = latestRelease("tag_name").ToString()
        Dim latestUrl As String = latestRelease("assets")(0)("browser_download_url").ToString()

        ' Get the current version number from the VersioningToolStripMenuItem
        Dim currentVersion As String = VersioningToolStripMenuItem.Text.Replace("Version ", "")

        ' Compare the latest version to the current version
        If latestVersion <> currentVersion Then
            ' Check if the current version is newer than the latest version
            If String.Compare(currentVersion, latestVersion) > 0 Then
                ' Prompt the user to revert to the latest version
                Dim result As DialogResult = MessageBox.Show("This version is newer than the latest released version. Would you like to revert to the latest version?", "Revert to Latest Version", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    ' Prompt the user for confirmation to revert
                    Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to revert to the latest version?", "Confirm Revert", MessageBoxButtons.YesNo)

                    If confirmResult = DialogResult.Yes Then
                        ' Prompt the user with a warning before reverting
                        Dim warningResult As DialogResult = MessageBox.Show("This cannot be undone! Are you sure you want to revert to the latest version?", "Warning", MessageBoxButtons.YesNo)
                        If warningResult = DialogResult.Yes Then
                            ' Close the program
                            Me.Close()

                            ' Download and unzip the latest release file
                            Dim downloadClient As New HttpClient()
                            Dim downloadResponse As HttpResponseMessage = downloadClient.GetAsync(latestUrl).Result
                            Dim bytes As Byte() = downloadResponse.Content.ReadAsByteArrayAsync().Result
                            System.IO.File.WriteAllBytes("latest.zip", bytes)

                            Try
                                ZipFile.ExtractToDirectory("latest.zip", ".")
                            Catch ex As Exception
                                MessageBox.Show("Error extracting ZIP file: " & ex.Message, "Error")
                            End Try

                            System.IO.File.Delete("latest.zip")

                            ' Move the updated application from the unzipped folder to the directory where the program is running from
                            Dim appDir As String = Path.GetDirectoryName(Application.ExecutablePath)
                            Dim updateDir As String = Path.Combine(appDir, "PoSTPWG")
                            For Each updateFile As String In Directory.GetFiles(updateDir, "*", SearchOption.AllDirectories)
                                Dim destFile As String = Path.Combine(appDir, Path.GetFileName(updateFile))
                                File.Move(updateFile, destFile)
                            Next

                            Dim p As Process = Process.Start(Application.ExecutablePath)

                            If p Is Nothing Then
                                MessageBox.Show("Error starting updated program.", "Error")
                            Else
                                ' Display a message to the user
                                MessageBox.Show("The latest version has been downloaded and installed. The program will now restart.", "Update Complete")
                            End If

                            ' Display a message to the user
                            MessageBox.Show("The program has been reverted to the latest version. The program will now restart.", "Revert Complete")
                        End If
                    End If
                End If
            Else
                ' Prompt the user to download the latest release
                Dim result As DialogResult = MessageBox.Show("A new version of the program is available. Do you want to download it?", "Update Available", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    ' Close the program
                    Me.Close()
                    ' Download and unzip the latest release file
                    Dim downloadClient As New HttpClient()
                    Dim downloadResponse As HttpResponseMessage = downloadClient.GetAsync(latestUrl).Result
                    Dim bytes As Byte() = downloadResponse.Content.ReadAsByteArrayAsync().Result
                    System.IO.File.WriteAllBytes("latest.zip", bytes)

                    Try
                        ZipFile.ExtractToDirectory("latest.zip", ".")
                    Catch ex As Exception
                        MessageBox.Show("Error extracting ZIP file: " & ex.Message, "Error")
                    End Try

                    System.IO.File.Delete("latest.zip")

                    ' Move the updated application from the unzipped folder to the directory where the program is running from
                    Dim appDir As String = Path.GetDirectoryName(Application.ExecutablePath)
                    Dim updateDir As String = Path.Combine(appDir, "PoSTPWG")
                    For Each updateFile As String In Directory.GetFiles(updateDir, "*", SearchOption.AllDirectories)
                        Dim destFile As String = Path.Combine(appDir, Path.GetFileName(updateFile))
                        File.Move(updateFile, destFile)
                    Next

                    Dim p As Process = Process.Start(Application.ExecutablePath)

                    If p Is Nothing Then
                        MessageBox.Show("Error starting updated program.", "Error")
                    Else
                        ' Display a message to the user
                        MessageBox.Show("The latest version has been downloaded and installed. The program will now restart.", "Update Complete")
                    End If
                Else
                    ' Display a message to the user that the program is up to date
                    MessageBox.Show("The program is up to date.", "Up-to-Date")
                End If
            End If
        End If
    End Sub

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs)
        ' Check for updates
        UpdateCheckToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If CPortText.Focused Then
            CPortText.Cut()
        ElseIf NPlotsText.Focused Then
            NPlotsText.Cut()
        ElseIf TempDir1Text.Focused Then
            TempDir1Text.Cut()
        ElseIf TempDir2Text.Focused Then
            TempDir2Text.Cut()
        ElseIf TempDir3Text.Focused Then
            TempDir3Text.Cut()
        ElseIf FinalDirText.Focused Then
            FinalDirText.Cut()
        ElseIf PoolKeyText.Focused Then
            PoolKeyText.Cut()
        ElseIf ContractKeyText.Focused Then
            ContractKeyText.Cut()
        ElseIf FarmerKeyText.Focused Then
            FarmerKeyText.Cut()
        ElseIf BucketsText.Focused Then
            BucketsText.Cut()
        ElseIf BucketsP23Text.Focused Then
            BucketsP23Text.Cut()
        ElseIf CudaDeviceText.Focused Then
            CudaDeviceText.Cut()
        ElseIf NumCudaText.Focused Then
            NumCudaText.Cut()
        ElseIf StreamsText.Focused Then
            StreamsText.Cut()
        ElseIf MaxMemText.Focused Then
            MaxMemText.Cut()
        ElseIf RemoteCopyPortText.Focused Then
            RemoteCopyPortText.Cut()
        ElseIf ThreadMultiplierP2Text.Focused Then
            ThreadMultiplierP2Text.Cut()
        ElseIf StageDirectoryText.Focused Then
            StageDirectoryText.Cut()
        ElseIf MaxPlotsCacheTempDirText.Focused Then
            MaxPlotsCacheTempDirText.Cut()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If CPortText.Focused Then
            CPortText.Copy()
        ElseIf NPlotsText.Focused Then
            NPlotsText.Copy()
        ElseIf TempDir1Text.Focused Then
            TempDir1Text.Copy()
        ElseIf TempDir2Text.Focused Then
            TempDir2Text.Copy()
        ElseIf TempDir3Text.Focused Then
            TempDir3Text.Copy()
        ElseIf FinalDirText.Focused Then
            FinalDirText.Copy()
        ElseIf PoolKeyText.Focused Then
            PoolKeyText.Copy()
        ElseIf ContractKeyText.Focused Then
            ContractKeyText.Copy()
        ElseIf FarmerKeyText.Focused Then
            FarmerKeyText.Copy()
        ElseIf BucketsText.Focused Then
            BucketsText.Copy()
        ElseIf BucketsP23Text.Focused Then
            BucketsP23Text.Copy()
        ElseIf CudaDeviceText.Focused Then
            CudaDeviceText.Copy()
        ElseIf NumCudaText.Focused Then
            NumCudaText.Copy()
        ElseIf StreamsText.Focused Then
            StreamsText.Copy()
        ElseIf MaxMemText.Focused Then
            MaxMemText.Copy()
        ElseIf RemoteCopyPortText.Focused Then
            RemoteCopyPortText.Copy()
        ElseIf ThreadMultiplierP2Text.Focused Then
            ThreadMultiplierP2Text.Copy()
        ElseIf StageDirectoryText.Focused Then
            StageDirectoryText.Copy()
        ElseIf MaxPlotsCacheTempDirText.Focused Then
            MaxPlotsCacheTempDirText.Copy()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If CPortText.Focused Then
            CPortText.Paste()
        ElseIf NPlotsText.Focused Then
            NPlotsText.Paste()
        ElseIf TempDir1Text.Focused Then
            TempDir1Text.Paste()
        ElseIf TempDir2Text.Focused Then
            TempDir2Text.Paste()
        ElseIf TempDir3Text.Focused Then
            TempDir3Text.Paste()
        ElseIf FinalDirText.Focused Then
            FinalDirText.Paste()
        ElseIf PoolKeyText.Focused Then
            PoolKeyText.Paste()
        ElseIf ContractKeyText.Focused Then
            ContractKeyText.Paste()
        ElseIf FarmerKeyText.Focused Then
            FarmerKeyText.Paste()
        ElseIf BucketsText.Focused Then
            BucketsText.Paste()
        ElseIf BucketsP23Text.Focused Then
            BucketsP23Text.Paste()
        ElseIf CudaDeviceText.Focused Then
            CudaDeviceText.Paste()
        ElseIf NumCudaText.Focused Then
            NumCudaText.Paste()
        ElseIf StreamsText.Focused Then
            StreamsText.Paste()
        ElseIf MaxMemText.Focused Then
            MaxMemText.Paste()
        ElseIf RemoteCopyPortText.Focused Then
            RemoteCopyPortText.Paste()
        ElseIf ThreadMultiplierP2Text.Focused Then
            ThreadMultiplierP2Text.Paste()
        ElseIf StageDirectoryText.Focused Then
            StageDirectoryText.Paste()
        ElseIf MaxPlotsCacheTempDirText.Focused Then
            MaxPlotsCacheTempDirText.Paste()
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        If CPortText.Focused Then
            CPortText.SelectAll()
        ElseIf NPlotsText.Focused Then
            NPlotsText.SelectAll()
        ElseIf TempDir1Text.Focused Then
            TempDir1Text.SelectAll()
        ElseIf TempDir2Text.Focused Then
            TempDir2Text.SelectAll()
        ElseIf TempDir3Text.Focused Then
            TempDir3Text.SelectAll()
        ElseIf FinalDirText.Focused Then
            FinalDirText.SelectAll()
        ElseIf PoolKeyText.Focused Then
            PoolKeyText.SelectAll()
        ElseIf ContractKeyText.Focused Then
            ContractKeyText.SelectAll()
        ElseIf FarmerKeyText.Focused Then
            FarmerKeyText.SelectAll()
        ElseIf BucketsText.Focused Then
            BucketsText.SelectAll()
        ElseIf BucketsP23Text.Focused Then
            BucketsP23Text.SelectAll()
        ElseIf CudaDeviceText.Focused Then
            CudaDeviceText.SelectAll()
        ElseIf NumCudaText.Focused Then
            NumCudaText.SelectAll()
        ElseIf StreamsText.Focused Then
            StreamsText.SelectAll()
        ElseIf MaxMemText.Focused Then
            MaxMemText.SelectAll()
        ElseIf RemoteCopyPortText.Focused Then
            RemoteCopyPortText.SelectAll()
        ElseIf ThreadMultiplierP2Text.Focused Then
            ThreadMultiplierP2Text.SelectAll()
        ElseIf StageDirectoryText.Focused Then
            StageDirectoryText.SelectAll()
        ElseIf MaxPlotsCacheTempDirText.Focused Then
            MaxPlotsCacheTempDirText.SelectAll()
        End If
    End Sub

    Private Sub DebugNumPlotsCreated_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugLongestPlotTime_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugShortestPlotTime_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugAveragePlotTime_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugPlotterGUIUpdater_Click(sender As Object, e As EventArgs)
        UpdateCheckToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub VersioningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersioningToolStripMenuItem.Click

    End Sub

    Private Sub DebugEstPlotsPerHour_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DebugLastPlotTime_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SourcePlotText_TextChanged(sender As Object, e As EventArgs) Handles SourcePlotText.TextChanged
        If SourcePlotText.Text = "" Then
            AddSourceButton.Enabled = False
        Else
            AddSourceButton.Enabled = True
        End If
    End Sub

    Private Sub AddSourceButton_Click(sender As Object, e As EventArgs) Handles AddSourceButton.Click
        Dim sourceDirectory As String = SourcePlotText.Text
        Dim kValues() As String = {"K30", "K31", "K32", "K33", "K34"}
        Dim percentFreeSpace As Integer = GetPercentFreeSpace(sourceDirectory)
        Dim availableSpaceInGB As Double = GetAvailableSpaceInGB(sourceDirectory)

        Dim subDirectories() As String = Directory.GetDirectories(sourceDirectory)

        ' Set all K columns to be hidden by default
        For Each kValue As String In kValues
            SourcePlotDataGrid.Columns(kValue).Visible = False
        Next

        For Each subDirectory As String In subDirectories
            Dim kCounts(kValues.Length - 1) As Integer
            Dim totalPlots As Object = 0 ' Set the data type to Object to handle string values

            Try
                Dim directoryName As String = Path.GetFileName(subDirectory)
                Dim hasValidPlot As Boolean = False

                For Each kValue As String In kValues
                    Dim files() As String = Directory.GetFiles(subDirectory, "plot-" & kValue & "-*")
                    If files.Length > 0 Then
                        kCounts(Array.IndexOf(kValues, kValue)) += files.Length
                        hasValidPlot = True
                        totalPlots += files.Length

                        ' Show the K column if there are any plots for the given K value
                        SourcePlotDataGrid.Columns(kValue).Visible = True
                    End If
                Next

                If hasValidPlot Then
                    Dim rowIndex As Integer = SourcePlotDataGrid.Rows.Add()
                    Dim row As DataGridViewRow = SourcePlotDataGrid.Rows(rowIndex)
                    row.Cells("SourceDirectory").Value = subDirectory
                    row.Cells("PercentAvailableSpace").Value = percentFreeSpace
                    row.Cells("GBAvailableSpace").Value = availableSpaceInGB

                    For i As Integer = 0 To kValues.Length - 1
                        If kCounts(i) > 0 Then
                            row.Cells(kValues(i)).Value = kCounts(i)
                        End If
                    Next

                    ' Set the cell data type to DataGridViewTextBoxCell
                    Dim totalPlotsCell As New DataGridViewTextBoxCell()
                    totalPlotsCell.Value = totalPlots
                    row.Cells("TotalPlots") = totalPlotsCell
                End If
            Catch ex As UnauthorizedAccessException
                ' handle the access denied error here
                Debug.WriteLine("Access denied to directory: " & subDirectory)
            End Try
        Next
        AddSourceButton.Enabled = False
        SourcePlotText.Text = ""
    End Sub

    Private Function GetPercentFreeSpace(directory As String) As Integer
        Dim driveInfo As New System.IO.DriveInfo(directory)
        Dim percentFreeSpace As Integer = (driveInfo.AvailableFreeSpace / driveInfo.TotalSize) * 100
        Return percentFreeSpace
    End Function

    Private Function GetAvailableSpaceInGB(directory As String) As Double
        Dim driveInfo As New System.IO.DriveInfo(directory)
        Dim availableSpaceInGB As Double = driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)
        Return Math.Round(availableSpaceInGB, 2)
    End Function

    ' Event handler for when the Remove button is clicked
    Private Sub SourcePlotDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles SourcePlotDataGrid.CellContentClick
        If e.ColumnIndex = SourcePlotDataGrid.Columns.Count - 1 AndAlso e.RowIndex >= 0 Then
            ' Remove the row when the remove button is clicked
            SourcePlotDataGrid.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    ' Enable drag and drop on the DataGridView control
    Private Sub SourcePlotDataGrid_DragEnter(sender As Object, e As DragEventArgs) Handles SourcePlotDataGrid.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Handle the drop event
    Private Sub SourcePlotDataGrid_DragDrop(sender As Object, e As DragEventArgs) Handles SourcePlotDataGrid.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' Get the dropped files
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

            ' Add the files to the DataGridView control
            For Each file In files
                SourcePlotDataGrid.Rows.Add(file)
            Next
        ElseIf e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            ' Get the row being dragged
            Dim dragRow As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If dragRow IsNot Nothing Then
                ' Get the index of the row under the mouse cursor
                Dim cursorLocation As Point = SourcePlotDataGrid.PointToClient(New Point(e.X, e.Y))
                Dim targetIndex As Integer = SourcePlotDataGrid.HitTest(cursorLocation.X, cursorLocation.Y).RowIndex

                ' Remove the row being dragged from the DataGridView control
                SourcePlotDataGrid.Rows.Remove(dragRow)

                ' Move the row to the new location
                If targetIndex = -1 Then
                    SourcePlotDataGrid.Rows.Add(dragRow)
                Else
                    SourcePlotDataGrid.Rows.Insert(targetIndex, dragRow)
                End If
            End If
        End If
    End Sub

    ' Allow row selection during drag-and-drop operations
    Private Sub SourcePlotDataGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles SourcePlotDataGrid.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim hitTest As DataGridView.HitTestInfo = SourcePlotDataGrid.HitTest(e.X, e.Y)
            If hitTest.Type = DataGridViewHitTestType.Cell Then
                Dim dragRow As DataGridViewRow = SourcePlotDataGrid.Rows(hitTest.RowIndex)
                SourcePlotDataGrid.DoDragDrop(dragRow, DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub SourcePlotDataGrid_DragOver(sender As Object, e As DragEventArgs) Handles SourcePlotDataGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            ' Get the row being dragged
            Dim dragRow As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If dragRow IsNot Nothing Then
                ' Get the index of the row under the mouse cursor
                Dim cursorLocation As Point = SourcePlotDataGrid.PointToClient(New Point(e.X, e.Y))
                Dim targetIndex As Integer = SourcePlotDataGrid.HitTest(cursorLocation.X, cursorLocation.Y).RowIndex

                ' Determine if auto-scrolling is required
                Dim scrollMargin As Integer = 10
                Dim clientRect As Rectangle = SourcePlotDataGrid.ClientRectangle
                clientRect.Inflate(-scrollMargin, -scrollMargin)
                If Not clientRect.Contains(cursorLocation) Then
                    ' Determine the direction and speed of the auto-scroll
                    Dim scrollDelta As Integer = 0
                    If cursorLocation.Y < clientRect.Top Then
                        scrollDelta = -SystemInformation.MouseWheelScrollLines
                    ElseIf cursorLocation.Y > clientRect.Bottom Then
                        scrollDelta = SystemInformation.MouseWheelScrollLines
                    End If

                    ' Perform the auto-scroll
                    If scrollDelta <> 0 Then
                        Dim currentScroll As Integer = SourcePlotDataGrid.FirstDisplayedScrollingRowIndex
                        Dim newScroll As Integer = currentScroll + scrollDelta
                        If newScroll < 0 Then
                            newScroll = 0
                        ElseIf newScroll >= SourcePlotDataGrid.RowCount Then
                            newScroll = SourcePlotDataGrid.RowCount - 1
                        End If
                        SourcePlotDataGrid.FirstDisplayedScrollingRowIndex = newScroll
                    End If
                End If

                ' Draw the graphical indicator
                If targetIndex >= 0 AndAlso targetIndex < SourcePlotDataGrid.Rows.Count Then
                    Dim targetRect As Rectangle = SourcePlotDataGrid.GetRowDisplayRectangle(targetIndex, False)
                    If cursorLocation.Y < targetRect.Top + targetRect.Height / 2 Then
                        targetRect.Height = 2
                    Else
                        targetRect.Y += targetRect.Height - 2
                        targetRect.Height = 2
                    End If
                    SourcePlotDataGrid.Invalidate(targetRect)
                End If

                ' Set the drag effect
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    ' Handle the drag-leave event
    Private Sub SourcePlotDataGrid_DragLeave(sender As Object, e As EventArgs) Handles SourcePlotDataGrid.DragLeave
        ' Remove the graphical indicator
        SourcePlotDataGrid.Invalidate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Update the grid every 5 minutes

    End Sub

    Private Sub SourcePlotButton_Click(sender As Object, e As EventArgs) Handles SourcePlotButton.Click
        Using fbd As New FolderBrowserDialog()
            If fbd.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = fbd.SelectedPath
                SourcePlotText.Text = folderPath
            End If
        End Using
    End Sub
End Class