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
            charger_data_1();
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
            label1.ForeColor = label17.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = label3.ForeColor = label4.ForeColor = ThemeColor.PrimaryColor;
            label14.ForeColor = label15.ForeColor = label16.ForeColor = label18.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = label7.ForeColor = label8.ForeColor = label9.ForeColor = Color.Black;
            label10.ForeColor = label11.ForeColor = label12.ForeColor = label13.ForeColor = Color.Black;
        }

        private void charger_data_1()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            TimeSpan Ts;
            var DateNaissance = DateTime.Now;
            DateNaissance = DateNaissance.AddYears(-10);
            //label5.Text = DateNaissance.ToString();
            //label5.Text  = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT COUNT(patient_medecin.cin_pt)FROM patient_medecin WHERE cin_med = '" + S_G_H.Form3.user_app + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label2.Text = SQLrd.GetString(0);
                }
                SQLc.Close();

                SQLc.Open();
                sqlQuery = "SELECT COUNT(patient_medecin.cin_pt)FROM patient_medecin INNER JOIN patient on patient.cin_pt=patient_medecin.cin_pt WHERE patient.genre_pt = 'F' and cin_med ='" + S_G_H.Form3.user_app + "';";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label3.Text = SQLrd.GetString(0);
                }
                SQLc.Close();
                
                SQLc.Open();

                sqlQuery = "select COUNT(patient_medecin.cin_pt) from patient_medecin INNER JOIN patient on patient.cin_pt = patient_medecin.cin_pt WHERE year (DATE_SUB(now(), INTERVAL year(patient.date_n_pt) year)) < 18 AND patient_medecin.cin_med = '" + S_G_H.Form3.user_app + "' ;"; 
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label4.Text = SQLrd.GetString(0);
                }
                SQLc.Close();
                
                //Rendez-Vous
                SQLc.Open();
                sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND cin_med ='" + S_G_H.Form3.user_app+"'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label18.Text = SQLrd.GetString(0);
                }
                SQLc.Close();
                
                //rdv month
                SQLc.Open();
                //sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE cin_med='"+ S_G_H.Form3.user_app + "' and month(date_rdv)='" + DateTime.Now.ToString("MM") + "'";
                sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 MONTH) AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label16.Text = SQLrd.GetString(0);
                }
                SQLc.Close();
                
                //rdv week
                SQLc.Open();
                sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN DATE_FORMAT(now(), '%Y-%m-%d') AND DATE_ADD(now(), INTERVAL 1 week) AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label15.Text = SQLrd.GetString(0);
                }
                SQLc.Close();
                
                //rdv day
                SQLc.Open();
                //sqlQuery = "select COUNT(rendez_vous.id_rdv) from rendez_vous WHERE rendez_vous.confirme = 'Y' AND rendez_vous.date_rdv BETWEEN now() AND DATE_ADD(now(), INTERVAL 1 day) AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app + "'";
                sqlQuery = "SELECT COUNT(rendez_vous.id_rdv) FROM `rendez_vous` INNER JOIN patient ON patient.cin_pt = rendez_vous.cin_pt WHERE rendez_vous.confirme = 'Y' AND rendez_vous.cin_med = '" + S_G_H.Form3.user_app+"' and rendez_vous.date_rdv = DATE_FORMAT(now(), '%Y-%m-%d')";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                if (SQLrd.Read())
                {
                    label14.Text = SQLrd.GetString(0);
                }
                SQLc.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
