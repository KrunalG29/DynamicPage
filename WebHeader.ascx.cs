using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iipl.erph
{
    public partial class WebHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateDynamicPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("form_dynamic_page.aspx");
        }

        protected void btnCreateFunction_Click(object sender, EventArgs e)
        {
            Response.Redirect("form_dynamic_page_v2.aspx");
        }

        protected void btnCreateDynamicPageURP_Click(object sender, EventArgs e)
        {
            Response.Redirect("form_dynamic_page_urp.aspx");
        }

        protected void btnT10_LinQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("T10_LinQ.aspx");
        }

        protected void btnFileSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("form_download_file.aspx");
        }

        protected void btnCallHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("spcallhistory.aspx");
        }
    }
}