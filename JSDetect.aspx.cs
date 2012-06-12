using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace JSDetect
{
    public partial class JSDetect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Session["jsActive"] = 0;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JSDetect", "PageMethods.SetJSEnabled();", true);
            refreshCommand.Content = "2; url=" + Request.QueryString["url"].ToString();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static void SetJSEnabled()
        {

            HttpContext.Current.Session["jsActive"] = 1;
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.QueryString["url"].ToString());
        }
    }
}
