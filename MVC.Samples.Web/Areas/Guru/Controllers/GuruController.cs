using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Guru.Models;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class GuruController : Controller
    {
        // GET: Guru/Guru
        [HttpGet]
        public ActionResult Index()
        {
            GuruModel guruModel;
            try
            {
                guruModel = new GuruModel();
                return View(guruModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                guruModel = null;
            }
         
        }
        [HttpPost]
        public ActionResult Index(GuruModel guru)
        {

            //DB Store the data.
            return View(guru);
        }
    }
}