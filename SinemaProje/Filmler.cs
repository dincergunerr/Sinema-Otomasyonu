using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinemaProje
{
    public partial class Filmler : Form
    {
        public Filmler()
        {
            InitializeComponent();
        }

        private void Filmler_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\Database.accdb");
        DataSet table = new DataSet();
        private void Filmler_Load(object sender, EventArgs e)
        {
            table.Clear();
            conn.Open();
            string sql = "select * from Filmler";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(table);
            dataGridView1.DataSource = table.Tables[0];
            conn.Close();

            //film süreleri combobox
            film_Cb.Items.Add("01:00");
            film_Cb.Items.Add("01:30");
            film_Cb.Items.Add("02:00");
            film_Cb.Items.Add("02:30");
            film_Cb.Items.Add("03:00");
            //film türleri
            type_Cb.Items.Add("Aksiyon");
            type_Cb.Items.Add("Komedi");
            type_Cb.Items.Add("Fantazi");
            type_Cb.Items.Add("Korku");
            type_Cb.Items.Add("Romantik");
            type_Cb.Items.Add("Bilim kurgu");
            type_Cb.Items.Add("Müzikal");
            type_Cb.Items.Add("Animasyon");

            //datagrid
            dataGridView1.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Film Id";
            dataGridView1.Columns[1].HeaderText = "Film Adı";
            dataGridView1.Columns[2].HeaderText = "Film Türü";
            dataGridView1.Columns[3].HeaderText = "Film Süresi";
            dataGridView1.Columns[4].HeaderText = "Vizyon Tarihi";
            dataGridView1.Columns[5].HeaderText = "Afiş";

            //To change Column name
            /* dataGridView1.Columns[1].HeaderText = "Name";
             dataGridView1.Columns[4].HeaderText = "Position";*/

        }
        private void select_picture_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                //pictureBox1.ImageLocation = openFileDialog1.FileName;

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                //pictureBox1.Size= pictureBox1.Image.Size;
                //MessageBox.Show(openFileDialog1.FileName.ToString());
                //MessageBox.Show(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName);
                //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
                MessageBox.Show(Environment.CurrentDirectory);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata mesajı: Seçim yapılmadı!!" , "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string sql = "DELETE FROM Filmler where film_id=@Film_id";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                
                int salonID = Convert.ToInt32(row.Cells[0].Value);
                ac.Parameters.AddWithValue("@Film_id", salonID);
                ac.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata mesajı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Filmler_Load(sender, e);
        }
       
       
        private void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                Image img = pictureBox1.Image;
                Bitmap bmp = new Bitmap(img.Width, img.Height);
                Graphics gra = Graphics.FromImage(bmp);
                gra.DrawImageUnscaled(img, new Point(0, 0));
                gra.Dispose();
                var arr = openFileDialog1.FileName.Split('.');
                var myUniqueFileName = "\\pictures\\" + string.Format(@"{0}", Guid.NewGuid()) + "." + arr[1];
                bmp.Save(Environment.CurrentDirectory + myUniqueFileName, ImageFormat.Jpeg);
                //string picture_path = Environment.CurrentDirectory + myUniqueFileName;
                string picture_path = myUniqueFileName;
                bmp.Dispose();
                string sql = "INSERT INTO Filmler(film_name,film_type,film_time,vision_date,picture_path) values(@film_name,@film_type,@film_time,@vision_date,@picture_path)";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                ac.Parameters.AddWithValue("@film_name", filmName.Text);
                ac.Parameters.AddWithValue("@film_type", type_Cb.SelectedItem.ToString());
                ac.Parameters.AddWithValue("@film_time", film_Cb.SelectedItem.ToString());
                ac.Parameters.AddWithValue("@vision_date", dateTimePicker1.Text);
                ac.Parameters.AddWithValue("@picture_path", picture_path);

                ac.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata mesajı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Filmler_Load(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            //MessageBox.Show(bugun.ToString());
            if (bugun > yeni)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }
        
    }
}
