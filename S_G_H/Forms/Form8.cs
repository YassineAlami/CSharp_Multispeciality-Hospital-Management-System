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

namespace S_G_H.Forms
{
    public partial class Form8 : Form
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

        int num_dossier = 0, c, d, num_ch, lit_aff = -1;
        int id_lit_si_pris, num_ch_si_pris, lit_aj;
        List<string> PTS = new List<string>();

        public Form8()
        {
            InitializeComponent();
            fill_Cbox_id_Maladie();
            fill_Cbox_id_vaccin();
            fill_Cbox_num_chambre();
            //fill_Cbox_id_lit();
            //fill_Cbox_Lit();
            fill_Cbox_pat();
            fill_Cbox_pat_cmp();

            this.comboBox3.Items.Add("stable");
            this.comboBox3.Items.Add("hospitalisation");
            this.comboBox3.Items.Add("médication");
            this.comboBox3.Items.Add("hébergemen");
            this.comboBox3.Items.Add("alimentation");
            this.comboBox3.Items.Add("prises de sang");

            this.comboBox1.Items.Add("Nom");
            this.comboBox1.Items.Add("Prenom");
            this.comboBox1.Items.Add("Genre");
            this.comboBox1.Items.Add("Adresse");
            this.comboBox1.Items.Add("Etat");
            this.comboBox1.Items.Add("Email");
            this.comboBox1.Items.Add("Date Naissance");


            label16.Visible = label17.Visible = label10.Visible = label5.Visible = label20.Visible = dateTimePicker4.Visible = false;
            comboBox6.Visible = comboBox7.Visible = dateTimePicker1.Visible = dateTimePicker3.Visible = button8.Visible = false;
            radioButton3.Visible = radioButton4.Visible = comboBox1.Visible = label9.Visible = dateTimePicker5.Visible = false;
            label29.Visible = label30.Visible = label31.Visible = pictureBox1.Visible = textBox4.Visible = textBox9.Visible = textBox10.Visible = false;
            
            
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.metroTabPage1.Controls.OfType<Button>())
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control lbls in this.metroTabPage2.Controls.OfType<Label>())
            {
                if (lbls.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbls;
                    lbl.ForeColor  = ThemeColor.PrimaryColor;

                }
            }
            foreach (Control lbls in this.metroTabPage5.Controls.OfType<Label>())
            {
                if (lbls.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbls;
                    lbl.ForeColor = ThemeColor.PrimaryColor;

                }
            }
            button2.BackColor= button3.BackColor = button4.BackColor = button6.BackColor = ThemeColor.PrimaryColor;
            button2.ForeColor = button3.ForeColor = button4.ForeColor = button6.ForeColor = Color.White;
            button2.FlatAppearance.BorderColor = button3.FlatAppearance.BorderColor = button6.FlatAppearance.BorderColor = button4.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            foreach (Control lbls in this.metroTabPage1.Controls.OfType<Label>())
            {
                if (lbls.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbls;
                    lbl.ForeColor = ThemeColor.PrimaryColor;

                }
            }
            radioButton1.ForeColor = radioButton2.ForeColor = radioButton3.ForeColor = radioButton4.ForeColor = ThemeColor.PrimaryColor;
            label23.ForeColor = label25.ForeColor = label27.ForeColor = ThemeColor.PrimaryColor;
            radioButton5.ForeColor = radioButton6.ForeColor = radioButton7.ForeColor = radioButton8.ForeColor = ThemeColor.SecondaryColor;
            /*
            label3.ForeColor = label2.ForeColor = label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = label5.ForeColor = label8.ForeColor = label12.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = label8.ForeColor = label19.ForeColor = label14.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = label17.ForeColor = label16.ForeColor = label14.ForeColor = ThemeColor.PrimaryColor;
            radioButton1.ForeColor = radioButton1.ForeColor = ThemeColor.PrimaryColor;*/
        }

        private void fill_Cbox_pat()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM patient_medecin where cin_med = '"+S_G_H.Form3.user_app+"'";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();
                PTS.Clear();
                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_pt");
                    comboBox2.Items.Add(item_cb);
                    comboBox8.Items.Add(item_cb);
                    comboBox10.Items.Add(item_cb);
                    PTS.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_pat_cmp()
        {
            
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM patient ";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();



                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_pt");
                    if (PTS.Contains(item_cb)== false)
                    {
                        comboBox9.Items.Add(item_cb);
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            conn_bd.Close();

            //while (PTS)
            //{
            //    if()
            //    {

            //    }
            //}
        }

        private void fill_Cbox_id_Maladie()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT id_mal, lbl_mal FROM Maladie";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_mal");
                    //hnooooooo
                    //label1.Text = myreader.GetString("lbl_mal");
                    comboBox4.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_vaccin()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT id_vcc  FROM Vaccin";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_vcc");
                    //hnooooooo
                    //label1.Text = myreader.GetString("lbl_mal");
                    comboBox5.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_num_chambre()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT num_ch FROM Chambre where si_pris ='N'";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("num_ch");
                    comboBox6.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_Lit(ComboBox combx, string query_fill, string valueMember)
        {
            try
            {
                SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
                MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_bd = new MySqlCommand(query_fill, SQLc);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_bd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                combx.DataSource = table;
                combx.ValueMember = valueMember;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void Form8_Load(object sender, EventArgs e)
        {
            string query = "Select num_ch from chambre where si_pris='N'";
            fill_Cbox_Lit(comboBox6, query, "num_ch");
            comboBox6_SelectedIndexChanged(null, null);

            LoadTheme();
            label15.ForeColor = ThemeColor.PrimaryColor;

            comboBox4.DropDownHeight = comboBox4.ItemHeight * 5;
            comboBox5.DropDownHeight = comboBox5.ItemHeight * 5;
            comboBox3.DropDownHeight = comboBox3.ItemHeight * 5;
            comboBox6.DropDownHeight = comboBox6.ItemHeight * 5;
            comboBox9.DropDownHeight = comboBox9.ItemHeight * 5;

            label13.Visible = label18.Visible = textBox8.Visible = textBox6.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           /* else if (comboBox1.SelectedItem == "Genre")
            {
                label13.Text = "Date Naissance"; textBox6.Text = "Nouvelle Date Naissance";//label18.Text = " ";
                label13.Visible = radioButton3.Visible = radioButton4.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = textBox6.Visible = false;
            }*/
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_mal FROM maladie WHERE id_mal= '" + comboBox4.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label1.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_vcc FROM Vaccin WHERE id_vcc= '" + comboBox5.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label6.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "stable" || comboBox3.SelectedItem == "prises de sang")
            {
                label16.Visible = label17.Visible = label10.Visible = label5.Visible = label20.Visible = false;
                comboBox6.Visible = comboBox7.Visible = dateTimePicker1.Visible = dateTimePicker3.Visible = false;
            }
            else
            {
                label16.Visible = label17.Visible = label10.Visible = label5.Visible = label20.Visible = true;
                comboBox6.Visible = comboBox7.Visible = dateTimePicker1.Visible = dateTimePicker3.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            int val;
            Int32.TryParse(comboBox6.SelectedValue.ToString(), out val);
            string query = "Select id_lit from Lit where si_pris= 'N' and num_ch=" + val;
            fill_Cbox_Lit(comboBox7, query, "id_lit");

            DataRowView dv = (DataRowView)comboBox6.SelectedItem;
            int num_ch = int.Parse((string)dv.Row["num_ch"].ToString());
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT type_ch FROM chambre WHERE num_ch= " + num_ch;
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label20.Text = SQLrd.GetString(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                comboBox1.Visible = label9.Visible = true;
            }
            else
            {
                comboBox1.Visible = label19.Visible = false;
            }

            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_pt,pnom_pt FROM patient inner join patient_medecin on patient_medecin.cin_pt = patient.cin_pt WHERE patient_medecin.cin_med = '" + S_G_H.Form3.user_app + "' and patient.cin_pt= '" + comboBox2.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label21.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Nom")
            {
                label13.Text = "Nom"; textBox6.Text = "Nouveau Nom";//label18.Text = " ";
                label13.Visible = textBox6.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Prenom")
            {
                label13.Text = "Prenom"; textBox6.Text = "Nouveau Prenom";//label18.Text = " ";
                label13.Visible = textBox6.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Genre")
            {
                label13.Text = "Genre"; //label18.Text = " ";
                label13.Visible = radioButton3.Visible = radioButton4.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = textBox6.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Adresse")
            {
                label13.Text = "Adresse"; textBox6.Text = "Nouvelle Adresse";//label18.Text = " ";
                label13.Visible = textBox6.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Etat")
            {
                label13.Text = "Etat"; textBox6.Text = "Nouveau Etat";//label18.Text = " ";
                label13.Visible = textBox6.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Email")
            {
                label13.Text = "Email"; textBox6.Text = "Nouveau Email";//label18.Text = " ";
                label13.Visible = textBox6.Visible = true; //label18.Visible = textBox8.Visible  = true;
                dateTimePicker4.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Date Naissance")
            {
                label13.Text = "Date Naissance"; textBox6.Text = "Nouvelle Date Naissance";//label18.Text = " ";
                label13.Visible = dateTimePicker4.Visible = true; //label18.Visible = textBox8.Visible  = true;
                textBox6.Visible = radioButton3.Visible = radioButton4.Visible = false;
            }
        }

        private void comboBox8_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_pt,pnom_pt FROM patient inner join patient_medecin on patient_medecin.cin_pt = patient.cin_pt WHERE patient_medecin.cin_med = '" + S_G_H.Form3.user_app + "' and patient.cin_pt= '" + comboBox8.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label22.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox9_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_pt,pnom_pt FROM patient WHERE patient.cin_pt= '" + comboBox9.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label24.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox10_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT nom_pt,pnom_pt FROM patient inner join patient_medecin on patient_medecin.cin_pt = patient.cin_pt WHERE patient_medecin.cin_med = '" + S_G_H.Form3.user_app + "' and patient.cin_pt= '" + comboBox10.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label26.Text = SQLrd.GetString(0) + " " + SQLrd.GetString(1);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            label29.Text = "Num de Carte"; label29.Visible = false;
            label31.Visible = label30.Visible = false;
            dateTimePicker5.Visible = false; button8.Visible = true;
            textBox9.Visible = textBox10.Visible = pictureBox1.Visible = textBox4.Visible = false;
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            label29.Text = "Montant"; label29.Visible = true;
            textBox9.Visible = true;
            dateTimePicker5.Visible = button8.Visible = false;
            label30.Visible = label31.Visible = pictureBox1.Visible = textBox4.Visible = textBox4.Visible = textBox10.Visible = false;
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            label29.Text = "Num de Carte"; label29.Visible = true;
            textBox9.Visible = textBox10.Visible = pictureBox1.Visible = label31.Visible = label30.Visible = true;
            dateTimePicker5.Visible = true;
            textBox4.Visible = button8.Visible = false;
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            label29.Text = "RIB"; label29.Visible = true;
            textBox4.Visible = true;
            dateTimePicker5.Visible = button8.Visible = false;
            label30.Visible = label31.Visible = pictureBox1.Visible = textBox9.Visible = textBox10.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (num_dossier == 0)
            {
                try
                {
                    SQLc.Open();

                    sqlQuery = "INSERT INTO dossier_medical VALUES ();";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }

                try
                {
                    SQLc.Open();

                    sqlQuery = "SELECT max(num_dossier) FROM dossier_medical";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    if (SQLrd.Read())
                    {
                        num_dossier = int.Parse(SQLrd.GetString(0));
                    }
                    //MessageBox.Show("dossier medical num :" + num_dossier, "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }

            try
            {
                SQLc.Open();

                sqlQuery = "INSERT INTO maladie_dossier (num_dossier, id_mal) VALUES (" + num_dossier + ", " + int.Parse(comboBox4.SelectedItem.ToString()) + ");";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Maladie Ajoutee au Dossier", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (num_dossier == 0)
            {
                try
                {
                    SQLc.Open();

                    sqlQuery = "INSERT INTO dossier_medical VALUES ();";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }

                try
                {
                    SQLc.Open();

                    sqlQuery = "SELECT max(num_dossier) FROM dossier_medical";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    if (SQLrd.Read())
                    {
                        num_dossier = int.Parse(SQLrd.GetString(0));
                    }
                    //                    MessageBox.Show("dossier medical num :" + num_dossier, "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }

            try
            {
                SQLc.Open();

                sqlQuery = "INSERT INTO Vaccin_dossier (num_dossier, id_vcc) VALUES (" + num_dossier + ", " + int.Parse(comboBox5.SelectedItem.ToString()) + ");";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Vaccin Ajoutee au Dossier", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int pris = 1;
            string g;
            lit_aj = 0;

            if (radioButton1.Checked == true) { g = "M"; }
            else { g = "F"; }

            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            DataRowView dv = (DataRowView)comboBox7.SelectedItem;
            int id_lit = int.Parse((string)dv.Row["id_lit"].ToString());

            DataRowView dv1 = (DataRowView)comboBox6.SelectedItem;
            int num_ch = int.Parse((string)dv1.Row["num_ch"].ToString());

            try
            {
                SQLc.Open();
                if (comboBox3.SelectedItem == "stable" || comboBox3.SelectedItem == "prises de sang")
                {
                    sqlQuery = "INSERT INTO patient (cin_pt, num_dossier, nom_pt, pnom_pt, genre_pt, date_n_pt, adresse_pt, email_pt, etat_pt) VALUES ('" + textBox1.Text + "'," + num_dossier + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','" + textBox7.Text + "', '" + comboBox3.SelectedItem + "');";
                }
                else
                {
                    sqlQuery = "INSERT INTO patient (cin_pt, num_dossier, nom_pt, pnom_pt, genre_pt, date_n_pt, adresse_pt, email_pt, id_lit, etat_pt, date_entree, date_sortie) VALUES ('" + textBox1.Text + "'," + num_dossier + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','" + textBox7.Text + "'," + id_lit + ",'" + comboBox3.SelectedItem + "' , '" + dateTimePicker1.Text + "', '" + dateTimePicker3.Text + "');";
                    MessageBox.Show("'num lit: '" + id_lit);
                    lit_aj = 1;
                    //sqlQuery = "INSERT INTO patient (cin_pt, num_dossier, nom_pt, pnom_pt, genre_pt, date_n_pt, adresse_pt, email_pt) VALUES ('" + textBox1.Text + "'," + num_dossier + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','" + textBox7.Text + "');";
                }

                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                num_dossier++;
                MessageBox.Show("Patient Ajouté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }

            if (lit_aj == 1)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Lit set si_pris = 'Y' WHERE id_lit =" + id_lit;

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT si_pris FROM lit WHERE num_ch= " + num_ch;
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                while (SQLrd.Read())
                {
                    if (SQLrd.GetString(0).ToString() == "N")
                    {
                        pris = 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }

            if (pris == 1)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE chambre set si_pris = 'Y' WHERE num_ch =" + num_ch;

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }

            string query = "Select num_ch from chambre where si_pris='N'";
            fill_Cbox_Lit(comboBox6, query, "num_ch");
            comboBox6_SelectedIndexChanged(null, null);
            SQLc.Close();
            num_dossier = 0;
            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO patient_medecin (cin_pt, cin_med) VaLUES ('" + textBox1.Text + "','" + S_G_H.Form3.user_app + "');";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox7.Text = "";
            comboBox4.Text = comboBox3.Text = comboBox5.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            /*
                        try
                        {
                            SQLc.Open();
                            sqlQuery = "delete md FROM maladie_dossier md inner join dossier_medical dm INNER JOIN patient pt on md.num_dossier = dm.num_dossier and pt.num_dossier=md.num_dossier WHERE pt.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();
                            sqlQuery = "delete vd FROM vaccin_dossier vd inner join dossier_medical dm INNER JOIN patient pt on vd.num_dossier = dm.num_dossier and pt.num_dossier=vd.num_dossier WHERE pt.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();
                            sqlQuery = "delete rdv FROM rendez_vous rdv inner join patient pt on rdv.cin_pt = pt.cin_pt WHERE pt.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();
                            //delete dm FROM dossier_medical dm inner join Patient pt on dm.num_dossier = pt.num_dossier WHERE pt.num_dossier = 10
                            sqlQuery = "delete dm FROM dossier_medical dm INNER JOIN patient pt on pt.num_dossier=dm.num_dossier WHERE pt.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                       SQLc.Close(); */
            try
            {
                SQLc.Open();

                sqlQuery = "delete pm FROM patient_medecin pm INNER JOIN patient pt on pm.cin_pt=pt.cin_pt WHERE pt.cin_pt = '" + comboBox8.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
            MessageBox.Show("Patient Supprimé", "Manipulation des Pations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
                        try
                        {
                            SQLc.Open();

                            sqlQuery = "delete ptrai FROM patient_traitement ptrai INNER JOIN patient pt on ptrai.cin_pt=pt.cin_pt WHERE ptrai.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();

                            sqlQuery = "delete pmedi FROM patient_medicament pmedi INNER JOIN patient pt on pmedi.cin_pt=pt.cin_pt WHERE pmedi.cin_pt ='" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();

                            sqlQuery = "delete pinf FROM patient_infirmier pinf INNER JOIN patient pt on pinf.cin_pt=pt.cin_pt WHERE pinf.cin_pt = '" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();

                        try
                        {
                            SQLc.Open();

                            sqlQuery = "delete FROM Patient WHERE cin_pt= '" + comboBox8.SelectedItem + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        SQLc.Close();
              */
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (comboBox1.SelectedItem == "Nom")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set nom_pt = '" + textBox6.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
                MessageBox.Show("Patient Modifié", "Manipulation des Pations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.SelectedItem == "Prenom")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set pnom_pt = '" + textBox6.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
            else if (comboBox1.SelectedItem == "Adresse")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set adresse_pt= '" + textBox6.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
            else if (comboBox1.SelectedItem == "Etat")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set Etat_pt= '" + textBox6.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
            else if (comboBox1.SelectedItem == "Email")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set Email_pt= '" + textBox6.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
            else if (comboBox1.SelectedItem == "Date Naissance")
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set date_n_pt= '" + dateTimePicker4.Text + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
            else if (comboBox1.SelectedItem == "Genre")
            {
                try
                {
                    SQLc.Open();
                    string g = "M";
                    if (radioButton4.Checked == true) g = "F";
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Patient set genre_pt= '" + g + "' WHERE cin_pt ='" + comboBox2.SelectedItem + "'";

                    SQLcmd.ExecuteNonQuery();
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
                SQLc.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                SQLc.Open();

                sqlQuery = "insert into Patient_Medecin (cin_pt, cin_med) Values ('" + comboBox9.SelectedItem + "', '" + S_G_H.Form3.user_app + "')";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                MessageBox.Show("Patient Ajouté Avec Succès", "Manipuler Mes Patients", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
    

