using SmartHostelManagementSystem.Models;
using SmartHostelManagementSystem.Services;
using Xunit;
public class ComplaintTests
{
    [Fact]
    public async Task GetByStatus_ShouldReturnOnlyOpenComplaints()
    {
        // Arrange
        var service = new ComplaintService();

        await service.RegisterComplaintAsync(new Complaint
        {
            StudentId = 1,
            Description = "Wi-Fi not working",
            Status = "Open"
        });

        await service.RegisterComplaintAsync(new Complaint
        {
            StudentId = 2,
            Description = "Water issue",
            Status = "Resolved"
        });

        // Act
        var openComplaints = await service.GetByStatusAsync("Open");

        // Assert
        Assert.All(openComplaints, c => Assert.Equal("Open", c.Status));
    }
}