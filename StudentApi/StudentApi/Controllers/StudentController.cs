using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.DTO;
using StudentApi.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IPO _ipo;
        private IHostingEnvironment _env;
        public StudentController(IPO ipo, IHostingEnvironment env)
        {
            _ipo = ipo;
            _env = env;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return new Student[] {
                new Student() { RollNumber=1,Name= "Parimal",IQ=10},
                new Student() { RollNumber=2,Name= "Dhaval",IQ=20},
                new Student() { RollNumber=3,Name= "Amish",IQ=30}
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<Student> Get(int id)
        {
            return GetAll().Where(x => x.RollNumber == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IEnumerable<Student> UpdateStudent(int id, [FromBody] string value)
        {
            Student s = GetAll().Where(x => x.RollNumber == id).FirstOrDefault();
            if (s != null)
            {
            }
            return GetAll();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Student> DeleteStudent(int id)
        {
            return GetAll();
        }


        [HttpGet]
        [Route("GetllPost")]
        public List<PostDTO> GetllPost()
        {
            List<PostDTO> lst = new List<PostDTO>();
            lst = _ipo.GetllPost();
            return lst;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("InsertPost")]
        public string InsertPost()
        {
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrWhiteSpace(_env.WebRootPath))
            {
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var PathWithFolderName = System.IO.Path.Combine(webRoot, "postimage");
            PostDTO o = new PostDTO();
            o.text = Convert.ToString(Request.Form["text"]);
            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                o.ImageName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string uploadsFolder = Path.Combine(webRoot, "postimage");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + o.ImageName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                o.ImageName = uniqueFileName;
            }
            string res = _ipo.InsertPost(o);
            return res;
        }
        [HttpPost]
        [Route("InsertComment")]
        public string InsertComment([FromBody] CommnetDTO o)
        {
            string res = _ipo.InsertComment(o);
            return res;
        }
        [HttpPost]
        [Route("InserLike")]
        public string InserLike(string id)
        {
            string res = _ipo.InserLike(id);
            return res;
        }
    }
}
