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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Books.Tag
{
    public partial class TagsAdd : Form
    {
        public TagsAdd()
        {
            InitializeComponent();
        }
        private void TagsAdd_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = GetTagId().ToString();
        }
        private int GetTagId()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(tagId), 0) FROM tags", con))
                {
                    con.Open();
                    int id = (int)cmd.ExecuteScalar();
                    con.Close();
                    return id + 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO tags 
                                            (tagId, tagName) VALUES
                                            (@i, @n)", con, tran))
                    {
                        cmd.Parameters.AddWithValue("@i", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@n", textBox2.Text);
                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();
                                this.textBox1.Clear();
                                this.textBox2.Clear();
                                con.Close();
                                this.textBox1.Text = GetTagId().ToString();
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
