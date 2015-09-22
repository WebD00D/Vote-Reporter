Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class RV_RollCallDetails
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim VoteDB As String = Session("VoteDBName")
        Dim CalendarID As Integer = Session("CalendarItemID")


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
            cmd.CommandText = "sp_VRGetReportConfigParams"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using

            cmd.Connection.Close()
        End Using

        Dim DistrictNameHeader As String = ds.Tables(0).Rows(0).Item(18)
        Dim DistrictNbrHeader As String = ds.Tables(0).Rows(0).Item(19)
        Dim MotionData As String = ds.Tables(0).Rows(0).Item(28)


        ' Get Vote Mapping Settings
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetVoteMappings"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_VRGetVoteMappings")
            End Using
            cmd.Connection.Close()
        End Using

        Dim UseDistrictName As Boolean = ds.Tables(0).Rows(0).Item(29)
        Dim District As Integer = 0

        If UseDistrictName = True Then District = 1

        ' Get Vote Header Display Order ,Whether or not it is used on reports, and all values. Pass 
        ' In Values to RollCallDetails sp and create a dummy column and case if vote value equals 
        ' the passed in value, then set the dummy order = the order passed in. 

        '1. Get Order
        Dim YeaOrder As Integer = ds.Tables(1).Rows(0).Item(9)
        Dim NayOrder As Integer = ds.Tables(1).Rows(1).Item(9)
        Dim AbstainOrder As Integer = ds.Tables(1).Rows(2).Item(9)
        Dim ExcusedOrder As Integer = ds.Tables(1).Rows(3).Item(9)
        Dim AbsentOrder As Integer = ds.Tables(1).Rows(4).Item(9)
        Dim NotVotingOrder As Integer = ds.Tables(1).Rows(5).Item(9)

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

        ' Get Report Content
        Using cmd As SqlCommand = con.CreateCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_RollCallDetails"
            cmd.Parameters.AddWithValue("@CalendarItemId", CStr(CalendarID))
            cmd.Parameters.AddWithValue("@VoteDB", VoteDB)
            cmd.Parameters.AddWithValue("@CALDATA", MotionData)


            cmd.Parameters.AddWithValue("@YeaOrder", YeaOrder)
            cmd.Parameters.AddWithValue("@NayOrder", NayOrder)
            cmd.Parameters.AddWithValue("@AbstainOrder", AbstainOrder)
            cmd.Parameters.AddWithValue("@ExcusedOrder", ExcusedOrder)
            cmd.Parameters.AddWithValue("@AbsentOrder", AbsentOrder)
            cmd.Parameters.AddWithValue("@NotVotingOrder", NotVotingOrder)

            cmd.Parameters.AddWithValue("@UseYea", CByte(UseYea))
            cmd.Parameters.AddWithValue("@UseNay", CByte(UseNay))
            cmd.Parameters.AddWithValue("@UseAbstain", CByte(UseAbstain))
            cmd.Parameters.AddWithValue("@UseExcused", CByte(UseExcused))
            cmd.Parameters.AddWithValue("@UseAbsent", CByte(UseAbsent))
            cmd.Parameters.AddWithValue("@UseNotVoting", CByte(UseNotVoting))

            cmd.Parameters.AddWithValue("@ShowDistrict", CByte(UseDistrictName))
            cmd.Parameters.AddWithValue("@DistNameHeader", DistrictNameHeader)
            cmd.Parameters.AddWithValue("@DistNbrHeader", DistrictNbrHeader)


            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_Report_RollCallDetails")
            End Using

            con.Close()
        End Using



        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 3)

            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using

            cmd.Connection.Close()
        End Using



        RCDetailsViewer.Report = CreateReport(ds)
        RCDetailsViewer.DataBind()

    End Sub

    Private Function CreateReport(ByVal ds As DataSet) As XRRollCallDetails
        Dim report As New XRRollCallDetails()
        report.DataSource = ds
        report.CreateDocument()
        Return report
    End Function

End Class