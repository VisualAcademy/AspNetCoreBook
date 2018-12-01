using System.Collections.Generic;
using Hawaso.Standard;

namespace All
{
    public interface ICongressCommentRespository
    {
        void AddComment(ArticleCommentBase model);
        int DeleteComment(int articleId, int id, string password);
        List<ArticleCommentBase> GetComments(int articleId);
        int GetCountBy(int articleId, int id, string password);
        List<ArticleCommentBase> GetRecentComments();
    }
}