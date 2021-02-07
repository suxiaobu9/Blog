using DbLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
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

        public BlogController()
        {
        }

        [HttpGet]
        public IEnumerable<BlogArticle> Get()
        {
            return null;
        }
    }
}
