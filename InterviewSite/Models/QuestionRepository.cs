using InterviewSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace InterviewSite.Models
{
    public class QuestionRepository : IQuestionRepository
    {
        Database db;
        DataSet ds;
        public bool CreateQuestion(Question q)
        {
            db = new Database();
            ds = new DataSet();
            bool returnVal = false;
            SqlParameter[] param = new SqlParameter[7];
            string[] guid = Guid.NewGuid().ToString().Split('-');
            string uqn = Regex.Replace(q.QuestionTitle, @"[^0-9a-zA-Z- ]+", "");
            q.UniqueQuestionName = uqn.Replace(' ', '-');
            q.QuestionId = guid[guid.Length - 1] + DateTime.UtcNow.ToString("ddMMyyyyhhmmsstt");
            param[0] = db.MakeInParameter("@QuestionId", SqlDbType.VarChar, 50, q.QuestionId);
            param[1] = db.MakeInParameter("@QuestionTitle", SqlDbType.NVarChar, 300, q.QuestionTitle);
            param[2] = db.MakeInParameter("@QuestionDetail", SqlDbType.NText, -1, q.QuestionDetail);
            param[3] = db.MakeInParameter("@Tags", SqlDbType.VarChar, 500, q.Tags);
            param[4] = db.MakeInParameter("@UserId", SqlDbType.VarChar, 50, q.UserId);
            param[6] = db.MakeInParameter("@UniqueQuestionName", SqlDbType.VarChar, 300, q.UniqueQuestionName.Trim());
            param[5] = db.MakeOutParameter("@Result", SqlDbType.Bit, 1);
            try
            {
                db.RunProcedure("CreateQuestion", param);
                returnVal = Convert.ToBoolean((param[5].Value).ToString());
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return returnVal;
        }

        public List<RecentQuestion> GetRecentQuestions(int PageNumber=1, int PageSize=30)
        {
            db = new Database();
            ds = new DataSet();
            List<RecentQuestion> lstQuestion = new List<RecentQuestion>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = db.MakeInParameter("@PageNumber", SqlDbType.Int, 4, PageNumber);
                param[1] = db.MakeInParameter("@PageSize", SqlDbType.Int, 4, PageSize);
                db.RunProcedure("GetRecentQuestions", param, out ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstQuestion.Add(new RecentQuestion
                    {
                        QuestionTitle = dr["QuestionTitle"].ToString(),
                        DateTimeShow = dr["DateTimeShow"].ToString(),
                        UserUniqueName = dr["User_Unique_Name"].ToString(),
                        AuthorName = dr["Name"].ToString(),
                        Total = Convert.ToInt32(dr["Total"].ToString())
                    });
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return lstQuestion;
        }

        private void ResetObject()
        {
            ds = null;
            db = null;
        }
    }
}