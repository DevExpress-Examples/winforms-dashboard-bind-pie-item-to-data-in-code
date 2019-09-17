using DevExpress.DashboardCommon;
using System;
using System.Windows.Forms;

namespace Dashboard_CreatePies
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private PieDashboardItem CreatePies(IDashboardDataSource dataSource) {
            PieDashboardItem pies = new PieDashboardItem();
            pies.DataSource = dataSource;
            pies.Values.Add(new Measure("Extended Price"));
            pies.Arguments.Add(new Dimension("Country"));
            pies.SeriesDimensions.Add(new Dimension("OrderDate"));
            return pies;
        }
        private void Form1_Load(object sender, EventArgs e) {
           DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource()
            {
                FileName = "SalesPerson.xlsx",
                SourceOptions = new DevExpress.DataAccess.Excel.ExcelSourceOptions(
                    new DevExpress.DataAccess.Excel.ExcelWorksheetSettings()
                    {
                        WorksheetName = "Data",
                        CellRange = "A1:L100"
                    }
                )
            };
            excelDataSource.Fill();

            Dashboard dashBoard = new Dashboard();
            dashBoard.DataSources.Add(excelDataSource);
            PieDashboardItem pies = CreatePies(excelDataSource);
            dashBoard.Items.Add(pies);

            dashboardViewer1.Dashboard = dashBoard;
            dashboardViewer1.ReloadData();
        }
    }
}
