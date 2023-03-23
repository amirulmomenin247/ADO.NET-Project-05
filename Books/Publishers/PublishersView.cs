using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.Publishers
{
    public partial class PublishersView : Form
    {
        public PublishersView()
        {
            InitializeComponent();
        }

        private void PublishersView_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM publishers", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    this.dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
