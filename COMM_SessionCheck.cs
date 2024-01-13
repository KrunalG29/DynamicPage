
using System;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Web;
using infinity;
/// <summary>
/// This is a custom "base page" to inherit from which will be used
/// to check the session status. If the session has expired or is a timeout
/// we will redirect the user to the page we specify. In the page you use
/// to inherit this from you need to set EnableSessionState = True
/// </summary>
public class COMM_SessionCheck : System.Web.UI.Page
{
    /// <summary>
    /// property vcariable for the URL Property
    /// </summary>
    private static string _redirectUrl;

    /// <summary>
    /// property to hold the redirect url we will
    /// use if the users session is expired or has
    /// timed out.
    /// </summary>
    public static string RedirectUrl
    {
        get { return _redirectUrl; }
        set { _redirectUrl = value; }
    }

    public COMM_SessionCheck()
    {
        _redirectUrl = string.Empty;
    }
    /// <summary>
    /// this is the override preInit event in this event we check that user s valid or not 
    /// if user is not valid or it is loged oout then we reirect user to the index page for relogin
    /// with crent page as redirecturl so if login successfully then system direct redirect on redirecturl
    /// here we also check config that if system is under maintanace then user can't work
    /// </summary>
    /// <param name="e"></param>
    override protected void OnInit(EventArgs e)
    {
        string IPAddress = ConfigurationManager.AppSettings["AccessIpAddress"].ToString();
        string AccessNotCheck = ConfigurationManager.AppSettings["AccessNotCheck"].ToString();
        string ClientIPAddress = db_my_functions.GetIp();
        if (("," + IPAddress + ",").Contains(("," + ClientIPAddress + ",")))
        {

        }
        else if (AccessNotCheck == "1")
        {

        }
        else
        {
            Response.Redirect("access_denied.aspx");
        }
    }
}
