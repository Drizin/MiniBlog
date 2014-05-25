using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Linq;
using System.Linq;

public class InBuiltCommentEngine : CommentEngineBase
{
    /// <summary>
    /// Name of the comment engine
    /// </summary>
    public override string Name
    {
        get { return "inbuilt"; }
    }

    /// <summary>
    /// Loads the comments and returns them
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    public override IEnumerable<Comment> LoadComments(XElement doc = null)
    {
        return Storage.LoadComments(doc);
    }

    /// <summary>
    /// Whether comments are open
    /// </summary>
    /// <param name="post"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override bool AreCommentsOpen(Post post, HttpContextBase context)
    {
        return post.PubDate > DateTime.UtcNow.AddDays(-Blog.DaysToComment) || context.User.Identity.IsAuthenticated;
    }

    /// <summary>
    /// Counts the approved comments
    /// </summary>
    /// <param name="post"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override int CountApprovedComments(Post post, HttpContextBase context)
    {
        return (Blog.ModerateComments && !context.User.Identity.IsAuthenticated) ? post.Comments.Count(c => c.IsApproved) : post.Comments.Count;
    }
}