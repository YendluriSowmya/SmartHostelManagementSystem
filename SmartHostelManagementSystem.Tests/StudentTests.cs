
using SmartHostelManagementSystem.Models;
using SmartHostelManagementSystem.Services;
using Xunit;

public class StudentTests
{
    [Fact]
    public async Task AddStudent_ShouldIncreaseStudentCount()
    {
        // Arrange
        var service = new StudentService();
        var student = new Student { Name = "Test User", Email = "test@example.com" };

        // Act
        await service.AddStudentAsync(student);
        var allStudents = await service.GetAllAsync();

        // Assert
        Assert.Contains(allStudents, s => s.Email == "test@example.com");
    }
}
