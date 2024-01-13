using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace iipl.erph
{
    public partial class T07_DOWNLOAD_FILES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imageUrl = "https://cyberfiction.io/images/CF-Avatar-01.png";
            foreach (string filename in Directory.GetFiles(@""+ imageUrl + "", "*.*"))
            {
                Console.WriteLine(filename);
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }
    }
}