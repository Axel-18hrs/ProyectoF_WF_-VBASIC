﻿
Imports Newtonsoft.Json
Imports ProyectoF_WF__VBASIC.ProyectoF_WF.Classes
Imports System.IO

Public Class Begginning
    Private _userManager As UserManager
    Private _administrator As Administrator

    Public Sub New()
        InitializeComponent()
        _userManager = New UserManager()
        _userManager.LoadUsers()
        pnlBEGLogin.BackColor = Color.FromArgb(150, Color.Violet)
        pnlBEGLogin.Location = New Point((Me.ClientSize.Width - pnlBEGLogin.Width) / 2, (Me.ClientSize.Height - pnlBEGLogin.Height) / 2)
        pbBEGAvatarIco.Anchor = AnchorStyles.None
        pbBEGAvatarIco.Dock = DockStyle.Top
        pbBEGAvatarIco.Width = 200
        pbBEGAvatarIco.AutoSize = True
        pbBEGAvatarIco.Margin = New Padding((pnlBEGLogin.ClientSize.Width - pbBEGAvatarIco.Width) / 2, 10, 0, 0)
        lblBEGNameOfUser.Top = pbBEGAvatarIco.Bottom + 10
        lblBEGNameOfUser.Left = (pnlBEGLogin.Width - lblBEGNameOfUser.Width) / 2
        txtNameOfUser.Top = lblBEGNameOfUser.Bottom + 10
        txtNameOfUser.Left = (pnlBEGLogin.Width - txtNameOfUser.Width) / 2
        lblBEGPassword.Top = txtNameOfUser.Bottom + 10
        lblBEGPassword.Left = (pnlBEGLogin.Width - lblBEGPassword.Width) / 2
        txtPassword.Top = lblBEGPassword.Bottom + 10
        txtPassword.Left = (pnlBEGLogin.Width - txtPassword.Width) / 2
        btnBEGAccess.Top = txtPassword.Bottom + 10
        btnBEGAccess.Left = (pnlBEGLogin.Width - btnBEGAccess.Width) / 2
        pnlBEGLogin.Visible = False
        pnlBEGSignin.BackColor = Color.FromArgb(150, Color.Violet)
        pnlBEGSignin.Location = New Point((Me.ClientSize.Width - pnlBEGLogin.Width) / 2, (Me.ClientSize.Height - pnlBEGLogin.Height) / 2)
        pbBEGSAvatarIco.Anchor = AnchorStyles.None
        pbBEGSAvatarIco.Dock = DockStyle.Top
        pbBEGSAvatarIco.Width = 200
        pbBEGSAvatarIco.AutoSize = True
        pbBEGSAvatarIco.Margin = New Padding((pnlBEGLogin.ClientSize.Width - pbBEGAvatarIco.Width) / 2, 10, 0, 0)
        lblBEGSNameOfUser.Top = pbBEGSAvatarIco.Bottom + 10
        lblBEGSNameOfUser.Left = (pnlBEGSignin.Width - lblBEGSNameOfUser.Width) / 2
        txtBEGSNameOfUser.Top = lblBEGSNameOfUser.Bottom + 10
        txtBEGSNameOfUser.Left = (pnlBEGSignin.Width - txtBEGSNameOfUser.Width) / 2
        lblBEGSPassword.Top = txtBEGSNameOfUser.Bottom + 10
        lblBEGSPassword.Left = (pnlBEGSignin.Width - lblBEGSPassword.Width) / 2
        txtBEGSPassword.Top = lblBEGSPassword.Bottom + 10
        txtBEGSPassword.Left = (pnlBEGSignin.Width - txtBEGSPassword.Width) / 2
        btnBEGSRegister.Top = txtBEGSPassword.Bottom + 10
        btnBEGSRegister.Left = (pnlBEGSignin.Width - btnBEGSRegister.Width) / 2
        lnkIhaveAcount.Top = btnBEGSRegister.Bottom + 8
        lnkIhaveAcount.Left = (pnlBEGSignin.Width - lnkIhaveAcount.Width) / 2
        pnlBEGSignin.Visible = True

        Dim _administrator As Administrator = New Administrator() With
        {
        .Id = Guid.NewGuid(),
            .IsAdmin = True,
            .Name = "SAM34",
            .Password = "1212"
        }
        Dim userFolderPath As String = Path.Combine(ClientManager.AdministratorFolderPath, _administrator.Name)
        Dim jsonFilePath As String = Path.Combine(userFolderPath, $"{_administrator.Name}.json")

        If Not Directory.Exists(userFolderPath) Then
            Directory.CreateDirectory(userFolderPath)
            Dim json As String = JsonConvert.SerializeObject(_administrator, Formatting.Indented)
            File.WriteAllText(jsonFilePath, json)
            _userManager.AddUser(_administrator)
        Else
            _administrator = Nothing
        End If
    End Sub
    Private Sub Begginning_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBEGSRegister_Click(sender As Object, e As EventArgs) Handles btnBEGSRegister.Click
        If String.IsNullOrEmpty(txtBEGSNameOfUser.Text) OrElse String.IsNullOrEmpty(txtBEGSPassword.Text) Then
            MessageBox.Show("I did not fill in the fields properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim username As String = txtBEGSNameOfUser.Text
        Dim password As String = txtBEGSPassword.Text
        Dim userFolderPath As String = Path.Combine(ClientManager.UserFolderPath, $"{username}")

        ' Verificar si el nombre de usuario ya existe en la lista de usuarios
        If Directory.Exists(userFolderPath) Then
            MessageBox.Show("The username is already in use.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Definir los caracteres permitidos para el nombre de usuario
        Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"

        ' Verificar si el nombre de usuario contiene caracteres no permitidos
        For Each c As Char In username
            If Not allowedChars.Contains(c) Then
                MessageBox.Show("The username contains disallowed characters.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Next

        ' Crear una nueva instancia de Client con los datos del nuevo usuario
        Dim newClient As New Client() With {
        .Id = Guid.NewGuid(),
        .Name = username,
        .Password = password
        }

        ' Agregar el nuevo usuario a través de ClientManager
        Dim userAdded As Boolean = _userManager.AddUser(newClient)

        If userAdded Then
            ' El usuario se registró correctamente
            MessageBox.Show("The user was successfully registered.", "Successful Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClientManager.InitializeCliente(newClient)
            txtBEGSNameOfUser.Clear()
            txtBEGSPassword.Clear()
            Me.Hide()
            Dim us As New User_Interface With {
            .StartPosition = FormStartPosition.Manual,
            .Location = Me.Location,
            .FormBase1 = Me
            }
            us.ShowDialog()
        Else
            ' Ocurrió un error al agregar el usuario
            MessageBox.Show("Error adding the user.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnBEGAccess_Click(sender As Object, e As EventArgs) Handles btnBEGAccess.Click
        Dim username As String = txtNameOfUser.Text
        Dim password As String = txtPassword.Text
        Dim projectFolderPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF_vbasic")
        Console.WriteLine($"Project Folder Path: {projectFolderPath}")
        ' Buscar el archivo JSON del usuario dentro de la carpeta del proyecto y sus subcarpetas
        Dim userFilePaths As String() = Directory.GetFiles(projectFolderPath, $"{username}.json", SearchOption.AllDirectories)

        If userFilePaths.Length > 0 Then
            ' Considerar solo el primer archivo JSON coincident
            Dim userFilePath As String = userFilePaths(0)

            ' Cargar el contenido del archivo JSON
            Dim json As String = File.ReadAllText(userFilePath)
            Dim existingUser As ConcretUser = JsonConvert.DeserializeObject(Of ConcretUser)(json)

            ' Verificar el nombre de usuario y la contraseña
            If existingUser.Name.Equals(username, StringComparison.OrdinalIgnoreCase) AndAlso existingUser.Password = password Then
                ' Las credenciales son válidas
                MessageBox.Show("The credentials are valid.")
                txtNameOfUser.Clear()
                txtPassword.Clear()
                Me.Hide()

                ' Mostrar el formulario correspondiente según el tipo de usuario
                If existingUser.IsAdmin Then
                    Dim dialogResult As DialogResult = MessageBox.Show($"Access as administrator", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Dim _administrator As Administrator = New Administrator() With
            {
                .Id = existingUser.Id,
                    .IsAdmin = existingUser.IsAdmin,
                    .Name = existingUser.Name,
                    .Password = existingUser.Password,
                    .Registration_Date = existingUser.Registration_Date
                }
                    ClientManager.InitializeAdministrator(_administrator)
                    _administrator.Deff()

                    If dialogResult = DialogResult.Yes Then
                        Dim adminInterface As Administrator_Interface = New Administrator_Interface()
                        adminInterface.StartPosition = FormStartPosition.Manual
                        adminInterface.Location = Me.Location
                        adminInterface.FormBase2 = Me
                        adminInterface.ShowDialog()
                    ElseIf dialogResult = DialogResult.No Then
                        Dim userInterface As User_Interface = New User_Interface()
                        userInterface.StartPosition = FormStartPosition.Manual
                        userInterface.Location = Me.Location
                        userInterface.FormBase1 = Me
                        userInterface.ShowDialog()
                    End If
                Else
                    Dim _client As Client = New Client() With
            {
                .Id = existingUser.Id,
                    .IsAdmin = existingUser.IsAdmin,
                    .Name = existingUser.Name,
                    .Password = existingUser.Password,
                    .Registration_Date = existingUser.Registration_Date
                }
                    ClientManager.InitializeCliente(_client)
                    _client.Deff()
                    Dim userInterface As User_Interface = New User_Interface()
                    userInterface.StartPosition = FormStartPosition.Manual
                    userInterface.Location = Me.Location
                    userInterface.FormBase1 = Me
                    userInterface.ShowDialog()
                    ClientManager.InitializeCliente(_client)
                End If
            Else
                ' El nombre de usuario no existe o la contraseña es incorrecta
                MessageBox.Show("The username does not exist or the password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub pbBEGLogout_Click(sender As Object, e As EventArgs) Handles pbBEGLogout.Click
        pnlBEGLogin.Visible = False
        pnlBEGSignin.Visible = True
    End Sub

    Private Sub pbBEGLogout_MouseHover(sender As Object, e As EventArgs) Handles pbBEGLogout.MouseHover
        Dim tt As New ToolTip()
        tt.SetToolTip(Me.pbBEGLogout, "Return")
    End Sub

    Private Sub lnkIhaveAcount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIhaveAcount.LinkClicked
        pnlBEGLogin.Visible = True
        pnlBEGSignin.Visible = False
    End Sub
End Class
