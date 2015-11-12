Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class ReportManagementService
    Inherits System.Web.Services.WebService

    Public Class VRReports
        Public ID As Integer
        Public Type As String
        Public Name As String
        Public MinAccess As Integer
        Public IsUsed As Integer
    End Class
    Shared ReportList As New List(Of VRReports)() From {}

    <WebMethod(True)> _
    Public Function ClearSubjectSearch()

        Session("UseSubjectSearch") = False
        Session("SearchText") = String.Empty

        Return ""

    End Function

    <WebMethod(True)> _
    Public Function CheckSubject(ByVal SearchText As String)

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim returnString As String = String.Empty
        Session("UseSubjectSearch") = False
        Session("SearchedBillIDs") = String.Empty
        Session("SearchText") = SearchText

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable



        Dim dt2 As New DataTable

        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRSearchSubjectFields"
            cmd.Parameters.AddWithValue("@SearchText", SearchText)
            cmd.Parameters.AddWithValue("@SessionCode", VoteReporter.Item(0).currentSessionCode)
            cmd.Parameters.AddWithValue("@SubjectField1", VoteReporter.Item(0).subjectDataField1)
            cmd.Parameters.AddWithValue("@SubjectField2", VoteReporter.Item(0).subjectDataField2)

            Using da
                da.SelectCommand = cmd
                da.Fill(dt2)
            End Using

            cmd.Connection.Close()
        End Using

        If dt2.Rows.Count = 0 Then
            Session("UseSubjectSearch") = False
            returnString = "empty"
        Else
            Session("UseSubjectSearch") = True
            Dim Bills As New List(Of String)()
            For Each Bill As DataRow In dt2.Rows
                Bills.Add(Bill("CalItem"))
            Next

            returnString = String.Join(",", Bills)
            Session("SearchedBillIDs") = returnString

        End If

        Return returnString
    End Function




    <WebMethod()> _
    Public Function LoadReportTypes()



        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter("SELECT * FROM ReportTypes", con)
        Dim ds As New DataSet("Users")
        da.Fill(ds, "Users")

        ReportList.Clear()

        For Each item As DataRow In ds.Tables(0).Rows()
            Dim u As New VRReports()
            u.ID = item("ID")
            u.Type = item("Type")
            u.Name = item("CurrentName")
            u.MinAccess = item("AccessLevel")
            u.IsUsed = item("IsUsed")

            ReportList.Add(u)
        Next

        Return ReportList
    End Function


    <WebMethod(True)> _
    Public Function EditReportDetails(ByVal Name As String, ByVal AccessLevel As Integer, ByVal ID As Integer, ByVal UseReport As Integer)
        Dim rval = Nothing




        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            With cmd
                .Connection = con
                .Connection.Open()
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_VRReportDetails_Update"
                .Parameters.AddWithValue("@Name", Name)
                .Parameters.AddWithValue("@Access", AccessLevel)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@IsUsed", UseReport)
                .ExecuteNonQuery()
                .Connection.Close()
            End With
            rval = 1
            Session("ReportJustEdited") = "Yes"
        Catch ex As Exception
            'TO DO: Error Logging Class
            rval = 2
            Session("ReportJustEdited") = "Failed"
        End Try



        Return rval
    End Function



End Class