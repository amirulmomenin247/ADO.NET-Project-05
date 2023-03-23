using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.Reports
{
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM publishers", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "publishers");
                    
                    da.SelectCommand.CommandText = "select * from books";
                    da.Fill(ds, "books");
                    CrystalReport2 rpt = new CrystalReport2();
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
