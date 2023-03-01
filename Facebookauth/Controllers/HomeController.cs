using Facebookauth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

using Facebook;
using Microsoft.AspNetCore.Http.Extensions;

namespace Facebookauth.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private const string AppId = "531352765769901";
        private const string AppSecret = "1df70441f37769634932b20c8b0e7152";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FacebookLogin()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = AppId,
                client_secret = AppSecret,
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = AppId,
                client_secret = AppSecret,
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=first_name,last_name,email");

            string firstName = me.ATHIRA;
            string lastName = me.PARAMESWRAN;
            string email = me.athira007p;

            

            return RedirectToAction("Index");
        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.GetEncodedUrl());
                uriBuilder.Path = Url.Action("FacebookCallback");
                uriBuilder.Query = null;
                return uriBuilder.Uri;
            }
        }
    }

}
