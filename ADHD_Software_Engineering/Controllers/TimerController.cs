using System;
using Microsoft.AspNetCore.Mvc;
using ADHD_Software_Engineering.Models;

namespace ADHD_Software_Engineering.Controllers
{
    public class TimerController : Controller
    {
        public IActionResult Index()
        {
            var model = new TimerViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Start(TimerViewModel model)
        {
            model.IsRunning = true;
            model.Status = "Running";
            model.RemainingSeconds = model.Duration * 60;
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Pause(TimerViewModel model)
        {
            model.IsRunning = false;
            model.Status = "Paused";
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Reset(TimerViewModel model)
        {
            model.IsRunning = false;
            model.Status = "Reset";
            model.RemainingSeconds = model.Duration * 60;
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult LogDistraction(TimerViewModel model)
        {
           // todo: implement timer pause logic here if needed
        }
    }
}