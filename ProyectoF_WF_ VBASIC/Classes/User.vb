
Namespace ProyectoF_WF.Classes
    Public MustInherit Class User
        Public Property Id As Guid
        Public Property IsAdmin As Boolean
        Public Property Name As String
        Public Property Password As String
        Public Property Registration_Date As DateTime

        Public Sub New()
            ' Id = Guid.NewGuid();
            Dim now As DateTime = DateTime.Now
            Dim trimmedDateTime As DateTime = New DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0)
            Registration_Date = trimmedDateTime
        End Sub

        Public Overridable Sub Deff()
            Console.WriteLine("user")
        End Sub
    End Class

End Namespace