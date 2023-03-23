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

namespace Books.Authors
{
    public partial class AuthorView : Form
    {
        public AuthorView()
        {
            InitializeComponent();
        }

        private void AuthorView_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM authors", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    this.dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
