using ModelLogin.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storeroom_zjo.Controllers
{
    public class UserController : Controller
    {
        UserBusinessLogic UserBL = new UserBusinessLogic();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if (UserBL.CheckUserLogin(User) > 0)
                {
                    message = "Sukces!";
                    
                }
                else
                {
                    message = "Nazwa użytkownika lub hasło jest nieprawidłowe";
                }
            }
            else
            {
                message = "Wszystkie pola są wymagane";
            }

            if(Request.IsAjaxRequest())
            {
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}