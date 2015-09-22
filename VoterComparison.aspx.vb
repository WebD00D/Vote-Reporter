Imports System.Data.SqlClient
Public Class VoterComparison
    Inherits System.Web.UI.Page

    Public _YeaName As String
    Public _NayName As String
    Public _AbstainName As String
    Public _ExcName As String
    Public _AbsentName As String
    Public _NVName As String

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

        'If UseYea = True Then
        '    ckYea.Checked = True
        'Else
        '    ckYea.Visible = False
        '    l1.Visible = False
        'End If

        'If UseNay = True Then
        '    ckNay.Checked = True
        'Else
        '    ckNay.Visible = False
        '    l2.Visible = False
        'End If

        'If UseAbstain = True Then
        '    ckAbstain.Checked = True
        'Else
        '    ckAbstain.Visible = False
        '    l3.Visible = False
        'End If

        'If UseExcused = True Then
        '    ckExc.Checked = True
        'Else
        '    ckExc.Visible = False
        '    l4.Visible = False
        'End If

        'If useAbsent = True Then
        '    ckAbsent.Checked = True
        'Else
        '    ckAbsent.Visible = False
        '    l5.Visible = False
        'End If

        'If useNV = True Then
        '    ckNV.Checked = True
        'Else
        '    ckNV.Visible = False
        '    l6.Visible = False
        'End If
    End Sub

End Class