using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hire_a_Car
{
    public partial class Bookings : UserControl
    {
        public Bookings()
        {
            InitializeComponent();
        }

        private void Bookings_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connection_string))
            {
                connection.Open();
                string query = "Select booking_id As [Booking ID], Customer.customer_id As [Customer ID], customer_name As [Customer Name], model_name As [Model Name], date_from As [Date From], date_to As [Date to],  confirmation_letter_sent_yn As [Confirmation Letter Sent], payment_received_yn As [Payment Received] " +
                    "From Booking " +
                    "Inner Join Vehicle " +
                    "On Vehicle.reg_number = Booking.reg_number " +
                    "Inner Join Model " +
                    "On Model.model_code = Vehicle.model_code " +
                    "Inner Join Customer " +
                    "On Customer.customer_id = Booking.customer_id " +
                    "Inner Join [Booking Status] " +
                    "On [Booking Status].booking_status_code = Booking.booking_status_code";

                SqlDataAdapter sqladp = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                sqladp.Fill(dt);
                dgvBookings.DataSource = dt;
            }
        }
    }
}
