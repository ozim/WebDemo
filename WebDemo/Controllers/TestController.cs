using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            JapaneseWord jpwe = new JapaneseWord();
            jpwe.EntryID = 1;
            jpwe.Hiragana =　"あ" ;
            jpwe.Romaji = "a";
            jpwe.AdditionalText = "Vowel \"a\"";
            jpwe.MotherTongueTranslationLabel = "English";
            jpwe.MotherTongueTranslation = "a";
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            return View(jpwe);
        }

        /// <summary>
        /// Edit and new methods both uses the same screen
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit() 
        {
            JapaneseWord jpwe = new JapaneseWord();
            jpwe.EntryID = 1;
            jpwe.Hiragana = "あ";
            jpwe.Romaji = "a";
            jpwe.AdditionalText = "Vowel \"a\"";
            jpwe.MotherTongueTranslationLabel = "English";
            jpwe.MotherTongueTranslation = "a";
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            return View(jpwe);
        }
            

        public ActionResult Details() 
        {
            return View();
        }
    }
}