using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cateno.CMS.Plugins.ImageResize;

namespace CTS.W._150501.Web
{
    /// <summary>
    /// Summary description for ImageResize
    /// </summary>
    public class ImageResize : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var photo = new Photo();
            photo.ProcessRequest(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}