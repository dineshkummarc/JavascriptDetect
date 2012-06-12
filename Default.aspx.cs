using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSDetect
{
    public partial class _Default : System.Web.UI.Page
    {
        bool jsEnabled = false;//run anuder initial assumption that JS is disabled

        protected void Page_Load(object sender, EventArgs e)
        {
            jsEnabled = IsJavascriptActive();

            Response.Write("Javascript running in browser: " + jsEnabled);
        }
        /// <summary>
        /// Detects whether or not the browser has javascript enabled
        /// </summary>
        /// <returns>boolean indicating if javascript is active on the client browser</returns>
        public static bool IsJavascriptActive()
        {
            bool active = false;
            HttpContext context = HttpContext.Current;
            if (!context.Request.Browser.Crawler)
            {
                if (context.Session["jsActive"] == null)
                {
                    context.Response.Redirect(ClientDomainName() + "/JSDetect.aspx?url=" + context.Request.Url.AbsoluteUri.ToString() + " ", true);
                }
                else
                {
                    if (context.Session["jsActive"].ToString().Equals("0"))
                    {
                        active = false;
                    }
                    else if (context.Session["jsActive"].ToString().Equals("1"))
                    {
                        active = true;
                    }
                }
            }
            return active;
        }
        /// <summary>
        /// Get the Domain name and port of the current URL
        /// </summary>
        /// <returns>Domain name and port</returns>
        public static string ClientDomainName()
        {
            string domainNameAndPort = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.Length - HttpContext.Current.Request.Url.PathAndQuery.Length);
            return domainNameAndPort;
        }
    }
}
