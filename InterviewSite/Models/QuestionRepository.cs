using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            SqlParameter[] param = new SqlParameter[6];
            string[] guid=Guid.NewGuid().ToString().Split('-');
            q.QuestionId = guid[guid.Length - 1] + DateTime.UtcNow.ToString("ddMMyyyyhhmmsstt");
            param[0] = db.MakeInParameter("@QuestionId",SqlDbType.VarChar, 50, q.QuestionId);
            param[1] = db.MakeInParameter("@QuestionTitle", SqlDbType.NVarChar, 300, q.QuestionTitle);
            param[2] = db.MakeInParameter("@QuestionDetail", SqlDbType.NText, -1, q.QuestionDetail);
            param[3] = db.MakeInParameter("@Tags", SqlDbType.VarChar, 500, q.Tags);
            param[4] = db.MakeInParameter("@UserId", SqlDbType.VarChar, 50, q.UserId);
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

        private void ResetObject()
        {
            ds = null;
            db = null;
        }
    }
}