using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing;




namespace Test
{
    class Pushover
    {
        public async Task PushImage(string message, Stream image)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                //specify to use TLS 1.2 as default connection
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(Constants.PushApplicationToken), "\"token\"");
                form.Add(new StringContent(Constants.PushUserKey), "\"user\"");
                form.Add(new StringContent(message), "\"message\"");
                var imageParameter = new StreamContent(image);
                imageParameter.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                form.Add(imageParameter, "\"attachment\"", "\"image.jpeg\"");
                
                // Remove content type that is not in the docs
                foreach (var param in form)
                    param.Headers.ContentType = null;

                HttpResponseMessage responseMessage = await httpClient.PostAsync(Constants.BaseApiUrl, form);
                if (responseMessage.IsSuccessStatusCode)
                    return;

                Console.WriteLine(responseMessage);
              
                //throw new ApplicationException(
                // $"Push image request failed with status {(int)responseMessage.StatusCode} {responseMessage.StatusCode}: {response.Errors.JoinStrings(". ") ?? ""}");
            }
        }

    }
}

        