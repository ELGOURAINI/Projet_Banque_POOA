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
    public partial class Form1 : Form
    {
        //les attributs
        List<Client> clients = new List<Client>();
        Client c1;
        public Form1()
        {
            InitializeComponent();
            clients.Add(c1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lg, ps,S;
            bool b= false;
            SqlDataReader reader;
            lg = textBox1.Text;
            ps = textBox2.Text;
            S = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BANK;Integrated Security=True;Pooling=False";
            SqlConnection conn = new SqlConnection(S);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Clients",conn);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                    if (reader.GetValue(4).ToString() == lg && reader.GetValue(5).ToString() == ps )
                    {
                        this.c1 = new Client(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());
                        b= true;
                        break;
                    }
            }  
            if(b==true)
            {
                //MessageBox.Show(c1.afficher());
                this.Hide();
                Form2 F1 = new Form2(c1, Int32.Parse(reader.GetValue(0).ToString()));
                F1.Show();
            }
            else
            {
                MessageBox.Show("Hey Visitor!!!!  Vous n'avez pas déjà un compte !! \n\n   " +
                                "         Vous pouvez pas se connectez");
            }

            //Form2 a1;
            /*for (int i = 0; i < clients.Count(); i++)
            {
                if (clients[i].auth(lg, ps))
                {
                    this.Hide();
                    //Client_auth = clients[i];
                    *//*a1 = new Form2(clients[i].nom, clients[i].prenom, clients[i].CIN);
                    a1.Show();*//*
                    MessageBox.Show(clients[i].afficher());
                }
                else
                {
                    MessageBox.Show("hey !!!!  Error!!");
                }
            }*/

        }
    }
}
