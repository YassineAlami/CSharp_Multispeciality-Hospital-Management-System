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
    public partial class Form17 : Form
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

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Form17()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = button7.Height;
            panel3.Top = button7.Top;
            panel3.Left = button7.Left;
            button7.BackColor = Color.FromArgb(46, 51, 73);

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel7.Width = button2.Width;
            //panel7.Top = button2.Top;
            panel7.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);

            charger_data_med();
            charger_data();
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
                    label2.Text = "CIN: " + SQLrd.GetString(0);
                    label3.Text = SQLrd.GetString(1) + " " + SQLrd.GetString(2);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    currentButton = (Button)btnSender;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(childForm);
            this.panel5.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //label1.Text = childForm.Text;
        }

        private void charger_data_med()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                SQLcmd.Connection = SQLc;
                //SQLcmd.CommandText = "SELECT DISTINCT concat(medecin.nom_med ,' ', medecin.pnom_med) as Medecin, patient_medecin.cin_med as 'CIN Medecin', medecin.genre_med as Genre, medecin.email_med as Email, medecin.tel_med as Tel, specialite.lib_spe as 'Specialite' FROM medecin INNER JOIN patient_medecin INNER JOIN specialite ON medecin.cin_med = patient_medecin.cin_med AND specialite.id_spe = medecin.id_spe WHERE patient_medecin.cin_pt = '" + Forms.Form3.user_app+"'";// + Form3.user_app + "'";
                SQLcmd.CommandText = "select medecin.cin_med as CIN, medecin.nom_med as Nom, medecin.pnom_med as Prenom, medecin.genre_med as Genre, medecin.email_med as Email, medecin.tel_med as Tel, Specialite.lib_spe as Specialite from medecin inner join patient_medecin inner join specialite on patient_medecin.cin_med = medecin.cin_med and specialite.id_spe =medecin.id_spe where patient_medecin.cin_pt ='" + S_G_H.Form3.user_app+"'";
                SQLrd = SQLcmd.ExecuteReader();
                SQLdt.Load(SQLrd);
                SQLrd.Close();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView2.DataSource = SQLdt;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form10 f1 = new Form10();
            f1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Patients.Form3(), sender);

            panel7.Width = button10.Width;
            panel7.Left = button10.Left;
            button10.BackColor = Color.FromArgb(46, 51, 73);
            button3.BackColor = button9.BackColor = button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //7abada law ngad hadi fchi fom patients
            this.Visible = false;
            Form17 f1 = new Form17();
            f1.Visible = true;
            button2.BackColor = Color.FromArgb(46, 51, 73);
            button3.BackColor = button9.BackColor = button10.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Patients.Form1(), sender);

            panel7.Width = button3.Width;
            panel7.Left = button3.Left;
            button3.BackColor = Color.FromArgb(46, 51, 73);
            button2.BackColor = button9.BackColor = button10.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Patients.Form2(), sender);

            panel7.Width = button9.Width;
            panel7.Left = button9.Left;
            button9.BackColor = Color.FromArgb(46, 51, 73);
            button3.BackColor = button2.BackColor = button10.BackColor = Color.FromArgb(24, 30, 54);
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
