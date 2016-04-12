Imports System
Imports System.Xml
Imports System.Data.SqlClient
Public Class Configuration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        

        GenericErrorLabel.InnerText = String.Empty

        If Not Page.IsPostBack Then
            'Try
            '    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)


            '    Dim cmd As New SqlCommand
            '    With cmd
            '        .CommandType = CommandType.Text
            '        .CommandText = "sp_VRGetDataConnnections"
            '        .Connection = con
            '    End With
            '    Dim da As New SqlDataAdapter(cmd)
            '    Dim dt As New DataTable
            '    da.Fill(dt)

            '    txtVRDBServer.Value = dt.Rows(0).Item(2).ToString()
            '    txtVRDBName.Value = dt.Rows(0).Item(3).ToString()
            '    txtVRDBUser.Value = dt.Rows(0).Item(4).ToString()
            '    txtVRDBPass.Value = dt.Rows(0).Item(5).ToString()
            '    txtVoteDBServer.Value = dt.Rows(1).Item(2).ToString()
            '    txtVoteDBName.Value = dt.Rows(1).Item(3).ToString()
            '    txtVoteDBUser.Value = dt.Rows(1).Item(4).ToString()
            '    txtVoteDBPass.Value = dt.Rows(1).Item(5).ToString()
            'Catch ex As Exception
            '    GenericErrorLabel.InnerText = "Error loading custom settings. Please contact support."
            'End Try


            'Try
            '    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            '    Dim cmd As New SqlCommand
            '    With cmd
            '        .CommandType = CommandType.Text
            '        .CommandText = "sp_VRGetVoteMappings"
            '        .Connection = con
            '    End With
            '    Dim da As New SqlDataAdapter(cmd)
            '    Dim dt As New DataTable
            '    da.Fill(dt)


            '    Dim ckABSTAIN_enabled As Byte = dt.Rows(2).Item(2)
            '    If CBool(ckABSTAIN_enabled) = True Then ckABS_Enabled.Checked = True Else ckABS_Enabled.Checked = False

            '    Dim ckEXCUSED_enabled As Byte = dt.Rows(3).Item(2)
            '    If CBool(ckEXCUSED_enabled) = True Then ckEXC_Enabled.Checked = True Else ckEXC_Enabled.Checked = False

            '    Dim ckbABSENT_enabled As Byte = dt.Rows(4).Item(2)
            '    If CBool(ckbABSENT_enabled) = True Then ckABSENT_Enabled.Checked = True Else ckABSENT_Enabled.Checked = False

            '    Dim ckbNV_enabled As Byte = dt.Rows(5).Item(2)
            '    If CBool(ckbNV_enabled) = True Then ckNV_Enabled.Checked = True Else ckNV_Enabled.Checked = False


            '    txtYEA_Name.Value = dt.Rows(0).Item(3).ToString()
            '    txtNAY_Name.Value = dt.Rows(1).Item(3).ToString()
            '    txtABS_Name.Value = dt.Rows(2).Item(3).ToString()
            '    txtEXC_Name.Value = dt.Rows(3).Item(3).ToString()
            '    txtABSENT_Name.Value = dt.Rows(4).Item(3)
            '    txtNV_Name.Value = dt.Rows(5).Item(3)


            '    txtYeaOrder.Value = dt.Rows(0).Item(9).ToString()
            '    txtNayOrder.Value = dt.Rows(1).Item(9).ToString()
            '    txtAbstainOrder.Value = dt.Rows(2).Item(9).ToString()
            '    txtExcOrder.Value = dt.Rows(3).Item(9).ToString()
            '    txtAbsentOrder.Value = dt.Rows(4).Item(9).ToString()
            '    txtNVOrder.Value = dt.Rows(5).Item(9).ToString()


            '    Dim ckABSTAIN_isUsed As Byte = dt.Rows(2).Item(4)
            '    If CBool(ckABSTAIN_isUsed) = True Then ckABS_IsUsed.Checked = True Else ckABS_IsUsed.Checked = False

            '    Dim ckEXCUSED_isUsed As Byte = dt.Rows(3).Item(4)
            '    If CBool(ckEXCUSED_isUsed) = True Then ckEXC_IsUsed.Checked = True Else ckEXC_IsUsed.Checked = False

            '    Dim ckbABSENT_isUsed As Byte = dt.Rows(4).Item(4)
            '    If CBool(ckbABSENT_isUsed) = True Then ckABSENT_IsUsed.Checked = True Else ckABSENT_IsUsed.Checked = False

            '    Dim ckbNV_isUsed As Byte = dt.Rows(5).Item(4)
            '    If CBool(ckbNV_isUsed) = True Then ckNV_IsUsed.Checked = True Else ckNV_IsUsed.Checked = False


            '    Dim ckABSTAIN_isEligible As Byte = dt.Rows(2).Item(5)
            '    If CBool(ckABSTAIN_isEligible) = True Then ckABS_IsEligible.Checked = True Else ckABS_IsEligible.Checked = False

            '    Dim ckEXCUSED_isEligible As Byte = dt.Rows(3).Item(5)
            '    If CBool(ckEXCUSED_isEligible) = True Then ckEXC_IsEligible.Checked = True Else ckEXC_IsEligible.Checked = False

            '    Dim ckbABSENT_isEligible As Byte = dt.Rows(4).Item(5)
            '    If CBool(ckbABSENT_isEligible) = True Then ckABSENT_IsEligible.Checked = True Else ckABSENT_IsEligible.Checked = False

            '    Dim ckbNV_isEligible As Byte = dt.Rows(5).Item(5)
            '    If CBool(ckbNV_isEligible) = True Then ckNV_IsEnabled.Checked = True Else ckNV_IsEnabled.Checked = False


            '    ' Load Saved Report Parameters


            '    Dim con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            '    Dim cmd2 As New SqlCommand
            '    With cmd2
            '        .Connection = con2
            '        .CommandType = CommandType.StoredProcedure
            '        .CommandText = "sp_VRGetReportConfigParams"
            '        .Connection.Open()
            '        .ExecuteNonQuery()
            '        .Connection.Close()
            '    End With

            '    Dim da2 As New SqlDataAdapter(cmd2)
            '    Dim dt2 As New DataTable
            '    da2.Fill(dt2)

            '    txtGovName.Value = dt2.Rows(0).Item(1).ToString()
            '    txtLegName.Value = dt2.Rows(0).Item(2).ToString()

            '    link1name.Value = dt2.Rows(0).Item(3).ToString()
            '    link1url.Value = dt2.Rows(0).Item(4).ToString()
            '    link2name.Value = dt2.Rows(0).Item(5).ToString()
            '    link2url.Value = dt2.Rows(0).Item(6).ToString()
            '    link3name.Value = dt2.Rows(0).Item(7).ToString()
            '    link3url.Value = dt2.Rows(0).Item(8).ToString()

            '    txtRCS.Value = dt2.Rows(0).Item(9).ToString()
            '    txtBillNbr.Value = dt2.Rows(0).Item(10).ToString()
            '    txtMotion.Value = dt2.Rows(0).Item(11).ToString()
            '    txtDateTime.Value = dt2.Rows(0).Item(12).ToString()
            '    txtVoteTot.Value = dt2.Rows(0).Item(13).ToString()
            '    txtResults.Value = dt2.Rows(0).Item(14).ToString()
            '    txtOutcome.Value = dt2.Rows(0).Item(15).ToString()
            '    txtPartyTotals.Value = dt2.Rows(0).Item(16).ToString()
            '    txtMember.Value = dt2.Rows(0).Item(17).ToString()
            '    txtDistrictName.Value = dt2.Rows(0).Item(18).ToString()
            '    txtDistrictNbr.Value = dt2.Rows(0).Item(19).ToString()

            '    txtPO1Name.Value = dt2.Rows(0).Item(20).ToString()
            '    txtPO1Title.Value = dt2.Rows(0).Item(21).ToString()
            '    txtPO2Name.Value = dt2.Rows(0).Item(22).ToString()
            '    txtPO2title.Value = dt2.Rows(0).Item(23).ToString()
            '    txtClerkName.Value = dt2.Rows(0).Item(24).ToString()
            '    txtClerkTitle.Value = dt2.Rows(0).Item(25).ToString()

            '    ddlMotion1.SelectedValue = dt2.Rows(0).Item(28)
            '    ddlSubjects1.SelectedValue = dt2.Rows(0).Item(35)
            '    If dt2.Rows(0).Item(36) = 0 Then
            '        ddlSubjects2.SelectedValue = "Default"
            '    Else
            '        ddlSubjects2.SelectedValue = dt2.Rows(0).Item(36)
            '    End If

            '    Dim img1Byte As Byte() = DirectCast(dt2.Rows(0).Item(26), Byte())
            '    Dim img2Byte As Byte() = DirectCast(dt2.Rows(0).Item(27), Byte())
            '    Dim img1String As String = String.Empty
            '    Dim img2String As String = String.Empty

            '    If dt2.Rows(0).Item(29) = True Then 'Show district name

            '        rbDName.Checked = True
            '        rbDNbr.Checked = False

            '    Else 'show district Number

            '        rbDName.Checked = False
            '        rbDNbr.Checked = True

            '    End If

            '    If dt2.Rows(0).Item(32) = True Then
            '        ckShowMbrStat.Checked = True
            '    End If
            '    If dt2.Rows(0).Item(33) = True Then
            '        ckShowPartyStat.Checked = True
            '    End If
            '    If dt2.Rows(0).Item(34) = True Then
            '        ckShowVoteTtl.Checked = True
            '    End If



            'If img1Byte.Length = 0 Then
            '    imagePreview1.Visible = False
            'Else
            '    img1String = Convert.ToBase64String(img1Byte, 0, img1Byte.Length)
            '    imagePreview1.Src = "data:image/png;base64," & img1String
            'End If

            'If img2Byte.Length = 0 Then
            '    imagePreview2.Visible = False
            'Else
            '    img2String = Convert.ToBase64String(img2Byte, 0, img2Byte.Length)
            '    imagePreview2.Src = "data:image/png;base64," & img2String
            'End If


            'Catch ex As Exception
            '    GenericErrorLabel.InnerText = "Error loading custom settings. Please contact support."
            'End Try

            Session("IsReload") = False

        End If







    End Sub

    Public Function ReturnDataTable(ByVal cmdtext As String, ByVal cmdType As System.Data.CommandType, ByVal oParm As List(Of SqlParameter))
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable
        Using cmd As SqlCommand = con.CreateCommand
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandType = cmdType
            cmd.CommandText = cmdtext

            If oParm IsNot Nothing Then cmd.Parameters.AddRange(oParm.ToArray())

            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)
            End Using
            cmd.Connection.Close()
        End Using
        Return dt
    End Function

    Public Sub UpdateSavedSessionDetails()

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim dt As New DataTable


        Dim CurrentSessionDetails As New Engine.clsVoteReporter
        Dim SessionDetailsList As New List(Of Engine.clsVoteReporter)
        SessionDetailsList = Session("clsVoteReporter")
        Dim CurrentSessionID As Integer = SessionDetailsList.Item(0).currentSessionID

        Dim oParmList As List(Of SqlParameter) = New List(Of SqlParameter)
        oParmList.Add(New SqlParameter("@SessionID", CurrentSessionID))
        dt = ReturnDataTable("sp_VRGetReportConfigParams", CommandType.StoredProcedure, oParmList)

        SessionDetailsList.Item(0).link1Name = dt.Rows(0).Item("Link1_Name")
        SessionDetailsList.Item(0).link1URL = dt.Rows(0).Item("Link1_URL")
        SessionDetailsList.Item(0).link2Name = dt.Rows(0).Item("Link2_Name")
        SessionDetailsList.Item(0).link2URL = dt.Rows(0).Item("Link2_URL")
        SessionDetailsList.Item(0).link3Name = dt.Rows(0).Item("Link3_Name")
        SessionDetailsList.Item(0).link3URL = dt.Rows(0).Item("Link3_URL")
        SessionDetailsList.Item(0).siteTitle = dt.Rows(0).Item("Government_Name")
        SessionDetailsList.Item(0).governmentName = dt.Rows(0).Item("Government_Name")
        SessionDetailsList.Item(0).legislatureName = dt.Rows(0).Item("Legislature_Name")
        SessionDetailsList.Item(0).rcsNbrTitle = dt.Rows(0).Item("RSCNumber")
        SessionDetailsList.Item(0).billNbrTitle = dt.Rows(0).Item("BillNumber")
        SessionDetailsList.Item(0).motionTitle = dt.Rows(0).Item("Motion")
        SessionDetailsList.Item(0).motionDataField = dt.Rows(0).Item("MotionDataField")
        SessionDetailsList.Item(0).subjectDataField1 = dt.Rows(0).Item("SubjectField1")
        SessionDetailsList.Item(0).subjectDataField2 = dt.Rows(0).Item("SubjectField2")
        SessionDetailsList.Item(0).dateTimeTitle = dt.Rows(0).Item("DateTime")
        SessionDetailsList.Item(0).voteTotalTitle = dt.Rows(0).Item("VoteTotals")
        SessionDetailsList.Item(0).resultsTitle = dt.Rows(0).Item("Results")
        SessionDetailsList.Item(0).outcomeTitle = dt.Rows(0).Item("Outcome")
        SessionDetailsList.Item(0).partyTotalsTitle = dt.Rows(0).Item("PartyTotals")
        SessionDetailsList.Item(0).memberTitle = dt.Rows(0).Item("Member")
        SessionDetailsList.Item(0).districtNameTitle = dt.Rows(0).Item("DistrictName")
        SessionDetailsList.Item(0).districtNbrTitle = dt.Rows(0).Item("DistrictNumber")
        SessionDetailsList.Item(0).presidingOfficer1Name = dt.Rows(0).Item("Presiding_Name_1")
        SessionDetailsList.Item(0).presidingOfficer1Title = dt.Rows(0).Item("Presiding_Title_1")
        SessionDetailsList.Item(0).presidingOfficer2Name = dt.Rows(0).Item("Presiding_Name_2")
        SessionDetailsList.Item(0).presidingOfficer2Title = dt.Rows(0).Item("Presiding_Title_2")
        SessionDetailsList.Item(0).clerkSecretaryName = dt.Rows(0).Item("Clerk_Secretary_Name")
        SessionDetailsList.Item(0).clerkSecretaryTitle = dt.Rows(0).Item("Clerk_Secretary_Title")
        SessionDetailsList.Item(0).showDistrictName = CBool(dt.Rows(0).Item("showDistrictName"))
        SessionDetailsList.Item(0).showDistrictNbr = CBool(dt.Rows(0).Item("showDistrictNbr"))
        SessionDetailsList.Item(0).showMajorityStats = CBool(dt.Rows(0).Item("showMajorityStats"))
        SessionDetailsList.Item(0).showPartyStats = CBool(dt.Rows(0).Item("ShowPartyStats"))
        SessionDetailsList.Item(0).showVotingStats = CBool(dt.Rows(0).Item("ShowVotingStats"))
        SessionDetailsList.Item(0).showOptionalAttendance = CBool(dt.Rows(0).Item("ShowOptionalAttendance"))
        SessionDetailsList.Item(0).showOptionalStats = CBool(dt.Rows(0).Item("ShowOptionalStats"))
        ' SessionDetailsList.Item(0).includeShortTitle = CBool(dt.Rows(0).Item("IncludeShortTitle"))
        SessionDetailsList.Item(0).showOptionalPartyTotals = CBool(dt.Rows(0).Item("ShowOptionalPartyTotals"))

        dt.Clear()

        Dim oParmList2 As List(Of SqlParameter) = New List(Of SqlParameter)
        oParmList2.Add(New SqlParameter("@SessionID", CurrentSessionID))
        dt = ReturnDataTable("sp_VRGetVoteMappings", CommandType.StoredProcedure, oParmList2)

        SessionDetailsList.Item(0).yeaEnabled = CBool(dt.Rows(0).Item("Enabled"))
        SessionDetailsList.Item(0).yeaNamesAs = dt.Rows(0).Item("Named_As")
        SessionDetailsList.Item(0).yeaIsUsed = CBool(dt.Rows(0).Item("IsUsed"))
        SessionDetailsList.Item(0).yeaIsEligible = CBool(dt.Rows(0).Item("isEligible"))
        SessionDetailsList.Item(0).yeaHeaderOrder = dt.Rows(0).Item("Header_Order")

        SessionDetailsList.Item(0).nayEnabled = CBool(dt.Rows(1).Item("Enabled"))
        SessionDetailsList.Item(0).nayNamesAs = dt.Rows(1).Item("Named_As")
        SessionDetailsList.Item(0).nayIsUsed = CBool(dt.Rows(1).Item("IsUsed"))
        SessionDetailsList.Item(0).nayIsEligible = CBool(dt.Rows(1).Item("isEligible"))
        SessionDetailsList.Item(0).nayHeaderOrder = dt.Rows(1).Item("Header_Order")

        SessionDetailsList.Item(0).abstainEnabled = CBool(dt.Rows(2).Item("Enabled"))
        SessionDetailsList.Item(0).abstainNamesAs = dt.Rows(2).Item("Named_As")
        SessionDetailsList.Item(0).abstainIsUsed = CBool(dt.Rows(2).Item("IsUsed"))
        SessionDetailsList.Item(0).abstainIsEligible = CBool(dt.Rows(2).Item("isEligible"))
        SessionDetailsList.Item(0).abstainHeaderOrder = dt.Rows(2).Item("Header_Order")

        SessionDetailsList.Item(0).excusedEnabled = CBool(dt.Rows(3).Item("Enabled"))
        SessionDetailsList.Item(0).excusedNamesAs = dt.Rows(3).Item("Named_As")
        SessionDetailsList.Item(0).excusedIsUsed = CBool(dt.Rows(3).Item("IsUsed"))
        SessionDetailsList.Item(0).excusedIsEligible = CBool(dt.Rows(3).Item("isEligible"))
        SessionDetailsList.Item(0).excusedHeaderOrder = dt.Rows(3).Item("Header_Order")

        SessionDetailsList.Item(0).absentEnabled = CBool(dt.Rows(4).Item("Enabled"))
        SessionDetailsList.Item(0).absentNamesAs = dt.Rows(4).Item("Named_As")
        SessionDetailsList.Item(0).absentIsUsed = CBool(dt.Rows(4).Item("IsUsed"))
        SessionDetailsList.Item(0).absentIsEligible = CBool(dt.Rows(4).Item("isEligible"))
        SessionDetailsList.Item(0).absentHeaderOrder = dt.Rows(4).Item("Header_Order")

        SessionDetailsList.Item(0).notVotingEnabled = CBool(dt.Rows(5).Item("Enabled"))
        SessionDetailsList.Item(0).notVotingNamesAs = dt.Rows(5).Item("Named_As")
        SessionDetailsList.Item(0).notVotingIsUsed = CBool(dt.Rows(5).Item("IsUsed"))
        SessionDetailsList.Item(0).notVotingIsEligible = CBool(dt.Rows(5).Item("isEligible"))
        SessionDetailsList.Item(0).notVotingHeaderOrder = dt.Rows(5).Item("Header_Order")


        Session("clsVoteReporter") = SessionDetailsList

    
    End Sub


    Protected Sub btnSaveAllConfigSettings_Click(sender As Object, e As EventArgs) Handles btnSaveAllConfigSettings.Click

        If Not validateAccountSettings() Then
            If Not validateReportParameters() Then
                If validateVoteMappings() Then
                    lblConfigurationErrorMessage.Text = "Please make sure all fields are completed, and a numerical sort order has been set in 'Vote Mapping'."
                    Exit Sub
                Else
                    'everything has been validated so we should be good to save everything
                    saveConfigurationSettings()
                    'update session information
                    UpdateSavedSessionDetails()
                    Response.Redirect("Default.aspx")
                    ' Context.ApplicationInstance.CompleteRequest()
                End If
            Else
                lblConfigurationErrorMessage.Text = "Please make sure all fields are completed in 'Report Parameters'."
                Exit Sub
            End If
        Else
            lblConfigurationErrorMessage.Text = "Please make sure all fields are completed in 'Account Settings'."
            Exit Sub
        End If

    End Sub

    Public Sub saveConfigurationSettings()

        Dim VRList As List(Of Engine.clsVoteReporter) = Session("clsVoteReporter")


        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand


        'Need to check if Session has been created first.. 

        Dim CheckTable As New DataTable

        Using cmd
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandText = "SELECT * FROM VRConfiguration WHERE SessionID =" & VRList.Item(0).currentSessionID
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(CheckTable)
            End Using
            cmd.Connection.Close()
        End Using

        Dim NewInsert = True
        If CheckTable.Rows.Count > 0 Then
            NewInsert = False
        End If


        Try  'Save site settings
            Using cmd
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetAccountParams"
                cmd.Parameters.AddWithValue("@GovName", txtGovName.Text)
                cmd.Parameters.AddWithValue("@LegName", txtLegName.Text)
                cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)
                cmd.Parameters.AddWithValue("@IsNew", CByte(NewInsert))
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using

            VRList.Item(0).governmentName = txtGovName.Text
            VRList.Item(0).legislatureName = txtLegName.Text
            Session("clsVoteReporter") = VRList

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Account Settings' to the database. Please contact support."
            Exit Sub
        End Try


        Try 'Save UI
            Using cmd
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetUIParams"
                cmd.Parameters.AddWithValue("@MainImage", imguploader2.FileBytes)
                cmd.Parameters.AddWithValue("@SealImg ", imguploader1.FileBytes)
                cmd.Parameters.AddWithValue("@Link1Name", link1name.Value)
                cmd.Parameters.AddWithValue("@Link1URL ", link1url.Value)
                cmd.Parameters.AddWithValue("@Link2Name", link2name.Value)
                cmd.Parameters.AddWithValue("@Link2URL ", link2url.Value)
                cmd.Parameters.AddWithValue("@Link3Name", link3name.Value)
                cmd.Parameters.AddWithValue("@Link3URL ", link3url.Value)
                cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'User Interface settings' to the database. Please contact support."
            Exit Sub
        End Try

        Try 'Save report parameters

            Using cmd

                cmd.Connection = con
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetReportParams"
                cmd.Parameters.AddWithValue("@RSCNumber", txtRCS.Value)
                cmd.Parameters.AddWithValue("@BillNumber", txtBillNbr.Value)
                cmd.Parameters.AddWithValue("@Motion", txtMotion.Value)
                cmd.Parameters.AddWithValue("@DateTime", txtDateTime.Value)
                cmd.Parameters.AddWithValue("@VoteTotals", txtVoteTot.Value)
                cmd.Parameters.AddWithValue("@Results", txtResults.Value)
                cmd.Parameters.AddWithValue("@Outcome ", txtOutcome.Value)
                cmd.Parameters.AddWithValue("@PartyTotals", txtPartyTotals.Value)
                cmd.Parameters.AddWithValue("@Member", txtMember.Value)
                cmd.Parameters.AddWithValue("@DistrictName", txtDistrictName.Value)
                cmd.Parameters.AddWithValue("@DistrictNumber", txtDistrictNbr.Value)
                cmd.Parameters.AddWithValue("@Presiding_Name_1", txtPO1Name.Value)
                cmd.Parameters.AddWithValue("@Presiding_Title_1", txtPO1Title.Value)
                cmd.Parameters.AddWithValue("@Presiding_Name_2", txtPO2Name.Value)
                cmd.Parameters.AddWithValue("@Presiding_Title_2", txtPO2title.Value)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Name", txtClerkName.Value)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Title", txtClerkTitle.Value)
                cmd.Parameters.AddWithValue("@showDistrictName", CByte(rbDName.Checked))
                cmd.Parameters.AddWithValue("@showDistrictNumber", CByte(rbDNbr.Checked))
                cmd.Parameters.AddWithValue("@showMajorityStats", CByte(ckShowMbrStat.Checked))
                cmd.Parameters.AddWithValue("@showPartyStats", CByte(ckShowPartyStat.Checked))
                cmd.Parameters.AddWithValue("@showVotingStats", CByte(ckShowVoteTtl.Checked))

                cmd.Parameters.AddWithValue("@ShowOptionalAttendance", CByte(ckOptionalAttendance.Checked))
                cmd.Parameters.AddWithValue("@ShowOptionalStats", CByte(ckOptionalVoterStats.Checked))
                cmd.Parameters.AddWithValue("@ShowOptionalPartyTotals", CByte(ckOptionalPartyTotals.Checked))
                cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)

                If ddlSubjects1.SelectedValue = "Default" Then
                    GenericErrorLabel.InnerText = "No 'Subject 1 Mapping' selected. Please select, and re-save."
                    Exit Sub
                Else
                    cmd.Parameters.AddWithValue("@SubjectField1", ddlSubjects1.SelectedValue)
                    Dim Subject2Val As Integer
                    If ddlSubjects2.SelectedValue = "Default" Then
                        Subject2Val = 0
                    Else
                        Subject2Val = ddlSubjects2.SelectedValue
                    End If
                    cmd.Parameters.AddWithValue("@SubjectField2", ddlSubjects2.SelectedValue)
                End If

                If ddlMotion1.SelectedValue = "Default" Then
                    GenericErrorLabel.InnerText = "No 'Motion Column Mapping' selected. Please select, and re-save."
                    Exit Sub
                Else
                    cmd.Parameters.AddWithValue("@MotionField", ddlMotion1.SelectedValue.ToString())
                End If

                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Report Parameters' to the database. Please contact support."
        End Try

        Try 'save vote mapping

            With cmd
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetVoteTypeMappings"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@YEA_name", txtYEA_Name.Text)
                cmd.Parameters.AddWithValue("@NAY_name", txtNAY_Name.Text)

                cmd.Parameters.AddWithValue("@ABS_enabled", CByte(ckABS_Enabled.Checked))
                cmd.Parameters.AddWithValue("@ABS_name", txtABS_Name.Value)
                cmd.Parameters.AddWithValue("@ABS_isUsed", CByte(ckABS_IsUsed.Checked))
                cmd.Parameters.AddWithValue("@ABS_isEligible", CByte(ckABS_IsEligible.Checked))

                cmd.Parameters.AddWithValue("@EXC_enabled", CByte(ckEXC_Enabled.Checked))
                cmd.Parameters.AddWithValue("@EXC_name", txtEXC_Name.Value)
                cmd.Parameters.AddWithValue("@EXC_isUsed", CByte(ckEXC_IsUsed.Checked))
                cmd.Parameters.AddWithValue("@EXC_isEligible", CByte(ckEXC_IsEligible.Checked))

                cmd.Parameters.AddWithValue("@ABSENT_enabled", CByte(ckABSENT_Enabled.Checked))
                cmd.Parameters.AddWithValue("@ABSENT_name", txtABSENT_Name.Text)
                cmd.Parameters.AddWithValue("@ABSENT_isUsed", CByte(ckABSENT_IsUsed.Checked))
                cmd.Parameters.AddWithValue("@ABSENT_isEligible", CByte(ckABSENT_IsEligible.Checked))

                cmd.Parameters.AddWithValue("@NV_enabled", CByte(ckNV_Enabled.Checked))
                cmd.Parameters.AddWithValue("@NV_name", txtNV_Name.Text)
                cmd.Parameters.AddWithValue("@NV_isUsed", CByte(ckNV_IsUsed.Checked))
                cmd.Parameters.AddWithValue("@NV_isEligible", CByte(ckNV_IsEnabled.Checked))

                cmd.Parameters.AddWithValue("@YeaOrder", txtYeaOrder.Text)
                cmd.Parameters.AddWithValue("@NayOrder", txtNayOrder.Text)
                cmd.Parameters.AddWithValue("@AbstainOrder", txtAbstainOrder.Text)
                cmd.Parameters.AddWithValue("@ExcusedOrder", txtExcOrder.Text)
                cmd.Parameters.AddWithValue("@AbsentOrder", txtAbsentOrder.Text)
                cmd.Parameters.AddWithValue("@NotVotingOrder", txtNVOrder.Text)
                cmd.Parameters.AddWithValue("@SessionID", VRList.Item(0).currentSessionID)
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()

            End With

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Vote Mappings' to the database. Please contact support."
        End Try






    End Sub


    Public Function validateAccountSettings()
        Dim hasErrors As Boolean = False
        If checkifEmpty(txtGovName.Text) Then hasErrors = True
        If checkifEmpty(txtLegName.Text) Then hasErrors = True
        Return hasErrors
    End Function

    Public Function validateReportParameters()
        Dim hasErrors As Boolean = False
        If checkifEmpty(txtRCS.Value) Then hasErrors = True
        If checkifEmpty(txtBillNbr.Value) Then hasErrors = True
        If checkifEmpty(txtMotion.Value) Then hasErrors = True
        If checkifEmpty(txtDateTime.Value) Then hasErrors = True
        If checkifEmpty(txtVoteTot.Value) Then hasErrors = True
        If checkifEmpty(txtResults.Value) Then hasErrors = True
        If checkifEmpty(txtOutcome.Value) Then hasErrors = True
        If checkifEmpty(txtPartyTotals.Value) Then hasErrors = True
        If checkifEmpty(txtMember.Value) Then hasErrors = True
        If checkifEmpty(txtDistrictName.Value) Then hasErrors = True
        If checkifEmpty(txtDistrictNbr.Value) Then hasErrors = True
        If ddlMotion1.SelectedValue = "Default" Then hasErrors = True
        If ddlSubjects1.SelectedValue = "Default" Then hasErrors = True
        If ddlSubjects2.SelectedValue = "Default" Then hasErrors = True
        Return hasErrors
    End Function

    Public Function validateVoteMappings()
        Dim hasErrors As Boolean = False

        'check for empty fields

        If txtYeaOrder.Text.Trim = String.Empty Or txtNayOrder.Text.Trim = String.Empty Or txtAbstainOrder.Text.Trim = String.Empty Or txtExcOrder.Text.Trim = String.Empty Or txtAbsentOrder.Text.Trim = String.Empty Or txtNVOrder.Text.Trim = String.Empty Then hasErrors = True
        If Not Integer.TryParse(txtYeaOrder.Text, 0) Or CInt(txtYeaOrder.Text) > 6 Or CInt(txtYeaOrder.Text) < 1 Then hasErrors = True
        If Not Integer.TryParse(txtNayOrder.Text, 0) Or CInt(txtNayOrder.Text) > 6 Or CInt(txtNayOrder.Text) < 1 Then hasErrors = True
        If Not Integer.TryParse(txtAbstainOrder.Text, 0) Or CInt(txtAbstainOrder.Text) > 6 Or CInt(txtAbstainOrder.Text) < 1 Then hasErrors = True
        If Not Integer.TryParse(txtExcOrder.Text, 0) Or CInt(txtExcOrder.Text) > 6 Or CInt(txtExcOrder.Text) < 1 Then hasErrors = True
        If Not Integer.TryParse(txtAbsentOrder.Text, 0) Or CInt(txtAbsentOrder.Text) > 6 Or CInt(txtAbsentOrder.Text) < 1 Then hasErrors = True
        If Not Integer.TryParse(txtNVOrder.Text, 0) Or CInt(txtNVOrder.Text) > 6 Or CInt(txtNVOrder.Text) < 1 Then hasErrors = True

        'Check for duplicate sort order numbers

        Dim YeaOrder As Integer = CInt(txtYeaOrder.Text)
        Dim NayOrder As Integer = CInt(txtNayOrder.Text)
        Dim AbstainOrder As Integer = CInt(txtAbstainOrder.Text)
        Dim ExcusedOrder As Integer = CInt(txtExcOrder.Text)
        Dim AbsentOrder As Integer = CInt(txtAbsentOrder.Text)
        Dim NotVotingOrder As Integer = CInt(txtNVOrder.Text)

        Dim IsUsed(5) As Integer
        IsUsed(0) = YeaOrder
        IsUsed(1) = NayOrder
        IsUsed(2) = AbstainOrder
        IsUsed(3) = ExcusedOrder
        IsUsed(4) = AbsentOrder
        IsUsed(5) = NotVotingOrder

        Dim hs As New HashSet(Of Integer)
        hs.Clear()
        For Each soItem In IsUsed
            If Not hs.Contains(soItem) Then
                hs.Add(soItem)
            Else
                'duplicate entry 
                hasErrors = True
            End If
        Next


        Return hasErrors
    End Function

    Public Function checkifEmpty(ByVal stringToCheck As String)
        Dim isEmpty As Boolean = False
        If stringToCheck.Trim = String.Empty Then isEmpty = True
        Return isEmpty
    End Function


                  
                  

    Protected Sub btnSaveUIDetails_Click(sender As Object, e As EventArgs)

        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            Using cmd
                cmd.Connection = con
                cmd.Connection.Open()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetUIParams"
                cmd.Parameters.AddWithValue("@MainImage", imguploader2.FileBytes)
                cmd.Parameters.AddWithValue("@SealImg ", imguploader1.FileBytes)
                cmd.Parameters.AddWithValue("@Link1Name", link1name.Value)
                cmd.Parameters.AddWithValue("@Link1URL ", link1url.Value)
                cmd.Parameters.AddWithValue("@Link2Name", link2name.Value)
                cmd.Parameters.AddWithValue("@Link2URL ", link2url.Value)
                cmd.Parameters.AddWithValue("@Link3Name", link3name.Value)
                cmd.Parameters.AddWithValue("@Link3URL ", link3url.Value)
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using
            Response.Redirect("Configuration.aspx", False)
            Context.ApplicationInstance.CompleteRequest()
        Catch ex As Exception
            ' TO DO: Add error handling 
        End Try



    End Sub

    Protected Sub btnSaveDataConfig_Click(sender As Object, e As EventArgs)

        Dim VRDBName As String = txtVRDBName.Value
        Dim VRDBServer As String = txtVRDBServer.Value
        Dim VRDBUser As String = txtVRDBUser.Value
        Dim VRDBPass As String = txtVRDBPass.Value

        Dim VoteDBName As String = txtVoteDBName.Value
        Dim VoteDBServer As String = txtVoteDBServer.Value
        Dim VoteDBUser As String = txtVoteDBUser.Value
        Dim VoteDBPass As String = txtVoteDBPass.Value

        '' If all fields are empty 
        'Dim VRDataCheck As Integer = 0

        'If Not VRDBName = String.Empty Then
        '    VRDataCheck += 1
        'End If
        'If Not VRDBServer = String.Empty Then
        '    VRDataCheck += 1
        'End If
        'If Not VRDBUser = String.Empty Then
        '    VRDataCheck += 1
        'End If
        'If Not VRDBPass = String.Empty Then
        '    VRDataCheck += 1
        'End If

        'If VRDataCheck = 4 Then 'All fields are filled, we can save.

        '    'update connnetion strings in web config
        '    Try
        '        Dim path As String = Server.MapPath("~/Web.Config")
        '        Dim doc As New XmlDocument()
        '        doc.Load(path)
        '        Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("connectionStrings/add[@name='{0}']", "VRDB"))
        '        Dim node As XmlNode
        '        node = list(0)

        '        Dim conString As String = node.Attributes("connectionString").Value
        '        Dim conStringBuilder As New SqlConnectionStringBuilder(conString)
        '        conStringBuilder.InitialCatalog = VRDBName
        '        conStringBuilder.DataSource = VRDBServer
        '        conStringBuilder.IntegratedSecurity = False
        '        conStringBuilder.UserID = VRDBUser
        '        conStringBuilder.Password = VRDBPass
        '        node.Attributes("connectionString").Value = conStringBuilder.ConnectionString

        '        doc.Save(path)
        '        conStringBuilder.Clear()

        '    Catch ex As Exception
        '        GenericErrorLabel.InnerText = "Something went wrong while updating connection string. Please contact support."
        '        Exit Sub
        '    End Try

        '    'save connection string info in database
        '    Try
        '        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        '        Dim cmd As New SqlCommand
        '        With cmd
        '            .CommandType = CommandType.StoredProcedure
        '            .CommandText = "sp_VRSetVRDBConnection"
        '            .Connection = con
        '            .Parameters.AddWithValue("@VRDBServer", VRDBServer)
        '            .Parameters.AddWithValue("@VRDBName", VRDBName)
        '            .Parameters.AddWithValue("@VRDBUser", VRDBUser)
        '            .Parameters.AddWithValue("@VRDBPass", VRDBPass)
        '            .Connection.Open()
        '            .ExecuteNonQuery()
        '            .Connection.Close()
        '        End With
        '    Catch ex As Exception
        '        GenericErrorLabel.InnerText = "Something went wrong while saving 'Reporter Database Connections' to the database. Please contact support."
        '        Exit Sub
        '    End Try

        'ElseIf VRDataCheck > 0 And VRDataCheck <= 3 Then 'Not all fields are filled

        '    GenericErrorLabel.InnerText = "All connection string fields must be filled out in order to save."
        '    Exit Sub

        'Else 'is equal to zero and no fields were filled out. We don't need to update

        'End If


        ''Update Vote Database


        'Dim VoteDataCheck As Integer = 0

        'If Not VRDBName = String.Empty Then
        '    VoteDataCheck += 1
        'End If
        'If Not VRDBServer = String.Empty Then
        '    VoteDataCheck += 1
        'End If
        'If Not VRDBUser = String.Empty Then
        '    VoteDataCheck += 1
        'End If
        'If Not VRDBPass = String.Empty Then
        '    VoteDataCheck += 1
        'End If

        'If VoteDataCheck = 4 Then 'save

        '    Try
        '        Dim path As String = Server.MapPath("~/Web.Config")
        '        Dim doc As New XmlDocument()
        '        doc.Load(path)
        '        Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("connectionStrings/add[@name='{0}']", "VoteDB"))
        '        Dim node As XmlNode
        '        node = list(0)

        '        Dim conString As String = node.Attributes("connectionString").Value
        '        Dim conStringBuilder As New SqlConnectionStringBuilder(conString)
        '        conStringBuilder.InitialCatalog = VRDBName
        '        conStringBuilder.DataSource = VRDBServer
        '        conStringBuilder.IntegratedSecurity = False
        '        conStringBuilder.UserID = VRDBUser
        '        conStringBuilder.Password = VRDBPass
        '        node.Attributes("connectionString").Value = conStringBuilder.ConnectionString

        '        doc.Save(path)
        '        conStringBuilder.Clear()

        '    Catch ex As Exception
        '        GenericErrorLabel.InnerText = "Something went wrong while updating connection string. Please contact support."
        '        Exit Sub
        '    End Try

        '    'save connection string info in database
        '    Try
        '        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        '        Dim cmd As New SqlCommand
        '        With cmd
        '            .CommandType = CommandType.StoredProcedure
        '            .CommandText = "sp_VRSetVoteDBConnection"
        '            .Connection = con
        '            .Parameters.Clear()
        '            .Parameters.AddWithValue("@VoteDBServer", VoteDBServer)
        '            .Parameters.AddWithValue("@VoteDBName", VoteDBName)
        '            .Parameters.AddWithValue("@VoteDBUser", VoteDBUser)
        '            .Parameters.AddWithValue("@VoteDBPass", VoteDBPass)
        '            .Connection.Open()
        '            .ExecuteNonQuery()
        '            .Connection.Close()

        '        End With
        '    Catch ex As Exception
        '        GenericErrorLabel.InnerText = "Something went wrong while saving 'Voting Database Connection' to the database. Please contact support."
        '        Exit Sub
        '    End Try

        'ElseIf VoteDataCheck > 0 And VoteDataCheck <= 3 Then 'not all filled out
        '    GenericErrorLabel.InnerText = "All connection string fields must be filled out in order to save."
        '    Exit Sub
        'Else ' no update 

        'End If


        ' Update Vote Type Mappings 
        Dim YEA_name As String = txtYEA_Name.Text
        Dim NAY_name As String = txtNAY_Name.text

        Dim ABS_enabled As Boolean = False
        If ckABS_Enabled.Checked = True Then ABS_enabled = True
        Dim ABS_name As String = txtABS_Name.Value
        Dim ABS_isUsed As Boolean = False
        If ckABS_IsUsed.Checked = True Then ABS_isUsed = True
        Dim ABS_isEligible As Boolean = False
        If ckABS_IsEligible.Checked = True Then ABS_isEligible = True

        Dim EXC_enabled As Boolean = False
        If ckEXC_Enabled.Checked = True Then EXC_enabled = True
        Dim EXC_name As String = txtEXC_Name.Value
        Dim EXC_isUsed As Boolean = False
        If ckEXC_IsUsed.Checked = True Then EXC_isUsed = True
        Dim EXC_isEligible As Boolean = False
        If ckEXC_IsEligible.Checked = True Then EXC_isEligible = True

        Dim ABSENT_enabled As Boolean = False
        If ckABSENT_Enabled.Checked = True Then ABSENT_enabled = True
        Dim ABSENT_name As String = txtABSENT_Name.Text
        Dim ABSENT_isUsed As Boolean = False
        If ckABSENT_IsUsed.Checked = True Then ABSENT_isUsed = True
        Dim ABSENT_isEligible As Boolean = False
        If ckABSENT_IsEligible.Checked = True Then ABSENT_isEligible = True

        Dim NV_enabled As Boolean = False
        If ckNV_Enabled.Checked = True Then NV_enabled = True
        Dim NV_name As String = txtNV_Name.Text
        Dim NV_isUsed As Boolean = False
        If ckNV_IsUsed.Checked = True Then NV_isUsed = True
        Dim NV_isEligible As Boolean = False
        If ckNV_IsEnabled.Checked = True Then NV_isEligible = True

        'validate sort order entry

        If txtYeaOrder.Text.Trim = String.Empty Or txtNayOrder.Text.Trim = String.Empty Or txtAbstainOrder.Text.Trim = String.Empty Or txtExcOrder.Text.Trim = String.Empty Or txtAbsentOrder.Text.Trim = String.Empty Or txtNVOrder.Text.Trim = String.Empty Then

            GenericErrorLabel.InnerText = "Not all 'Sort Order' values in vote type mapping were filled out. Please correct, and re-save."
            Exit Sub

        End If


        If Not Integer.TryParse(txtYeaOrder.Text, 0) Or CInt(txtYeaOrder.Text) > 6 Or CInt(txtYeaOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Yea' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        If Not Integer.TryParse(txtNayOrder.Text, 0) Or CInt(txtNayOrder.Text) > 6 Or CInt(txtNayOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Nay' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        If Not Integer.TryParse(txtAbstainOrder.Text, 0) Or CInt(txtAbstainOrder.Text) > 6 Or CInt(txtAbstainOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Abstain' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        If Not Integer.TryParse(txtExcOrder.Text, 0) Or CInt(txtExcOrder.Text) > 6 Or CInt(txtExcOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Excused' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        If Not Integer.TryParse(txtAbsentOrder.Text, 0) Or CInt(txtAbsentOrder.Text) > 6 Or CInt(txtAbsentOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Absent' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        If Not Integer.TryParse(txtNVOrder.Text, 0) Or CInt(txtNVOrder.Text) > 6 Or CInt(txtNVOrder.Text) < 1 Then
            GenericErrorLabel.InnerText = "Sort Order for 'Not Voting' vote type mapping is invalid. Value must be numeric and between 1 - 6."
            Exit Sub
        End If

        'Check for duplicate sort order numbers

        Dim YeaOrder As Integer = CInt(txtYeaOrder.Text)
        Dim NayOrder As Integer = CInt(txtNayOrder.Text)
        Dim AbstainOrder As Integer = CInt(txtAbstainOrder.Text)
        Dim ExcusedOrder As Integer = CInt(txtExcOrder.Text)
        Dim AbsentOrder As Integer = CInt(txtAbsentOrder.Text)
        Dim NotVotingOrder As Integer = CInt(txtNVOrder.Text)

        Dim IsUsed(5) As Integer
        IsUsed(0) = YeaOrder
        IsUsed(1) = NayOrder
        IsUsed(2) = AbstainOrder
        IsUsed(3) = ExcusedOrder
        IsUsed(4) = AbsentOrder
        IsUsed(5) = NotVotingOrder

        Dim hs As New HashSet(Of Integer)
        hs.Clear()
        For Each soItem In IsUsed
            If Not hs.Contains(soItem) Then
                hs.Add(soItem)
            Else
                'duplicate entry 
                GenericErrorLabel.InnerText = "Duplicate sort order entry found in Vote Type Mappings. Please correct, and re-save."
                Exit Sub
            End If
        Next




        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            With cmd
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetVoteTypeMappings"
                cmd.Connection.Open()


                cmd.Parameters.AddWithValue("@YEA_name", YEA_name)
                cmd.Parameters.AddWithValue("@NAY_name", NAY_name)

                cmd.Parameters.AddWithValue("@ABS_enabled", CByte(ABS_enabled))
                cmd.Parameters.AddWithValue("@ABS_name", ABS_name)
                cmd.Parameters.AddWithValue("@ABS_isUsed", CByte(ABS_isUsed))
                cmd.Parameters.AddWithValue("@ABS_isEligible", CByte(ABS_isEligible))

                cmd.Parameters.AddWithValue("@EXC_enabled", CByte(EXC_enabled))
                cmd.Parameters.AddWithValue("@EXC_name", EXC_name)
                cmd.Parameters.AddWithValue("@EXC_isUsed", CByte(EXC_isUsed))
                cmd.Parameters.AddWithValue("@EXC_isEligible", CByte(EXC_isEligible))

                cmd.Parameters.AddWithValue("@ABSENT_enabled", CByte(ABSENT_enabled))
                cmd.Parameters.AddWithValue("@ABSENT_name", ABSENT_name)
                cmd.Parameters.AddWithValue("@ABSENT_isUsed", CByte(ABSENT_isUsed))
                cmd.Parameters.AddWithValue("@ABSENT_isEligible", CByte(ABSENT_isEligible))

                cmd.Parameters.AddWithValue("@NV_enabled", CByte(NV_enabled))
                cmd.Parameters.AddWithValue("@NV_name", NV_name)
                cmd.Parameters.AddWithValue("@NV_isUsed", CByte(NV_isUsed))
                cmd.Parameters.AddWithValue("@NV_isEligible", CByte(NV_isEligible))

                cmd.Parameters.AddWithValue("@YeaOrder", YeaOrder)
                cmd.Parameters.AddWithValue("@NayOrder", NayOrder)
                cmd.Parameters.AddWithValue("@AbstainOrder", AbstainOrder)
                cmd.Parameters.AddWithValue("@ExcusedOrder", ExcusedOrder)
                cmd.Parameters.AddWithValue("@AbsentOrder", AbsentOrder)
                cmd.Parameters.AddWithValue("@NotVotingOrder", NotVotingOrder)



                cmd.ExecuteNonQuery()
                cmd.Connection.Close()

            End With

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Vote Mappings' to the database. Please contact support."
        End Try


        Session("IsReload") = False






    End Sub

    Protected Sub btnSaveReportData_Click(sender As Object, e As EventArgs)

        Dim showDistName As Boolean = False
        Dim showDistNbr As Boolean = False

        If rbDName.Checked = True Then
            showDistName = True
            showDistNbr = False
        Else
            showDistName = False
            showDistNbr = True
        End If

        Dim showMajorityStats As Boolean = False
        Dim showPartyStats As Boolean = False
        Dim showVoteStats As Boolean = False

        If ckShowMbrStat.Checked = True Then showMajorityStats = True
        If ckShowPartyStat.Checked = True Then showPartyStats = True
        If ckShowVoteTtl.Checked = True Then showVoteStats = True


        Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Try

            Using cmd As New SqlCommand

                cmd.Connection = Con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetReportParams"
                cmd.Parameters.AddWithValue("@RSCNumber", txtRCS.Value)
                cmd.Parameters.AddWithValue("@BillNumber", txtBillNbr.Value)
                cmd.Parameters.AddWithValue("@Motion", txtMotion.Value)
                cmd.Parameters.AddWithValue("@DateTime", txtDateTime.Value)
                cmd.Parameters.AddWithValue("@VoteTotals", txtVoteTot.Value)
                cmd.Parameters.AddWithValue("@Results", txtResults.Value)
                cmd.Parameters.AddWithValue("@Outcome ", txtOutcome.Value)
                cmd.Parameters.AddWithValue("@PartyTotals", txtPartyTotals.Value)
                cmd.Parameters.AddWithValue("@Member", txtMember.Value)
                cmd.Parameters.AddWithValue("@DistrictName", txtDistrictName.Value)
                cmd.Parameters.AddWithValue("@DistrictNumber", txtDistrictNbr.Value)
                cmd.Parameters.AddWithValue("@Presiding_Name_1", txtPO1Name.Value)
                cmd.Parameters.AddWithValue("@Presiding_Title_1", txtPO1Title.Value)
                cmd.Parameters.AddWithValue("@Presiding_Name_2", txtPO2Name.Value)
                cmd.Parameters.AddWithValue("@Presiding_Title_2", txtPO2title.Value)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Name", txtClerkName.Value)
                cmd.Parameters.AddWithValue("@Clerk_Secretary_Title", txtClerkTitle.Value)
                cmd.Parameters.AddWithValue("@showDistrictName", CByte(showDistName))
                cmd.Parameters.AddWithValue("@showDistrictNumber", CByte(showDistNbr))
                cmd.Parameters.AddWithValue("@showMajorityStats", CByte(showMajorityStats))
                cmd.Parameters.AddWithValue("@showPartyStats", CByte(showPartyStats))
                cmd.Parameters.AddWithValue("@showVotingStats", CByte(showVoteStats))


                If ddlSubjects1.SelectedValue = "Default" Then
                    GenericErrorLabel.InnerText = "No 'Subject 1 Mapping' selected. Please select, and re-save."
                    Exit Sub
                Else
                    cmd.Parameters.AddWithValue("@SubjectField1", ddlSubjects1.SelectedValue)
                    Dim Subject2Val As Integer
                    If ddlSubjects2.SelectedValue = "Default" Then
                        Subject2Val = 0
                    Else
                        Subject2Val = ddlSubjects2.SelectedValue
                    End If
                    cmd.Parameters.AddWithValue("@SubjectField2", ddlSubjects2.SelectedValue)
                End If

                If ddlMotion1.SelectedValue = "Default" Then
                    GenericErrorLabel.InnerText = "No 'Motion Column Mapping' selected. Please select, and re-save."
                    Exit Sub
                Else
                    cmd.Parameters.AddWithValue("@MotionField", ddlMotion1.SelectedValue.ToString())
                End If


                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End Using

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Report Parameters' to the database. Please contact support."
        End Try
    End Sub

    Protected Sub btnSaveAccountParams_Click(sender As Object, e As EventArgs)



        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            Using cmd
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_VRSetAccountParams"
                cmd.Parameters.AddWithValue("@GovName", txtGovName.Text)
                cmd.Parameters.AddWithValue("@LegName", txtLegName.Text)
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            End Using

        Catch ex As Exception
            GenericErrorLabel.InnerText = "Something went wrong while saving 'Account Settings' to the database. Please contact support."
        End Try




    End Sub


End Class