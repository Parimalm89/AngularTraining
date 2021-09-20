using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.DTO
{
    public class PostDTO
    {
        public long ID { get; set; }
        public string text   { get; set; }
        public string ImageName { get; set; }
        public int likes  { get; set; }
        public string Comments { get; set; }
        public string PostDateTime { get; set; }
        public string strComments { get; set; }
        public int LikeCount { get; set; }
        public int commentsCount { get; set; }
        public List<CommnetDTO> lstcmt { get; set; }
    }
    public class likesDTO
    {
        public long ID { get; set; }
        public long pid { get; set; }                
        public string LiketDateTime { get; set; }
    }
    public class CommnetDTO
    {
        public long ID { get; set; }
        public long pid { get; set; }
        public string text { get; set; }
        public string Comments { get; set; }
        public string PostDateTime { get; set; }
    }
}
