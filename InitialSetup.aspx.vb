Imports System.Xml
Imports System.Data.SqlClient
Public Class InitialSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub Unnamed5_Click(sender As Object, e As EventArgs) Handles btnFinish.Click


        If txtVRDBName.Text.Trim = String.Empty Or txtVRDBServer.Text.Trim = String.Empty Or txtVRDBUser.Text.Trim = String.Empty Or txtVRDBPassword.Text.Trim = String.Empty Or txtVoteDBName.Text.Trim = String.Empty Or txtVoteServer.Text.Trim = String.Empty Or txtVoteUser.Text.Trim = String.Empty Or txtVotePassword.Text.Trim = String.Empty Then

            lblError.Text = "Please make sure to fill in all fields."
            Exit Sub
        Else


            Dim path As String = Server.MapPath("~/Web.Config")
            Dim doc As New XmlDocument()
            doc.Load(path)
            Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("connectionStrings/add[@name='{0}']", "VRDB"))
            Dim node As XmlNode
            node = list(0)

            Dim conString As String = node.Attributes("connectionString").Value
            Dim conStringBuilder As New SqlConnectionStringBuilder(conString)
            conStringBuilder.InitialCatalog = txtVRDBName.Text
            conStringBuilder.DataSource = txtVRDBServer.Text
            conStringBuilder.IntegratedSecurity = False
            conStringBuilder.UserID = txtVRDBUser.Text
            conStringBuilder.Password = txtVRDBPassword.Text
            node.Attributes("connectionString").Value = conStringBuilder.ConnectionString

            Try
                doc.Save(path) 'save vote reporter 
            Catch ex As Exception
                lblError.Text = "Something went wrong while updating connection string. Please contact support."
            End Try


            Try
                Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
                Dim cmd As New SqlCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sp_VRSetVRDBConnection"
                    .Connection = con
                    .Parameters.AddWithValue("@VRDBServer", txtVRDBServer.Text)
                    .Parameters.AddWithValue("@VRDBName", txtVRDBName.Text)
                    .Parameters.AddWithValue("@VRDBUser", txtVRDBUser.Text)
                    .Parameters.AddWithValue("@VRDBPass", txtVRDBPassword.Text)
                    .Connection.Open()
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With
            Catch ex As Exception
                lblError.Text = "Something went wrong while saving to the database. Please contact support."
                Exit Sub
            End Try



            conStringBuilder.Clear()


            path = Server.MapPath("~/Web.Config")
            doc.Load(path)
            list = doc.DocumentElement.SelectNodes(String.Format("connectionStrings/add[@name='{0}']", "VoteDB"))
            node = list(0)

            conString = node.Attributes("connectionString").Value
            conStringBuilder.InitialCatalog = txtVoteDBName.Text
            conStringBuilder.DataSource = txtVoteServer.Text
            conStringBuilder.IntegratedSecurity = False
            conStringBuilder.UserID = txtVoteUser.Text
            conStringBuilder.Password = txtVotePassword.Text
            node.Attributes("connectionString").Value = conStringBuilder.ConnectionString

            Try
                doc.Save(path)
            Catch ex As Exception
                lblError.Text = "Something went wrong while updating connection string. Please contact support."
            End Try

            'save connection string info in database and create Synoynms for sync table
            Try
                Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
                Dim cmd As New SqlCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sp_VRSetVoteDBConnection"
                    .Connection = con
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@VoteDBServer", txtVoteServer.Text)
                    .Parameters.AddWithValue("@VoteDBName", txtVoteDBName.Text)
                    .Parameters.AddWithValue("@VoteDBUser", txtVoteUser.Text)
                    .Parameters.AddWithValue("@VoteDBPass", txtVotePassword.Text)
                    .Connection.Open()
                    .ExecuteNonQuery()
                    .Connection.Close()

                End With
            Catch ex As Exception
                lblError.Text = "Something went wrong while saving to the database. Please contact support."
                Exit Sub
            End Try

            Response.Redirect("Login.aspx", False)
            Context.ApplicationInstance.CompleteRequest()

        End If





    End Sub
End Class