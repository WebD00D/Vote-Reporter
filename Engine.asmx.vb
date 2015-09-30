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
        Public usersAccess As Integer

        ' -- BASE SESSION SETTINGS --
        Public link1Name As String
        Public link1URL As String
        Public link2Name As String
        Public link2URL As String
        Public link3Name As String
        Public link3URL As String
        Public siteTitle As String
        Public governmentName As String
        Public legislatureName As String
        Public rcsNbrTitle As String
        Public billNbrTitle As String
        Public motionTitle As String
        Public dateTimeTitle As String
        Public voteTotalTitle As String
        Public resultsTitle As String
        Public outcomeTitle As String
        Public partyTotalsTitle As String
        Public memberTitle As String
        Public districtNameTitle As String
        Public districtNbrTitle As String
        Public presidingOfficer1Name As String
        Public presidingOfficer2Name As String
        Public presidingOfficer1Title As String
        Public presidingOfficer2Title As String
        Public clerkSecretaryName As String
        Public clerkSecretaryTitle As String
        Public motionDataField As Integer
        Public subjectDataField1 As Integer
        Public subjectDataField2 As Integer
        Public showDistrictName As Boolean
        Public showDistrictNbr As Boolean
        Public showMajorityStats As Boolean
        Public showPartyStats As Boolean
        Public showVotingStats As Boolean
        Public showOptionalAttendance As Boolean
        Public showOptionalStats As Boolean
        Public showOptionalPartyTotals As Boolean
        Public includeShortTitle As Boolean

        '--VOTE MAPPING SETTINGS --

        Public yeaEnabled As Boolean
        Public yeaNamesAs As Boolean
        Public yeaIsUsed As Boolean
        Public yeaIsEligible As Boolean
        Public yeaVoteValue1 As Integer = 1
        Public yeaVoteValue2 As Integer = -1
        Public yeaVoteValue3 As Integer = -1
        Public yeaHeaderOrder As Integer

        Public nayEnabled As Boolean
        Public nayNamesAs As Boolean
        Public nayIsUsed As Boolean
        Public nayIsEligible As Boolean
        Public nayVoteValue1 As Integer = 1
        Public nayVoteValue2 As Integer = -1
        Public nayVoteValue3 As Integer = -1
        Public nayHeaderOrder As Integer

        Public abstainEnabled As Boolean
        Public abstainNamesAs As Boolean
        Public abstainIsUsed As Boolean
        Public abstainIsEligible As Boolean
        Public abstainVoteValue1 As Integer = 1
        Public abstainVoteValue2 As Integer = -1
        Public abstainVoteValue3 As Integer = -1
        Public abstainHeaderOrder As Integer

        Public excusedEnabled As Boolean
        Public excusedNamesAs As Boolean
        Public excusedIsUsed As Boolean
        Public excusedIsEligible As Boolean
        Public excusedVoteValue1 As Integer = 1
        Public excusedVoteValue2 As Integer = -1
        Public excusedVoteValue3 As Integer = -1
        Public excusedHeaderOrder As Integer

        Public absentEnabled As Boolean
        Public absentNamesAs As Boolean
        Public absentIsUsed As Boolean
        Public absentIsEligible As Boolean
        Public absentVoteValue1 As Integer = 1
        Public absentVoteValue2 As Integer = -1
        Public absentVoteValue3 As Integer = -1
        Public absentHeaderOrder As Integer

        Public notVotingEnabled As Boolean
        Public notVotingNamesAs As Boolean
        Public notVotingIsUsed As Boolean
        Public notVotingIsEligible As Boolean
        Public notVotingVoteValue1 As Integer = 1
        Public notVotingVoteValue2 As Integer = -1
        Public notVotingVoteValue3 As Integer = -1
        Public notVotingHeaderOrder As Integer


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
                VR.governmentName = dt.Rows(0).Item("Government_Name")
                VR.legislatureName = dt.Rows(0).Item("Legislature_Name")
                VR.rcsNbrTitle = dt.Rows(0).Item("RSCNumber")
                VR.billNbrTitle = dt.Rows(0).Item("BillNumber")
                VR.motionTitle = dt.Rows(0).Item("Government_Name")
                VR.motionDataField = dt.Rows(0).Item("Motion")
                VR.subjectDataField1 = dt.Rows(0).Item("SubjectField1")
                VR.subjectDataField2 = dt.Rows(0).Item("SubjectField2")
                VR.dateTimeTitle = dt.Rows(0).Item("DateTime")
                VR.voteTotalTitle = dt.Rows(0).Item("VoteTotals")
                VR.resultsTitle = dt.Rows(0).Item("Results")
                VR.outcomeTitle = dt.Rows(0).Item("Outcome")
                VR.partyTotalsTitle = dt.Rows(0).Item("PartyTotals")
                VR.memberTitle = dt.Rows(0).Item("Member")
                VR.districtNameTitle = dt.Rows(0).Item("DistrictName")
                VR.districtNbrTitle = dt.Rows(0).Item("DistrictNumber")
                VR.presidingOfficer1Name = dt.Rows(0).Item("Presiding_Name_1")
                VR.presidingOfficer1Title = dt.Rows(0).Item("Presiding_Title_1")
                VR.presidingOfficer2Name = dt.Rows(0).Item("Presiding_Name_2")
                VR.presidingOfficer2Title = dt.Rows(0).Item("Presiding_Title_2")
                VR.clerkSecretaryName = dt.Rows(0).Item("Clerk_Secretary_Name")
                VR.clerkSecretaryTitle = dt.Rows(0).Item("Clerk_Secretary_Title")
                VR.showDistrictName = CBool(dt.Rows(0).Item("showDistrictName"))
                VR.showDistrictNbr = CBool(dt.Rows(0).Item("showDistrictNbr"))
                VR.showMajorityStats = CBool(dt.Rows(0).Item("showMajorityStats"))
                VR.showPartyStats = CBool(dt.Rows(0).Item("ShowPartyStats"))
                VR.showVotingStats = CBool(dt.Rows(0).Item("ShowVotingStats"))
                VR.showOptionalAttendance = CBool(dt.Rows(0).Item("ShowOptionalAttendance"))
                VR.showOptionalStats = CBool(dt.Rows(0).Item("ShowOptionalStats"))
                VR.includeShortTitle = CBool(dt.Rows(0).Item("IncludeShortTitle"))
                VR.showOptionalPartyTotals = CBool(dt.Rows(0).Item("ShowOptionalPartyTotals"))

                dt.Clear()

                Dim oParmList2 As List(Of SqlParameter) = New List(Of SqlParameter)
                oParmList2.Add(New SqlParameter("@SessionID", VR.currentSessionID))
                dt = ReturnDataTable("sp_VRGetVoteMappings", CommandType.StoredProcedure, oParmList2)

                VR.yeaEnabled = CBool(dt.Rows(0).Item("Enabled"))
                VR.yeaNamesAs = dt.Rows(0).Item("Named_As")
                VR.yeaIsUsed = CBool(dt.Rows(0).Item("IsUsed"))
                VR.yeaIsEligible = CBool(dt.Rows(0).Item("isEligible"))
                VR.yeaHeaderOrder = dt.Rows(0).Item("Header_Order")

                VR.nayEnabled = CBool(dt.Rows(1).Item("Enabled"))
                VR.nayNamesAs = dt.Rows(1).Item("Named_As")
                VR.nayIsUsed = CBool(dt.Rows(1).Item("IsUsed"))
                VR.nayIsEligible = CBool(dt.Rows(1).Item("isEligible"))
                VR.nayHeaderOrder = dt.Rows(1).Item("Header_Order")

                VR.abstainEnabled = CBool(dt.Rows(2).Item("Enabled"))
                VR.abstainNamesAs = dt.Rows(2).Item("Named_As")
                VR.abstainIsUsed = CBool(dt.Rows(2).Item("IsUsed"))
                VR.abstainIsEligible = CBool(dt.Rows(2).Item("isEligible"))
                VR.abstainHeaderOrder = dt.Rows(2).Item("Header_Order")

                VR.excusedEnabled = CBool(dt.Rows(3).Item("Enabled"))
                VR.excusedNamesAs = dt.Rows(3).Item("Named_As")
                VR.excusedIsUsed = CBool(dt.Rows(3).Item("IsUsed"))
                VR.excusedIsEligible = CBool(dt.Rows(3).Item("isEligible"))
                VR.excusedHeaderOrder = dt.Rows(3).Item("Header_Order")

                VR.absentEnabled = CBool(dt.Rows(4).Item("Enabled"))
                VR.absentNamesAs = dt.Rows(4).Item("Named_As")
                VR.absentIsUsed = CBool(dt.Rows(4).Item("IsUsed"))
                VR.absentIsEligible = CBool(dt.Rows(4).Item("isEligible"))
                VR.absentHeaderOrder = dt.Rows(4).Item("Header_Order")

                VR.notVotingEnabled = CBool(dt.Rows(5).Item("Enabled"))
                VR.notVotingNamesAs = dt.Rows(5).Item("Named_As")
                VR.notVotingIsUsed = CBool(dt.Rows(5).Item("IsUsed"))
                VR.notVotingIsEligible = CBool(dt.Rows(5).Item("isEligible"))
                VR.notVotingHeaderOrder = dt.Rows(5).Item("Header_Order")
     
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


