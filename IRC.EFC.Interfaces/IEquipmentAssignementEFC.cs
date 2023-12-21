using IRC.Models;


namespace IRC.EFC.Interfaces
{
    public interface IEquipmentAssignementEFC
    {
        Task<List<EquipmentAssignement>> GetAllEquipmentAssignementsAsync();
        Task<EquipmentAssignement?> GetEquipmentAssignementByIdAsync(int id);

        Task AddEquipmentAssignementAsync(EquipmentAssignement EquipmentAssignement);

        Task DeleteEquipmentAssignementAsync(int id);
        Task<bool> CheckExistAsync(int id);
        Task UpdateEquipmentAssignementAsync(EquipmentAssignement EquipmentAssignement, int id);
    }
}
