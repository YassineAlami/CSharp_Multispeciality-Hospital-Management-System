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
using System.Globalization;

namespace S_G_H
{
    public partial class Form18 : Form
    {
        MySqlConnection SQLc = new MySqlConnection();
        MySqlCommand SQLcmd = new MySqlCommand();
        DataTable SQLdt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter SQLda = new MySqlDataAdapter();
        MySqlDataReader SQLrd;
        BindingSource SQLbs = new BindingSource();

        DataSet ds = new DataSet();
        String server = "localhost";
        String user = "root";
        String psw = "";
        String database = "bd_Hopital_3";

        DateTime DT = new DateTime();
        public Form18()
        {
            InitializeComponent();
            DT = dateTimePicker1.MinDate = dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Today;
            fill_Cbox_nom_med();
            //charger_data();
        }

        private void clear_DGV()
        {
            DataTable DT = (DataTable)dataGridView2.DataSource;
            if (DT != null)
                DT.Clear();
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            DateTime D = new DateTime();
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "SELECT DISTINCT medecin.cin_med as 'ID Medecin', concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin, Medecin.genre_med as Genre, specialite.lib_spe as Specialite, medecin_service.date_serv as Date from medecin_service INNER JOIN medecin INNER join specialite on medecin.cin_med = medecin_service.cin_med AND medecin.id_spe = specialite.id_spe where medecin_service.date_serv =  '"+ DT.ToString("yyyy-MM-dd") + "';";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void fill_Cbox_nom_med()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Medecin";
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
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_med, pnom_med FROM Medecin WHERE cin_med = '" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label4.Text = "Dr. "+SQLrd.GetString(0) +"  "+ SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownHeight = comboBox1.ItemHeight * 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            
            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO medecin_service (cin_med, date_serv) VaLUES        ('" + comboBox1.SelectedItem + "','" + dateTimePicker1.Text + "');";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Medecin Ajoute au Service", "Manipulation ervice de Garde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
            clear_DGV();
            charger_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            
            string query = "DELETE FROM medecin_service WHERE  date_serv='" + dateTimePicker1.Text + "' and cin_med = '"+comboBox1.SelectedItem+"';";
            MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
            MySqlDataReader my_reader;
            try
            {
                SQLc.Open();
                connection_database.Open();
                my_reader = cmd_databes.ExecuteReader();
                MessageBox.Show("Suppression Avec Succès", "Manipulation Service de Garde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (my_reader.Read())
                {

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            clear_DGV();
            charger_data();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DT = dateTimePicker2.Value;
            clear_DGV();
            charger_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
