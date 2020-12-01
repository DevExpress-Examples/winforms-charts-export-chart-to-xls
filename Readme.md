<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to: Export a Chart to XLS

The following example exports a chart as an image to the XLS document. In this example, the form contains the _Export to File_ and _Export to Stream_ buttons that allow you to save the XLS document with the chart image to a file or a stream. Follow the steps below to implement this scenario:

* [Add](https://docs.devexpress.com/WindowsForms/2957/controls-and-libraries/chart-control/examples/general/how-to-add-a-chart-to-a-windows-forms-application) a [Chart Control](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl) object to the form. Make sure that this Chart Control _Name_ is _chartControl1_ in the Visual Studio _Properties_ window. 

* Create a [Series](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.Series) object and pass [ViewType.Bar](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.ViewType) as a constructor parameter  in the _Form1_Load_ event handler. Use the [ChartControl.Series.Add](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.SeriesCollection.Add(DevExpress.XtraCharts.Series)) method to add this series to the chart.

* Call the _GetSales_ method and set its result to the [ChartControl.DataSource](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.DataSource) property. Specify the [Series.ArgumentDataMember](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.SeriesBase.ArgumentDataMember) and [Series.ValueDataMembers](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.SeriesBase.ValueDataMembers) properties to populate the chart with data.

* Add two [SimpleButtons](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.SimpleButton) to the form. Set the first button [Text](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.SimpleButton.Text) property to _Export to File_ and the second one - _Export to Stream_. 

* The Chart Control uses the [DevExpress Printing Library](https://docs.devexpress.com/WindowsForms/2079/controls-and-libraries/printing-exporting) to export a chart. To use this library, add references to the following assemblies to the project: _DevExpress.XtraPrinting.19.2, _DevExpress.Printing.v19.2.Core_.

* Handle the first button's [Click](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.click?view=net-5.0) event and use the [ChartControl.IsPrintingAvailable](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.IsPrintingAvailable) property to check whether the chart can be exported. Call the [ChartControl.ExportToXls(System.String)](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.ExportToXls(System.String)) method to export the chart to a file. Pass the path to this file as a parameter to this method.

* Handle the second button's [Click](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.click?view=net-5.0) event and use the [ChartControl.IsPrintingAvailable](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.IsPrintingAvailable) property to check whether the chart can be exported. Call the [ChartControl.ExportToXls(System.IO.Stream)](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.ExportToXls(System.IO.Stream)) method to export the chart to a stream. This example uses [FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-5.0), and you can open the file where the stream is saved to check the export result.
