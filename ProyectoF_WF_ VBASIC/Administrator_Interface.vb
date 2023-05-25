Imports Newtonsoft.Json
Imports ProyectoF_WF__VBASIC.ProyectoF_WF.Classes
Imports System.IO

Public Class Administrator_Interface
    Private formBase As Form

    Public Property FormBase2 As Form
        Get
            Return formBase
        End Get
        Set(ByVal value As Form)
            formBase = value
        End Set
    End Property
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        dgvUsers.RowHeadersVisible = False
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvUsers.AllowUserToResizeRows = False
        Dim jsonFolderPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF_vbasic")
        Dim userDataList As List(Of ConcretUser) = New List(Of ConcretUser)()

        For Each jsonFilePath As String In Directory.EnumerateFiles(jsonFolderPath, "*.json", SearchOption.AllDirectories)
            Dim json As String = File.ReadAllText(jsonFilePath)
            Dim userData As ConcretUser = JsonConvert.DeserializeObject(Of ConcretUser)(json)
            userDataList.Add(userData)
        Next

        dgvUsers.AutoGenerateColumns = False
        dgvUsers.Columns.Add("IdColumn", "ID")
        dgvUsers.Columns.Add("IsAdminColumn", "Admin")
        dgvUsers.Columns.Add("NameColumn", "Name")
        dgvUsers.Columns.Add("PasswordColumn", "Password")
        dgvUsers.Columns.Add("RegistrationDateColumn", "Registration Date")
        dgvUsers.Columns.Add("ProfileImageColumn", "Profile Image")
        dgvUsers.Columns("IdColumn").DataPropertyName = "Id"
        dgvUsers.Columns("IsAdminColumn").DataPropertyName = "IsAdmin"
        dgvUsers.Columns("NameColumn").DataPropertyName = "Name"
        dgvUsers.Columns("PasswordColumn").DataPropertyName = "Password"
        dgvUsers.Columns("RegistrationDateColumn").DataPropertyName = "Registration_Date"
        dgvUsers.Columns("ProfileImageColumn").DataPropertyName = "Profile_Image"
        dgvUsers.DataSource = userDataList

    End Sub
    Private Sub Administrator_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Administrator_Interface_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        formBase.Location = Me.Location
        formBase.Show()
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim anyAdminSelected As Boolean = False

            For Each dataGridViewRow As DataGridViewRow In dgvUsers.SelectedRows
                Dim isAdmin As Boolean = Convert.ToBoolean(dataGridViewRow.Cells("IsAdminColumn").Value)

                If isAdmin Then
                    anyAdminSelected = True
                    Continue For
                End If

                Dim username As String = dataGridViewRow.Cells("NameColumn").Value.ToString()
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the user " & username & "?", "Confirmation", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Dim jsonFolderPath As String = ClientManager.UserFolderPath
                    Dim userFolderPath As String = Path.Combine(jsonFolderPath, username)

                    If Directory.Exists(userFolderPath) Then
                        Directory.Delete(userFolderPath, True)
                        MessageBox.Show("User " & username & " has been deleted.")
                    Else
                        MessageBox.Show("The user has already been deleted.")
                    End If
                End If
            Next

            If anyAdminSelected Then
                MessageBox.Show("Administrators cannot be deleted.")
            End If
        End If
    End Sub
End Class