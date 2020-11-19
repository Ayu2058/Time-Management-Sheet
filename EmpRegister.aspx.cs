using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheetManagement
{
    public partial class ManagerPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label13.Text = "";
            Label14.Text = "";
            if (Calendar1.SelectedDate == null||(RadioButton1.Checked==false&&RadioButton2.Checked==false))
            {
                if(Calendar1.SelectedDate == null)
                Label13.Text = "Select Date";
                if (RadioButton1.Checked == false && RadioButton2.Checked == false)
                    Label14.Text = "Select Gender from here";
            }
            else
            {
                string connectString = @"Data Source=DESKTOP-8LTHKRE\\SQLEXPRESS;Initial Catalog=TimesheetMgmt;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                try
                {
                    SqlCommand sqlComm = new SqlCommand("EmpRegister", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@Emp_Id", TextBox1.Text);
                    sqlComm.Parameters.AddWithValue("@FirstName", TextBox2.Text);
                    sqlComm.Parameters.AddWithValue("@LastName", TextBox3.Text);
                    sqlComm.Parameters.AddWithValue("@Password", TextBox8.Text);
                    sqlComm.Parameters.AddWithValue("@Phone", Int64.Parse(TextBox5.Text));
                    if (RadioButton1.Checked)
                        sqlComm.Parameters.AddWithValue("@Gender", RadioButton1.Text);
                    else if (RadioButton2.Checked)
                        sqlComm.Parameters.AddWithValue("@Gender", RadioButton2.Text);
                    sqlComm.Parameters.AddWithValue("@Address", TextBox6.Text);
                    sqlComm.Parameters.AddWithValue("@Designation", DropDownList1.Text);
                    sqlComm.Parameters.AddWithValue("@Email", TextBox7.Text);
                    sqlComm.Parameters.AddWithValue("@DOB", Calendar1.SelectedDate);

                    sqlComm.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Done!!!')", true);
                    //Response.Redirect("ManagerPanel.aspx");
                }
                catch (Exception)
                {
                }
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Enabled = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Enabled = false;
        }
    }
}