Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class SessionService
    Inherits System.Web.Services.WebService

    Public Class SessionDetails

        Public SessionID As Integer
        Public SessionCode As String
        Public IsCurrent As Boolean

    End Class

    Shared SessionDetailsList As New List(Of SessionDetails)() From {}


    <WebMethod(True)> _
    Public Function LoadSessions()

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        With cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRSetSession"
            Using da
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            .Connection.Close()
        End With

        SessionDetailsList.Clear()
        For Each Item As DataRow In dt.Rows()
            Dim sd As New SessionDetails()
            sd.SessionCode = Item("SessionCode")
            sd.SessionID = Item("SessionId")
            sd.IsCurrent = Item("IsCurrent")

            '  If sd.IsCurrent = True And CStr(Session("CurrentSession")) = String.Empty Then
            'SetSessionID(sd.SessionID, 0)
            '           End If


            SessionDetailsList.Add(sd)
        Next

        Return SessionDetailsList

        Return ""
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function SetSessionID(ByVal SessionID As Integer, ByVal index As Integer)

        Session("CurrentSession") = SessionID
        Session("SelectedIndex") = index

        Return ""
    End Function





End Class