Imports System.IO
Imports newton
Imports Newtonsoft.Json


Namespace ProyectoF_WF.Classes
    Public Class UserManager
        Implements IUserManager
        Private _jsonFilePaths As List(Of String)
        Private ReadOnly _users As List(Of User)

        Public Sub New()
            _users = New List(Of User)()
        End Sub

        Public Sub LoadUsers()
            Dim _userFolderPath As String = ClientManager.UserFolderPath
            Dim _adminFolderPath As String = ClientManager.AdministratorFolderPath

            If Not Directory.Exists(_userFolderPath) Then
                Directory.CreateDirectory(_userFolderPath)
            End If

            If Not Directory.Exists(_adminFolderPath) Then
                Directory.CreateDirectory(_adminFolderPath)
            End If

            _jsonFilePaths = Directory.EnumerateFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF"), "*.json").ToList()

            For Each jsonFilePath As String In _jsonFilePaths
                Dim json As String = File.ReadAllText(jsonFilePath)
                Dim user As User = JsonConvert.DeserializeObject(Of User)(json)
                _users.Add(user)

                Console.WriteLine($"Usuario cargado: {user.Name}")
            Next
        End Sub

        Public Function AddUser(user As User) As Boolean Implements IUserManager.AddUser
            If Not user.IsAdmin Then
                Dim clientUser As Client = TryCast(user, Client)
                If clientUser IsNot Nothing Then
                    _users.Add(clientUser)
                    WriteUserFile(user)
                End If
            End If

            Return True
        End Function

        Private Sub WriteUserFile(user As User)
            If user.IsAdmin = False Then
                Dim userFolderPath As String = Path.Combine(ClientManager.UserFolderPath, $"{user.Name}")

                If Not Directory.Exists(userFolderPath) Then
                    Directory.CreateDirectory(userFolderPath)
                End If

                Dim userFilePath As String = Path.Combine(userFolderPath, $"{user.Name}.json")
                Dim json As String = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented)
                File.WriteAllText(userFilePath, json)
            ElseIf user.IsAdmin = True Then
                Dim admiFolderPath As String = Path.Combine(ClientManager.AdministratorFolderPath, $"{user.Name}")

                If Not Directory.Exists(admiFolderPath) Then
                    Directory.CreateDirectory(admiFolderPath)
                End If

                Dim admiFilePath As String = Path.Combine(admiFolderPath, $"{user.Name}.json")
                Dim json As String = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented)
                File.WriteAllText(admiFilePath, json)
            End If
        End Sub
    End Class
End Namespace
