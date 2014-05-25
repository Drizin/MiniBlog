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
    private readonly Uri _uri;

    public CommentCount(int count, Uri uri)
    {
        _count = count;
        _uri = uri;
    }

    public int Count
    {
        get { return _count; }
    }

    public Uri Uri
    {
        get { return _uri; }
    }
}