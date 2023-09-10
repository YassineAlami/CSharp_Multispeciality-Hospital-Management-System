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
    public partial class Form19 : Form
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

        public Form19()
        {
            InitializeComponent();
            fill_Cbox_Spe();
            charger_data_Stats();
        }

        private void fill_Cbox_Spe()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Specialite";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_spe");
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void charger_data_Stats()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            //total specialite
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(id_spe) FROM specialite";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label72.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //patients total
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(cin_pt) FROM Patient";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label24.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //patients femmes
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(cin_pt) FROM Patient where genre_pt = 'F'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label47.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //patients etat stable
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(cin_pt) FROM Patient where etat_pt = 'stable'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label49.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //patients etat unstable
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(cin_pt) FROM Patient where etat_pt = 'Hospitalisation'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label50.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //patients enfants
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_pt) FROM Patient where year(CURRENT_DATE - INTERVAL year(date_n_pt) Year) < 19";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label48.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Medecins total
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_med) FROM medecin";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label51.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Medecins Femmes
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_med) FROM medecin where genre_med = 'F'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label52.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Medecins de garde
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_med) FROM medecin_service where date_serv = date(now())";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label53.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            //total infirmier
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_inf) FROM infirmiere";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label55.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //infirmier Femmes
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_inf) FROM infirmiere where genre_inf = 'F'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label56.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            //Chambre total
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(num_ch) FROM chambre";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label62.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Chambre occupes
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(num_ch) FROM chambre where si_pris = 'Y'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label63.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Chambre Libre
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(num_ch) FROM chambre where si_pris = 'N'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label64.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //total lits
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(id_lit) FROM lit";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label59.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //lits occupes
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(id_lit) FROM lit where si_pris= 'Y'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label60.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //lits Libres
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(id_lit) FROM lit where si_pris= 'N'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label61.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //total admin
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_admin) FROM admin_app";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label67.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //total admin
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(cin_admin) FROM admin_app where genre_admin = 'F'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label68.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            //Rendez-Vous total
            SQLc.Open();
            sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y'";
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLrd = SQLcmd.ExecuteReader();
            if (SQLrd.Read())
            {
                label77.Text = SQLrd.GetString(0);
            }
            SQLc.Close();
            //rdv month
            SQLc.Open();
            sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 MONTH)";
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLrd = SQLcmd.ExecuteReader();
            if (SQLrd.Read())
            {
                label19.Text = SQLrd.GetString(0);
            }
            SQLc.Close();
            //rdv week
            SQLc.Open();
            sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 week)";
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLrd = SQLcmd.ExecuteReader();
            if (SQLrd.Read())
            {
                label20.Text = SQLrd.GetString(0);
            }
            SQLc.Close();
            //rdv day
            SQLc.Open();
            sqlQuery = "SELECT COUNT(rendez_vous.id_rdv) FROM `rendez_vous` WHERE rendez_vous.confirme = 'Y' and rendez_vous.date_rdv = DATE_FORMAT(now(), '%Y-%m-%d')";
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLrd = SQLcmd.ExecuteReader();
            if (SQLrd.Read())
            {
                label25.Text = SQLrd.GetString(0);
            }
            SQLc.Close();
            //rdv non confirmes
            SQLc.Open();
            sqlQuery = "SELECT COUNT(rendez_vous.id_rdv) FROM `rendez_vous` WHERE rendez_vous.confirme = 'N'";
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLrd = SQLcmd.ExecuteReader();
            if (SQLrd.Read())
            {
                label33.Text = SQLrd.GetString(0);
            }
            SQLc.Close();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lib_spe FROM Specialite WHERE id_spe= '" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label76.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT count(cin_med) FROM medecin WHERE id_spe='" + comboBox1.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label75.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }
    }
}
