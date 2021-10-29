using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace Test
{
    class ReadCamera
    {
        public Stream GetImage(string CamBaseUrl)
        {
            byte[] buffer = new byte[100000];
            // create HTTP request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(CamBaseUrl);
            // get response
            WebResponse resp = req.GetResponse();
            // get response stream
            return resp.GetResponseStream();
        }

        //string sourceURL = "http://192.168.1.225:1601/image/jpeg.cgi";
        //byte[] buffer = new byte[100000];
        //int read, total = 0;
        //// create HTTP request
        //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
        //// get response
        //WebResponse resp = req.GetResponse();
        //// get response stream
        //Stream stream = resp.GetResponseStream();

        //// read data from stream
        ////while ((read = stream.Read(buffer, total, 1000)) != 0)
        ////{
        ////    total += read;
        ////}
        ////// get bitmap
        ////Bitmap image = (Bitmap)Bitmap.FromStream(
        ////              new MemoryStream(buffer, 0, total));
    }
}
