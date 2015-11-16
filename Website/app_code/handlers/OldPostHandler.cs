using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OldPostHandler
/// </summary>
public class OldPostHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        var oldUrl = context.Request.RawUrl;
        var oldPost = Storage.GetOldPost(oldUrl);

        if (oldPost == null)
        {
            throw new HttpException(404, "The post does not exist");
        }

        var newUrl = "/post/" + oldPost.Slug;
        context.Response.Status = "301 Moved Permanently";
        context.Response.AddHeader("Location", newUrl);
    }
}