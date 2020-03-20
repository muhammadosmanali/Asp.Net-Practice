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
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.connection_string))
            {
                connection.Open();

                string query = "Select customer_id As [Customer ID]," +
                    "customer_name As [Customer Name]," +
                    "customer_details As [Customer Details]," +
                    "gender As Gender," +
                    "address_line_1 + ' ' + address_line_2 + ', '  + address_line_3 As Address," +
                    "town As Town," +
                    "county As County," +
                    "country As Country from Customer";
                SqlDataAdapter sqladp = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                sqladp.Fill(dt);
                dgvCustomer.DataSource = dt;

            }
        }
    }
}
