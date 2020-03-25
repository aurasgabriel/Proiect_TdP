using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(usr_txt .Text != string.Empty && pass_txt .Text !=string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Te rugam introdu utilizatorul si parola !");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
