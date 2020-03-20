using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hire_a_Car
{
    public partial class Vehicles : UserControl
    {
        public Vehicles()
        {
            InitializeComponent();
        }

        private void Vehicles_Load(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.connection_string))
            {
                connection.Open();
                string query = "Select model_name As [Model Name], reg_number As [Registration Number], manufacturer_name As [Manufacturer Name], Model.daily_hire_rate As [Daily Hire Rate($)], current_mileage As [Current Mileage(miles)], date_mot_due As [Last MOT], engine_size As [Engine Size(cc)], vehicle_category_description As [Vehicle Category] " +
                    "from Vehicle " +
                    "Inner Join Model " +
                    "On Vehicle.model_code = Model.model_code " +
                    "Inner Join [Vehicle Category] " +
                    "On Vehicle.vehicle_category_code = [Vehicle Category].vehicle_category_code " +
                    "Inner Join Manufacturer " +
                    "On Model.manufacturer_code = Manufacturer.manufacturer_code";
                SqlDataAdapter sql = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                sql.Fill(dt);
                dgvVehicles.DataSource = dt;
            }
        }
    }
}
