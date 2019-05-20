using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
       
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Game()
        {
            MinesweeperModel msModel = new MinesweeperModel(3, 7);
            Session["msmodel"] = msModel;
            return View(msModel);
        }
        public ActionResult GameMove(int x, int y)
        {
            var msModel = (MinesweeperModel)Session["msmodel"];
            msModel.MakeMove(x, y);
            return View("Game", msModel);
        }
        public ActionResult Flag(int x, int y)
        {
            var msModel = (MinesweeperModel)Session["msmodel"];
            msModel.MakeMove(x, y);
            return View("Game", msModel);
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
    }
}