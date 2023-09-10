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
    public partial class Form3 : Form
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
        string q1 = "SELECT patient.cin_pt "/*as 'ID Patient'*/+ ", concat(Patient.nom_pt, ' ', Patient.pnom_pt) as Patinet, patient.genre_pt as Genre, patient.date_n_pt as 'Date Naissance', Patient.etat_pt as Etat from patient inner join Medecin on patient.cin_med = medecin.cin_med where medecin.cin_med='AE123456'";
        string q2 = "SELECT cin_pt , nom_pt, pnom_pt from patient";
        internal static string user_app;

        public Form3()
        {
            InitializeComponent();
            charger_data();
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            //string date_l = DateTime.Today.ToString("yyyy-MM-dd");

            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "SELECT patient.cin_pt, concat(Patient.nom_pt, ' ', Patient.pnom_pt) as Patinet, patient.genre_pt as Genre, patient.date_n_pt as 'Date Naissance', Adresse_pt AS Adresse, Email_pt as Email,etat_pt as Etat from patient inner join patient_medecin on patient.cin_pt = patient_medecin.cin_pt where patient_medecin.cin_med= '" + S_G_H.Form3.user_app + "'";
                //SQLcmd.CommandText = "SELECT rendez_vous.date_rdv as Date, patient.nom_pt as Nom, patient.pnom_pt as Prenom, patient.genre_pt as genre, patient.date_n_pt as 'Date Naissance', patient.etat_pt as Etat  FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt=rendez_vous.cin_pt WHERE rendez_vous.cin_med = '" + S_G_H.Form3.user_app + "'";
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
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //radioButton2.ForeColor = radioButton1.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
