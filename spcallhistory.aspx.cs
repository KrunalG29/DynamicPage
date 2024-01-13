using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iipl.erph
{
    public partial class spcallhistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            lbloutput.Text = str();
            if (chk.Checked == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "copyText();", true);
            }
        }
        public string str()
        {
            string query = "";
            string SP_name = "";

            try
            {
                if (TextBox1.Text.Trim() != "")
                {
                    query += @"INSERT INTO Log_SPCallHistory(SP_Name, SP_Para,CreateDate) 
VALUES(";
                    string[] qu = TextBox1.Text.Split('@');
                    for (int i = 0; i < qu.Length; i++)
                    {
                        if (i == 0)//
                        {

                            SP_name = (@"'" + qu[i].ToUpper().Replace("ALTER PROCEDURE [DBO].[", "").Replace("]", "").Replace("\r\n", "").Replace(" ", "").Replace("(", "")).Trim() + "'";

                            query += @"'" + qu[i].ToUpper().Replace("ALTER PROCEDURE [DBO].[", "").Replace("]", "").Replace("\r\n", "").Replace(" ", "");
                            query += "',";
                        }
                        else
                        {
                            string[] spech = qu[i].ToString().Split(' ');
                            if (spech.Length > 0)
                            {
                                if (spech[1].ToString().ToLower().Contains("datetime"))
                                {
                                    query += Environment.NewLine + "'['+isnull(CAST(CONVERT(DATE, @" + (spech[0].ToString()).Trim() + @") AS VARCHAR),'')+'],'+";
                                }
                                else
                                {
                                    query += Environment.NewLine + "'['+isnull(CAST(@" + (spech[0].ToString()).Trim() + @" AS VARCHAR),'')+'],'+";
                                }
                            }
                        }
                    }
                    query = query.Substring(0, query.Length - 3) + "',";
                    query += "\nCONVERT(VARCHAR(23), GETDATE(), 121))";

                    query += "\n\n --select top 10 * from Log_SPCallHistory with (nolock) where sp_name =" + SP_name + " order by id desc";
                }
            }
            catch
            {
            }
            return query;
        }
    }
}