<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AzureWebsitesGetHdcTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AzureWebsitesGetHdcTest</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="TestClosedXML" runat="server" Text="Test ClosedXML" OnClick="TestClosedXML_Click" />
      <asp:Button ID="TestReportViewer" runat="server" Text="Test ReportViewer" OnClick="TestReportViewer_Click" />
    </div>
    </form>
</body>
</html>
