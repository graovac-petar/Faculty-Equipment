using IRC.EFC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC
{
    public class EquipmentEFC : IEquipmentEFC
    {
        public EquipmentEFC(DBContext context)
        {
            Context = context;
        }

        public DBContext Context { get; }

        public async Task AddEquipmentAsync(Models.Equipment Equipment)
        {
            await Context.Equipment.AddAsync(Equipment);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await Context.Equipment.AnyAsync(x => x.EquipmentId == id);
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            if (await CheckExistAsync(id))
            {
                var Equipment = await GetEquipmentByIdAsync(id);
                Context.Equipment.Remove(Equipment);
                await Context.SaveChangesAsync();
            }

        }

        public async Task<List<Models.Equipment>> GetAllEquipmentsAsync()
        {
            return await Context.Equipment.ToListAsync();
        }

        public async Task<Models.Equipment?> GetEquipmentByIdAsync(int id)
        {
            return await Context.Equipment.FirstOrDefaultAsync(x => x.EquipmentId == id);
        }

        public async Task UpdateEquipmentAsync(Models.Equipment Equipment, int id)
        {
            if (await CheckExistAsync(id))
            {
                var existingEquipment = await GetEquipmentByIdAsync(id);
                Context.Equipment.Attach(existingEquipment);
                await Context.SaveChangesAsync();
            }
        }
    }
}
