Imports Newtonsoft.Json.Linq
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace ProyectoF_WF.Classes
    Module ClientManager
        Public Property ClientInstance As Client
        Public Property AdministratorInstance As Administrator
        ' B
        Public ReadOnly Property UserFolderPath As String
            Get
                Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF_vbasic", "Users")
            End Get
        End Property

        Public ReadOnly Property AdministratorFolderPath As String
            Get
                Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF_vbasic", "Administrator")
            End Get
        End Property

        Sub InitializeCliente(ByVal user As Client)
            ClientInstance = user
        End Sub

        Sub InitializeAdministrator(ByVal user As Administrator)
            AdministratorInstance = user
        End Sub
    End Module
End Namespace
