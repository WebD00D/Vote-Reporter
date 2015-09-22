Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class VRConfigurationService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function SetDataParameters(ByVal VRDBName As String, ByVal VRDBCon As String, ByVal VoteDBName As String, ByVal VoteDBCon As String) As String

        Dim returnVal As Integer = 0

        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Using cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetVotingDataDetails"
                cmd.Parameters.AddWithValue("@VoteDatabaseName", Trim(VoteDBName))
                cmd.Parameters.AddWithValue("@VoteDatabaseConnection", Trim(VoteDBCon))
                cmd.Parameters.AddWithValue("@VRDatabaseName", Trim(VRDBName))
                cmd.Parameters.AddWithValue("@VRDatabaseConnection", Trim(VRDBCon))
                cmd.Connection = con
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using
            returnVal = 1
        Catch ex As Exception
            'To Do: Add Error Logging
        End Try
        Return returnVal
    End Function


    <WebMethod()> _
    Public Function SetReportParameters(ByVal RCS As String, ByVal BillNbr As String, ByVal Motion As String, ByVal DateTime As String, ByVal VoteTotals As String, ByVal Results As String, ByVal PartyTotals As String _
                            , ByVal Outcome As String, ByVal Member As String, ByVal DistrictName As String, ByVal DistrictNumber As String, ByVal PresName1 As String _
                            , ByVal PresTitle1 As String, ByVal PresName2 As String, ByVal PresTitle2 As String, ByVal ClerkName As String, ByVal ClerkTitle As String)

        Dim returnVal As Boolean = False
        Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)

        Try

            Using cmd As New SqlCommand

                cmd.Connection = Con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetReportParams"
                cmd.Parameters.AddWithValue("@RSCNumber", RCS)
                cmd.Parameters.AddWithValue("@BillNumber", BillNbr)
                cmd.Parameters.AddWithValue("@Motion", Motion)
                cmd.Parameters.AddWithValue("@DateTime", DateTime)
                cmd.Parameters.AddWithValue("@VoteTotals", VoteTotals)
                cmd.Parameters.AddWithValue("@Results", Results)
                cmd.Parameters.AddWithValue("@Outcome ", Outcome)
                cmd.Parameters.AddWithValue("@PartyTotals", PartyTotals)
                cmd.Parameters.AddWithValue("@Member", Member)
                cmd.Parameters.AddWithValue("@DistrictName", DistrictName)
                cmd.Parameters.AddWithValue("@DistrictNumber", DistrictNumber)
                cmd.Parameters.AddWithValue("@Presiding_Name_1", PresName1)
                cmd.Parameters.AddWithValue("@Presiding_Title_1", PresTitle1)
                cmd.Parameters.AddWithValue("@Presiding_Name_2", PresName2)
                cmd.Parameters.AddWithValue("@Presiding_Title_2", PresTitle2)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Name", ClerkName)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Title", ClerkTitle)
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End Using
            returnVal = True
        Catch ex As Exception
            ' to do: add error handling class
            returnVal = False
        End Try

        Return returnVal
    End Function



    <WebMethod()> _
    Public Function SetAccountSettings(ByVal GovName As String, ByVal LegBodyName As String)
        Dim returnval As Boolean = False

        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            Using cmd
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetAccountParams"
                cmd.Parameters.AddWithValue("@GovName", GovName)
                cmd.Parameters.AddWithValue("@LegName", LegBodyName)
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using
            returnval = True
        Catch ex As Exception
            returnval = False
        End Try
       

        Return returnval
    End Function



End Class