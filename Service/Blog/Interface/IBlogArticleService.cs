using Model;
using Model.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Blog.Interface
{
    public interface IBlogArticleService
    {
        /// <summary>
        /// 取得文章html內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleModel GetArticleDetail(int id);

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<BlogArticle> GetArticleList(int page, int pageSize);

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<BlogArticle> GetArticleList(ArticleType type, int page, int pageSize);

        /// <summary>
        /// 同步資料進sqlite
        /// </summary>
        public void SynchronizeArticle();
    }
}
