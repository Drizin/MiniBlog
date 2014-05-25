using System.Web.WebPages;

public class DisqusCommentEngine : CommentEngineBase
{
    public override string Name
    {
        get { return "Disqus"; }
    }

    public override string CommentUriHash
    {
        get { return "disqus_thread"; }
    }

}