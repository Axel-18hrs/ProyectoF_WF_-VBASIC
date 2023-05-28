Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports AxWMPLib
Imports ProyectoF_WF__VBASIC.ProyectoF_WF.Classes
Imports WMPLib

Partial Public Class User_Interface
    Inherits Form

    Private openFileDialog As OpenFileDialog
    Private _client As Client
    Private _administrator As Administrator
    Private originalPictureBoxSize As Size
    Private originalPictureBoxLocation As Point
    Private currentImageIndex As Integer = 0
    Private disableDoubleClickEvent As Boolean = False
    Private imagePaths As List(Of String)
    Private videoPaths As List(Of String)
    Private _formBase1 As Form

    Public Property FormBase1 As Form
        Get
            Return FormBase1
        End Get
        Set(value As Form)
            _formBase1 = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        _formBase1 = New Form()
        openFileDialog = New OpenFileDialog()
        imagePaths = New List(Of String)()
        videoPaths = New List(Of String)()

        If ClientManager.ClientInstance IsNot Nothing Then
            _client = ClientManager.ClientInstance
            _client.RefreshPaths()

            ' Get image paths
            imagePaths = _client.ImagePaths

            ' Get video paths
            videoPaths = _client.VideoPaths
        End If

        If ClientManager.AdministratorInstance IsNot Nothing Then
            _administrator = ClientManager.AdministratorInstance
            _administrator.RefreshPaths()

            ' Get image paths
            imagePaths = _administrator.ImagePaths

            ' Get video paths
            videoPaths = _administrator.VideoPaths
        End If

        CargarVideos()
        CargarImagenes()

        Dim x As Integer = (Me.Width - pbCargarImagenes.Width) \ 2
        Dim y As Integer = (Me.Height - pbCargarImagenes.Height) \ 2
        pbCargarImagenes.Location = New Point(x, y)

        originalPictureBoxSize = pbCargarImagenes.Size
        originalPictureBoxLocation = pbCargarImagenes.Location

        AxWindowsMediaPlayer1.Dock = DockStyle.Fill

        pbCargarImagenes.SizeMode = PictureBoxSizeMode.Zoom
        pbCargarImagenes.Anchor = AnchorStyles.None
        pbCargarImagenes.Location = New Point((Me.ClientSize.Width - pbCargarImagenes.Width) \ 2, (Me.ClientSize.Height - pbCargarImagenes.Height) \ 2)
    End Sub

    Protected Overrides Sub Finalize()
        ClientManager.InitializeCliente(Nothing)
    End Sub

    Private Sub CargarVideos()
        AxWindowsMediaPlayer1.URL = Nothing

        ' Verificar si la lista de rutas de videos está vacía o es nula
        If videoPaths Is Nothing OrElse videoPaths.Count = 0 Then
            MessageBox.Show("No videos found.")
            Return
        End If

        ' Obtener la primera ruta de video de la lista
        Dim videoPath As String = videoPaths(0)

        ' Asignar la ruta del video al control AxWindowsMediaPlayer
        AxWindowsMediaPlayer1.URL = videoPath
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub CargarImagenes()
        pbCargarImagenes.Image = Nothing

        If imagePaths Is Nothing OrElse imagePaths.Count = 0 Then
            MessageBox.Show("No images found.")
            Return
        End If

        Dim imagePath As String = imagePaths(0)

        Try
            Using image As Image = Image.FromFile(imagePath)
                pbCargarImagenes.Image = New Bitmap(image)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading image: {ex.Message}")
        End Try
    End Sub

    Private Sub User_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.Visible = False
        pbCargarImagenes.Visible = False
    End Sub

    Private Sub EscogerArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles escogerArchivoToolStripMenuItem.Click
        openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Video files|*.mp4;*.mov;*.avi;*.wmv;*.mkv"

        If openFileDialog.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Dim selectedFile As String = openFileDialog.FileName

        If ClientManager.ClientInstance IsNot Nothing Then
            _client.MoveFile(selectedFile)
            _client.RefreshPaths()

            imagePaths = _client.ImagePaths
            videoPaths = _client.VideoPaths
        End If

        If ClientManager.AdministratorInstance IsNot Nothing Then
            _administrator.MoveFile(selectedFile)
            _administrator.RefreshPaths()

            imagePaths = _administrator.ImagePaths
            videoPaths = _administrator.VideoPaths
        End If

        If videoPaths.Count > 0 Then
            Dim videoPath As String = videoPaths(0)
            AxWindowsMediaPlayer1.URL = videoPath
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
        ElseIf imagePaths.Count > 0 Then
            Dim imagePath As String = imagePaths(0)
            pbCargarImagenes.Image = Image.FromFile(imagePath)
        Else
            MessageBox.Show("No videos or images found.")
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub

    Private Sub AxWindowsMediaPlayer1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles AxWindowsMediaPlayer1.PreviewKeyDown
        If videoPaths Is Nothing OrElse videoPaths.Count = 0 Then
            Return
        End If

        Select Case e.KeyCode
            Case Keys.Left
                Dim currentIndex As Integer = videoPaths.IndexOf(AxWindowsMediaPlayer1.URL)
                Dim previousIndex As Integer = (currentIndex - 1 + videoPaths.Count) Mod videoPaths.Count
                Dim previousVideoPath As String = videoPaths(previousIndex)
                AxWindowsMediaPlayer1.URL = previousVideoPath
                AxWindowsMediaPlayer1.Ctlcontrols.play()
                Console.WriteLine("Left!")
            Case Keys.Right
                Dim currentIndex As Integer = videoPaths.IndexOf(AxWindowsMediaPlayer1.URL)
                Dim nextIndex As Integer = (currentIndex + 1) Mod videoPaths.Count
                Dim nextVideoPath As String = videoPaths(nextIndex)
                AxWindowsMediaPlayer1.URL = nextVideoPath
                AxWindowsMediaPlayer1.Ctlcontrols.play()
                Console.WriteLine("Right!")
            Case Else
                ' Do nothing for other keys
        End Select
    End Sub

    Private Sub ImagenesDelUsuarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles imagenesDelUsuarToolStripMenuItem.Click
        If pbCargarImagenes Is Nothing Then
            Return
        End If

        If AxWindowsMediaPlayer1.Visible = True Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            AxWindowsMediaPlayer1.Visible = False
        End If

        pbCargarImagenes.Focus()
        pbCargarImagenes.Visible = True
    End Sub

    Private Sub VideosDelUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles videosDelUsuarioToolStripMenuItem.Click
        If AxWindowsMediaPlayer1 Is Nothing Then
            Return
        End If

        If pbCargarImagenes.Visible = True Then
            pbCargarImagenes.Visible = False
        End If

        AxWindowsMediaPlayer1.Focus()
        AxWindowsMediaPlayer1.Visible = True
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub User_Interface_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        _formBase1.Location = Me.Location
        _formBase1.Show()
        Me.Close()
    End Sub

    Private Sub Log_OutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Log_OutToolStripMenuItem.Click
        Dispose()
        _formBase1.Location = Me.Location
        _formBase1.Show()
        Me.Close()
    End Sub

    Private Sub User_Interface_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If pbCargarImagenes.Focus() Then
            If imagePaths Is Nothing OrElse imagePaths.Count = 0 Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Space
                    menuStrip1.Visible = True
                    Me.WindowState = FormWindowState.Normal
                    Me.FormBorderStyle = FormBorderStyle.Sizable
                    pbCargarImagenes.Visible = True
                    disableDoubleClickEvent = False

                    pbCargarImagenes.Size = originalPictureBoxSize
                    pbCargarImagenes.SizeMode = PictureBoxSizeMode.Zoom
                    pbCargarImagenes.Location = originalPictureBoxLocation
                Case Keys.Left
                    currentImageIndex = (currentImageIndex - 1 + imagePaths.Count) Mod imagePaths.Count
                    Dim previousImagePath As String = imagePaths(currentImageIndex)
                    pbCargarImagenes.Image = Image.FromFile(previousImagePath)
                Case Keys.Right
                    currentImageIndex = (currentImageIndex + 1) Mod imagePaths.Count
                    Dim nextImagePath As String = imagePaths(currentImageIndex)
                    pbCargarImagenes.Image = Image.FromFile(nextImagePath)
                Case Else
                    ' Do nothing for other keys
            End Select
        End If
    End Sub

    Private Sub PbCargarImagenes_DoubleClick(sender As Object, e As EventArgs) Handles pbCargarImagenes.DoubleClick
        If disableDoubleClickEvent Then
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        pbCargarImagenes.Visible = False
        disableDoubleClickEvent = True

        Dim pictureBoxWidth As Integer = Me.ClientSize.Width
        Dim pictureBoxHeight As Integer = Me.ClientSize.Height
        Dim pictureBoxX As Integer = (Me.ClientSize.Width - pictureBoxWidth) \ 2
        Dim pictureBoxY As Integer = (Me.ClientSize.Height - pictureBoxHeight) \ 2

        pbCargarImagenes.Size = New Size(pictureBoxWidth, pictureBoxHeight)
        pbCargarImagenes.Location = New Point(pictureBoxX, pictureBoxY)
    End Sub
End Class