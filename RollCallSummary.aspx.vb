﻿Imports System.Data.SqlClient
Public Class RollCallSummary
    Inherits System.Web.UI.Page
    Public _YeaName As String
    Public _NayName As String
    Public _AbstainName As String
    Public _ExcName As String
    Public _AbsentName As String
    Public _NVName As String
    Public _CurrentSession As String
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
                ckYea2.Checked = True
            Else
                ckYea2.Visible = False
                l1.Visible = False
            End If

            If UseNay = True Then
                ckNay2.Checked = True
            Else
                ckNay2.Visible = False
                l2.Visible = False
            End If

            If UseAbstain = True Then
                ckAbstain2.Checked = True
            Else
                ckAbstain2.Visible = False
                l3.Visible = False
            End If

            If UseExcused = True Then
                ckExc2.Checked = True
            Else
                ckExc2.Visible = False
                l4.Visible = False
            End If

            If useAbsent = True Then
                ckAbsent2.Checked = True
            Else
                ckAbsent2.Visible = False
                l5.Visible = False
            End If

            If useNV = True Then
                ckNV2.Checked = True
            Else
                ckNV2.Visible = False
                l6.Visible = False
            End If
        Else
            Response.Redirect("NotConfigured.html")
        End If

       

    End Sub

End Class