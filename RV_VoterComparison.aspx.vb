Imports System
Imports System.Data.SqlClient

Public Class RV_VoterComparison
    Inherits System.Web.UI.Page

    Public _BillLists As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim CalendarItems As String = Session("CalendarItems")
        If Session("UseSubjectSearch") = True Then
            CalendarItems = Session("SearchedBillIDs")
        End If
        _BillLists = CalendarItems

        Dim StartDate As String = Session("VoteComp_StartDate")
        Dim EndDate As String = Session("VoteComp_EndDate")

        Dim strStartDate As String = String.Empty
        Dim strEndDate As String = String.Empty

        If Not StartDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(StartDate)) = True Then
                StartDate = CDate(Session("VoteComp_StartDate"))
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
                EndDate = CDate(Session("VoteComp_EndDate"))
                strEndDate = CStr(EndDate + " 23:59:59")
            Else
                strEndDate = Today + " 23:59:59"
            End If
        Else
            strEndDate = Today + " 23:59:59"
        End If



        Dim Voter1ID As String = CStr(Session("Voter1ID"))
        Dim Voter2ID As String = CStr(Session("Voter2ID"))
        Dim Voter3ID As String = CStr(Session("Voter3ID"))
        Dim Voter4ID As String = CStr(Session("Voter4ID"))
        Dim Voter5ID As String = CStr(Session("Voter5ID"))
        Dim Voter6ID As String = CStr(Session("Voter6ID"))
        Dim Voter7ID As String = CStr(Session("Voter7ID"))


        If Voter3ID = "0" Then Voter3ID = String.Empty
        If Voter4ID = "0" Then Voter4ID = String.Empty
        If Voter5ID = "0" Then Voter5ID = String.Empty
        If Voter6ID = "0" Then Voter6ID = String.Empty
        If Voter7ID = "0" Then Voter7ID = String.Empty


        Dim dt As New DataTable
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim ds As New DataSet




        ' Get Motion Column
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

        Dim MotionData As String = ds.Tables(0).Rows(0).Item(28)
        Dim SubField1 As Integer = ds.Tables(0).Rows(0).Item(35)
        Dim SubField2 As Integer = ds.Tables(0).Rows(0).Item(36)

        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 6)

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using

            cmd.Connection.Close()
        End Using

        ' Get Values for Naming conventions for vote types

        Dim NameDT As New DataTable
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetVoteTypeNames"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(NameDT)
            End Using

            cmd.Connection.Close()
        End Using

        Dim YeaName As String = NameDT.Rows(0).Item(0)
        Dim NayName As String = NameDT.Rows(1).Item(0)
        Dim AbstainName As String = NameDT.Rows(2).Item(0)
        Dim ExcusedNamed As String = NameDT.Rows(3).Item(0)
        Dim AbsentName As String = NameDT.Rows(4).Item(0)
        Dim NVName As String = NameDT.Rows(5).Item(0)

        Dim MemberCount As Integer = 2

        ' Set Report Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure


            If Not Voter7ID = String.Empty Then

                cmd.CommandText = "sp_Report_VoterComparison_7MBR"
                cmd.Parameters.AddWithValue("@Member3", CStr(Voter3ID))
                cmd.Parameters.AddWithValue("@Member4", CStr(Voter4ID))
                cmd.Parameters.AddWithValue("@Member5", CStr(Voter5ID))
                cmd.Parameters.AddWithValue("@Member6", CStr(Voter6ID))
                cmd.Parameters.AddWithValue("@Member7", CStr(Voter7ID))

                MemberCount = 7

            ElseIf Not Voter6ID = String.Empty Then

                cmd.CommandText = "sp_Report_VoterComparison_6MBR"
                cmd.Parameters.AddWithValue("@Member3", CStr(Voter3ID))
                cmd.Parameters.AddWithValue("@Member4", CStr(Voter4ID))
                cmd.Parameters.AddWithValue("@Member5", CStr(Voter5ID))
                cmd.Parameters.AddWithValue("@Member6", CStr(Voter6ID))

                MemberCount = 6

            ElseIf Not Voter5ID = String.Empty Then

                cmd.CommandText = "sp_Report_VoterComparison_5MBR"
                cmd.Parameters.AddWithValue("@Member3", CStr(Voter3ID))
                cmd.Parameters.AddWithValue("@Member4", CStr(Voter4ID))
                cmd.Parameters.AddWithValue("@Member5", CStr(Voter5ID))

                MemberCount = 5

            ElseIf Not Voter4ID = String.Empty Then

                cmd.CommandText = "sp_Report_VoterComparison_4MBR"
                cmd.Parameters.AddWithValue("@Member3", CStr(Voter3ID))
                cmd.Parameters.AddWithValue("@Member4", CStr(Voter4ID))

                MemberCount = 4

            ElseIf Not Voter3ID = String.Empty Then

                cmd.CommandText = "sp_Report_VoterComparison_4MBR"
                cmd.Parameters.AddWithValue("@Member3", CStr(Voter3ID))

                MemberCount = 3

            Else
                cmd.CommandText = "sp_Report_VoterComparison_2MBR"
            End If

            cmd.Parameters.AddWithValue("@BillList", CalendarItems)
            cmd.Parameters.AddWithValue("@YeaName", YeaName)
            cmd.Parameters.AddWithValue("@NayName", NayName)
            cmd.Parameters.AddWithValue("@AbstainName", AbstainName)
            cmd.Parameters.AddWithValue("@ExcusedName", ExcusedNamed)
            cmd.Parameters.AddWithValue("@AbsentName", AbsentName)
            cmd.Parameters.AddWithValue("@NVName", NVName)
            cmd.Parameters.AddWithValue("@Member1", CStr(Voter1ID))
            cmd.Parameters.AddWithValue("@Member2", CStr(Voter2ID))
            cmd.Parameters.AddWithValue("@MotionField", MotionData)
            cmd.Parameters.AddWithValue("@SubjectField1", SubField1)
            cmd.Parameters.AddWithValue("@SubjectField2", SubField2)
            cmd.Parameters.AddWithValue("@StartDate", strStartDate)
            cmd.Parameters.AddWithValue("@EndDate", strEndDate)

            Using da As New SqlDataAdapter(cmd)

                Dim SORTBY As String = Session("Vcomp_SortBy")
                If Not SORTBY = String.Empty Then
                    Dim FilterTable As New DataTable("sp_Report_VoterComparison_7MBR")
                    da.Fill(FilterTable)
                    Dim Filter As New DataView(FilterTable)
                    Filter.Sort = SORTBY
                    FilterTable = Filter.ToTable()
                    ds.Tables.Add(FilterTable)
                Else
                    da.Fill(ds, "sp_Report_VoterComparison_7MBR")
                End If

                If ds.Tables("sp_Report_VoterComparison_7MBR").Rows.Count = 0 Then
                    Dim drEmptyRow As DataRow = ds.Tables("sp_Report_VoterComparison_7MBR").NewRow

                    ds.Tables("sp_Report_VoterComparison_7MBR").Rows.InsertAt(drEmptyRow, 0)
                    ds.Tables("sp_Report_VoterComparison_7MBR").AcceptChanges()
                End If

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
            .Parameters.AddWithValue("@BillList", _BillLists)

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
        _BillLists = sBillList.ToString()



        VoterComparisonViewer.Report = CreateReport(ds, MemberCount)
        VoterComparisonViewer.DataBind()


    End Sub


    Private Function CreateReport(ByVal ds As DataSet, ByVal MemberCount As Integer) As XRVoterComparison
        Dim report As New XRVoterComparison()
        report.DataSource = ds

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        report.BeginInit()
        report.lblSession.Text = VoteReporter.Item(0).currentSessionLegislature
        report.lblPrintedOn.Text = Date.Now.ToString()

        If Not Session("VoteComp_StartDate") = String.Empty Then
            report.lblStartDate.Text = Session("VoteComp_StartDate").ToString()
        Else
            report.lblStartDate.Text = "ALL"
        End If
        If Not Session("VoteComp_EndDate") = String.Empty Then
            report.lblEndDate.Text = Session("VoteComp_EndDate").ToString()
        Else
            report.lblEndDate.Text = "ALL"
        End If


        If Session("IsAllBills") = True Then
            report.lblBills.Text = "ALL"
        Else
            report.lblBills.Text = _BillLists
        End If

        If Session("Vcomp_SortBy") = String.Empty Then
            report.lblSort.Text = "N/A"
        Else
            If Session("Vcomp_SortBy") = "Column1 ASC" Then
                report.lblSort.Text = "Document Number"
            Else
                report.lblSort.Text = "RCS Number"
            End If
        End If



        'If has3 = False Then
        '    report.hMember3.Visible = False
        '    report.Member3.Visible = False
        'End If
        report.EndInit()

        report.CreateDocument()
        Return report
    End Function
End Class