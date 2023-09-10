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

namespace S_G_H
{
    public partial class Form13 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottemRect,
               int nWidthEllipse,
               int nHeightEllipse
           );

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

        public Form13()
        {
            InitializeComponent();
            charger_data_1();
            charger_data();
            fill_Cbox_med();
            fill_Cbox_trai();

            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(1)  ;
            dateTimePicker1.Value = DateTime.Today;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = button5.Height;
            panel3.Top = button5.Top;
            panel3.Left = button5.Left;
            button5.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void fill_Cbox_med()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM patient_medecin where patient_medecin.cin_pt = '"+S_G_H.Form3.user_app+"'";
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
                    comboBox2.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            //delete not confirmed RDVs < today
            string query = "DELETE FROM rendez_vous WHERE Confirme = 'N' and date_rdv <= now();";
            MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
            MySqlDataReader my_reader;
            try
            {
                SQLc.Open();
                connection_database.Open();
                my_reader = cmd_databes.ExecuteReader();
                while (my_reader.Read())
                {

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            string date_l = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "SELECT DISTINCT medecin.cin_med as 'ID Medecin', concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin, specialite.lib_spe as Specialite, rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure from rendez_vous INNER JOIN medecin INNER join specialite on medecin.cin_med = rendez_vous.cin_med AND medecin.id_spe = specialite.id_spe where rendez_vous.confirme = 'N' and rendez_vous.cin_pt = '"+S_G_H.Form3.user_app+"';";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void charger_data_1()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT Patient.cin_pt, Patient.nom_pt, Patient.pnom_pt, rendez_vous.date_rdv, rendez_vous.heure_rdv FROM Patient inner join rendez_vous on Patient.cin_pt = rendez_vous.cin_pt WHERE rendez_vous.cin_pt= '" + Form3.user_app + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label2.Text = "CIN: " + SQLrd.GetString(0);
                    label3.Text = SQLrd.GetString(1) + " " + SQLrd.GetString(2);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("voulez-vous vraiment quitter l'application?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);   }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("Voulez-Vous Vraiment Retourner à La Page d'Accueil?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    this.Visible = false;
                    Form2 f1 = new Form2();
                    f1.Visible = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form10 f1 = new Form10();
            f1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            button4.BackColor = Color.FromArgb(46, 51, 73);

            this.Visible = false;
            Form12 f1 = new Form12();
            f1.Visible = true;
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form17 f1 = new Form17();
            f1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO rendez_vous (cin_pt, cin_med, date_rdv, heure_rdv, confirme, lbl_type_trai) VaLUES ('" + S_G_H.Form3.user_app + "','" +comboBox1.SelectedItem + "',  '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', 'N', '"+ comboBox2.SelectedItem+"');";
                MessageBox.Show("Rendez-Vous Ajouté Avec Succès", "Gestion Des Rendez-Vous", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_med, pnom_med FROM medecin WHERE cin_med= '" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label8.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }
    }
}
