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

namespace S_G_H
{
    public partial class Form16 : Form
    {
        MySqlConnection SQLc = new MySqlConnection();
        MySqlCommand SQLcmd = new MySqlCommand();
        DataTable SQLdt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter SQLda = new MySqlDataAdapter();
        MySqlDataReader SQLrd;

        DataTable dt_table;
        DataSet ds = new DataSet();
        String server = "localhost";
        String user = "root";
        String psw = "";
        String database = "bd_Hopital_3";

        public Form16()
        {
            InitializeComponent();
            //charger_data();
            charger_data();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }


        private void charger_data_X()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            SQLc.Open();
            SQLcmd.Connection = SQLc;
           /* SELECT DISTINCT Patient.cin_pt as CIN, concat(Patient.nom_pt, ' ', Patient.pnom_pt) as patient, concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin ,patient_medecin.cin_med as 'CIN Medecin', type_traitement.lbl_type_trai as Traitement, concat(infirmiere.nom_inf, ' ', infirmiere.pnom_inf) FROM Patient inner join patient_medecin INNER JOIN medecin INNER JOIN patient_traitement INNER JOIN type_traitement INNER JOIN infirmiere INNER JOIN patient_infirmier on Patient.cin_pt = patient_medecin.cin_pt and medecin.cin_med = patient_medecin.cin_med and patient_traitement.cin_pt = patient.cin_pt AND patient_traitement.lbl_type_trai = type_traitement.lbl_type_trai and patient_infirmier.cin_pt = patient.cin_pt and infirmiere.cin_inf = patient_infirmier.cin_inf WHERE patient.cin_pt = 'B1234568'

                mosiba
                SELECT DISTINCT Patient.cin_pt as CIN, concat(Patient.nom_pt, ' ', Patient.pnom_pt) as patient, concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin , patient_medecin.cin_med as 'CIN Medecin', type_traitement.lbl_type_trai as Traitement
FROM Patient inner join patient_medecin INNER JOIN medecin INNER JOIN patient_traitement INNER JOIN type_traitement INNER JOIN patient_medicament INNER JOIN patient_infirmier
on Patient.cin_pt = patient_traitement.cin_pt and Patient.cin_pt = patient_medecin.cin_pt and Patient.cin_pt = patient_medicament.cin_pt and Patient.cin_pt = patient_infirmier.cin_inf AND

patient_traitement.cin_pt = patient_medecin.cin_pt and patient_traitement.cin_pt = patient_medicament.cin_pt and patient_traitement.cin_pt = patient_infirmier.cin_pt

WHERE patient.cin_pt = 'B1234568'

                medecin.cin_med = patient_medecin.cin_med AND type_traitement.lbl_type_trai = patient_traitement.lbl_type_trai

            medecin traitement
            SELECT DISTINCT Patient.cin_pt as CIN, concat(Patient.nom_pt, ' ', Patient.pnom_pt) as patient, concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin ,patient_medecin.cin_med as 'CIN Medecin', type_traitement.lbl_type_trai as Traitement FROM Patient inner join patient_medecin INNER JOIN medecin INNER JOIN patient_traitement INNER JOIN type_traitement on Patient.cin_pt = patient_medecin.cin_pt and medecin.cin_med = patient_medecin.cin_med and patient_traitement.cin_pt = patient.cin_pt AND patient_traitement.lbl_type_trai = type_traitement.lbl_type_trai WHERE patient.cin_pt = 'B1234568'
            medecin
            SELECT DISTINCT Patient.cin_pt as CIN, concat(Patient.nom_pt, ' ', Patient.pnom_pt) as patient, concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin ,patient_medecin.cin_med as 'CIN Medecin' FROM Patient inner join patient_medecin INNER JOIN patient_medicament INNER JOIN medecin on Patient.cin_pt = patient_medecin.cin_pt and medecin.cin_med = patient_medecin.cin_med WHERE patient.cin_pt = 'B1234568'
            */SQLcmd.CommandText = "SELECT DISTINCT Patient.cin_pt as CIN, concat(Patient.nom_pt,' ', Patient.pnom_pt) as patient, concat (medecin.nom_med,' ', medecin.pnom_med) as Medecin ,patient_medecin.cin_med as 'CIN Medecin', patient_infirmier.cin_inf as Infirmier, patient_traitement.lbl_type_trai as Traitement, patient_medicament.id_medi as Medicament FROM Patient inner join patient_medecin INNER JOIN patient_infirmier INNER JOIN patient_traitement inner join patient_medicament INNER JOIN medecin on Patient.cin_pt = patient_medecin.cin_pt and patient_infirmier.cin_pt = patient.cin_pt and patient_traitement.cin_pt = patient.cin_pt and patient_medicament.cin_pt = patient.cin_pt and medecin.cin_med = patient_medecin.cin_med WHERE patient.cin_pt = 'B1234568'";
            SQLrd = SQLcmd.ExecuteReader();
            SQLdt.Load(SQLrd);
            SQLrd.Close();
            SQLc.Close();
            dataGridView1.DataSource = SQLdt;
        }

        private void charger_data()
        {
            try
            {
                SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "SELECT DISTINCT concat(infirmiere.nom_inf ,' ', infirmiere.pnom_inf) as infirmiere , patient_infirmier.cin_inf as 'CIN Infirmier', infirmiere.genre_inf as Genre, infirmiere.email_inf as Email, infirmiere.tel_inf as Tel FROM patient INNER JOIN infirmiere INNER JOIN patient_infirmier ON patient.cin_pt = patient_infirmier.cin_pt AND infirmiere.cin_inf = patient_infirmier.cin_inf WHERE patient.cin_pt = 'B1234568'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
                dataGridView2.DataSource = SQLdt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form6 f1 = new Form6();
            f1.Visible = true;
        }
    }
}
