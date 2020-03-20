using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hire_a_Car
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            this.Controls.Add(obj);
            obj.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Home obj = new Home();
            Controls.Add(obj);
            obj.BringToFront();
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            Vehicles obj = new Vehicles();
            this.Controls.Add(obj);
            obj.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            Controls.Add(obj);
            obj.BringToFront();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Bookings obj = new Bookings();
            Controls.Add(obj);
            obj.BringToFront();
        }
    }
}
