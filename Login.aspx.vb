Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class Skeleton
    Inherits System.Web.UI.Page
    Private Link1URL As String
    Private Link2URL As String
    Private Link3URL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter("SELECT * FROM Users WHERE Username ='" & txtUsername.Text & "'", con)
        Dim ds As New DataSet("user")
        da.Fill(ds, "user")
        Dim dt As DataTable = ds.Tables("user")

        If dt.Rows.Count = 1 Then

            Dim UserMgmtService As New UserManagementService()
            Dim md5Hash As MD5 = MD5.Create()
            Dim DBHash As String = dt.Rows(0).Item(6)
            Dim HashedPass = UserMgmtService.GetHash(md5Hash, txtPassword.Text)

            If UserMgmtService.UnHashIt(HashedPass, DBHash) Then
                'Store User Info
                Session("Firstname") = dt.Rows(0).Item("FirstName").ToString()
                Session("Access") = dt.Rows(0).Item("Type")


                ' Get Data Settings
                Dim cmd As New SqlCommand
                With cmd
                    .Connection = con
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM [DBConfig]"
                End With

                da.SelectCommand = cmd
                da.Fill(ds, "data")

                cmd.Connection.Close()

                Session("VRDBName") = ds.Tables("data").Rows(0).Item(3).ToString()
                Session("VoteDBName") = ds.Tables("data").Rows(1).Item(3).ToString()


                '' Get Report Params

                'With cmd
                '    .Connection = con
                '    .Connection.Open()
                '    .CommandType = CommandType.StoredProcedure
                '    .CommandText = "sp_VRGetReportConfigParams"
                '    .Parameters.AddWithValue("@SessionID", 1)
                '    .ExecuteNonQuery()
                '    .Connection.Close()
                'End With

                'da.SelectCommand = cmd
                'da.Fill(ds, "reports")

                'Session("pGovernmentName") = ds.Tables("reports").Rows(0).Item(0).ToString()
                'Session("pLegislatureName") = ds.Tables("reports").Rows(0).Item(1).ToString()

                'Session("pLink1Name") = ds.Tables("reports").Rows(0).Item(2).ToString()
                'Session("pLink1URL") = ds.Tables("reports").Rows(0).Item(3).ToString()
                'Session("pLink2Name") = ds.Tables("reports").Rows(0).Item(4).ToString()
                'Session("pLink2URL") = ds.Tables("reports").Rows(0).Item(5).ToString()
                'Session("pLink3Name") = ds.Tables("reports").Rows(0).Item(6).ToString()
                'Session("pLink3URL") = ds.Tables("reports").Rows(0).Item(7).ToString()

                'Session("pRCS") = ds.Tables("reports").Rows(0).Item(8).ToString()
                'Session("pBill") = ds.Tables("reports").Rows(0).Item(9).ToString()
                'Session("pMotion") = ds.Tables("reports").Rows(0).Item(10).ToString()
                'Session("pDate") = ds.Tables("reports").Rows(0).Item(11).ToString()
                'Session("pVoteTotals") = ds.Tables("reports").Rows(0).Item(12).ToString()
                'Session("pResults") = ds.Tables("reports").Rows(0).Item(13).ToString()
                'Session("pOutcome") = ds.Tables("reports").Rows(0).Item(14).ToString()
                'Session("pPartyTotals") = ds.Tables("reports").Rows(0).Item(15).ToString()
                'Session("pMember") = ds.Tables("reports").Rows(0).Item(16).ToString()
                'Session("pDistrictName") = ds.Tables("reports").Rows(0).Item(17).ToString()
                'Session("pDistrictNumber") = ds.Tables("reports").Rows(0).Item(18).ToString()
                'Session("pPres1Name") = ds.Tables("reports").Rows(0).Item(19).ToString()
                'Session("pPres1Title") = ds.Tables("reports").Rows(0).Item(20).ToString()
                'Session("pPres2Name") = ds.Tables("reports").Rows(0).Item(21).ToString()
                'Session("pPres2Title") = ds.Tables("reports").Rows(0).Item(22).ToString()
                'Session("pClerkName") = ds.Tables("reports").Rows(0).Item(23).ToString()
                'Session("pClerkTitle") = ds.Tables("reports").Rows(0).Item(24).ToString()
                'Session("pMotionData") = ds.Tables("reports").Rows(0).Item(28).ToString()


                Response.Redirect("Default.aspx", False)
                Context.ApplicationInstance.CompleteRequest()

            Else
                lblError.Text = "Invalid credentials."
                Exit Sub
            End If

        Else
            lblError.Text = "Invalid credentials."
            Exit Sub
        End If


    End Sub
End Class