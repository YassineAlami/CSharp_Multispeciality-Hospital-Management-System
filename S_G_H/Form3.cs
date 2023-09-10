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
    public partial class Form3 : Form
    {
        public static string user_app;
        string type_user;

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
        String database = "bd_hopital_3";


        public Form3()
        {
            InitializeComponent();
            //this.BackColor = Color.White;
            //panel2.BackColor = Color.FromArgb(25, Color.Black);
        }
        //protected override void OnPaint(PaintEventArgs e)
      //  {
            //e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        //}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f1 = new Form2();
            f1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
                SQLc.Open();
            
                sqlQuery = "select email_user, type_user from user_app where email_user= '" + textBox1.Text + "' and psw_user= '" + textBox2.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                int cpt = 0;
                while (SQLrd.Read())
                {
                    type_user = SQLrd.GetString(1);
                    cpt++;
                }
                SQLc.Close();

                if (cpt == 0)
                {
                    MessageBox.Show("La Connexion a échoué Veuillez Réessayer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SQLc.Close();
                }
                else
                {
                    MessageBox.Show("type: " + type_user);
                    if (type_user == "Patient")
                    {
                        try
                        {
                            SQLc.Open();

                            sqlQuery = "SELECT cin_pt FROM Patient WHERE email_pt= '" + textBox1.Text + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();

                            if (SQLrd.Read())
                            {
                                user_app = SQLrd.GetString(0);
                                MessageBox.Show("cin patient li tconnecta: " + user_app);
                            }
                            this.Visible = false;
                            Form10 f = new Form10();
                            f.Visible = true;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        SQLc.Close();
                    }
                    else if (type_user == "Admin")
                    {
                        try
                        {
                            SQLc.Open();

                            sqlQuery = "SELECT cin_admin FROM Admin_App WHERE email_admin= '" + textBox1.Text + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();

                            if (SQLrd.Read())
                            {
                                user_app = SQLrd.GetString(0);
                                MessageBox.Show("cin Admin li tconnecta: " + user_app);
                            }
                            this.Visible = false;
                            Form5 f = new Form5();
                            f.Visible = true;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        SQLc.Close();
                    }
                    else if (type_user == "Medecin")
                    {
                        try
                        {
                            SQLc.Open();

                            sqlQuery = "SELECT cin_med FROM Medecin WHERE email_med= '" + textBox1.Text + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();

                            if (SQLrd.Read())
                            {
                                user_app = SQLrd.GetString(0);
                                MessageBox.Show("cin Medecin li tconnecta: " + user_app);
                            }
                            this.Visible = false;
                            Form14 f = new Form14();
                            f.Visible = true;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        SQLc.Close();
                    }
                    else if (type_user == "Infirmier")
                    {
                        try
                        {
                            SQLc.Open();

                            sqlQuery = "SELECT cin_inf FROM infirmiere WHERE email_inf= '" + textBox1.Text + "'";
                            SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                            SQLrd = SQLcmd.ExecuteReader();

                            if (SQLrd.Read())
                            {
                                user_app = SQLrd.GetString(0);
                                MessageBox.Show("cin Infirmier li tconnecta: " + user_app);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        SQLc.Close();
                    }

                }
                //*****
                /*
                try
                {
                    SQLc.Open();
                    
                    sqlQuery = "SELECT cin_pt FROM Patient WHERE email_pt= '" + textBox1.Text+"'";
                    SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                    SQLrd = SQLcmd.ExecuteReader();

                    if (SQLrd.Read())
                    {
                        user_app = SQLrd.GetString(0);
                        MessageBox.Show("cin patient li tconnecta: " +user_app );
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                SQLc.Close();


                MessageBox.Show("La Connexion a été établie", "Connecté Avec Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLc.Close();
                SQLc.Open();

                sqlQuery = "SELECT type_user FROM user_app WHERE email_user= '" + textBox1.Text + "' and psw_user = '" + textBox2.Text + "'";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();

                if (SQLrd.Read())
                {
                    //if (SQLrd.GetString(0)=="Medecin"|| SQLrd.GetString(0) =="Infirmier")
                    //{
                    //    this.Visible = false;
                    //    Form5 f = new Form5();
                    //    f.Visible = true;
                    //}
                    if (SQLrd.GetString(0) == "Admin")
                    {
                            this.Visible = false;
                            Form5 f = new Form5();
                            f.Visible = true;
                    }
                    else if (SQLrd.GetString(0) == "Medecin")
                        {
                            this.Visible = false;
                            Form14 f = new Form14();
                            f.Visible = true;
                        }
                        else if (SQLrd.GetString(0) == "Patient")
                    {
                        this.Visible = false;
                        Form10 f = new Form10();
                        f.Visible = true;
                    }
                }
                SQLc.Close();
                }*/
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label3;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Email")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Mot de Passe")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '⦿';
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            Form9 f9 = new Form9();
            f9.Visible = true; 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            Form20 f9 = new Form20();
            f9.Visible = true;
        }
    }
}
