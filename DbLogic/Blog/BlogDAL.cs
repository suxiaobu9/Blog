using Model;
using System.Collections.Generic;

namespace DbLogic.Blog
{
    public class BlogDAL : IBlogDAL
    {
        public BlogDAL(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        private readonly IDataAccess _dataAccess;


        /// <summary>
        /// 取得文章細節
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogArticle GetFirstArticle(int id)
        {
            var sql = @"select * from BlogArticle 
                        where Id = @id";
            var parameter = new Dictionary<string, object>
            {
                { "Id", id }
            };

            var result = _dataAccess.QueryFrist<BlogArticle>(sql, parameter);
            return result;
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BlogArticle> GetArticleList(int page, int pageSize)
        {
            var sql = @"select * from BlogArticle 
                        where IsShow = 1
                        order by Id
                        offset @page rows
                        fetch next @pageSize rows only";
            var parameter = new Dictionary<string, object>
            {
                { "page",page},
                { "pageSize",pageSize}
            };
            var result = _dataAccess.Query<BlogArticle>(sql, parameter);
            return result;
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BlogArticle> GetArticleList(ArticleType type, int page, int pageSize)
        {
            var sql = @"select * from BlogArticle 
                        where IsShow = 1
                            and Type = @type
                        order by Id
                        offset @page rows
                        fetch next @pageSize rows only";
            var parameter = new Dictionary<string, object>
            {
                { "type",type.ToString()},
                { "page",page},
                { "pageSize",pageSize}
            };

            var result = _dataAccess.Query<BlogArticle>(sql, parameter);
            return result;
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        public void InsertArticle(BlogArticle model)
        {
            var sql = @"INSERT INTO [dbo].[BlogArticle]
                             ([Title]
                             ,[FilePath]
                             ,[Type]
                             ,[CreateTime]
                             ,[IsShow])
                       VALUES
                             (@Title
                             ,@FilePath
                             ,@Type
                             ,@CreateTime
                             ,1)";
            var parameter = new Dictionary<string, object>
            {
                { "Title",model.Title},
                { "FilePath",model.FilePath},
                { "Type",model.Type},
                { "CreateTime",_dataAccess.GetDbTime()}
            };

            _dataAccess.Excute(sql, parameter);
        }
    }
}
