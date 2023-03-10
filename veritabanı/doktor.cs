using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace veritabanı
{
    public partial class doktor : Form
    {
        public doktor()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=dbHastane;user ID=postgres;password=ilyas123");
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into personel (kisino,ad,soyad,yas) values(@k1,@k2,@k3,@k4)", baglanti);
            komut1.Parameters.AddWithValue("@k1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@k2", textBox2.Text);
            komut1.Parameters.AddWithValue("@k3", textBox3.Text);
            komut1.Parameters.AddWithValue("@k4", int.Parse(textBox4.Text));
            komut1.ExecuteNonQuery();

            NpgsqlCommand komut = new NpgsqlCommand("insert into doktor (kisino,brans,polino) values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", textBox5.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(comboBox1.SelectedValue.ToString()));  
            komut.ExecuteNonQuery();

            baglanti.Close();

        }

        private void doktor_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from poliklinik", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "poliad";
            comboBox1.ValueMember = "polino";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from doktor";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
