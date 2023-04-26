namespace SinemaProje
{
    partial class Seanslar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seanslar));
            this.salonNo_cb = new System.Windows.Forms.ComboBox();
            this.filmAdi_cb = new System.Windows.Forms.ComboBox();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.baslangic_cb = new System.Windows.Forms.ComboBox();
            this.tarih_cb = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // salonNo_cb
            // 
            this.salonNo_cb.FormattingEnabled = true;
            this.salonNo_cb.Location = new System.Drawing.Point(106, 80);
            this.salonNo_cb.Name = "salonNo_cb";
            this.salonNo_cb.Size = new System.Drawing.Size(126, 23);
            this.salonNo_cb.TabIndex = 0;
            // 
            // filmAdi_cb
            // 
            this.filmAdi_cb.FormattingEnabled = true;
            this.filmAdi_cb.Location = new System.Drawing.Point(106, 35);
            this.filmAdi_cb.Name = "filmAdi_cb";
            this.filmAdi_cb.Size = new System.Drawing.Size(126, 23);
            this.filmAdi_cb.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.BackgroundImage = global::SinemaProje.Properties.Resources.Cinema_Add_Ticket_icon;
            this.Add.ForeColor = System.Drawing.Color.Transparent;
            this.Add.Image = global::SinemaProje.Properties.Resources.Icons8_Ios7_Programming_Add_Property;
            this.Add.Location = new System.Drawing.Point(12, 218);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(212, 49);
            this.Add.TabIndex = 2;
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.ForeColor = System.Drawing.Color.Transparent;
            this.Delete.Image = global::SinemaProje.Properties.Resources.Roundicons_100_Free_Solid_Cancel;
            this.Delete.Location = new System.Drawing.Point(770, 383);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(126, 35);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Sil";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // baslangic_cb
            // 
            this.baslangic_cb.FormattingEnabled = true;
            this.baslangic_cb.Location = new System.Drawing.Point(151, 124);
            this.baslangic_cb.Name = "baslangic_cb";
            this.baslangic_cb.Size = new System.Drawing.Size(81, 23);
            this.baslangic_cb.TabIndex = 4;
            this.baslangic_cb.SelectedIndexChanged += new System.EventHandler(this.baslangic_cb_SelectedIndexChanged);
            // 
            // tarih_cb
            // 
            this.tarih_cb.CalendarFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarih_cb.Location = new System.Drawing.Point(139, 172);
            this.tarih_cb.Name = "tarih_cb";
            this.tarih_cb.Size = new System.Drawing.Size(93, 25);
            this.tarih_cb.TabIndex = 5;
            this.tarih_cb.ValueChanged += new System.EventHandler(this.tarih_cb_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.filmAdi_cb);
            this.groupBox1.Controls.Add(this.tarih_cb);
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.salonNo_cb);
            this.groupBox1.Controls.Add(this.baslangic_cb);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 295);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seans Ekle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seans Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Seans Baslangıcı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Salon No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Film Adı";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(469, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(434, 285);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(256, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(465, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Seçileni silmek için tıkla ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Image = global::SinemaProje.Properties.Resources.Rafiqul_Hassan_Blogger_Arrow_Back_4;
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(20, 0, 15, 0);
            this.label5.Size = new System.Drawing.Size(35, 37);
            this.label5.TabIndex = 16;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Seanslar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SinemaProje.Properties.Resources.de8bcd63_43c3_463b_892f_b149a94afca1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(910, 451);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Delete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Seanslar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seanslar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Seanslar_FormClosing);
            this.Load += new System.EventHandler(this.Seanslar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox salonNo_cb;
        private System.Windows.Forms.ComboBox filmAdi_cb;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox baslangic_cb;
        private System.Windows.Forms.DateTimePicker tarih_cb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
    }
}