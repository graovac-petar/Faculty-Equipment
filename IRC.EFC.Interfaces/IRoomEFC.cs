using IRC.Models;

namespace IRC.EFC.Interfaces
{
    public interface IRoomEFC
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int id);

        Task AddRoomAsync(Room room);

        Task DeleteRoomAsync(int id);
        Task<bool> CheckExistAsync(int id);
        Task UpdateRoomAsync(Room room, int id);

    }
}
