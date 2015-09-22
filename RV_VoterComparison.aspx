<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RV_VoterComparison.aspx.vb" Inherits="VoteReporterNEW.RV_VoterComparison" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="VoterComparisonViewer" runat="server" ReportTypeName="VoteReporterNEW.XRVoterComparison" Theme="Moderno"></dx:ASPxDocumentViewer>
    </div>
    </form>
</body>
</html>
