using Newtonsoft.Json;
using POServiceApi.DataAccess.Dapper;
using StudentApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.BO
{
    public class POBO : Interface.IPO
    {
        private IDapperHelper _dapper;

        public POBO(IDapperHelper dapper)
        {
            _dapper = dapper;
        }
        public List<PostDTO> GetllPost()
        {
            List<PostDTO> lst = new List<PostDTO>();

            try
            {
                _dapper.ClearParameter();
                _dapper.AddParameter("@Operation", "GetAllPost");
                lst = _dapper.GetDataList<PostDTO>("usp_post_operation", System.Data.CommandType.StoredProcedure);
                if (lst != null && lst.Count > 0)
                {
                    foreach (PostDTO o in lst)
                    {
                        if (o.strComments != "")
                        {
                            o.lstcmt = JsonConvert.DeserializeObject<List<CommnetDTO>>(o.strComments);
                        }
                        o.strComments = "";
                    }

                }
                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }
        public string InsertPost(PostDTO o)
        {
            string res = "-1";

            try
            {
                _dapper.ClearParameter();
                _dapper.AddParameter("@Operation", "InsertPost");
                _dapper.AddParameter("@text", o.text);
                _dapper.AddParameter("@ImageName", o.ImageName);
                res = _dapper.ExecuteNonQuery("usp_post_operation", System.Data.CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
        public string InserLike(string id)
        {
            string res = "-1";

            try
            {
                _dapper.ClearParameter();
                _dapper.AddParameter("@Operation", "UpdateLike");
                _dapper.AddParameter("@Id", id);
                res = _dapper.ExecuteNonQuery("usp_post_operation", System.Data.CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
        public string InsertComment(CommnetDTO o)
        {
            string res = "-1";

            try
            {
                _dapper.ClearParameter();
                _dapper.AddParameter("@Operation", "InsertComment");
                _dapper.AddParameter("@Id", o.pid);
                _dapper.AddParameter("@text", o.Comments);
                res = _dapper.ExecuteNonQuery("usp_post_operation", System.Data.CommandType.StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
    }
}
