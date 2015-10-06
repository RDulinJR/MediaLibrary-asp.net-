using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Html_Login : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
                TextBox1.Text = Request.Cookies["UserName"].Value;
            if (Request.Cookies["Pass"] != null)
                TextBox2.Text = Request.Cookies["Pass"].Value;
            if (Request.Cookies["UserName"] != null && Request.Cookies["Pass"] != null)
                CheckBox1.Checked = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand("select U_Id from Users where UserName=@un and Password=@pw", con);
        cmd.Parameters.AddWithValue("@un", TextBox1.Text);
        cmd.Parameters.AddWithValue("@pw", TextBox2.Text);
        con.Open();
        string id = Convert.ToString(cmd.ExecuteScalar());
        if (String.IsNullOrEmpty(id))
            Label3.Text = "Invalid Username or Password!";
        else
        {
            if (CheckBox1.Checked)
            {
                Response.Cookies["UserName"].Value = TextBox1.Text;
                Response.Cookies["Pass"].Value = TextBox2.Text;
                Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["Pass"].Expires = DateTime.Now.AddMonths(2);
            }
            Session.Add("uid", id);
            Session.Add("username", TextBox1.Text);
            FormsAuthentication.RedirectFromLoginPage(id, false);
        }
    }
}