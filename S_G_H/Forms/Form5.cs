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
    public partial class Form5 : Form
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

        public Form5()
        {
            InitializeComponent();
            charger_data();
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

            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                //SQLcmd.CommandText = "SELECT patient.cin_pt as CIN , concat(Patient.nom_pt,'  ', Patient.pnom_pt ) as Patient , patient.genre_pt as Genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age',  rendez_vous.date_rdv as Date, heure_rdv as Heure from rendez_vous inner join patient on rendez_vous.cin_pt = Patient.cin_pt where rendez_vous.cin_med= '" + S_G_H.Form3.user_app + "'";
                SQLcmd.CommandText = "SELECT rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.cin_med ='" + S_G_H.Form3.user_app + "' ORDER by rendez_vous.date_rdv and rendez_vous.heure_rdv ASC";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void charger_data_mois()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            clear_DGV();
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "select rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 MONTH) AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app+ "' ORDER by rendez_vous.date_rdv ASC";
                //SQLcmd.CommandText = "SELECT rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.cin_med = '"+S_G_H.Form3.user_app+"' and rendez_vous.date_rdv BETWEEN DATE_FORMAT(rendez_vous.date_rdv, '%Y-%m-%d') AND DATE_ADD(DATE_FORMAT (now(), '%Y-%m-%d'), INTERVAL 30 DAY)"; 
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void charger_data_sem()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            clear_DGV();
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                //SQLcmd.CommandText = "SELECT rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.cin_med = '"+S_G_H.Form3.user_app+"' and rendez_vous.date_rdv BETWEEN DATE_FORMAT(rendez_vous.date_rdv, '%Y-%m-%d') AND DATE_ADD(DATE_FORMAT (now(), '%Y-%m-%d'), INTERVAL 7 DAY)";
                SQLcmd.CommandText = "select rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat from rendez_vous INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 week) AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app + "' ORDER by rendez_vous.date_rdv ASC"; 
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void charger_data_jour()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            clear_DGV();
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "SELECT rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, YEAR(DATE_SUB(now(), INTERVAL YEAR(patient.date_n_pt) YEAR )) as 'Age', patient.etat_pt as Etat FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.confirme = 'Y' AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app+ "' and rendez_vous.date_rdv = DATE_FORMAT(now(), '%Y-%m-%d') ORDER by rendez_vous.heure_rdv ASC";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
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
            radioButton1.ForeColor = ThemeColor.PrimaryColor;
            radioButton2.ForeColor = radioButton3.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //while (dataGridView2.Rows.Count > 0)
            //{
            //    dataGridView2.Rows.RemoveAt(0);
            //}

            charger_data_mois();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //while (dataGridView2.Rows.Count > 0)
            //{
            //    dataGridView2.Rows.RemoveAt(0);
            //}
            
            charger_data_jour();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //while (dataGridView2.Rows.Count > 0)
            //{
            //    dataGridView2.Rows.RemoveAt(0);
            //}
            
            charger_data_sem();
        }
    }
}
