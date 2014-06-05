# Azure Websites GetHdc-Issue #

This sample illustrates issues with reporting and exporting when using libraries that rely on [Graphics.GetHdc](http://msdn.microsoft.com/en-us/library/9z5820hw(v=vs.110).aspx) to determine content sizes.
Azure Websites currently restricts the use of certain low-level APIs.

This reproduction web-app uses **ClosedXML** and **Microsoft.ReportViewer** and is currently deployed [here](http://azurewebsitesgethdctest.azurewebsites.net/).

The sample does not use a very recent [ClosedXML](https://closedxml.codeplex.com/)-version (but the [most common one](http://www.nuget.org/packages/ClosedXML/0.69.2)), because the great team developing it [recently fixed this issue](https://closedxml.codeplex.com/SourceControl/changeset/d7fde184b52432d1289f84ac41087508b7331845) by avoiding this API.

