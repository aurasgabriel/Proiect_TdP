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
    public partial class Ticket_Reservation : Form
    {
        RailwayDbEntities db;
        public Ticket_Reservation()
        {
            InitializeComponent();
            db = new RailwayDbEntities();
            BindDeparture();
            BindArrival();

        }

        private void BindDeparture()
        {
            var items = db.Routes.ToList();
            DepartureCombo.DataSource = items;
            DepartureCombo.DisplayMember = "DepartureCity";
            //throw new NotImplementedException();
        }

        private void BindArrival()
        {
            var items = db.Routes.ToList();
            ArrivalCombo.DataSource = items;
            ArrivalCombo.DisplayMember = "ArrivalCity";
            //throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ArrivalCombo.Text!= DepartureCombo.Text)
            {
                dataGrid.DataSource = db.Routes.Where(a => a.DepartureCity.Equals(DepartureCombo.Text) && a.ArrivalCity.Equals(ArrivalCombo.Text)).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CustomerIDtxt.Text);
            var item = db.Customers.Where(a => a.CustomerID == id).FirstOrDefault();
            CustomerFnametxt.Text = item.First_Name;
            CustomerLnametxt.Text = item.Last_Name;
            Birthdaytxt.Text = item.Birthday;
            Citytxt.Text = item.City;
            Phonetxt.Text = item.Phone;
            Mailtxt.Text = item.E_mail;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var trainid = dataGrid.SelectedRows[0].Cells[0].Value;
            Routetxt.Text = trainid.ToString();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Seattxt.Text)<= 200)
            {
                if (AvailableSeat() == true)
                {
                    Reservation reservation = new Reservation();
                    reservation.CustomerID = Convert.ToInt32(CustomerIDtxt.Text);
                    reservation.DateOfDeparture = dateTime.Value;
                    reservation.RouteID = Convert.ToInt32(Routetxt.Text);
                    reservation.SeatNr = Convert.ToInt32(Seattxt.Text);
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    MessageBox.Show("Ticket Booked Successfully");
                }
                else
                {
                    MessageBox.Show("Seat is already reserved");
                }
            }
            else
            {
                MessageBox.Show("Seat number invalid");
            }
        }

        private bool AvailableSeat()
        {
            int routeid = Convert.ToInt32(Routetxt.Text);
            int seatnr = Convert.ToInt32(Seattxt.Text);
            string departure = dateTime.Value.ToString("dd/MM/YYYY");
            var item = db.Reservations.Where(a => a.RouteID == routeid && a.SeatNr == seatnr).FirstOrDefault();
            if (item != null)
            {
                string existdate = ((DateTime)item.DateOfDeparture).ToString("dd/MM/YYYY");

                if (existdate == departure)

                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
