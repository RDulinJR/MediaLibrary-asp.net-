using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//only runs when page first loads not on postback reload
        {
            //activeThm is the current theme for the page
            string activeThm = Page.Theme;
            //thmCook is the cookie storing the theme setting, userThm is the cookie value storing the theme the user wants
            HttpCookie thmCook = Request.Cookies.Get("userThm");//reads variable from cookie
            if (thmCook != null)
            {//test if cookie is present
                activeThm = thmCook.Value;//sets active theme to value in cookie
            }
            if (!string.IsNullOrEmpty(activeThm))
            {
                ListItem item = ListThm.Items.FindByValue(activeThm);//finds a list item that matches the active theme
                if (item != null)
                {
                    item.Selected = true;//sets list to match active theme
                }
            }
        }
        if (Session["username"] == null)
        {
            Label1.Visible = false;
            LinkButton2.Visible = true;
            LinkButton1.Visible = false;
        }
        else
        {
            Label1.Visible = true;
            LinkButton1.Visible = true;
            LinkButton2.Visible = false;
            Label1.Text = Session["username"].ToString();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("Login.aspx");
        
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void ListThm_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie thmCook = new HttpCookie("userThm");//cookie reference called thmCook created, cookie is called userThm
        thmCook.Expires = DateTime.Now.AddMonths(3);//cookie set to expire after 3 months
        thmCook.Value = ListThm.SelectedValue;
        Response.Cookies.Add(thmCook);//adds cookie
        Response.Redirect(Request.Url.ToString());//reloads current page
    }
}