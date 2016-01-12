Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class RV_RollCallSummary
    Inherits System.Web.UI.Page

    Public _Bills As String
    Public _YeaName As String
    Public _NayName As String
    Public _AbstainName As String
    Public _ExcName As String
    Public _AbsentName As String
    Public _NVName As String
    Public _UseYea As Boolean
    Public _UseNay As Boolean
    Public _UseAbstain As Boolean
    Public _UseExcused As Boolean
    Public _UseAbsent As Boolean
    Public _UseNV As Boolean
    Public _OYea As Integer
    Public _ONay As Integer
    Public _OAbstain As Integer
    Public _OExcused As Integer
    Public _OAbsent As Integer
    Public _ONV As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim Bills As String = Session("RollCallSummary_Bills")
        Dim StartDate As String = Session("RollCallSummary_StartDate")
        Dim EndDate As String = Session("RollCallSummary_EndDate")

        Dim strStartDate As String = String.Empty
        Dim strEndDate As String = String.Empty

        If Not StartDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(StartDate)) = True Then
                StartDate = CDate(Session("RollCallSummary_StartDate"))
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
                EndDate = CDate(Session("RollCallSummary_EndDate"))
                strEndDate = CStr(EndDate + " 23:59:59")
            Else
                strEndDate = Today + " 23:59:59"
            End If
        Else
            strEndDate = Today + " 23:59:59"
        End If


        If Session("UseSubjectSearch") = True Then
            Bills = Session("SearchedBillIDs")
        End If

        _Bills = Bills

        Dim dt As New DataTable
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim ds As New DataSet


        'Get Vote Database Name 
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetDatabaseName"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using

            cmd.Connection.Close()
        End Using

        Dim VoteDB As String = dt.Rows(1).Item(0)


        ' Get Report Configuration Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetReportConfigParams"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using
            cmd.Connection.Close()
        End Using

        Dim RCSNumberHeading As String = ds.Tables(0).Rows(0).Item(9)
        Dim BillNumberHeading As String = ds.Tables(0).Rows(0).Item(10)
        Dim MotionHeading As String = ds.Tables(0).Rows(0).Item(11)
        Dim MotionCalDataField As String = ds.Tables(0).Rows(0).Item(28)
        Dim DateTimeHeading As String = ds.Tables(0).Rows(0).Item(12)

        Dim MotionData As String = ds.Tables(0).Rows(0).Item(28)
        Dim SubField1 As Integer = ds.Tables(0).Rows(0).Item(35)
        Dim SubField2 As Integer = ds.Tables(0).Rows(0).Item(36)

        ' Get Vote Mapping Settings
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetVoteMappings"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_VRGetVoteMappings")
            End Using
            cmd.Connection.Close()
        End Using

        ' Get Vote Header Display Order ,Whether or not it is used on reports, and all values. Pass 
        ' In Values to RollCallDetails sp and create a dummy column and case if vote value equals 
        ' the passed in value, then set the dummy order = the order passed in. 

        '1. Get Order
        _OYea = ds.Tables(1).Rows(0).Item(9)
        _ONay = ds.Tables(1).Rows(1).Item(9)
        _OAbstain = ds.Tables(1).Rows(2).Item(9)
        _OExcused = ds.Tables(1).Rows(3).Item(9)
        _OAbsent = ds.Tables(1).Rows(4).Item(9)
        _ONV = ds.Tables(1).Rows(5).Item(9)

        '2. Set what Vote Values we can use.

        _UseYea = True 'always use
        _UseNay = True 'always use

        _UseAbstain = False
        _UseExcused = False
        _UseAbsent = False
        _UseNV = False

        If ds.Tables(1).Rows(2).Item(4) = True Then _UseAbstain = True

        If ds.Tables(1).Rows(3).Item(4) = True Then _UseExcused = True

        If ds.Tables(1).Rows(4).Item(4) = True Then _UseAbsent = True

        If ds.Tables(1).Rows(5).Item(4) = True Then _UseNV = True

        _YeaName = ds.Tables(1).Rows(0).Item(3)
        _NayName = ds.Tables(1).Rows(1).Item(3)
        _AbstainName = ds.Tables(1).Rows(2).Item(3)
        _ExcName = ds.Tables(1).Rows(3).Item(3)
        _AbsentName = ds.Tables(1).Rows(4).Item(3)
        _NVName = ds.Tables(1).Rows(5).Item(3)


        '4. Call Report Stored Procedure

        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_RollCallSummary"
            cmd.Parameters.AddWithValue("@BillList", Bills)
            cmd.Parameters.AddWithValue("@MotionField", MotionData)
            cmd.Parameters.AddWithValue("@SessionCode", VoteReporter.Item(0).currentSessionCode)
            cmd.Parameters.AddWithValue("@SubjectField1", SubField1)
            cmd.Parameters.AddWithValue("@SubjectField2", SubField2)
            cmd.Parameters.AddWithValue("@StartDate", strStartDate)
            cmd.Parameters.AddWithValue("@EndDate", strEndDate)

            cmd.Parameters.AddWithValue("@oyea", _OYea)
            cmd.Parameters.AddWithValue("@onay", _ONay)
            cmd.Parameters.AddWithValue("@oabstn", _OAbstain)
            cmd.Parameters.AddWithValue("@oexc", _OExcused)
            cmd.Parameters.AddWithValue("@oabs", _OAbsent)
            cmd.Parameters.AddWithValue("@onv", _ONV)

            cmd.Parameters.AddWithValue("@uyea", CByte(_UseYea))
            cmd.Parameters.AddWithValue("@unay", CByte(_UseNay))
            cmd.Parameters.AddWithValue("@uabstn", CByte(_UseAbstain))
            cmd.Parameters.AddWithValue("@uexc", CByte(_UseExcused))
            cmd.Parameters.AddWithValue("@uabs", CByte(_UseAbsent))
            cmd.Parameters.AddWithValue("@unv", CByte(_UseNV))

            Dim motionFilter = Session("RCH_MotionFilter")

            Using da As New SqlDataAdapter(cmd)

                Dim SORTBY As String = Session("RCSortBy")
                If Not SORTBY = String.Empty Then
                    Dim FilterTable As New DataTable("sp_Report_RollCallSummary")
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


                    If Not Trim(motionFilter) = String.Empty Then
                        Dim FilterTable As New DataTable("sp_Report_RollCallSummary")
                        da.Fill(FilterTable)
                        Dim Filter As New DataView(FilterTable)
                        Filter.RowFilter = "Motion = '" + motionFilter + "'"
                        FilterTable = Filter.ToTable()
                        ds.Tables.Add(FilterTable)
                    Else

                        da.Fill(ds, "sp_Report_RollCallSummary")
                    End If



                End If

                If ds.Tables("sp_Report_RollCallSummary").Rows.Count = 0 Then
                    Dim drEmptyRow As DataRow = ds.Tables("sp_Report_RollCallSummary").NewRow

                    ds.Tables("sp_Report_RollCallSummary").Rows.InsertAt(drEmptyRow, 0)
                    ds.Tables("sp_Report_RollCallSummary").AcceptChanges()
                End If


            End Using

        End Using


        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 2)

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using

            cmd.Connection.Close()
        End Using

        'Bill List Code
        Dim newDT As New DataTable
        Dim newcon As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim newcmd As New SqlCommand
        With newcmd
            .CommandType = CommandType.StoredProcedure
            .Connection = newcon
            .Connection.Open()
            .CommandText = "sp_VRGetCalendarItemListDetails"
            .Parameters.AddWithValue("@BillList", _Bills)

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
        _Bills = sBillList.ToString()








        RCSummaryViewer.Report = CreateReport(ds)
        RCSummaryViewer.DataBind()


    End Sub


    Private Function CreateReport(ByVal ds As DataSet) As XRRollCallSummary


        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim report As New XRRollCallSummary()
        report.DataSource = ds

        report.BeginInit()
        report.lblSession.Text = VoteReporter.Item(0).currentSessionLegislature
        report.lblPrintDate.Text = Date.Now.ToString()


        If Not Session("RCSortBy") = String.Empty Then
            If Session("RCSortBy") = "LegNbr ASC" Then
                report.lblSortOrder.Text = "Document Number"
            Else
                report.lblSortOrder.Text = "RCS Number"
            End If
        Else
            report.lblSortOrder.Text = "N/A"
        End If

       


        If Session("RollCallSummary_StartDate").ToString = String.Empty Then
            Dim StartDate As Date = CDate(Session("SessionStarted"))
            report.lblBeginDate.Text = StartDate.ToString("d")
        Else
            Dim StartDate As Date = CDate(Session("RollCallSummary_StartDate"))
            report.lblBeginDate.Text = StartDate.ToString("d")
        End If

        If Session("RollCallSummary_EndDate").ToString = String.Empty Then

            Dim EndDate As Date = CDate(Session("SessionEnded"))
            report.lblEndDate.Text = EndDate.ToString("d")
        Else
            Dim EndDate As Date = CDate(Session("RollCallSummary_EndDate"))
            report.lblEndDate.Text = EndDate.ToString("d")
        End If


        If Session("RCHistISALL") = 1 Then
            report.lblBills.Text = "ALL"
        Else
            report.lblBills.Text = _Bills
        End If


        If Session("UseSubjectSearch") = True Then
            report.lblSubjects.Text = Session("SearchText").ToString()
        Else
            report.lblSubjects.Text = "ALL"
        End If


        If Session("ShowPartyTotals") = False Then
            report.Landscape = False
            'hide party total columns

            report.XrLabel3.Visible = False
            report.XrLabel40.Visible = False

            report.XrLabel36.Visible = False
            report.XrLabel37.Visible = False
            report.XrLabel41.Visible = False
            report.XrLabel38.Visible = False
            report.XrLabel42.Visible = False
            report.XrLabel43.Visible = False


            report.XrLabel30.Visible = False
            report.XrLabel31.Visible = False
            report.XrLabel32.Visible = False
            report.XrLabel33.Visible = False

            report.XrPageInfo1.WidthF = 664
            report.XrLine1.WidthF = 664
            report.XrLine2.WidthF = 664
            report.XrLine3.Visible = False
            report.XrLine6.Visible = False

        End If

        If Session("RCHShowShortTitle") = True Then
            report.XrLabel18.Visible = True
        Else
            report.XrLabel18.Visible = False
        End If





        Dim votesUsed As New StringBuilder

        If Session("RCHYea") = True Then
            votesUsed.Append(_YeaName & " ")
        End If
        If Session("RCHNay") = True Then
            votesUsed.Append(_NayName & " ")
        End If
        If Session("RCHAbstain") = True Then
            votesUsed.Append(_AbstainName & " ")
        End If
        If Session("RCHExcused") = True Then
            votesUsed.Append(_ExcName & " ")
        End If
        If Session("RCHAbsent") = True Then
            votesUsed.Append(_AbsentName & " ")
        End If
        If Session("RCHNotVoting") = True Then
            votesUsed.Append(_NVName & " ")
        End If

        Dim strVotesUsed = votesUsed.ToString()
        report.lblVoteTypes.Text = strVotesUsed


        If _UseYea = True And _OYea = 1 Then report.H1.Text = _YeaName
        If _UseYea = True And _OYea = 2 Then report.H2.Text = _YeaName
        If _UseYea = True And _OYea = 3 Then report.H3.Text = _YeaName
        If _UseYea = True And _OYea = 4 Then report.H4.Text = _YeaName
        If _UseYea = True And _OYea = 5 Then report.H5.Text = _YeaName
        If _UseYea = True And _OYea = 6 Then report.H6.Text = _YeaName

        If _UseNay = True And _ONay = 1 Then report.H1.Text = _NayName
        If _UseNay = True And _ONay = 2 Then report.H2.Text = _NayName
        If _UseNay = True And _ONay = 3 Then report.H3.Text = _NayName
        If _UseNay = True And _ONay = 4 Then report.H4.Text = _NayName
        If _UseNay = True And _ONay = 5 Then report.H5.Text = _NayName
        If _UseNay = True And _ONay = 6 Then report.H6.Text = _NayName

        If _UseAbstain = True And _OAbstain = 1 Then report.H1.Text = _AbstainName
        If _UseAbstain = True And _OAbstain = 2 Then report.H2.Text = _AbstainName
        If _UseAbstain = True And _OAbstain = 3 Then report.H3.Text = _AbstainName
        If _UseAbstain = True And _OAbstain = 4 Then report.H4.Text = _AbstainName
        If _UseAbstain = True And _OAbstain = 5 Then report.H5.Text = _AbstainName
        If _UseAbstain = True And _OAbstain = 6 Then report.H6.Text = _AbstainName

        If _UseExcused = True And _OExcused = 1 Then report.H1.Text = _ExcName
        If _UseExcused = True And _OExcused = 2 Then report.H2.Text = _ExcName
        If _UseExcused = True And _OExcused = 3 Then report.H3.Text = _ExcName
        If _UseExcused = True And _OExcused = 4 Then report.H4.Text = _ExcName
        If _UseExcused = True And _OExcused = 5 Then report.H5.Text = _ExcName
        If _UseExcused = True And _OExcused = 6 Then report.H6.Text = _ExcName

        If _UseAbsent = True And _OAbsent = 1 Then report.H1.Text = _AbsentName
        If _UseAbsent = True And _OAbsent = 2 Then report.H2.Text = _AbsentName
        If _UseAbsent = True And _OAbsent = 3 Then report.H3.Text = _AbsentName
        If _UseAbsent = True And _OAbsent = 4 Then report.H4.Text = _AbsentName
        If _UseAbsent = True And _OAbsent = 5 Then report.H5.Text = _AbsentName
        If _UseAbsent = True And _OAbsent = 6 Then report.H6.Text = _AbsentName

        If _UseNV = True And _ONV = 1 Then report.H1.Text = _NVName
        If _UseNV = True And _ONV = 2 Then report.H2.Text = _NVName
        If _UseNV = True And _ONV = 3 Then report.H3.Text = _NVName
        If _UseNV = True And _ONV = 4 Then report.H4.Text = _NVName
        If _UseNV = True And _ONV = 5 Then report.H5.Text = _NVName
        If _UseNV = True And _ONV = 6 Then report.H6.Text = _NVName

        If Session("RCHYea") = False Then
            report.BeginInit()

            Select Case _OYea

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If

        If Session("RCHNay") = False Then
            report.BeginInit()

            Select Case _ONay

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If

        If Session("RCHAbstain") = False Then
            report.BeginInit()

            Select Case _OAbstain

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If
        If Session("RCHExcused") = False Then
            report.BeginInit()

            Select Case _OExcused

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If
        If Session("RCHAbsent") = False Then
            report.BeginInit()

            Select Case _OAbsent

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If
        If Session("RCHNotVoting") = False Then
            report.BeginInit()

            Select Case _ONV

                Case 1
                    report.XrTable1.DeleteColumn(report.Tally1)
                    report.XrTable2.DeleteColumn(report.H1)
                Case 2
                    report.XrTable1.DeleteColumn(report.Tally2)
                    report.XrTable2.DeleteColumn(report.H2)
                Case 3
                    report.XrTable1.DeleteColumn(report.Tally3)
                    report.XrTable2.DeleteColumn(report.H3)
                Case 4
                    report.XrTable1.DeleteColumn(report.Tally4)
                    report.XrTable2.DeleteColumn(report.H4)
                Case 5
                    report.XrTable1.DeleteColumn(report.Tally5)
                    report.XrTable2.DeleteColumn(report.H5)
                Case 6
                    report.XrTable1.DeleteColumn(report.Tally6)
                    report.XrTable2.DeleteColumn(report.H6)
            End Select

            report.XrTable1.AdjustSize()
            report.EndInit()
        End If

        report.EndInit()

        report.CreateDocument()
        Return report
    End Function

End Class