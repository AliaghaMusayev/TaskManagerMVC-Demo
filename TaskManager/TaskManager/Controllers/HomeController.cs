using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Models.DBModel;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MyMainDBModel dbConnection = new MyMainDBModel();
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

        [HttpPost]
        public ActionResult Modify(Tasks modifiedTask, int Id)
        {
            dbConnection.Tasks.FirstOrDefault(f => f.Id == Id).Status=modifiedTask.Status;
            dbConnection.SaveChanges();
            return View();
        }

        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(Tasks newTask)
        {
            dbConnection.Tasks.Add(newTask);
            dbConnection.SaveChanges();
            return View("Admin");
        }
    }
}