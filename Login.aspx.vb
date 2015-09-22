Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class Skeleton
    Inherits System.Web.UI.Page
    Private Link1URL As String
    Private Link2URL As String
    Private Link3URL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter("SELECT * FROM Users WHERE Username ='" & txtUsername.Text & "'", con)
        Dim ds As New DataSet("user")
        da.Fill(ds, "user")
        Dim dt As DataTable = ds.Tables("user")

        If dt.Rows.Count = 1 Then

            Dim UserMgmtService As New UserManagementService()
            Dim md5Hash As MD5 = MD5.Create()
            Dim DBHash As String = dt.Rows(0).Item(6)
            Dim HashedPass = UserMgmtService.GetHash(md5Hash, txtPassword.Text)

            If UserMgmtService.UnHashIt(HashedPass, DBHash) Then
                'Store User Info
                Session("Firstname") = dt.Rows(0).Item("FirstName").ToString()
                Session("Access") = dt.Rows(0).Item("Type")


                ' Get Data Settings
                Dim cmd As New SqlCommand
                With cmd
                    .Connection = con
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM [DBConfig]"
                End With

                da.SelectCommand = cmd
                da.Fill(ds, "data")

                cmd.Connection.Close()

                Session("VRDBName") = ds.Tables("data").Rows(0).Item(3).ToString()
                Session("VoteDBName") = ds.Tables("data").Rows(1).Item(3).ToString()
                Response.Redirect("Default.aspx", False)
                Context.ApplicationInstance.CompleteRequest()

            Else
                lblError.Text = "Invalid credentials."
                Exit Sub
            End If

        Else
            lblError.Text = "Invalid credentials."
            Exit Sub
        End If


    End Sub
End Class