//using NetCore.Data.DataModels;
using NetCore.Data.Classes;

using NetCore.Data.ViewModels;
using NetCore.Services.Data;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser
    {
        //case2: Classes
        private DBFirstDbContext _context;

        public UserService(DBFirstDbContext context)
        {
            _context = context;
        }

        #region private methods
        private IEnumerable<User> GetUserInfos()
        {
            //case2: Classes
            return _context.Users.ToList();

            ////case1: DataModels
            //return new List<User>()
            //{
            //    new User()
            //    {
            //        UserId = "jadejs",
            //        UserName = "김정수",
            //        UserEmail = "jadejskim@gmail.com",
            //        Password = "123456"
            //    }
            //};
        }

        private bool checkTheUserInfo(string userId, string password)
        {
            return GetUserInfos().Where(u => u.UserId.Equals(userId) && u.Password.Equals(password)).Any();
        }

        #endregion private methods

        bool IUser.MatchTheUserInfor(LoginInfo login)
        {
            return checkTheUserInfo(login.UserId, login.Password);
        }
    }
}
