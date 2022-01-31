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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U561OEJ;Initial Catalog=bibliotheque;Integrated Security=True;Pooling=False");
        DataSet dsBiblio;
        BindingSource AdhérentBS = new BindingSource();
        SqlDataReader dr;
        SqlCommand cmd;
        
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "update Adherent set NomA ='" + textBox2.Text + "', Adresse = " + textBox3.Text + ", DateInscription = '" + dateTimePicker1.Value + "' where CodeA = " + textBox1.Text + "";
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

                string req = "Delete from Adherent where CodeA = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Suppression bien faite");

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        BindingSource db = new BindingSource();
        public DataTable dt = new DataTable();
        public void Naviguer()
        {
            try
            {
                con.Open();
                string req = "select * from Adherent";
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                db.DataSource = dt;
                this.textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add(new Binding("Text", db, "CodeTh"));
                this.textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add(new Binding("Text", db, "NomA"));
                this.textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add(new Binding("Text", db, "Adresse"));
                this.dateTimePicker1.DataBindings.Clear();
                dateTimePicker1.DataBindings.Add(new Binding("Text", db, "DateInscription"));

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur" + ex.Message);
            }

            con.Close();
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "select *  from Adherent where CodeA = " + textBox4.Text + "";
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                
                while (dr.Read())
                {
                    MessageBox.Show("" + dr[0] +" "+ dr[1] + " " +  dr[2] + " " +  dr[3]);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "insert into Adherent values (" + textBox1.Text + ",'" + textBox2.Text + "','"+textBox3.Text+"','"+dateTimePicker1.Value+"')";
                SqlCommand sc = new SqlCommand(req, con);
                sc.ExecuteNonQuery();
                MessageBox.Show("Ajout bien fait");

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }
    }
}
