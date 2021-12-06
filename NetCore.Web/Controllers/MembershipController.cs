using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        //의존성 주입 - 생성자
        private IUser _user;

        public MembershipController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Services => Web + // Data => Services 
        // Data => Service => Web
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                //3. MVC
                //if (login.UserId.Equals(userId) && login.Password.Equals(password))
                //4. 뷰모델 : 서비스개념
                if (_user.MatchTheUserInfor(login))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                    return RedirectToAction("Index", "Membership");
                }
                else
                {
                    message = "로그인되지 않았습니다.";
                }
            }
            else
            {
                message = "로그인 정보를 올바르게 입력하세요.";
            }

            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }

    }
}
