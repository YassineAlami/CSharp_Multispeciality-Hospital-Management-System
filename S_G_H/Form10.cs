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
    public partial class Form10 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottemRect,
                int nWidthEllipse,
                int nHeightEllipse
            );


        //static int num_dossier = 9;
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
        public Form10()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            panel3.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

            charger_data();
            charger_data_2();
        }
        /*
        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                SQLcmd.CommandText = "select cin_pt as CIN, nom_pt as Nom, pnom_pt as Prenom, genre_pt as Genre, date_n_pt as 'Date Naissance', email_pt as Email from patient where cin_pt= 'B1234568'";
                //"select maladie_dossier.num_dossier as Num_Dossier, id_vcc as Vaccin, id_mal as Maladie from vaccin_dossier, maladie_dossier where maladie_dossier.num_dossier =vaccin_dossier.num_dossier and vaccin_dossier.num_dossier = 1";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }catch ( Exception ex ) { MessageBox.Show(ex.Message); }
            
            dataGridView1.DataSource = SQLdt;
        }
    */
        private void charger_data_2()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                //SQLcmd.CommandText = "select cin_med as Medecin, date_rdv as Date from rendez_vous where cin_pt='"+ Form3.user_app + "';";
                //SQLcmd.CommandText = "select rendez_vous.cin_med as 'ID Medecin', concat(medecin.nom_med,' ',medecin.pnom_med)  as Medecin, rendez_vous.date_rdv as Date from rendez_vous INNER JOIN medecin on medecin.cin_med = rendez_vous.cin_med where cin_pt='" + Form3.user_app + "';";
                //"select maladie_dossier.num_dossier as Num_Dossier, id_vcc as Vaccin, id_mal as Maladie from vaccin_dossier, maladie_dossier where maladie_dossier.num_dossier =vaccin_dossier.num_dossier and vaccin_dossier.num_dossier = 1";
                SQLcmd.CommandText = "SELECT medecin.cin_med as CIN,medecin.nom_med as Nom, medecin.pnom_med as Prenom, medecin.genre_med as Genre, medecin.tel_med as Tel, medecin.email_med as Email, rendez_vous.date_rdv as 'Date', rendez_vous.heure_rdv as 'Heure' FROM `rendez_vous` INNER JOIN medecin ON medecin.cin_med= rendez_vous.cin_med WHERE rendez_vous.confirme='Y' AND rendez_vous.cin_pt = '" + S_G_H.Form3.user_app+"'";
                //SQLcmd.CommandText = "SELECT Patient.cin_pt as CIN, Patient.nom_pt as NOM, Patient.pnom_pt as Prenom, rendez_vous.date_rdv as Date, rendez_vous.heure_rdv as Heure, concat(Medecin.nom_med,'  ',Medecin.pnom_med) as Medecin, rendez_vous.lbl_type_trai as Traitement FROM Patient inner join rendez_vous inner join medecin on Patient.cin_pt = rendez_vous.cin_pt   WHERE rendez_vous.confirme = 'Y' AND rendez_vous.cin_pt= '" + Form3.user_app + "'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
                
            }catch (Exception ex ) { MessageBox.Show(ex.Message); }

            dataGridView2.DataSource = SQLdt;
            
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT cin_pt, nom_pt, pnom_pt FROM Patient WHERE cin_pt= '" + Form3.user_app + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label2.Text = "CIN: "+SQLrd.GetString(0);
                    label3.Text = SQLrd.GetString(1)+" "+ SQLrd.GetString(2);
                    //MessageBox.Show("cin "+SQLrd.GetString(1) + " nom" + SQLrd.GetString(2) );
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            //charger_data_vaccin_maladie();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            panel3.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            button4.BackColor = Color.FromArgb(46, 51, 73);

            this.Visible = false;
            Form12 f1 = new Form12();
            f1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Height = button5.Height;
            panel3.Top = button5.Top;
            button5.BackColor = Color.FromArgb(46, 51, 73);

            this.Visible = false;
            Form13 f1 = new Form13();
            f1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            button4.BackColor = Color.FromArgb(46, 51, 73);

            this.Visible = false;
            Form17 f1 = new Form17();
            f1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Height = button6.Height;
            panel3.Top = button6.Top;
            button6.BackColor = Color.FromArgb(46, 51, 73);

            DialogResult q;
            try
            {
                q = MessageBox.Show("Voulez-Vous Vraiment Retourner à La Page d'Accueil?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    this.Visible = false;
                    Form2 f1 = new Form2();
                    f1.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button5_Leave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button7_Leave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button6_Leave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("voulez-vous vraiment quitter l'application?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
