Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class RV_RollCallTranscript
    Inherits System.Web.UI.Page
    Private YeaOrder As Integer
    Private NayOrder As Integer
    Private AbstainOrder As Integer
    Private ExcusedOrder As Integer
    Private AbsentOrder As Integer
    Private NotVotingOrder As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim Bills As String = Session("CalendarItems")
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

       

        ' Get Report Configuration Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetReportConfigParams"

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using
            cmd.Connection.Close()
        End Using

        Dim RCSNumberHeading As String = ds.Tables(0).Rows(0).Item(9)
        Dim BillNumberHeading As String = ds.Tables(0).Rows(0).Item(10)
        Dim MotionHeading As String = ds.Tables(0).Rows(0).Item(11)
        Dim MotionCalDataField As String = ds.Tables(0).Rows(0).Item(28)
        Dim DateTimeHeading As String = ds.Tables(0).Rows(0).Item(12)
        Dim SubField1 As Integer = ds.Tables(0).Rows(0).Item(35)
        Dim SubField2 As Integer = ds.Tables(0).Rows(0).Item(36)



        ' Get Vote Mapping Settings
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
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
        YeaOrder = ds.Tables(1).Rows(0).Item(9)
        NayOrder = ds.Tables(1).Rows(1).Item(9)
        AbstainOrder = ds.Tables(1).Rows(2).Item(9)
        ExcusedOrder = ds.Tables(1).Rows(3).Item(9)
        AbsentOrder = ds.Tables(1).Rows(4).Item(9)
        NotVotingOrder = ds.Tables(1).Rows(5).Item(9)

        '2. Set what Vote Values we can use.

        Dim UseYea As Integer = 1 'always use
        Dim UseNay As Integer = 1 'always use
        Dim UseAbstain As Integer = 0
        Dim UseExcused As Integer = 0
        Dim UseAbsent As Integer = 0
        Dim UseNotVoting As Integer = 0

        If ds.Tables(1).Rows(2).Item(4) = True Then UseAbstain = 1

        If ds.Tables(1).Rows(3).Item(4) = True Then UseExcused = 1

        If ds.Tables(1).Rows(4).Item(4) = True Then UseAbsent = 1

        If ds.Tables(1).Rows(5).Item(4) = True Then UseNotVoting = 1

        ' Get Vote Value Names

        Dim YeaHeader As String = ds.Tables(1).Rows(0).Item(3)
        Dim NayHeader As String = ds.Tables(1).Rows(1).Item(3)
        Dim AbstainHeader As String = ds.Tables(1).Rows(2).Item(3)
        Dim ExcusedHeader As String = ds.Tables(1).Rows(3).Item(3)
        Dim AbsentHeader As String = ds.Tables(1).Rows(4).Item(3)
        Dim NotVotingHeader As String = ds.Tables(1).Rows(5).Item(3)


        Dim VoteDate As Date = Nothing



        Dim cmd2 As New SqlCommand
        With cmd2
            .Connection = con
            .Connection.Open()
            .CommandTimeout = 1200
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_Report_RollCallTranscript"
            .Parameters.AddWithValue("@BillList", Bills)
            .Parameters.AddWithValue("@MotionField", MotionCalDataField)
            .Parameters.AddWithValue("@SubjectField1", SubField1)
            .Parameters.AddWithValue("@SubjectField2", SubField2)
            .Parameters.AddWithValue("@uyea", UseYea)
            .Parameters.AddWithValue("@oyea", YeaOrder)
            .Parameters.AddWithValue("@unay", UseNay)
            .Parameters.AddWithValue("@onay", NayOrder)
            .Parameters.AddWithValue("@uabstn", UseAbstain)
            .Parameters.AddWithValue("@oabstn", AbstainOrder)
            .Parameters.AddWithValue("@uexc", UseExcused)
            .Parameters.AddWithValue("@oexc", ExcusedOrder)
            .Parameters.AddWithValue("@uabs", UseAbsent)
            .Parameters.AddWithValue("@oabs", AbsentOrder)
            .Parameters.AddWithValue("@unv", UseNotVoting)
            .Parameters.AddWithValue("@onv", NotVotingOrder)
            .Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)

            Using da

                da.SelectCommand = cmd2

                If Not Session("VoteDate") = String.Empty Then
                    VoteDate = CDate(Session("VoteDate"))
                    Dim FilterTable As New DataTable("sp_Report_RollCallTranscript")
                    da.Fill(FilterTable)
                    Dim strDate As String = CStr(VoteDate)
                    Dim Filter As New DataView(FilterTable)
                    Filter.RowFilter = "CDate = #" & strDate & "#"
                    FilterTable = Filter.ToTable()
                    ds.Tables.Add(FilterTable)
                Else
                    da.Fill(ds, "sp_Report_RollCallTranscript")
                End If

            End Using

            .Connection.Close()

        End With


        ' Get Headers
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
            cmd.Parameters.AddWithValue("@useYea", CByte(UseYea))
            cmd.Parameters.AddWithValue("@useNay", CByte(UseNay))
            cmd.Parameters.AddWithValue("@useAbstain", CByte(UseAbstain))
            cmd.Parameters.AddWithValue("@useExcused", CByte(UseExcused))
            cmd.Parameters.AddWithValue("@useAbsent", CByte(UseAbsent))
            cmd.Parameters.AddWithValue("@useNotVoting", CByte(UseNotVoting))
            cmd.Parameters.AddWithValue("@hYea", YeaHeader)
            cmd.Parameters.AddWithValue("@hNay", NayHeader)
            cmd.Parameters.AddWithValue("@hAbstain", AbstainHeader)
            cmd.Parameters.AddWithValue("@hExcused", ExcusedHeader)
            cmd.Parameters.AddWithValue("@hAbsent", AbsentHeader)
            cmd.Parameters.AddWithValue("@hNotVoting", NotVotingHeader)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetVoteHeaderOrders")
            End Using

            cmd.Connection.Close()
        End Using



        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 1)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using

            cmd.Connection.Close()
        End Using

        RCTranscriptViewer.Report = CreateReport(ds, UseYea, UseNay, UseAbstain, UseExcused, UseAbsent, UseNotVoting)
        RCTranscriptViewer.DataBind()

    End Sub


    Private Function CreateReport(ByVal ds As DataSet, ByVal useYEA As Integer, ByVal useNay As Integer, ByVal useAbstain As Integer, ByVal useExc As Integer, ByVal useAbsent As Integer, ByVal useNV As Integer) As XRRollCallTranscript

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim report As New XRRollCallTranscript()
        report.DataSource = ds
        report.lblSession.Text = VoteReporter.Item(0).currentSessionLegislature
        report.BeginInit()

        If useYEA = 0 Then
            Select Case YeaOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If

        If useNay = 0 Then
            Select Case NayOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If

        If useAbstain = 0 Then
            Select Case AbstainOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If


        If useExc = 0 Then
            Select Case ExcusedOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If


        If useAbsent = 0 Then
            Select Case AbsentOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If


        If useNV = 0 Then
            Select Case NotVotingOrder
                Case 1
                    report.XrTable1.DeleteColumn(report.xT1)
                    report.XrTable2.DeleteRow(report.R1)
                Case 2
                    report.XrTable1.DeleteColumn(report.xT2)
                    report.XrTable2.DeleteRow(report.R2)
                Case 3
                    report.XrTable1.DeleteColumn(report.xT3)
                    report.XrTable2.DeleteRow(report.R3)
                Case 4
                    report.XrTable1.DeleteColumn(report.xT4)
                    report.XrTable2.DeleteRow(report.R4)
                Case 5
                    report.XrTable1.DeleteColumn(report.xT5)
                    report.XrTable2.DeleteRow(report.R5)
                Case 6
                    report.XrTable1.DeleteColumn(report.xT6)
                    report.XrTable2.DeleteRow(report.R6)
            End Select
        End If

        report.XrTable1.AdjustSize()
        report.XrTable2.AdjustSize()
        report.EndInit()

        report.CreateDocument()
        Return report
    End Function

End Class