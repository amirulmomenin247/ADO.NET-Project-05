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
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM books", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "books1");
                    ds.Tables["books1"].Columns.Add(new DataColumn("image", typeof(System.Byte[])));
                    var dt = ds.Tables["books1"];
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["image"] = File.ReadAllBytes(Path.Combine(Path.GetFullPath(@"..\..\Pictures"), dt.Rows[i]["picture"].ToString()));
                    }
                    CrystalReport1 rpt = new CrystalReport1();
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource= rpt;
                    crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
