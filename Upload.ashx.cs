using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iipl.erph
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            uploads.SaveAs(context.Server.MapPath(".") + "\\ckeditor\\" + file);
            //provide direct URL here
            string url = HttpContext.Current.Session["base_url"] + "\\ckeditor\\" + file;

            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            context.Response.End();
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }

}