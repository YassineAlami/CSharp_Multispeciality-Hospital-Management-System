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
    public partial class Form2 : Form
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

        public Form2()
        {
            InitializeComponent();
            charger_data_trai();
        }

        private void charger_data_trai()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText  = "SELECT DISTINCT type_traitement.lbl_type_trai as Traitement, type_traitement.frai_trai as Frais FROM patient INNER JOIN type_traitement INNER JOIN patient_traitement ON patient.cin_pt = patient_traitement.cin_pt AND patient_traitement.lbl_type_trai = type_traitement.lbl_type_trai WHERE patient.cin_pt = '"+S_G_H.Form3.user_app+"'";
                //SQLcmd.CommandText = "SELECT DISTINCT type_traitement.lbl_type_trai as Traitement, type_traitement.frai_trai as Frais FROM patient INNER JOIN type_traitement INNER JOIN patient_traitement ON patient.cin_pt = patient_traitement.cin_pt AND patient_traitement.lbl_type_trai = type_traitement.lbl_type_trai WHERE patient.cin_pt ='" + S_G_H.Form3.user_app + "'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView2.DataSource = SQLdt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
