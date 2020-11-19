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
    public partial class ManagerLogin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-8LTHKRE\\SQLEXPRESS;Initial Catalog=TimesheetMgmt;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand sqlComm = new SqlCommand("ManagerLogin", conn);
                sqlComm.Parameters.AddWithValue("@Email", TextBox1.Text);
                sqlComm.Parameters.AddWithValue("@Password", TextBox2.Text);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = sqlComm.ExecuteReader();
                if (sdr.Read())
                {
                    Response.Redirect("ManagerPanel.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid username or password')", true);
                }
            }
            catch (Exception)
            {
            }
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}