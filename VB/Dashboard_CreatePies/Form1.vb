Imports DevExpress.DashboardCommon
Imports System
Imports System.Windows.Forms

Namespace Dashboard_CreatePies
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Function CreatePies(ByVal dataSource As IDashboardDataSource) As PieDashboardItem
			Dim pies As New PieDashboardItem()
			pies.DataSource = dataSource
			pies.Values.Add(New Measure("Extended Price"))
			pies.Arguments.Add(New Dimension("Country"))
			pies.SeriesDimensions.Add(New Dimension("OrderDate"))
			Return pies
		End Function
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim excelDataSource As New DashboardExcelDataSource()
            excelDataSource.FileName = "SalesPerson.xlsx"
            Dim options As New DevExpress.DataAccess.Excel.ExcelSourceOptions()
            Dim importSettings = New DevExpress.DataAccess.Excel.ExcelWorksheetSettings()
            importSettings.WorksheetName = "Data"
            importSettings.CellRange = "A1:L100"
            options.ImportSettings = importSettings
            excelDataSource.SourceOptions = options
            excelDataSource.Fill()

            Dim dashBoard As New Dashboard()
			dashBoard.DataSources.Add(excelDataSource)
			Dim pies As PieDashboardItem = CreatePies(excelDataSource)
			dashBoard.Items.Add(pies)

			dashboardViewer1.Dashboard = dashBoard
			dashboardViewer1.ReloadData()
		End Sub
	End Class
End Namespace
