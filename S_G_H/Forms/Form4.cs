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
using System.Runtime.InteropServices;

namespace S_G_H.Forms
{
    public partial class Form4 : Form
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
        String database = "bd_Hopital_3";

        public Form4()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.MinDate = DateTime.Today;
            fill_Cbox_pat();
            fill_Cbox_trai();
            charger_data_rdv_non_conf();

        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            panel1.BackColor = button3.BackColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label1.ForeColor = label3.ForeColor = label2.ForeColor = label4.ForeColor = ThemeColor.PrimaryColor;
            //label6.ForeColor = label7.ForeColor = label8.ForeColor = label9.ForeColor = Color.Black;
        }

        private void charger_data_rdv_non_conf()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            string date_l = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "SELECT rendez_vous.id_rdv as 'ID', Patient.cin_pt as 'CIN Patient', patient.nom_pt as 'Nom', patient.pnom_pt as 'Prenom', rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure from rendez_vous INNER JOIN Patient on Patient.cin_pt = rendez_vous.cin_pt where rendez_vous.confirme = 'N' and rendez_vous.cin_med= '"+S_G_H.Form3.user_app+"';";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void fill_Cbox_pat()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM patient_medecin WHERE patient_medecin.cin_med = '"+ S_G_H.Form3.user_app+"';";
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
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO rendez_vous (cin_pt, cin_med, date_rdv, heure_rdv, lbl_type_trai) VaLUES ('" + comboBox5.SelectedItem + "','"+ S_G_H.Form3.user_app +"',  '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '"+ comboBox1.SelectedItem+"');";
                MessageBox.Show("Rendez-Vous Ajouté Avec Succès", "Gestion Des Rendez-Vous", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                SQLc.Close();
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            finally {   SQLc.Close();   }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "UPDATE rendez_vous set cin_pt = @cin_pt, date_rdv = @date_rdv, heure_rdv = @heure_rdv WHERE cin_pt = '"+ S_G_H.Form3.user_app + "'";
                SQLcmd.Parameters.AddWithValue("@cin_pt", comboBox5.SelectedItem);
                SQLcmd.Parameters.AddWithValue("@date_rdv", dateTimePicker1.Text);
                SQLcmd.Parameters.AddWithValue("@heure_rdv", dateTimePicker2.Text);
                MessageBox.Show("Rendez-Vous Modifié", "Gestion Des Rendez-Vous", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("voulez-vous vraiment Annulé le Rendez-Vous?", "Gestion Des Rendez-Vous", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    try
                    {
                        SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

                        string query = "DELETE FROM Rendez_vous WHERE cin_pt ='" + comboBox5.SelectedItem + "' and date_rdv = '" + dateTimePicker1.Text + "';";

                        MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                        MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                        MySqlDataReader my_reader;
                        try
                        {
                            connection_database.Open();
                            my_reader = cmd_databes.ExecuteReader();
                            MessageBox.Show("Rendez-Vous Annulé", "Gestion Des Rendez-Vous", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            while (my_reader.Read())
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "UPDATE rendez_vous set rendez_vous.confirme = 'Y' WHERE rendez_vous.id_rdv = " +int.Parse(textBox1.Text) + "";

                MessageBox.Show("Rendez-Vous Confirmé", "Gestion Des Rendez-Vous", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
