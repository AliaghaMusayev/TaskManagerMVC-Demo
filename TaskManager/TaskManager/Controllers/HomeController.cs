using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Admin()
        {
            if (Convert.ToBoolean(Session["loggedUser"])==false)
            {
                return RedirectToAction("Login", "Authorize");
            }
            List<GeneralViewModel> selectedData = TempData["SelectedData"] as List<GeneralViewModel>;
            if (selectedData != null)
            {
                ViewBag.userName = selectedData[0].selectedUsers.UserName;
            }
            
            return View(selectedData);
        }

        public ActionResult User()
        {
            if (Convert.ToBoolean(Session["loggedUser"]) == false)
            {
                return RedirectToAction("Login", "Authorize");
            }
            List<GeneralViewModel> selectedData = TempData["SelectedData"] as List<GeneralViewModel>;
            if (selectedData != null)
            {
                ViewBag.userName = selectedData[0].selectedUsers.UserName;
            }
            return View(selectedData);
        }


        public ActionResult Modify()
        {
            return View();
        }
    }
}