namespace AzureWebsitesGetHdcTest
{
	using ClosedXML.Excel;
	using Microsoft.Reporting.WebForms;
	using System;
	using System.IO;

	public static class Test
	{
		/// <summary>
		/// Tests rendering of a simple report without an actual data source.
		/// </summary>
		/// <remarks>
		/// The used report definition 'simple.rdl' is a new/blank file created
		/// with Report Builder 3.0.
		/// </remarks>
		public static void TestReportViewer()
		{
			Microsoft.Reporting.WebForms.Warning[] warnings;
			string[] streamIds;
			var mimeType = string.Empty;
			var encoding = string.Empty;
			var extension = string.Empty;

			var reportViewer = new ReportViewer();
			reportViewer.LocalReport.LoadReportDefinition(new StreamReader(typeof(Test).Assembly.GetManifestResourceStream("AzureWebsitesGetHdcTest.simple.rdl")));
			var report = reportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
		}

		/// <summary>
		/// Tests creating a sample Excel workbook and adjusting column widths to content.
		/// </summary>
		/// <remarks>
		/// The width is first adjusted to the string 'Hello' in the first cell/column.
		/// The content is then changed to 'Hello World'. We expect that the width increases
		/// by about a factor of two. If the width does not increase or is unreasonably large
		/// an exception reflecting the widths is thrown.
		/// </remarks>
		public static void TestClosedXML()
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
		}
	}
}