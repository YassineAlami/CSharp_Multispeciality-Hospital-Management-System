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

namespace S_G_H
{
    public partial class Form4 : Form
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

        public Form4()
        {
            InitializeComponent();
            fill_Cbox_specialite();
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" +"user id="+user +";"+"password="+"" +";"+"database="+database;
            SQLc.Open();
            SQLcmd.Connection = SQLc;
            SQLcmd.CommandText = "SELECT * FROM Medecin";
            SQLrd = SQLcmd.ExecuteReader();
            SQLdt.Load(SQLrd);
            SQLrd.Close();
            SQLc.Close();
            dataGridView1.DataSource = SQLdt;
        }

        private void fill_Cbox_specialite()
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
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string g;
            int sp = int.Parse(comboBox1.SelectedItem.ToString());
            if (radioButton1.Checked == true)
            {
                g = "M";
            }
            else
            {
                g = "F";
            }
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO Medecin (cin_med, nom_med, pnom_med, genre_med, tel_med,id_spe,email_med) VaLUES        ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+g+"', '"+textBox5.Text+"',"+sp+",'"+textBox6.Text+"');";
                SQLcmd = new MySqlCommand(sqlQuery,SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                SQLc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLc.Close();
            }
            charger_data();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("voulez-vous vraiment quitter l'application?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(q==DialogResult.Yes)
                {
                    Application.Exit();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            charger_data();
            if (textBox1.Text == "CIN Medecin")
            {
                textBox1.ForeColor = Color.LightGray;
            }
            if (textBox2.Text == "Nom Medecin")
            {
                textBox2.ForeColor = Color.LightGray;
            }
            
            if (textBox3.Text == "Prenom Medecin")
            {
                textBox3.ForeColor = Color.LightGray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            SQLc.Open();
            string g;
            if (radioButton1.Checked == true) { g = "M"; } else { g = "F"; }
            try
            {
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Medecin set cin_med = @cin_med, nom_med = @nom_med, pnom_med = @pnom_med,genre_med=@genre_med,tel_med=@tel_med, email_med = @email_med, id_spe=@id_spe WHERE cin_med = @cin_med";
                SQLcmd.Parameters.AddWithValue("@cin_med",textBox1.Text);
                SQLcmd.Parameters.AddWithValue("@nom_med", textBox2.Text);
                SQLcmd.Parameters.AddWithValue("@pnom_med", textBox3.Text);
                SQLcmd.Parameters.AddWithValue("@genre_med", g);
                SQLcmd.Parameters.AddWithValue("@tel_med", textBox5.Text);
                SQLcmd.Parameters.AddWithValue("@email_med", textBox6.Text);
                SQLcmd.Parameters.AddWithValue("@id_spe", comboBox1.SelectedItem);

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
                charger_data();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SQLc.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "M") radioButton1.Checked = true; else radioButton2.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            string query = "DELETE FROM Medecin WHERE cin_med ='" + textBox1.Text + "';";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            SQLc.Open();

            SQLcmd.Connection = SQLc;
            SQLcmd.CommandText = "DELETE FROM Medecin WHERE cin_med ='"+textBox1.Text+"';";//@cin_med
//            SQLcmd.Parameters.AddWithValue("@cin_med", textBox1.Text);
            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
            SQLc.Close();
            */

            //connection_database.Close();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            charger_data();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataView dv = SQLdt.DefaultView;
                dv.RowFilter = string.Format("cin_med LIKE '%{0}%'", textBox4.Text);
                dataGridView1.DataSource = dv.ToTable();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "CIN Medecin")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Prenom Medecin")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "CIN Med")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.SteelBlue;
            }
        }

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            
        }
        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nom Medecin")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "Prenom Medecin")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Tel Medecin")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ForeColor = Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }
    }
}
