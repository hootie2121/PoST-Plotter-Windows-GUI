<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenConfigLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitHubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.VersioningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PlotControls = New System.Windows.Forms.GroupBox()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.ResumeButton = New System.Windows.Forms.Button()
        Me.StopPlotButton = New System.Windows.Forms.Button()
        Me.DebugPlotterGUIUpdater = New System.Windows.Forms.Label()
        Me.SessionStats = New System.Windows.Forms.GroupBox()
        Me.DebugLastPlotTime = New System.Windows.Forms.Label()
        Me.LastPlotTimeLabel = New System.Windows.Forms.Label()
        Me.DebugEstPlotsPerDay = New System.Windows.Forms.Label()
        Me.EstPlotsPerDayLabel = New System.Windows.Forms.Label()
        Me.DebugEstPlotsPerHour = New System.Windows.Forms.Label()
        Me.EstPlotsPerHour = New System.Windows.Forms.Label()
        Me.DebugAveragePlotTime = New System.Windows.Forms.Label()
        Me.AveragePlotTimeLabel = New System.Windows.Forms.Label()
        Me.DebugShortestPlotTime = New System.Windows.Forms.Label()
        Me.ShortestPlotTimeLabel = New System.Windows.Forms.Label()
        Me.DebugLongestPlotTime = New System.Windows.Forms.Label()
        Me.LongestPlotTimeLabel = New System.Windows.Forms.Label()
        Me.DebugNumPlotsCreated = New System.Windows.Forms.Label()
        Me.NumPlotsCreatedLabel = New System.Windows.Forms.Label()
        Me.PlotProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Console = New System.Windows.Forms.GroupBox()
        Me.ConsolePrintOutTextBox = New System.Windows.Forms.RichTextBox()
        Me.DebugPlotter = New System.Windows.Forms.Label()
        Me.DebugPlotterPath = New System.Windows.Forms.Label()
        Me.PlotButton = New System.Windows.Forms.Button()
        Me.GPUOptions = New System.Windows.Forms.GroupBox()
        Me.DebugMaxPlotsCacheTempDir = New System.Windows.Forms.Label()
        Me.MaxPlotsCacheTempDirText = New System.Windows.Forms.TextBox()
        Me.MaxParallelCopiesCheck = New System.Windows.Forms.CheckBox()
        Me.DebugMaxParalleCopies = New System.Windows.Forms.Label()
        Me.MaxPlotstoCacheinTempDirLabel = New System.Windows.Forms.Label()
        Me.MaxMemText = New System.Windows.Forms.TextBox()
        Me.TempDir3Check = New System.Windows.Forms.CheckBox()
        Me.DebugMaxMem = New System.Windows.Forms.Label()
        Me.DebugTempDir3 = New System.Windows.Forms.Label()
        Me.MaxMemLabel = New System.Windows.Forms.Label()
        Me.TempDir3Button = New System.Windows.Forms.Button()
        Me.NumCudaText = New System.Windows.Forms.TextBox()
        Me.TempDir3Text = New System.Windows.Forms.TextBox()
        Me.StreamsText = New System.Windows.Forms.TextBox()
        Me.TempDir3Label = New System.Windows.Forms.Label()
        Me.DebugStreams = New System.Windows.Forms.Label()
        Me.NumStreamsLabel = New System.Windows.Forms.Label()
        Me.CudaDeviceText = New System.Windows.Forms.TextBox()
        Me.DebugNumCuda = New System.Windows.Forms.Label()
        Me.NumCudaLabel = New System.Windows.Forms.Label()
        Me.DebugCudaDevice = New System.Windows.Forms.Label()
        Me.CudaDeviceLabel = New System.Windows.Forms.Label()
        Me.CPUOptions = New System.Windows.Forms.GroupBox()
        Me.DebugAlternateTempDir = New System.Windows.Forms.Label()
        Me.AlternateTempDirCheck = New System.Windows.Forms.CheckBox()
        Me.DebugDirectInFinalDir = New System.Windows.Forms.Label()
        Me.DirectInFinalDirCheck = New System.Windows.Forms.CheckBox()
        Me.DebugStageDirectory = New System.Windows.Forms.Label()
        Me.StageDirectoryButton = New System.Windows.Forms.Button()
        Me.StageDirectoryText = New System.Windows.Forms.TextBox()
        Me.StageDirectoryLabel = New System.Windows.Forms.Label()
        Me.DebugThreadMultiplierP2 = New System.Windows.Forms.Label()
        Me.ThreadMultiplierP2Text = New System.Windows.Forms.TextBox()
        Me.ThreadMultiplierP2Label = New System.Windows.Forms.Label()
        Me.BucketsP23Text = New System.Windows.Forms.TextBox()
        Me.DebugBucketsP23 = New System.Windows.Forms.Label()
        Me.BucketsP23Label = New System.Windows.Forms.Label()
        Me.BucketsText = New System.Windows.Forms.TextBox()
        Me.DebugBuckets = New System.Windows.Forms.Label()
        Me.BucketsLabel = New System.Windows.Forms.Label()
        Me.DebugNumThreads = New System.Windows.Forms.Label()
        Me.NumThreadsCombo = New System.Windows.Forms.ComboBox()
        Me.NumThreadsLabel = New System.Windows.Forms.Label()
        Me.CommonOptions = New System.Windows.Forms.GroupBox()
        Me.AdvancedOptionsCheck = New System.Windows.Forms.CheckBox()
        Me.UniquePlotCheck = New System.Windows.Forms.CheckBox()
        Me.DebugUniquePlot = New System.Windows.Forms.Label()
        Me.AccountKeys = New System.Windows.Forms.GroupBox()
        Me.ContractKeyRadio = New System.Windows.Forms.RadioButton()
        Me.ContractKeyText = New System.Windows.Forms.TextBox()
        Me.PoolKeyRadio = New System.Windows.Forms.RadioButton()
        Me.PoolKeyLabel = New System.Windows.Forms.Label()
        Me.DebugFarmerKey = New System.Windows.Forms.Label()
        Me.PoolKeyText = New System.Windows.Forms.TextBox()
        Me.FarmerKeyText = New System.Windows.Forms.TextBox()
        Me.DebugPoolKey = New System.Windows.Forms.Label()
        Me.FarmerKeyLabel = New System.Windows.Forms.Label()
        Me.ContractKeyLabel = New System.Windows.Forms.Label()
        Me.DebugContractKey = New System.Windows.Forms.Label()
        Me.WaitforCopyCheck = New System.Windows.Forms.CheckBox()
        Me.CPortText = New System.Windows.Forms.TextBox()
        Me.DebugWaitforCopy = New System.Windows.Forms.Label()
        Me.RemoteCopyPortText = New System.Windows.Forms.TextBox()
        Me.DebugCPort = New System.Windows.Forms.Label()
        Me.CPortCombo = New System.Windows.Forms.ComboBox()
        Me.CPortLabel = New System.Windows.Forms.Label()
        Me.DebugRemoteCopyPort = New System.Windows.Forms.Label()
        Me.DebugFinalDir = New System.Windows.Forms.Label()
        Me.RemoteCopyPortLabel = New System.Windows.Forms.Label()
        Me.FinalDirButton = New System.Windows.Forms.Button()
        Me.FinalDirText = New System.Windows.Forms.TextBox()
        Me.FinalDirLabel = New System.Windows.Forms.Label()
        Me.TempDir2Check = New System.Windows.Forms.CheckBox()
        Me.DebugTempDir2 = New System.Windows.Forms.Label()
        Me.TempDir2Button = New System.Windows.Forms.Button()
        Me.TempDir2Text = New System.Windows.Forms.TextBox()
        Me.TempDir2Label = New System.Windows.Forms.Label()
        Me.DebugTempDir1 = New System.Windows.Forms.Label()
        Me.TempDir1Button = New System.Windows.Forms.Button()
        Me.TempDir1Text = New System.Windows.Forms.TextBox()
        Me.TempDir1 = New System.Windows.Forms.Label()
        Me.DebugNPlots = New System.Windows.Forms.Label()
        Me.NPlotsCheck = New System.Windows.Forms.CheckBox()
        Me.NPlotsText = New System.Windows.Forms.TextBox()
        Me.NPlots = New System.Windows.Forms.Label()
        Me.DebugCL = New System.Windows.Forms.Label()
        Me.CLCombo = New System.Windows.Forms.ComboBox()
        Me.CompressionLabel = New System.Windows.Forms.Label()
        Me.DebugKValue = New System.Windows.Forms.Label()
        Me.KValueCombo = New System.Windows.Forms.ComboBox()
        Me.KVLabel = New System.Windows.Forms.Label()
        Me.DebugPM = New System.Windows.Forms.Label()
        Me.PMGPURadio = New System.Windows.Forms.RadioButton()
        Me.PMCPURadio = New System.Windows.Forms.RadioButton()
        Me.PMLabel = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PlotDestination = New System.Windows.Forms.GroupBox()
        Me.MoveControls = New System.Windows.Forms.GroupBox()
        Me.StopMoveButton = New System.Windows.Forms.Button()
        Me.ResumeMoveButton = New System.Windows.Forms.Button()
        Me.PauseMoveButton = New System.Windows.Forms.Button()
        Me.StartMoveButton = New System.Windows.Forms.Button()
        Me.ParentK34Check = New System.Windows.Forms.CheckBox()
        Me.ParentK33Check = New System.Windows.Forms.CheckBox()
        Me.ParentK32Check = New System.Windows.Forms.CheckBox()
        Me.ParentK31Check = New System.Windows.Forms.CheckBox()
        Me.ParentK30Check = New System.Windows.Forms.CheckBox()
        Me.MaxParallelMovesText = New System.Windows.Forms.TextBox()
        Me.MaxParallelMovesLabel = New System.Windows.Forms.Label()
        Me.AddDestinationButton = New System.Windows.Forms.Button()
        Me.DestinationPlotDataGrid = New System.Windows.Forms.DataGridView()
        Me.DestinationPlotButton = New System.Windows.Forms.Button()
        Me.DestinationPlotText = New System.Windows.Forms.TextBox()
        Me.DestinationDirectoryLabel = New System.Windows.Forms.Label()
        Me.PlotSource = New System.Windows.Forms.GroupBox()
        Me.AddSourceButton = New System.Windows.Forms.Button()
        Me.SourcePlotDataGrid = New System.Windows.Forms.DataGridView()
        Me.SourcePlotButton = New System.Windows.Forms.Button()
        Me.SourcePlotText = New System.Windows.Forms.TextBox()
        Me.SourceDirectoryLabel = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PlotControls.SuspendLayout()
        Me.SessionStats.SuspendLayout()
        Me.Console.SuspendLayout()
        Me.GPUOptions.SuspendLayout()
        Me.CPUOptions.SuspendLayout()
        Me.CommonOptions.SuspendLayout()
        Me.AccountKeys.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PlotDestination.SuspendLayout()
        Me.MoveControls.SuspendLayout()
        CType(Me.DestinationPlotDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlotSource.SuspendLayout()
        CType(Me.SourcePlotDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1680, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(178, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.toolStripSeparator3, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.toolStripSeparator4, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(49, 24)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.RedoToolStripMenuItem.Text = "&Redo"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(203, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(203, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugModeToolStripMenuItem, Me.OpenConfigToolStripMenuItem, Me.OpenConfigLocationToolStripMenuItem, Me.ClearConfigToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'DebugModeToolStripMenuItem
        '
        Me.DebugModeToolStripMenuItem.Name = "DebugModeToolStripMenuItem"
        Me.DebugModeToolStripMenuItem.Size = New System.Drawing.Size(237, 26)
        Me.DebugModeToolStripMenuItem.Text = "Debug Mode"
        '
        'OpenConfigToolStripMenuItem
        '
        Me.OpenConfigToolStripMenuItem.Name = "OpenConfigToolStripMenuItem"
        Me.OpenConfigToolStripMenuItem.Size = New System.Drawing.Size(237, 26)
        Me.OpenConfigToolStripMenuItem.Text = "Open Config"
        '
        'OpenConfigLocationToolStripMenuItem
        '
        Me.OpenConfigLocationToolStripMenuItem.Name = "OpenConfigLocationToolStripMenuItem"
        Me.OpenConfigLocationToolStripMenuItem.Size = New System.Drawing.Size(237, 26)
        Me.OpenConfigLocationToolStripMenuItem.Text = "Open Config Location"
        '
        'ClearConfigToolStripMenuItem
        '
        Me.ClearConfigToolStripMenuItem.Name = "ClearConfigToolStripMenuItem"
        Me.ClearConfigToolStripMenuItem.Size = New System.Drawing.Size(237, 26)
        Me.ClearConfigToolStripMenuItem.Text = "Clear Config"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadMeToolStripMenuItem, Me.GitHubToolStripMenuItem, Me.UpdateCheckToolStripMenuItem, Me.toolStripSeparator5, Me.VersioningToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ReadMeToolStripMenuItem
        '
        Me.ReadMeToolStripMenuItem.Name = "ReadMeToolStripMenuItem"
        Me.ReadMeToolStripMenuItem.Size = New System.Drawing.Size(213, 26)
        Me.ReadMeToolStripMenuItem.Text = "README"
        '
        'GitHubToolStripMenuItem
        '
        Me.GitHubToolStripMenuItem.Name = "GitHubToolStripMenuItem"
        Me.GitHubToolStripMenuItem.Size = New System.Drawing.Size(213, 26)
        Me.GitHubToolStripMenuItem.Text = "GitHub"
        '
        'UpdateCheckToolStripMenuItem
        '
        Me.UpdateCheckToolStripMenuItem.Name = "UpdateCheckToolStripMenuItem"
        Me.UpdateCheckToolStripMenuItem.Size = New System.Drawing.Size(213, 26)
        Me.UpdateCheckToolStripMenuItem.Text = "Check for Updates"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(210, 6)
        '
        'VersioningToolStripMenuItem
        '
        Me.VersioningToolStripMenuItem.Name = "VersioningToolStripMenuItem"
        Me.VersioningToolStripMenuItem.Size = New System.Drawing.Size(213, 26)
        Me.VersioningToolStripMenuItem.Text = "Version 1.1.5"
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.TabPage1)
        Me.MainTabControl.Controls.Add(Me.TabPage2)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 28)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1680, 1052)
        Me.MainTabControl.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.PlotControls)
        Me.TabPage1.Controls.Add(Me.DebugPlotterGUIUpdater)
        Me.TabPage1.Controls.Add(Me.SessionStats)
        Me.TabPage1.Controls.Add(Me.PlotProgressBar)
        Me.TabPage1.Controls.Add(Me.Console)
        Me.TabPage1.Controls.Add(Me.DebugPlotter)
        Me.TabPage1.Controls.Add(Me.DebugPlotterPath)
        Me.TabPage1.Controls.Add(Me.PlotButton)
        Me.TabPage1.Controls.Add(Me.GPUOptions)
        Me.TabPage1.Controls.Add(Me.CPUOptions)
        Me.TabPage1.Controls.Add(Me.CommonOptions)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1672, 994)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'PlotControls
        '
        Me.PlotControls.Controls.Add(Me.PauseButton)
        Me.PlotControls.Controls.Add(Me.ResumeButton)
        Me.PlotControls.Controls.Add(Me.StopPlotButton)
        Me.PlotControls.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.PlotControls.Location = New System.Drawing.Point(3, 900)
        Me.PlotControls.Name = "PlotControls"
        Me.PlotControls.Size = New System.Drawing.Size(364, 73)
        Me.PlotControls.TabIndex = 27
        Me.PlotControls.TabStop = False
        Me.PlotControls.Text = "Plot Controls:"
        '
        'PauseButton
        '
        Me.PauseButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.PauseButton.Location = New System.Drawing.Point(6, 26)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(113, 29)
        Me.PauseButton.TabIndex = 11
        Me.PauseButton.Text = "Pause Plot"
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'ResumeButton
        '
        Me.ResumeButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ResumeButton.Location = New System.Drawing.Point(125, 26)
        Me.ResumeButton.Name = "ResumeButton"
        Me.ResumeButton.Size = New System.Drawing.Size(113, 29)
        Me.ResumeButton.TabIndex = 12
        Me.ResumeButton.Text = "Resume Plot"
        Me.ResumeButton.UseVisualStyleBackColor = True
        '
        'StopPlotButton
        '
        Me.StopPlotButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.StopPlotButton.Location = New System.Drawing.Point(244, 26)
        Me.StopPlotButton.Name = "StopPlotButton"
        Me.StopPlotButton.Size = New System.Drawing.Size(113, 29)
        Me.StopPlotButton.TabIndex = 10
        Me.StopPlotButton.Text = "Stop Plot"
        Me.StopPlotButton.UseVisualStyleBackColor = True
        '
        'DebugPlotterGUIUpdater
        '
        Me.DebugPlotterGUIUpdater.AutoSize = True
        Me.DebugPlotterGUIUpdater.Location = New System.Drawing.Point(1523, 988)
        Me.DebugPlotterGUIUpdater.Name = "DebugPlotterGUIUpdater"
        Me.DebugPlotterGUIUpdater.Size = New System.Drawing.Size(0, 20)
        Me.DebugPlotterGUIUpdater.TabIndex = 26
        '
        'SessionStats
        '
        Me.SessionStats.Controls.Add(Me.DebugLastPlotTime)
        Me.SessionStats.Controls.Add(Me.LastPlotTimeLabel)
        Me.SessionStats.Controls.Add(Me.DebugEstPlotsPerDay)
        Me.SessionStats.Controls.Add(Me.EstPlotsPerDayLabel)
        Me.SessionStats.Controls.Add(Me.DebugEstPlotsPerHour)
        Me.SessionStats.Controls.Add(Me.EstPlotsPerHour)
        Me.SessionStats.Controls.Add(Me.DebugAveragePlotTime)
        Me.SessionStats.Controls.Add(Me.AveragePlotTimeLabel)
        Me.SessionStats.Controls.Add(Me.DebugShortestPlotTime)
        Me.SessionStats.Controls.Add(Me.ShortestPlotTimeLabel)
        Me.SessionStats.Controls.Add(Me.DebugLongestPlotTime)
        Me.SessionStats.Controls.Add(Me.LongestPlotTimeLabel)
        Me.SessionStats.Controls.Add(Me.DebugNumPlotsCreated)
        Me.SessionStats.Controls.Add(Me.NumPlotsCreatedLabel)
        Me.SessionStats.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.SessionStats.Location = New System.Drawing.Point(1045, 434)
        Me.SessionStats.Name = "SessionStats"
        Me.SessionStats.Size = New System.Drawing.Size(620, 136)
        Me.SessionStats.TabIndex = 25
        Me.SessionStats.TabStop = False
        Me.SessionStats.Text = "Session Statistics:"
        '
        'DebugLastPlotTime
        '
        Me.DebugLastPlotTime.AutoSize = True
        Me.DebugLastPlotTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugLastPlotTime.Location = New System.Drawing.Point(117, 73)
        Me.DebugLastPlotTime.Name = "DebugLastPlotTime"
        Me.DebugLastPlotTime.Size = New System.Drawing.Size(0, 20)
        Me.DebugLastPlotTime.TabIndex = 21
        '
        'LastPlotTimeLabel
        '
        Me.LastPlotTimeLabel.AutoSize = True
        Me.LastPlotTimeLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LastPlotTimeLabel.Location = New System.Drawing.Point(6, 73)
        Me.LastPlotTimeLabel.Name = "LastPlotTimeLabel"
        Me.LastPlotTimeLabel.Size = New System.Drawing.Size(105, 20)
        Me.LastPlotTimeLabel.TabIndex = 20
        Me.LastPlotTimeLabel.Text = "Last Plot Time:"
        '
        'DebugEstPlotsPerDay
        '
        Me.DebugEstPlotsPerDay.AutoSize = True
        Me.DebugEstPlotsPerDay.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugEstPlotsPerDay.Location = New System.Drawing.Point(467, 98)
        Me.DebugEstPlotsPerDay.Name = "DebugEstPlotsPerDay"
        Me.DebugEstPlotsPerDay.Size = New System.Drawing.Size(0, 20)
        Me.DebugEstPlotsPerDay.TabIndex = 19
        '
        'EstPlotsPerDayLabel
        '
        Me.EstPlotsPerDayLabel.AutoSize = True
        Me.EstPlotsPerDayLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EstPlotsPerDayLabel.Location = New System.Drawing.Point(291, 98)
        Me.EstPlotsPerDayLabel.Name = "EstPlotsPerDayLabel"
        Me.EstPlotsPerDayLabel.Size = New System.Drawing.Size(170, 20)
        Me.EstPlotsPerDayLabel.TabIndex = 18
        Me.EstPlotsPerDayLabel.Text = "Estimated Plots per Day:"
        '
        'DebugEstPlotsPerHour
        '
        Me.DebugEstPlotsPerHour.AutoSize = True
        Me.DebugEstPlotsPerHour.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugEstPlotsPerHour.Location = New System.Drawing.Point(189, 98)
        Me.DebugEstPlotsPerHour.Name = "DebugEstPlotsPerHour"
        Me.DebugEstPlotsPerHour.Size = New System.Drawing.Size(0, 20)
        Me.DebugEstPlotsPerHour.TabIndex = 17
        '
        'EstPlotsPerHour
        '
        Me.EstPlotsPerHour.AutoSize = True
        Me.EstPlotsPerHour.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EstPlotsPerHour.Location = New System.Drawing.Point(6, 98)
        Me.EstPlotsPerHour.Name = "EstPlotsPerHour"
        Me.EstPlotsPerHour.Size = New System.Drawing.Size(177, 20)
        Me.EstPlotsPerHour.TabIndex = 16
        Me.EstPlotsPerHour.Text = "Estimated Plots per Hour:"
        '
        'DebugAveragePlotTime
        '
        Me.DebugAveragePlotTime.AutoSize = True
        Me.DebugAveragePlotTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugAveragePlotTime.Location = New System.Drawing.Point(143, 48)
        Me.DebugAveragePlotTime.Name = "DebugAveragePlotTime"
        Me.DebugAveragePlotTime.Size = New System.Drawing.Size(0, 20)
        Me.DebugAveragePlotTime.TabIndex = 15
        '
        'AveragePlotTimeLabel
        '
        Me.AveragePlotTimeLabel.AutoSize = True
        Me.AveragePlotTimeLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AveragePlotTimeLabel.Location = New System.Drawing.Point(6, 48)
        Me.AveragePlotTimeLabel.Name = "AveragePlotTimeLabel"
        Me.AveragePlotTimeLabel.Size = New System.Drawing.Size(134, 20)
        Me.AveragePlotTimeLabel.TabIndex = 14
        Me.AveragePlotTimeLabel.Text = "Average Plot Time:"
        '
        'DebugShortestPlotTime
        '
        Me.DebugShortestPlotTime.AutoSize = True
        Me.DebugShortestPlotTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugShortestPlotTime.Location = New System.Drawing.Point(430, 23)
        Me.DebugShortestPlotTime.Name = "DebugShortestPlotTime"
        Me.DebugShortestPlotTime.Size = New System.Drawing.Size(0, 20)
        Me.DebugShortestPlotTime.TabIndex = 13
        '
        'ShortestPlotTimeLabel
        '
        Me.ShortestPlotTimeLabel.AutoSize = True
        Me.ShortestPlotTimeLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ShortestPlotTimeLabel.Location = New System.Drawing.Point(291, 23)
        Me.ShortestPlotTimeLabel.Name = "ShortestPlotTimeLabel"
        Me.ShortestPlotTimeLabel.Size = New System.Drawing.Size(133, 20)
        Me.ShortestPlotTimeLabel.TabIndex = 12
        Me.ShortestPlotTimeLabel.Text = "Shortest Plot Time:"
        '
        'DebugLongestPlotTime
        '
        Me.DebugLongestPlotTime.AutoSize = True
        Me.DebugLongestPlotTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugLongestPlotTime.Location = New System.Drawing.Point(428, 48)
        Me.DebugLongestPlotTime.Name = "DebugLongestPlotTime"
        Me.DebugLongestPlotTime.Size = New System.Drawing.Size(0, 20)
        Me.DebugLongestPlotTime.TabIndex = 11
        '
        'LongestPlotTimeLabel
        '
        Me.LongestPlotTimeLabel.AutoSize = True
        Me.LongestPlotTimeLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LongestPlotTimeLabel.Location = New System.Drawing.Point(291, 48)
        Me.LongestPlotTimeLabel.Name = "LongestPlotTimeLabel"
        Me.LongestPlotTimeLabel.Size = New System.Drawing.Size(131, 20)
        Me.LongestPlotTimeLabel.TabIndex = 10
        Me.LongestPlotTimeLabel.Text = "Longest Plot Time:"
        '
        'DebugNumPlotsCreated
        '
        Me.DebugNumPlotsCreated.AutoSize = True
        Me.DebugNumPlotsCreated.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugNumPlotsCreated.Location = New System.Drawing.Point(188, 23)
        Me.DebugNumPlotsCreated.Name = "DebugNumPlotsCreated"
        Me.DebugNumPlotsCreated.Size = New System.Drawing.Size(0, 20)
        Me.DebugNumPlotsCreated.TabIndex = 9
        '
        'NumPlotsCreatedLabel
        '
        Me.NumPlotsCreatedLabel.AutoSize = True
        Me.NumPlotsCreatedLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumPlotsCreatedLabel.Location = New System.Drawing.Point(6, 23)
        Me.NumPlotsCreatedLabel.Name = "NumPlotsCreatedLabel"
        Me.NumPlotsCreatedLabel.Size = New System.Drawing.Size(176, 20)
        Me.NumPlotsCreatedLabel.TabIndex = 8
        Me.NumPlotsCreatedLabel.Text = "Number of Plots Created:"
        '
        'PlotProgressBar
        '
        Me.PlotProgressBar.Location = New System.Drawing.Point(3, 979)
        Me.PlotProgressBar.Name = "PlotProgressBar"
        Me.PlotProgressBar.Size = New System.Drawing.Size(1007, 29)
        Me.PlotProgressBar.TabIndex = 24
        '
        'Console
        '
        Me.Console.Controls.Add(Me.ConsolePrintOutTextBox)
        Me.Console.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.Console.Location = New System.Drawing.Point(3, 434)
        Me.Console.Name = "Console"
        Me.Console.Size = New System.Drawing.Size(1030, 440)
        Me.Console.TabIndex = 23
        Me.Console.TabStop = False
        Me.Console.Text = "Console:"
        '
        'ConsolePrintOutTextBox
        '
        Me.ConsolePrintOutTextBox.BackColor = System.Drawing.SystemColors.Desktop
        Me.ConsolePrintOutTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ConsolePrintOutTextBox.ForeColor = System.Drawing.SystemColors.Window
        Me.ConsolePrintOutTextBox.Location = New System.Drawing.Point(9, 26)
        Me.ConsolePrintOutTextBox.Name = "ConsolePrintOutTextBox"
        Me.ConsolePrintOutTextBox.Size = New System.Drawing.Size(1013, 395)
        Me.ConsolePrintOutTextBox.TabIndex = 0
        Me.ConsolePrintOutTextBox.Text = ""
        '
        'DebugPlotter
        '
        Me.DebugPlotter.AutoSize = True
        Me.DebugPlotter.Location = New System.Drawing.Point(699, 877)
        Me.DebugPlotter.Name = "DebugPlotter"
        Me.DebugPlotter.Size = New System.Drawing.Size(0, 20)
        Me.DebugPlotter.TabIndex = 22
        '
        'DebugPlotterPath
        '
        Me.DebugPlotterPath.AutoSize = True
        Me.DebugPlotterPath.Location = New System.Drawing.Point(3, 877)
        Me.DebugPlotterPath.Name = "DebugPlotterPath"
        Me.DebugPlotterPath.Size = New System.Drawing.Size(0, 20)
        Me.DebugPlotterPath.TabIndex = 21
        '
        'PlotButton
        '
        Me.PlotButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.PlotButton.Location = New System.Drawing.Point(883, 926)
        Me.PlotButton.Name = "PlotButton"
        Me.PlotButton.Size = New System.Drawing.Size(150, 29)
        Me.PlotButton.TabIndex = 20
        Me.PlotButton.Text = "Ready. Set. Plot!"
        Me.PlotButton.UseVisualStyleBackColor = True
        '
        'GPUOptions
        '
        Me.GPUOptions.Controls.Add(Me.DebugMaxPlotsCacheTempDir)
        Me.GPUOptions.Controls.Add(Me.MaxPlotsCacheTempDirText)
        Me.GPUOptions.Controls.Add(Me.MaxParallelCopiesCheck)
        Me.GPUOptions.Controls.Add(Me.DebugMaxParalleCopies)
        Me.GPUOptions.Controls.Add(Me.MaxPlotstoCacheinTempDirLabel)
        Me.GPUOptions.Controls.Add(Me.MaxMemText)
        Me.GPUOptions.Controls.Add(Me.TempDir3Check)
        Me.GPUOptions.Controls.Add(Me.DebugMaxMem)
        Me.GPUOptions.Controls.Add(Me.DebugTempDir3)
        Me.GPUOptions.Controls.Add(Me.MaxMemLabel)
        Me.GPUOptions.Controls.Add(Me.TempDir3Button)
        Me.GPUOptions.Controls.Add(Me.NumCudaText)
        Me.GPUOptions.Controls.Add(Me.TempDir3Text)
        Me.GPUOptions.Controls.Add(Me.StreamsText)
        Me.GPUOptions.Controls.Add(Me.TempDir3Label)
        Me.GPUOptions.Controls.Add(Me.DebugStreams)
        Me.GPUOptions.Controls.Add(Me.NumStreamsLabel)
        Me.GPUOptions.Controls.Add(Me.CudaDeviceText)
        Me.GPUOptions.Controls.Add(Me.DebugNumCuda)
        Me.GPUOptions.Controls.Add(Me.NumCudaLabel)
        Me.GPUOptions.Controls.Add(Me.DebugCudaDevice)
        Me.GPUOptions.Controls.Add(Me.CudaDeviceLabel)
        Me.GPUOptions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.GPUOptions.Location = New System.Drawing.Point(1045, 243)
        Me.GPUOptions.Name = "GPUOptions"
        Me.GPUOptions.Size = New System.Drawing.Size(620, 185)
        Me.GPUOptions.TabIndex = 19
        Me.GPUOptions.TabStop = False
        Me.GPUOptions.Text = "GPU Options:"
        '
        'DebugMaxPlotsCacheTempDir
        '
        Me.DebugMaxPlotsCacheTempDir.AutoSize = True
        Me.DebugMaxPlotsCacheTempDir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugMaxPlotsCacheTempDir.Location = New System.Drawing.Point(342, 94)
        Me.DebugMaxPlotsCacheTempDir.Name = "DebugMaxPlotsCacheTempDir"
        Me.DebugMaxPlotsCacheTempDir.Size = New System.Drawing.Size(0, 20)
        Me.DebugMaxPlotsCacheTempDir.TabIndex = 52
        '
        'MaxPlotsCacheTempDirText
        '
        Me.MaxPlotsCacheTempDirText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxPlotsCacheTempDirText.Location = New System.Drawing.Point(275, 91)
        Me.MaxPlotsCacheTempDirText.Name = "MaxPlotsCacheTempDirText"
        Me.MaxPlotsCacheTempDirText.Size = New System.Drawing.Size(61, 27)
        Me.MaxPlotsCacheTempDirText.TabIndex = 51
        '
        'MaxParallelCopiesCheck
        '
        Me.MaxParallelCopiesCheck.AutoSize = True
        Me.MaxParallelCopiesCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxParallelCopiesCheck.Location = New System.Drawing.Point(412, 93)
        Me.MaxParallelCopiesCheck.Name = "MaxParallelCopiesCheck"
        Me.MaxParallelCopiesCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MaxParallelCopiesCheck.Size = New System.Drawing.Size(163, 24)
        Me.MaxParallelCopiesCheck.TabIndex = 48
        Me.MaxParallelCopiesCheck.Text = ":Max Parallel Copies"
        Me.MaxParallelCopiesCheck.UseVisualStyleBackColor = True
        '
        'DebugMaxParalleCopies
        '
        Me.DebugMaxParalleCopies.AutoSize = True
        Me.DebugMaxParalleCopies.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugMaxParalleCopies.Location = New System.Drawing.Point(581, 94)
        Me.DebugMaxParalleCopies.Name = "DebugMaxParalleCopies"
        Me.DebugMaxParalleCopies.Size = New System.Drawing.Size(0, 20)
        Me.DebugMaxParalleCopies.TabIndex = 49
        '
        'MaxPlotstoCacheinTempDirLabel
        '
        Me.MaxPlotstoCacheinTempDirLabel.AutoSize = True
        Me.MaxPlotstoCacheinTempDirLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxPlotstoCacheinTempDirLabel.Location = New System.Drawing.Point(6, 95)
        Me.MaxPlotstoCacheinTempDirLabel.Name = "MaxPlotstoCacheinTempDirLabel"
        Me.MaxPlotstoCacheinTempDirLabel.Size = New System.Drawing.Size(263, 20)
        Me.MaxPlotstoCacheinTempDirLabel.TabIndex = 50
        Me.MaxPlotstoCacheinTempDirLabel.Text = "Max Plots to Cache in Temp. Directory:"
        '
        'MaxMemText
        '
        Me.MaxMemText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxMemText.Location = New System.Drawing.Point(469, 56)
        Me.MaxMemText.Name = "MaxMemText"
        Me.MaxMemText.Size = New System.Drawing.Size(47, 27)
        Me.MaxMemText.TabIndex = 20
        '
        'TempDir3Check
        '
        Me.TempDir3Check.AutoSize = True
        Me.TempDir3Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir3Check.Location = New System.Drawing.Point(526, 128)
        Me.TempDir3Check.Name = "TempDir3Check"
        Me.TempDir3Check.Size = New System.Drawing.Size(79, 24)
        Me.TempDir3Check.TabIndex = 37
        Me.TempDir3Check.Text = "In RAM"
        Me.TempDir3Check.UseVisualStyleBackColor = True
        '
        'DebugMaxMem
        '
        Me.DebugMaxMem.AutoSize = True
        Me.DebugMaxMem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugMaxMem.Location = New System.Drawing.Point(522, 59)
        Me.DebugMaxMem.Name = "DebugMaxMem"
        Me.DebugMaxMem.Size = New System.Drawing.Size(0, 20)
        Me.DebugMaxMem.TabIndex = 19
        '
        'DebugTempDir3
        '
        Me.DebugTempDir3.AutoSize = True
        Me.DebugTempDir3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugTempDir3.Location = New System.Drawing.Point(6, 155)
        Me.DebugTempDir3.Name = "DebugTempDir3"
        Me.DebugTempDir3.Size = New System.Drawing.Size(0, 20)
        Me.DebugTempDir3.TabIndex = 36
        '
        'MaxMemLabel
        '
        Me.MaxMemLabel.AutoSize = True
        Me.MaxMemLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxMemLabel.Location = New System.Drawing.Point(285, 59)
        Me.MaxMemLabel.Name = "MaxMemLabel"
        Me.MaxMemLabel.Size = New System.Drawing.Size(178, 20)
        Me.MaxMemLabel.TabIndex = 18
        Me.MaxMemLabel.Text = "Max Shared Memory(GB):"
        '
        'TempDir3Button
        '
        Me.TempDir3Button.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir3Button.Location = New System.Drawing.Point(457, 125)
        Me.TempDir3Button.Name = "TempDir3Button"
        Me.TempDir3Button.Size = New System.Drawing.Size(63, 29)
        Me.TempDir3Button.TabIndex = 35
        Me.TempDir3Button.Text = "Search"
        Me.TempDir3Button.UseVisualStyleBackColor = True
        '
        'NumCudaText
        '
        Me.NumCudaText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumCudaText.Location = New System.Drawing.Point(189, 57)
        Me.NumCudaText.Name = "NumCudaText"
        Me.NumCudaText.Size = New System.Drawing.Size(34, 27)
        Me.NumCudaText.TabIndex = 17
        '
        'TempDir3Text
        '
        Me.TempDir3Text.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir3Text.Location = New System.Drawing.Point(172, 127)
        Me.TempDir3Text.Name = "TempDir3Text"
        Me.TempDir3Text.Size = New System.Drawing.Size(279, 27)
        Me.TempDir3Text.TabIndex = 34
        '
        'StreamsText
        '
        Me.StreamsText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StreamsText.Location = New System.Drawing.Point(484, 20)
        Me.StreamsText.Name = "StreamsText"
        Me.StreamsText.Size = New System.Drawing.Size(34, 27)
        Me.StreamsText.TabIndex = 16
        '
        'TempDir3Label
        '
        Me.TempDir3Label.AutoSize = True
        Me.TempDir3Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir3Label.Location = New System.Drawing.Point(6, 130)
        Me.TempDir3Label.Name = "TempDir3Label"
        Me.TempDir3Label.Size = New System.Drawing.Size(160, 20)
        Me.TempDir3Label.TabIndex = 33
        Me.TempDir3Label.Text = "Temporary Directory 3:"
        '
        'DebugStreams
        '
        Me.DebugStreams.AutoSize = True
        Me.DebugStreams.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugStreams.Location = New System.Drawing.Point(526, 20)
        Me.DebugStreams.Name = "DebugStreams"
        Me.DebugStreams.Size = New System.Drawing.Size(0, 20)
        Me.DebugStreams.TabIndex = 15
        '
        'NumStreamsLabel
        '
        Me.NumStreamsLabel.AutoSize = True
        Me.NumStreamsLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumStreamsLabel.Location = New System.Drawing.Point(285, 24)
        Me.NumStreamsLabel.Name = "NumStreamsLabel"
        Me.NumStreamsLabel.Size = New System.Drawing.Size(193, 20)
        Me.NumStreamsLabel.TabIndex = 14
        Me.NumStreamsLabel.Text = "Number of Parallel Streams:"
        '
        'CudaDeviceText
        '
        Me.CudaDeviceText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CudaDeviceText.Location = New System.Drawing.Point(107, 22)
        Me.CudaDeviceText.Name = "CudaDeviceText"
        Me.CudaDeviceText.Size = New System.Drawing.Size(51, 27)
        Me.CudaDeviceText.TabIndex = 13
        '
        'DebugNumCuda
        '
        Me.DebugNumCuda.AutoSize = True
        Me.DebugNumCuda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugNumCuda.Location = New System.Drawing.Point(230, 60)
        Me.DebugNumCuda.Name = "DebugNumCuda"
        Me.DebugNumCuda.Size = New System.Drawing.Size(0, 20)
        Me.DebugNumCuda.TabIndex = 12
        '
        'NumCudaLabel
        '
        Me.NumCudaLabel.AutoSize = True
        Me.NumCudaLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumCudaLabel.Location = New System.Drawing.Point(6, 60)
        Me.NumCudaLabel.Name = "NumCudaLabel"
        Me.NumCudaLabel.Size = New System.Drawing.Size(177, 20)
        Me.NumCudaLabel.TabIndex = 10
        Me.NumCudaLabel.Text = "Number of Cuda Devices:"
        '
        'DebugCudaDevice
        '
        Me.DebugCudaDevice.AutoSize = True
        Me.DebugCudaDevice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugCudaDevice.Location = New System.Drawing.Point(164, 25)
        Me.DebugCudaDevice.Name = "DebugCudaDevice"
        Me.DebugCudaDevice.Size = New System.Drawing.Size(0, 20)
        Me.DebugCudaDevice.TabIndex = 9
        '
        'CudaDeviceLabel
        '
        Me.CudaDeviceLabel.AutoSize = True
        Me.CudaDeviceLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CudaDeviceLabel.Location = New System.Drawing.Point(6, 25)
        Me.CudaDeviceLabel.Name = "CudaDeviceLabel"
        Me.CudaDeviceLabel.Size = New System.Drawing.Size(95, 20)
        Me.CudaDeviceLabel.TabIndex = 7
        Me.CudaDeviceLabel.Text = "Cuda Device:"
        '
        'CPUOptions
        '
        Me.CPUOptions.Controls.Add(Me.DebugAlternateTempDir)
        Me.CPUOptions.Controls.Add(Me.AlternateTempDirCheck)
        Me.CPUOptions.Controls.Add(Me.DebugDirectInFinalDir)
        Me.CPUOptions.Controls.Add(Me.DirectInFinalDirCheck)
        Me.CPUOptions.Controls.Add(Me.DebugStageDirectory)
        Me.CPUOptions.Controls.Add(Me.StageDirectoryButton)
        Me.CPUOptions.Controls.Add(Me.StageDirectoryText)
        Me.CPUOptions.Controls.Add(Me.StageDirectoryLabel)
        Me.CPUOptions.Controls.Add(Me.DebugThreadMultiplierP2)
        Me.CPUOptions.Controls.Add(Me.ThreadMultiplierP2Text)
        Me.CPUOptions.Controls.Add(Me.ThreadMultiplierP2Label)
        Me.CPUOptions.Controls.Add(Me.BucketsP23Text)
        Me.CPUOptions.Controls.Add(Me.DebugBucketsP23)
        Me.CPUOptions.Controls.Add(Me.BucketsP23Label)
        Me.CPUOptions.Controls.Add(Me.BucketsText)
        Me.CPUOptions.Controls.Add(Me.DebugBuckets)
        Me.CPUOptions.Controls.Add(Me.BucketsLabel)
        Me.CPUOptions.Controls.Add(Me.DebugNumThreads)
        Me.CPUOptions.Controls.Add(Me.NumThreadsCombo)
        Me.CPUOptions.Controls.Add(Me.NumThreadsLabel)
        Me.CPUOptions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.CPUOptions.Location = New System.Drawing.Point(1045, 3)
        Me.CPUOptions.Name = "CPUOptions"
        Me.CPUOptions.Size = New System.Drawing.Size(620, 185)
        Me.CPUOptions.TabIndex = 18
        Me.CPUOptions.TabStop = False
        Me.CPUOptions.Text = "CPU Options:"
        '
        'DebugAlternateTempDir
        '
        Me.DebugAlternateTempDir.AutoSize = True
        Me.DebugAlternateTempDir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugAlternateTempDir.Location = New System.Drawing.Point(500, 96)
        Me.DebugAlternateTempDir.Name = "DebugAlternateTempDir"
        Me.DebugAlternateTempDir.Size = New System.Drawing.Size(0, 20)
        Me.DebugAlternateTempDir.TabIndex = 45
        '
        'AlternateTempDirCheck
        '
        Me.AlternateTempDirCheck.AutoSize = True
        Me.AlternateTempDirCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AlternateTempDirCheck.Location = New System.Drawing.Point(279, 95)
        Me.AlternateTempDirCheck.Name = "AlternateTempDirCheck"
        Me.AlternateTempDirCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AlternateTempDirCheck.Size = New System.Drawing.Size(215, 24)
        Me.AlternateTempDirCheck.TabIndex = 44
        Me.AlternateTempDirCheck.Text = ":Alternate Temp. Directories"
        Me.AlternateTempDirCheck.UseVisualStyleBackColor = True
        '
        'DebugDirectInFinalDir
        '
        Me.DebugDirectInFinalDir.AutoSize = True
        Me.DebugDirectInFinalDir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugDirectInFinalDir.Location = New System.Drawing.Point(234, 96)
        Me.DebugDirectInFinalDir.Name = "DebugDirectInFinalDir"
        Me.DebugDirectInFinalDir.Size = New System.Drawing.Size(0, 20)
        Me.DebugDirectInFinalDir.TabIndex = 43
        '
        'DirectInFinalDirCheck
        '
        Me.DirectInFinalDirCheck.AutoSize = True
        Me.DirectInFinalDirCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DirectInFinalDirCheck.Location = New System.Drawing.Point(6, 95)
        Me.DirectInFinalDirCheck.Name = "DirectInFinalDirCheck"
        Me.DirectInFinalDirCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DirectInFinalDirCheck.Size = New System.Drawing.Size(222, 24)
        Me.DirectInFinalDirCheck.TabIndex = 42
        Me.DirectInFinalDirCheck.Text = ":Plot Direct to Final Directory"
        Me.DirectInFinalDirCheck.UseVisualStyleBackColor = True
        '
        'DebugStageDirectory
        '
        Me.DebugStageDirectory.AutoSize = True
        Me.DebugStageDirectory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugStageDirectory.Location = New System.Drawing.Point(6, 155)
        Me.DebugStageDirectory.Name = "DebugStageDirectory"
        Me.DebugStageDirectory.Size = New System.Drawing.Size(0, 20)
        Me.DebugStageDirectory.TabIndex = 41
        '
        'StageDirectoryButton
        '
        Me.StageDirectoryButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StageDirectoryButton.Location = New System.Drawing.Point(412, 125)
        Me.StageDirectoryButton.Name = "StageDirectoryButton"
        Me.StageDirectoryButton.Size = New System.Drawing.Size(63, 29)
        Me.StageDirectoryButton.TabIndex = 40
        Me.StageDirectoryButton.Text = "Search"
        Me.StageDirectoryButton.UseVisualStyleBackColor = True
        '
        'StageDirectoryText
        '
        Me.StageDirectoryText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StageDirectoryText.Location = New System.Drawing.Point(127, 127)
        Me.StageDirectoryText.Name = "StageDirectoryText"
        Me.StageDirectoryText.Size = New System.Drawing.Size(279, 27)
        Me.StageDirectoryText.TabIndex = 39
        '
        'StageDirectoryLabel
        '
        Me.StageDirectoryLabel.AutoSize = True
        Me.StageDirectoryLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StageDirectoryLabel.Location = New System.Drawing.Point(6, 130)
        Me.StageDirectoryLabel.Name = "StageDirectoryLabel"
        Me.StageDirectoryLabel.Size = New System.Drawing.Size(115, 20)
        Me.StageDirectoryLabel.TabIndex = 38
        Me.StageDirectoryLabel.Text = "Stage Directory:"
        '
        'DebugThreadMultiplierP2
        '
        Me.DebugThreadMultiplierP2.AutoSize = True
        Me.DebugThreadMultiplierP2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugThreadMultiplierP2.Location = New System.Drawing.Point(511, 25)
        Me.DebugThreadMultiplierP2.Name = "DebugThreadMultiplierP2"
        Me.DebugThreadMultiplierP2.Size = New System.Drawing.Size(0, 20)
        Me.DebugThreadMultiplierP2.TabIndex = 19
        '
        'ThreadMultiplierP2Text
        '
        Me.ThreadMultiplierP2Text.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ThreadMultiplierP2Text.Location = New System.Drawing.Point(454, 22)
        Me.ThreadMultiplierP2Text.Name = "ThreadMultiplierP2Text"
        Me.ThreadMultiplierP2Text.Size = New System.Drawing.Size(51, 27)
        Me.ThreadMultiplierP2Text.TabIndex = 18
        '
        'ThreadMultiplierP2Label
        '
        Me.ThreadMultiplierP2Label.AutoSize = True
        Me.ThreadMultiplierP2Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ThreadMultiplierP2Label.Location = New System.Drawing.Point(279, 25)
        Me.ThreadMultiplierP2Label.Name = "ThreadMultiplierP2Label"
        Me.ThreadMultiplierP2Label.Size = New System.Drawing.Size(169, 20)
        Me.ThreadMultiplierP2Label.TabIndex = 17
        Me.ThreadMultiplierP2Label.Text = "Thread Multiplier for P2:"
        '
        'BucketsP23Text
        '
        Me.BucketsP23Text.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BucketsP23Text.Location = New System.Drawing.Point(471, 61)
        Me.BucketsP23Text.Name = "BucketsP23Text"
        Me.BucketsP23Text.Size = New System.Drawing.Size(78, 27)
        Me.BucketsP23Text.TabIndex = 16
        '
        'DebugBucketsP23
        '
        Me.DebugBucketsP23.AutoSize = True
        Me.DebugBucketsP23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugBucketsP23.Location = New System.Drawing.Point(555, 64)
        Me.DebugBucketsP23.Name = "DebugBucketsP23"
        Me.DebugBucketsP23.Size = New System.Drawing.Size(0, 20)
        Me.DebugBucketsP23.TabIndex = 15
        '
        'BucketsP23Label
        '
        Me.BucketsP23Label.AutoSize = True
        Me.BucketsP23Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BucketsP23Label.Location = New System.Drawing.Point(279, 64)
        Me.BucketsP23Label.Name = "BucketsP23Label"
        Me.BucketsP23Label.Size = New System.Drawing.Size(186, 20)
        Me.BucketsP23Label.TabIndex = 14
        Me.BucketsP23Label.Text = "Buckets for Phases 2 and 3:"
        '
        'BucketsText
        '
        Me.BucketsText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BucketsText.Location = New System.Drawing.Point(74, 57)
        Me.BucketsText.Name = "BucketsText"
        Me.BucketsText.Size = New System.Drawing.Size(78, 27)
        Me.BucketsText.TabIndex = 13
        '
        'DebugBuckets
        '
        Me.DebugBuckets.AutoSize = True
        Me.DebugBuckets.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugBuckets.Location = New System.Drawing.Point(158, 60)
        Me.DebugBuckets.Name = "DebugBuckets"
        Me.DebugBuckets.Size = New System.Drawing.Size(0, 20)
        Me.DebugBuckets.TabIndex = 12
        '
        'BucketsLabel
        '
        Me.BucketsLabel.AutoSize = True
        Me.BucketsLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BucketsLabel.Location = New System.Drawing.Point(6, 60)
        Me.BucketsLabel.Name = "BucketsLabel"
        Me.BucketsLabel.Size = New System.Drawing.Size(62, 20)
        Me.BucketsLabel.TabIndex = 10
        Me.BucketsLabel.Text = "Buckets:"
        '
        'DebugNumThreads
        '
        Me.DebugNumThreads.AutoSize = True
        Me.DebugNumThreads.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugNumThreads.Location = New System.Drawing.Point(209, 25)
        Me.DebugNumThreads.Name = "DebugNumThreads"
        Me.DebugNumThreads.Size = New System.Drawing.Size(0, 20)
        Me.DebugNumThreads.TabIndex = 9
        '
        'NumThreadsCombo
        '
        Me.NumThreadsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NumThreadsCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumThreadsCombo.FormattingEnabled = True
        Me.NumThreadsCombo.Location = New System.Drawing.Point(152, 22)
        Me.NumThreadsCombo.Name = "NumThreadsCombo"
        Me.NumThreadsCombo.Size = New System.Drawing.Size(51, 28)
        Me.NumThreadsCombo.TabIndex = 8
        '
        'NumThreadsLabel
        '
        Me.NumThreadsLabel.AutoSize = True
        Me.NumThreadsLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NumThreadsLabel.Location = New System.Drawing.Point(6, 25)
        Me.NumThreadsLabel.Name = "NumThreadsLabel"
        Me.NumThreadsLabel.Size = New System.Drawing.Size(140, 20)
        Me.NumThreadsLabel.TabIndex = 7
        Me.NumThreadsLabel.Text = "Number of Threads:"
        '
        'CommonOptions
        '
        Me.CommonOptions.Controls.Add(Me.AdvancedOptionsCheck)
        Me.CommonOptions.Controls.Add(Me.UniquePlotCheck)
        Me.CommonOptions.Controls.Add(Me.DebugUniquePlot)
        Me.CommonOptions.Controls.Add(Me.AccountKeys)
        Me.CommonOptions.Controls.Add(Me.WaitforCopyCheck)
        Me.CommonOptions.Controls.Add(Me.CPortText)
        Me.CommonOptions.Controls.Add(Me.DebugWaitforCopy)
        Me.CommonOptions.Controls.Add(Me.RemoteCopyPortText)
        Me.CommonOptions.Controls.Add(Me.DebugCPort)
        Me.CommonOptions.Controls.Add(Me.CPortCombo)
        Me.CommonOptions.Controls.Add(Me.CPortLabel)
        Me.CommonOptions.Controls.Add(Me.DebugRemoteCopyPort)
        Me.CommonOptions.Controls.Add(Me.DebugFinalDir)
        Me.CommonOptions.Controls.Add(Me.RemoteCopyPortLabel)
        Me.CommonOptions.Controls.Add(Me.FinalDirButton)
        Me.CommonOptions.Controls.Add(Me.FinalDirText)
        Me.CommonOptions.Controls.Add(Me.FinalDirLabel)
        Me.CommonOptions.Controls.Add(Me.TempDir2Check)
        Me.CommonOptions.Controls.Add(Me.DebugTempDir2)
        Me.CommonOptions.Controls.Add(Me.TempDir2Button)
        Me.CommonOptions.Controls.Add(Me.TempDir2Text)
        Me.CommonOptions.Controls.Add(Me.TempDir2Label)
        Me.CommonOptions.Controls.Add(Me.DebugTempDir1)
        Me.CommonOptions.Controls.Add(Me.TempDir1Button)
        Me.CommonOptions.Controls.Add(Me.TempDir1Text)
        Me.CommonOptions.Controls.Add(Me.TempDir1)
        Me.CommonOptions.Controls.Add(Me.DebugNPlots)
        Me.CommonOptions.Controls.Add(Me.NPlotsCheck)
        Me.CommonOptions.Controls.Add(Me.NPlotsText)
        Me.CommonOptions.Controls.Add(Me.NPlots)
        Me.CommonOptions.Controls.Add(Me.DebugCL)
        Me.CommonOptions.Controls.Add(Me.CLCombo)
        Me.CommonOptions.Controls.Add(Me.CompressionLabel)
        Me.CommonOptions.Controls.Add(Me.DebugKValue)
        Me.CommonOptions.Controls.Add(Me.KValueCombo)
        Me.CommonOptions.Controls.Add(Me.KVLabel)
        Me.CommonOptions.Controls.Add(Me.DebugPM)
        Me.CommonOptions.Controls.Add(Me.PMGPURadio)
        Me.CommonOptions.Controls.Add(Me.PMCPURadio)
        Me.CommonOptions.Controls.Add(Me.PMLabel)
        Me.CommonOptions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.CommonOptions.Location = New System.Drawing.Point(3, 3)
        Me.CommonOptions.Name = "CommonOptions"
        Me.CommonOptions.Size = New System.Drawing.Size(1030, 425)
        Me.CommonOptions.TabIndex = 17
        Me.CommonOptions.TabStop = False
        Me.CommonOptions.Text = "Common Options:"
        '
        'AdvancedOptionsCheck
        '
        Me.AdvancedOptionsCheck.AutoSize = True
        Me.AdvancedOptionsCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AdvancedOptionsCheck.Location = New System.Drawing.Point(6, 200)
        Me.AdvancedOptionsCheck.Name = "AdvancedOptionsCheck"
        Me.AdvancedOptionsCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AdvancedOptionsCheck.Size = New System.Drawing.Size(205, 24)
        Me.AdvancedOptionsCheck.TabIndex = 39
        Me.AdvancedOptionsCheck.Text = ":Enable Advanced Options"
        Me.AdvancedOptionsCheck.UseVisualStyleBackColor = True
        '
        'UniquePlotCheck
        '
        Me.UniquePlotCheck.AutoSize = True
        Me.UniquePlotCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.UniquePlotCheck.Location = New System.Drawing.Point(837, 174)
        Me.UniquePlotCheck.Name = "UniquePlotCheck"
        Me.UniquePlotCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UniquePlotCheck.Size = New System.Drawing.Size(111, 24)
        Me.UniquePlotCheck.TabIndex = 41
        Me.UniquePlotCheck.Text = ":Unique Plot"
        Me.UniquePlotCheck.UseVisualStyleBackColor = True
        '
        'DebugUniquePlot
        '
        Me.DebugUniquePlot.AutoSize = True
        Me.DebugUniquePlot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugUniquePlot.Location = New System.Drawing.Point(954, 173)
        Me.DebugUniquePlot.Name = "DebugUniquePlot"
        Me.DebugUniquePlot.Size = New System.Drawing.Size(0, 20)
        Me.DebugUniquePlot.TabIndex = 15
        '
        'AccountKeys
        '
        Me.AccountKeys.Controls.Add(Me.ContractKeyRadio)
        Me.AccountKeys.Controls.Add(Me.ContractKeyText)
        Me.AccountKeys.Controls.Add(Me.PoolKeyRadio)
        Me.AccountKeys.Controls.Add(Me.PoolKeyLabel)
        Me.AccountKeys.Controls.Add(Me.DebugFarmerKey)
        Me.AccountKeys.Controls.Add(Me.PoolKeyText)
        Me.AccountKeys.Controls.Add(Me.FarmerKeyText)
        Me.AccountKeys.Controls.Add(Me.DebugPoolKey)
        Me.AccountKeys.Controls.Add(Me.FarmerKeyLabel)
        Me.AccountKeys.Controls.Add(Me.ContractKeyLabel)
        Me.AccountKeys.Controls.Add(Me.DebugContractKey)
        Me.AccountKeys.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.AccountKeys.Location = New System.Drawing.Point(6, 230)
        Me.AccountKeys.Name = "AccountKeys"
        Me.AccountKeys.Size = New System.Drawing.Size(1016, 195)
        Me.AccountKeys.TabIndex = 2
        Me.AccountKeys.TabStop = False
        Me.AccountKeys.Text = "Account Keys:"
        '
        'ContractKeyRadio
        '
        Me.ContractKeyRadio.AutoSize = True
        Me.ContractKeyRadio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContractKeyRadio.Location = New System.Drawing.Point(938, 78)
        Me.ContractKeyRadio.Name = "ContractKeyRadio"
        Me.ContractKeyRadio.Size = New System.Drawing.Size(75, 24)
        Me.ContractKeyRadio.TabIndex = 41
        Me.ContractKeyRadio.TabStop = True
        Me.ContractKeyRadio.Text = "Enable"
        Me.ContractKeyRadio.UseVisualStyleBackColor = True
        '
        'ContractKeyText
        '
        Me.ContractKeyText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContractKeyText.Location = New System.Drawing.Point(141, 77)
        Me.ContractKeyText.Name = "ContractKeyText"
        Me.ContractKeyText.Size = New System.Drawing.Size(791, 27)
        Me.ContractKeyText.TabIndex = 34
        '
        'PoolKeyRadio
        '
        Me.PoolKeyRadio.AutoSize = True
        Me.PoolKeyRadio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PoolKeyRadio.Location = New System.Drawing.Point(938, 23)
        Me.PoolKeyRadio.Name = "PoolKeyRadio"
        Me.PoolKeyRadio.Size = New System.Drawing.Size(75, 24)
        Me.PoolKeyRadio.TabIndex = 40
        Me.PoolKeyRadio.TabStop = True
        Me.PoolKeyRadio.Text = "Enable"
        Me.PoolKeyRadio.UseVisualStyleBackColor = True
        '
        'PoolKeyLabel
        '
        Me.PoolKeyLabel.AutoSize = True
        Me.PoolKeyLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PoolKeyLabel.Location = New System.Drawing.Point(6, 25)
        Me.PoolKeyLabel.Name = "PoolKeyLabel"
        Me.PoolKeyLabel.Size = New System.Drawing.Size(113, 20)
        Me.PoolKeyLabel.TabIndex = 29
        Me.PoolKeyLabel.Text = "Pool Public Key:"
        '
        'DebugFarmerKey
        '
        Me.DebugFarmerKey.AutoSize = True
        Me.DebugFarmerKey.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugFarmerKey.Location = New System.Drawing.Point(6, 165)
        Me.DebugFarmerKey.Name = "DebugFarmerKey"
        Me.DebugFarmerKey.Size = New System.Drawing.Size(0, 20)
        Me.DebugFarmerKey.TabIndex = 39
        '
        'PoolKeyText
        '
        Me.PoolKeyText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PoolKeyText.Location = New System.Drawing.Point(125, 22)
        Me.PoolKeyText.Name = "PoolKeyText"
        Me.PoolKeyText.Size = New System.Drawing.Size(807, 27)
        Me.PoolKeyText.TabIndex = 30
        '
        'FarmerKeyText
        '
        Me.FarmerKeyText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FarmerKeyText.Location = New System.Drawing.Point(141, 132)
        Me.FarmerKeyText.Name = "FarmerKeyText"
        Me.FarmerKeyText.Size = New System.Drawing.Size(791, 27)
        Me.FarmerKeyText.TabIndex = 38
        '
        'DebugPoolKey
        '
        Me.DebugPoolKey.AutoSize = True
        Me.DebugPoolKey.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugPoolKey.Location = New System.Drawing.Point(6, 55)
        Me.DebugPoolKey.Name = "DebugPoolKey"
        Me.DebugPoolKey.Size = New System.Drawing.Size(0, 20)
        Me.DebugPoolKey.TabIndex = 31
        '
        'FarmerKeyLabel
        '
        Me.FarmerKeyLabel.AutoSize = True
        Me.FarmerKeyLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FarmerKeyLabel.Location = New System.Drawing.Point(6, 135)
        Me.FarmerKeyLabel.Name = "FarmerKeyLabel"
        Me.FarmerKeyLabel.Size = New System.Drawing.Size(129, 20)
        Me.FarmerKeyLabel.TabIndex = 37
        Me.FarmerKeyLabel.Text = "Farmer Public Key:"
        '
        'ContractKeyLabel
        '
        Me.ContractKeyLabel.AutoSize = True
        Me.ContractKeyLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContractKeyLabel.Location = New System.Drawing.Point(6, 80)
        Me.ContractKeyLabel.Name = "ContractKeyLabel"
        Me.ContractKeyLabel.Size = New System.Drawing.Size(129, 20)
        Me.ContractKeyLabel.TabIndex = 33
        Me.ContractKeyLabel.Text = "Pool Contract Key:"
        '
        'DebugContractKey
        '
        Me.DebugContractKey.AutoSize = True
        Me.DebugContractKey.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugContractKey.Location = New System.Drawing.Point(6, 110)
        Me.DebugContractKey.Name = "DebugContractKey"
        Me.DebugContractKey.Size = New System.Drawing.Size(0, 20)
        Me.DebugContractKey.TabIndex = 35
        '
        'WaitforCopyCheck
        '
        Me.WaitforCopyCheck.AutoSize = True
        Me.WaitforCopyCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.WaitforCopyCheck.Location = New System.Drawing.Point(657, 174)
        Me.WaitforCopyCheck.Name = "WaitforCopyCheck"
        Me.WaitforCopyCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.WaitforCopyCheck.Size = New System.Drawing.Size(127, 24)
        Me.WaitforCopyCheck.TabIndex = 40
        Me.WaitforCopyCheck.Text = ":Wait For Copy"
        Me.WaitforCopyCheck.UseVisualStyleBackColor = True
        '
        'CPortText
        '
        Me.CPortText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CPortText.Location = New System.Drawing.Point(172, 127)
        Me.CPortText.Name = "CPortText"
        Me.CPortText.Size = New System.Drawing.Size(81, 27)
        Me.CPortText.TabIndex = 32
        '
        'DebugWaitforCopy
        '
        Me.DebugWaitforCopy.AutoSize = True
        Me.DebugWaitforCopy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugWaitforCopy.Location = New System.Drawing.Point(790, 175)
        Me.DebugWaitforCopy.Name = "DebugWaitforCopy"
        Me.DebugWaitforCopy.Size = New System.Drawing.Size(0, 20)
        Me.DebugWaitforCopy.TabIndex = 12
        '
        'RemoteCopyPortText
        '
        Me.RemoteCopyPortText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RemoteCopyPortText.Location = New System.Drawing.Point(477, 172)
        Me.RemoteCopyPortText.Name = "RemoteCopyPortText"
        Me.RemoteCopyPortText.Size = New System.Drawing.Size(78, 27)
        Me.RemoteCopyPortText.TabIndex = 17
        '
        'DebugCPort
        '
        Me.DebugCPort.AutoSize = True
        Me.DebugCPort.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugCPort.Location = New System.Drawing.Point(259, 130)
        Me.DebugCPort.Name = "DebugCPort"
        Me.DebugCPort.Size = New System.Drawing.Size(0, 20)
        Me.DebugCPort.TabIndex = 31
        '
        'CPortCombo
        '
        Me.CPortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CPortCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CPortCombo.FormattingEnabled = True
        Me.CPortCombo.Location = New System.Drawing.Point(84, 127)
        Me.CPortCombo.Name = "CPortCombo"
        Me.CPortCombo.Size = New System.Drawing.Size(81, 28)
        Me.CPortCombo.TabIndex = 30
        '
        'CPortLabel
        '
        Me.CPortLabel.AutoSize = True
        Me.CPortLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CPortLabel.Location = New System.Drawing.Point(6, 130)
        Me.CPortLabel.Name = "CPortLabel"
        Me.CPortLabel.Size = New System.Drawing.Size(72, 20)
        Me.CPortLabel.TabIndex = 29
        Me.CPortLabel.Text = "Coin Port:"
        '
        'DebugRemoteCopyPort
        '
        Me.DebugRemoteCopyPort.AutoSize = True
        Me.DebugRemoteCopyPort.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugRemoteCopyPort.Location = New System.Drawing.Point(561, 175)
        Me.DebugRemoteCopyPort.Name = "DebugRemoteCopyPort"
        Me.DebugRemoteCopyPort.Size = New System.Drawing.Size(0, 20)
        Me.DebugRemoteCopyPort.TabIndex = 9
        '
        'DebugFinalDir
        '
        Me.DebugFinalDir.AutoSize = True
        Me.DebugFinalDir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugFinalDir.Location = New System.Drawing.Point(339, 150)
        Me.DebugFinalDir.Name = "DebugFinalDir"
        Me.DebugFinalDir.Size = New System.Drawing.Size(0, 20)
        Me.DebugFinalDir.TabIndex = 27
        '
        'RemoteCopyPortLabel
        '
        Me.RemoteCopyPortLabel.AutoSize = True
        Me.RemoteCopyPortLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RemoteCopyPortLabel.Location = New System.Drawing.Point(339, 175)
        Me.RemoteCopyPortLabel.Name = "RemoteCopyPortLabel"
        Me.RemoteCopyPortLabel.Size = New System.Drawing.Size(132, 20)
        Me.RemoteCopyPortLabel.TabIndex = 7
        Me.RemoteCopyPortLabel.Text = "Remote Copy Port:"
        '
        'FinalDirButton
        '
        Me.FinalDirButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FinalDirButton.Location = New System.Drawing.Point(790, 120)
        Me.FinalDirButton.Name = "FinalDirButton"
        Me.FinalDirButton.Size = New System.Drawing.Size(63, 29)
        Me.FinalDirButton.TabIndex = 26
        Me.FinalDirButton.Text = "Search"
        Me.FinalDirButton.UseVisualStyleBackColor = True
        '
        'FinalDirText
        '
        Me.FinalDirText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FinalDirText.Location = New System.Drawing.Point(453, 122)
        Me.FinalDirText.Name = "FinalDirText"
        Me.FinalDirText.Size = New System.Drawing.Size(331, 27)
        Me.FinalDirText.TabIndex = 25
        '
        'FinalDirLabel
        '
        Me.FinalDirLabel.AutoSize = True
        Me.FinalDirLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FinalDirLabel.Location = New System.Drawing.Point(339, 125)
        Me.FinalDirLabel.Name = "FinalDirLabel"
        Me.FinalDirLabel.Size = New System.Drawing.Size(108, 20)
        Me.FinalDirLabel.TabIndex = 24
        Me.FinalDirLabel.Text = "Final Directory:"
        '
        'TempDir2Check
        '
        Me.TempDir2Check.AutoSize = True
        Me.TempDir2Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir2Check.Location = New System.Drawing.Point(859, 73)
        Me.TempDir2Check.Name = "TempDir2Check"
        Me.TempDir2Check.Size = New System.Drawing.Size(79, 24)
        Me.TempDir2Check.TabIndex = 23
        Me.TempDir2Check.Text = "In RAM"
        Me.TempDir2Check.UseVisualStyleBackColor = True
        '
        'DebugTempDir2
        '
        Me.DebugTempDir2.AutoSize = True
        Me.DebugTempDir2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugTempDir2.Location = New System.Drawing.Point(339, 100)
        Me.DebugTempDir2.Name = "DebugTempDir2"
        Me.DebugTempDir2.Size = New System.Drawing.Size(0, 20)
        Me.DebugTempDir2.TabIndex = 22
        '
        'TempDir2Button
        '
        Me.TempDir2Button.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir2Button.Location = New System.Drawing.Point(790, 70)
        Me.TempDir2Button.Name = "TempDir2Button"
        Me.TempDir2Button.Size = New System.Drawing.Size(63, 29)
        Me.TempDir2Button.TabIndex = 21
        Me.TempDir2Button.Text = "Search"
        Me.TempDir2Button.UseVisualStyleBackColor = True
        '
        'TempDir2Text
        '
        Me.TempDir2Text.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir2Text.Location = New System.Drawing.Point(505, 72)
        Me.TempDir2Text.Name = "TempDir2Text"
        Me.TempDir2Text.Size = New System.Drawing.Size(279, 27)
        Me.TempDir2Text.TabIndex = 20
        '
        'TempDir2Label
        '
        Me.TempDir2Label.AutoSize = True
        Me.TempDir2Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir2Label.Location = New System.Drawing.Point(339, 75)
        Me.TempDir2Label.Name = "TempDir2Label"
        Me.TempDir2Label.Size = New System.Drawing.Size(160, 20)
        Me.TempDir2Label.TabIndex = 19
        Me.TempDir2Label.Text = "Temporary Directory 2:"
        '
        'DebugTempDir1
        '
        Me.DebugTempDir1.AutoSize = True
        Me.DebugTempDir1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugTempDir1.Location = New System.Drawing.Point(339, 50)
        Me.DebugTempDir1.Name = "DebugTempDir1"
        Me.DebugTempDir1.Size = New System.Drawing.Size(0, 20)
        Me.DebugTempDir1.TabIndex = 17
        '
        'TempDir1Button
        '
        Me.TempDir1Button.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir1Button.Location = New System.Drawing.Point(790, 20)
        Me.TempDir1Button.Name = "TempDir1Button"
        Me.TempDir1Button.Size = New System.Drawing.Size(63, 29)
        Me.TempDir1Button.TabIndex = 16
        Me.TempDir1Button.Text = "Search"
        Me.TempDir1Button.UseVisualStyleBackColor = True
        '
        'TempDir1Text
        '
        Me.TempDir1Text.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir1Text.Location = New System.Drawing.Point(505, 22)
        Me.TempDir1Text.Name = "TempDir1Text"
        Me.TempDir1Text.Size = New System.Drawing.Size(279, 27)
        Me.TempDir1Text.TabIndex = 15
        '
        'TempDir1
        '
        Me.TempDir1.AutoSize = True
        Me.TempDir1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TempDir1.Location = New System.Drawing.Point(339, 25)
        Me.TempDir1.Name = "TempDir1"
        Me.TempDir1.Size = New System.Drawing.Size(160, 20)
        Me.TempDir1.TabIndex = 14
        Me.TempDir1.Text = "Temporary Directory 1:"
        '
        'DebugNPlots
        '
        Me.DebugNPlots.AutoSize = True
        Me.DebugNPlots.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugNPlots.Location = New System.Drawing.Point(282, 165)
        Me.DebugNPlots.Name = "DebugNPlots"
        Me.DebugNPlots.Size = New System.Drawing.Size(0, 20)
        Me.DebugNPlots.TabIndex = 13
        '
        'NPlotsCheck
        '
        Me.NPlotsCheck.AutoSize = True
        Me.NPlotsCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NPlotsCheck.Location = New System.Drawing.Point(205, 164)
        Me.NPlotsCheck.Name = "NPlotsCheck"
        Me.NPlotsCheck.Size = New System.Drawing.Size(77, 24)
        Me.NPlotsCheck.TabIndex = 12
        Me.NPlotsCheck.Text = "Infinite"
        Me.NPlotsCheck.UseVisualStyleBackColor = True
        '
        'NPlotsText
        '
        Me.NPlotsText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NPlotsText.Location = New System.Drawing.Point(132, 162)
        Me.NPlotsText.Name = "NPlotsText"
        Me.NPlotsText.Size = New System.Drawing.Size(67, 27)
        Me.NPlotsText.TabIndex = 11
        '
        'NPlots
        '
        Me.NPlots.AutoSize = True
        Me.NPlots.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NPlots.Location = New System.Drawing.Point(6, 165)
        Me.NPlots.Name = "NPlots"
        Me.NPlots.Size = New System.Drawing.Size(120, 20)
        Me.NPlots.TabIndex = 10
        Me.NPlots.Text = "Number of Plots:"
        '
        'DebugCL
        '
        Me.DebugCL.AutoSize = True
        Me.DebugCL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugCL.Location = New System.Drawing.Point(205, 95)
        Me.DebugCL.Name = "DebugCL"
        Me.DebugCL.Size = New System.Drawing.Size(0, 20)
        Me.DebugCL.TabIndex = 9
        '
        'CLCombo
        '
        Me.CLCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CLCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CLCombo.FormattingEnabled = True
        Me.CLCombo.Location = New System.Drawing.Point(148, 92)
        Me.CLCombo.Name = "CLCombo"
        Me.CLCombo.Size = New System.Drawing.Size(51, 28)
        Me.CLCombo.TabIndex = 8
        '
        'CompressionLabel
        '
        Me.CompressionLabel.AutoSize = True
        Me.CompressionLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CompressionLabel.Location = New System.Drawing.Point(6, 95)
        Me.CompressionLabel.Name = "CompressionLabel"
        Me.CompressionLabel.Size = New System.Drawing.Size(136, 20)
        Me.CompressionLabel.TabIndex = 7
        Me.CompressionLabel.Text = "Compression Level:"
        '
        'DebugKValue
        '
        Me.DebugKValue.AutoSize = True
        Me.DebugKValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugKValue.Location = New System.Drawing.Point(132, 60)
        Me.DebugKValue.Name = "DebugKValue"
        Me.DebugKValue.Size = New System.Drawing.Size(0, 20)
        Me.DebugKValue.TabIndex = 6
        '
        'KValueCombo
        '
        Me.KValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.KValueCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.KValueCombo.FormattingEnabled = True
        Me.KValueCombo.Location = New System.Drawing.Point(75, 57)
        Me.KValueCombo.Name = "KValueCombo"
        Me.KValueCombo.Size = New System.Drawing.Size(51, 28)
        Me.KValueCombo.TabIndex = 5
        '
        'KVLabel
        '
        Me.KVLabel.AutoSize = True
        Me.KVLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.KVLabel.Location = New System.Drawing.Point(6, 60)
        Me.KVLabel.Name = "KVLabel"
        Me.KVLabel.Size = New System.Drawing.Size(63, 20)
        Me.KVLabel.TabIndex = 4
        Me.KVLabel.Text = "K-Value:"
        '
        'DebugPM
        '
        Me.DebugPM.AutoSize = True
        Me.DebugPM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DebugPM.Location = New System.Drawing.Point(259, 25)
        Me.DebugPM.Name = "DebugPM"
        Me.DebugPM.Size = New System.Drawing.Size(0, 20)
        Me.DebugPM.TabIndex = 3
        '
        'PMGPURadio
        '
        Me.PMGPURadio.AutoSize = True
        Me.PMGPURadio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PMGPURadio.Location = New System.Drawing.Point(195, 23)
        Me.PMGPURadio.Name = "PMGPURadio"
        Me.PMGPURadio.Size = New System.Drawing.Size(58, 24)
        Me.PMGPURadio.TabIndex = 2
        Me.PMGPURadio.TabStop = True
        Me.PMGPURadio.Text = "GPU"
        Me.PMGPURadio.UseVisualStyleBackColor = True
        '
        'PMCPURadio
        '
        Me.PMCPURadio.AutoSize = True
        Me.PMCPURadio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PMCPURadio.Location = New System.Drawing.Point(132, 23)
        Me.PMCPURadio.Name = "PMCPURadio"
        Me.PMCPURadio.Size = New System.Drawing.Size(57, 24)
        Me.PMCPURadio.TabIndex = 1
        Me.PMCPURadio.TabStop = True
        Me.PMCPURadio.Text = "CPU"
        Me.PMCPURadio.UseVisualStyleBackColor = True
        '
        'PMLabel
        '
        Me.PMLabel.AutoSize = True
        Me.PMLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PMLabel.Location = New System.Drawing.Point(6, 25)
        Me.PMLabel.Name = "PMLabel"
        Me.PMLabel.Size = New System.Drawing.Size(120, 20)
        Me.PMLabel.TabIndex = 0
        Me.PMLabel.Text = "Plotting Method:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.PlotDestination)
        Me.TabPage2.Controls.Add(Me.PlotSource)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1672, 1019)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'PlotDestination
        '
        Me.PlotDestination.Controls.Add(Me.MoveControls)
        Me.PlotDestination.Controls.Add(Me.ParentK34Check)
        Me.PlotDestination.Controls.Add(Me.ParentK33Check)
        Me.PlotDestination.Controls.Add(Me.ParentK32Check)
        Me.PlotDestination.Controls.Add(Me.ParentK31Check)
        Me.PlotDestination.Controls.Add(Me.ParentK30Check)
        Me.PlotDestination.Controls.Add(Me.MaxParallelMovesText)
        Me.PlotDestination.Controls.Add(Me.MaxParallelMovesLabel)
        Me.PlotDestination.Controls.Add(Me.AddDestinationButton)
        Me.PlotDestination.Controls.Add(Me.DestinationPlotDataGrid)
        Me.PlotDestination.Controls.Add(Me.DestinationPlotButton)
        Me.PlotDestination.Controls.Add(Me.DestinationPlotText)
        Me.PlotDestination.Controls.Add(Me.DestinationDirectoryLabel)
        Me.PlotDestination.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.PlotDestination.Location = New System.Drawing.Point(3, 313)
        Me.PlotDestination.Name = "PlotDestination"
        Me.PlotDestination.Size = New System.Drawing.Size(1671, 698)
        Me.PlotDestination.TabIndex = 1
        Me.PlotDestination.TabStop = False
        Me.PlotDestination.Text = "Plot Destination:"
        '
        'MoveControls
        '
        Me.MoveControls.Controls.Add(Me.StopMoveButton)
        Me.MoveControls.Controls.Add(Me.ResumeMoveButton)
        Me.MoveControls.Controls.Add(Me.PauseMoveButton)
        Me.MoveControls.Controls.Add(Me.StartMoveButton)
        Me.MoveControls.Location = New System.Drawing.Point(6, 636)
        Me.MoveControls.Name = "MoveControls"
        Me.MoveControls.Size = New System.Drawing.Size(429, 62)
        Me.MoveControls.TabIndex = 30
        Me.MoveControls.TabStop = False
        Me.MoveControls.Text = "Move Controls:"
        '
        'StopMoveButton
        '
        Me.StopMoveButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StopMoveButton.Location = New System.Drawing.Point(330, 26)
        Me.StopMoveButton.Name = "StopMoveButton"
        Me.StopMoveButton.Size = New System.Drawing.Size(92, 29)
        Me.StopMoveButton.TabIndex = 32
        Me.StopMoveButton.Text = "Stop Move"
        Me.StopMoveButton.UseVisualStyleBackColor = True
        '
        'ResumeMoveButton
        '
        Me.ResumeMoveButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ResumeMoveButton.Location = New System.Drawing.Point(211, 26)
        Me.ResumeMoveButton.Name = "ResumeMoveButton"
        Me.ResumeMoveButton.Size = New System.Drawing.Size(113, 29)
        Me.ResumeMoveButton.TabIndex = 31
        Me.ResumeMoveButton.Text = "Resume Move"
        Me.ResumeMoveButton.UseVisualStyleBackColor = True
        '
        'PauseMoveButton
        '
        Me.PauseMoveButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PauseMoveButton.Location = New System.Drawing.Point(104, 26)
        Me.PauseMoveButton.Name = "PauseMoveButton"
        Me.PauseMoveButton.Size = New System.Drawing.Size(101, 29)
        Me.PauseMoveButton.TabIndex = 30
        Me.PauseMoveButton.Text = "Pause Move"
        Me.PauseMoveButton.UseVisualStyleBackColor = True
        '
        'StartMoveButton
        '
        Me.StartMoveButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.StartMoveButton.Location = New System.Drawing.Point(6, 26)
        Me.StartMoveButton.Name = "StartMoveButton"
        Me.StartMoveButton.Size = New System.Drawing.Size(92, 29)
        Me.StartMoveButton.TabIndex = 29
        Me.StartMoveButton.Text = "Start Move"
        Me.StartMoveButton.UseVisualStyleBackColor = True
        '
        'ParentK34Check
        '
        Me.ParentK34Check.AutoSize = True
        Me.ParentK34Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ParentK34Check.Location = New System.Drawing.Point(1128, 22)
        Me.ParentK34Check.Name = "ParentK34Check"
        Me.ParentK34Check.Size = New System.Drawing.Size(56, 24)
        Me.ParentK34Check.TabIndex = 28
        Me.ParentK34Check.Text = "K34"
        Me.ParentK34Check.UseVisualStyleBackColor = True
        '
        'ParentK33Check
        '
        Me.ParentK33Check.AutoSize = True
        Me.ParentK33Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ParentK33Check.Location = New System.Drawing.Point(1066, 22)
        Me.ParentK33Check.Name = "ParentK33Check"
        Me.ParentK33Check.Size = New System.Drawing.Size(56, 24)
        Me.ParentK33Check.TabIndex = 27
        Me.ParentK33Check.Text = "K33"
        Me.ParentK33Check.UseVisualStyleBackColor = True
        '
        'ParentK32Check
        '
        Me.ParentK32Check.AutoSize = True
        Me.ParentK32Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ParentK32Check.Location = New System.Drawing.Point(1004, 22)
        Me.ParentK32Check.Name = "ParentK32Check"
        Me.ParentK32Check.Size = New System.Drawing.Size(56, 24)
        Me.ParentK32Check.TabIndex = 26
        Me.ParentK32Check.Text = "K32"
        Me.ParentK32Check.UseVisualStyleBackColor = True
        '
        'ParentK31Check
        '
        Me.ParentK31Check.AutoSize = True
        Me.ParentK31Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ParentK31Check.Location = New System.Drawing.Point(942, 22)
        Me.ParentK31Check.Name = "ParentK31Check"
        Me.ParentK31Check.Size = New System.Drawing.Size(56, 24)
        Me.ParentK31Check.TabIndex = 25
        Me.ParentK31Check.Text = "K31"
        Me.ParentK31Check.UseVisualStyleBackColor = True
        '
        'ParentK30Check
        '
        Me.ParentK30Check.AutoSize = True
        Me.ParentK30Check.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ParentK30Check.Location = New System.Drawing.Point(880, 22)
        Me.ParentK30Check.Name = "ParentK30Check"
        Me.ParentK30Check.Size = New System.Drawing.Size(56, 24)
        Me.ParentK30Check.TabIndex = 24
        Me.ParentK30Check.Text = "K30"
        Me.ParentK30Check.UseVisualStyleBackColor = True
        '
        'MaxParallelMovesText
        '
        Me.MaxParallelMovesText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxParallelMovesText.Location = New System.Drawing.Point(837, 20)
        Me.MaxParallelMovesText.Name = "MaxParallelMovesText"
        Me.MaxParallelMovesText.Size = New System.Drawing.Size(37, 27)
        Me.MaxParallelMovesText.TabIndex = 23
        '
        'MaxParallelMovesLabel
        '
        Me.MaxParallelMovesLabel.AutoSize = True
        Me.MaxParallelMovesLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MaxParallelMovesLabel.Location = New System.Drawing.Point(692, 23)
        Me.MaxParallelMovesLabel.Name = "MaxParallelMovesLabel"
        Me.MaxParallelMovesLabel.Size = New System.Drawing.Size(139, 20)
        Me.MaxParallelMovesLabel.TabIndex = 22
        Me.MaxParallelMovesLabel.Text = "Max Parallel Moves:"
        '
        'AddDestinationButton
        '
        Me.AddDestinationButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AddDestinationButton.Location = New System.Drawing.Point(639, 19)
        Me.AddDestinationButton.Name = "AddDestinationButton"
        Me.AddDestinationButton.Size = New System.Drawing.Size(47, 29)
        Me.AddDestinationButton.TabIndex = 21
        Me.AddDestinationButton.Text = "Add"
        Me.AddDestinationButton.UseVisualStyleBackColor = True
        '
        'DestinationPlotDataGrid
        '
        Me.DestinationPlotDataGrid.AllowDrop = True
        Me.DestinationPlotDataGrid.AllowUserToAddRows = False
        Me.DestinationPlotDataGrid.AllowUserToDeleteRows = False
        Me.DestinationPlotDataGrid.AllowUserToResizeRows = False
        Me.DestinationPlotDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DestinationPlotDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DestinationPlotDataGrid.Location = New System.Drawing.Point(6, 53)
        Me.DestinationPlotDataGrid.Name = "DestinationPlotDataGrid"
        Me.DestinationPlotDataGrid.RowHeadersWidth = 51
        Me.DestinationPlotDataGrid.RowTemplate.Height = 29
        Me.DestinationPlotDataGrid.Size = New System.Drawing.Size(1662, 577)
        Me.DestinationPlotDataGrid.TabIndex = 20
        '
        'DestinationPlotButton
        '
        Me.DestinationPlotButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DestinationPlotButton.Location = New System.Drawing.Point(488, 18)
        Me.DestinationPlotButton.Name = "DestinationPlotButton"
        Me.DestinationPlotButton.Size = New System.Drawing.Size(63, 29)
        Me.DestinationPlotButton.TabIndex = 19
        Me.DestinationPlotButton.Text = "Search"
        Me.DestinationPlotButton.UseVisualStyleBackColor = True
        '
        'DestinationPlotText
        '
        Me.DestinationPlotText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DestinationPlotText.Location = New System.Drawing.Point(165, 20)
        Me.DestinationPlotText.Name = "DestinationPlotText"
        Me.DestinationPlotText.Size = New System.Drawing.Size(317, 27)
        Me.DestinationPlotText.TabIndex = 18
        '
        'DestinationDirectoryLabel
        '
        Me.DestinationDirectoryLabel.AutoSize = True
        Me.DestinationDirectoryLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DestinationDirectoryLabel.Location = New System.Drawing.Point(6, 23)
        Me.DestinationDirectoryLabel.Name = "DestinationDirectoryLabel"
        Me.DestinationDirectoryLabel.Size = New System.Drawing.Size(153, 20)
        Me.DestinationDirectoryLabel.TabIndex = 17
        Me.DestinationDirectoryLabel.Text = "Destination Directory:"
        '
        'PlotSource
        '
        Me.PlotSource.Controls.Add(Me.AddSourceButton)
        Me.PlotSource.Controls.Add(Me.SourcePlotDataGrid)
        Me.PlotSource.Controls.Add(Me.SourcePlotButton)
        Me.PlotSource.Controls.Add(Me.SourcePlotText)
        Me.PlotSource.Controls.Add(Me.SourceDirectoryLabel)
        Me.PlotSource.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.PlotSource.Location = New System.Drawing.Point(24, 37)
        Me.PlotSource.Name = "PlotSource"
        Me.PlotSource.Size = New System.Drawing.Size(1671, 301)
        Me.PlotSource.TabIndex = 0
        Me.PlotSource.TabStop = False
        Me.PlotSource.Text = "Plot Source:"
        '
        'AddSourceButton
        '
        Me.AddSourceButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AddSourceButton.Location = New System.Drawing.Point(608, 19)
        Me.AddSourceButton.Name = "AddSourceButton"
        Me.AddSourceButton.Size = New System.Drawing.Size(47, 29)
        Me.AddSourceButton.TabIndex = 21
        Me.AddSourceButton.Text = "Add"
        Me.AddSourceButton.UseVisualStyleBackColor = True
        '
        'SourcePlotDataGrid
        '
        Me.SourcePlotDataGrid.AllowUserToAddRows = False
        Me.SourcePlotDataGrid.AllowUserToDeleteRows = False
        Me.SourcePlotDataGrid.AllowUserToResizeRows = False
        Me.SourcePlotDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SourcePlotDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.SourcePlotDataGrid.Location = New System.Drawing.Point(6, 53)
        Me.SourcePlotDataGrid.Name = "SourcePlotDataGrid"
        Me.SourcePlotDataGrid.RowHeadersWidth = 51
        Me.SourcePlotDataGrid.RowTemplate.Height = 29
        Me.SourcePlotDataGrid.Size = New System.Drawing.Size(1319, 188)
        Me.SourcePlotDataGrid.TabIndex = 20
        '
        'SourcePlotButton
        '
        Me.SourcePlotButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SourcePlotButton.Location = New System.Drawing.Point(457, 18)
        Me.SourcePlotButton.Name = "SourcePlotButton"
        Me.SourcePlotButton.Size = New System.Drawing.Size(63, 29)
        Me.SourcePlotButton.TabIndex = 19
        Me.SourcePlotButton.Text = "Search"
        Me.SourcePlotButton.UseVisualStyleBackColor = True
        '
        'SourcePlotText
        '
        Me.SourcePlotText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SourcePlotText.Location = New System.Drawing.Point(134, 20)
        Me.SourcePlotText.Name = "SourcePlotText"
        Me.SourcePlotText.Size = New System.Drawing.Size(317, 27)
        Me.SourcePlotText.TabIndex = 18
        '
        'SourceDirectoryLabel
        '
        Me.SourceDirectoryLabel.AutoSize = True
        Me.SourceDirectoryLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SourceDirectoryLabel.Location = New System.Drawing.Point(6, 23)
        Me.SourceDirectoryLabel.Name = "SourceDirectoryLabel"
        Me.SourceDirectoryLabel.Size = New System.Drawing.Size(122, 20)
        Me.SourceDirectoryLabel.TabIndex = 17
        Me.SourceDirectoryLabel.Text = "Source Directory:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1680, 1080)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "PoST Plotter Windows GUI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PlotControls.ResumeLayout(False)
        Me.SessionStats.ResumeLayout(False)
        Me.SessionStats.PerformLayout()
        Me.Console.ResumeLayout(False)
        Me.GPUOptions.ResumeLayout(False)
        Me.GPUOptions.PerformLayout()
        Me.CPUOptions.ResumeLayout(False)
        Me.CPUOptions.PerformLayout()
        Me.CommonOptions.ResumeLayout(False)
        Me.CommonOptions.PerformLayout()
        Me.AccountKeys.ResumeLayout(False)
        Me.AccountKeys.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.PlotDestination.ResumeLayout(False)
        Me.PlotDestination.PerformLayout()
        Me.MoveControls.ResumeLayout(False)
        CType(Me.DestinationPlotDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlotSource.ResumeLayout(False)
        Me.PlotSource.PerformLayout()
        CType(Me.SourcePlotDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DebugModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadMeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GitHubToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateCheckToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As ToolStripSeparator
    Friend WithEvents VersioningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenConfigLocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PlotControls As GroupBox
    Friend WithEvents PauseButton As Button
    Friend WithEvents ResumeButton As Button
    Friend WithEvents StopPlotButton As Button
    Friend WithEvents DebugPlotterGUIUpdater As Label
    Friend WithEvents SessionStats As GroupBox
    Friend WithEvents DebugLastPlotTime As Label
    Friend WithEvents LastPlotTimeLabel As Label
    Friend WithEvents DebugEstPlotsPerDay As Label
    Friend WithEvents EstPlotsPerDayLabel As Label
    Friend WithEvents DebugEstPlotsPerHour As Label
    Friend WithEvents EstPlotsPerHour As Label
    Friend WithEvents DebugAveragePlotTime As Label
    Friend WithEvents AveragePlotTimeLabel As Label
    Friend WithEvents DebugShortestPlotTime As Label
    Friend WithEvents ShortestPlotTimeLabel As Label
    Friend WithEvents DebugLongestPlotTime As Label
    Friend WithEvents LongestPlotTimeLabel As Label
    Friend WithEvents DebugNumPlotsCreated As Label
    Friend WithEvents NumPlotsCreatedLabel As Label
    Friend WithEvents PlotProgressBar As ProgressBar
    Friend WithEvents Console As GroupBox
    Friend WithEvents ConsolePrintOutTextBox As RichTextBox
    Friend WithEvents DebugPlotter As Label
    Friend WithEvents DebugPlotterPath As Label
    Friend WithEvents PlotButton As Button
    Friend WithEvents GPUOptions As GroupBox
    Friend WithEvents DebugMaxPlotsCacheTempDir As Label
    Friend WithEvents MaxPlotsCacheTempDirText As TextBox
    Friend WithEvents MaxParallelCopiesCheck As CheckBox
    Friend WithEvents DebugMaxParalleCopies As Label
    Friend WithEvents MaxPlotstoCacheinTempDirLabel As Label
    Friend WithEvents MaxMemText As TextBox
    Friend WithEvents TempDir3Check As CheckBox
    Friend WithEvents DebugMaxMem As Label
    Friend WithEvents DebugTempDir3 As Label
    Friend WithEvents MaxMemLabel As Label
    Friend WithEvents TempDir3Button As Button
    Friend WithEvents NumCudaText As TextBox
    Friend WithEvents TempDir3Text As TextBox
    Friend WithEvents StreamsText As TextBox
    Friend WithEvents TempDir3Label As Label
    Friend WithEvents DebugStreams As Label
    Friend WithEvents NumStreamsLabel As Label
    Friend WithEvents CudaDeviceText As TextBox
    Friend WithEvents DebugNumCuda As Label
    Friend WithEvents NumCudaLabel As Label
    Friend WithEvents DebugCudaDevice As Label
    Friend WithEvents CudaDeviceLabel As Label
    Friend WithEvents CPUOptions As GroupBox
    Friend WithEvents DebugAlternateTempDir As Label
    Friend WithEvents AlternateTempDirCheck As CheckBox
    Friend WithEvents DebugDirectInFinalDir As Label
    Friend WithEvents DirectInFinalDirCheck As CheckBox
    Friend WithEvents DebugStageDirectory As Label
    Friend WithEvents StageDirectoryButton As Button
    Friend WithEvents StageDirectoryText As TextBox
    Friend WithEvents StageDirectoryLabel As Label
    Friend WithEvents DebugThreadMultiplierP2 As Label
    Friend WithEvents ThreadMultiplierP2Text As TextBox
    Friend WithEvents ThreadMultiplierP2Label As Label
    Friend WithEvents BucketsP23Text As TextBox
    Friend WithEvents DebugBucketsP23 As Label
    Friend WithEvents BucketsP23Label As Label
    Friend WithEvents BucketsText As TextBox
    Friend WithEvents DebugBuckets As Label
    Friend WithEvents BucketsLabel As Label
    Friend WithEvents DebugNumThreads As Label
    Friend WithEvents NumThreadsCombo As ComboBox
    Friend WithEvents NumThreadsLabel As Label
    Friend WithEvents CommonOptions As GroupBox
    Friend WithEvents AdvancedOptionsCheck As CheckBox
    Friend WithEvents UniquePlotCheck As CheckBox
    Friend WithEvents DebugUniquePlot As Label
    Friend WithEvents AccountKeys As GroupBox
    Friend WithEvents ContractKeyRadio As RadioButton
    Friend WithEvents ContractKeyText As TextBox
    Friend WithEvents PoolKeyRadio As RadioButton
    Friend WithEvents PoolKeyLabel As Label
    Friend WithEvents DebugFarmerKey As Label
    Friend WithEvents PoolKeyText As TextBox
    Friend WithEvents FarmerKeyText As TextBox
    Friend WithEvents DebugPoolKey As Label
    Friend WithEvents FarmerKeyLabel As Label
    Friend WithEvents ContractKeyLabel As Label
    Friend WithEvents DebugContractKey As Label
    Friend WithEvents WaitforCopyCheck As CheckBox
    Friend WithEvents CPortText As TextBox
    Friend WithEvents DebugWaitforCopy As Label
    Friend WithEvents RemoteCopyPortText As TextBox
    Friend WithEvents DebugCPort As Label
    Friend WithEvents CPortCombo As ComboBox
    Friend WithEvents CPortLabel As Label
    Friend WithEvents DebugRemoteCopyPort As Label
    Friend WithEvents DebugFinalDir As Label
    Friend WithEvents RemoteCopyPortLabel As Label
    Friend WithEvents FinalDirButton As Button
    Friend WithEvents FinalDirText As TextBox
    Friend WithEvents FinalDirLabel As Label
    Friend WithEvents TempDir2Check As CheckBox
    Friend WithEvents DebugTempDir2 As Label
    Friend WithEvents TempDir2Button As Button
    Friend WithEvents TempDir2Text As TextBox
    Friend WithEvents TempDir2Label As Label
    Friend WithEvents DebugTempDir1 As Label
    Friend WithEvents TempDir1Button As Button
    Friend WithEvents TempDir1Text As TextBox
    Friend WithEvents TempDir1 As Label
    Friend WithEvents DebugNPlots As Label
    Friend WithEvents NPlotsCheck As CheckBox
    Friend WithEvents NPlotsText As TextBox
    Friend WithEvents NPlots As Label
    Friend WithEvents DebugCL As Label
    Friend WithEvents CLCombo As ComboBox
    Friend WithEvents CompressionLabel As Label
    Friend WithEvents DebugKValue As Label
    Friend WithEvents KValueCombo As ComboBox
    Friend WithEvents KVLabel As Label
    Friend WithEvents DebugPM As Label
    Friend WithEvents PMGPURadio As RadioButton
    Friend WithEvents PMCPURadio As RadioButton
    Friend WithEvents PMLabel As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PlotSource As GroupBox
    Friend WithEvents SourcePlotButton As Button
    Friend WithEvents SourcePlotText As TextBox
    Friend WithEvents SourceDirectoryLabel As Label
    Friend WithEvents AddSourceButton As Button
    Friend WithEvents SourcePlotDataGrid As DataGridView
    Friend WithEvents PlotDestination As GroupBox
    Friend WithEvents AddDestinationButton As Button
    Friend WithEvents DestinationPlotDataGrid As DataGridView
    Friend WithEvents DestinationPlotButton As Button
    Friend WithEvents DestinationPlotText As TextBox
    Friend WithEvents DestinationDirectoryLabel As Label
    Friend WithEvents MaxParallelMovesText As TextBox
    Friend WithEvents MaxParallelMovesLabel As Label
    Friend WithEvents MoveControls As GroupBox
    Friend WithEvents StopMoveButton As Button
    Friend WithEvents ResumeMoveButton As Button
    Friend WithEvents PauseMoveButton As Button
    Friend WithEvents StartMoveButton As Button
    Friend WithEvents ParentK34Check As CheckBox
    Friend WithEvents ParentK33Check As CheckBox
    Friend WithEvents ParentK32Check As CheckBox
    Friend WithEvents ParentK31Check As CheckBox
    Friend WithEvents ParentK30Check As CheckBox
End Class
