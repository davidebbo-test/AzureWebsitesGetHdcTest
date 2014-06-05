# Azure Websites GetHdc-Issue #

This sample illustrates issues with reporting and exporting when using libraries that rely on [Graphics.GetHdc](http://msdn.microsoft.com/en-us/library/9z5820hw(v=vs.110).aspx) to determine content sizes.
Azure Websites currently restricts the use of certain low-level APIs.

Previous discussion on this topic can be found at the [Azure forums](http://social.msdn.microsoft.com/Forums/windowsazure/en-US/b4a6eb43-0013-435f-9d11-00ee26a8d017/report-viewer-error-on-export-pdf-or-excel-from-azure-web-sites?forum=windowsazurewebsitespreview).

The sample does not use a very recent [ClosedXML](https://closedxml.codeplex.com/)-version (but the [most common one](http://www.nuget.org/packages/ClosedXML/0.69.2)), because the great team developing it [recently fixed this issue](https://closedxml.codeplex.com/SourceControl/changeset/d7fde184b52432d1289f84ac41087508b7331845) by avoiding this API.

## Usage ##
This reproduction web-app uses **ClosedXML** and **Microsoft.ReportViewer** and is currently deployed [here](http://azurewebsitesgethdctest.azurewebsites.net/).

The app contains a button for each test. Clicking a button causes a reload of the page. If the default page reappears everything went fine. An error will be displayed if an exception occurred.