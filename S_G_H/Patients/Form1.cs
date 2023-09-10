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

namespace S_G_H.Patients
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
            charger_data_inf();
        }

        private void charger_data_inf()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "SELECT DISTINCT concat(infirmiere.nom_inf ,' ', infirmiere.pnom_inf) as infirmiere , patient_infirmier.cin_inf as 'CIN Infirmier', infirmiere.genre_inf as Genre, infirmiere.email_inf as Email, infirmiere.tel_inf as Tel FROM patient INNER JOIN infirmiere INNER JOIN patient_infirmier ON patient.cin_pt = patient_infirmier.cin_pt AND infirmiere.cin_inf = patient_infirmier.cin_inf WHERE patient.cin_pt = '"+S_G_H.Form3.user_app+"'";
                //SQLcmd.CommandText = "SELECT DISTINCT concat(infirmiere.nom_inf ,' ', infirmiere.pnom_inf) as infirmiere , patient_infirmier.cin_inf as 'CIN Infirmier', infirmiere.genre_inf as Genre, infirmiere.email_inf as Email, infirmiere.tel_inf as Tel FROM patient INNER JOIN infirmiere INNER JOIN patient_infirmier ON patient.cin_pt = patient_infirmier.cin_pt AND infirmiere.cin_inf = patient_infirmier.cin_inf WHERE patient.cin_pt = '" + S_G_H.Form3.user_app + "'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView2.DataSource = SQLdt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
