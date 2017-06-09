using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLogin.BL
{
    public class User
    {
        public int IdUser{ get; set; }
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Password{ get; set; }
    }

    public class UserBusinessLogic
    {
        string conStr = ConfigurationManager.ConnectionStrings["StoreroomDB"].ConnectionString;
        public int CheckUserLogin(User User)
        {
            using(SqlConnection conObj = new SqlConnection(conStr))
            {
                SqlCommand comObj = new SqlCommand("uspLogin", conObj);
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Parameters.Add(new SqlParameter("@UserName", User.UserName));
                comObj.Parameters.Add(new SqlParameter("@Password", User.Password));
                conObj.Open();
                return Convert.ToInt32( comObj.ExecuteScalar());
            }
        }
    }
}
