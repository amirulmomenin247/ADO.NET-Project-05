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
    public partial class PublishersAdd : Form
    {
        public PublishersAdd()
        {
            InitializeComponent();
        }

        private void PublishersAdd_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = GetPublisherId().ToString();
            LoadComboBox();
        }
        private int GetPublisherId()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(publisherId), 0) FROM publishers", con))
                {
                    con.Open();
                    int id = (int)cmd.ExecuteScalar();
                    con.Close();
                    return id + 1;
                }
            }
        }
        private void LoadComboBox()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tags", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.comboBox1.DataSource = dt;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO publishers 
                                            (publisherId, publishername, publisheremail, tagId ) VALUES
                                            (@i, @n, @e, @t)", con, tran))
                    {
                        cmd.Parameters.AddWithValue("@i", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@n", textBox2.Text);
                        cmd.Parameters.AddWithValue("@e", textBox3.Text);
                        cmd.Parameters.AddWithValue("@t", comboBox1.SelectedValue);


                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();
                                this.textBox1.Clear();
                                this.textBox2.Clear();
                                this.textBox3.Clear();
                                con.Close();
                                this.textBox1.Text = GetPublisherId().ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tran.Rollback();
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                        }

                    }
                }

            }
        }
    }
}
