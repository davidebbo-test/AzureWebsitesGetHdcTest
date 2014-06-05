namespace AzureWebsitesGetHdcTest
{
	using System;

	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void TestClosedXML_Click(object sender, EventArgs e)
		{
			Test.TestClosedXML();
		}

		protected void TestReportViewer_Click(object sender, EventArgs e)
		{
			Test.TestReportViewer();
		}
	}
}