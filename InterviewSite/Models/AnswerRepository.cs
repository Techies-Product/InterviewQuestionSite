using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class AnswerRepository : IAnswerRepository
    {
        Database db;
        DataSet ds;

        public bool InsertAnswer(Answer a)
        {
            db = new Database();
            ds = new DataSet();
            bool returnVal = false;
            SqlParameter[] param = new SqlParameter[7];
            a.AnswerId=Guid.NewGuid() + DateTime.UtcNow.ToString("ddMMyyyyhhmmsstt");
            param[0] = db.MakeInParameter("@AnswerId", SqlDbType.VarChar, 50, a.AnswerId);
            param[1] = db.MakeInParameter("@AnswerDetail", SqlDbType.NText, -1, a.AnswerDetail);
            param[2] = db.MakeInParameter("@QuestionId", SqlDbType.VarChar, 50, a.QuestionId);
            param[3] = db.MakeInParameter("@IsActive", SqlDbType.VarChar, 500, true);
            param[4] = db.MakeInParameter("@IsDeleted", SqlDbType.VarChar, 50, false);
            param[5] = db.MakeInParameter("@UserId", SqlDbType.VarChar, 300, a.UserId);
            param[6] = db.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            try
            {
                db.RunProcedure("InsertAnswer", param);
                returnVal = Convert.ToBoolean((param[6].Value).ToString());
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