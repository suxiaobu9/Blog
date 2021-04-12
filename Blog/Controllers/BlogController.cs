using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Blog;
using Service.Blog.Interface;
using System.Linq;

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
        public IActionResult Get(ArticleType type, int page, int pageSize)
        {
            var result = (type == ArticleType.All ?
                        _blogArticleService.GetArticleList(page, pageSize) :
                        _blogArticleService.GetArticleList(type, page, pageSize))
                            .Select(x => new SimpleArticleModel
                            {
                                Id = x.Id,
                                Title = x.Title,
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
        public IActionResult Get(int id)
        {

            return Ok(_blogArticleService.GetArticleDetail(id));
        }

        /// <summary>
        /// 取得圖片
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        [HttpGet("GetImage")]
        public IActionResult Get(string imagePath)
        {
            var image = _blogArticleService.GetImage(imagePath);
            return File(image, "image/jpeg");
        }

        /// <summary>
        /// 同步資料進sqlite
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put()
        {
            _blogArticleService.SynchronizeArticle();
            return Ok();
        }
    }
}
