using StudentApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Interface
{
    public interface IPO
    {
        List<PostDTO> GetllPost();
        string InsertPost(PostDTO o);
        string InserLike(string id);
        string InsertComment( CommnetDTO o);
    }
}
