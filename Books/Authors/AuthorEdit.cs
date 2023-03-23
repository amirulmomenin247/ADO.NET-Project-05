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
    public partial class AuthorEdit : Form
    {
        public AuthorEdit()
        {
            InitializeComponent();
        }

        private void AuthorEdit_Load(object sender, EventArgs e)
        {
            LoadAuthor();
            LoadBook();
        }

        private void LoadBook()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM books", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.comboBox1.DataSource = dt;
                }
            }
        }

        private void LoadAuthor()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM authors", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.comboBox2.DataSource = dt;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM authors WHERE authorid=@i", con))
                {
                    cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox2.Text = dr.GetString(1);
                        textBox3.Text = dr.GetString(2);
                        comboBox1.SelectedValue = dr.GetValue(3);

                    }
                    con.Close();
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
                    using (SqlCommand cmd = new SqlCommand(@"UPDATE authors 
                                            SET authorname=@n WHERE
                                            authorid =@i", con, tran))
                    {
                        cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);
                        cmd.Parameters.AddWithValue("@n", textBox2.Text);
                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();
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
                        con.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE authors WHERE authorid=@i", con))
                    {
                        cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAuthor();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Data delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Open();
                            }
                        }

                    }
                }
            }
        }
    }
}
