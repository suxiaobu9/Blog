﻿using DbLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Blog.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogArticleService _blogArticleService;
        public BlogController(IBlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
        }

        /// <summary>
        /// 取得文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetArticleList")]
        public ActionResult Get(int page, int pageSize)
        {
            var result = _blogArticleService.GetArticleList(page, pageSize)
                            .Select(x => new
                            {
                                x.Id,
                                x.Title,
                                CreateTime = x.CreateTime.ToString("yyyy/MM/dd")
                            });
            return Ok(result);
        }

        /// <summary>
        /// 取得文章html內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetArticle")]
        public ActionResult Get(int id)
        {
            return Ok(_blogArticleService.GetArticleDetail(id));
        }

        /// <summary>
        /// 同步資料進sqlite
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put()
        {
            _blogArticleService.SynchronizeArticle();
            return Ok();
        }
    }
}
