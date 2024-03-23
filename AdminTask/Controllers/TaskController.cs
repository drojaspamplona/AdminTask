using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdminTask.Models;

public class TaskController : Controller
{
    private static List<Task> tasks = new List<Task>
    {
        new Task { Id = 1, Title = "Hacer la compra", Description = "Comprar leche, huevos y pan", DueDate = DateTime.Today.AddDays(3), Status = TaskStatus.Pending },
        new Task { Id = 2, Title = "Llamar al cliente", Description = "Confirmar la reunión programada", DueDate = DateTime.Today.AddDays(1), Status = TaskStatus.Pending },
        new Task { Id = 3, Title = "Preparar presentación", Description = "Preparar la presentación para la reunión del equipo", DueDate = DateTime.Today.AddDays(5), Status = TaskStatus.Pending }
    };

    public ActionResult Index()
    {
        return View(tasks);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Task task)
    {
        tasks.Add(task);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var taskToDelete = tasks.FirstOrDefault(t => t.Id == id);
        if (taskToDelete != null)
            tasks.Remove(taskToDelete);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var taskToEdit = tasks.FirstOrDefault(t => t.Id == id);
        if (taskToEdit != null)
            return View(taskToEdit);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Edit(Task task)
    {
        var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;
        }
        return RedirectToAction("Index");
    }
}