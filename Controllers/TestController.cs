using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }

        public string Welcome(string Name, int numTimes = 1)
        {
        //https://localhost:44349/test/welcome?name=Azkmal&numTimes=99 place in url
            return HttpUtility.HtmlEncode("Hello, " + Name + " Number of Times is " + numTimes);
        }

        public string Welcome2(string Name, int ID = 1)
        {
            
            return HttpUtility.HtmlEncode("Hello, " + Name + " ID is " + ID);
        }

        public string PrintMessage()
        {
            return "<h1>Welcome</h1><p>This is the first custom page</p>";
        }
    }
}