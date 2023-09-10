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

        public Form3()
        {
            InitializeComponent();
            charger_data_medi();
        }

        private void charger_data_medi()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "SELECT DISTINCT medicament.id_medi AS 'ID Medicament', medicament.lbl_medi AS Medicament, medicament.prix_medi as Prix, medicament.genre_medi AS Genre FROM patient INNER JOIN medicament INNER JOIN patient_medicament ON patient.cin_pt = patient_medicament.cin_pt AND patient_medicament.id_medi = medicament.id_medi WHERE patient.cin_pt = '"+S_G_H.Form3.user_app+"'";
                //SQLcmd.CommandText = "SELECT DISTINCT medicament.id_medi AS 'ID Medicament', medicament.lbl_medi AS Medicament, medicament.prix_medi as Prix, medicament.genre_medi AS Genre FROM patient INNER JOIN medicament INNER JOIN patient_medicament ON patient.cin_pt = patient_medicament.cin_pt AND patient_medicament.id_medi = medicament.id_medi WHERE patient.cin_pt =  '" + S_G_H.Form3.user_app + "'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView2.DataSource = SQLdt;
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
