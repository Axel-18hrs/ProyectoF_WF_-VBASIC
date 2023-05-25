<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Begginning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Begginning))
        Me.pnlBEGSignin = New System.Windows.Forms.Panel()
        Me.lnkIhaveAcount = New System.Windows.Forms.LinkLabel()
        Me.btnBEGSRegister = New System.Windows.Forms.Button()
        Me.txtBEGSPassword = New System.Windows.Forms.TextBox()
        Me.lblBEGSPassword = New System.Windows.Forms.Label()
        Me.txtBEGSNameOfUser = New System.Windows.Forms.TextBox()
        Me.lblBEGSNameOfUser = New System.Windows.Forms.Label()
        Me.pbBEGSAvatarIco = New System.Windows.Forms.PictureBox()
        Me.pnlBEGLogin = New System.Windows.Forms.Panel()
        Me.pbBEGLogout = New System.Windows.Forms.PictureBox()
        Me.btnBEGAccess = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblBEGPassword = New System.Windows.Forms.Label()
        Me.txtNameOfUser = New System.Windows.Forms.TextBox()
        Me.lblBEGNameOfUser = New System.Windows.Forms.Label()
        Me.pbBEGAvatarIco = New System.Windows.Forms.PictureBox()
        Me.pnlBEGSignin.SuspendLayout()
        CType(Me.pbBEGSAvatarIco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBEGLogin.SuspendLayout()
        CType(Me.pbBEGLogout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBEGAvatarIco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBEGSignin
        '
        Me.pnlBEGSignin.BackColor = System.Drawing.Color.DimGray
        Me.pnlBEGSignin.Controls.Add(Me.lnkIhaveAcount)
        Me.pnlBEGSignin.Controls.Add(Me.btnBEGSRegister)
        Me.pnlBEGSignin.Controls.Add(Me.txtBEGSPassword)
        Me.pnlBEGSignin.Controls.Add(Me.lblBEGSPassword)
        Me.pnlBEGSignin.Controls.Add(Me.txtBEGSNameOfUser)
        Me.pnlBEGSignin.Controls.Add(Me.lblBEGSNameOfUser)
        Me.pnlBEGSignin.Controls.Add(Me.pbBEGSAvatarIco)
        Me.pnlBEGSignin.Location = New System.Drawing.Point(126, 54)
        Me.pnlBEGSignin.Name = "pnlBEGSignin"
        Me.pnlBEGSignin.Size = New System.Drawing.Size(476, 462)
        Me.pnlBEGSignin.TabIndex = 2
        '
        'lnkIhaveAcount
        '
        Me.lnkIhaveAcount.AutoSize = True
        Me.lnkIhaveAcount.Location = New System.Drawing.Point(164, 427)
        Me.lnkIhaveAcount.Name = "lnkIhaveAcount"
        Me.lnkIhaveAcount.Size = New System.Drawing.Size(104, 16)
        Me.lnkIhaveAcount.TabIndex = 7
        Me.lnkIhaveAcount.TabStop = True
        Me.lnkIhaveAcount.Text = "I have an acount"
        '
        'btnBEGSRegister
        '
        Me.btnBEGSRegister.BackColor = System.Drawing.Color.Salmon
        Me.btnBEGSRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBEGSRegister.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBEGSRegister.Location = New System.Drawing.Point(146, 363)
        Me.btnBEGSRegister.Name = "btnBEGSRegister"
        Me.btnBEGSRegister.Size = New System.Drawing.Size(195, 52)
        Me.btnBEGSRegister.TabIndex = 6
        Me.btnBEGSRegister.Text = "Register"
        Me.btnBEGSRegister.UseVisualStyleBackColor = False
        '
        'txtBEGSPassword
        '
        Me.txtBEGSPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBEGSPassword.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBEGSPassword.Location = New System.Drawing.Point(110, 311)
        Me.txtBEGSPassword.Name = "txtBEGSPassword"
        Me.txtBEGSPassword.Size = New System.Drawing.Size(281, 28)
        Me.txtBEGSPassword.TabIndex = 5
        '
        'lblBEGSPassword
        '
        Me.lblBEGSPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBEGSPassword.AutoSize = True
        Me.lblBEGSPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblBEGSPassword.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBEGSPassword.Location = New System.Drawing.Point(187, 282)
        Me.lblBEGSPassword.Name = "lblBEGSPassword"
        Me.lblBEGSPassword.Size = New System.Drawing.Size(103, 23)
        Me.lblBEGSPassword.TabIndex = 4
        Me.lblBEGSPassword.Text = "Password"
        '
        'txtBEGSNameOfUser
        '
        Me.txtBEGSNameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBEGSNameOfUser.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBEGSNameOfUser.Location = New System.Drawing.Point(110, 222)
        Me.txtBEGSNameOfUser.Name = "txtBEGSNameOfUser"
        Me.txtBEGSNameOfUser.Size = New System.Drawing.Size(281, 28)
        Me.txtBEGSNameOfUser.TabIndex = 3
        '
        'lblBEGSNameOfUser
        '
        Me.lblBEGSNameOfUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBEGSNameOfUser.AutoSize = True
        Me.lblBEGSNameOfUser.BackColor = System.Drawing.Color.Transparent
        Me.lblBEGSNameOfUser.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBEGSNameOfUser.Location = New System.Drawing.Point(106, 196)
        Me.lblBEGSNameOfUser.Name = "lblBEGSNameOfUser"
        Me.lblBEGSNameOfUser.Size = New System.Drawing.Size(141, 23)
        Me.lblBEGSNameOfUser.TabIndex = 2
        Me.lblBEGSNameOfUser.Text = "Name of user"
        '
        'pbBEGSAvatarIco
        '
        Me.pbBEGSAvatarIco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbBEGSAvatarIco.BackColor = System.Drawing.Color.Transparent
        Me.pbBEGSAvatarIco.BackgroundImage = CType(resources.GetObject("pbBEGSAvatarIco.BackgroundImage"), System.Drawing.Image)
        Me.pbBEGSAvatarIco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBEGSAvatarIco.Location = New System.Drawing.Point(163, 15)
        Me.pbBEGSAvatarIco.Name = "pbBEGSAvatarIco"
        Me.pbBEGSAvatarIco.Size = New System.Drawing.Size(178, 157)
        Me.pbBEGSAvatarIco.TabIndex = 1
        Me.pbBEGSAvatarIco.TabStop = False
        '
        'pnlBEGLogin
        '
        Me.pnlBEGLogin.BackColor = System.Drawing.Color.DimGray
        Me.pnlBEGLogin.Controls.Add(Me.pbBEGLogout)
        Me.pnlBEGLogin.Controls.Add(Me.btnBEGAccess)
        Me.pnlBEGLogin.Controls.Add(Me.txtPassword)
        Me.pnlBEGLogin.Controls.Add(Me.lblBEGPassword)
        Me.pnlBEGLogin.Controls.Add(Me.txtNameOfUser)
        Me.pnlBEGLogin.Controls.Add(Me.lblBEGNameOfUser)
        Me.pnlBEGLogin.Controls.Add(Me.pbBEGAvatarIco)
        Me.pnlBEGLogin.Location = New System.Drawing.Point(778, 54)
        Me.pnlBEGLogin.Name = "pnlBEGLogin"
        Me.pnlBEGLogin.Size = New System.Drawing.Size(476, 462)
        Me.pnlBEGLogin.TabIndex = 3
        '
        'pbBEGLogout
        '
        Me.pbBEGLogout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbBEGLogout.BackColor = System.Drawing.Color.Transparent
        Me.pbBEGLogout.BackgroundImage = CType(resources.GetObject("pbBEGLogout.BackgroundImage"), System.Drawing.Image)
        Me.pbBEGLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBEGLogout.Location = New System.Drawing.Point(14, 15)
        Me.pbBEGLogout.Name = "pbBEGLogout"
        Me.pbBEGLogout.Size = New System.Drawing.Size(50, 50)
        Me.pbBEGLogout.TabIndex = 8
        Me.pbBEGLogout.TabStop = False
        '
        'btnBEGAccess
        '
        Me.btnBEGAccess.BackColor = System.Drawing.Color.Salmon
        Me.btnBEGAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBEGAccess.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBEGAccess.Location = New System.Drawing.Point(146, 363)
        Me.btnBEGAccess.Name = "btnBEGAccess"
        Me.btnBEGAccess.Size = New System.Drawing.Size(195, 52)
        Me.btnBEGAccess.TabIndex = 6
        Me.btnBEGAccess.Text = "Access"
        Me.btnBEGAccess.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(110, 311)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(281, 28)
        Me.txtPassword.TabIndex = 5
        '
        'lblBEGPassword
        '
        Me.lblBEGPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBEGPassword.AutoSize = True
        Me.lblBEGPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblBEGPassword.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBEGPassword.Location = New System.Drawing.Point(187, 282)
        Me.lblBEGPassword.Name = "lblBEGPassword"
        Me.lblBEGPassword.Size = New System.Drawing.Size(103, 23)
        Me.lblBEGPassword.TabIndex = 4
        Me.lblBEGPassword.Text = "Password"
        '
        'txtNameOfUser
        '
        Me.txtNameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNameOfUser.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameOfUser.Location = New System.Drawing.Point(110, 222)
        Me.txtNameOfUser.Name = "txtNameOfUser"
        Me.txtNameOfUser.Size = New System.Drawing.Size(281, 28)
        Me.txtNameOfUser.TabIndex = 3
        '
        'lblBEGNameOfUser
        '
        Me.lblBEGNameOfUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBEGNameOfUser.AutoSize = True
        Me.lblBEGNameOfUser.BackColor = System.Drawing.Color.Transparent
        Me.lblBEGNameOfUser.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBEGNameOfUser.Location = New System.Drawing.Point(106, 196)
        Me.lblBEGNameOfUser.Name = "lblBEGNameOfUser"
        Me.lblBEGNameOfUser.Size = New System.Drawing.Size(141, 23)
        Me.lblBEGNameOfUser.TabIndex = 2
        Me.lblBEGNameOfUser.Text = "Name of user"
        '
        'pbBEGAvatarIco
        '
        Me.pbBEGAvatarIco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbBEGAvatarIco.BackColor = System.Drawing.Color.Transparent
        Me.pbBEGAvatarIco.BackgroundImage = CType(resources.GetObject("pbBEGAvatarIco.BackgroundImage"), System.Drawing.Image)
        Me.pbBEGAvatarIco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBEGAvatarIco.Location = New System.Drawing.Point(163, 15)
        Me.pbBEGAvatarIco.Name = "pbBEGAvatarIco"
        Me.pbBEGAvatarIco.Size = New System.Drawing.Size(178, 157)
        Me.pbBEGAvatarIco.TabIndex = 1
        Me.pbBEGAvatarIco.TabStop = False
        '
        'Begginning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1370, 553)
        Me.Controls.Add(Me.pnlBEGLogin)
        Me.Controls.Add(Me.pnlBEGSignin)
        Me.Name = "Begginning"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Begginning"
        Me.pnlBEGSignin.ResumeLayout(False)
        Me.pnlBEGSignin.PerformLayout()
        CType(Me.pbBEGSAvatarIco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBEGLogin.ResumeLayout(False)
        Me.pnlBEGLogin.PerformLayout()
        CType(Me.pbBEGLogout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBEGAvatarIco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlBEGSignin As Panel
    Private WithEvents lnkIhaveAcount As LinkLabel
    Private WithEvents btnBEGSRegister As Button
    Private WithEvents txtBEGSPassword As TextBox
    Private WithEvents lblBEGSPassword As Label
    Private WithEvents txtBEGSNameOfUser As TextBox
    Private WithEvents lblBEGSNameOfUser As Label
    Private WithEvents pbBEGSAvatarIco As PictureBox
    Private WithEvents pnlBEGLogin As Panel
    Private WithEvents pbBEGLogout As PictureBox
    Private WithEvents btnBEGAccess As Button
    Private WithEvents txtPassword As TextBox
    Private WithEvents lblBEGPassword As Label
    Private WithEvents txtNameOfUser As TextBox
    Private WithEvents lblBEGNameOfUser As Label
    Private WithEvents pbBEGAvatarIco As PictureBox
End Class
