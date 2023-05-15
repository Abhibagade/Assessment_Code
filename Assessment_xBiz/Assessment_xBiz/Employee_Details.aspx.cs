using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Assessment_xBiz
{
    public partial class Employee_Details : System.Web.UI.Page
    {
        static string conString = ConfigurationManager.ConnectionStrings["emp"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(conString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Employees (Emp_Name, Emp_State, Emp_City, Emp_Contact, Emp_Hobbies, Emp_Resume) VALUES (@Emp_Name, @Emp_State, @Emp_City, @Emp_Contact, @Emp_Hobbies, @Emp_Resume)";

            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            
            cmd.Parameters.AddWithValue("@Emp_Name", NameTextBox.Text);
            cmd.Parameters.AddWithValue("@Emp_State", StateDropDownList.SelectedValue);
            cmd.Parameters.AddWithValue("@Emp_City", CityTextBox.Text);
            cmd.Parameters.AddWithValue("@Emp_Contact", ContactTextBox.Text);
            cmd.Parameters.AddWithValue("@Emp_Hobbies", HobbyTextBox.Text);
            cmd.Parameters.AddWithValue("@Emp_Resume", FileUpload1.FileName);

            conn.Open();
            int empID = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
    }
}