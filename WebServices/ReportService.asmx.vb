Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class ReportService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

#Region "Classes"
    Public Class RollCallTranscript
        Public calendarItemID As Integer
        Public billPrefix As String
        Public legislationNbr As Integer
        Public RCSNbr As Integer
        Public createDate As String

        Public sessionDay As Integer
        Public billNbr As String 'this val is concatenated already in sql
        Public voteDate As Date
        Public outcome As String
        Public voteVal As Integer
        Public votingName As String
        Public groupCount As Integer
        Public Motion As String

        Public YEA As String
        Public NAY As String
        Public EXC As String
        Public ABSENT As String
        Public NV As String
    End Class

    Public Class CalendarMotions
        Public Motion As String
    End Class

    Public Class ActiveMembers
        Public MemberId As Integer
        Public FirstName As String
        Public LastName As String
        Public VotingName As String
        Public DistrictName As String
        Public DistrictNumber As Integer
        Public PartyCode As String
    End Class

    Public Class VoteStatisticTypes
        Public TypeID As Integer
        Public Type As String
    End Class

#End Region


#Region "Lists Of Class"
    Shared RollCallTranscriptList As New List(Of RollCallTranscript)() From {}
    Shared MotionsList As New List(Of CalendarMotions)() From {}
    Shared MembersList As New List(Of ActiveMembers)() From {}
    Shared VoteStatisticsList As New List(Of VoteStatisticTypes)() From {}
#End Region

#Region "Load Data"


    <WebMethod(True)> _
    Public Function CheckVoterStatisticsOptional()
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable

        Dim SessionCode As String = Session("SessionCode")

        Using cmd As SqlCommand = con.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SessionID FROM VRSessionDetail WHERE SessionCode = '" & SessionCode & "'"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
        End Using

        Dim SessionID As Integer = Nothing
        SessionID = dt.Rows(0).Item(0)
        dt.Clear()
        dt.Columns.Clear()
        dt.Dispose()
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT ShowOptionalStats FROM VRConfiguration WHERE SessionID = " & SessionID

            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using

            cmd.Connection.Close()
        End Using
        If dt.Rows(0).Item(0) = True Then
            Return True
        Else
            Return False
        End If
    End Function



    <WebMethod(True)> _
    Public Function CheckVoterAttendanceOptional()
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable

        Dim SessionCode As String = Session("SessionCode")

        Using cmd As SqlCommand = con.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SessionID FROM VRSessionDetail WHERE SessionCode = '" & SessionCode & "'"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
        End Using

        Dim SessionID As Integer = Nothing
        SessionID = dt.Rows(0).Item(0)
        dt.Clear()
        dt.Columns.Clear()
        dt.Dispose()
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT ShowOptionalAttendance FROM VRConfiguration WHERE SessionID = " & SessionID

            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using

            cmd.Connection.Close()
        End Using

        If dt.Rows(0).Item(0) = True Then
            Return True
        Else
            Return False
        End If

    End Function




    <WebMethod()> _
    Public Function LoadStatisticTypes()

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand

        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        With cmd
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRGetStatisticTypes"
            Using da
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            .Connection.Close()
        End With

        VoteStatisticsList.Clear()
        For Each Item As DataRow In dt.Rows()
            Dim VT As New VoteStatisticTypes()
            VT.TypeID = Item("ID")
            VT.Type = Item("Statistic")
            VoteStatisticsList.Add(VT)
        Next

        Return VoteStatisticsList

    End Function





    <WebMethod(True)> _
    Public Function LoadMembers()


        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet

  
        With cmd
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRGetActiveMembers"
            .Parameters.AddWithValue("@SessionCode", VoteReporter.Item(0).currentSessionCode)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "Members")
            End Using
        End With

        MembersList.Clear()
        For Each Item As DataRow In ds.Tables(0).Rows()
            Dim M As New ActiveMembers()
            M.MemberId = Item("MemberId")
            M.VotingName = CStr(Item("VotingName"))
            M.DistrictName = Item("DistrictName")
            M.DistrictNumber = CStr(Item("DistrictNbr"))
            M.PartyCode = Item("PartyCode")
            MembersList.Add(M)
        Next

        Return MembersList

    End Function

    <WebMethod(True)> _
    Public Function LoadCalendarDates()

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        Dim cmd As New SqlCommand
        With cmd
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRGetVoteDates"
            .Parameters.AddWithValue("@sessionCode", VoteReporter.Item(0).currentSessionCode)
        End With
        ds = New DataSet("RCTranscriptData")
        da.SelectCommand = cmd
        da.Fill(ds, "RCTranscriptData")
        RollCallTranscriptList.Clear()
        For Each Item As DataRow In ds.Tables(0).Rows()
            Dim RCT As New RollCallTranscript()
            RCT.createDate = CStr(Item("VoteDates"))
            RollCallTranscriptList.Add(RCT)
        Next
        Return RollCallTranscriptList
    End Function


    <WebMethod(True)> _
    Public Function LoadCalendarItems()

        ' setting use subject search session to false in case a report was loaded 
        ' previously using search text. We want to clear this so the same bills don't overwrite the new query from the user.
        Session("UseSubjectSearch") = False

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        'Get Vote Database Name 
        Using cmdd As New SqlCommand
            cmdd.Connection = con
            cmdd.Connection.Open()
            cmdd.CommandType = CommandType.StoredProcedure
            cmdd.CommandText = "sp_VRGetDatabaseName"
            Using da
                da.SelectCommand = cmdd
                da.Fill(dt)
            End Using
            cmdd.Connection.Close()
        End Using

        'Dim dt2 As New DataTable
        'Using c As New SqlCommand
        '    c.Connection = con
        '    c.Connection.Open()
        '    c.CommandType = CommandType.StoredProcedure
        '    c.CommandText = "sp_VRGetMotionField"
        '    c.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).motionDataField)

        '    Using da
        '        da.SelectCommand = c
        '        da.Fill(dt2)
        '    End Using
        '    c.Connection.Close()
        'End Using

        Dim MotionField As String = VoteReporter.Item(0).motionDataField

     
        Dim cmd As New SqlCommand
        With cmd
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRGetVoteResults"

            .Parameters.AddWithValue("@motionfield", MotionField)
            .Parameters.AddWithValue("@sessionCode", VoteReporter.Item(0).currentSessionCode)
        End With

        ds = New DataSet("RCTranscriptData")
        da.SelectCommand = cmd
        da.Fill(ds, "RCTranscriptData")

        'fill master table

        Dim MasterTable As New DataTable
        da.Fill(MasterTable)
      
        RollCallTranscriptList.Clear()

        For Each Item As DataRow In ds.Tables(0).Rows()
            Dim RCT As New RollCallTranscript()
            RCT.calendarItemID = Item("CalendarItemId")
            RCT.billPrefix = Item("BillPrefix")
            RCT.legislationNbr = CStr(Item("LegislationNbr"))
            RCT.createDate = CStr(Item("CreatedDate"))
            RCT.Motion = Item("Motion")
            ' use link for filtering 
            If RollCallTranscriptList.Where(Function(t) t.billPrefix = RCT.billPrefix And t.legislationNbr = RCT.legislationNbr).Count = 0 Then
                RollCallTranscriptList.Add(RCT)
            End If
        Next

        Return RollCallTranscriptList
    End Function

    <WebMethod()> _
    Public Function LoadDatesBySession()

        Dim SessionCode As String = Session("SessionCode")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        With cmd
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRGetVoteDates"
            .Parameters.AddWithValue("@sessionCode", SessionCode)
        End With

        ds = New DataSet("RCTranscriptData")
        da.SelectCommand = cmd
        da.Fill(ds, "RCTranscriptData")

        RollCallTranscriptList.Clear()

        For Each Item As DataRow In ds.Tables(0).Rows()
            Dim RCT As New RollCallTranscript()
            RCT.createDate = CStr(Item("VoteDates"))
            RollCallTranscriptList.Add(RCT)
        Next

        Return RollCallTranscriptList


    End Function


    <WebMethod(True)> _
    Public Function LoadMotions()

        Dim VoteCon As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand


        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Using cmd
            cmd.Connection = VoteCon
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetAllMotions"
            cmd.Parameters.AddWithValue("@Session", VoteReporter.Item(0).currentSessionCode)
        End Using

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        MotionsList.Clear()

        For Each Motion As DataRow In dt.Rows()
            Dim m As New CalendarMotions
            m.Motion = Motion(0)
            MotionsList.Add(m)
        Next

        Return MotionsList

    End Function


    <WebMethod()> _
    Public Function GetSessionID(ByVal SessionCode As String)
        Dim SessionID As Integer = Nothing
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable
        Using cmd As SqlCommand = con.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SessionID FROM VRSessionDetail WHERE SessionCode = '" & SessionCode & "'"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
        End Using
        SessionID = dt.Rows(0).Item(0)
        Return SessionID
    End Function


#End Region

#Region "Set Session Data"


    <WebMethod(EnableSession:=True)> _
    Public Function SetTranscriptItems(ByVal Arr As String, ByVal DateFilter As String, ByVal Motion As String) As String
        Dim result As String = CStr(Arr)
        Session("CalendarItems") = result
        Session("VoteDate") = DateFilter
        Session("rtMotionFilter") = Motion
        Return "success"
    End Function

    'set voter attendance data 
    <WebMethod(True)> _
    Public Function SetAttendanceData(ByVal Members As String, ByVal StartDate As String, ByVal EndDate As String)

        Session("AttendanceMembers") = Members
        Session("atn_StartDate") = StartDate
        Session("atn_EndDate") = EndDate

        Return "success"

    End Function



    'set session data for Voter Stats Report
    <WebMethod(EnableSession:=True)> _
    Public Function SetVoterStatsData(ByVal IsAllBills As Integer, ByVal Members As String, ByVal Bills As String, ByVal StartDate As String, ByVal EndDate As String)

        'Session("vsMotionFilter") = MotionFilter
        Session("vstatMember") = Members
        Session("vstatBills") = Bills
        Session("vstatStartDate") = StartDate
        Session("vstatEndDate") = EndDate
        Session("vstatIsAll") = IsAllBills

        Return "success"
    End Function

    <WebMethod()> _
    Public Function GetSelectedBills(ByVal SelectedBillList As String)
        Dim dt As New DataTable



        Return dt
    End Function

    'set voter details data 
    <WebMethod(EnableSession:=True)> _
    Public Function SetVoterHistoryData(ByVal Members As String, ByVal Bills As String, ByVal useYeas As Boolean _
                                      , ByVal useNays As Boolean, ByVal useAbstain As Boolean, ByVal useExcused As Boolean _
                                      , ByVal useAbsent As Boolean, ByVal useNV As Boolean, ByVal BeginDate As String, ByVal EndDate As String, ByVal SortBy As String, ByVal IsAll As Integer, ByVal ShowShort As Boolean, ByVal ShowPartyTotals As Boolean, ByVal MotionFilter As String)


        Session("VDIsAllBills") = IsAll



        Session("BeginDate") = BeginDate
        Session("EndDate") = EndDate
        Session("VDSort") = SortBy
        Session("vstatMember") = Members
        Session("vhYES") = False
        Session("vhNAY") = False
        Session("vhABSTAIN") = False
        Session("vhEXC") = False
        Session("vhABSENT") = False
        Session("vhNV") = False
        Session("vhShowShortTitle") = False
        Session("vhShowPartyTotals") = False
        Session("vhMotionFilter") = MotionFilter
        Session("vhShowShort") = ShowShort

        Session("vstatBills") = Bills
        If useYeas = True Then Session("vhYES") = True
        If useNays = True Then Session("vhNAY") = True
        If useAbstain = True Then Session("vhABSTAIN") = True
        If useExcused = True Then Session("vhEXC") = True
        If useAbsent = True Then Session("vhABSENT") = True
        If useNV = True Then Session("vhNV") = True
        If ShowShort = True Then Session("vhShowShortTitle") = True
        If ShowPartyTotals = True Then Session("vhShowPartyTotals") = True



        Return ""

    End Function






    ' sets calendar items that will be used in html doc load.
    <WebMethod(EnableSession:=True)> _
    Public Function SetVoterComparisonDetails(ByVal BillArr As String, ByVal IsAllBills As Boolean, ByVal Voter1ID As Integer, ByVal Voter2ID As Integer, ByVal Voter3ID As Integer, ByVal Voter4ID As Integer, ByVal Voter5ID As Integer, ByVal Voter6ID As Integer, ByVal Voter7ID As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal SortBy As String, ByVal MotionFilter As String) As String
        Dim result As String = CStr(BillArr)
        Session("IsAllBills") = IsAllBills
        Session("CalendarItems") = result

        Session("VoterComp_MotionFilter") = MotionFilter
        Session("Vcomp_SortBy") = SortBy

        Session("Voter1ID") = Voter1ID
        Session("Voter2ID") = Voter2ID
        Session("Voter3ID") = Voter3ID
        Session("Voter4ID") = Voter4ID
        Session("Voter5ID") = Voter5ID
        Session("Voter6ID") = Voter6ID
        Session("Voter7ID") = Voter7ID

        Session("VoteComp_StartDate") = StartDate
        Session("VoteComp_EndDate") = EndDate

        Return "success"
    End Function

    <WebMethod(True)> _
    Public Function SetCalendarItem(ByVal CalendarItem As Integer)
        Session("CalendarItemID") = CalendarItem
        Return ""
    End Function

    <WebMethod(True)> _
    Public Function SetMember(ByVal MemberID As Integer)
        Session("MemberID") = MemberID
        Return ""
    End Function

    <WebMethod(True)> _
    Public Function SetRollCallSummaryDetails(ByVal Bills As String, ByVal StartDate As String, ByVal EndDate As String, ByVal SortBy As String, ByVal IsAll As Integer, ByVal ckYea As Boolean, ByVal ckNay As Boolean, ByVal ckAbstain As Boolean, ByVal ckExcused As Boolean, ByVal ckAbsent As Boolean, ByVal ckNotVoting As Boolean, ByVal ShowShort As Boolean, ByVal ShowPartyTotals As Boolean, ByVal MotionFilter As String)


        Session("RCHYea") = False
        Session("RCHNay") = False
        Session("RCHAbstain") = False
        Session("RCHExcused") = False
        Session("RCHAbsent") = False
        Session("RCHNotVoting") = False
        Session("RCHShowShortTitle") = False
        Session("ShowPartyTotals") = False

        Session("RCH_MotionFilter") = MotionFilter

        If ckYea = True Then Session("RCHYea") = True
        If ckNay = True Then Session("RCHNay") = True
        If ckAbstain = True Then Session("RCHAbstain") = True
        If ckExcused = True Then Session("RCHExcused") = True
        If ckAbsent = True Then Session("RCHAbsent") = True
        If ckNotVoting = True Then Session("RCHNotVoting") = True
        If ShowShort = True Then Session("RCHShowShortTitle") = True
        If ShowPartyTotals = True Then Session("ShowPartyTotals") = True

        Session("RollCallSummary_Bills") = Bills
        Session("RollCallSummary_StartDate") = StartDate
        Session("RollCallSummary_EndDate") = EndDate
        Session("RCSortBy") = SortBy
        Session("RCHistISALL") = IsAll

        Return ""

    End Function




    <WebMethod(True)> _
    Public Function ResetSearchSession()

        Session("UseSubjectSearch") = False
        
        Return ""

    End Function


#End Region

#Region "Old HTML/JS Getters"
    ' sets calendar items that will be used in html doc load.
    <WebMethod(EnableSession:=True)> _
    Public Function SetCalendarItems(ByVal Arr As String) As String
        Dim result As String = CStr(Arr)

        Session("CalendarItems") = result
        Return "success"
    End Function

    ' gets calendar items used for html doc creation
    <WebMethod(EnableSession:=True)> _
    Public Function GetCalendarItems() As String
        Dim result As String = Session("CalendarItems")
        Return result
    End Function

    ' gets calendar items used for html doc creation
    <WebMethod(EnableSession:=True)> _
    Public Function GetCalendarDetails()

        Dim sqlcmd As String = String.Empty

        Dim Items As String = Session("CalendarItems")
        Dim Separator() As String = {","}
        Dim SelectedItems() As String = Items.Split(Separator, StringSplitOptions.RemoveEmptyEntries)


        If Session("AllItems") = True Then
            sqlcmd = "SELECT * FROM vueVoteResults"
        Else
            'For each calendar item selected, build sql query
            Dim sb As New StringBuilder
            Dim Length As Integer = SelectedItems.Length()

            For Each item In SelectedItems

                If item = SelectedItems(Length - 1) Then
                    sb.Append("CalendarItemID = " & item & " ORDER BY CalendarItemId;")
                Else
                    sb.Append("CalendarItemID = " & item & " OR ")
                End If

            Next

            sqlcmd = "SELECT * FROM vueVoteResults WHERE " & sb.ToString()

        End If

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("connex").ConnectionString)
        Dim da As New SqlDataAdapter(sqlcmd, con)
        Dim ds As New DataSet("VoteResults")
        da.Fill(ds, "VoteResults")


        RollCallTranscriptList.Clear()
        'for each calendar item we need to go through all rows in our dataset, and if the cal id matches then
        'grab all the data we need. Once it goes through all the rows, then it moves to next calendar item. We append
        'data to RollCallTranscriptList. 

        Dim CalItemID As Integer = Nothing
        Dim CreatedDate As Date = Nothing
        Dim RCS As Integer = Nothing
        Dim SesDay As Integer = Nothing
        Dim Bill As String = Nothing
        Dim VoteDate As Date = Nothing
        Dim Outcome As String = Nothing
        Dim VoteValue As Integer = Nothing
        Dim GroupCt As Integer = Nothing
        Dim Motion As String = Nothing
        Dim VotingName As String = Nothing

        Dim sbYea As New StringBuilder
        Dim sbNay As New StringBuilder
        Dim sbNV As New StringBuilder
        Dim sbAbsent As New StringBuilder

        For Each id In SelectedItems
            Dim RCT As New RollCallTranscript()
            For Each r As DataRow In ds.Tables(0).Rows()

                If r("CalendarItemId") = id Then
                    'grab all the data that belongs to that id

                    CalItemID = r("CalendarItemId")
                    CreatedDate = CStr(r("CreatedDate"))
                    RCS = r("RCSNbr")
                    SesDay = r("SessionDay")
                    Bill = r("BillNumber")
                    VoteDate = CStr(r("VoteDate"))
                    Outcome = r("PASS")
                    VoteValue = r("VoteValue")
                    GroupCt = r("GroupCount")
                    Motion = r("Motion1")
                    VotingName = r("VotingName")

                    Select Case VoteValue

                        Case 1 'YEA 
                            sbYea.Append(VotingName & " ")
                        Case 2 'NAY
                            sbNay.Append(VotingName & " ")
                        Case 0
                            sbNV.Append(VotingName & " ")
                        Case 5
                            sbAbsent.Append(VotingName & " ")

                    End Select



                End If

            Next
            RCT.calendarItemID = CalItemID
            RCT.createDate = CreatedDate
            RCT.RCSNbr = RCS
            RCT.sessionDay = SesDay
            RCT.billNbr = Bill
            RCT.voteDate = VoteDate
            RCT.outcome = Outcome
            RCT.voteVal = VoteValue
            RCT.groupCount = GroupCt
            RCT.Motion = Motion
            RCT.YEA = sbYea.ToString()
            RCT.NAY = sbNay.ToString()
            RCT.NV = sbNV.ToString()
            RCT.ABSENT = sbAbsent.ToString()
            sbYea.Clear()
            sbNay.Clear()
            sbNV.Clear()
            sbAbsent.Clear()

            RollCallTranscriptList.Add(RCT)

        Next



        Return RollCallTranscriptList
    End Function

#End Region







End Class