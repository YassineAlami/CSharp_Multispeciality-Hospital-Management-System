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
    public partial class Form6 : Form
    {
        int num_dossier, c, d, num_ch, lit_aff=-1;
        int id_lit_si_pris, num_ch_si_pris, lit_aj;
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

        string g;
        public Form6()
        {
            InitializeComponent();
            fill_Cbox_id_med();
            fill_Cbox_id_inf();
            fill_Cbox_maladie();
            fill_Cbox_vaccin();
            fill_Cbox_trait();

            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            this.comboBox3.Items.Add("stable");
            this.comboBox3.Items.Add("hospitalisation");
            this.comboBox3.Items.Add("médication");
            this.comboBox3.Items.Add("hébergemen");
            this.comboBox3.Items.Add("alimentation");
            this.comboBox3.Items.Add("prises de sang");

            radioButton4.Checked = true;
        }


        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            SQLc.Open();
            SQLcmd.Connection = SQLc;
            SQLcmd.CommandText = "SELECT * FROM Patient";
            SQLrd = SQLcmd.ExecuteReader();
            SQLdt.Load(SQLrd);
            SQLrd.Close();
            SQLc.Close();
            dataGridView1.DataSource = SQLdt;
        }

        private void fill_Cbox_id_med()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM Medecin";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_med");
                    //hnooooooo
                    //comboBox1.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_id_inf()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            string query = "SELECT * FROM infirmiere";
            MySqlConnection conn_bd = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_bd = new MySqlCommand(query, conn_bd);
            MySqlDataReader myreader;
            try
            {
                conn_bd.Open();
                myreader = cmd_bd.ExecuteReader();

                while (myreader.Read())
                {
                    string item_cb = myreader.GetString("cin_inf");
                    //honaaaa
                    //comboBox2.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_maladie()
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
                    string item_cb = myreader.GetString("lbl_mal");
                    comboBox4.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn_bd.Close();
        }

        private void fill_Cbox_vaccin()
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
                    string item_cb = myreader.GetString("lbl_vcc");
                    comboBox5.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void fill_Cbox_trait()
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
                    //honaaaa
                    //comboBox8.Items.Add(item_cb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
/*
        public DataTable getData(string queryX)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            SQLcmd = new MySqlCommand(queryX, SQLc);
            SQLda = new MySqlDataAdapter(SQLcmd);
            dt_table = new DataTable();
            SQLda.Fill(dt_table);
            return dt_table;
        }
        */
        private void Form6_Load(object sender, EventArgs e)
        {
            string query = "Select num_ch from chambre where si_pris='N'";
            fill_Cbox_Lit(comboBox6, query, "num_ch");
            comboBox6_SelectedIndexChanged(null, null);


            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            

            //creation du dossier medical avec l id du dernier cree +1
            c = 0; d = 0;
            try
            {
                SQLc.Open();
                sqlQuery = "SELECT num_dossier FROM dossier_medical;";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                while (SQLrd.Read())
                {

                }
                num_dossier = int.Parse(SQLrd.GetString(0)) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
            charger_data();
            this.ActiveControl = label1;
        }
        
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pris=1;
            lit_aj = 0;

            if(radioButton1.Checked==true)  {   g = "M";    }
            else {      g = "F";    }

            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            DataRowView dv = (DataRowView)comboBox7.SelectedItem;
            int id_lit = int.Parse((string)dv.Row["id_lit"].ToString());

            DataRowView dv1 = (DataRowView)comboBox6.SelectedItem;
            int num_ch = int.Parse((string)dv1.Row["num_ch"].ToString());

            
            try
            {
                SQLc.Open();
                if(radioButton3.Checked == true)
                {        
                    sqlQuery = "INSERT INTO patient (cin_pt, num_dossier, nom_pt, pnom_pt, genre_pt, date_n_pt, adresse_pt, email_pt, id_lit, etat_pt, date_entree, date_sortie) VALUES ('" + textBox1.Text + "'," + num_dossier + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','" + textBox7.Text + "'," + id_lit + ",'"+ comboBox3.SelectedItem +"' , '"+ dateTimePicker1.Text +"', '"+ dateTimePicker3.Text+"');";
                    lit_aj = 1;
                }
                else
                {
                    sqlQuery = "INSERT INTO patient (cin_pt, num_dossier, nom_pt, pnom_pt, genre_pt, date_n_pt, adresse_pt, email_pt) VALUES ('" + textBox1.Text + "'," + num_dossier + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','"+ textBox7.Text +  "');";
                }

                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                num_dossier++;
                MessageBox.Show("Patient Ajouté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLc.Close();
            }
            catch (Exception ex) {  MessageBox.Show(ex.Message);    }
            finally {   SQLc.Close();   }
            charger_data();

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
                    if(SQLrd.GetString(0).ToString() == "N")
                    {
                        pris = 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }

            if(pris == 1)
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
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;

            //DataRowView dv = (DataRowView)comboBox7.SelectedItem;
            //int id_lit = int.Parse((string)dv.Row["id_lit"].ToString());
            
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT id_lit FROM Patient WHERE cin_pt= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    id_lit_si_pris = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("id lit a libérer: " + id_lit_si_pris);
                }
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            SQLc.Close();

            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Lit set si_pris = 'N' WHERE id_lit =" + id_lit_si_pris;

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT num_ch FROM Lit WHERE id_lit= '" + id_lit_si_pris + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    num_ch_si_pris = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("id lit a libérer: " + num_ch_si_pris);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Chambre set si_pris = 'N' WHERE num_ch =" + num_ch_si_pris;

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT num_dossier FROM Patient WHERE cin_pt= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    num_dossier = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("num dossier a supprimer: " + num_dossier);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();

            try
            {
                SQLc.Open();

                sqlQuery = "delete FROM Maladie_Dossier WHERE num_dossier= '" + num_dossier+ "'";
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

                sqlQuery = "delete FROM Vaccin_Dossier WHERE num_dossier= '" + num_dossier + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();

            string query = "DELETE FROM Patient WHERE cin_pt ='" + textBox1.Text + "';";
            MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
            MySqlDataReader my_reader;
            try
            {
                connection_database.Open();
                my_reader = cmd_databes.ExecuteReader();
                MessageBox.Show("Suppression Avec Succès");
                while (my_reader.Read())
                {

                }
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            SQLc.Close();
            charger_data();
            try
            {
                SQLc.Open();

                sqlQuery = "delete FROM Dossier_medical WHERE num_dossier= '" + num_dossier + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
            }   catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            SQLc.Close();

            string query_ = "Select num_ch from chambre where si_pris='N'";
            fill_Cbox_Lit(comboBox6, query_, "num_ch");
            comboBox6_SelectedIndexChanged(null, null);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "CIN Patient")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nom Patient")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Prenom Patient")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Adresse Patient")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "CIN Patient")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
           // if (textBox6.Text == "ID Medicament")
            {
             //   textBox6.Text = "";
               // textBox6.ForeColor = Color.Black;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            if (radioButton1.Checked == true){g = "M";} else{g = "F";}
            // int id_medi = int.Parse(textBox6.Text);

            DataRowView dv = (DataRowView)comboBox7.SelectedItem;
            int id_lit = int.Parse((string)dv.Row["id_lit"].ToString());
            //ndir n l combobox bjouj 3ad ndir lmodifications

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT id_lit FROM Patient WHERE cin_pt= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    id_lit_si_pris = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("id lit a libérer: " + id_lit_si_pris);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Lit set si_pris = 'N' WHERE id_lit =" + id_lit_si_pris;
                MessageBox.Show("lit si_pris -> N ");

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
            SQLc.Close();

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT num_ch FROM lit WHERE id_lit= '" + id_lit_si_pris + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    num_ch_si_pris = int.Parse(SQLrd.GetString(0));
                    MessageBox.Show("num ch libérer: " + num_ch_si_pris);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();

            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Chambre set si_pris = 'N' WHERE num_ch =" + num_ch_si_pris;
                MessageBox.Show("chambre si_pris -> N ");

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { SQLc.Close(); }
            SQLc.Close();

            try
            {
                SQLc.Open();
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;
                //MySqlCommand SQLcmd = new MySqlCommand();
                //SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Patient set cin_pt = @cin_pt, nom_pt = @nom_pt, pnom_pt = @pnom_pt,genre_pt=@genre_pt,date_n_pt=@date_n_pt,adresse_pt=@adresse_pt,etat_pt=@etat_pt,date_entree=@date_entree, date_sortie=@date_sortie,id_lit=@id_lit,email_pt=@email_pt WHERE cin_pt = @cin_pt";
                SQLcmd.Parameters.AddWithValue("@cin_pt", textBox1.Text);
                SQLcmd.Parameters.AddWithValue("@nom_pt", textBox2.Text);
                SQLcmd.Parameters.AddWithValue("@pnom_pt", textBox3.Text);
                SQLcmd.Parameters.AddWithValue("@genre_pt", g);
                SQLcmd.Parameters.AddWithValue("@date_n_pt", dateTimePicker2.Text);
                SQLcmd.Parameters.AddWithValue("@adresse_pt", textBox5.Text);
                //hnooooooo
                //SQLcmd.Parameters.AddWithValue("@cin_med", comboBox1.SelectedItem);
                //honaaaaaaa
                //SQLcmd.Parameters.AddWithValue("@cin_inf", comboBox2.SelectedItem);
                SQLcmd.Parameters.AddWithValue("@date_entree", dateTimePicker1.Text);
                SQLcmd.Parameters.AddWithValue("@date_sortie", dateTimePicker3.Text);
                SQLcmd.Parameters.AddWithValue("@etat_pt", comboBox3.SelectedItem);
                //honaaa
                //SQLcmd.Parameters.AddWithValue("@id_medi", id_medi);
                SQLcmd.Parameters.AddWithValue("@id_lit",id_lit );
                //honaaaa
                //SQLcmd.Parameters.AddWithValue("@lbl_type_trai", comboBox8.SelectedItem);
                SQLcmd.Parameters.AddWithValue("@email_pt", textBox7.Text);
                

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
                //charger_data();
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            SQLc.Close();
            charger_data();
            //hona
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

            int pris = 1;
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
            string query_ = "Select num_ch from chambre where si_pris='N'";
            fill_Cbox_Lit(comboBox6, query_, "num_ch");
            comboBox6_SelectedIndexChanged(null, null);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {          
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //honaaa
                //comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //honaaaa
                //comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox7.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                //comboBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //honaaa
                //textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                //honaaaaa
                //comboBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[9].Value.ToString() == "M") radioButton1.Checked = true; else radioButton2.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                SQLc.Open();

                sqlQuery = "SELECT id_lit FROM Patient WHERE cin_pt= '" + textBox1.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    lit_aff = int.Parse(SQLrd.GetString(0));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            
            int num_ch = 0;
            try
            {
                SQLc.Open();

                sqlQuery = "SELECT num_ch FROM lit WHERE id_lit= '" + lit_aff + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    num_ch = int.Parse(SQLrd.GetString(0));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            SQLc.Close();
            try
            {
                comboBox6.Text = num_ch.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //textBox6.ForeColor = Color.Black;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataView dv = SQLdt.DefaultView;
                dv.RowFilter = string.Format("cin_pt LIKE '%{0}%'", textBox4.Text);
                dataGridView1.DataSource = dv.ToTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if(c==0)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO dossier_medical(num_dossier) VALUES (" + num_dossier + ");";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SQLc.Close();
            }

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO Maladie_Dossier (id_mal, num_dossier) VALUES ((select id_mal from Maladie where lbl_mal='" + comboBox4.SelectedItem + "'),"+ num_dossier+");";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                c++;
                MessageBox.Show("Ajouté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            if (c == 0)
            {
                try
                {
                    SQLc.Open();
                    sqlQuery = "INSERT INTO dossier_medical(num_dossier) VALUES (" + num_dossier + ");";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SQLc.Close();
            }

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO Vaccin_Dossier (id_vcc, num_dossier) VALUES ((select id_vcc from Vaccin where lbl_vcc='" + comboBox5.SelectedItem + "')," + num_dossier + ");";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                c++;
                MessageBox.Show("Ajouté Avec Succès", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int val;
            //Int32.TryParse(comboBox6.SelectedValue.ToString(), out val);
            //string query = "SELECT `id_lit` FROM `Lit` WHERE `num_ch` = " + val;
            //comboBox7.DataSource = getData(query);
            //dataGridView_Products.DataSource = getData(query);
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            int val;
            Int32.TryParse(comboBox6.SelectedValue.ToString(),out val);
            string query = "Select id_lit from Lit where si_pris= 'N' and num_ch="+val;
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

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                //foreach(Control c in panel4.Controls)
                //{
                //    if(c is TextBox)    {   ((TextBox)c).Clear();  }
                //}
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox7.Text = string.Empty;
                textBox5.Text = string.Empty;
                //hhoonnaaaa
                //textBox6.Text = string.Empty;
                textBox8.Visible = false;
                label22.Visible = label23.Visible = label24.Visible = label18.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                //honaaaa
                //comboBox1.Text = string.Empty;
                //honaaaa
                //comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;
                comboBox6.Text = string.Empty;
                comboBox7.Text = string.Empty;
                //honaaa
                //comboBox8.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text == "CIN Patient" || textBox1.Text == "")
            {
                MessageBox.Show("CIN Patient Non Valide", "Gestion Hopital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double facture;
                SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
                try
                {
                    SQLc.Open();

                    sqlQuery = "SELECT chambre.prix_ch, type_traitement.frai_trai, medicament.prix_medi FROM `chambre` INNER join lit INNER JOIN patient INNER JOIN type_traitement INNER JOIN medicament on chambre.num_ch = lit.num_ch AND patient.id_lit= lit.id_lit AND type_traitement.lbl_type_trai = patient.lbl_type_trai AND medicament.id_medi=patient.id_medi WHERE patient.cin_pt ='" + textBox1.Text + "'";// WHERE num_ch= " + num_ch;
                    //sqlQuery = "SELECT chambre.prix_ch, type_traitement.frai_trai, medicament.prix_medi FROM `chambre` INNER join lit INNER JOIN patient INNER JOIN type_traitement INNER JOIN medicament on chambre.num_ch = lit.num_ch AND patient.id_lit= lit.id_lit AND type_traitement.lbl_type_trai = patient.lbl_type_trai AND medicament.id_medi=patient.id_medi WHERE patient.cin_pt ='" + textBox1.Text + "'";// WHERE num_ch= " + num_ch;
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    if (SQLrd.Read())
                    {
                        facture = double.Parse(SQLrd.GetString(0)) + double.Parse(SQLrd.GetString(1)) + double.Parse(SQLrd.GetString(2));
                        //MessageBox.Show("Facture totale: " + facture);
                        textBox8.Text = facture.ToString() + " DH";
                        label22.Text += (SQLrd.GetString(0));
                        label23.Text += (SQLrd.GetString(1));
                        label24.Text += (SQLrd.GetString(2));
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();
                label22.Visible = label23.Visible = label24.Visible = textBox8.Visible = label18.Visible = true;
                //textBox8.Visible = true;
                //label18.Visible = true;
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = label10.Visible = label12.Visible = label16.Visible = label17.Visible = label20.Visible = true;
            comboBox3.Visible = comboBox6.Visible = comboBox7.Visible = dateTimePicker1.Visible = dateTimePicker3.Visible = true;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Form15 f1 = new Form15();
            f1.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = label10.Visible = label12.Visible = label16.Visible = label17.Visible = label20.Visible = false;
            comboBox3.Visible = comboBox6.Visible = comboBox7.Visible = dateTimePicker1.Visible = dateTimePicker3.Visible = false;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
