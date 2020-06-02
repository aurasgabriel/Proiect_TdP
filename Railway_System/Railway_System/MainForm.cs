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

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact obj3 = new Contact();
            obj3.ShowDialog();
        }

        private void rezervaTichetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ticket_Reservation obj6 = new Ticket_Reservation();
            obj6.ShowDialog();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers obj4 = new ManageUsers();
            obj4.ShowDialog();
        }

        private void manageRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoutesInfo obj5 = new RoutesInfo();
            obj5.ShowDialog();
        }
    }
}
