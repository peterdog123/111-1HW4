using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _111_1HW4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection s_Conns = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLLocalDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                s_Conns.Open();
                SqlDataAdapter o_A = new SqlDataAdapter("SELECT * from Users", s_Conns);
                DataSet o_Set = new DataSet();
                o_A.Fill(o_Set,"zz");
                gd_View.DataSource = o_Set;
                gd_View.DataBind();
                s_Conns.Close();
            }
            catch (Exception ex){
                Response.Write(ex.ToString());
            }
        }

        protected void btn_Insert_Click1(object sender, EventArgs e)
        {
            try
            {
                s_Conns.Open();
                SqlCommand scom = new SqlCommand("Insert into Users(Name, Brithday)" + "Values(N'阿貓阿狗','2000/10/10');");
                scom.ExecuteNonQuery();
                s_Conns.Close();
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}