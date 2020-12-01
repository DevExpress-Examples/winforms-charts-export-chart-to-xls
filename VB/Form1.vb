Imports DevExpress.XtraCharts
Imports System
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Namespace ExportToXLS
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim series As New Series("Series1", ViewType.Bar)
			chartControl1.Series.Add(series)
			chartControl1.DataSource = GetSales()
			series.ArgumentDataMember = "Region"
			series.ValueDataMembers.AddRange(New String() { "Sales" })
		End Sub

		Private Function GetSales() As DataTable
			Dim prevYear As Integer = Date.Now.Year - 1
			Dim table As New DataTable()
			table.Columns.Add("Region", GetType(String))
			table.Columns.Add("Sales", GetType(Decimal))

			table.Rows.Add("Asia", 4.2372R)
			table.Rows.Add("Australia", 1.7871R)
			table.Rows.Add("Europe", 3.0884R)
			table.Rows.Add("North America", 3.4855R)
			table.Rows.Add("South America", 1.6027R)

			Return table
		End Function

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			If chartControl1.IsPrintingAvailable Then
				' The XLS file name.
				Dim fileName As String = "Output.xls"

				' Path to an XLS file.
				Dim filePath As String = "c:\temp"
				If Not Directory.Exists(filePath) Then
					Directory.CreateDirectory(filePath)
				End If

				Dim fullPath As String = String.Format("{0}\{1}", filePath, fileName)

				' Exports to an XLS file.
				chartControl1.ExportToXls(fullPath)
			End If
		End Sub
		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			If chartControl1.IsPrintingAvailable Then
				' The XLS file name.
				Dim fileName As String = "Output.xls"

				' Path to an XLS file.
				Dim filePath As String = "c:\temp"
				If Not Directory.Exists(filePath) Then
					Directory.CreateDirectory(filePath)
				End If

				Dim fullPath As String = String.Format("{0}\{1}", filePath, fileName)

				' Exports to a stream as XLS.
				Dim xlsStream As New FileStream(fullPath, FileMode.Create)
				chartControl1.ExportToXls(xlsStream)
				xlsStream.Close()
			End If
		End Sub
	End Class
End Namespace