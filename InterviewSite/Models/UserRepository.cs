using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class UserRepository : IUserRepository
    {
        Database db;
        DataSet ds;
        public IEnumerable<User> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string GetUserId(string Email)
        {
            db = new Database();
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = db.MakeInParameter("@Email", SqlDbType.VarChar, 100, Email);
            string UserId=null;
            try
            {
                db.RunProcedure("GetUserId", param, out ds);
                if (!object.Equals(ds, null))
                {
                    if (!object.Equals(ds.Tables, null))
                    {
                        if (ds.Tables.Count > 0)
                        {
                            UserId=ds.Tables[0].Rows[0]["UserId"].ToString();
                        }
                    }
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return UserId;
        }

        public User SaveUser(User usr)
        {
            db = new Database();
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[17];
            User ReturnUserInfo = new User();
            param[0] = db.MakeInParameter("@UserId", SqlDbType.VarChar, 50, usr.UserId);
            param[1] = db.MakeInParameter("@FirstName", SqlDbType.NVarChar, 100, usr.FirstName);
            param[2] = db.MakeInParameter("@LastName", SqlDbType.NVarChar, 100, usr.LastName);
            param[3] = db.MakeInParameter("@Email", SqlDbType.VarChar, 200, usr.Email);
            param[4] = db.MakeInParameter("@Password", SqlDbType.VarChar, -1, usr.Password);
            param[5] = db.MakeInParameter("@City", SqlDbType.VarChar, 50, usr.City);
            param[6] = db.MakeInParameter("@State", SqlDbType.VarChar, 50, usr.State);
            param[7] = db.MakeInParameter("@Country", SqlDbType.Int, 4, usr.Country);
            param[8] = db.MakeInParameter("@RegistrationIpAddress", SqlDbType.VarChar, 50, usr.RegistrationIpAddress);
            param[9] = db.MakeInParameter("@IsActive", SqlDbType.Bit, 1, usr.IsActive);
            param[10] = db.MakeInParameter("@FacebookProfile", SqlDbType.VarChar, 100, usr.FacebookProfile);
            param[11] = db.MakeInParameter("@FacebookAccessToken", SqlDbType.VarChar, 100, usr.FacebookAccessToken);
            param[12] = db.MakeInParameter("@TwitterHandle", SqlDbType.VarChar, 100, usr.TwitterHandle);
            param[13] = db.MakeInParameter("@TwitterAccessToken", SqlDbType.VarChar, 100, usr.TwitterAccessToken);
            param[14] = db.MakeInParameter("@GoogleProfile", SqlDbType.VarChar, 100, usr.GoogleProfile);
            param[15] = db.MakeInParameter("@GoogleAccessToken", SqlDbType.VarChar, 100, usr.GoogleAccessToken);
            param[16] = db.MakeOutParameter("@Result", SqlDbType.Int, 4);
            try
            {
                db.RunProcedure("UserRegistration", param, out ds);
                if (Convert.ToInt32(param[16].Value.ToString()) == 1)
                {
                    ReturnUserInfo=ds.Tables[0].AsEnumerable()
                        .Select(r => new User
                        {
                            Email = r.Field<string>("Email"),
                            FirstName = r.Field<string>("FirstName"),
                            LastName = r.Field<string>("LastName"),
                            User_Unique_Name = r.Field<string>("User_Unique_Name"),
                            UserId = r.Field<string>("UserId"),
                            UserType = r.Field<string>("UserType"),
                            Photo = r.Field<string>("Photo")
                        }).FirstOrDefault();
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return ReturnUserInfo;
        }

        public User UserLogin(string UserId, string Password,string IpAddr)
        {
            User usr = null;
            try
            {
                db = new Database();
                ds = new DataSet();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = db.MakeInParameter("@UserId",SqlDbType.VarChar,50,UserId);
                param[1] = db.MakeInParameter("@Password", SqlDbType.VarChar,-1,Password);
                param[2] = db.MakeInParameter("@IpAddr", SqlDbType.VarChar,50,IpAddr);
                db.RunProcedure("UserLogin", param, out ds);
                if (!object.Equals(ds, null))
                {
                    if (ds.Tables.Count > 0)
                    {
                        usr = new User();
                        usr.Email=ds.Tables[0].Rows[0]["Email"].ToString();
                        usr.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        usr.LastName=ds.Tables[0].Rows[0]["LastName"].ToString();
                        usr.User_Unique_Name = ds.Tables[0].Rows[0]["User_Unique_Name"].ToString();
                        usr.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                        usr.UserType= ds.Tables[0].Rows[0]["UserType"].ToString();
                        usr.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                    }
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                ResetObject();
            }
            return usr;
        }

        public void ResetObject()
        {
            ds = null;
            db = null;
        }
    }

}