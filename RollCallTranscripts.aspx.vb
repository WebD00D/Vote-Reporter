Imports System.Data.SqlClient
Public Class RollCallTranscripts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Using cmd

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetVoteMappings"
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
            cmd.Connection = con
            cmd.Connection.Open()

            Using da
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using

            cmd.Connection.Close()

        End Using

        If dt.Rows.Count > 0 Then

        Else
            Response.Redirect("NotConfigured.html")
        End If
    End Sub

End Class