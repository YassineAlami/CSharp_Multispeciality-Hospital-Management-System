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
    public partial class Form11 : Form
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

        int nbr_lit_ch_prise, nbr_lit_ch_total;

        public Form11()
        {
            InitializeComponent();
            radioButton1.Checked = radioButton6.Checked = radioButton9.Checked = radioButton12.Checked = radioButton15.Checked = true;
            radioButton18.Checked = radioButton21.Checked = radioButton24.Checked = radioButton27.Checked = true;
            fill_Cbox_spe();
            fill_Cbox_type_mal(); fill_Cbox_id_mal();
            fill_Cbox_id_type_vcc(); fill_Cbox_id_vcc();
            fill_Cbox_ch(); fill_Cbox_type_ch(); fill_Cbox_id_lit();
            fill_Cbox_id_medi(); fill_Cbox_lbl_trai();
        }

        private void fill_Cbox_id_lit()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Lit";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_lit");
                    comboBox11.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_ch()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Chambre";
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
                    comboBox8.Items.Add(item_cb);
                    comboBox10.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_spe()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Specialite";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_spe");
                    comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_type_vcc()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Type_vaccin";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_type_vcc");
                    comboBox6.Items.Add(item_cb);
                    comboBox7.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_vcc()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Vaccin";
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
                    comboBox5.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_lbl_trai()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM type_traitement";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("lbl_type_trai");
                    comboBox12.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_medi()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Medicament";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_medi");
                    comboBox13.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_mal()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Maladie";
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
                    comboBox3.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_type_ch()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Chambre";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("type_ch");
                    comboBox9.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_type_mal()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM type_maladie";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("id_type_mal");
                    comboBox2.Items.Add(item_cb);
                    comboBox4.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lib_spe FROM specialite WHERE id_spe= '" + comboBox1.SelectedItem + "'";
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

        private void Form11_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownHeight = comboBox1.ItemHeight * 5;
            comboBox2.DropDownHeight = comboBox2.ItemHeight * 5;
            comboBox3.DropDownHeight = comboBox3.ItemHeight * 5;
            comboBox4.DropDownHeight = comboBox4.ItemHeight * 5;
            comboBox6.DropDownHeight = comboBox6.ItemHeight * 5;
            comboBox5.DropDownHeight = comboBox5.ItemHeight * 5;
            comboBox7.DropDownHeight = comboBox7.ItemHeight * 5;
            comboBox8.DropDownHeight = comboBox8.ItemHeight * 5;
            comboBox9.DropDownHeight = comboBox9.ItemHeight * 5;
            comboBox10.DropDownHeight = comboBox10.ItemHeight * 5;
            comboBox11.DropDownHeight = comboBox11.ItemHeight * 5;
            comboBox12.DropDownHeight = comboBox13.ItemHeight * 5;
            comboBox13.DropDownHeight = comboBox13.ItemHeight * 5;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = label5.Visible = label6.Visible = false;
            textBox2.Visible = label7.Visible = true;
            button1.Text = "Ajouter";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = label5.Visible = label6.Visible = true;
            textBox2.Visible = label7.Visible = true;
            button1.Text = "Modifier";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = label5.Visible = label6.Visible = true;
            textBox2.Visible = label7.Visible = false;
            button1.Text = "Supprimer";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton1.Checked==true)//ajouter
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO Specialite (lib_spe) VaLUES        ('" + textBox2.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Specialite Ajoute","Manipulation Specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show (ex.Message); }
                finally { SQLc.Close(); }
            }
            else if(radioButton2.Checked == true)//Modifier
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Specialite set lib_spe = '"+textBox2.Text+"' WHERE id_spe = '"+comboBox1.SelectedItem+"'";
                    MessageBox.Show("Specialite Modifie", "Manipulation Specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else//supprimer
            {
                string query = "DELETE FROM Specialite WHERE id_spe ='" + comboBox1.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Specialite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_type_mal FROM type_maladie WHERE id_type_mal= '" + comboBox2.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label2.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = label3.Visible = label2.Visible = false;
            textBox1.Visible = label1.Visible = true;
            button2.Text = "Ajouter";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = label2.Visible = label3.Visible = true;
            textBox1.Visible = label1.Visible = true;
            button2.Text = "Modifier";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = label2.Visible = label3.Visible = true;
            textBox1.Visible = label1.Visible = false;
            button2.Text = "Supprimer";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton6.Checked == true)//ajouter
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO type_maladie (lbl_type_mal) VaLUES        ('" + textBox1.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Type Maladie Ajoute", "Manipulation Type Maladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }

            }
            else if (radioButton5.Checked==true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Type_maladie set lbl_type_mal = '" + textBox1.Text + "' WHERE id_type_mal = '" + comboBox2.SelectedItem + "'";
                    MessageBox.Show("Type Maladie Modifie", "Manipulation Type Mladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else //if (radioButton4.Checked == true)
            {
                string query = "DELETE FROM Type_Maladie WHERE id_type_mal ='" + comboBox2.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Type Maladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = label9.Visible = label8.Visible = false;
            comboBox4.Visible = label10.Visible = label11.Visible = true;
            textBox3.Visible = label4.Visible = true;
            button3.Text = "Ajouter";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = label9.Visible = label8.Visible = true;
            comboBox4.Visible = label10.Visible = label11.Visible = true;
            textBox3.Visible = label4.Visible = true;
            button3.Text = "Modifier";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = label9.Visible = label8.Visible = true;
            comboBox4.Visible = label10.Visible = label11.Visible = false;
            textBox3.Visible = label4.Visible = false;
            button3.Text = "Supprimer";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton9.Checked==true)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO Maladie (id_type_mal, lbl_mal) VaLUES        ('"+comboBox4.SelectedItem+"','" + textBox3.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Maladie Ajoute", "Manipulation Maladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if(radioButton8.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Maladie set id_type_mal = '" + comboBox4.SelectedItem + "',lbl_mal = '"+textBox3.Text+"'  WHERE id_mal = '" + comboBox3.SelectedItem + "'";
                    MessageBox.Show("Maladie Modifie", "Manipulation Maladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM Maladie WHERE id_mal ='" + comboBox3.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Maladie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_mal FROM maladie WHERE id_mal = '" + comboBox3.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label8.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_type_mal FROM type_maladie WHERE id_type_mal= '" + comboBox4.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label10.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox6.Visible = label15.Visible = label16.Visible = true;
            textBox4.Visible = label14.Visible = false;
            button4.Text = "Supprimer";
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox6.Visible = label15.Visible = label16.Visible = true;
            textBox4.Visible = label14.Visible = true;
            button4.Text = "Modofier";
        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox6.Visible = label15.Visible = label16.Visible = false;
            textBox4.Visible = label14.Visible = true;
            button4.Text = "Ajouter";
        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_type_vcc FROM type_Vaccin WHERE id_type_vcc= '" + comboBox6.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label15.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton12.Checked==true)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO type_Vaccin (lbl_type_vcc) VaLUES        ('" + textBox4.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Type Vaccin Ajoute", "Manipulation Type Vaccin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if (radioButton11.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Type_Vaccin set lbl_type_vcc = '" + textBox4.Text + "' WHERE id_type_vcc = '" + comboBox6.SelectedItem + "'";
                    MessageBox.Show("Type Vaccin Modifie", "Manipulation Type Vaccin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM Type_Vaccin WHERE id_type_vcc ='" + comboBox6.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Type Vaccin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton15.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO Vaccin (id_type_vcc, lbl_vcc) VaLUES        ('" + comboBox7.SelectedItem + "','" + textBox5.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Vaccin Ajoute", "Manipulation Vaccins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if(radioButton14.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Vaccin set id_type_vcc = '" + comboBox7.SelectedItem + "',lbl_vcc = '" + textBox5.Text + "'  WHERE id_vcc = '" + comboBox5.SelectedItem + "'";
                    MessageBox.Show("Vaccin Modifie", "Manipulation Vaccins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM Vaccin WHERE id_vcc ='" + comboBox5.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Vaccins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_type_vcc FROM type_Vaccin WHERE id_type_vcc= '" + comboBox7.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label18.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = label17.Visible = label13.Visible = false;
            comboBox7.Visible = label19.Visible = label18.Visible = true;
            textBox5.Visible = label12.Visible = true;
            button5.Text = "Ajouter";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = label17.Visible = label13.Visible = true;
            comboBox7.Visible = label19.Visible = label18.Visible = true;
            textBox5.Visible = label12.Visible = true;
            button5.Text = "Modifier";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = label17.Visible = label13.Visible = true;
            comboBox7.Visible = label19.Visible = label18.Visible = false;
            textBox5.Visible = label12.Visible = false;
            button5.Text = "Supprimer";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_vcc FROM Vaccin WHERE id_vcc = '" + comboBox5.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label13.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            label22.Visible = label21.Visible = textBox7.Visible= true;
            label24.Visible = comboBox9.Visible = true;
            label20.Visible = textBox6.Visible = true;
            comboBox8.Visible = false;
            button6.Text = "Ajouter";
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            label22.Visible = label21.Visible = comboBox8.Visible = true;
            label24.Visible = comboBox9.Visible = true;
            label20.Visible = textBox6.Visible = true;
            textBox7.Visible = false;
            button6.Text = "Modifier";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            label22.Visible = label21.Visible = comboBox8.Visible = true;
            label24.Visible = comboBox9.Visible = false;
            label20.Visible = textBox6.Visible = false;
            textBox7.Visible = false;
            button6.Text = "Supprimer";
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT type_ch FROM Chambre WHERE num_ch = '" + comboBox8.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label21.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton18.Checked == true)//ajouter
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO Chambre (num_ch,type_ch, prix_ch) VaLUES        ('" + textBox7.Text + "','" + comboBox9.SelectedItem + "','" + textBox6.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Chambre Ajoute", "Manipulation Chambres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if (radioButton17.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Chambre set type_ch = '" + comboBox9.SelectedItem + "',prix_ch = '" + textBox6.Text + "'  WHERE num_ch = '" + comboBox8.SelectedItem + "'";
                    MessageBox.Show("Chambre Modifie", "Manipulation Chambres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM chambre WHERE num_ch ='" + comboBox8.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Chambres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            comboBox11.Visible = label27.Visible = label26.Visible = false;
            comboBox10.Visible = label28.Visible = label23.Visible = true;
            button7.Text = "Ajouter";
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            comboBox11.Visible = label27.Visible = label26.Visible = true;
            comboBox10.Visible = label28.Visible = label23.Visible = true;
            button7.Text = "Modifier";
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            comboBox11.Visible = label27.Visible = label26.Visible = true;
            comboBox10.Visible = label28.Visible = label23.Visible = false;
            button7.Text = "Supprimer";
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT type_ch FROM Chambre WHERE num_ch = '" + comboBox10.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label28.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                //get the nbr of occupied beds in the room
                sqlQuery = "SELECT COUNT(id_lit) FROM `lit` WHERE num_ch= '" + comboBox10.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                while (SQLrd.Read())
                {
                    nbr_lit_ch_prise = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("nbr l par ch: " + nbr_lit_ch_prise);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            //get the total nbr of beds in the room
            if (label28.Text == "Twin Sharing" || label28.Text == "Premium Twin Sharing")
            {
                nbr_lit_ch_total = 2;
            }
            else if (label28.Text == "Deluxe Room" || label28.Text == "Premium Deluxe" || label28.Text == "Suite")
            {
                nbr_lit_ch_total = 1;
            }
            else if (label28.Text == "Group Room")
            {
                nbr_lit_ch_total = 6;
            }

            if (radioButton21.Checked == true)//ajouter
            {
                
                //check if there is room for adding beds
                if (nbr_lit_ch_prise < nbr_lit_ch_total)
                {
                    MessageBox.Show("ok");
                    try
                    {
                        SQLc.Open();
                        sqlQuery = "INSERT INTO Lit (num_ch) VaLUES        ('" + comboBox10.SelectedItem+ "');";
                        SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                        SQLrd = SQLcmd.ExecuteReader();
                        MessageBox.Show("Lit Ajoute", "Manipulation Lits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SQLc.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { SQLc.Close(); }
                }
                else
                {
                    MessageBox.Show("La Chambre a atteint La Capacite Maximale", "Manipulation Lits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (radioButton20.Checked == true)
            {
                if (nbr_lit_ch_prise < nbr_lit_ch_total)
                { 
                    try
                    {
                        SQLc.Open();
                        MySqlCommand SQLcmd = new MySqlCommand();
                        SQLcmd.Connection = SQLc;

                        SQLcmd.CommandText = "UPDATE Lit set num_ch = '" + comboBox10.SelectedItem + "' WHERE id_lit = '" + comboBox11.SelectedItem + "'";
                        MessageBox.Show("Emplacement du Lit Modifie", "Manipulation Lits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SQLcmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { SQLc.Close(); }
                }
                else
                {
                    MessageBox.Show("La Chambre a atteint La Capacite Maximale", "Manipulation Lits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string query = "DELETE FROM Lit WHERE id_lit ='" + comboBox11.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Lits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            label32.Visible = label31.Visible = comboBox13.Visible = false;
            label30.Visible = label29.Visible = true;
            label33.Visible = textBox10.Visible = true;
            textBox8.Visible = textBox9.Visible = true;
            button8.Text = "Ajouter";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            label32.Visible = label31.Visible = comboBox13.Visible = true;
            label30.Visible = label29.Visible = true;
            label33.Visible = textBox10.Visible = true;
            textBox8.Visible = textBox9.Visible = true;
            button8.Text = "Modifier";
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            label32.Visible = label31.Visible = comboBox13.Visible = true;
            label30.Visible = label29.Visible = false;
            label33.Visible = textBox10.Visible = false;
            textBox8.Visible = textBox9.Visible = false;
            button8.Text = "Supprimer";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton24.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO Medicament (prix_medi, lbl_medi, genre_medi) VaLUES        ('" + textBox8.Text+ "','" + textBox9.Text + "','"+ textBox10.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Medicament Ajoute", "Manipulation Medicaments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if (radioButton23.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Medicament set prix_medi = '" + textBox8.Text+ "',lbl_medi = '" + textBox9.Text + "', genre_medi='"+ textBox10.Text + "'  WHERE id_medi = '" + comboBox13.SelectedItem + "'";
                    MessageBox.Show("Medicament Modifie", "Manipulation Medicaments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM Medicament WHERE id_medi ='" + comboBox13.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Medicaments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT lbl_medi FROM Medicament WHERE id_medi = '" + comboBox13.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label31.Text = SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            comboBox12.Visible = false; label34.Visible =  textBox12.Visible= true;
            textBox11.Visible = label36.Visible = true;
            button9.Text = "Ajouter";
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Visible = false; label34.Visible = comboBox12.Visible = true;
            textBox11.Visible = label36.Visible = true;
            button9.Text = "Modifier";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            comboBox12.Visible = label34.Visible = true; textBox12.Visible = false;
            textBox11.Visible = label36.Visible = false;
            button9.Text = "Supprimer";
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (radioButton27.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO type_traitement (lbl_type_trai, frai_trai) VaLUES        ('" + textBox12.Text + "','" + textBox11.Text + "');";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                    MessageBox.Show("Traitement Ajoute", "Manipulation Traitements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLc.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else if (radioButton26.Checked == true)
            {
                try
                {
                    SQLc.Open();
                    MySqlCommand SQLcmd = new MySqlCommand();
                    SQLcmd.Connection = SQLc;

                    SQLcmd.CommandText = "UPDATE Type_Traitement set frai_trai = '" + textBox11.Text + "' WHERE lbl_type_trai= '" + comboBox12.SelectedItem + "'";
                    MessageBox.Show("Traitement Modifie", "Manipulation Traitements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { SQLc.Close(); }
            }
            else
            {
                string query = "DELETE FROM type_traitement WHERE lbl_type_trai ='" + comboBox12.SelectedItem + "';";
                MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
                MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
                MySqlDataReader my_reader;
                try
                {
                    SQLc.Open();
                    connection_database.Open();
                    my_reader = cmd_databes.ExecuteReader();
                    MessageBox.Show("Suppression Avec Succès", "Manipulation Traitements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (my_reader.Read())
                    {

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT num_ch FROM Lit WHERE id_lit = '" + comboBox11.SelectedItem + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    label26.Text = "Chambre "+SQLrd.GetString(0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
        }
    }
}
