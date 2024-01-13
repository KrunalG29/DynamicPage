using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kogs;
using infinity;
namespace iipl.erph
{
    public partial class test : System.Web.UI.Page
    {
        public static string txt_constringText = "workstation id=kuldipierp.mssql.somee.com;packet size=4096;user id=KuldipGajjar_SQLLogin_1;pwd=yjh792dcxd;data source=kuldipierp.mssql.somee.com;persist security info=False;initial catalog=kuldipierp";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Int32 ABC = KOGS.ToInt32("5666KKF");
            //Int32 A = 0,B = 0,C = 0,D = 0,E = 0,F = 0,G = 0;
            //try { A = KOGS.ToInt32(10000000000000000000); } catch { A = 0; }
            //try { B = KOGS.ToInt32(0); } catch { B = 0; }
            //try { C = KOGS.ToInt32("600"); } catch { C = 0; }
            //try { D = KOGS.ToInt32("100FG"); } catch { D = 0; }
            //try { E = KOGS.ToInt32(null); } catch { E = 0; }
            //try { F = KOGS.ToInt32(200); } catch { F = 0; }
            //try { G = KOGS.ToInt32(-20); } catch { G = 0; }
            //if (!IsPostBack)
            //{
            //    //FileCreate();
            //}
        }

        #region FileCreate
        public void FileCreate()
        {
            string readText = File.ReadAllText(Server.MapPath("~/filename.sql"));

            string[] stringSeparators = new string[] { @"/****** Object:  StoredProcedure" };
            string[] Array = readText.Split(stringSeparators, StringSplitOptions.None);

            int arry_len = Array.Length;
            int count = 0;
            String file = "";
            foreach (String arr in Array)
            {
                if (count % 90 == 0 && count != 0)
                {
                    StreamWriter sw = null;
                    String SaveFilePath = Server.MapPath("~/Upload_v2/Nothing/") + "\\" + count + ".sql";
                    FileStream fsSave = File.Create(SaveFilePath);
                    sw = new StreamWriter(fsSave);
                    sw.Write(file);
                    sw.Close();
                    sw.Dispose();
                    file = "";
                }
                file = file + "\n" + "/****** Object:  StoredProcedure" + arr;
                count++;
            }
        }
        #endregion
    }
}