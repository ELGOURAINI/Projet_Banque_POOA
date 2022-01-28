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
    public partial class Form4 : Form
    {
        int id;
        Client client;
        List<Compte> compte_cli;
        public Form4(Client C, int id)
        {
            InitializeComponent();
            this.client = C;
            this.id = id;
            this.compte_cli = new List<Compte>();
            label1.Text = "Hey , " + C.nomC + " \n\t\t" + C.prenomC;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //panel5.Show();
            string S;
            //SqlDataReader reader;
            //SqlCommand cmd2, cmd1;

            S = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BANK;Integrated Security=True;Pooling=False";
            SqlConnection conn = new SqlConnection(S);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Operations", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F1 = new Form2(this.client, this.id);
            F1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string S;
            int i = 0;
            SqlDataReader reader;

            S = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BANK;Integrated Security=True;Pooling=False";
            SqlConnection conn = new SqlConnection(S);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Comptes where Comptes.idCli=" + this.id, conn);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add( "Compte" + reader.GetValue(0).ToString()) ;
                i++;
            }

        }
    }
}
