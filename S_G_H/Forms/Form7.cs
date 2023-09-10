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
    public partial class Form7 : Form
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


        public Form7()
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
                SQLcmd.CommandText = "SELECT medecin_service.date_serv as date, medecin_service.cin_med as cin, medecin.nom_med as Nom, medecin.pnom_med as Prenom, medecin.genre_med as Genre, specialite.lib_spe as specialite from medecin_service inner join medecin inner join specialite on medecin.cin_med = medecin_service.cin_med and specialite.id_spe = medecin.id_spe where date_serv = DATE_FORMAT(now(), '%Y-%m-%d')";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            dataGridView2.DataSource = SQLdt;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
