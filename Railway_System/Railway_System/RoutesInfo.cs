using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_System
{
    public partial class RoutesInfo : Form
    {
        RailwayDbEntities db;

        public RoutesInfo()
        {
            InitializeComponent();
            db = new RailwayDbEntities();
        }

        void Clear()
        {
            departureText.Text = arrivalText.Text = DepartTimeText.Text = ArrivTimeText.Text = ClassText.Text = PriceText.Text = SeatText.Text = CodeText.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
               // common.Logger.OpenLogger();
                //common.Logger.LogThisLine(MethodBase.GetCurrentMethod().Name);
                Route rd = new Route();
                rd.TrainCode = CodeText.Text;
                rd.DepartureCity = departureText.Text;
                rd.ArrivalCity = arrivalText.Text;
                rd.DepartureTime = DepartTimeText.Text;
                rd.ArrivalTime = ArrivTimeText.Text;
                rd.Class = ClassText.Text;
                rd.Seat = Convert.ToInt32(SeatText.Text);
                rd.Price = Convert.ToDecimal(PriceText.Text);
                db.Routes.Add(rd);
                db.SaveChanges();
                MessageBox.Show("New route added successfully !");
                Clear();
               // common.Logger.CloseLogger();
        }
    
        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoutesInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
