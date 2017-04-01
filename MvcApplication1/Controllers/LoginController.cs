using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
              return  RedirectToAction("Index", "Calculator");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogMeIn(LoginModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            string xmlData = HttpContext.Server.MapPath("~/App_Data/db.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);

            var results = from DataRow myRow in ds.Tables[0].Rows
                          where
                          myRow[0].ToString() == model.UserName
                          && myRow[1].ToString() == model.Password
                          select myRow;
            if (results.ToList().Count < 1)
            {
                ModelState.AddModelError(string.Empty, "The User Name or Password Is Incorrect !");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                Session.Add("username", model.UserName);

                string returnUrl = Request.QueryString["ReturnUrl"];

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    string decodedUrl = "";
                    if (!string.IsNullOrEmpty(returnUrl))
                        decodedUrl = Server.UrlDecode(returnUrl);                  

                    if (Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }

                }


                return RedirectToAction("Index", "Calculator");


            }


            return View("Index");
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Index", "Login");
        }

    }
}
