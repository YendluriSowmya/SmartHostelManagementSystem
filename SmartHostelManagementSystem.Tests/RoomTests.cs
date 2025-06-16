using SmartHostelManagementSystem.Models;
using SmartHostelManagementSystem.Services;
using Xunit;
public class RoomTests
{
    [Fact]
    public async Task AllocateRoom_ShouldThrow_WhenNoRoomAvailable()
    {
        // Arrange
        var roomService = new RoomService();

        // Save empty room list to simulate "no available rooms"
        await SmartHostelManagementSystem.Data.FileStorage.SaveAsync("rooms.json", new List<Room>());

        var student = new Student { Name = "Test", Email = "test@test.com" };

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => roomService.AllocateRoomAsync(student));
    }
}
