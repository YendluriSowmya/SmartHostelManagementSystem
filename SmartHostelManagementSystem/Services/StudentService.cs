using SmartHostelManagementSystem.Data;
using SmartHostelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Services
{
    public class StudentService
    {
        private readonly string file = "students.json";

        public async Task AddStudentAsync(Student student)
        {
            var students = await FileStorage.LoadAsync<Student>(file);
            student.Id = students.Count + 1;
            students.Add(student);
            await FileStorage.SaveAsync(file, students);
        }

        public async Task<List<Student>> GetAllAsync() =>
            await FileStorage.LoadAsync<Student>(file);
    }
}
