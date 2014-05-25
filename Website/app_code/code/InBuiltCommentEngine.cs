public class InBuiltCommentEngine : CommentEngineBase
{
    public override string Name
    {
        get { return "inbuilt"; }
    }

    public override string CommentUriHash
    {
        get { return "comments"; }
    }

}