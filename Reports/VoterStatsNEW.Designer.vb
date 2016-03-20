<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class VoterStatsNEW
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.VoterDetailsDS1 = New VoteReporterNEW.VoterDetailsDS()
        Me.Sp_Report_GetTypeDetailsTableAdapter = New VoteReporterNEW.VoterDetailsDSTableAdapters.sp_Report_GetTypeDetailsTableAdapter()
        Me.VoterStatisticsDS1 = New VoteReporterNEW.VoterStatisticsDS()
        Me.Sp_Report_GetTypeDetailsTableAdapter1 = New VoteReporterNEW.VoterStatisticsDSTableAdapters.sp_Report_GetTypeDetailsTableAdapter()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.lblSession = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.T3BASE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hMajority1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hMajority2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hMajority3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hMajority4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hParty1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hParty2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hParty3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hParty4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.hOrder6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.T1BASE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cMajority1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cMajority2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cMajority3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cMajority4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cParty1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cParty2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cParty3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cParty4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cOrder6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBills = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSubjects = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVoteTypes = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblStartDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEndDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.lblPrintedOn = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        CType(Me.VoterDetailsDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VoterStatisticsDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrTable1, Me.XrTable2})
        Me.Detail.HeightF = 19.79167!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 35.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'VoterDetailsDS1
        '
        Me.VoterDetailsDS1.DataSetName = "VoterDetailsDS"
        Me.VoterDetailsDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sp_Report_GetTypeDetailsTableAdapter
        '
        Me.Sp_Report_GetTypeDetailsTableAdapter.ClearBeforeFill = True
        '
        'VoterStatisticsDS1
        '
        Me.VoterStatisticsDS1.DataSetName = "VoterStatisticsDS"
        Me.VoterStatisticsDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sp_Report_GetTypeDetailsTableAdapter1
        '
        Me.Sp_Report_GetTypeDetailsTableAdapter1.ClearBeforeFill = True
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel25, Me.XrTable3, Me.XrLabel24, Me.XrLine2, Me.XrLabel23, Me.XrLabel1, Me.XrLabel14, Me.XrPictureBox1, Me.lblSession, Me.XrLabel20, Me.XrLabel21, Me.XrLabel22})
        Me.PageHeader.HeightF = 171.2641!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_GetTypeDetails.CurrentName")})
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(147.9517!, 44.01389!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(731.526!, 29.94445!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetReportConfigParams.Government_Name")})
        Me.XrLabel14.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(147.9517!, 3.041656!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(731.526!, 40.97222!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "XrLabel14"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Image", Nothing, "sp_VRGetReportConfigParams.imgMainBackground")})
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 3.041656!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(103.2873!, 93.91669!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'lblSession
        '
        Me.lblSession.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSession.LocationFloat = New DevExpress.Utils.PointFloat(147.9517!, 73.95834!)
        Me.lblSession.Name = "lblSession"
        Me.lblSession.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblSession.SizeF = New System.Drawing.SizeF(436.1111!, 22.99999!)
        Me.lblSession.StylePriority.UseFont = False
        Me.lblSession.StylePriority.UseTextAlignment = False
        Me.lblSession.Text = "lblSession"
        Me.lblSession.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel25
        '
        Me.XrLabel25.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(279.209!, 136.5417!)
        Me.XrLabel25.Multiline = True
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(50.0!, 27.0!)
        Me.XrLabel25.StylePriority.UseFont = False
        Me.XrLabel25.Text = "Member " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Votes %"
        '
        'XrLabel20
        '
        Me.XrLabel20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 141.653!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(78.82782!, 21.88889!)
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "Member"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel21
        '
        Me.XrLabel21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(99.35014!, 141.6532!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(56.94447!, 21.88867!)
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "District"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel22
        '
        Me.XrLabel22.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(156.2946!, 136.5419!)
        Me.XrLabel22.Multiline = True
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(37.5!, 27.0!)
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Votes"
        '
        'XrLine2
        '
        Me.XrLine2.LineWidth = 2
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 163.5417!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(903.1924!, 7.722214!)
        '
        'XrLabel24
        '
        Me.XrLabel24.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(234.7646!, 136.5417!)
        Me.XrLabel24.Multiline = True
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(44.44!, 27.0!)
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.Text = "Member " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Votes"
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(329.209!, 136.5419!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(591.66!, 27.0!)
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.T3BASE, Me.hMajority1, Me.hMajority2, Me.hMajority3, Me.hMajority4, Me.hParty1, Me.hParty2, Me.hParty3, Me.hParty4, Me.hOrder1, Me.hOrder2, Me.hOrder3, Me.hOrder4, Me.hOrder5, Me.hOrder6})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'T3BASE
        '
        Me.T3BASE.Name = "T3BASE"
        Me.T3BASE.StylePriority.UseTextAlignment = False
        Me.T3BASE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.T3BASE.Weight = 0.11804957717531023R
        '
        'hMajority1
        '
        Me.hMajority1.CanShrink = True
        Me.hMajority1.Multiline = True
        Me.hMajority1.Name = "hMajority1"
        Me.hMajority1.StylePriority.UseTextAlignment = False
        Me.hMajority1.Text = "With" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Majority"
        Me.hMajority1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hMajority1.Weight = 0.43055473327641913R
        '
        'hMajority2
        '
        Me.hMajority2.CanShrink = True
        Me.hMajority2.Multiline = True
        Me.hMajority2.Name = "hMajority2"
        Me.hMajority2.StylePriority.UseTextAlignment = False
        Me.hMajority2.Text = "With" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Majority %"
        Me.hMajority2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hMajority2.Weight = 0.53471968674861181R
        '
        'hMajority3
        '
        Me.hMajority3.CanShrink = True
        Me.hMajority3.Multiline = True
        Me.hMajority3.Name = "hMajority3"
        Me.hMajority3.StylePriority.UseTextAlignment = False
        Me.hMajority3.Text = "Against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Majority"
        Me.hMajority3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hMajority3.Weight = 0.43749899888235139R
        '
        'hMajority4
        '
        Me.hMajority4.Multiline = True
        Me.hMajority4.Name = "hMajority4"
        Me.hMajority4.StylePriority.UseTextAlignment = False
        Me.hMajority4.Text = "Against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Majority %"
        Me.hMajority4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hMajority4.Weight = 0.51388842222087172R
        '
        'hParty1
        '
        Me.hParty1.Multiline = True
        Me.hParty1.Name = "hParty1"
        Me.hParty1.StylePriority.UseTextAlignment = False
        Me.hParty1.Text = "With" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Party"
        Me.hParty1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hParty1.Weight = 0.29861195027430565R
        '
        'hParty2
        '
        Me.hParty2.Multiline = True
        Me.hParty2.Name = "hParty2"
        Me.hParty2.StylePriority.UseTextAlignment = False
        Me.hParty2.Text = "With " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Party %"
        Me.hParty2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hParty2.Weight = 0.40999993961572712R
        '
        'hParty3
        '
        Me.hParty3.Multiline = True
        Me.hParty3.Name = "hParty3"
        Me.hParty3.StylePriority.UseTextAlignment = False
        Me.hParty3.Text = "Against" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Party"
        Me.hParty3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hParty3.Weight = 0.36777694698905161R
        '
        'hParty4
        '
        Me.hParty4.Multiline = True
        Me.hParty4.Name = "hParty4"
        Me.hParty4.StylePriority.UseTextAlignment = False
        Me.hParty4.Text = "Against " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Party %"
        Me.hParty4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.hParty4.Weight = 0.38888725436285448R
        '
        'hOrder1
        '
        Me.hOrder1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header1")})
        Me.hOrder1.Name = "hOrder1"
        Me.hOrder1.StylePriority.UseTextAlignment = False
        Me.hOrder1.Text = "hOrder1"
        Me.hOrder1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder1.Weight = 0.4027764120499252R
        '
        'hOrder2
        '
        Me.hOrder2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header2")})
        Me.hOrder2.Name = "hOrder2"
        Me.hOrder2.StylePriority.UseTextAlignment = False
        Me.hOrder2.Text = "hOrder2"
        Me.hOrder2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder2.Weight = 0.3958300021520279R
        '
        'hOrder3
        '
        Me.hOrder3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header3")})
        Me.hOrder3.Name = "hOrder3"
        Me.hOrder3.StylePriority.UseTextAlignment = False
        Me.hOrder3.Text = "hOrder3"
        Me.hOrder3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder3.Weight = 0.40278251556446509R
        '
        'hOrder4
        '
        Me.hOrder4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header4")})
        Me.hOrder4.Name = "hOrder4"
        Me.hOrder4.StylePriority.UseTextAlignment = False
        Me.hOrder4.Text = "hOrder4"
        Me.hOrder4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder4.Weight = 0.38193596165332522R
        '
        'hOrder5
        '
        Me.hOrder5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header5")})
        Me.hOrder5.Name = "hOrder5"
        Me.hOrder5.StylePriority.UseTextAlignment = False
        Me.hOrder5.Text = "hOrder5"
        Me.hOrder5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder5.Weight = 0.42360831752616923R
        '
        'hOrder6
        '
        Me.hOrder6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_VRGetVoteHeaderOrders.Header6")})
        Me.hOrder6.Name = "hOrder6"
        Me.hOrder6.StylePriority.UseTextAlignment = False
        Me.hOrder6.Text = "hOrder6"
        Me.hOrder6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.hOrder6.Weight = 0.40972617888081941R
        '
        'XrLabel23
        '
        Me.XrLabel23.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(193.7946!, 136.5419!)
        Me.XrLabel23.Multiline = True
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(40.97!, 27.0!)
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Eligible"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(18.09905!, 16.7222!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(903.1967!, 2.720007!)
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(329.2091!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(591.6599!, 16.7222!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.T1BASE, Me.cMajority1, Me.cMajority2, Me.cMajority3, Me.cMajority4, Me.cParty1, Me.cParty2, Me.cParty3, Me.cParty4, Me.cOrder1, Me.cOrder2, Me.cOrder3, Me.cOrder4, Me.cOrder5, Me.cOrder6})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'T1BASE
        '
        Me.T1BASE.Name = "T1BASE"
        Me.T1BASE.StylePriority.UseTextAlignment = False
        Me.T1BASE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.T1BASE.Weight = 0.11805445998671599R
        '
        'cMajority1
        '
        Me.cMajority1.CanShrink = True
        Me.cMajority1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.WithMajority")})
        Me.cMajority1.Name = "cMajority1"
        Me.cMajority1.StylePriority.UseTextAlignment = False
        Me.cMajority1.Text = "cMajority1"
        Me.cMajority1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cMajority1.Weight = 0.43055473327641913R
        '
        'cMajority2
        '
        Me.cMajority2.CanShrink = True
        Me.cMajority2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.WithMajorityPercentage", "{0}%")})
        Me.cMajority2.Name = "cMajority2"
        Me.cMajority2.StylePriority.UseTextAlignment = False
        Me.cMajority2.Text = "cMajority2"
        Me.cMajority2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cMajority2.Weight = 0.53471968674861181R
        '
        'cMajority3
        '
        Me.cMajority3.CanShrink = True
        Me.cMajority3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.AgaintsMajority")})
        Me.cMajority3.Name = "cMajority3"
        Me.cMajority3.StylePriority.UseTextAlignment = False
        Me.cMajority3.Text = "cMajority3"
        Me.cMajority3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cMajority3.Weight = 0.43749899888235139R
        '
        'cMajority4
        '
        Me.cMajority4.CanShrink = True
        Me.cMajority4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.AgaintsMajorityPercentage", "{0}%")})
        Me.cMajority4.Name = "cMajority4"
        Me.cMajority4.StylePriority.UseTextAlignment = False
        Me.cMajority4.Text = "cMajority4"
        Me.cMajority4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cMajority4.Weight = 0.51388842222087172R
        '
        'cParty1
        '
        Me.cParty1.CanShrink = True
        Me.cParty1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.WithParty")})
        Me.cParty1.Name = "cParty1"
        Me.cParty1.StylePriority.UseTextAlignment = False
        Me.cParty1.Text = "cParty1"
        Me.cParty1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cParty1.Weight = 0.29861195027430565R
        '
        'cParty2
        '
        Me.cParty2.CanShrink = True
        Me.cParty2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.WithPartyPercentage", "{0}%")})
        Me.cParty2.Name = "cParty2"
        Me.cParty2.StylePriority.UseTextAlignment = False
        Me.cParty2.Text = "cParty2"
        Me.cParty2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cParty2.Weight = 0.41418352810582304R
        '
        'cParty3
        '
        Me.cParty3.CanShrink = True
        Me.cParty3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.AgaintsParty")})
        Me.cParty3.Name = "cParty3"
        Me.cParty3.StylePriority.UseTextAlignment = False
        Me.cParty3.Text = "cParty3"
        Me.cParty3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cParty3.Weight = 0.36777994500825451R
        '
        'cParty4
        '
        Me.cParty4.CanShrink = True
        Me.cParty4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.AgaintsPartyPercentage", "{0}%")})
        Me.cParty4.Name = "cParty4"
        Me.cParty4.StylePriority.UseTextAlignment = False
        Me.cParty4.Text = "cParty4"
        Me.cParty4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.cParty4.Weight = 0.38469456433901139R
        '
        'cOrder1
        '
        Me.cOrder1.CanShrink = True
        Me.cOrder1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER1")})
        Me.cOrder1.Name = "cOrder1"
        Me.cOrder1.StylePriority.UseTextAlignment = False
        Me.cOrder1.Text = "cOrder1"
        Me.cOrder1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder1.Weight = 0.40277641204992487R
        '
        'cOrder2
        '
        Me.cOrder2.CanShrink = True
        Me.cOrder2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER2")})
        Me.cOrder2.Name = "cOrder2"
        Me.cOrder2.StylePriority.UseTextAlignment = False
        Me.cOrder2.Text = "cOrder2"
        Me.cOrder2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder2.Weight = 0.39583061250348189R
        '
        'cOrder3
        '
        Me.cOrder3.CanShrink = True
        Me.cOrder3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER3")})
        Me.cOrder3.Name = "cOrder3"
        Me.cOrder3.StylePriority.UseTextAlignment = False
        Me.cOrder3.Text = "cOrder3"
        Me.cOrder3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder3.Weight = 0.40278190521301083R
        '
        'cOrder4
        '
        Me.cOrder4.CanShrink = True
        Me.cOrder4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER4")})
        Me.cOrder4.Name = "cOrder4"
        Me.cOrder4.StylePriority.UseTextAlignment = False
        Me.cOrder4.Text = "cOrder4"
        Me.cOrder4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder4.Weight = 0.38193596165332577R
        '
        'cOrder5
        '
        Me.cOrder5.CanShrink = True
        Me.cOrder5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER5")})
        Me.cOrder5.Name = "cOrder5"
        Me.cOrder5.StylePriority.UseTextAlignment = False
        Me.cOrder5.Text = "cOrder5"
        Me.cOrder5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder5.Weight = 0.42360770717471419R
        '
        'cOrder6
        '
        Me.cOrder6.CanShrink = True
        Me.cOrder6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.ORDER6")})
        Me.cOrder6.Name = "cOrder6"
        Me.cOrder6.StylePriority.UseTextAlignment = False
        Me.cOrder6.Text = "cOrder6"
        Me.cOrder6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.cOrder6.Weight = 0.4097267892322729R
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(18.09905!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(311.11!, 16.7222!)
        Me.XrTable2.StylePriority.UseFont = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.XrTableCell12, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell13, Me.XrTableCell14})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.VotingName")})
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "XrTableCell9"
        Me.XrTableCell9.Weight = 2.4640493621656225R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.DistrictNbr")})
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "XrTableCell12"
        Me.XrTableCell12.Weight = 1.7269408377822826R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.TotalVotes")})
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "XrTableCell10"
        Me.XrTableCell10.Weight = 1.1372525228800037R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.TtlEligibleVotes")})
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "XrTableCell11"
        Me.XrTableCell11.Weight = 1.2425511490034113R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.MemberVotes")})
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "XrTableCell13"
        Me.XrTableCell13.Weight = 1.3478563165164623R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_VoterStatisticsNEW.MemberVotePercentage", "{0}%")})
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Text = "XrTableCell14"
        Me.XrTableCell14.Weight = 1.5163414548767598R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4, Me.XrLabel2, Me.lblBills, Me.lblSubjects, Me.lblVoteTypes, Me.XrLabel19, Me.XrLabel18, Me.XrLabel3, Me.lblStartDate, Me.lblEndDate})
        Me.ReportFooter.HeightF = 108.0766!
        Me.ReportFooter.Name = "ReportFooter"
        Me.ReportFooter.PrintAtBottom = True
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(56.86!, 12.58!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "Begin Date:"
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 22.58!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(56.86!, 12.58!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "End Date:"
        '
        'lblBills
        '
        Me.lblBills.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblBills.LocationFloat = New DevExpress.Utils.PointFloat(88.86144!, 95.49331!)
        Me.lblBills.Multiline = True
        Me.lblBills.Name = "lblBills"
        Me.lblBills.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblBills.SizeF = New System.Drawing.SizeF(381.3422!, 12.58333!)
        Me.lblBills.StylePriority.UseFont = False
        '
        'lblSubjects
        '
        Me.lblSubjects.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblSubjects.LocationFloat = New DevExpress.Utils.PointFloat(88.86144!, 46.88556!)
        Me.lblSubjects.Name = "lblSubjects"
        Me.lblSubjects.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblSubjects.SizeF = New System.Drawing.SizeF(381.3423!, 12.58334!)
        Me.lblSubjects.StylePriority.UseFont = False
        '
        'lblVoteTypes
        '
        Me.lblVoteTypes.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblVoteTypes.LocationFloat = New DevExpress.Utils.PointFloat(88.86144!, 69.94435!)
        Me.lblVoteTypes.Name = "lblVoteTypes"
        Me.lblVoteTypes.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblVoteTypes.SizeF = New System.Drawing.SizeF(230.69!, 12.58333!)
        Me.lblVoteTypes.StylePriority.UseFont = False
        '
        'XrLabel19
        '
        Me.XrLabel19.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(20.52231!, 95.49332!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(40.88779!, 12.58333!)
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.Text = "Bills:"
        '
        'XrLabel18
        '
        Me.XrLabel18.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(20.09674!, 46.88556!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(56.85994!, 12.58333!)
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "Subjects:"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(20.09668!, 69.94769!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(68.76476!, 12.57999!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Vote Types:"
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblStartDate.LocationFloat = New DevExpress.Utils.PointFloat(88.86144!, 0.0!)
        Me.lblStartDate.Multiline = True
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblStartDate.SizeF = New System.Drawing.SizeF(138.8881!, 12.58333!)
        Me.lblStartDate.StylePriority.UseFont = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblEndDate.LocationFloat = New DevExpress.Utils.PointFloat(88.86144!, 22.57668!)
        Me.lblEndDate.Multiline = True
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblEndDate.SizeF = New System.Drawing.SizeF(138.8881!, 12.58333!)
        Me.lblEndDate.StylePriority.UseFont = False
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.lblPrintedOn, Me.XrLabel5})
        Me.PageFooter.HeightF = 25.89289!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(853.1492!, 11.82144!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(70.56549!, 14.07143!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'lblPrintedOn
        '
        Me.lblPrintedOn.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblPrintedOn.LocationFloat = New DevExpress.Utils.PointFloat(89.28276!, 13.30956!)
        Me.lblPrintedOn.Multiline = True
        Me.lblPrintedOn.Name = "lblPrintedOn"
        Me.lblPrintedOn.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.lblPrintedOn.SizeF = New System.Drawing.SizeF(138.8881!, 12.58333!)
        Me.lblPrintedOn.StylePriority.UseFont = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(20.51797!, 11.82478!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(56.86!, 12.58!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "Printed On:"
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'VoterStatsNEW
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.DataMember = "sp_Report_VoterStatisticsNEW"
        Me.DataSource = Me.VoterStatisticsDS1
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 35, 50)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.VoterDetailsDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VoterStatisticsDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents VoterDetailsDS1 As VoteReporterNEW.VoterDetailsDS
    Friend WithEvents Sp_Report_GetTypeDetailsTableAdapter As VoteReporterNEW.VoterDetailsDSTableAdapters.sp_Report_GetTypeDetailsTableAdapter
    Friend WithEvents VoterStatisticsDS1 As VoteReporterNEW.VoterStatisticsDS
    Friend WithEvents Sp_Report_GetTypeDetailsTableAdapter1 As VoteReporterNEW.VoterStatisticsDSTableAdapters.sp_Report_GetTypeDetailsTableAdapter
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblSession As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents T3BASE As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hMajority1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hMajority2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hMajority3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hMajority4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hParty1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hParty2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hParty3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hParty4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents hOrder6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents T1BASE As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cMajority1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cMajority2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cMajority3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cMajority4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cParty1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cParty2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cParty3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cParty4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cOrder6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBills As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSubjects As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVoteTypes As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblStartDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEndDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents lblPrintedOn As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
End Class
