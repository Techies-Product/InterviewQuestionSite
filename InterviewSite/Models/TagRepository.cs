using InterviewSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class TagRepository : ITagRepository
    {
        Database db;
        DataSet ds;

        public bool Save(int id, string Name, int CompanyOrCategoryId, bool IsCompany)
        {
            db = new Database();
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = db.MakeInParameter("@Id", SqlDbType.Int, 4, id);
            param[1] = db.MakeInParameter("@Name", SqlDbType.VarChar, 100, Name);
            param[2] = db.MakeInParameter("@CompanyOrCategoryId", SqlDbType.Int, 4, CompanyOrCategoryId);
            param[3] = db.MakeInParameter("@IsCompany", SqlDbType.Bit, 1, IsCompany);
            param[4] = db.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            bool Status = false;
            try
            {
                db.RunProcedure("InsertUpdateTags", param);
                Status = Convert.ToBoolean(param[4].Value.ToString());
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return Status;
        }
        public IEnumerable<TagList> GetTags(int PageNumber = 1, int PageSize = 20)
        {
            db = new Database();
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = db.MakeInParameter("@PageNumber", SqlDbType.Int, 4, PageNumber);
            param[1] = db.MakeInParameter("@PageSize", SqlDbType.Int, 4, PageSize);
            try
            {
                db.RunProcedure("GetTags", param,out ds);
                return ds.Tables[0].AsEnumerable()
                .Select(r => new TagList()
                {
                    Id = r.Field<int>("id"),
                    CompanyOrCategoryId = r.Field<int?>("CompanyOrCategoryId"),
                    CreatedDate = r.Field<DateTime>("CreatedDate"),
                    ModifiedDate = r.Field<DateTime>("ModifiedDate"),
                    IsCompany = r.Field<bool>("IsCompany"),
                    Name = r.Field<string>("Name"),
                    Total=r.Field<int>("Total")
                }).ToList();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return null;
        }

        private void ResetObject()
        {
            ds = null;
            db = null;
        }

        public List<string> SearchTags(string qry)
        {
            db = new Database();
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = db.MakeInParameter("@qry", SqlDbType.VarChar, 100, qry);
            try
            {
                db.RunProcedure("SearchTags", param, out ds);
                return ds.Tables[0].AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return null;
        }
    }
}