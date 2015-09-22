Imports System.Data.SqlClient
Public Class VoterDetails
    Inherits System.Web.UI.Page

    Public _YeaName As String
    Public _NayName As String
    Public _AbstainName As String
    Public _ExcName As String
    Public _AbsentName As String
    Public _NVName As String
    Public _CurrentSession As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Using cmd

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetVoteMappings"
            cmd.Connection = con
            cmd.Connection.Open()

            Using da
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using

            cmd.Connection.Close()

        End Using

        _YeaName = dt.Rows(0).Item(3)
        _NayName = dt.Rows(1).Item(3)
        _AbstainName = dt.Rows(2).Item(3)
        _ExcName = dt.Rows(3).Item(3)
        _AbsentName = dt.Rows(4).Item(3)
        _NVName = dt.Rows(5).Item(3)

        Dim UseYea As Boolean = dt.Rows(0).Item(4)
        Dim UseNay As Boolean = dt.Rows(1).Item(4)
        Dim UseAbstain As Boolean = dt.Rows(2).Item(4)
        Dim UseExcused As Boolean = dt.Rows(3).Item(4)
        Dim useAbsent As Boolean = dt.Rows(4).Item(4)
        Dim useNV As Boolean = dt.Rows(5).Item(4)

        If UseYea = True Then
            ckYea.Checked = True
        Else
            ckYea.Visible = False
            l1.Visible = False
        End If

        If UseNay = True Then
            ckNay.Checked = True
        Else
            ckNay.Visible = False
            l2.Visible = False
        End If

        If UseAbstain = True Then
            ckAbstain.Checked = True
        Else
            ckAbstain.Visible = False
            l3.Visible = False
        End If

        If UseExcused = True Then
            ckExc.Checked = True
        Else
            ckExc.Visible = False
            l4.Visible = False
        End If

        If useAbsent = True Then
            ckAbsent.Checked = True
        Else
            ckAbsent.Visible = False
            l5.Visible = False
        End If

        If useNV = True Then
            ckNV.Checked = True
        Else
            ckNV.Visible = False
            l6.Visible = False
        End If

        ''fill drop down list
        'Using cmd
        '    cmd.Connection = con
        '    cmd.Connection.Open()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = "sp_VRGetVoteDates"
        '    cmd.Parameters.AddWithValue("@sessionCode", Session("SessionCode"))
        '    cmd.Connection.Close()

        '    Dim DateDataTable As New DataTable
        '    Using da
        '        da.SelectCommand = cmd
        '        da.Fill(DateDataTable)
        '        ddlBeginDate.DataSource = DateDataTable
        '        ddlEndDate.DataSource = DateDataTable
        '        ddlBeginDate.DataValueField = "VoteDates"
        '        ddlBeginDate.DataTextField = "VoteDates"
        '        ddlEndDate.DataValueField = "VoteDates"
        '        ddlEndDate.DataTextField = "VoteDates"
        '        ddlBeginDate.DataBind()
        '        ddlEndDate.DataBind()
        '        ddlBeginDate.Items.Insert(0, New ListItem("", ""))
        '        ddlEndDate.Items.Insert(0, New ListItem("", ""))



        '    End Using



        'End Using









        _CurrentSession = Session("SessionCode")

    End Sub

End Class