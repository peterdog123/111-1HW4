using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _111_1HW4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Sqlconnection s_Conns = new Sqlconnection(ConfigurationManager.ConnectionStrings["MSSQLLocalDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                s_Conns.open();
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

        protected System.Void btn_Insert_Click()
        {
            try
            {
                s_Conns.open();
                SqlCommand scom = new SqlCommand("Insert into Users(Name, Brithday)"+ "Values(N'阿貓阿狗','2000/10/10');");
                scom.ExecuteNonQuery();
                s_Conns.close();
                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}