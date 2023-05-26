<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_Interface
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(User_Interface))
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.escogerArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imagenesDelUsuarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.videosDelUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Log_OutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbCargarImagenes = New System.Windows.Forms.PictureBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.menuStrip1.SuspendLayout()
        CType(Me.pbCargarImagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.escogerArchivoToolStripMenuItem, Me.imagenesDelUsuarToolStripMenuItem, Me.videosDelUsuarioToolStripMenuItem, Me.Log_OutToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1370, 30)
        Me.menuStrip1.TabIndex = 1
        Me.menuStrip1.Text = "menuStrip1"
        '
        'escogerArchivoToolStripMenuItem
        '
        Me.escogerArchivoToolStripMenuItem.Name = "escogerArchivoToolStripMenuItem"
        Me.escogerArchivoToolStripMenuItem.Size = New System.Drawing.Size(97, 24)
        Me.escogerArchivoToolStripMenuItem.Size = New System.Drawing.Size(97, 26)
        Me.escogerArchivoToolStripMenuItem.Text = "Choose file"
        '
        'imagenesDelUsuarToolStripMenuItem
        '
        Me.imagenesDelUsuarToolStripMenuItem.Name = "imagenesDelUsuarToolStripMenuItem"
        Me.imagenesDelUsuarToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.imagenesDelUsuarToolStripMenuItem.Size = New System.Drawing.Size(112, 26)
        Me.imagenesDelUsuarToolStripMenuItem.Text = "Studio image"
        '
        'videosDelUsuarioToolStripMenuItem
        '
        Me.videosDelUsuarioToolStripMenuItem.Name = "videosDelUsuarioToolStripMenuItem"
        Me.videosDelUsuarioToolStripMenuItem.Size = New System.Drawing.Size(99, 24)
        Me.videosDelUsuarioToolStripMenuItem.Size = New System.Drawing.Size(99, 26)
        Me.videosDelUsuarioToolStripMenuItem.Text = "User videos"
        '
        'Log_OutToolStripMenuItem
        '
        Me.Log_OutToolStripMenuItem.Name = "Log_OutToolStripMenuItem"
        Me.Log_OutToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.Log_OutToolStripMenuItem.Size = New System.Drawing.Size(74, 26)
        Me.Log_OutToolStripMenuItem.Text = "Log out"
        '
        'pbCargarImagenes
        '
        Me.pbCargarImagenes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCargarImagenes.Location = New System.Drawing.Point(69, 70)
        Me.pbCargarImagenes.Location = New System.Drawing.Point(72, 59)
        Me.pbCargarImagenes.Name = "pbCargarImagenes"
        Me.pbCargarImagenes.Size = New System.Drawing.Size(1225, 419)
        Me.pbCargarImagenes.TabIndex = 3
        Me.pbCargarImagenes.TabStop = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 31)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(1370, 521)
        Me.AxWindowsMediaPlayer1.TabIndex = 4
        '
        'User_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1370, 553)
        Me.Controls.Add(Me.pbCargarImagenes)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Name = "User_Interface"
        Me.Text = "User_Interface"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.pbCargarImagenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents escogerArchivoToolStripMenuItem As ToolStripMenuItem
    Private WithEvents imagenesDelUsuarToolStripMenuItem As ToolStripMenuItem
    Private WithEvents videosDelUsuarioToolStripMenuItem As ToolStripMenuItem
    Private WithEvents Log_OutToolStripMenuItem As ToolStripMenuItem
    Private WithEvents pbCargarImagenes As PictureBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
End Class
