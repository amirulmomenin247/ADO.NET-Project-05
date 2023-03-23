using Books.Authors;
using Books.Book;
using Books.Publishers;
using Books.Reports;
using Books.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TagView { MdiParent = this }.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TagsAdd { MdiParent = this }.Show();
        }

        private void updateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TagsEdit { MdiParent = this }.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PublishersView { MdiParent = this }.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PublishersAdd { MdiParent = this }.Show();
        }

        private void updateDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PublisherEdit { MdiParent = this }.Show();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BookView { MdiParent = this }.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BookAdd { MdiParent = this }.Show();
        }

        private void updateDeleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BookEdit { MdiParent = this }.Show();
        }

        private void viewToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new AuthorView { MdiParent = this }.Show();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new AuthorAdd { MdiParent = this }.Show();
        }

        private void updateDeleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new AuthorEdit { MdiParent = this }.Show();
        }

        private void reportOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Report1 { MdiParent=this }.Show();
        }

        private void subreportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Report2 { MdiParent = this }.Show();
        }
    }
}
