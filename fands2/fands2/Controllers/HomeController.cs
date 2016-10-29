using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fands2.DAL;
using fands2.Models;

namespace fands2.Controllers
{
    public class HomeController : Controller
    {
        private ResponseRepository repo = new ResponseRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Responses()
        {
            List<Response> list_of_responses = repo.GetResponses();
            ViewBag.Responses = list_of_responses;

            return View();

        }
    }
}