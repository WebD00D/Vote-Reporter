Imports System.Data.SqlClient
Public Class UserManagementEditor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim sqltext As String = "SELECT * FROM UserTypes"
        Dim da As New SqlDataAdapter(sqltext, con)
        Dim dt As New DataTable

        da.Fill(dt)
        ddlUserType.DataSource = dt
        ddlUserType.DataTextField = "Type"
        ddlUserType.DataValueField = "ID"
        ddlUserType.DataBind()
        ddlUserType.Items.Insert(0, New ListItem("---", "Default"))

        da.Dispose()
        dt.Clear()

        'sqltext = "SELECT * FROM Chamber"
        'da = New SqlDataAdapter(sqltext, con)
        'da.Fill(dt)

        'ddlChamber.DataSource = dt
        'ddlChamber.DataTextField = "Chamber"
        'ddlChamber.DataValueField = "ChamberCode"
        'ddlChamber.DataBind()
        'ddlChamber.Items.Insert(0, New ListItem("---", "Default"))


        'If Session("NewUserCreated") = 1 Then
        '    lblSuccess.InnerText = "User successfully created!"
        '    Session("NewUserCreated") = -1
        'ElseIf Session("NewUserCreated") = 0 Then
        '    lblSuccess.InnerText = "Something went wrong. User not created."
        '    lblSuccess.Attributes.CssStyle.Add("color", "red")
        '    Session("NewUserCreated") = -1
        'End If



    End Sub

End Class