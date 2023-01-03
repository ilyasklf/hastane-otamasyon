using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veritabanı
{
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doktor git = new doktor();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hemsire git = new hemsire();
            git.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guvenlik git = new guvenlik();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yonetici git = new yonetici();
            git.Show();
            this.Hide();
        }
    }
}
