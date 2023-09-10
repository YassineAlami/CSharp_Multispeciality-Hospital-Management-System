using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace S_G_H
{
    public partial class Form9 : Form
    {
        MySqlConnection SQLc = new MySqlConnection();
        MySqlCommand SQLcmd = new MySqlCommand();
        DataTable SQLdt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter SQLda = new MySqlDataAdapter();
        MySqlDataReader SQLrd;

        DataSet ds = new DataSet();
        String server = "localhost";
        String user = "root";
        String psw = "";
        String database = "bd_hopital_3";

        public Form9()
        {
            InitializeComponent();
            fill_Cbox_q();
        }
        private void fill_Cbox_q()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM `recuperer_mdp`";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_q");
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Enter Your Email")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == "Enter Your Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '⦿';
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(textBox3.Text== "Confirm Your Password")
            {
                textBox3.Text = "";
                textBox3.PasswordChar = '⦿';
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            SQLc.Open();
            try
            { 
            if(radioButton1.Checked==true)
            {
                sqlQuery = "select * from Medecin where email_med= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                int cpt = 0;
                while (SQLrd.Read()){   cpt++;  }
                if (cpt == 0)
                {
                    MessageBox.Show("La Création de Votre Compte a échoué", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SQLc.Close();
                }
                else
                { 
                    MessageBox.Show("Votre Compte a été Créé Avec Succès", "Compte Créé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                    SQLc.Open();
                    sqlQuery = "INSERT INTO User_App (email_user, psw_user, type_user,id_q,rep_q) VALUES ('" + textBox1.Text + "','" + textBox2.Text+ "','Medecin','"+comboBox1.SelectedItem+"','"+textBox4.Text+"');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    SQLc.Close();
                    this.Visible = false;
                    Form3 f = new Form3();
                    f.Visible = true;
                }
            }
            else if(radioButton3.Checked==true)
            {
                sqlQuery = "select * from Infirmiere where email_inf= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                int cpt = 0;
                while (SQLrd.Read()) { cpt++; }
                if (cpt == 0)
                {
                    MessageBox.Show("La Création de Votre Compte a échoué", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SQLc.Close();
                }
                else
                {
                    MessageBox.Show("Votre Compte a été Créé Svec Succès", "Compte Créé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();

                    SQLc.Open();
                    sqlQuery = "INSERT INTO User_App (email_user, psw_user, type_user,id_q,rep_q) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','Infirmier','"+comboBox1.SelectedItem+"','"+textBox4.Text+"');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    SQLc.Close();

                    this.Visible = false;
                    Form3 f = new Form3();
                    f.Visible = true;
                }
            }
            else if(radioButton2.Checked==true)
            {
                sqlQuery = "select * from Patient where email_pt= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                int cpt = 0;
                while (SQLrd.Read()) { cpt++; }
                if (cpt == 0)
                {
                    MessageBox.Show("La Création de Votre Compte a échoué", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Votre Compte a été Créé Svec Succès", "Compte Créé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();

                    SQLc.Open();
                    sqlQuery = "INSERT INTO User_App (email_user, psw_user, type_user,id_q,rep_q) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','Patient','"+comboBox1.SelectedItem+"','"+textBox4.Text+"');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    SQLc.Close();

                    this.Visible = false;
                    Form3 f = new Form3();
                    f.Visible = true;
                }
            }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f1 = new Form2();
            f1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text = textBox2.Text = "";
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT txt_q FROM `recuperer_mdp` WHERE id_q = '" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label6.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }
    }
}
