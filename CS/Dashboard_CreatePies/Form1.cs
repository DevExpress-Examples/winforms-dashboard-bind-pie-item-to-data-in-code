using System;
using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess;

namespace Dashboard_CreatePies {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private PieDashboardItem CreatePies(DataSource dataSource) {

            // Creates a pie dashboard item and specifies its data source.
            PieDashboardItem pies = new PieDashboardItem();
            pies.DataSource = dataSource;

            // Specifies a measure that provides data used to calculate pie values.
            pies.Values.Add(new Measure("Extended Price"));
            // Specifies a dimension that provides data for arguments in a pie.
            pies.Arguments.Add(new Dimension("Country"));
            // Specifies a dimension that provides data for pie series.
            pies.SeriesDimensions.Add(new Dimension("OrderDate"));

            return pies;
        }
        private void Form1_Load(object sender, EventArgs e) {

            // Creates a dashboard and sets it as the currently opened dashboard in the dashboard viewer.
            dashboardViewer1.Dashboard = new Dashboard();

            // Creates a data source and adds it to the dashboard data source collection.
            DataSource dataSource = new DataSource("Sales Person");
            dashboardViewer1.Dashboard.DataSources.Add(dataSource);

            // Creates a pie dashboard item with the specified data source 
            // and adds it to the Items collection to display within the dashboard.
            PieDashboardItem pies = CreatePies(dataSource);
            dashboardViewer1.Dashboard.Items.Add(pies);

            // Reloads data in the data sources.
            dashboardViewer1.ReloadData();
        }
        private void dashboardViewer1_DataLoading(object sender, DataLoadingEventArgs e) {

            // Specifies data for the current data source.
            e.Data = (new nwindDataSetTableAdapters.SalesPersonTableAdapter()).GetData();
        }
    }
}
