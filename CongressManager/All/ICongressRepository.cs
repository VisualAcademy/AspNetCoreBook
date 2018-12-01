using System.Collections.Generic;
using Hawaso.Standard;

namespace All
{
    public interface ICongressRepository
    {
        void Add(ArticleBase vm);
        int DeleteNote(int id, string password);
        List<ArticleBase> GetAll(int pageIndex);
        List<ArticleBase> GetAll(int pageIndex, int pageSize = 10);
        List<ArticleBase> GetSummaryByCategory(string category);
        int GetCountAll();
        int GetCountBySearch(string searchField, string searchQuery);
        string GetFileNameById(int id);
        List<ArticleBase> GetNewPhotos();
        ArticleBase GetNoteById(int id);
        List<ArticleBase> GetRecentPosts();
        List<ArticleBase> GetRecentPosts(int numberOfCongresses);
        List<ArticleBase> GetSeachAll(int pageIndex, string searchField, string searchQuery);
        void Pinned(int id);
        void ReplyNote(ArticleBase vm);
        int SaveOrUpdate(ArticleBase n, BoardWriteFormType formType);
        void UpdateDownCount(string fileName);
        void UpdateDownCountById(int id);
        int UpdateNote(ArticleBase vm);
    }
}