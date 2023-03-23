namespace Books.Book
{
    partial class BookEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.BookAddbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PublisherIdCB = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BookIdCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 184);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(146, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(163, 20);
            this.textBox3.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Cover Price";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = " ";
            this.openFileDialog1.Filter = "JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Publish Date";
            // 
            // BookAddbtn
            // 
            this.BookAddbtn.Location = new System.Drawing.Point(50, 346);
            this.BookAddbtn.Name = "BookAddbtn";
            this.BookAddbtn.Size = new System.Drawing.Size(107, 36);
            this.BookAddbtn.TabIndex = 43;
            this.BookAddbtn.Text = "Update";
            this.BookAddbtn.UseVisualStyleBackColor = true;
            this.BookAddbtn.Click += new System.EventHandler(this.BookAddbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(378, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Picture";
            // 
            // PublisherIdCB
            // 
            this.PublisherIdCB.DisplayMember = "publishername";
            this.PublisherIdCB.FormattingEnabled = true;
            this.PublisherIdCB.Location = new System.Drawing.Point(146, 298);
            this.PublisherIdCB.Name = "PublisherIdCB";
            this.PublisherIdCB.Size = new System.Drawing.Size(122, 21);
            this.PublisherIdCB.TabIndex = 39;
            this.PublisherIdCB.ValueMember = "publisherid";
            this.PublisherIdCB.SelectedIndexChanged += new System.EventHandler(this.PublisherIdCB_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(146, 220);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(163, 20);
            this.textBox2.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Publisher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "IsAvailable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Book Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "bookid";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 36);
            this.button2.TabIndex = 48;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BookIdCB
            // 
            this.BookIdCB.DisplayMember = "bookid";
            this.BookIdCB.FormattingEnabled = true;
            this.BookIdCB.Location = new System.Drawing.Point(146, 41);
            this.BookIdCB.Name = "BookIdCB";
            this.BookIdCB.Size = new System.Drawing.Size(122, 21);
            this.BookIdCB.TabIndex = 49;
            this.BookIdCB.ValueMember = "bookid";
            this.BookIdCB.SelectedIndexChanged += new System.EventHandler(this.BookIdCB_SelectedIndexChanged);
            // 
            // BookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 415);
            this.Controls.Add(this.BookIdCB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BookAddbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PublisherIdCB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookEdit";
            this.Text = "BookEdit";
            this.Load += new System.EventHandler(this.BookEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BookAddbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PublisherIdCB;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox BookIdCB;
    }
}