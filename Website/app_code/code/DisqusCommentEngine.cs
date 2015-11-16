using System.Web.WebPages;

public class DisqusCommentEngine : CommentEngineBase
{
    public override string Name
    {
        get { return "Disqus"; }
    }

}