using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace S_G_H
{
    public partial class Form20 : Form
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

        int id_q = 0;
        string rep_q = "";
        public Form20()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "select email_user, id_q, rep_q from user_app where email_user= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    id_q = int.Parse(SQLrd.GetString(1));
                    rep_q = SQLrd.GetString(2);
                }
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            if(id_q!=0)
            {
                try
                {
                    SQLc.Open();
                    
                    sqlQuery = "SELECT txt_q FROM `recuperer_mdp` WHERE id_q= " + id_q + "";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    if (SQLrd.Read())
                    {
                        label1.Visible = true;
                        label1.Text = SQLrd.GetString(0);
                        button1.Visible = false;
                        textBox3.Visible = button3.Visible = true;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
            else
            {
                MessageBox.Show("Cet Email n'est pas enregistré. Veuillez Réessayer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            if (textBox2.Text == textBox4.Text)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE user_app set psw_user= '"+textBox2.Text +"' WHERE email_user = '"+textBox1.Text+"'";
                    MessageBox.Show("Mot de  Passe Modifié. Veuillez Réessayer", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) {  MessageBox.Show(ex.Message);  }
                SQLc.Close();

                this.Visible = false;
                Form2 f = new Form2();
                f.Visible = true;
            }
            else
            {
                MessageBox.Show("Mot de  Passe Incorrect. Veuillez Réessayer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(rep_q == textBox3.Text)
            {
                MessageBox.Show("ok");
                button3.Visible = false;
                textBox4.Visible = textBox2.Visible = button2.Visible = true;
            }
            else
            {
                MessageBox.Show("Fausse Réponse. Veuillez Réessayer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
