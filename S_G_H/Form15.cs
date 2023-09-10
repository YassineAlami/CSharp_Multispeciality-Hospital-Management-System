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
using MySql.Data;
using System.Configuration;


namespace S_G_H
{
    public partial class Form15 : Form
    {
        MySqlConnection SQLc = new MySqlConnection();
        MySqlCommand SQLcmd = new MySqlCommand();
        DataTable SQLdt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter SQLda = new MySqlDataAdapter();
        MySqlDataReader SQLrd;

        DataTable dt_table;
        DataSet ds = new DataSet();
        String server = "localhost";
        String user = "root";
        String psw = "";
        String database = "bd_Hopital_3";

        public Form15()
        {
            InitializeComponent();
            fill_Cbox_medi();
            fill_Cbox_med();
            fill_Cbox_inf();
            fill_Cbox_trai();
            fill_Cbox_pat();
        }

        private void fill_Cbox_pat()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM patient";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_pt");
                    comboBox5.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_inf()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM infirmiere";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_inf");
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_med()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM medecin";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_med");
                    comboBox3.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_medi()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM medicament";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_medi");
                    comboBox2.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_trai()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM type_traitement";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("lbl_type_trai");
                    comboBox4.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_medi FROM medicament WHERE id_medi= '" + comboBox2.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label4.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_inf, pnom_inf FROM infirmiere WHERE cin_inf= '" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label3.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_med, pnom_med FROM medecin WHERE cin_med= '" + comboBox3.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label20.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form6 f1 = new Form6();
            f1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_pt, pnom_pt FROM Patient WHERE cin_pt= '" + comboBox5.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label9.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO patient_medecin (cin_pt, cin_med) VALUES ( '" + comboBox5.SelectedItem + "', '" + comboBox3.SelectedItem + "' );";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Medecin Affecté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO patient_infirmier (cin_pt, cin_inf) VALUES ( '" + comboBox5.SelectedItem + "', '" + comboBox1.SelectedItem + "' );";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Infirmier Affecté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO patient_medicament (cin_pt, id_medi) VALUES ( '" + comboBox5.SelectedItem + "', '" + int.Parse(comboBox2.SelectedItem.ToString()) + "' );";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Medicament Affecté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO patient_traitement (cin_pt, lbl_type_trai) VALUES ( '" + comboBox5.SelectedItem + "', '" + comboBox4.SelectedItem + "' );";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Traitement Affecté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form16 f1 = new Form16();
            f1.Visible = true;
        }
    }
}
