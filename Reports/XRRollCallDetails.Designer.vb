<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class XRRollCallDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XRRollCallDetails))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.check6 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.check5 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.check4 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.check3 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.check2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.check1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDistrict = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.RcDetailsDS1 = New VoteReporterNEW.RCDetailsDS()
        Me.Sp_Report_RollCallDetailsTableAdapter = New VoteReporterNEW.RCDetailsDSTableAdapters.sp_Report_RollCallDetailsTableAdapter()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.VoteHeader6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Yea_Header = New DevExpress.XtraReports.UI.FormattingRule()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.RcDetailsDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.check6, Me.check5, Me.check4, Me.check3, Me.check2, Me.check1, Me.XrLine1, Me.XrLabel4, Me.lblDistrict})
        Me.Detail.HeightF = 36.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = "Detail_BeforePrint"
        Me.Detail.StylePriority.UseTextAlignment = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'check6
        '
        Me.check6.Image = CType(resources.GetObject("check6.Image"), System.Drawing.Image)
        Me.check6.LocationFloat = New DevExpress.Utils.PointFloat(608.7084!, 0.0!)
        Me.check6.Name = "check6"
        Me.check6.SizeF = New System.Drawing.SizeF(26.08331!, 20.49996!)
        Me.check6.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'check5
        '
        Me.check5.Image = CType(resources.GetObject("check5.Image"), System.Drawing.Image)
        Me.check5.LocationFloat = New DevExpress.Utils.PointFloat(538.4584!, 0.0!)
        Me.check5.Name = "check5"
        Me.check5.SizeF = New System.Drawing.SizeF(26.08331!, 20.49996!)
        Me.check5.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'check4
        '
        Me.check4.Image = CType(resources.GetObject("check4.Image"), System.Drawing.Image)
        Me.check4.LocationFloat = New DevExpress.Utils.PointFloat(469.7917!, 0.0!)
        Me.check4.Name = "check4"
        Me.check4.SizeF = New System.Drawing.SizeF(26.08325!, 20.49996!)
        Me.check4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'check3
        '
        Me.check3.Image = CType(resources.GetObject("check3.Image"), System.Drawing.Image)
        Me.check3.LocationFloat = New DevExpress.Utils.PointFloat(397.9167!, 0.0!)
        Me.check3.Name = "check3"
        Me.check3.SizeF = New System.Drawing.SizeF(26.08325!, 20.49996!)
        Me.check3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'check2
        '
        Me.check2.Image = CType(resources.GetObject("check2.Image"), System.Drawing.Image)
        Me.check2.LocationFloat = New DevExpress.Utils.PointFloat(331.25!, 0.0!)
        Me.check2.Name = "check2"
        Me.check2.SizeF = New System.Drawing.SizeF(26.08325!, 20.49996!)
        Me.check2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'check1
        '
        Me.check1.Image = CType(resources.GetObject("check1.Image"), System.Drawing.Image)
        Me.check1.LocationFloat = New DevExpress.Utils.PointFloat(262.5!, 0.0!)
        Me.check1.Name = "check1"
        Me.check1.SizeF = New System.Drawing.SizeF(26.08325!, 20.49996!)
        Me.check1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 23.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(650.0!, 13.0!)
        '
        'XrLabel4
        '
        Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_RollCallDetails.VotingName")})
        Me.XrLabel4.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "XrLabel4"
        '
        'lblDistrict
        '
        Me.lblDistrict.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblDistrict.LocationFloat = New DevExpress.Utils.PointFloat(111.4583!, 0.0!)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDistrict.SizeF = New System.Drawing.SizeF(99.99996!, 23.0!)
        Me.lblDistrict.StylePriority.UseFont = False
        Me.lblDistrict.Text = "[sp_Report_RollCallDetails.ShowDistrictName]"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "sp_Report_GetTypeDetails.CurrentName")})
        Me.XrLabel3.Font = New System.Drawing.Font("Arial Narrow", 30.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(15.97226!, 91.36102!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(423.3055!, 55.16676!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "XrLabel3"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.StylePriority.UseBorders = False
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'RcDetailsDS1
        '
        Me.RcDetailsDS1.DataSetName = "RCDetailsDS"
        Me.RcDetailsDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sp_Report_RollCallDetailsTableAdapter
        '
        Me.Sp_Report_RollCallDetailsTableAdapter.ClearBeforeFill = True
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Image", Nothing, "sp_VRGetReportConfigParams.imgMainBackground")})
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(439.2777!, 21.11115!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(180.9028!, 160.5279!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel8, Me.XrLabel6, Me.XrLabel3, Me.XrPictureBox1, Me.VoteHeader1, Me.VoteHeader2, Me.VoteHeader3, Me.VoteHeader4, Me.VoteHeader5, Me.VoteHeader6, Me.XrLabel7})
        Me.ReportHeader.HeightF = 250.6944!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseTextAlignment = False
        Me.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 219.3611!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "[sp_VRGetReportConfigParams.Member]"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'VoteHeader1
        '
        Me.VoteHeader1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader1.LocationFloat = New DevExpress.Utils.PointFloat(243.75!, 219.3611!)
        Me.VoteHeader1.Name = "VoteHeader1"
        Me.VoteHeader1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader1.SizeF = New System.Drawing.SizeF(58.37497!, 23.0!)
        Me.VoteHeader1.StylePriority.UseFont = False
        Me.VoteHeader1.StylePriority.UseTextAlignment = False
        Me.VoteHeader1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'VoteHeader2
        '
        Me.VoteHeader2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader2.LocationFloat = New DevExpress.Utils.PointFloat(312.5!, 219.3611!)
        Me.VoteHeader2.Name = "VoteHeader2"
        Me.VoteHeader2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader2.SizeF = New System.Drawing.SizeF(58.375!, 23.0!)
        Me.VoteHeader2.StylePriority.UseFont = False
        Me.VoteHeader2.StylePriority.UseTextAlignment = False
        Me.VoteHeader2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'VoteHeader3
        '
        Me.VoteHeader3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader3.LocationFloat = New DevExpress.Utils.PointFloat(379.1667!, 219.3611!)
        Me.VoteHeader3.Name = "VoteHeader3"
        Me.VoteHeader3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader3.SizeF = New System.Drawing.SizeF(58.37497!, 23.0!)
        Me.VoteHeader3.StylePriority.UseFont = False
        Me.VoteHeader3.StylePriority.UseTextAlignment = False
        Me.VoteHeader3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'VoteHeader4
        '
        Me.VoteHeader4.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader4.LocationFloat = New DevExpress.Utils.PointFloat(452.0833!, 219.3611!)
        Me.VoteHeader4.Name = "VoteHeader4"
        Me.VoteHeader4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader4.SizeF = New System.Drawing.SizeF(58.37497!, 23.0!)
        Me.VoteHeader4.StylePriority.UseFont = False
        Me.VoteHeader4.StylePriority.UseTextAlignment = False
        Me.VoteHeader4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'VoteHeader5
        '
        Me.VoteHeader5.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader5.LocationFloat = New DevExpress.Utils.PointFloat(520.7501!, 219.3611!)
        Me.VoteHeader5.Name = "VoteHeader5"
        Me.VoteHeader5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader5.SizeF = New System.Drawing.SizeF(58.37497!, 23.0!)
        Me.VoteHeader5.StylePriority.UseFont = False
        Me.VoteHeader5.StylePriority.UseTextAlignment = False
        Me.VoteHeader5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'VoteHeader6
        '
        Me.VoteHeader6.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VoteHeader6.LocationFloat = New DevExpress.Utils.PointFloat(589.5418!, 219.3611!)
        Me.VoteHeader6.Name = "VoteHeader6"
        Me.VoteHeader6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.VoteHeader6.SizeF = New System.Drawing.SizeF(58.37497!, 23.00001!)
        Me.VoteHeader6.StylePriority.UseFont = False
        Me.VoteHeader6.StylePriority.UseTextAlignment = False
        Me.VoteHeader6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(111.4583!, 219.3611!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(100.0!, 23.00002!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "[sp_Report_RollCallDetails.DistrictHeaders]"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Yea_Header
        '
        Me.Yea_Header.Name = "Yea_Header"
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(15.97226!, 158.639!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(423.3055!, 23.00002!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = resources.GetString("XrLabel8.Text")
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XRRollCallDetails
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.DataAdapter = Me.Sp_Report_RollCallDetailsTableAdapter
        Me.DataMember = "sp_Report_RollCallDetails"
        Me.DataSource = Me.RcDetailsDS1
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.Yea_Header, Me.FormattingRule1})
        Me.Padding = New DevExpress.XtraPrinting.PaddingInfo(20, 20, 20, 20, 100.0!)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Scripts.OnDataSourceDemanded = "XRRollCallDetails_DataSourceDemanded"
        Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
        Me.Version = "14.2"
        CType(Me.RcDetailsDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand

    Friend WithEvents RcDetailsDS1 As VoteReporterNEW.RCDetailsDS
    Friend WithEvents Sp_Report_RollCallDetailsTableAdapter As VoteReporterNEW.RCDetailsDSTableAdapters.sp_Report_RollCallDetailsTableAdapter
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents Yea_Header As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VoteHeader6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents check6 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents check5 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents check4 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents check3 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents check2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents check1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents lblDistrict As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
End Class
