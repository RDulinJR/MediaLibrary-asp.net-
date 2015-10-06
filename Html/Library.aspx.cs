using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Html_About : System.Web.UI.Page
{
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

    }
}