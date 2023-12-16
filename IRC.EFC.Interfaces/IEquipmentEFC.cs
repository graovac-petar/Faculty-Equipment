using IRC.Models;

namespace IRC.EFC.Interfaces
{
    public interface IEquipmentEFC
    {
        Task<List<Equipment>> GetAllEquipmentsAsync();
        Task<Equipment?> GetEquipmentByIdAsync(int id);

        Task AddEquipmentAsync(Equipment Equipment);

        Task DeleteEquipmentAsync(int id);
        Task<bool> CheckExistAsync(int id);
        Task UpdateEquipmentAsync(Equipment Equipment, int id);
    }
}
