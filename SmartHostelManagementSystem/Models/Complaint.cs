using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Open";  // "Open", "InProgress", "Resolved"
        public DateTime DateRaised { get; set; }
    }
}
