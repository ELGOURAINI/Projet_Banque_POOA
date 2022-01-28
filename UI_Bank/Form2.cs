using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI_Bank
{
    public partial class Form2 : Form
    {
        Client CLI;
        int id;
        public Form2(Client C,int id)
        {
            InitializeComponent();
            this.CLI = C;
            this.id = id;
            label1.Text = "Hey , "+C.nomC+ "\n\t\t" + C.prenomC;
            label7.Text =C.nomC;
            label8.Text =C.prenomC;
            label9.Text =C.adresse;
            label10.Text =C.login;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 F3 = new Form3(this.CLI,this.id);
            F3.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 F4 = new Form4(this.CLI, this.id);
            F4.Show();
        }
    }
}
