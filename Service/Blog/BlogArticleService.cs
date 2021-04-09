﻿using DbLogic;
using DbLogic.Blog;
using Microsoft.AspNetCore.Hosting;
using Model;
using Model.Blog;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IBlogDAL _blogDAL;

        public BlogArticleService(IBlogDAL blogDAL,
            IHostingEnvironment hostingEnvironment)
        {
            _blogDAL = blogDAL;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 取得文章細節
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleModel GetArticleDetail(int id)
        {
            var blogArtical = _blogDAL.GetFirstArticle(id);

            return new ArticleModel
            {
                Title = blogArtical.Title,
                CreateTime = blogArtical.CreateTime.ToString("yyyy/MM/dd"),
                MdContent = File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, blogArtical.FilePath))
            };
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<BlogArticle> GetArticleList(int page, int pageSize)
        {
            var result = _blogDAL.GetArticleList(page, pageSize).ToList();
            return result;
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
            var result = _blogDAL.GetArticleList(type, page, pageSize).ToList();
            return result;
        }

        /// <summary>
        /// 同步md資料進sqlite
        /// </summary>
        public void SynchronizeArticle()
        {
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var dirPath = Path.Combine(contentRootPath, "AppData");
            var allFiles = GetAllFiles(dirPath).Where(x => Path.GetExtension(x) == ".md");

            var allDbArticals = _blogDAL.GetAllArticleList().ToList();

            foreach (var filePath in allFiles)
            {
                var title = Path.GetFileNameWithoutExtension(filePath);
                if (title.StartsWith("#"))
                    title = title.Substring(1, title.Length - 1).Trim();

                if (allDbArticals.Any(x => x.Title == title))
                    continue;

                var relativePath = filePath.Replace(contentRootPath, "").TrimStart('\\');
                var pathSplit = relativePath.Split('\\');
                _blogDAL.InsertArticle(new BlogArticle
                {
                    Title = title,
                    Type = pathSplit[1],
                    FilePath = relativePath,
                    CreateTime = new DateTime(Convert.ToInt32(pathSplit[2]), Convert.ToInt32(pathSplit[3]), Convert.ToInt32(pathSplit[4])),
                    IsShow = true
                });
            }
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
