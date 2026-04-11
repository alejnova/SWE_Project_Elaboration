using System;

namespace ADHD_Software_Engineering.Models
{
    public class Distraction
    {
        public string Note { get; set; }
        public DateTime loggedAt { get; set; } = DateTime.Now;
    }
}