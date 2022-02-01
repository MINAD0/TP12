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

namespace TP12
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U561OEJ;Initial Catalog=bibliotheque;Integrated Security=True;Pooling=False");
        DataSet dsBiblio;
        BindingSource AdhérentBS = new BindingSource();
        SqlDataReader dr;
        SqlCommand cmd;
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bibliothequeDataSet1.Thème' table. You can move, or remove it, as needed.
            this.thèmeTableAdapter.Fill(this.bibliothequeDataSet1.Thème);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Nouveau")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.ResetText();
                button1.Text = "Ajouter";

            }
            else if (button1.Text == "Ajouter")
            {
                con.Open();

                string req = "insert into Livre values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "')";
                SqlCommand sc = new SqlCommand(req, con);
                sc.ExecuteNonQuery();
                MessageBox.Show("Ajout bien fait");

                con.Close();

                button1.Text = "Nouveau";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "update Livre set Titre ='" + textBox2.Text + "' Auteur='" + textBox3.Text + "' NbExemplaires='"+dateTimePicker1.Value+"' where CodeTh = '" + textBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modifcation bien faite");

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "delete from Livre  where CodeL = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("supprission bien faite");

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        BindingSource db = new BindingSource();
        public DataTable dt = new DataTable();
        public void Naviguer()
        {
            try
            {
                con.Open();
                string req = "select * from Livre";
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                db.DataSource = dt;
                this.textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add(new Binding("Text", db, "CodeL"));
                this.textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add(new Binding("Text", db, "Titre"));
                this.textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add(new Binding("Text", db, "Auteur"));
                this.dateTimePicker1.DataBindings.Clear();
                textBox2.DataBindings.Add(new Binding("Text", db, "NbExemplaires"));
                this.comboBox1.DataBindings.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur" + ex.Message);
            }

            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Naviguer();
            db.MoveFirst();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Naviguer();
            db.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Naviguer();
            db.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Naviguer();
            db.MoveLast();
        }
    }
}
