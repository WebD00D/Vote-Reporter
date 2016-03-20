Imports System
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Public Class RV_VoterStatisticsNEW
    Inherits System.Web.UI.Page
    Public _ShowMajorityStats As Boolean
    Public _ShowPartyStats As Boolean
    Public _ShowVoteStats As Boolean
    Public _ReportColumns As Integer
    Public _sSubjects As String
    Public _sBills As String
    Public _YeaName As String
    Public _NayName As String
    Public _AbstainName As String
    Public _ExcName As String
    Public _AbsentName As String
    Public _NVName As String
    Public _UseYea As Integer
    Public _UseNay As Integer
    Public _UseAbstain As Integer
    Public _UseExcused As Integer
    Public _UseAbsent As Integer
    Public _UseNV As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Members As String = Session("vstatMember")
        Dim Bills As String = Session("vstatBills")
        Dim SessionCode As String = Session("SessionCode")

        If Session("UseSubjectSearch") = True Then
            Bills = Session("SearchedBillIDs")
            _sSubjects = Session("SearchText")
        End If

        _ReportColumns = 0



        Dim StartDate As String = Session("vstatStartDate")
        Dim EndDate As String = Session("vstatEndDate")

        Dim strStartDate As String = String.Empty
        Dim strEndDate As String = String.Empty

        If Not StartDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(StartDate)) = True Then
                StartDate = CDate(Session("vstatStartDate"))
                strStartDate = CStr(StartDate)
            Else
                strStartDate = "01/01/1900"
            End If
        Else
            strStartDate = "01/01/1900"
        End If
        Dim Today As String = CStr(Date.Today)
        If Not EndDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(EndDate)) = True Then
                EndDate = CDate(Session("vstatEndDate"))
                strEndDate = CStr(EndDate + " 23:59:59")
            Else
                strEndDate = Today + " 23:59:59"
            End If
        Else
            strEndDate = Today + " 23:59:59"
        End If

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        'Get Vote Database Name 
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetDatabaseName"
            Using da
                da.SelectCommand = cmd
                da.Fill(dt)

            End Using
            cmd.Connection.Close()
        End Using

        Dim VoteDB As String = dt.Rows(1).Item(0)


        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 5)
            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using
            cmd.Connection.Close()
        End Using


        Dim VRList As New List(Of Engine.clsVoteReporter)
        VRList = Session("clsVoteReporter")


        ' Get Report Configuration Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetReportConfigParams"

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using

            cmd.Connection.Close()
        End Using

        Dim MotionField As String = ds.Tables(1).Rows(0).Item(28)

        _ShowMajorityStats = ds.Tables(1).Rows(0).Item(32)
        _ShowPartyStats = ds.Tables(1).Rows(0).Item(33)
        _ShowVoteStats = ds.Tables(1).Rows(0).Item(34)

        If _ShowMajorityStats = True Then
            _ReportColumns += 1
        End If
        If _ShowPartyStats = True Then
            _ReportColumns += 1
        End If
        If _ShowVoteStats = True Then
            _ReportColumns += 1
        End If




        'Dim DistrictNameHeader As String = ds.Tables(0).Rows(0).Item(18)
        'Dim DistrictNbrHeader As String = ds.Tables(0).Rows(0).Item(19)
        'Dim UseDistrictNbr As Boolean = ds.Tables(0).Rows(0).Item(30)
        'Dim UseDistrictName As Boolean = ds.Tables(0).Rows(0).Item(29)

        ' Get Vote Mapping Settings
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetVoteMappings"

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetVoteMappings")
            End Using
            cmd.Connection.Close()
        End Using


        ' Get Vote Header Display Order ,Whether or not it is used on reports, and all values. Pass 
        ' In Values to RollCallDetails sp and create a dummy column and case if vote value equals 
        ' the passed in value, then set the dummy order = the order passed in. 

        '1. Get Order
        Dim YeaOrder As Integer = ds.Tables(2).Rows(0).Item(9)
        Dim NayOrder As Integer = ds.Tables(2).Rows(1).Item(9)
        Dim AbstainOrder As Integer = ds.Tables(2).Rows(2).Item(9)
        Dim ExcusedOrder As Integer = ds.Tables(2).Rows(3).Item(9)
        Dim AbsentOrder As Integer = ds.Tables(2).Rows(4).Item(9)
        Dim NotVotingOrder As Integer = ds.Tables(2).Rows(5).Item(9)

        '2. Set what Vote Values we can use.

        _UseYea = 1 'always use
        _UseNay = 1 'always use

        _UseAbstain = 0
        _UseExcused = 0
        _UseAbsent = 0
        _UseNV = 0

        If ds.Tables(2).Rows(2).Item(4) = True Then _UseAbstain = 1

        If ds.Tables(2).Rows(3).Item(4) = True Then _UseExcused = 1

        If ds.Tables(2).Rows(4).Item(4) = True Then _UseAbsent = 1

        If ds.Tables(2).Rows(5).Item(4) = True Then _UseNV = 1

        ' 3. Get Eligible

        Dim elgYea As Integer = 1 'always use
        Dim elgNay As Integer = 1 'always use
        Dim elgAbstain As Integer = 0
        Dim elgExcused As Integer = 0
        Dim elgAbsent As Integer = 0
        Dim elgNotVoting As Integer = 0


        If ds.Tables(2).Rows(2).Item(5) = True Then elgAbstain = 1
        If ds.Tables(2).Rows(3).Item(5) = True Then elgExcused = 1
        If ds.Tables(2).Rows(4).Item(5) = True Then elgAbsent = 1
        If ds.Tables(2).Rows(5).Item(5) = True Then elgNotVoting = 1


        _YeaName = ds.Tables(2).Rows(0).Item(3)
        _NayName = ds.Tables(2).Rows(1).Item(3)
        _AbstainName = ds.Tables(2).Rows(2).Item(3)
        _ExcName = ds.Tables(2).Rows(3).Item(3)
        _AbsentName = ds.Tables(2).Rows(4).Item(3)
        _NVName = ds.Tables(2).Rows(5).Item(3)


        'Get Vote Headers
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetVoteHeaderOrders"
            cmd.Parameters.AddWithValue("@oYea", YeaOrder)
            cmd.Parameters.AddWithValue("@oNay", NayOrder)
            cmd.Parameters.AddWithValue("@oAbstain", AbstainOrder)
            cmd.Parameters.AddWithValue("@oExcused", ExcusedOrder)
            cmd.Parameters.AddWithValue("@oAbsent", AbsentOrder)
            cmd.Parameters.AddWithValue("@oNotVoting", NotVotingOrder)

            cmd.Parameters.AddWithValue("@useYea", CByte(_UseYea))
            cmd.Parameters.AddWithValue("@useNay", CByte(_UseNay))
            cmd.Parameters.AddWithValue("@useAbstain", CByte(_UseAbstain))
            cmd.Parameters.AddWithValue("@useExcused", CByte(_UseExcused))
            cmd.Parameters.AddWithValue("@useAbsent", CByte(_UseAbsent))
            cmd.Parameters.AddWithValue("@useNotVoting", CByte(_UseNV))

            cmd.Parameters.AddWithValue("@hYea", _YeaName)
            cmd.Parameters.AddWithValue("@hNay", _NayName)
            cmd.Parameters.AddWithValue("@hAbstain", _AbstainName)
            cmd.Parameters.AddWithValue("@hExcused", _ExcName)
            cmd.Parameters.AddWithValue("@hAbsent", _AbsentName)
            cmd.Parameters.AddWithValue("@hNotVoting", _NVName)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetVoteHeaderOrders")
            End Using
            cmd.Connection.Close()
        End Using


        ' Get Report Data
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_VoterStatisticsNEW"

            With cmd.Parameters

                .AddWithValue("@BillList", Bills)
                .AddWithValue("@MemberList", Members)
                .AddWithValue("@StartDate", strStartDate)
                .AddWithValue("@EndDate", strEndDate)


                .AddWithValue("@Yea_eligible", elgYea)
                .AddWithValue("@Nay_eligible", elgNay)
                .AddWithValue("@Abstain_eligible", elgAbstain)
                .AddWithValue("@Excused_eligible", elgExcused)
                .AddWithValue("@Absent_eligible", elgAbsent)
                .AddWithValue("@NotVoting_eligible", elgNotVoting)

                .AddWithValue("@uYea", _UseYea)
                .AddWithValue("@oYea", YeaOrder)
                .AddWithValue("@uNay", _UseNay)
                .AddWithValue("@oNay", NayOrder)
                .AddWithValue("@uAbstain", _UseAbstain)
                .AddWithValue("@oAbstain", AbstainOrder)
                .AddWithValue("@uExc", _UseExcused)
                .AddWithValue("@oExc", ExcusedOrder)
                .AddWithValue("@uAbsent", _UseAbsent)
                .AddWithValue("@oAbsent", AbsentOrder)
                .AddWithValue("@uNV", _UseNV)
                .AddWithValue("@oNV", NotVotingOrder)

            End With

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_Report_VoterStatisticsNEW")

                If ds.Tables("sp_Report_VoterStatisticsNEW").Rows.Count = 0 Then
                    Context.Response.Redirect("NoRecordsFound.html", True)
                    Dim drEmptyRow As DataRow = ds.Tables("sp_Report_VoterStatisticsNEW").NewRow
                    drEmptyRow.Item("VotingName") = "NO DATA TO SHOW"
                    ds.Tables("sp_Report_VoterStatisticsNEW").Rows.InsertAt(drEmptyRow, 0)
                    ds.Tables("sp_Report_VoterStatisticsNEW").AcceptChanges()
                End If
            End Using

            cmd.Connection.Close()
        End Using


        'Get Bill List 
        Dim newDT As New DataTable
        Dim newcon As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim newcmd As New SqlCommand
        With newcmd
            .CommandType = CommandType.StoredProcedure
            .Connection = newcon
            .Connection.Open()
            .CommandText = "sp_VRGetCalendarItemListDetails"
            .Parameters.AddWithValue("@BillList", Bills)

            Dim newDA As New SqlDataAdapter

            Using newDA
                newDA.SelectCommand = newcmd
                newDA.Fill(newDT)
            End Using
        End With

        Dim sBillList As New StringBuilder
        Dim FindDuplicates As New Hashtable
        Dim idxCounter As Integer = 0
        For Each row As DataRow In newDT.Rows
            If FindDuplicates.ContainsValue(row("BillNumber")) = False Then
                FindDuplicates.Add(idxCounter, row("BillNumber"))
                sBillList.Append(row("BillNumber") & " ")
            End If
            idxCounter += 1
        Next
        _sBills = sBillList.ToString()

        VoterStatsViewNEW.Report = CreateReport(ds, _ReportColumns)
        VoterStatsViewNEW.DataBind()

    End Sub

    Private Function CreateReport(ByVal ds As DataSet, ByVal ColCount As Integer) As VoterStatsNEW
        Dim report As New VoterStatsNEW()
        report.DataSource = ds

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        report.lblSession.Text = VoteReporter.Item(0).currentSessionLegislature
        report.lblPrintedOn.Text = Date.Now.ToString()

        If Session("vstatStartDate").ToString = String.Empty Then
            Dim StartDate As Date = CDate(Session("SessionStartedOn"))
            report.lblStartDate.Text = StartDate.ToString("d")
        Else
            Dim StartDate As Date = CDate(Session("vstatStartDate"))
            report.lblStartDate.Text = StartDate.ToString("d")
        End If

        If Session("vstatEndDate").ToString = String.Empty Then

            Dim EndDate As Date = CDate(Session("SessionEndedOn"))
            report.lblEndDate.Text = EndDate.ToString("d")
        Else
            Dim EndDate As Date = CDate(Session("vstatEndDate"))
            report.lblEndDate.Text = EndDate.ToString("d")
        End If




        If Not _sSubjects = String.Empty Then
            report.lblSubjects.Text = _sSubjects
        Else
            report.lblSubjects.Text = "ALL"
        End If

        If Session("vstatIsAll") = 1 Then
            report.lblBills.Text = "ALL"
        Else
            report.lblBills.Text = _sBills
        End If



        Dim votesUsed As New StringBuilder

        If _UseYea = 1 Then
            votesUsed.Append(_YeaName & " ")
        End If
        If _UseNay = 1 Then
            votesUsed.Append(_NayName & " ")
        End If
        If _UseAbstain = 1 Then
            votesUsed.Append(_AbstainName & " ")
        End If
        If _UseExcused = 1 Then
            votesUsed.Append(_ExcName & " ")
        End If
        If _UseAbsent = 1 Then
            votesUsed.Append(_AbsentName & " ")
        End If
        If _UseNV = 1 Then
            votesUsed.Append(_NVName & " ")
        End If

        Dim strVotesUsed = votesUsed.ToString()
        report.lblVoteTypes.Text = strVotesUsed




        If ColCount > 1 Then
            report.Landscape = True
        Else
            report.Landscape = False
        End If

        Dim xMajority1 As XRTableCell = report.cMajority1
        Dim xMajority2 As XRTableCell = report.cMajority2
        Dim xMajority3 As XRTableCell = report.cMajority3
        Dim xMajority4 As XRTableCell = report.cMajority4
        Dim xParty1 As XRTableCell = report.cParty1
        Dim xParty2 As XRTableCell = report.cParty2
        Dim xParty3 As XRTableCell = report.cParty3
        Dim xParty4 As XRTableCell = report.cParty4
        Dim xVote1 As XRTableCell = report.cOrder1
        Dim xVote2 As XRTableCell = report.cOrder2
        Dim xVote3 As XRTableCell = report.cOrder3
        Dim xVote4 As XRTableCell = report.cOrder4
        Dim xVote5 As XRTableCell = report.cOrder5
        Dim xVote6 As XRTableCell = report.cOrder6



        If _ShowMajorityStats = False Then

            report.XrTable1.BeginInit()
            report.XrTable1.DeleteColumn(xMajority1)
            report.XrTable1.DeleteColumn(xMajority2)
            report.XrTable1.DeleteColumn(xMajority3)
            report.XrTable1.DeleteColumn(xMajority4)
            report.XrTable1.AdjustSize()
            report.XrTable1.EndInit()

            report.XrTable3.BeginInit()
            report.XrTable3.DeleteColumn(report.hMajority1)
            report.XrTable3.DeleteColumn(report.hMajority2)
            report.XrTable3.DeleteColumn(report.hMajority3)
            report.XrTable3.DeleteColumn(report.hMajority4)
            report.XrTable3.AdjustSize()
            report.XrTable3.EndInit()

        End If


        If _ShowPartyStats = False Then

            report.XrTable1.BeginInit()
            report.XrTable1.DeleteColumn(xParty1)
            report.XrTable1.DeleteColumn(xParty2)
            report.XrTable1.DeleteColumn(xParty3)
            report.XrTable1.DeleteColumn(xParty4)
            report.XrTable1.AdjustSize()
            report.XrTable1.EndInit()

            report.XrTable3.BeginInit()
            report.XrTable3.DeleteColumn(report.hParty1)
            report.XrTable3.DeleteColumn(report.hParty2)
            report.XrTable3.DeleteColumn(report.hParty3)
            report.XrTable3.DeleteColumn(report.hParty4)
            report.XrTable3.AdjustSize()
            report.XrTable3.EndInit()

        End If


        If _ShowVoteStats = False Then

            report.XrTable1.BeginInit()
            report.XrTable1.DeleteColumn(xVote1)
            report.XrTable1.DeleteColumn(xVote2)
            report.XrTable1.DeleteColumn(xVote3)
            report.XrTable1.DeleteColumn(xVote4)
            report.XrTable1.DeleteColumn(xVote5)
            report.XrTable1.DeleteColumn(xVote6)
            report.XrTable1.AdjustSize()
            report.XrTable1.EndInit()

            report.XrTable3.BeginInit()
            report.XrTable3.DeleteColumn(report.hOrder1)
            report.XrTable3.DeleteColumn(report.hOrder2)
            report.XrTable3.DeleteColumn(report.hOrder3)
            report.XrTable3.DeleteColumn(report.hOrder4)
            report.XrTable3.DeleteColumn(report.hOrder5)
            report.XrTable3.DeleteColumn(report.hOrder6)
            report.XrTable3.AdjustSize()
            report.XrTable3.EndInit()


        End If

        report.CreateDocument()
        Return report
    End Function

End Class