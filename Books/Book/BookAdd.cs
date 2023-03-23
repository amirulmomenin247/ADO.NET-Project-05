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

namespace Books.Book
{
    public partial class BookAdd : Form
    {
        string pictureName = "";
        public BookAdd()
        {
            InitializeComponent();
        }

        private void BookAdd_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = GetBookId().ToString();
            LoadPublisher();
        }

        private void LoadPublisher()
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

        private int GetBookId()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(bookid), 0) FROM books", con))
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                this.pictureName = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {

                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO books 
                                            (bookid, title, coverprice, publishdate, available, picture, publisherid) VALUES
                                            (@i, @t, @c, @d,@a, @pic, @p)", con, tran))
                    {
                        cmd.Parameters.AddWithValue("@i", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@t", textBox2.Text);
                        cmd.Parameters.AddWithValue("@c", decimal.Parse(textBox3.Text));
                        cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@a", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@p", PublisherIdCB.SelectedValue);
                        string ext = Path.GetExtension(this.pictureName);
                        string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                        string savePath = Path.Combine(Path.GetFullPath(@"..\..\Pictures"), fileName);
                        File.Copy(pictureName, savePath, true);
                        cmd.Parameters.AddWithValue("@pic", fileName);

                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();
                                this.textBox1.Clear();
                                this.textBox2.Clear();
                                this.textBox3.Clear();
                                dateTimePicker1.Value = DateTime.Now;
                                checkBox1.Checked = false;
                                pictureBox1.Image = null;
                                pictureName = "";
                                con.Close();
                                this.textBox1.Text = GetBookId().ToString();
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

        private void PublisherIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
