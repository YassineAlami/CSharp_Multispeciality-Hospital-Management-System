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
    public partial class Form12 : Form
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

        public Form12()
        {
            InitializeComponent();
            charger_data();
            charger_data_1();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            panel3.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            string date_l = DateTime.Today.ToString("yyyy-MM-dd");
            label2.Text = date_l;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                
                SQLcmd.CommandText = "select medecin.cin_med as 'ID Medecin', concat(medecin.nom_med, ' ', medecin.pnom_med) as Medecin, specialite.lib_spe as Specialite, medecin_service.date_serv as Date from medecin_service INNER JOIN medecin INNER join specialite on medecin.cin_med = medecin_service.cin_med AND medecin.id_spe = specialite.id_spe where medecin_service.date_serv='" + date_l + "';";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView2.DataSource = SQLdt;
        }

        private void charger_data_1()
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
                    label2.Text = "CIN: " + SQLrd.GetString(0);
                    label3.Text = SQLrd.GetString(1) + " " + SQLrd.GetString(2);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form10 f1 = new Form10();
            f1.Visible = true;
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

        private void button6_Click(object sender, EventArgs e)
        {
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
            }   catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form13 f1 = new Form13();
            f1.Visible = true;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form17 f1 = new Form17();
            f1.Visible = true;
        }
    }
}
