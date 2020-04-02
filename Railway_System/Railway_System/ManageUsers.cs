using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_System
{
    public partial class ManageUsers : Form
    {
        Customer model = new Customer();
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete ?","Delete Operation",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                using(RailwayDbEntities db = new RailwayDbEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                        db.Customers.Attach(model);
                    db.Customers.Remove(model);
                    db.SaveChanges();
                    PopulateDataGrid();
                    Clear();
                    MessageBox.Show("Deleted Successfully !");
                }
            }
        }

        void Clear()
        {
            textFName.Text = textLName.Text = textBirthday.Text = textCity.Text = textPhone.Text = textMail.Text = "";
            btnInsert.Text = "Save";
            btnDelete.Enabled = false;
            model.CustomerID = 0;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            Clear();
            PopulateDataGrid();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            model.First_Name = textFName.Text.Trim();
            model.Last_Name = textLName.Text.Trim();
            model.Birthday = textBirthday.Text.Trim();
            model.City = textCity.Text.Trim();
            model.Phone = textPhone.Text.Trim();
            model.E_mail = textMail.Text.Trim();

            using (RailwayDbEntities db = new RailwayDbEntities())
            {
                if (model.CustomerID == 0)
                    db.Customers.Add(model);
                else
                    db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            Clear();
            PopulateDataGrid();
            MessageBox.Show("Submitted Succesfully !");
        }
        
        void PopulateDataGrid()
        {
            dataCustomer.AutoGenerateColumns = false;
            using (RailwayDbEntities db = new RailwayDbEntities())
            {
                dataCustomer.DataSource = db.Customers.ToList<Customer>();
                foreach (var item in db.Customers.ToList<Customer>())
                {
                    model.First_Name = item.First_Name;
                }
            }
        }

        private void dataCustomer_DoubleClick(object sender, EventArgs e)
        {
            if(dataCustomer.CurrentRow.Index != -1)
            {
                model.CustomerID = Convert.ToInt32(dataCustomer.CurrentRow.Cells["CustomerID"].Value);
                using (RailwayDbEntities db = new RailwayDbEntities())
                {
                    model = db.Customers.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    textFName.Text = model.First_Name;
                    textLName.Text = model.Last_Name;
                    textBirthday.Text = model.Birthday;
                    textCity.Text = model.City;
                    textPhone.Text = model.Phone;
                    textMail.Text = model.E_mail;
                }
                btnInsert.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
