Imports System
Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess

Namespace Dashboard_CreatePies
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Function CreatePies(ByVal dataSource As DashboardObjectDataSource) As PieDashboardItem

            ' Creates a pie dashboard item and specifies its data source.
            Dim pies As New PieDashboardItem()
            pies.DataSource = dataSource

            ' Specifies a measure that provides data used to calculate pie values.
            pies.Values.Add(New Measure("Extended Price"))
            ' Specifies a dimension that provides data for arguments in a pie.
            pies.Arguments.Add(New Dimension("Country"))
            ' Specifies a dimension that provides data for pie series.
            pies.SeriesDimensions.Add(New Dimension("OrderDate"))

            Return pies
        End Function
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

            ' Creates a dashboard and sets it as the currently opened dashboard in the dashboard viewer.
            dashboardViewer1.Dashboard = New Dashboard()

            ' Creates a data source and adds it to the dashboard data source collection.
            Dim dataSource As New DashboardObjectDataSource()
            dataSource.DataSource = (New nwindDataSetTableAdapters.SalesPersonTableAdapter()).GetData()
            dashboardViewer1.Dashboard.DataSources.Add(dataSource)

            ' Creates a pie dashboard item with the specified data source 
            ' and adds it to the Items collection to display within the dashboard.
            Dim pies As PieDashboardItem = CreatePies(dataSource)
            dashboardViewer1.Dashboard.Items.Add(pies)

            ' Reloads data in the data sources.
            dashboardViewer1.ReloadData()
        End Sub
    End Class
End Namespace
