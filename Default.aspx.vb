Imports System
Imports System.Data.SqlClient
Public Class _Default
    Inherits System.Web.UI.Page

    Public _RCTranscript As String
    Public _RCSummary As String
    Public _RCDetails As String
    Public _VoterDetails As String
    Public _VoterStats As String
    Public _VoterComparison As String
    Public _MemberAttendance As String

    Public cRCTranscript As String = String.Empty
    Public cRCSummary As String = String.Empty
    Public cRCDetails As String = String.Empty
    Public cVDetails As String = String.Empty
    Public cVStats As String = String.Empty
    Public cVComp As String = String.Empty
    Public cMAttendance As String = String.Empty



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Get Settings for each page

        

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Dim cmd As New SqlCommand
        Using cmd
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_VRGetReportSecurityDetails"
            cmd.Connection.Open()
        End Using

        da.SelectCommand = cmd
        da.Fill(dt)

        con.Close()

        ' 1 - admin  2 - standard 3- public
        Dim Permission As Integer = Session("Access")

        If Permission > 1 Then
            adminSection.Visible = False
        End If



        Dim VoterStat As Integer = dt.Rows(3).Item("AccessLevel")
        Dim VoterDetail As Integer = dt.Rows(2).Item("AccessLevel")
        Dim VoterComparison As Integer = dt.Rows(4).Item("AccessLevel")
        Dim RCHistory As Integer = dt.Rows(1).Item("AccessLevel")
        Dim RCTranscript As Integer = dt.Rows(0).Item("AccessLevel")
        ' Dim RCDetails As Integer = dt.Rows(2).Item("AccessLevel")
        Dim MemberAttendance As Integer = dt.Rows(5).Item("AccessLevel")

        lnkVoterStats.Enabled = GetPermission(Permission, VoterStat)
        lnkVoterDetails.Enabled = GetPermission(Permission, VoterDetail)
        lnkVoterComp.Enabled = GetPermission(Permission, VoterComparison)
        '   lnkRCDet.Enabled = GetPermission(Permission, RCDetails)
        lnkRCTrans.Enabled = GetPermission(Permission, RCTranscript)
        lnkRCSum.Enabled = GetPermission(Permission, RCHistory)
        lnkMemberAttendance.Enabled = GetPermission(Permission, MemberAttendance)

        If lnkMemberAttendance.Enabled = False Then
            lnkMemberAttendance.Visible = False
            iAtt.Visible = False
        End If


        If lnkVoterStats.Enabled = False Then
            lnkVoterStats.ForeColor = Drawing.Color.LightGray
            lnkVoterStats.Visible = False
            ivstats.Visible = False
        End If

        If lnkVoterDetails.Enabled = False Then
            lnkVoterDetails.ForeColor = Drawing.Color.LightGray
            lnkVoterDetails.Visible = False
            ivdet.Visible = False
        End If

        If lnkVoterComp.Enabled = False Then
            lnkVoterComp.ForeColor = Drawing.Color.LightGray
            lnkVoterComp.Visible = False
            ivcomp.Visible = False
        End If

        If lnkRCTrans.Enabled = False Then
            lnkRCTrans.ForeColor = Drawing.Color.LightGray
            lnkRCTrans.Visible = False
            irctrans.Visible = False
        End If

        If lnkRCSum.Enabled = False Then
            lnkRCSum.ForeColor = Drawing.Color.LightGray
            lnkRCSum.Visible = False
            ircsum.Visible = False
        End If


        'Get Report Names for Main Screen

        _VoterStats = dt.Rows(3).Item(2)
        _VoterDetails = dt.Rows(2).Item(2)
        _VoterComparison = dt.Rows(4).Item(2)
        _RCSummary = dt.Rows(1).Item(2)
        _RCTranscript = dt.Rows(0).Item(2)
        ' _RCDetails = dt.Rows(2).Item(2)
        _MemberAttendance = dt.Rows(5).Item(2)


        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM ReportTypes"
        End Using

        Dim da2 As New SqlDataAdapter(cmd)
        Dim dt2 As New DataTable
        da2.Fill(dt2)


        If dt2.Rows(5).Item(4) = 0 Then
            lnkMemberAttendance.CssClass = "hide"

        End If


        If dt2.Rows(0).Item(4) = 0 Then
            lnkRCTrans.CssClass = "hide"

        End If

        If dt2.Rows(1).Item(4) = 0 Then
            lnkRCSum.CssClass = "hide"

        End If

        'If dt2.Rows(2).Item(4) = 0 Then
        '    lnkRCDet.CssClass = "hide"

        'End If


        If dt2.Rows(2).Item(4) = 0 Then
            lnkVoterDetails.CssClass = "hide"

        End If


        If dt2.Rows(3).Item(4) = 0 Then
            lnkVoterStats.CssClass = "hide"
            lnkVoterStats.Visible = False

        End If

        If dt2.Rows(4).Item(4) = 0 Then
            lnkVoterComp.CssClass = "hide"

        End If





    End Sub








    Public Function GetPermission(ByVal UserPermission As Integer, ByVal MinAccessLevel As Integer)

        Dim PermissionGranted As Boolean = False

        If UserPermission <= MinAccessLevel Then
            PermissionGranted = True
        End If

        Return PermissionGranted

    End Function





End Class