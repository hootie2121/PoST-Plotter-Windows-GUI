Imports System.IO

Public Class Form1
    Dim arguments As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DebugPM.Visible = False
        DebugKValue.Visible = False
        DebugCL.Visible = False
        DebugNPlots.Visible = False
        DebugTempDir1.Visible = False
        DebugTempDir2.Visible = False
        DebugFinalDir.Visible = False
        DebugPoolKey.Visible = False
        DebugContractKey.Visible = False
        DebugFarmerKey.Visible = False
        DebugNumThreads.Visible = False
        DebugBuckets.Visible = False
        DebugBucketsP23.Visible = False
        DebugCudaDevice.Visible = False
        DebugNumCuda.Visible = False
        DebugStreams.Visible = False
        DebugMaxMem.Visible = False
        For i As Integer = 1 To 9
            CLCombo.Items.Add(i.ToString())
        Next
        ContractKeyRadio.Checked = True
        Dim numThreads As Integer = System.Environment.ProcessorCount
        NumThreadsCombo.Items.Clear()
        For i As Integer = 1 To numThreads - 1
            NumThreadsCombo.Items.Add(i)
        Next
        KValueCombo.Text = "32"
        CLCombo.Text = "1"
        NPlotsText.Text = "1"
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
    End Sub

    Private Sub PMCPURadio_CheckedChanged(sender As Object, e As EventArgs) Handles PMCPURadio.CheckedChanged
        If PMCPURadio.Checked Then
            arguments("-PM") = "CPU"
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
        End If
        If arguments.ContainsKey("-PM") Then
            DebugPM.Text = "-PM " & arguments("-PM").ToString()
        Else
            DebugPM.Text = "No processing mode selected"
        End If
        Debug.WriteLine("-PM " & arguments("-PM"))
    End Sub

    Private Sub PMGPURadio_CheckedChanged(sender As Object, e As EventArgs) Handles PMGPURadio.CheckedChanged
        If PMGPURadio.Checked Then
            arguments("-PM") = "GPU"
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
        If Not Integer.TryParse(StreamsText.Text, Nothing) Then
            StreamsText.Text = 2
        Else
            If CInt(StreamsText.Text) < 2 Then
                StreamsText.Text = 2
            End If
        End If
        arguments("-S") = StreamsText.Text.ToString()
        If arguments.ContainsKey("-S") Then
            DebugStreams.Text = "-S " & arguments("-S").ToString()
        Else
            DebugStreams.Text = "Invalid Value"
        End If
        Debug.WriteLine("-S " & arguments("-S"))
    End Sub

    Private Sub DebugStreams_Click(sender As Object, e As EventArgs) Handles DebugStreams.Click

    End Sub

    Private Sub MaxMemText_TextChanged(sender As Object, e As EventArgs) Handles MaxMemText.TextChanged
        Dim selectedDevice As Integer = arguments("-g") ' change this to the desired CUDA device ID

        Dim dedicatedMemory As Integer = 0
        Dim sharedMemory As Integer = 0
        Dim maxValue As Integer = 0

        ' Run the nvidia-smi command and retrieve the output
        Dim process As New Process()
        process.StartInfo.FileName = "nvidia-smi.exe"
        process.StartInfo.Arguments = "--query-gpu=memory.dedicated.usage,memory.shared.usage --format=csv,noheader"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.CreateNoWindow = True
        process.Start()

        Dim output As String = process.StandardOutput.ReadToEnd()

        ' Parse the output to get the dedicated and shared GPU memory values for the selected GPU
        Dim lines As String() = output.Split(vbCrLf)
        Dim lineNumber As Integer = 0
        For Each line As String In lines
            If line.Trim() <> "" Then
                If lineNumber = selectedDevice Then
                    Dim parts As String() = line.Split(","c)
                    dedicatedMemory = Integer.Parse(parts(0))
                    sharedMemory = Integer.Parse(parts(1))
                    Exit For
                End If
                lineNumber += 1
            End If
        Next

        maxValue = dedicatedMemory + sharedMemory

        ' Validate the MaxMemText value
        Dim maxMem As Integer
        If Integer.TryParse(MaxMemText.Text, maxMem) Then
            If maxMem < 8 Then
                MaxMemText.Text = 8
            ElseIf maxMem > maxValue Then
                MaxMemText.Text = maxValue
            End If
        End If
    End Sub


    Private Sub DebugMaxMem_Click(sender As Object, e As EventArgs) Handles DebugMaxMem.Click

    End Sub

    Private Sub AvailMemValue_Click(sender As Object, e As EventArgs)

    End Sub
End Class
