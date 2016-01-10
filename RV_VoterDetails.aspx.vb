Imports System
Imports System.Text
Imports System.Data.SqlClient
Public Class RV_VoterDetails

    Inherits System.Web.UI.Page

    Public UseYea As Boolean = True 'always use
    Public UseNay As Boolean = True 'always use

    Public UseAbstain As Boolean = False
    Public UseExcused As Boolean = False
    Public UseAbsent As Boolean = False
    Public UseNotVoting As Boolean = False

    Public nYea As String
    Public nNay As String
    Public nAbstain As String
    Public nExc As String
    Public nAbsent As String
    Public nNV As String

    Public _pBeginDate As String
    Public _pEndDate As String
    Public _sSort As String
    Public _sVoteTypes As String
    Public _sSubjects As String
    Public _sBills As String
    Public _sPrintedOn As String




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString())
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        Dim Members As String = Session("vstatMember")
        Dim Bills As String = Session("vstatBills")

        If Session("UseSubjectSearch") = True Then
            Session("KeepUsingSubject") = Session("SearchedBillIDs")
            Bills = Session("SearchedBillIDs")
            _sSubjects = Session("SearchText")
        End If

        ' Get Report Configuration Details
        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetReportConfigParams"
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using

            cmd.Connection.Close()
            cmd.Parameters.Clear()

        End Using

        Dim DistrictNameHeader As String = ds.Tables(0).Rows(0).Item(18)
        Dim DistrictNbrHeader As String = ds.Tables(0).Rows(0).Item(19)



        Dim MotionData As String = ds.Tables(0).Rows(0).Item(28)
        Dim SubField1 As Integer = ds.Tables(0).Rows(0).Item(35)
        Dim SubField2 As Integer = ds.Tables(0).Rows(0).Item(36)


        ' Get Vote Mapping Settings
        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetVoteMappings"
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetVoteMappings")
            End Using
            cmd.Connection.Close()
            cmd.Parameters.Clear()
        End Using

        Dim UseDistrictName As Boolean = ds.Tables(0).Rows(0).Item(29)

        ' Get Order
        Dim YeaOrder As Integer = ds.Tables(1).Rows(0).Item(9)
        Dim NayOrder As Integer = ds.Tables(1).Rows(1).Item(9)
        Dim AbstainOrder As Integer = ds.Tables(1).Rows(2).Item(9)
        Dim ExcusedOrder As Integer = ds.Tables(1).Rows(3).Item(9)
        Dim AbsentOrder As Integer = ds.Tables(1).Rows(4).Item(9)
        Dim NotVotingOrder As Integer = ds.Tables(1).Rows(5).Item(9)



        nYea = ds.Tables(1).Rows(0).Item(3)
        nNay = ds.Tables(1).Rows(1).Item(3)
        nAbstain = ds.Tables(1).Rows(2).Item(3)
        nExc = ds.Tables(1).Rows(3).Item(3)
        nAbsent = ds.Tables(1).Rows(4).Item(3)
        nNV = ds.Tables(1).Rows(5).Item(3)

        ' Set what Vote Values we can use.

        If ds.Tables(1).Rows(2).Item(4) = True Then UseAbstain = True

        If ds.Tables(1).Rows(3).Item(4) = True Then UseExcused = True

        If ds.Tables(1).Rows(4).Item(4) = True Then UseAbsent = True

        If ds.Tables(1).Rows(5).Item(4) = True Then UseNotVoting = True

        Dim vdt As New DataTable

        Dim StartDate As String = Session("BeginDate")
        Dim EndDate As String = Session("EndDate")
        'Validate Dates

        Dim strStartDate As String = String.Empty
        Dim strEndDate As String = String.Empty

        If Not StartDate = String.Empty Then

            If IsDate(CDate(StartDate)) = True Then
                StartDate = CDate(Session("BeginDate"))
                strStartDate = CStr(StartDate)
            Else
                strStartDate = "01/01/1900"
            End If
        Else
            strStartDate = "01/01/1900"
        End If
        Dim Today As String = CStr(Date.Today)
        If Not EndDate = String.Empty Then

            If IsDate(CDate(EndDate)) = True Then
                EndDate = CDate(Session("EndDate"))
                strEndDate = CStr(EndDate + " 23:59:59")
            Else
                strEndDate = Today + " 23:59:59"
            End If
        Else
            strEndDate = Today + " 23:59:59"
        End If

        _pBeginDate = strStartDate
        _pEndDate = strEndDate

        ' Get Report Content
        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_VoterDetails"
            cmd.Parameters.AddWithValue("@Members", Members)
            cmd.Parameters.AddWithValue("@BillList", Bills)
            cmd.Parameters.AddWithValue("@MotionField", MotionData)
            cmd.Parameters.AddWithValue("@SubjectField1", SubField1)
            cmd.Parameters.AddWithValue("@SubjectField2", SubField2)
            cmd.Parameters.AddWithValue("@BeginDate", strStartDate)
            cmd.Parameters.AddWithValue("@EndDate", strEndDate)

            cmd.Parameters.AddWithValue("@oYea", VoteReporter.Item(0).yeaHeaderOrder)
            cmd.Parameters.AddWithValue("@oNay", VoteReporter.Item(0).nayHeaderOrder)
            cmd.Parameters.AddWithValue("@oAbstain", VoteReporter.Item(0).abstainHeaderOrder)
            cmd.Parameters.AddWithValue("@oExc", VoteReporter.Item(0).excusedHeaderOrder)
            cmd.Parameters.AddWithValue("@oAbsent", VoteReporter.Item(0).absentHeaderOrder)
            cmd.Parameters.AddWithValue("@oNV", VoteReporter.Item(0).notVotingHeaderOrder)

            cmd.Parameters.AddWithValue("@uYea", CByte(UseYea))
            cmd.Parameters.AddWithValue("@uNay", CByte(UseNay))
            cmd.Parameters.AddWithValue("@uAbstain", CByte(UseAbstain))
            cmd.Parameters.AddWithValue("@uExc", CByte(UseExcused))
            cmd.Parameters.AddWithValue("@uAbsent", CByte(UseAbsent))
            cmd.Parameters.AddWithValue("@uNV", CByte(UseNotVoting))

            cmd.Parameters.AddWithValue("@nYea", nYea)
            cmd.Parameters.AddWithValue("@nNay", nNay)
            cmd.Parameters.AddWithValue("@nAbstain", nAbstain)
            cmd.Parameters.AddWithValue("@nExc", nExc)
            cmd.Parameters.AddWithValue("@nAbsent", nAbsent)
            cmd.Parameters.AddWithValue("@nNV", nNV)

            cmd.Parameters.AddWithValue("@ShowDistrict", CByte(VoteReporter.Item(0).showDistrictName))
            cmd.Parameters.AddWithValue("@DistrictNameHeader", VoteReporter.Item(0).districtNameTitle)
            cmd.Parameters.AddWithValue("@DistrictNbrHeader", VoteReporter.Item(0).districtNbrTitle)

            Using da
                da.SelectCommand = cmd

                Dim SORTBY As String = Session("VDSort")
                Dim motionFilter As String = Session("vhMotionFilter")
                If Not SORTBY = String.Empty Then
                    Dim FilterTable As New DataTable("sp_Report_VoterDetails")
                    da.Fill(FilterTable)

                    Dim Filter As New DataView(FilterTable)
                    'check for motion filter

                    If Not Trim(motionFilter) = String.Empty Then
                        Filter.RowFilter = "Motion = '" + motionFilter + "'"
                    End If

                    Filter.Sort = SORTBY
                    FilterTable = Filter.ToTable()
                    ds.Tables.Add(FilterTable)

                Else

                    'check for motion filter

                    If Not Trim(motionFilter) = String.Empty Then
                        Dim FilterTable As New DataTable("sp_Report_VoterDetails")
                        da.Fill(FilterTable)
                        Dim Filter As New DataView(FilterTable)
                        Filter.RowFilter = "Motion = '" + motionFilter + "'"
                        FilterTable = Filter.ToTable()
                        ds.Tables.Add(FilterTable)
                    Else
                        'Dim FilterTable As New DataTable("sp_Report_VoterDetails")
                        'da.Fill(FilterTable)
                        'Dim Filter As New DataView(FilterTable)

                        'Filter.RowFilter = "BillNbr <> '0'"
                        'FilterTable = Filter.ToTable()
                        'ds.Tables.Add(FilterTable)

                        da.Fill(ds, "sp_Report_VoterDetails")
                    End If

                End If

                If ds.Tables("sp_Report_VoterDetails").Rows.Count = 0 Then
                    Dim drEmptyRow As DataRow = ds.Tables("sp_Report_VoterDetails").NewRow
                    drEmptyRow.Item("VotingName") = "NO DATA TO SHOW"
                    ds.Tables("sp_Report_VoterDetails").Rows.InsertAt(drEmptyRow, 0)
                    ds.Tables("sp_Report_VoterDetails").AcceptChanges()
                End If

            End Using

            con.Close()
        End Using

        Dim sBillList As New StringBuilder
        Dim FindDuplicates As New Hashtable
        Dim idxCounter As Integer = 0
        For Each row As DataRow In ds.Tables("sp_Report_VoterDetails").Rows
            If FindDuplicates.ContainsValue(row("BillNbr")) = False Then
                FindDuplicates.Add(idxCounter, row("BillNbr"))
                sBillList.Append(row("BillNbr") & " ")
            End If
            idxCounter += 1
        Next
        _sBills = sBillList.ToString()


        ' Get Report Type Details
        Dim cmd2 As New SqlCommand
        With cmd2
            .Connection = con
            .Connection.Open()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_Report_GetTypeDetails"
            .Parameters.AddWithValue("@TypeID", 4)
        End With
        Using da
            da.SelectCommand = cmd2
            da.Fill(ds, "sp_Report_GetTypeDetails")
        End Using

        cmd2.Connection.Close()

        VoterDetailsViewer.Report = CreateReport(ds, YeaOrder, NayOrder, AbstainOrder, ExcusedOrder, AbsentOrder, NotVotingOrder)
        VoterDetailsViewer.DataBind()

    End Sub

    Private Function CreateReport(ByVal ds As DataSet, ByVal YeaOrder As Integer, ByVal NayOrder As Integer, ByVal AbstainOrder As Integer, ByVal ExcusedOrder As Integer, ByVal AbsentOrder As Integer, ByVal NVOrder As Integer) As XRVoterDetails

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim report As New XRVoterDetails()
        report.DataSource = ds

        report.lblSessionPeriod.Text = VoteReporter.Item(0).currentSessionLegislature
        report.lblPrintDate.Text = Date.Now.ToString()

        If Session("BeginDate").ToString = String.Empty Then
            report.lblBeginDate.Text = Session("SessionStartedOn").ToString()
        Else
            report.lblBeginDate.Text = Session("BeginDate")
        End If

        If Session("EndDate").ToString = String.Empty Then
            report.lblEndDate.Text = Session("SessionEndedOn").ToString()
        Else
            report.lblEndDate.Text = Session("EndDate")
        End If

        If Session("VDSort") = "LegNbr ASC" Then
            report.lblSortOrder.Text = "Document Number"
        ElseIf Session("VDSort") = "RCSNbr ASC" Then
            report.lblSortOrder.Text = "RCS Number"
        Else
            report.lblSortOrder.Text = "N/A"
        End If

        If Not _sSubjects = String.Empty Then
            report.lblSubjects.Text = _sSubjects
        Else
            report.lblSubjects.Text = "ALL"
        End If

        If Session("VDIsAllBills") = 1 Then
            report.lblBills.Text = "ALL"
        Else
            report.lblBills.Text = _sBills
        End If

        If Session("vhShowPartyTotals") = False Then
            report.Landscape = False
            'hide party total columns
            report.XrLabel21.Visible = False
            report.XrLabel22.Visible = False
            report.XrLabel23.Visible = False
            report.XrLabel27.Visible = False
            report.XrLabel28.Visible = False

            report.XrLabel30.Visible = False
            report.XrLabel31.Visible = False
            report.XrLabel32.Visible = False
            report.XrLabel33.Visible = False

            report.XrLabel40.Visible = False
            report.XrLabel41.Visible = False

            report.XrLabel3.WidthF = 197
            report.XrLabel20.WidthF = 197
  
            report.XrLine1.WidthF = 742
            report.XrLine2.WidthF = 742

            report.XrLine3.Visible = False
            report.XrLine6.Visible = False


            report.XrPageInfo1.WidthF = 742

        End If

        If Session("vhShowShort") = True Then
            report.XrLabel2.Visible = True
        Else
            report.XrLabel2.Visible = False
        End If

        Dim votesUsed As New StringBuilder

        If Session("vhYES") = True Then
            votesUsed.Append(nYea & " ")
        End If
        If Session("vhNAY") = True Then
            votesUsed.Append(nNay & " ")
        End If
        If Session("vhABSTAIN") = True Then
            votesUsed.Append(nAbstain & " ")
        End If
        If Session("vhEXC") = True Then
            votesUsed.Append(nExc & " ")
        End If
        If Session("vhABSENT") = True Then
            votesUsed.Append(nAbsent & " ")
        End If
        If Session("vhNV") = True Then
            votesUsed.Append(nNV & " ")
        End If

        Dim strVotesUsed = votesUsed.ToString()
        report.lblVoteTypes.Text = strVotesUsed

        If UseYea = True And YeaOrder = 1 Then report.Header1.Text = nYea
        If UseYea = True And YeaOrder = 2 Then report.Header2.Text = nYea
        If UseYea = True And YeaOrder = 3 Then report.Header3.Text = nYea
        If UseYea = True And YeaOrder = 4 Then report.Header4.Text = nYea
        If UseYea = True And YeaOrder = 5 Then report.Header5.Text = nYea
        If UseYea = True And YeaOrder = 6 Then report.Header6.Text = nYea

        If UseNay = True And NayOrder = 1 Then report.Header1.Text = nNay
        If UseNay = True And NayOrder = 2 Then report.Header2.Text = nNay
        If UseNay = True And NayOrder = 3 Then report.Header3.Text = nNay
        If UseNay = True And NayOrder = 4 Then report.Header4.Text = nNay
        If UseNay = True And NayOrder = 5 Then report.Header5.Text = nNay
        If UseNay = True And NayOrder = 6 Then report.Header6.Text = nNay

        If UseAbstain = True And AbstainOrder = 1 Then report.Header1.Text = nAbstain
        If UseAbstain = True And AbstainOrder = 2 Then report.Header2.Text = nAbstain
        If UseAbstain = True And AbstainOrder = 3 Then report.Header3.Text = nAbstain
        If UseAbstain = True And AbstainOrder = 4 Then report.Header4.Text = nAbstain
        If UseAbstain = True And AbstainOrder = 5 Then report.Header5.Text = nAbstain
        If UseAbstain = True And AbstainOrder = 6 Then report.Header6.Text = nAbstain

        If UseExcused = True And ExcusedOrder = 1 Then report.Header1.Text = nExc
        If UseExcused = True And ExcusedOrder = 2 Then report.Header2.Text = nExc
        If UseExcused = True And ExcusedOrder = 3 Then report.Header3.Text = nExc
        If UseExcused = True And ExcusedOrder = 4 Then report.Header4.Text = nExc
        If UseExcused = True And ExcusedOrder = 5 Then report.Header5.Text = nExc
        If UseExcused = True And ExcusedOrder = 6 Then report.Header6.Text = nExc

        If UseAbsent = True And AbsentOrder = 1 Then report.Header1.Text = nAbsent
        If UseAbsent = True And AbsentOrder = 2 Then report.Header2.Text = nAbsent
        If UseAbsent = True And AbsentOrder = 3 Then report.Header3.Text = nAbsent
        If UseAbsent = True And AbsentOrder = 4 Then report.Header4.Text = nAbsent
        If UseAbsent = True And AbsentOrder = 5 Then report.Header5.Text = nAbsent
        If UseAbsent = True And AbsentOrder = 6 Then report.Header6.Text = nAbsent

        If UseNotVoting = True And NVOrder = 1 Then report.Header1.Text = nNV
        If UseNotVoting = True And NVOrder = 2 Then report.Header2.Text = nNV
        If UseNotVoting = True And NVOrder = 3 Then report.Header3.Text = nNV
        If UseNotVoting = True And NVOrder = 4 Then report.Header4.Text = nNV
        If UseNotVoting = True And NVOrder = 5 Then report.Header5.Text = nNV
        If UseNotVoting = True And NVOrder = 6 Then report.Header6.Text = nNV


        If Session("vhYES") = False Then
            report.BeginInit()

            Select Case YeaOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select
            report.XrTable1.AdjustSize()
            report.EndInit()
        End If


        If Session("vhNAY") = False Then

            report.BeginInit()
            Select Case NayOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()

        End If

        If Session("vhABSTAIN") = False Then

            report.BeginInit()
            Select Case AbstainOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()

        End If


        If Session("vhEXC") = False Then

            report.BeginInit()
            Select Case ExcusedOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()

        End If

        If Session("vhABSENT") = False Then

            report.BeginInit()
            Select Case AbsentOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()

        End If

        If Session("vhNV") = False Then

            report.BeginInit()
            Select Case NVOrder

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.h1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.h2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.h3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.h4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.h5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.h6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()

        End If

        report.CreateDocument()
        Return report
    End Function

End Class