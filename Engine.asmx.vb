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
        Public yeaNamesAs As String
        Public yeaIsUsed As Boolean
        Public yeaIsEligible As Boolean
        Public yeaVoteValue1 As Integer = 1
        Public yeaVoteValue2 As Integer = -1
        Public yeaVoteValue3 As Integer = -1
        Public yeaHeaderOrder As Integer

        Public nayEnabled As Boolean
        Public nayNamesAs As String
        Public nayIsUsed As Boolean
        Public nayIsEligible As Boolean
        Public nayVoteValue1 As Integer = 2
        Public nayVoteValue2 As Integer = 8
        Public nayVoteValue3 As Integer = -1
        Public nayHeaderOrder As Integer

        Public abstainEnabled As Boolean
        Public abstainNamesAs As String
        Public abstainIsUsed As Boolean
        Public abstainIsEligible As Boolean
        Public abstainVoteValue1 As Integer = 3
        Public abstainVoteValue2 As Integer = -1
        Public abstainVoteValue3 As Integer = -1
        Public abstainHeaderOrder As Integer

        Public excusedEnabled As Boolean
        Public excusedNamesAs As String
        Public excusedIsUsed As Boolean
        Public excusedIsEligible As Boolean
        Public excusedVoteValue1 As Integer = 4
        Public excusedVoteValue2 As Integer = 7
        Public excusedVoteValue3 As Integer = 9
        Public excusedHeaderOrder As Integer

        Public absentEnabled As Boolean
        Public absentNamesAs As String
        Public absentIsUsed As Boolean
        Public absentIsEligible As Boolean
        Public absentVoteValue1 As Integer = 5
        Public absentVoteValue2 As Integer = -1
        Public absentVoteValue3 As Integer = -1
        Public absentHeaderOrder As Integer

        Public notVotingEnabled As Boolean
        Public notVotingNamesAs As String
        Public notVotingIsUsed As Boolean
        Public notVotingIsEligible As Boolean
        Public notVotingVoteValue1 As Integer = 0
        Public notVotingVoteValue2 As Integer = 6
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

                If dt.Rows.Count > 0 Then

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
                    VR.motionTitle = dt.Rows(0).Item("Motion")
                    VR.motionDataField = dt.Rows(0).Item("MotionDataField")
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

                Else
                    ' This is the first time the app has been run. We need to set Vote Reporter 
                    ' properties to a default value.

                    VR.link1Name = "Link 1"
                    VR.link1URL = "http://www.roll-call.com"
                    VR.link2Name = "Link 2"
                    VR.link2URL = "http://www.roll-call.com"
                    VR.link3Name = "Link 3"
                    VR.link3URL = "http://www.roll-call.com"
                    VR.siteTitle = "{{Please Configure}}"
                    VR.governmentName = "{{Please Configure}}"
                    VR.legislatureName = "{{Please Configure}}"
                    VR.rcsNbrTitle = "{{Please Configure}}"
                    VR.billNbrTitle = "{{Please Configure}}"
                    VR.motionTitle = "{{Please Configure}}"
                    VR.motionDataField = 1
                    VR.subjectDataField1 = 2
                    VR.subjectDataField2 = 3
                    VR.dateTimeTitle = "{{Please Configure}}"
                    VR.voteTotalTitle = "{{Please Configure}}"
                    VR.resultsTitle = "{{Please Configure}}"
                    VR.outcomeTitle = "{{Please Configure}}"
                    VR.partyTotalsTitle = "{{Please Configure}}"
                    VR.memberTitle = "{{Please Configure}}"
                    VR.districtNameTitle = "{{Please Configure}}"
                    VR.districtNbrTitle = "{{Please Configure}}"
                    VR.presidingOfficer1Name = "{{Please Configure}}"
                    VR.presidingOfficer1Title = "{{Please Configure}}"
                    VR.presidingOfficer2Name = "{{Please Configure}}"
                    VR.presidingOfficer2Title = "{{Please Configure}}"
                    VR.clerkSecretaryName = "{{Please Configure}}"
                    VR.clerkSecretaryTitle = "{{Please Configure}}"
                    VR.showDistrictName = True
                    VR.showDistrictNbr = True
                    VR.showMajorityStats = True
                    VR.showPartyStats = True
                    VR.showVotingStats = True
                    VR.showOptionalAttendance = True
                    VR.showOptionalStats = True
                    VR.includeShortTitle = True
                    VR.showOptionalPartyTotals = True

                    VR.yeaEnabled = True
                    VR.yeaNamesAs = "{{Please Configure}}"
                    VR.yeaIsUsed = True
                    VR.yeaIsEligible = True
                    VR.yeaHeaderOrder = 1

                    VR.nayEnabled = True
                    VR.nayNamesAs = "{{Please Configure}}"
                    VR.nayIsUsed = True
                    VR.nayIsEligible = True
                    VR.nayHeaderOrder = 2

                    VR.abstainEnabled = True
                    VR.abstainNamesAs = "{{Please Configure}}"
                    VR.abstainIsUsed = True
                    VR.abstainIsEligible = True
                    VR.abstainHeaderOrder = 3

                    VR.excusedEnabled = True
                    VR.excusedNamesAs = "{{Please Configure}}"
                    VR.excusedIsUsed = True
                    VR.excusedIsEligible = True
                    VR.excusedHeaderOrder = 4

                    VR.absentEnabled = True
                    VR.absentNamesAs = "{{Please Configure}}"
                    VR.absentIsUsed = True
                    VR.absentIsEligible = True
                    VR.absentHeaderOrder = 5

                    VR.notVotingEnabled = True
                    VR.notVotingNamesAs = "{{Please Configure}}"
                    VR.notVotingIsUsed = True
                    VR.notVotingIsEligible = True
                    VR.notVotingHeaderOrder = 6

                    VRList.Add(VR)
                    Session("clsVoteReporter") = VRList

                End If


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

            If dt.Rows.Count > 0 Then
                'session items have been created.
                VRList.Item(0).link1Name = dt.Rows(0).Item("Link1_Name")
                VRList.Item(0).link1URL = dt.Rows(0).Item("Link1_URL")
                VRList.Item(0).link2Name = dt.Rows(0).Item("Link2_Name")
                VRList.Item(0).link2URL = dt.Rows(0).Item("Link2_URL")
                VRList.Item(0).link3Name = dt.Rows(0).Item("Link3_Name")
                VRList.Item(0).link3URL = dt.Rows(0).Item("Link3_URL")
                VRList.Item(0).siteTitle = dt.Rows(0).Item("Government_Name")
                VRList.Item(0).governmentName = dt.Rows(0).Item("Government_Name")
                VRList.Item(0).legislatureName = dt.Rows(0).Item("Legislature_Name")
                VRList.Item(0).rcsNbrTitle = dt.Rows(0).Item("RSCNumber")
                VRList.Item(0).billNbrTitle = dt.Rows(0).Item("BillNumber")
                VRList.Item(0).motionTitle = dt.Rows(0).Item("Motion")
                VRList.Item(0).motionDataField = dt.Rows(0).Item("MotionDataField")
                VRList.Item(0).subjectDataField1 = dt.Rows(0).Item("SubjectField1")
                VRList.Item(0).subjectDataField2 = dt.Rows(0).Item("SubjectField2")
                VRList.Item(0).dateTimeTitle = dt.Rows(0).Item("DateTime")
                VRList.Item(0).voteTotalTitle = dt.Rows(0).Item("VoteTotals")
                VRList.Item(0).resultsTitle = dt.Rows(0).Item("Results")
                VRList.Item(0).outcomeTitle = dt.Rows(0).Item("Outcome")
                VRList.Item(0).partyTotalsTitle = dt.Rows(0).Item("PartyTotals")
                VRList.Item(0).memberTitle = dt.Rows(0).Item("Member")
                VRList.Item(0).districtNameTitle = dt.Rows(0).Item("DistrictName")
                VRList.Item(0).districtNbrTitle = dt.Rows(0).Item("DistrictNumber")
                VRList.Item(0).presidingOfficer1Name = dt.Rows(0).Item("Presiding_Name_1")
                VRList.Item(0).presidingOfficer1Title = dt.Rows(0).Item("Presiding_Title_1")
                VRList.Item(0).presidingOfficer2Name = dt.Rows(0).Item("Presiding_Name_2")
                VRList.Item(0).presidingOfficer2Title = dt.Rows(0).Item("Presiding_Title_2")
                VRList.Item(0).clerkSecretaryName = dt.Rows(0).Item("Clerk_Secretary_Name")
                VRList.Item(0).clerkSecretaryTitle = dt.Rows(0).Item("Clerk_Secretary_Title")
                VRList.Item(0).showDistrictName = CBool(dt.Rows(0).Item("showDistrictName"))
                VRList.Item(0).showDistrictNbr = CBool(dt.Rows(0).Item("showDistrictNbr"))
                VRList.Item(0).showMajorityStats = CBool(dt.Rows(0).Item("showMajorityStats"))
                VRList.Item(0).showPartyStats = CBool(dt.Rows(0).Item("ShowPartyStats"))
                VRList.Item(0).showVotingStats = CBool(dt.Rows(0).Item("ShowVotingStats"))
                VRList.Item(0).showOptionalAttendance = CBool(dt.Rows(0).Item("ShowOptionalAttendance"))
                VRList.Item(0).showOptionalStats = CBool(dt.Rows(0).Item("ShowOptionalStats"))
                VRList.Item(0).includeShortTitle = CBool(dt.Rows(0).Item("IncludeShortTitle"))
                VRList.Item(0).showOptionalPartyTotals = CBool(dt.Rows(0).Item("ShowOptionalPartyTotals"))


                dt.Clear()

                Dim oParmList2 As List(Of SqlParameter) = New List(Of SqlParameter)
                oParmList2.Add(New SqlParameter("@SessionID", SessionID))
                dt = ReturnDataTable("sp_VRGetVoteMappings", CommandType.StoredProcedure, oParmList2)

                VRList.Item(0).yeaEnabled = CBool(dt.Rows(0).Item("Enabled"))
                VRList.Item(0).yeaNamesAs = dt.Rows(0).Item("Named_As")
                VRList.Item(0).yeaIsUsed = CBool(dt.Rows(0).Item("IsUsed"))
                VRList.Item(0).yeaIsEligible = CBool(dt.Rows(0).Item("isEligible"))
                VRList.Item(0).yeaHeaderOrder = dt.Rows(0).Item("Header_Order")

                VRList.Item(0).nayEnabled = CBool(dt.Rows(1).Item("Enabled"))
                VRList.Item(0).nayNamesAs = dt.Rows(1).Item("Named_As")
                VRList.Item(0).nayIsUsed = CBool(dt.Rows(1).Item("IsUsed"))
                VRList.Item(0).nayIsEligible = CBool(dt.Rows(1).Item("isEligible"))
                VRList.Item(0).nayHeaderOrder = dt.Rows(1).Item("Header_Order")

                VRList.Item(0).abstainEnabled = CBool(dt.Rows(2).Item("Enabled"))
                VRList.Item(0).abstainNamesAs = dt.Rows(2).Item("Named_As")
                VRList.Item(0).abstainIsUsed = CBool(dt.Rows(2).Item("IsUsed"))
                VRList.Item(0).abstainIsEligible = CBool(dt.Rows(2).Item("isEligible"))
                VRList.Item(0).abstainHeaderOrder = dt.Rows(2).Item("Header_Order")

                VRList.Item(0).excusedEnabled = CBool(dt.Rows(3).Item("Enabled"))
                VRList.Item(0).excusedNamesAs = dt.Rows(3).Item("Named_As")
                VRList.Item(0).excusedIsUsed = CBool(dt.Rows(3).Item("IsUsed"))
                VRList.Item(0).excusedIsEligible = CBool(dt.Rows(3).Item("isEligible"))
                VRList.Item(0).excusedHeaderOrder = dt.Rows(3).Item("Header_Order")

                VRList.Item(0).absentEnabled = CBool(dt.Rows(4).Item("Enabled"))
                VRList.Item(0).absentNamesAs = dt.Rows(4).Item("Named_As")
                VRList.Item(0).absentIsUsed = CBool(dt.Rows(4).Item("IsUsed"))
                VRList.Item(0).absentIsEligible = CBool(dt.Rows(4).Item("isEligible"))
                VRList.Item(0).absentHeaderOrder = dt.Rows(4).Item("Header_Order")

                VRList.Item(0).notVotingEnabled = CBool(dt.Rows(5).Item("Enabled"))
                VRList.Item(0).notVotingNamesAs = dt.Rows(5).Item("Named_As")
                VRList.Item(0).notVotingIsUsed = CBool(dt.Rows(5).Item("IsUsed"))
                VRList.Item(0).notVotingIsEligible = CBool(dt.Rows(5).Item("isEligible"))
                VRList.Item(0).notVotingHeaderOrder = dt.Rows(5).Item("Header_Order")



                Session("clsVoteReporter") = VRList
                Return True
            Else
                ' This is the first time the app has been run. We need to set Vote Reporter 
                ' properties to a default value.

                VRList.Item(0).link1Name = "Link 1"
                VRList.Item(0).link1URL = "http://www.roll-call.com"
                VRList.Item(0).link2Name = "Link 2"
                VRList.Item(0).link2URL = "http://www.roll-call.com"
                VRList.Item(0).link3Name = "Link 3"
                VRList.Item(0).link3URL = "http://www.roll-call.com"
                VRList.Item(0).siteTitle = "{{Please Configure}}"
                VRList.Item(0).governmentName = "{{Please Configure}}"
                VRList.Item(0).legislatureName = "{{Please Configure}}"
                VRList.Item(0).rcsNbrTitle = "{{Please Configure}}"
                VRList.Item(0).billNbrTitle = "{{Please Configure}}"
                VRList.Item(0).motionTitle = "{{Please Configure}}"
                VRList.Item(0).motionDataField = 1
                VRList.Item(0).subjectDataField1 = 2
                VRList.Item(0).subjectDataField2 = 3
                VRList.Item(0).dateTimeTitle = "{{Please Configure}}"
                VRList.Item(0).voteTotalTitle = "{{Please Configure}}"
                VRList.Item(0).resultsTitle = "{{Please Configure}}"
                VRList.Item(0).outcomeTitle = "{{Please Configure}}"
                VRList.Item(0).partyTotalsTitle = "{{Please Configure}}"
                VRList.Item(0).memberTitle = "{{Please Configure}}"
                VRList.Item(0).districtNameTitle = "{{Please Configure}}"
                VRList.Item(0).districtNbrTitle = "{{Please Configure}}"
                VRList.Item(0).presidingOfficer1Name = "{{Please Configure}}"
                VRList.Item(0).presidingOfficer1Title = "{{Please Configure}}"
                VRList.Item(0).presidingOfficer2Name = "{{Please Configure}}"
                VRList.Item(0).presidingOfficer2Title = "{{Please Configure}}"
                VRList.Item(0).clerkSecretaryName = "{{Please Configure}}"
                VRList.Item(0).clerkSecretaryTitle = "{{Please Configure}}"
                VRList.Item(0).showDistrictName = True
                VRList.Item(0).showDistrictNbr = True
                VRList.Item(0).showMajorityStats = True
                VRList.Item(0).showPartyStats = True
                VRList.Item(0).showVotingStats = True
                VRList.Item(0).showOptionalAttendance = True
                VRList.Item(0).showOptionalStats = True
                VRList.Item(0).includeShortTitle = True
                VRList.Item(0).showOptionalPartyTotals = True

                VRList.Item(0).yeaEnabled = True
                VRList.Item(0).yeaNamesAs = "{{Please Configure}}"
                VRList.Item(0).yeaIsUsed = True
                VRList.Item(0).yeaIsEligible = True
                VRList.Item(0).yeaHeaderOrder = 1

                VRList.Item(0).nayEnabled = True
                VRList.Item(0).nayNamesAs = "{{Please Configure}}"
                VRList.Item(0).nayIsUsed = True
                VRList.Item(0).nayIsEligible = True
                VRList.Item(0).nayHeaderOrder = 2

                VRList.Item(0).abstainEnabled = True
                VRList.Item(0).abstainNamesAs = "{{Please Configure}}"
                VRList.Item(0).abstainIsUsed = True
                VRList.Item(0).abstainIsEligible = True
                VRList.Item(0).abstainHeaderOrder = 3

                VRList.Item(0).excusedEnabled = True
                VRList.Item(0).excusedNamesAs = "{{Please Configure}}"
                VRList.Item(0).excusedIsUsed = True
                VRList.Item(0).excusedIsEligible = True
                VRList.Item(0).excusedHeaderOrder = 4

                VRList.Item(0).absentEnabled = True
                VRList.Item(0).absentNamesAs = "{{Please Configure}}"
                VRList.Item(0).absentIsUsed = True
                VRList.Item(0).absentIsEligible = True
                VRList.Item(0).absentHeaderOrder = 5

                VRList.Item(0).notVotingEnabled = True
                VRList.Item(0).notVotingNamesAs = "{{Please Configure}}"
                VRList.Item(0).notVotingIsUsed = True
                VRList.Item(0).notVotingIsEligible = True
                VRList.Item(0).notVotingHeaderOrder = 6

                Session("clsVoteReporter") = VRList
                Return True
            End If

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


