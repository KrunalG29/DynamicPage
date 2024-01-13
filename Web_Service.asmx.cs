using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using infinity;

namespace iipl.erph
{
    /// <summary>
    /// Summary description for Web_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Web_Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region function:get_tbl_name1
        [WebMethod(EnableSession = true)]
        public string[] get_tbl_name1(string prefixText, int count, string contextKey)
        {
            //return all records whose Title starts with the prefix input string 

            List<string> titleArList = new List<string>();
            string[] arr = contextKey.Split('$');
            String projectName = "";
            String liveConStr = "";
            if (arr.Length > 0)
            {
                projectName = Handle.ToString(arr[0]);
                liveConStr = Handle.ToString(arr[1]);
            }
            DataTable dt = db_dynamic_page.GetAllTables1(liveConStr, prefixText);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string strTemp = Convert.ToString(dt.Rows[i]["name"].ToString());
                    string strid = dt.Rows[i]["name"].ToString();
                    //  titleArList.Add(strTemp);
                    titleArList.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(strTemp, strid));
                }
            }
            dt.Dispose();
            return titleArList.ToArray();
        }
        #endregion

        #region function:get_all_task
        [WebMethod(EnableSession = true)]
        public string[] get_all_task(string prefixText, int count, string contextKey)
        {
            //return all records whose Title starts with the prefix input string 
            List<string> titleArList = new List<string>();
            DataTable dt = db_iERP_task_log.Get_iERP_task_log_select();
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string strTemp = Convert.ToString(dt.Rows[i]["task_id"].ToString());
                    string strid = dt.Rows[i]["id"].ToString();
                    //  titleArList.Add(strTemp);
                    titleArList.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(strTemp, strid));
                }
            }
            dt.Dispose();
            return titleArList.ToArray();
        }
        #endregion


        #region function:get_all_task
        [WebMethod(EnableSession = true)]
        public string[] get_comp(string prefixText, int count, string contextKey)
        {
            //return all records whose Title starts with the prefix input string 
            List<string> titleArList = new List<string>();
            DataTable dt = db_iERP_task_log.Get_iERP_task_log_select_comp();
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string strTemp = Convert.ToString(dt.Rows[i]["task_comp"].ToString());
                    string strid = dt.Rows[i]["task_comp"].ToString();
                    //  titleArList.Add(strTemp);
                    titleArList.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(strTemp, strid));
                }
            }
            dt.Dispose();
            return titleArList.ToArray();
        }
        #endregion
    }
}
