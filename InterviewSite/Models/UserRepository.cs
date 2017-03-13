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
        public IEnumerable<User> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public User SaveUser(User usr)
        {
            Database db = new Database();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[17];
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
                    ds.Tables[0].AsEnumerable()
                        .Select(r => new User
                        {
                            Email = r.Field<string>("Email"),
                            FirstName = r.Field<string>("FirstName"),
                            LastName = r.Field<string>("LastName"),
                            User_Unique_Name = r.Field<string>("User_Unique_Name"),
                            UserId = r.Field<string>("UserId"),
                            UserType = r.Field<string>("UserType"),
                            Photo = r.Field<string>("Photo")
                        });
                }
            }
            catch (Exception exp)
            {

            }
            return null;
        }
    }
}