﻿Imports System.Data.SqlClient
Public Class RVMemberAttendance_Optional
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim SessionCode As String = VoteReporter.Item(0).currentSessionCode
        Dim Members As String = Session("AttendanceMembers")
        Dim StartDate As String = Session("atn_StartDate")
        Dim EndDate As String = Session("atn_EndDate")

        Dim strStartDate As String = String.Empty
        Dim strEndDate As String = String.Empty

        If Not StartDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(StartDate)) = True Then
                StartDate = CDate(Session("atn_StartDate"))
                strStartDate = CStr(StartDate)
            Else
                strStartDate = "01/01/1900"
            End If
        Else
            strStartDate = "01/01/1900"
        End If
        Dim Today As String = CStr(Date.Today)
        If Not EndDate = String.Empty Then
            'Validate Dates
            If IsDate(CDate(EndDate)) = True Then
                EndDate = CDate(Session("atn_EndDate"))
                strEndDate = CStr(EndDate + " 23:59:59")
            Else
                strEndDate = Today + " 23:59:59"
            End If
        Else
            strEndDate = Today + " 23:59:59"
        End If

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable


        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SessionID", VoteReporter.Item(0).currentSessionID)
            cmd.CommandText = "sp_VRGetReportConfigParams"

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_VRGetReportConfigParams")
            End Using
            cmd.Connection.Close()
        End Using

        ' Get Report Type Details
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_GetTypeDetails"
            cmd.Parameters.AddWithValue("@TypeID", 7)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_Report_GetTypeDetails")
            End Using

            cmd.Connection.Close()
        End Using

        ' Get Attendance Data
        Using cmd As New SqlCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Report_VoterAttendance"
            cmd.Parameters.AddWithValue("@Members", Members)
            cmd.Parameters.AddWithValue("@SessionCode", SessionCode)
            cmd.Parameters.AddWithValue("@StartDate", strStartDate)
            cmd.Parameters.AddWithValue("@EndDate", strEndDate)

            Using da
                da.SelectCommand = cmd
                da.Fill(ds, "sp_Report_VoterAttendance")

                If ds.Tables("sp_Report_VoterAttendance").Rows.Count = 0 Then
                    Dim drEmptyRow As DataRow = ds.Tables("sp_Report_VoterAttendance").NewRow

                    ds.Tables("sp_Report_VoterAttendance").Rows.InsertAt(drEmptyRow, 0)
                    ds.Tables("sp_Report_VoterAttendance").AcceptChanges()
                End If


            End Using

            cmd.Connection.Close()
        End Using

        MemberAttendanceOptionalViewer.Report = CreateReport(ds)
        MemberAttendanceOptionalViewer.DataBind()
    End Sub

    Private Function CreateReport(ByVal ds As DataSet) As XRMemberAttendance_Optional

        Dim VoteReporter As New List(Of Engine.clsVoteReporter)
        VoteReporter = Session("clsVoteReporter")

        Dim report As New XRMemberAttendance_Optional()
        report.DataSource = ds

        report.BeginInit()
        report.lblSession.Text = VoteReporter.Item(0).currentSessionLegislature

        report.lblPrintDate.Text = Date.Now.ToString()

        If Session("atn_StartDate").ToString = String.Empty Then
            report.lblBeginDate.Text = Session("SessionStarted").ToString()
        Else
            report.lblBeginDate.Text = Session("atn_StartDate")
        End If

        If Session("atn_EndDate").ToString = String.Empty Then
            report.lblEndDate.Text = Session("SessionEnded").ToString()
        Else
            report.lblEndDate.Text = Session("atn_EndDate")
        End If

        report.EndInit()

        report.CreateDocument()
        Return report
    End Function

End Class