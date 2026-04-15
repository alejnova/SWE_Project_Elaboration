using System;
using System.Collections.Generic;

namespace ADHD_Software_Engineering.Models
{
    public class FocusSession
    {
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; } = "Ready";
        public List<Distraction> Distractions { get; set; } = new List<Distraction>();

        public void AddDistraction(string note)
        {
            Distractions.Add(new Distraction
            {
                Note = note,
                loggedAt = DateTime.Now
            });
        }
    }
}