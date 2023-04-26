using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinemaProje
{
    public partial class Seanslar : Form
    {
        public Seanslar()
        {
            InitializeComponent();
        }
        private void Seanslar_FormClosing(object sender, FormClosingEventArgs e)
        {

            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\Database.accdb");
        DataSet table = new DataSet();

        private void Seanslar_Load(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            table.Clear();
            conn.Open();
            string sql = "select * from Seanslar";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(table);
            dataGridView1.DataSource = table.Tables[0];
            conn.Close();
            for (int i = 9; i <= 21; i++)
            {
                string saat = String.Format("{0}:00", i);
                if (i == 9) { saat = String.Format("0{0}:00", i); }
                baslangic_cb.Items.Add(saat);
            }
            ShowFilmVeSalon(filmAdi_cb, "select * from Filmler", "film_name");
            ShowFilmVeSalon(salonNo_cb, "select * from Salonlar", "salon_no");

            //Datagrid
            dataGridView1.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "Seans Id";
            dataGridView1.Columns[1].HeaderText = "Film Adı";
            dataGridView1.Columns[2].HeaderText = "Salon No";
            dataGridView1.Columns[3].HeaderText = "Başlangıç Saati";
            dataGridView1.Columns[4].HeaderText = "Bitiş Saati";
            dataGridView1.Columns[5].HeaderText = "Seans Tarihi";
        }

        private void ShowFilmVeSalon(System.Windows.Forms.ComboBox comboBox, string sql, string sql2)
        {
            conn.Open();
            OleDbCommand komut = new OleDbCommand(sql, conn);
            OleDbDataReader reader = komut.ExecuteReader();
            while (reader.Read() == true)
            {
                comboBox.Items.Add(reader[sql2].ToString());
            }
            conn.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string sql = "DELETE FROM Seanslar where seans_id=@seans_id";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int SeansID = Convert.ToInt32(row.Cells[0].Value);
                ac.Parameters.AddWithValue("@seans_id", SeansID);
                ac.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata mesajı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Seanslar_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, EventArgs e)
        {

            conn.Open();
            string sql = "select picture_path FROM Filmler where film_name=@film_name";
            OleDbCommand ac = new OleDbCommand(sql, conn);
            DataGridViewRow row = new DataGridViewRow();

            try
            {
                row = dataGridView1.SelectedRows[0];
                ac.Parameters.AddWithValue("@film_name", row.Cells[1].Value);
                OleDbDataReader reader = ac.ExecuteReader();
                reader.Read();
                var a = String.Format(Environment.CurrentDirectory + reader[0].ToString());
                //MessageBox.Show(a);
                pictureBox1.ImageLocation = a;
            }
            catch (Exception)
            {
                MessageBox.Show("Sol taraftaki satır başlığını seçiniz");
            }
            conn.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sqlTxt = "select film_time FROM Filmler where film_name=@film_name";
            OleDbCommand dc = new OleDbCommand(sqlTxt, conn);
            dc.Parameters.AddWithValue("@film_name", filmAdi_cb.Text);
            OleDbDataReader reader = dc.ExecuteReader();
            reader.Read();
            var a = reader[0].ToString();

            var deneme = baslangic_cb.SelectedItem.ToString().Split(':');
            var deneme2 = a.Split(':');
            var birlestir1 = Convert.ToInt32(deneme[0]) + Convert.ToInt32(deneme2[0]);
            var birlestir2 = Convert.ToInt32(deneme[1]) + Convert.ToInt32(deneme2[1]);
            string deneme4 = birlestir2.ToString();
            if (birlestir2 == 0) { deneme4 = "00"; }
            var deneme3 = String.Format(birlestir1 + ":" + deneme4);


            try
            {

                string sql = "INSERT INTO Seanslar(film_adi,salon_no,seans_baslangic,seans_bitis,seans_tarihi) values(@film_adi,@salon_no,@seans_baslangic,@seans_bitis,@seans_tarihi)";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                ac.Parameters.AddWithValue("@film_adi", filmAdi_cb.Text);
                ac.Parameters.AddWithValue("@salon_no", salonNo_cb.SelectedItem.ToString());
                ac.Parameters.AddWithValue("@seans_baslangic", baslangic_cb.SelectedItem.ToString());
                ac.Parameters.AddWithValue("@seans_bitis", deneme3);
                ac.Parameters.AddWithValue("@seans_tarihi", tarih_cb.Text);

                ac.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata mesajı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Seanslar_Load(sender, e);
        }
        private bool SeansCheck()
        {

            try
            {
                conn.Open();
                string sql = "select * from Seanslar where salon_no=@salon_no and seans_baslangic=@seans_baslangic";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                ac.Parameters.AddWithValue("@salon_no", salonNo_cb.SelectedItem.ToString());
                ac.Parameters.AddWithValue("@seans_baslangic", baslangic_cb.SelectedItem.ToString());
                OleDbDataReader reader = ac.ExecuteReader();
                reader.Read();
                var a = reader[0].ToString();
                conn.Close();
                return false;
            }
            catch (Exception)
            {
                conn.Close();
                return true;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }

        private void baslangic_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            var deneme = SeansCheck();
            if (deneme == true)
            {
                MessageBox.Show("Bu salonda ve seçilen saatde zaten bir seans var lütfen başka bir seans saati seçiniz.");
                baslangic_cb.SelectedItem = "";
            }
            else if (deneme == false)
            {
                try
                {
                    conn.Open();
                    string sql = "select seans_bitis from Seanslar where salon_no=@salon_no and seans_baslangic=@seans_baslangic";
                    OleDbCommand ac = new OleDbCommand(sql, conn);
                    ac.Parameters.AddWithValue("@salon_no", salonNo_cb.SelectedItem.ToString());
                    ac.Parameters.AddWithValue("@seans_baslangic", baslangic_cb.SelectedItem.ToString());
                    OleDbDataReader reader = ac.ExecuteReader();
                    reader.Read();
                    conn.Close();
                    var a = reader[0].ToString();
                    var selected = baslangic_cb.SelectedItem.ToString().Split(':');
                    var data = a.Split(':');
                    if (Convert.ToInt32(selected[0]) == Convert.ToInt32(data[0]))
                    {
                        if (Convert.ToInt32(data[1]) != 0)
                        {
                            MessageBox.Show("Seçilen salonda ve bu saat diliminde zaten bir seans devam ediyor lütfen başka bir saat seç.");
                            baslangic_cb.SelectedItem = "";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Salon No seçmeden seçim yapmayınız.");
                    baslangic_cb.SelectedItem = "";
                }

            }


        }

        private void tarih_cb_ValueChanged(object sender, EventArgs e)
        {

            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(tarih_cb.Text);
            //MessageBox.Show(bugun.ToString());
            if (bugun > yeni)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz", "Uyarı");
                tarih_cb.Text = DateTime.Now.ToShortDateString();
            }
            else if (yeni >= bugun)
            {
                try
                {
                    conn.Open();
                    string sql = "select vision_date from Filmler where film_name=@film_name";
                    OleDbCommand ac = new OleDbCommand(sql, conn);
                    ac.Parameters.AddWithValue("@film_name", filmAdi_cb.SelectedItem.ToString());
                    OleDbDataReader reader = ac.ExecuteReader();
                    reader.Read();
                    var a = reader[0].ToString();
                    conn.Close();
                    if (DateTime.Parse(a) > DateTime.Parse(tarih_cb.Text))
                    {
                        MessageBox.Show("Filmin vizyon tarihinden önce seans eklenemez.");
                        tarih_cb.Text = DateTime.Now.ToShortDateString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Film adı seçilmeden tarih seçilemez." + ex);
                    tarih_cb.Text = DateTime.Now.ToShortDateString();
                }
            }




        }
    }
}

