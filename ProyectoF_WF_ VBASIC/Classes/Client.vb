Imports System.IO
Imports Newtonsoft.Json
Imports ProyectoF_WF.Interfaces
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace ProyectoF_WF.Classes
    Public Class Client
        Inherits User

        Private ReadOnly _imageExtensions As List(Of String) = New List(Of String) From {
            ".jpg",
            ".jpeg",
            ".png",
            ".bmp",
            ".gif"
        }
        Private ReadOnly _videoExtensions As List(Of String) = New List(Of String) From {
            ".mp4",
            ".mov",
            ".avi",
            ".wmv",
            ".mkv"
        }
        Private _imagePaths As List(Of String) = New List(Of String)()
        Private _videoPaths As List(Of String) = New List(Of String)()

        Public ReadOnly Property ImagePaths As List(Of String)
            Get
                Return _imagePaths
            End Get
        End Property

        Public ReadOnly Property VideoPaths As List(Of String)
            Get
                Return _videoPaths
            End Get
        End Property

        Public Sub New()
            IsAdmin = False
        End Sub

        Public Sub MoveFile(ByVal file As String)
            Dim _client As Client = ClientManager.ClientInstance

            If Not (_imageExtensions.Union(_videoExtensions).Contains(Path.GetExtension(file).ToLower())) Then
                MessageBox.Show("The selected file is not a valid image or video file.")
                Return
            End If

            Dim rootFolder As String = ClientManager.UserFolderPath
            Dim userFolder As String = Path.Combine(rootFolder, _client.Name)

            If Not Directory.Exists(userFolder) Then
                Directory.CreateDirectory(userFolder)
            End If

            Dim imageFolder As String = Path.Combine(userFolder, "Images")

            If Not Directory.Exists(imageFolder) Then
                Directory.CreateDirectory(imageFolder)
            End If

            Dim videoFolder As String = Path.Combine(userFolder, "Videos")

            If Not Directory.Exists(videoFolder) Then
                Directory.CreateDirectory(videoFolder)
            End If

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
        ''' <summary>
        ''' METHOD
        ''' </summary>
        Public Sub RefreshPaths()
            Dim _user As Client = ClientManager.ClientInstance
            _imagePaths.Clear()
            _videoPaths.Clear()
            Dim rootFolder As String = ClientManager.UserFolderPath
            Dim userFolder As String = Path.Combine(rootFolder, ClientManager.ClientInstance.Name)
            Dim imageFiles As String() = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories).Where(Function(file) _imageExtensions.Contains(Path.GetExtension(file))).ToArray()
            Dim videoFiles As String() = Directory.GetFiles(userFolder, "*.*", SearchOption.AllDirectories).Where(Function(file) _videoExtensions.Contains(Path.GetExtension(file))).ToArray()
            _imagePaths.AddRange(imageFiles)
            _videoPaths.AddRange(videoFiles)
        End Sub
    End Class
End Namespace