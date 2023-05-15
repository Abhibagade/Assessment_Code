using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Assessment_xBiz
{
    public partial class Employee : System.Web.UI.Page
    {

        static string conString = ConfigurationManager.ConnectionStrings["emp"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(conString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Employee INNER JOIN Employee_Details ON Employee.Emp_ID = Employee_Details.Emp_ID WHERE Employee.Emp_ID = @Emp_ID;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Emp_ID", int.Parse(IdTextBox.Text));

            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}