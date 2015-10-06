using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;


public partial class Html_AddMovie : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["MediaLibraryConnectionString1"].ConnectionString;
    Movie movie;
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
        if (Session["username"] == null)
            Response.Redirect("Login.aspx");
    }
    protected void clear()
    {
        Image1.Visible = false;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string s;
        string url = "http://www.omdbapi.com/?t=" + TextBox1.Text + "&y=&plot=short&r=json";
        using (var client = new WebClient())
        {
            s = client.DownloadString(url);
        }
        movie = new JavaScriptSerializer().Deserialize<Movie>(s);
        TextBox1.Text = movie.Title;
        TextBox2.Text = movie.Year;
        TextBox3.Text = movie.Runtime.Remove(movie.Runtime.IndexOf(' '));
        TextBox4.Text = movie.Genre;
        TextBox5.Text = movie.Actors;
        Image1.Visible = true;
        Image1.ImageUrl = movie.Poster;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (ValidateInfo())
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("Insert into Movies (Title,Year,Runtime,Genre,Actors,Poster,U_id) values (@t,@y,@r,@g,@a,@p,@uid)", con);
            cmd.Parameters.AddWithValue("@t", TextBox1.Text);
            cmd.Parameters.AddWithValue("@y", TextBox2.Text);
            cmd.Parameters.AddWithValue("@r", TextBox3.Text);
            cmd.Parameters.AddWithValue("@g", TextBox4.Text);
            cmd.Parameters.AddWithValue("@a", TextBox5.Text);
            cmd.Parameters.AddWithValue("@p", Image1.ImageUrl);
            cmd.Parameters.AddWithValue("@uid", Session["uid"].ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write(TextBox1.Text + " Added Successfully!");
            clear();
        }
    }
    protected bool ValidateInfo()
    {
        string errorMessage = "";
        bool valid = true;
        int i;
        if(String.IsNullOrWhiteSpace(TextBox1.Text))
        {
            errorMessage += "No Valid title\r\n";
            valid = false;
        }
        if (String.IsNullOrWhiteSpace(TextBox2.Text))
        {
            errorMessage += "No valid year\r\n";
            valid = false;
        }
        else if (!int.TryParse(TextBox2.Text, out i))
        {
            errorMessage += "Only use numbers for year\r\n";
            valid = false;
        }
        if (String.IsNullOrWhiteSpace(TextBox3.Text))
        {
            errorMessage += "No valid runtime\r\n";
            valid = false;
        }
        else if (!int.TryParse(TextBox3.Text, out i))
        {
            errorMessage += "Only use numbers for runtime\r\n";
            valid = false;
        }
        if (String.IsNullOrWhiteSpace(TextBox4.Text))
        {
            errorMessage += "No Valid Genre\r\n";
            valid = false;
        }
        if (String.IsNullOrWhiteSpace(TextBox5.Text))
        {
            errorMessage += "No Valid Actors\r\n";
            valid = false;
        }
        if(!String.IsNullOrWhiteSpace(errorMessage))
        {
            Response.Write(errorMessage + "\r\n Title was not added!");
        }
        return valid;
    }
}