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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U561OEJ;Initial Catalog=bibliotheque;Integrated Security=True;Pooling=False");
        DataSet dsBiblio;
        BindingSource AdhérentBS = new BindingSource();
        SqlDataReader dr;
        SqlCommand cmd;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "update Thème set IntituléTh ='" + textBox2.Text + "' where CodeTh = '" + textBox1.Text + "'";
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

                string req = "delete from Thème  where CodeTh = '" + textBox1.Text + "'";
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
                string req = "select * from Thème";
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                db.DataSource = dt;
                this.textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add(new Binding("Text", db, "CodeTh"));
                this.textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add(new Binding("Text", db, "IntituléTh"));


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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string req = "select *  from Thème where CodeTh = " + textBox4.Text + "";
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                while (dr.Read())
                {
                    MessageBox.Show("" + dr[0] + " " + dr[1]);
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
            if(button1.Text == "Nouveau")
            {
                button1.Text = "Ajouter";

                    con.Open();

                    string req = "insert into Thème values (" + textBox1.Text + ",'" + textBox2.Text + "')";
                    SqlCommand sc = new SqlCommand(req, con);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Ajout bien fait");

                    con.Close();
            }
            else
            {
                button1.Text = "Nouveau";
                
                    con.Open();

                    string req = "insert into Thème values (" + textBox1.Text + ",'" + textBox2.Text + "')";
                    SqlCommand sc = new SqlCommand(req, con);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Ajout bien fait");

                    con.Close();

            }
           
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
