using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinemaProje
{
    public partial class BiletAl : Form
    {
        public BiletAl()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\Database.accdb");
        private void BiletAl_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
        private void BiletAl_Load(object sender, EventArgs e)
        {
            BosKoltuklar();
            ComboBoxItems(comboBox1, "select * from Filmler", "film_name");
           
            //ComboFilmVeSalon(comboBox2, "select * from Salonlar", "salon_no");
        }
        private void ComboBoxItems(System.Windows.Forms.ComboBox combo, string sql1, string sql2)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand(sql1, conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                combo.Items.Add(reader[sql2].ToString());
            }
            conn.Close();

        }
        private void BeyazaBoya()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is System.Windows.Forms.Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        private void BosKoltuklar()
        {
            int ctr = 1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Size = new Size(30, 30);
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 35 + 10, i * 40 + 10);
                    btn.Name = ctr.ToString();
                    btn.Text = ctr.ToString();
                    ctr++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            if (b.BackColor == Color.White)
            {
                textBox1.Text = b.Text;
            }
        }

        private void ComboDoluKoltuklar()
        {
            koltukSil_cb.Items.Clear();
            koltukSil_cb.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is System.Windows.Forms.Button)
                {
                    if (item.BackColor == Color.Gray)
                    {
                        koltukSil_cb.Items.Add(item.Text);
                    }
                }
            }
        }

        private void DoluKoltuklar()
        {
            conn.Open();
            string sql = String.Format("select * from Biletler where film_adi='" + comboBox1.SelectedItem + "' and salon_no='" + comboBox2.SelectedItem + "'" +
                " and seans_tarihi='" + comboBox3.SelectedItem + "' and seans_saati ='" + comboBox4.SelectedItem + "' ");
            OleDbCommand command = new OleDbCommand(sql, conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is System.Windows.Forms.Button)
                    {
                        if (reader["koltuk_no"].ToString() == item.Text)
                        {
                            item.BackColor = Color.Gray;
                        }
                    }
                }
            }
            conn.Close();
        }
        private void FilmResmi()
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand("select * from Filmler where film_name='" + comboBox1.SelectedItem + "'", conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                pictureBox1.ImageLocation = reader["picture_path"].ToString();
            }
            conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilmResmi();
            BeyazaBoya();
            Salonlar();
            //ComboDoluKoltuklar();
            koltukSil_cb.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Salonlar()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            conn.Open();
            string sql = "select salon_no from Seanslar where film_adi=@film_adi";

            OleDbCommand command = new OleDbCommand(sql, conn);
            command.Parameters.AddWithValue("@film_adi", comboBox1.Text);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["salon_no"].ToString());
            }
            conn.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeansTarihi();
            BeyazaBoya();
            //ComboDoluKoltuklar();
            koltukSil_cb.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void SeansTarihi()
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            conn.Open();
            OleDbCommand command = new OleDbCommand("select * from Seanslar where film_adi='" + comboBox1.SelectedItem + "' and salon_no= '" + comboBox2.SelectedItem + "'", conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (DateTime.Parse(reader["seans_tarihi"].ToString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!comboBox3.Items.Contains(reader["seans_tarihi"].ToString()))
                    {
                        comboBox3.Items.Add(reader["seans_tarihi"].ToString());
                    }
                }
            }
            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeansSaati();
            BeyazaBoya();
            //ComboDoluKoltuklar();
            koltukSil_cb.Items.Clear();
        }
        private void SeansSaati()
        {
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            conn.Open();
            OleDbCommand command = new OleDbCommand("select * from Seanslar where film_adi='" + comboBox1.SelectedItem + "' and salon_no= '" + comboBox2.SelectedItem + "' and seans_tarihi='" + comboBox3.SelectedItem + "'", conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                if (DateTime.Parse(reader["seans_tarihi"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(reader["seans_baslangic"].ToString()) > DateTime.Parse(DateTime.Now.ToShortTimeString()))
                    {
                        comboBox4.Items.Add(reader["seans_baslangic"].ToString());
                    }


                }

                else if (DateTime.Parse(reader["seans_tarihi"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    comboBox4.Items.Add(reader["seans_baslangic"].ToString());
                }
            }
            conn.Close();

        }
        

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeyazaBoya();
            DoluKoltuklar();
            ComboDoluKoltuklar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (koltukSil_cb.Text != "")
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Biletler where film_adi=@film_adi and salon_no=@salon_no and seans_tarihi=@seans_tarihi and seans_saati=@seans_saati and koltuk_no=@koltuk_no";
                    OleDbCommand ac = new OleDbCommand(sql, conn);
                    ac.Parameters.AddWithValue("@film_adi", comboBox1.SelectedItem);
                    ac.Parameters.AddWithValue("@salon_no", comboBox2.SelectedItem);
                    ac.Parameters.AddWithValue("@seans_tarihi", comboBox3.SelectedItem);
                    ac.Parameters.AddWithValue("@seans_saati", comboBox4.SelectedItem);
                    ac.Parameters.AddWithValue("@koltuk_no", koltukSil_cb.SelectedItem);
                    ac.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi.", "Başarılı");
                    conn.Close();
                    BeyazaBoya();
                    DoluKoltuklar();
                    ComboDoluKoltuklar();
                   
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu " + hata.Message, "Uyarı");

                }
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapılmadı!", "Uyarı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    conn.Open();
                    textBox2.Text = "";

                    string sql = "INSERT INTO Biletler(film_adi,salon_no,seans_tarihi,seans_saati,satis_zamani,isim_soyisim,bilet_ucreti,koltuk_no) values(@film_adi,@salon_no,@seans_tarihi,@seans_saati,@satis_zamani,@isim_soyisim,@bilet_ucreti,@koltuk_no)";
                    OleDbCommand ac = new OleDbCommand(sql, conn);
                    ac.Parameters.AddWithValue("@film_adi", comboBox1.SelectedItem);
                    ac.Parameters.AddWithValue("@salon_no", comboBox2.SelectedItem);
                    ac.Parameters.AddWithValue("@seans_tarihi", comboBox3.SelectedItem);
                    ac.Parameters.AddWithValue("@seans_saati", comboBox4.SelectedItem.ToString());
                    ac.Parameters.AddWithValue("@satis_zamani", DateTime.Now.ToString());
                    ac.Parameters.AddWithValue("@isim_soyisim", textBox2.Text);
                    ac.Parameters.AddWithValue("@bilet_ucreti", comboBox5.SelectedItem);
                    ac.Parameters.AddWithValue("@koltuk_no", textBox1.Text);
                    ac.ExecuteNonQuery();

                    conn.Close();
                    BeyazaBoya();
                    DoluKoltuklar();
                    ComboDoluKoltuklar();
                    
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu!" + hata.Message, "Hata");
                }
                textBox1.Text = "";

                MessageBox.Show("Bilet satışı başarıyla tamamlanmıştır", "Başarılı");
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapılmadı!", "Hata");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
    }
}
