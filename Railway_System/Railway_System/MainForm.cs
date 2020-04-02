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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void adaugaOCursaNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientNouToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Despre obj2 = new Despre();
            obj2.ShowDialog();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact obj3 = new Contact();
            obj3.ShowDialog();
        }

        private void rezervaTichetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers obj4 = new ManageUsers();
            obj4.ShowDialog();
        }
    }
}
