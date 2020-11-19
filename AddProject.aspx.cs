using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TimeSheetManagement
{
    public partial class AddProject : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8LTHKRE\\SQLEXPRESS;Initial Catalog=TimesheetMgmt;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String pname = "spAddProject";
            con.Open();
            SqlCommand cmd = new SqlCommand(pname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Project_ID", TextBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@Project_name", TextBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@StartDate", Calendar1.SelectedDate.Date);
            cmd.Parameters.AddWithValue("@EndDate", Calendar2.SelectedDate.Date);
            cmd.ExecuteNonQuery();
            con.Close();
            //Response.Write(" Data submitted successfully!!");
        }
    }
}