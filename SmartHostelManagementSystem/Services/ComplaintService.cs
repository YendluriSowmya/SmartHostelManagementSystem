using SmartHostelManagementSystem.Data;
using SmartHostelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Services
{
    public class ComplaintService
    {
        private readonly string file = "complaints.json";

        public async Task RegisterComplaintAsync(Complaint complaint)
        {
            var list = await FileStorage.LoadAsync<Complaint>(file);
            complaint.ComplaintId = list.Count + 1;
            complaint.DateRaised = DateTime.Now;
            list.Add(complaint);
            await FileStorage.SaveAsync(file, list);
        }

        public async Task<List<Complaint>> GetByStatusAsync(string status)
        {
            var list = await FileStorage.LoadAsync<Complaint>(file);
            return list.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
