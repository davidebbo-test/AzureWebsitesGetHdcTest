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
            Label1.Text = "The TestClosedXML test was successful";
        }

        protected void TestReportViewer_Click(object sender, EventArgs e)
        {
            byte[] bytes = Test.TestReportViewer();
            Label1.Text = String.Format("A PDF file with site {0} was successfully created", bytes.Length);
        }
    }
}