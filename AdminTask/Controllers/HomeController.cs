using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminTask.Models;

namespace AdminTask.Controllers
{
    public class HomeController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123-456-7890", DateOfBirth = new DateTime(1990, 1, 1) },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987-654-3210", DateOfBirth = new DateTime(1985, 5, 15) },
        };

        private static List<Task> tasks = new List<Task>
        {
            new Task { Id = 1, Title = "Hacer la compra", Description = "Comprar leche, huevos y pan", DueDate = DateTime.Today.AddDays(3), Status = TaskStatus.Pending },
            new Task { Id = 2, Title = "Llamar al cliente", Description = "Confirmar la reunión programada", DueDate = DateTime.Today.AddDays(1), Status = TaskStatus.Pending },
            new Task { Id = 3, Title = "Preparar presentación", Description = "Preparar la presentación para la reunión del equipo", DueDate = DateTime.Today.AddDays(5), Status = TaskStatus.Pending }
        };
        
        public ActionResult Index()
        {
            var userTasks = from user in users
                from task in tasks
                select new UserTask { UserId = user.Id, User = user, TaskId = task.Id, Task = task };

            return View(userTasks);
        }
        
    }
}
