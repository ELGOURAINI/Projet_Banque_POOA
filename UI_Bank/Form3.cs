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
    public partial class Form3 : Form
    {
        int id;
        Client client;
        List<Compte> compte_cli;
        public Form3(Client C,int id)
        {
            InitializeComponent();
            this.client = C;
            this.id = id;
            this.compte_cli = new List<Compte>();
            label1.Text = "Hey , " + C.nomC + " \n\t\t" + C.prenomC;
        }
        public List<int> Request_Result_Compte(int Id,SqlConnection conn)
        {
            SqlDataReader reader;
            List<int> lst = new List<int>();
            SqlCommand cmd = new SqlCommand("Select * from Comptes where Comptes.idCli=" +Id, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lst.Add(Int32.Parse(reader.GetValue(0).ToString()));
            }
            return lst;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //panel5.Show();
            panel3.Hide();
            string S;
            SqlDataReader reader;
            //SqlCommand cmd2, cmd1;

            S = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BANK;Integrated Security=True;Pooling=False";
            SqlConnection conn = new SqlConnection(S);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Comptes where Comptes.idCli=" + this.id, conn);
            //reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetValue(3).ToString() == "Compte Epargne")
                    this.compte_cli.Add(new CompteEpargne(this.client, double.Parse(reader.GetValue(2).ToString()), 0.0));
                else if (reader.GetValue(3).ToString() == "Compte Courant")
                    this.compte_cli.Add(new CompteCrt(this.client, double.Parse(reader.GetValue(2).ToString())));

            }
            reader.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F1 = new Form2(this.client, this.id);
            F1.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            panel3.Show();
            //textBox1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            panel3.Show();
            //textBox1.Show();
        }
        /*SqlDataAdapter da = new SqlDataAdapter();
DataTable dt = new DataTable();

da.SelectCommand = cmd;

dt.Clear();
da.Fill(dt);
dataGridView1.DataSource = dt;*/
    }
}
