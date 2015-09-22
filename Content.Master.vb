Imports System.Data.SqlClient
Public Class Content
    Inherits System.Web.UI.MasterPage
    Public FirstName As String
    Public Link1URL As String
    Public Link1Name As String
    Public Link2URL As String
    Public Link2Name As String
    Public Link3URL As String
    Public Link3Name As String
    Public SiteTitle As String
    Public SetSession As Integer
    Public SessionIndex As Integer
    Public _CurrentSessionCode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Access") = -1 Then
            Response.Redirect("Login.aspx", False)
            Context.ApplicationInstance.CompleteRequest()
        Else
            FirstName = Session("FirstName")
        End If

        Dim VoteDB As String = Session("VoteDBName")
        Dim MotionData As String = Session("pMotionData")

        Session("VoteDBName") = VoteDB
        Session("pMotionData") = MotionData

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable
        Dim SessionIDDT As New DataTable
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandText = "SELECT s.SessionID,sd.SessionCode,sd.SessionName,sd.IsCurrent,s.Legislature Legislature FROM VRSession s INNER JOIN VRSessionDetail sd on s.SessionID = sd.SessionID WHERE IsCurrent = 1"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(SessionIDDT)
            End Using
            cmd.Connection.Close()
        End Using

        Dim SessionID As Integer = SessionIDDT.Rows(0).Item("SessionID")

        Using cmd As New SqlCommand

            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetReportConfigParams"
            cmd.Parameters.AddWithValue("@SessionID", SessionID)
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
        End Using


        Link1Name = dt.Rows(0).Item(3)
        Link1URL = dt.Rows(0).Item(4)
        Link2Name = dt.Rows(0).Item(5)
        Link2URL = dt.Rows(0).Item(6)
        Link3Name = dt.Rows(0).Item(7)
        Link3URL = dt.Rows(0).Item(8)
        SiteTitle = dt.Rows(0).Item(1)


        Dim CheckSessionCodeState As String = CStr(Session("SessionCode"))

        If Not Page.IsPostBack Then
            If CStr(Session("SessionCode")) = String.Empty Then
                Using cmd As SqlCommand = con.CreateCommand
                    cmd.Connection = con
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_VRGetAvailableSessions"
                    '   cmd.Parameters.AddWithValue("@VoteDB", "OHHVoting_VRSync")

                    Dim SessionDT As New DataTable
                    Using da As New SqlDataAdapter
                        da.SelectCommand = cmd
                        da.Fill(SessionDT)
                        ddlSession.DataSource = SessionDT
                        ddlSession.DataValueField = "SessionCode"
                        ddlSession.DataTextField = "SessionCode"
                        ddlSession.DataBind()
                    End Using
                End Using
                ddlSession.SelectedIndex = ddlSession.Items.IndexOf(ddlSession.Items(0))
                Session("SessionCode") = ddlSession.SelectedValue
                Dim t As String = Session("SessionCode")
            Else
                Using cmd As SqlCommand = con.CreateCommand
                    cmd.Connection = con
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_VRGetAvailableSessions"
                    'cmd.Parameters.AddWithValue("@VoteDB", "OHHVoting_VRSync")

                    Dim SessionDT As New DataTable
                    Using da As New SqlDataAdapter
                        da.SelectCommand = cmd
                        da.Fill(SessionDT)
                        ddlSession.DataSource = SessionDT
                        ddlSession.DataValueField = "SessionCode"
                        ddlSession.DataTextField = "SessionCode"
                        ddlSession.DataBind()
                    End Using

                End Using
                ddlSession.SelectedValue = CheckSessionCodeState
            End If
        End If

        _CurrentSessionCode = Session("SessionCode")





    End Sub

    Protected Sub linkLogout_Click(sender As Object, e As EventArgs) Handles linkLogout.Click
        Session("Access") = -1
        Response.Redirect("Login.aspx", False)
        Context.ApplicationInstance.CompleteRequest()
    End Sub

    Protected Sub ddlSession_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim SessionCode As String = ddlSession.SelectedItem.Text
        Session("SessionCode") = SessionCode
        _CurrentSessionCode = SessionCode
    End Sub
End Class