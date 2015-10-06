using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Html_MovieDetails : System.Web.UI.Page
{
    private string strcon = WebConfigurationManager.ConnectionStrings["MediaLibraryConnectionString1"].ConnectionString;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        HttpCookie thmCook = Request.Cookies.Get("userThm");//reads variable from cookie
        if (thmCook != null)
        {//test if cookie is present
            Page.Theme = thmCook.Value;//sets theme to value in cookie
        }
        else
        {
            Page.Theme = "BlueGreen";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand("Select * from Movies where MediaId=@mid", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cmd.Parameters.AddWithValue("@mid", Page.Request.QueryString["mediaId"].ToString());
        con.Open();
        adp.Fill(ds, "Movies");
        cmd.ExecuteNonQuery();
        con.Close();
        FormView1.DataSource = ds;
        FormView1.DataBind();
    }
}