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
    public partial class poli : Form
    {
        public poli()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=dbHastane;user ID=postgres;password=ilyas123");
        DataSet daset = new DataSet();
        private void UrunListele()
        {
            baglanti.Open();
            NpgsqlDataAdapter adtr = new NpgsqlDataAdapter("select *from poliklinik", baglanti);
            adtr.Fill(daset, "poliklinik");
            dataGridView1.DataSource = daset.Tables["poliklinik"];
            baglanti.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into poliklinik (polino,poliad) values(@p1,@p2)", baglanti);
            int text1 = int.Parse(textBox1.Text);
            komut.Parameters.AddWithValue("@p1", text1);
            komut.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from poliklinik";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();


            //NpgsqlCommand komut3 = new NpgsqlCommand("Delete from doktor where polino=@p1", baglanti);
            //komut3.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            //komut3.ExecuteNonQuery(); 

            //NpgsqlCommand komut4 = new NpgsqlCommand("Delete from hemsire where polino=@p1", baglanti);
            //komut4.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            //komut4.ExecuteNonQuery();

            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from poliklinik where polino=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            komut2.ExecuteNonQuery();

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update poliklinik set poliad=@poliad", baglanti);
            komut.Parameters.AddWithValue("@polino", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@poliad", textBox2.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Clear();
            UrunListele();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tablo = new DataTable();
            //NpgsqlDataAdapter adtr = new NpgsqlDataAdapter("select *from poliklinik where poliad like '%" + textBox6.Text + "%'", baglanti);
            NpgsqlDataAdapter adtr = new NpgsqlDataAdapter("select *from poliklinik where polino between '" + textBox6.Text + "and'"+textBox6.Text, baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
