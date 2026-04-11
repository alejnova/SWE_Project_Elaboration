using System;
namespace ADHD_Software_Engineering.Models
{
    public class TimerViewModel
    {
        public int Duration { get; set; } = 25;
        public int RemainingSeconds { get; set; } = 25 * 60;
        public bool IsRunning { get; set; } = false;
        public string Status { get; set; } = "Ready";
    }
}

