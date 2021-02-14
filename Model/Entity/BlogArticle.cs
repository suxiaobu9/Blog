using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BlogArticle
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FilePath { get; set; }

        public string Type { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsShow { get; set; }
    }
}
