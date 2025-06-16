
using SmartHostelManagementSystem.Models;
using SmartHostelManagementSystem.Services;
using Xunit;
public class FeeTests
{
    [Fact]
    public async Task GetFeeDefaulters_ShouldReturnStudentWithoutFees()
    {
        // Arrange
        var feeService = new FeeService();
        var studentList = new List<Student>
        {
            new Student { Id = 1, Name = "Defaulter", Email = "a@test.com" },
            new Student { Id = 2, Name = "Payer", Email = "b@test.com" }
        };

        await feeService.AddPaymentAsync(new FeeRecord
        {
            StudentId = 2,
            Amount = 1000,
            PaymentDate = DateTime.Now
        });

        // Act
        var defaulters = await feeService.GetFeeDefaultersAsync(studentList);

        // Assert
        Assert.Contains(defaulters, f => f.StudentId == 1);
        Assert.DoesNotContain(defaulters, f => f.StudentId == 2);
    }
}
