using SmartHostelManagementSystem.Data;
using SmartHostelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Services
{
    public class RoomService
    {
        private readonly string file = "rooms.json";            
        

        public async Task AllocateRoomAsync(Student student)
        {
            var rooms = await GetAllRoomsAsync();
            var room = rooms.FirstOrDefault(r => r.Occupied < r.Capacity);

            if (room != null)
            {
                room.Occupied++;
                student.RoomNumber = room.RoomNumber;

                await FileStorage.SaveAsync("rooms.json", rooms);
            }
            else
            {
                throw new Exception("No rooms available.");
            }
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var rooms = await GetAllRoomsAsync();
            var fullRooms = rooms.Where(r => r.Occupied >= r.Capacity).ToList();
            return fullRooms;
        }

        public async Task<List<Room>> GetAvailableRoomsAsync()
        {
            var rooms = await GetAllRoomsAsync();
            var availableRooms = rooms
                                 .Where(r => r.Occupied < r.Capacity)
                                 .ToList();
            return availableRooms;
        }

        public async Task<List<Room>> GetSortedRoomsAsync()
        {
            var rooms = await GetAllRoomsAsync();
            var sortedRooms = rooms
                              .OrderBy(r => r.RoomNumber)
                              .ToList();
            return sortedRooms;
        }

    }
}
