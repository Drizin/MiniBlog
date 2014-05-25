using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentCount
/// </summary>
public class CommentCount
{
    private readonly int _count;
    private readonly Uri _url;

    public CommentCount(int count, Uri url)
    {
        _count = count;
        _url = url;
    }

    public int Count
    {
        get { return _count; }
    }

    public Uri PostUri
    {
        get { return _url; }
    }
}