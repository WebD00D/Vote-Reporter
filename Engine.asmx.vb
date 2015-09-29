Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Object
Imports System.MarshalByRefObject
Imports System.Data.Common.DbParameterCollection
Imports System.Data.SqlClient.SqlParameterCollection

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Engine
    Inherits System.Web.Services.WebService

    Public Class clsVoteReporter
        Public defaultSessionID As Integer 'This is the session ID that is marked current in the database. 
        Public currentSessionID As Integer
        Public currentSessionCode As String
        Public currentSessionName As String
        Public currentSessionLegislature As String
        Public usersFirstName As String
        Public usersAccess
        Public link1Name As String
        Public link1URL As String
        Public link2Name As String
        Public link2URL As String
        Public link3Name As String
        Public link3URL As String
        Public siteTitle As String
    End Class

    Public Class clsLegislativeSession
        Public sessionID As Integer
        Public sessionCode As String
        Public sessionName As String
        Public isCurrentSession As Boolean
        Public legislatureName As String
    End Class

#Region "Vote Reporter Base"

    <WebMethod(True)> _
    Public Function ValidateUser(ByVal Username As String, ByVal Password As String)

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As DataTable = ReturnDataTable("SELECT * FROM Users WHERE Username ='" & Username & "'", CommandType.Text, Nothing)
        Dim VRList As New List(Of clsVoteReporter)
        Dim VR As New clsVoteReporter

        If dt.Rows.Count = 1 Then
            Dim userMgmtService As New UserManagementService()
            Dim md5Hash As MD5 = MD5.Create()
            Dim DBHash As String = dt.Rows(0).Item("Password")
            Dim HashedPass = userMgmtService.GetHash(md5Hash, Password)
            If userMgmtService.UnHashIt(HashedPass, DBHash) Then

                VR.usersFirstName = dt.Rows(0).Item("FirstName")
                VR.usersAccess = dt.Rows(0).Item("Type")

                dt.Clear()

                dt = getDefaultSession()

                VR.defaultSessionID = dt.Rows(0).Item("SessionID")
                VR.currentSessionID = dt.Rows(0).Item("SessionID")
                VR.currentSessionCode = dt.Rows(0).Item("SessionCode")
                VR.currentSessionName = dt.Rows(0).Item("SessionName")
                VR.currentSessionLegislature = dt.Rows(0).Item("Legislature")

                dt.Clear()

                Dim oParmList As List(Of SqlParameter) = New List(Of SqlParameter)
                oParmList.Add(New SqlParameter("@SessionID", VR.currentSessionID))
                dt = ReturnDataTable("sp_VRGetReportConfigParams", CommandType.StoredProcedure, oParmList)

                VR.link1Name = dt.Rows(0).Item("Link1_Name")
                VR.link1URL = dt.Rows(0).Item("Link1_URL")
                VR.link2Name = dt.Rows(0).Item("Link2_Name")
                VR.link2URL = dt.Rows(0).Item("Link2_URL")
                VR.link3Name = dt.Rows(0).Item("Link3_Name")
                VR.link3URL = dt.Rows(0).Item("Link3_URL")
                VR.siteTitle = dt.Rows(0).Item("Government_Name")

                VRList.Add(VR)
                Session("clsVoteReporter") = VRList

            End If
            Return True
        Else
            Return False
        End If

    End Function

  
    <WebMethod(True)> _
    Public Function GetBaseVoteReporterData()
        Dim VRList As List(Of clsVoteReporter) = Session("clsVoteReporter")
        Return VRList
    End Function

    <WebMethod(True)> _
    Public Function LoadSessions()
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetAvailableSessions"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            cmd.Connection.Close()
        End Using

        Dim VRSessionList As New List(Of clsLegislativeSession)

        If dt.Rows.Count > 0 Then
            For Each Item As DataRow In dt.Rows()
                Dim VRSession As New clsLegislativeSession
                VRSession.sessionID = Item("SessionID")
                VRSession.sessionCode = Item("SessionCode")
                VRSession.sessionName = Item("SessionName")
                VRSession.legislatureName = Item("Legislature")
                VRSessionList.Add(VRSession)
            Next
        End If

        Return VRSessionList

    End Function

    <WebMethod(True)> _
    Public Function getDefaultSession()

        Dim dt As New DataTable
        dt = ReturnDataTable("SELECT s.SessionID,sd.SessionCode,sd.SessionName,sd.IsCurrent,s.Legislature Legislature FROM VRSession s INNER JOIN VRSessionDetail sd on s.SessionID = sd.SessionID WHERE IsCurrent = 1", CommandType.Text, Nothing)

        Return dt

    End Function

    <WebMethod(True)> _
    Public Function getSessionDetails(ByVal SessionID As Integer)

        Dim dt As New DataTable
        dt = ReturnDataTable("SELECT s.SessionID,sd.SessionCode,sd.SessionName,s.Legislature Legislature FROM VRSession s INNER JOIN VRSessionDetail sd on s.SessionID = sd.SessionID WHERE s.SessionID = " & SessionID, CommandType.Text, Nothing)
        Return dt

    End Function


    <WebMethod(True)> _
    Public Function getCurrentSession()

        Dim VRList As List(Of clsVoteReporter) = Session("clsVoteReporter")
        Return VRList.Item(0).currentSessionID

    End Function

    <WebMethod(True)> _
    Public Function getCurrentSessionCode()
        Dim VRList As List(Of clsVoteReporter) = Session("clsVoteReporter")
        Return VRList.Item(0).currentSessionCode
    End Function

    <WebMethod(True)> _
    Public Function updateSession(ByVal SessionID As Integer)

        'Get all data related to that session ID
        Try
            Dim dt As DataTable = getSessionDetails(SessionID)
            Dim VRList As List(Of clsVoteReporter) = Session("clsVoteReporter")
            VRList.Item(0).currentSessionID = SessionID
            VRList.Item(0).currentSessionCode = dt.Rows(0).Item("SessionCode")
            VRList.Item(0).currentSessionName = dt.Rows(0).Item("SessionName")
            VRList.Item(0).currentSessionLegislature = dt.Rows(0).Item("Legislature")

            dt.Clear()

            Dim oParmList As List(Of SqlParameter) = New List(Of SqlParameter)
            oParmList.Add(New SqlParameter("@SessionID", SessionID))
            dt = ReturnDataTable("sp_VRGetReportConfigParams", CommandType.StoredProcedure, oParmList)

            VRList.Item(0).link1Name = dt.Rows(0).Item("Link1_Name")
            VRList.Item(0).link1URL = dt.Rows(0).Item("Link1_URL")
            VRList.Item(0).link2Name = dt.Rows(0).Item("Link2_Name")
            VRList.Item(0).link2URL = dt.Rows(0).Item("Link2_URL")
            VRList.Item(0).link3Name = dt.Rows(0).Item("Link3_Name")
            VRList.Item(0).link3URL = dt.Rows(0).Item("Link3_URL")
            VRList.Item(0).siteTitle = dt.Rows(0).Item("Government_Name")

            Session("clsVoteReporter") = VRList
            Return True
        Catch ex As Exception
            Return False
        End Try

       
    End Function

#End Region

#Region "DB Tasks"
    <WebMethod(True)> _
    Public Function ReturnDataTable(ByVal cmdtext As String, ByVal cmdType As System.Data.CommandType, ByVal oParm As List(Of SqlParameter))
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = cmdType
            cmd.CommandText = cmdtext

            If Not IsNothing(oParm) Then
                cmd.Parameters.AddRange(oParm.ToArray())
            End If

            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            cmd.Connection.Close()
        End Using
        Return dt
    End Function


#End Region

End Class


