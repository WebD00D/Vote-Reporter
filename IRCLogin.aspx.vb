Public Class IRCLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

 
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If txtUsername.Text = "IRCAdmin" And txtPassword.Text = "1234" Then
            Response.Redirect("InitialSetup.aspx", False)
            Context.ApplicationInstance.CompleteRequest()
        Else
            lblError.Text = "Invalid Credentials."

        End If



    End Sub
End Class