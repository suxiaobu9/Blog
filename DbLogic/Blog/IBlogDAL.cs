using Model;
using System.Collections.Generic;

namespace DbLogic.Blog
{
    public interface IBlogDAL
    {
        /// <summary>
        /// 取得文章細節
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogArticle GetFirstArticle(int id);

        /// <summary>
        /// 取得所有文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogArticle> GetAllArticleList();

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BlogArticle> GetArticleList(int page, int pageSize);

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BlogArticle> GetArticleList(ArticleType type, int page, int pageSize);

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        public void InsertArticle(BlogArticle model);
    }
}
