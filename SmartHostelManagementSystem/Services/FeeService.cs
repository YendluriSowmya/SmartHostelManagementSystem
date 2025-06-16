using SmartHostelManagementSystem.Data;
using SmartHostelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Services
{
    public class FeeService
    {
        private readonly string file = "fees.json";

        public async Task AddPaymentAsync(FeeRecord record)
        {
            var fees = await FileStorage.LoadAsync<FeeRecord>(file);
            fees.Add(record);
            await FileStorage.SaveAsync(file, fees);
        }

        public async Task<List<FeeRecord>> GetFeeDefaultersAsync(List<Student> students)
        {
            var fees = await FileStorage.LoadAsync<FeeRecord>(file);
            var paidIds = fees.Select(f => f.StudentId).Distinct();
            return students.Where(s => !paidIds.Contains(s.Id))
                           .Select(s => new FeeRecord { StudentId = s.Id })
                           .ToList();
        }
    }

}
