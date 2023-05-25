Imports System.IO

Namespace ProyectoF_WF.Classes
    Public Class Administrator
        Inherits User
        Private ReadOnly _imageExtensions As New List(Of String) From {".jpg", ".jpeg", ".png", ".bmp", ".gif"}
        Private ReadOnly _videoExtensions As New List(Of String) From {".mp4", ".mov", ".avi", ".wmv", ".mkv"}
        Private _imagePaths As New List(Of String)()
        Private _videoPaths As New List(Of String)()

        ' Gets the list of image file paths associated with the client.
        Public ReadOnly Property ImagePaths() As List(Of String)
            Get
                Return _imagePaths
            End Get
        End Property

        ' Gets the list of video file paths associated with the client.
        Public ReadOnly Property VideoPaths() As List(Of String)
            Get
                Return _videoPaths
            End Get
        End Property

        Public Sub New()
            IsAdmin = True
        End Sub

        Public Sub MoveFile(file As String)
            Dim _admin As Administrator = ClientManager.AdministratorInstance

            ' Check if the selected file is a valid image or video file
            If Not (_imageExtensions.Union(_videoExtensions).Contains(Path.GetExtension(file).ToLower())) Then
                MessageBox.Show("The selected file is not a valid image or video file.")
                Return
            End If

            Dim rootFolder As String = ClientManager.AdministratorFolderPath
            Dim userFolder As String = Path.Combine(rootFolder, _admin.Name)

            ' Create the user folder if it doesn't exist
            If Not Directory.Exists(userFolder) Then
                Directory.CreateDirectory(userFolder)
            End If

            ' Create the image folder inside the user folder if it doesn't exist
            Dim imageFolder As String = Path.Combine(userFolder, "Images")
            If Not Directory.Exists(imageFolder) Then
                Directory.CreateDirectory(imageFolder)
            End If

            ' Create the video folder inside the user folder if it doesn't exist
            Dim videoFolder As String = Path.Combine(userFolder, "Videos")
            If Not Directory.Exists(videoFolder) Then
                Directory.CreateDirectory(videoFolder)
            End If

            ' Move the file to the corresponding folder based on its extension
            Dim destinationFolder As String
            If _imageExtensions.Contains(Path.GetExtension(file).ToLower()) Then
                destinationFolder = imageFolder
            Else
                destinationFolder = videoFolder
            End If

            Dim fileName As String = Path.GetFileName(file)

            If Not String.IsNullOrEmpty(destinationFolder) AndAlso Not String.IsNullOrEmpty(fileName) Then
                Dim destinationPath As String = Path.Combine(destinationFolder, fileName)
                If Not Directory.Exists(destinationPath) Then
                    Directory.Move(file, destinationPath)
                Else
                    MessageBox.Show("A file with the same name already exists in the destination folder.")
                End If
            Else
                MessageBox.Show("Error combining the destination file path.")
            End If
        End Sub

        ' Refreshes the file paths associated with the client.
        Public Sub RefreshPaths()
            Dim _admi As Administrator = ClientManager.AdministratorInstance

            ' Clear the existing file path lists
            _imagePaths.Clear()
            _videoPaths.Clear()

            ' Get the user folder path
            Dim rootFolder As String = ClientManager.AdministratorFolderPath
            Dim userFolder As String = Path.Combine(rootFolder, ClientManager.AdministratorInstance.Name)

            ' Get the file paths of all files in the user folder and its subfolders
            Dim imageFiles As String() = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories) _
            .Where(Function(file) _imageExtensions.Contains(Path.GetExtension(file))) _
            .ToArray()

            Dim videoFiles As String() = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories) _
            .Where(Function(file) _videoExtensions.Contains(Path.GetExtension(file))) _
            .ToArray()

            ' Add the file paths to the corresponding lists
            _imagePaths.AddRange(imageFiles)
            _videoPaths.AddRange(videoFiles)
        End Sub
    End Class
End Namespace
