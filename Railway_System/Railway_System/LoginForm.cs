using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NLog;
using System.Reflection;
using Railway_System.common;
using System.IO;

namespace Railway_System
{
    public partial class LoginForm : Form
    {
        private string userName = "";
        private string error = "";
        private DateTime loginTime, logoutTime, errorTime;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_utilizator_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                //common.Logger.OpenLogger();
                RailwayDbEntities db = new RailwayDbEntities();
                if (usr_txt.Text != string.Empty && pass_txt.Text != string.Empty)
                {
                    
                    var user = db.Admins.Where(a => a.Username.Equals(usr_txt.Text.Trim())).SingleOrDefault();
                    if (user != null)
                    {
                        if (user.Password.Equals(pass_txt.Text))
                        {
                            MessageBox.Show("Logged in successfully as Admin !");
                            this.Visible = false;
                            Home obj1 = new Home();
                            obj1.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Password !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username !");
                    }
                }
                else
                {
                    MessageBox.Show("Please insert Username & Password !");
                }

               // common.Logger.CloseLogger();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                errorTime = DateTime.Now; //exception time
                LogErMsg(); //Call the error information method
                MessageBox.Show("Error ! Please check the error log !");
            }
            
        }

        private void FrmLogFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (userName != "")
            {
                logoutTime = DateTime.Now; //logout time
                LogMsg(); //Call the user information method
            }
        }

        private void LogMsg()
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\auras\Documents\Proiect_TdP\Railway_System\Railway_System\log.txt", true);//set the log path
            sw.WriteLine($"User Message:(LoginTime:{loginTime.ToString()}\tUserName:{userName}\tLogoutTime:{logoutTime.ToString()})");//log message
            sw.Close();
        }

        private void LogErMsg()
        {
      
                StreamWriter sw = new StreamWriter(@"C:\Users\auras\Documents\Proiect_TdP\Railway_System\Railway_System\log.txt", true);//set the log path
            sw.WriteLine($"Error Message:({error}\tErrorTime:{errorTime})");//error message
            sw.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
