using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Repository;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Currently just displays a japanese list. I plan to have different lists in the future and also implementing a 
        /// Dropdown list feature. This is also containt a partial view.
        /// </summary>
        /// <returns></returns>
        public ActionResult DictionaryLists() 
        {
            JapaneseWordRepository jprep = new JapaneseWordRepository();
            var modellist = jprep.GetAllEntries();

            return View(modellist);
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