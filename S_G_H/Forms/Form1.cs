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
        string q1 = "SELECT patient.cin_pt "/*as 'ID Patient'*/+ ", concat(Patient.nom_pt, ' ', Patient.pnom_pt) as Patinet, patient.genre_pt as Genre, patient.date_n_pt as 'Date Naissance', Patient.etat_pt as Etat from patient inner join Medecin on patient.cin_med = medecin.cin_med where medecin.cin_med='AE123456'";
        string q2 = "SELECT cin_pt , nom_pt, pnom_pt from patient";
        
        public Form1()
        {
            InitializeComponent();
            charger_data();
            textBox1.ReadOnly = true;
            
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            //string date_l = DateTime.Today.ToString("yyyy-MM-dd");
           
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "SELECT patient.cin_pt , Patient.nom_pt , Patient.pnom_pt as Prenom, patient.genre_pt as Genre, patient.date_n_pt as 'Date Naissance', Patient.etat_pt as Etat from patient" ;
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
            label4.ForeColor = ThemeColor.SecondaryColor;
            radioButton2.ForeColor= radioButton1.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            charger_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                textBox1.ReadOnly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (radioButton1.Checked == true) { search = "where Patient.cin_pt='"+textBox1.Text+"'"; }
            //else if (radioButton2.Checked == true) { search = "where Patient.nom_pt='"+ textBox1.Text + "'"; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
//            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
        if(radioButton1.Checked)
            {
                try
                {
                    DataView dv = SQLdt.DefaultView;
                    dv.RowFilter = string.Format("cin_pt LIKE '%{0}%'", textBox1.Text);
                    dataGridView2.DataSource = dv.ToTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (radioButton2.Checked)
            {
                try
                {
                    DataView dv = SQLdt.DefaultView;
                    dv.RowFilter = string.Format("nom_pt LIKE '%{0}%'", textBox1.Text);
                    dataGridView2.DataSource = dv.ToTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                textBox1.ReadOnly = false;
            }
        }
    }
}
