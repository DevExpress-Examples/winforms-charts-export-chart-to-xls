using DevExpress.XtraCharts;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ExportToXLS {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Series series = new Series("Series1", ViewType.Bar);
            chartControl1.Series.Add(series);
            chartControl1.DataSource = GetSales();
            series.ArgumentDataMember = "Region";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
        }

        private DataTable GetSales() {
            int prevYear = DateTime.Now.Year - 1;
            DataTable table = new DataTable();
            table.Columns.Add("Region", typeof(string));
            table.Columns.Add("Sales", typeof(decimal));

            table.Rows.Add("Asia", 4.2372D);
            table.Rows.Add("Australia", 1.7871D);
            table.Rows.Add("Europe", 3.0884D);
            table.Rows.Add("North America", 3.4855D);
            table.Rows.Add("South America", 1.6027D);

            return table;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            if (chartControl1.IsPrintingAvailable) {
                // The XLS file name.
                string fileName = "Output.xls";

                // Path to an XLS file.
                string filePath = "c:\\temp";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                string fullPath = String.Format("{0}\\{1}", filePath, fileName);

                // Exports to an XLS file.
                chartControl1.ExportToXls(fullPath);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            if (chartControl1.IsPrintingAvailable) {
                // The XLS file name.
                string fileName = "Output.xls";

                // Path to an XLS file.
                string filePath = "c:\\temp";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                string fullPath = String.Format("{0}\\{1}", filePath, fileName);

                // Exports to a stream as XLS.
                FileStream xlsStream = new FileStream(fullPath, FileMode.Create);
                chartControl1.ExportToXls(xlsStream);
                xlsStream.Close();
            }
        }
    }
}