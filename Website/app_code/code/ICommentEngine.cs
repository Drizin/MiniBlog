using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.WebPages;
using System.Xml.Linq;

/// <summary>
/// Interface that represents a comment engine
/// </summary>
public interface ICommentEngine
{
    /// <summary>
    /// Name of the comment engine
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Path to the comment section.
    /// Convention is: ~/views/commentengine/{name}/{name}.cshtml
    /// </summary>
    string CommentSectionPath { get; }

    /// <summary>
    /// Path to the comment count section.
    /// Convention is: ~/views/commentengine/{name}/commentcount.cshtml
    /// </summary>
    string CommentCountSectionPath { get; }

    /// <summary>
    /// Path to the global section
    /// Convention is: ~/views/commentengine/{name}/global.cshtml
    /// </summary>
    string GlobalSectionPath { get; }

    /// <summary>
    /// Method to render the comments section
    /// </summary>
    /// <param name="post">The current post</param>
    /// <param name="context">The context</param>
    /// <returns><see cref="HelperResult"/></returns>
    HelperResult RenderCommentSection(Post post, HttpContext context);

    /// <summary>
    /// Renders the comment count section
    /// </summary>
    /// <param name="post">The current post</param>
    /// <param name="context">The context</param>
    /// <returns><see cref="HelperResult"/></returns>
    HelperResult RenderCommentCountSection(Post post, HttpContext context);

    /// <summary>
    /// Renders the global section.  This section is put on every page before the closing body tag. 
    /// </summary>
    /// <param name="context">The context</param>
    /// <returns><see cref="HelperResult"/></returns>
    HelperResult RenderGlobalSection(HttpContext context);

    /// <summary>
    /// Gets settings related to the selected blog engine from the web.config and caches them.
    /// Convention: <add key="{name}:{key}" value="VALUE"/>
    /// </summary>
    /// <param name="key">Key to look for.  This key is concatenated with the comment engine name in the format: name:key</param>
    /// <returns>The setting vale</returns>
    string GetSetting(string key);

    /// <summary>
    /// Loads the comments and returns them
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    IEnumerable<Comment> LoadComments(XElement doc = null);

    /// <summary>
    /// Whether comments are open
    /// </summary>
    /// <param name="post"></param>
    /// <param name="contextBase"></param>
    /// <returns></returns>
    bool AreCommentsOpen(Post post, HttpContextBase contextBase);

    /// <summary>
    /// Counts the approved comments
    /// </summary>
    /// <param name="post"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    int CountApprovedComments(Post post, HttpContextBase context);
}