using IRC.EFC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC
{
    public class RoomEFC : IRoomEFC
    {
        public RoomEFC(DBContext context)
        {
            Context = context;
        }

        public DBContext Context { get; }

        public async Task AddRoomAsync(Models.Room Room)
        {
            await Context.Room.AddAsync(Room);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await Context.Room.AnyAsync(x => x.RoomId == id);
        }

        public async Task DeleteRoomAsync(int id)
        {
            if (await CheckExistAsync(id))
            {
                var Room = await GetRoomByIdAsync(id);
                Context.Room.Remove(Room);
                await Context.SaveChangesAsync();
            }

        }

        public async Task<List<Models.Room>> GetAllRoomsAsync()
        {
            var uniqueRooms = await Context.Room
                                   .GroupBy(room => room.RoomNumber)
                                   .Select(group => group.First())
                                   .ToListAsync();

            return uniqueRooms;
        }

        public async Task<Models.Room?> GetRoomByIdAsync(int id)
        {
            return await Context.Room.FirstOrDefaultAsync(x => x.RoomId == id);
        }

        public async Task UpdateRoomAsync(Models.Room Room, int id)
        {
            var existingRoom = await Context.Room.FirstOrDefaultAsync(x => x.RoomId == id);

            if (existingRoom == null)
                return;

            existingRoom.RoomNumber = Room.RoomNumber;


            await Context.SaveChangesAsync();
        }
    }
}
