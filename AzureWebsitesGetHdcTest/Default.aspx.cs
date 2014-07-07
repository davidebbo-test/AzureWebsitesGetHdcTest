namespace AzureWebsitesGetHdcTest
{
    using System;
    using System.IO;
    using ClosedXML.Excel;
    using Microsoft.Reporting.WebForms;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TestClosedXML_Click(object sender, EventArgs e)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sample Sheet");
            var column = worksheet.Column(1);

            worksheet.Cell("A1").Value = "Hello";
            column.AdjustToContents();
            var initialWidth = column.Width;

            worksheet.Cell("A1").Value = "Hello World!";
            column.AdjustToContents();
            var width = column.Width;

            if (width <= initialWidth || width > initialWidth * 10)
            {
                throw new Exception(string.Format("Width was not correctly adjusted. Initial: {0}, Current: {1}", initialWidth, width));
            }

            Label1.Text = "The TestClosedXML test was successful";
        }

        protected void TestReportViewer_Click(object sender, EventArgs e)
        {
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            var mimeType = string.Empty;
            var encoding = string.Empty;
            var extension = string.Empty;

            var reportViewer = new ReportViewer();
            reportViewer.LocalReport.LoadReportDefinition(new StreamReader(typeof(Default).Assembly.GetManifestResourceStream("AzureWebsitesGetHdcTest.simple.rdl")));

            var bytes = reportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + "test");
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download 
        }
    }
}