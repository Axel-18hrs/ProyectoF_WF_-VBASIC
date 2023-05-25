Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports AxWMPLib
Imports ProyectoF_WF__VBASIC.ProyectoF_WF.Classes
Imports WMPLib

Public Class User_Interface
    Private openFileDialog As OpenFileDialog
    Private _client As Client
    Private _administrator As Administrator
    Private originalPictureBoxSize As Size
    Private originalPictureBoxLocation As Point
    Private currentImageIndex As Integer = 0
    Private imagePaths As List(Of String)
    Private videoPaths As List(Of String)
    Private formBase1 As Form
    Private currentIndex As Integer
    Private disableDoubleClickEvent As Boolean = False
    Public Property FormBase As Form
        Get
            Return formBase1
        End Get
        Set(ByVal value As Form)
            formBase1 = value
        End Set
    End Property

    Sub New()
        InitializeComponent()
        formBase1 = New Form()
        openFileDialog = New OpenFileDialog()
        imagePaths = New List(Of String)()
        videoPaths = New List(Of String)()
        If ClientManager.ClientInstance IsNot Nothing Then
            _client = ClientManager.ClientInstance
            _client.RefreshPaths()
            imagePaths = _client.ImagePaths
            videoPaths = _client.VideoPaths
        End If

        If ClientManager.AdministratorInstance IsNot Nothing Then
            _administrator = ClientManager.AdministratorInstance
            imagePaths = _administrator.ImagePaths
            videoPaths = _administrator.VideoPaths
        End If


        CargarVideos()
        CargarImagenes()

        AxWindowsMediaPlayer1.Visible = True
        AxWindowsMediaPlayer1.settings.autoStart = False
        pbCargarImagenes.Visible = False
        AxWindowsMediaPlayer1.Location = New Point(100, 100)
        Dim x As Integer = (Me.Width - pbCargarImagenes.Width) / 2
        Dim y As Integer = (Me.Height - pbCargarImagenes.Height) / 2
        pbCargarImagenes.Location = New Point(x, y)
        originalPictureBoxSize = pbCargarImagenes.Size
        originalPictureBoxLocation = pbCargarImagenes.Location
        AxWindowsMediaPlayer1.Dock = DockStyle.Fill
        AxWindowsMediaPlayer1.Location = New Point(Me.Width, Me.Height)
        pbCargarImagenes.SizeMode = PictureBoxSizeMode.Zoom
        pbCargarImagenes.Anchor = AnchorStyles.None
        pbCargarImagenes.Location = New Point((Me.ClientSize.Width - pbCargarImagenes.Width) / 2, (Me.ClientSize.Height - pbCargarImagenes.Height) / 2)
    End Sub
    Private Sub User_Interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Protected Overrides Sub Finalize()
        ClientManager.InitializeCliente(Nothing)
    End Sub

    Public Sub CargarVideos()
        AxWindowsMediaPlayer1.URL = Nothing

        ' Verificar si la lista de rutas de videos está vacía o es nula
        If videoPaths Is Nothing OrElse videoPaths.Count = 0 Then
            MessageBox.Show("No video found.")
            Return
        End If

        ' Obtener la primera ruta de video de la lista
        Dim videoPath As String = videoPaths(0)

        ' Asignar la ruta del video al control AxWindowsMediaPlayer
        AxWindowsMediaPlayer1.URL = videoPath

        ' Detener la reproducción del video en el control
        AxWindowsMediaPlayer1.Ctlcontrols.[stop]()
    End Sub

    Public Sub CargarImagenes()
        pbCargarImagenes.Image = Nothing

        If imagePaths Is Nothing OrElse imagePaths.Count = 0 Then
            MessageBox.Show("No images found.")
            Return
        End If

        Dim imagePath As String = imagePaths(0)

        Try
            Using img = Image.FromFile(imagePath)
                pbCargarImagenes.Image = New Bitmap(img)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading image: {ex.Message}")
        End Try
    End Sub
    Private Sub escogerArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles escogerArchivoToolStripMenuItem.Click
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
        AxWindowsMediaPlayer1.Ctlcontrols.[stop]()
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
        If videoPaths Is Nothing OrElse videoPaths.Count = 0 Then Return

        Select Case e.KeyCode
            Case Keys.Left
                Dim currentIndex As Integer = videoPaths.IndexOf(AxWindowsMediaPlayer1.URL)
                Dim previousIndex As Integer = (currentIndex - 1 + videoPaths.Count) Mod videoPaths.Count
                Dim previousVideoPath As String = videoPaths(previousIndex)
                AxWindowsMediaPlayer1.URL = previousVideoPath
                AxWindowsMediaPlayer1.Ctlcontrols.play()
                Console.WriteLine("Left!")
            Case Keys.Right
                currentIndex = videoPaths.IndexOf(AxWindowsMediaPlayer1.URL)
                Dim nextIndex As Integer = (currentIndex + 1) Mod videoPaths.Count
                Dim nextVideoPath As String = videoPaths(nextIndex)
                AxWindowsMediaPlayer1.URL = nextVideoPath
                AxWindowsMediaPlayer1.Ctlcontrols.play()
                Console.WriteLine("Right!")
            Case Else
        End Select
    End Sub

    Private Sub imagenesDelUsuarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles imagenesDelUsuarToolStripMenuItem.Click
        If AxWindowsMediaPlayer1.Visible = True Then
            AxWindowsMediaPlayer1.Ctlcontrols.[stop]()
            AxWindowsMediaPlayer1.Visible = False
        End If

        pbCargarImagenes.Focus()
        pbCargarImagenes.Visible = True
    End Sub

    Private Sub videosDelUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles videosDelUsuarioToolStripMenuItem.Click
        If pbCargarImagenes.Visible = True Then
            pbCargarImagenes.Visible = False
        End If

        AxWindowsMediaPlayer1.Focus()
        AxWindowsMediaPlayer1.Visible = True
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub User_Interface_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        formBase1.Location = Me.Location
        formBase1.Show()
        Me.Close()
    End Sub

    Private Sub Log_OutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Log_OutToolStripMenuItem.Click
        Dispose()
        formBase1.Location = Me.Location
        formBase1.Show()
        Me.Close()
    End Sub

    Private Sub User_Interface_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If pbCargarImagenes.Focus() Then
            If imagePaths Is Nothing OrElse imagePaths.Count = 0 Then Return

            Select Case e.KeyCode
                Case Keys.Space
                    disableDoubleClickEvent = True
                    menuStrip1.Visible = True
                    Me.WindowState = FormWindowState.Normal
                    Me.FormBorderStyle = FormBorderStyle.Sizable
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
            End Select
        End If
    End Sub

    Private Sub pbCargarImagenes_DoubleClick(sender As Object, e As EventArgs) Handles pbCargarImagenes.DoubleClick
        If disableDoubleClickEvent = True Then
            Return
        End If
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        menuStrip1.Visible = False
        disableDoubleClickEvent = True
        Dim pictureBoxWidth As Integer = Me.ClientSize.Width
        Dim pictureBoxHeight As Integer = Me.ClientSize.Height
        Dim pictureBoxX As Integer = (Me.ClientSize.Width - pictureBoxWidth) / 2
        Dim pictureBoxY As Integer = (Me.ClientSize.Height - pictureBoxHeight) / 2
        pbCargarImagenes.Size = New Size(pictureBoxWidth, pictureBoxHeight)
        pbCargarImagenes.Location = New Point(pictureBoxX, pictureBoxY)
    End Sub
End Class