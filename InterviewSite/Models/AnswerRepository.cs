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
        /// <summary>
        /// This function is used to upvote and downvote for the answers
        /// 0 means error 
        /// 1 means success 
        /// -1 means undo success
        /// </summary>
        /// <param name="answerId"></param>
        /// <param name="IsUpvote">1. UpVote, 0. DownVote, -1. UndoVote</param>
        /// <returns></returns>
        public int UpvoteDownvote(string answerId, bool IsUpvote,string UserId)
        {
            db = new Database();
            ds = new DataSet();
            int returnVal = 0;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = db.MakeInParameter("@AnswerId",SqlDbType.VarChar,50,answerId);
            param[1] = db.MakeInParameter("@UserId", SqlDbType.VarChar,50,UserId);
            param[2] = db.MakeInParameter("@VoteUpDown", SqlDbType.Bit,1,IsUpvote);
            param[3] = db.MakeOutParameter("@Result", SqlDbType.Int,4);
            try
            {
                db.RunProcedure("UpAndDownVote", param);
                returnVal = Convert.ToInt32((param[3].Value).ToString());
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