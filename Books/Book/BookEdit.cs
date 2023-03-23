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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Books.Book
{
    public partial class BookEdit : Form
    {
        string pictureName = "", oldPictureName = "";
        public BookEdit()
        {
            InitializeComponent();
        }

        private void BookEdit_Load(object sender, EventArgs e)
        {
            LoadBookId();
            LoadPublisherId();
        }

        private void LoadPublisherId()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM publishers", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.PublisherIdCB.DataSource = dt;
                }
            }
        }

        private void BookIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM books WHERE bookid=@i", con))
                {
                    cmd.Parameters.AddWithValue("@i", BookIdCB.SelectedValue);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox2.Text = dr.GetString(1);
                        textBox3.Text = dr.GetDecimal(2).ToString("0.00");
                        dateTimePicker1.Value = dr.GetDateTime(3);
                        pictureBox1.Image = Image.FromFile(Path.Combine(@"..\..\Pictures", dr.GetString(5).ToString()));
                        checkBox1.Checked = dr.GetBoolean(4);
                        oldPictureName = dr.GetString(5);
                    }
                    con.Close();
                }
            }
        }

        private void PublisherIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM publishers WHERE publisherid=@i", con))
                {
                    cmd.Parameters.AddWithValue("@i", PublisherIdCB.SelectedValue);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                   
                    con.Close();
                }
            }
        }

        private void BookAddbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(@"UPDATE books 
                                            SET title=@t, coverprice=@c, publishdate=@d, available=@a picture=@pic, publisherid=@p
                                            WHERE ProductId =@i", con, tran))
                    {
                        cmd.Parameters.AddWithValue("@i", BookIdCB.SelectedValue);
                        cmd.Parameters.AddWithValue("@t", textBox2.Text);
                        cmd.Parameters.AddWithValue("@c", textBox3.Text);
                        cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@a", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@p", PublisherIdCB.SelectedValue);
                        if (!string.IsNullOrEmpty(pictureName))
                        {
                            string ext = Path.GetExtension(this.pictureName);
                            string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                            string savePath = Path.Combine(Path.GetFullPath(@"..\..\Pictures"), fileName);
                            File.Copy(pictureName, savePath, true);
                            cmd.Parameters.AddWithValue("@pic", fileName);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@pic", oldPictureName);
                        }
                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();

                                pictureName = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                this.pictureName = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE books WHERE bookid=@i", con))
                    {
                        cmd.Parameters.AddWithValue("@i", BookIdCB.SelectedValue);
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookId();
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

        private void LoadBookId()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM books", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.BookIdCB.DataSource = dt;
                }
            }
        }
    }
}
