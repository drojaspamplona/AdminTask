using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminTask.Models;

namespace AdminTask.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123-456-7890", DateOfBirth = new DateTime(1990, 1, 1) },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987-654-3210", DateOfBirth = new DateTime(1985, 5, 15) },
        };
        public ActionResult Index()
        {
            return View(users);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = users.Count + 1; 
                users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    existingUser.DateOfBirth = user.DateOfBirth;
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}
