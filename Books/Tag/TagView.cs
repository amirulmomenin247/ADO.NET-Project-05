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

namespace Books.Tag
{
    public partial class TagView : Form
    {
        public TagView()
        {
            InitializeComponent();
        }

        private void TagView_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tags", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    this.dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
