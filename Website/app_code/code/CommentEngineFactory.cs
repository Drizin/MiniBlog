using System;
using System.Reflection;

public class CommentEngineFactory
{
    public static ICommentEngine Create(string engineType)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var t in a.GetTypes())
            {
                if (t.IsSubclassOf(typeof(CommentEngineBase)))
                {
                    if (t.Name.Equals(engineType, StringComparison.InvariantCultureIgnoreCase) 
                        || t.Name.Equals(engineType + "CommentEngine", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return (ICommentEngine)Activator.CreateInstance(t);
                    }
                }
            }
        }
        throw new Exception("Unable to locate comment engine");
    }
}