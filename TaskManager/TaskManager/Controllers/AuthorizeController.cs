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
    
    public class AuthorizeController : Controller
    {
        private MyMainDBModel dbConnections = new MyMainDBModel();
        // GET: Authorize
        public ActionResult Login()
        {
            Session["loggedUser"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(GeneralViewModel loginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var loggedInUser = dbConnections.Users.FirstOrDefault(f => f.UserName.Equals(loginUser.selectedUsers.UserName) && f.Password.Equals(loginUser.selectedUsers.Password));
                if (loggedInUser == null)
                {
                    ViewBag.loginStatus = "Password or username is incorrect / Or user not registered";
                    return View();
                }
                
                var LoggedUserStatus = dbConnections.UserStatus.FirstOrDefault(w => w.Id.Equals(loggedInUser.UserStatus));
                
                var LoggedUserTasks = LoggedUserStatus.Id == (int)Status.User ? dbConnections.Tasks.Where(w => w.UserId.Equals(loggedInUser.Id)) : dbConnections.Tasks;

                if (LoggedUserTasks.Count() == 0)
                {
                    ViewBag.loginStatus = "User have not any tasks";

                }

                List<GeneralViewModel> selectedUser = new List<GeneralViewModel>();
                selectedUser.Add(new GeneralViewModel() { selectedUsers = loggedInUser,userStatus = LoggedUserStatus, userTasks = LoggedUserTasks});

                TempData["SelectedData"] = selectedUser;

                Session["loggedUser"] = true;
                

                if (LoggedUserStatus.Id != (int)Status.Admin)
                {
                    return RedirectToAction("User", "Home");
                }

                return RedirectToAction("Admin", "Home");
            }

            catch(Exception ex)
            {
                return View(ex.Message);
            }
            
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users signUpUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbConnections.Users.Add(signUpUser);
            dbConnections.SaveChanges();
            ViewBag.success = "You are signed up successfully";
            return RedirectToAction("Login");
        }
    }
}