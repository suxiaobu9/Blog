using DbLogic;
using Microsoft.AspNetCore.Hosting;
using Model;
using Service.Blog.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.Blog
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BlogArticleService(BlogDbContext blogDbContext,
            IHostingEnvironment hostingEnvironment)
        {
            _blogDbContext = blogDbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 取得文章細節
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetArticleDetail(int id)
        {
            var blogArtical = _blogDbContext.BlogArticles.FirstOrDefault(x => x.Id == id);

            return File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, blogArtical.FilePath));
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<BlogArticle> GetArticleList(int page, int pageSize)
        {
            return _blogDbContext.BlogArticles
                    .Where(x=>x.IsShow)
                    .OrderByDescending(x => x.CreateTime)
                    .Paging(page, pageSize)
                    .ToList();
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<BlogArticle> GetArticleList(ArticleType type, int page, int pageSize)
        {
            return _blogDbContext.BlogArticles
                    .Where(x => x.Type == type.ToString())
                    .OrderByDescending(x => x.CreateTime)
                    .Paging(page, pageSize)
                    .ToList();
        }

        /// <summary>
        /// 同步md資料進sqlite
        /// </summary>
        public void SynchronizeArticle()
        {
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var dirPath = Path.Combine(contentRootPath, "AppData");
            var allFiles = GetAllFiles(dirPath);

            var allDbArticals = _blogDbContext.BlogArticles.ToList();

            foreach (var filePath in allFiles)
            {
                var title = Path.GetFileNameWithoutExtension(filePath);
                if (title.StartsWith("#"))
                    title = title.Substring(1, title.Length - 1).Trim();

                if (allDbArticals.Any(x => x.Title == title))
                    continue;

                var relativePath = filePath.Replace(contentRootPath, "").TrimStart('\\');
                var pathSplit = relativePath.Split('\\');
                _blogDbContext.BlogArticles.Add(new BlogArticle
                {
                    Title = title,
                    Type = pathSplit[1],
                    FilePath = relativePath,
                    CreateTime = new DateTime(Convert.ToInt32(pathSplit[2]), Convert.ToInt32(pathSplit[3]), Convert.ToInt32(pathSplit[4])),
                    IsShow = true
                });
            }

            _blogDbContext.SaveChanges();

        }

        /// <summary>
        /// 取得資料夾下所有檔案檔案(包含其他資料夾下)
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private List<string> GetAllFiles(string dirPath)
        {
            var allFiles = Directory.GetFiles(dirPath).ToList();

            var dirs = Directory.GetDirectories(dirPath);

            foreach (var item in dirs)
            {
                allFiles.AddRange(GetAllFiles(item));
            }
            return allFiles;
        }

    }

    public static class IEnumerableExtension
    {
        /// <summary>
        /// 分頁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> Paging<T>(this IQueryable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
