using ADHD_Software_Engineering.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADHD_Software_Engineering.Controllers
{
    public class TaskController : Controller
    {
        // Temporary in-memory list
        private static readonly List<TaskItem> Tasks = new()
        {
            new TaskItem
            {
                Id = 1,
                Title = "Discussion 3",
                Description = "Finish Software Engineering Discussion",
                DueDate = DateTime.Today.AddDays(2),
                Status = "Pending",
                Subtasks = new List<SubtaskItem>
                {
                    new SubtaskItem { Title = "Gather risks" },
                    new SubtaskItem { Title = "Describe team contribution" }
                }
            }
        };

        public IActionResult Index()
        {
            return View(Tasks);
        }

        public IActionResult Dashboard()
        {
            return View(Tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TaskItem());
        }

        public IActionResult Profile()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task, string? subtask1, string? subtask2, string? subtask3)
        {
            if (!string.IsNullOrWhiteSpace(subtask1))
                task.Subtasks.Add(new SubtaskItem { Title = subtask1 });

            if (!string.IsNullOrWhiteSpace(subtask2))
                task.Subtasks.Add(new SubtaskItem { Title = subtask2 });

            if (!string.IsNullOrWhiteSpace(subtask3))
                task.Subtasks.Add(new SubtaskItem { Title = subtask3 });

            if (!ModelState.IsValid)
                return View(task);

            task.Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1;
            task.Status = "Pending";

            Tasks.Add(task);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem updatedTask, string? subtask1, string? subtask2, string? subtask3)
        {
            var existingTask = Tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(updatedTask);

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.Status = updatedTask.Status;

            existingTask.Subtasks = new List<SubtaskItem>();

            if (!string.IsNullOrWhiteSpace(subtask1))
                existingTask.Subtasks.Add(new SubtaskItem { Title = subtask1 });

            if (!string.IsNullOrWhiteSpace(subtask2))
                existingTask.Subtasks.Add(new SubtaskItem { Title = subtask2 });

            if (!string.IsNullOrWhiteSpace(subtask3))
                existingTask.Subtasks.Add(new SubtaskItem { Title = subtask3 });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                Tasks.Remove(task);

            return RedirectToAction(nameof(Index));
        }
    }
}

