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

namespace Railway_System
{
    public partial class LoginForm : Form
    {
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
