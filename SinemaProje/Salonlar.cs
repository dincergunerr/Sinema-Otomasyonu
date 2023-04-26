using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinemaProje
{
    public partial class Salonlar : Form
    {
        public Salonlar()
        {
            InitializeComponent();
        }
        private void Salonlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }

        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\Database.accdb");
        DataSet table = new DataSet();
       
        private void Salonlar_Load(object sender, EventArgs e)
        {
            table.Clear();
            conn.Open();
            string sql = "select * from Salonlar";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(table);
            dataGridView1.DataSource = table.Tables[0];
            conn.Close();
            dataGridView1.Columns[0].AutoSizeMode= System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Salon Id";
            dataGridView1.Columns[1].HeaderText ="Salon No";

            //To change Column name
            /* dataGridView1.Columns[1].HeaderText = "Name";
             dataGridView1.Columns[4].HeaderText = "Position";*/
        }

        private void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            try{
                string sql = "INSERT INTO Salonlar(salon_no) values(@Salon_no)";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                ac.Parameters.AddWithValue("@Salon_no", textBox1.Text);
                ac.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show("Hata mesajı: "+ex.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            conn.Close();
            Salonlar_Load(sender, e);
           // textBox1.Refresh();
            //comboBox1.Refresh();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string sql = "DELETE FROM Salonlar where salon_id=@Salon_id";
                OleDbCommand ac = new OleDbCommand(sql, conn);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int salonID = Convert.ToInt32(row.Cells[0].Value);
                ac.Parameters.AddWithValue("@Salon_id", salonID);
                ac.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata mesajı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Salonlar_Load(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AnaMenu f1 = new AnaMenu();
            this.Hide();
            f1.Show();
        }
    }
}
