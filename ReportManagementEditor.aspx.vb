Imports System.Data.SqlClient
Public Class ReportManagementEditor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim sqltext As String = "SELECT * FROM UserTypes"
        Dim da As New SqlDataAdapter(sqltext, con)
        Dim dt As New DataTable

        da.Fill(dt)
        ddlAccessLevel.DataSource = dt
        ddlAccessLevel.DataTextField = "Type"
        ddlAccessLevel.DataValueField = "ID"
        ddlAccessLevel.DataBind()
        ddlAccessLevel.Items.Insert(0, New ListItem("---", "Default"))

        If Session("ReportJustEdited") = "Yes" Then
            'do something
            successMsg.InnerText = "Changes saved successfully!"
            Session("ReportJustEdited") = "Default"
        ElseIf Session("ReportJustEdited") = "Failed" Then
            successMsg.InnerText = "Something went wrong. Changes were not saved."
            successMsg.Attributes.CssStyle.Add("color", "red")
            Session("ReportJustEdited") = "Default"
        Else
            successMsg.InnerText = ""
            Session("ReportJustEdited") = "Default"
        End If

    End Sub

End Class