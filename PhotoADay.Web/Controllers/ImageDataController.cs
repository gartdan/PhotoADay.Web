using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoADay.Web.Controllers
{
    public class ImageDataController : ApiController
    {
        public HttpResponseMessage Get(string fileName)
        {
            var path = Constants.FileUploadRootDir + "/" + User.Identity.Name + "/" + fileName;
            var absolutePath = System.Web.HttpContext.Current.Server.MapPath(path);
            if (!File.Exists(absolutePath)) {
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotFound };
            }
            var response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            response.Content = new StreamContent(File.OpenRead(absolutePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
            
            
        }
    }
}
