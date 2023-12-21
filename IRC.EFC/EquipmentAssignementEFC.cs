using IRC.DTOs.Filter;
using IRC.EFC.Interfaces;
using IRC.Models;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC
{
    public class EquipmentAssignementEFC : IEquipmentAssignementEFC
    {
        public EquipmentAssignementEFC(DBContext context)
        {
            Context = context;
        }

        public DBContext Context { get; }

        public async Task AddEquipmentAssignementAsync(Models.EquipmentAssignement EquipmentAssignement)
        {
            await Context.EquipmentAssignement.AddAsync(EquipmentAssignement);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await Context.EquipmentAssignement.AnyAsync(x => x.EquipmentAssignementId == id);
        }

        public async Task DeleteEquipmentAssignementAsync(int id)
        {
            if (await CheckExistAsync(id))
            {
                var EquipmentAssignement = await GetEquipmentAssignementByIdAsync(id);
                Context.EquipmentAssignement.Remove(EquipmentAssignement);
                await Context.SaveChangesAsync();
            }

        }

        public async Task<List<Models.EquipmentAssignement>> GetAllEquipmentAssignementsAsync()
        {
            var assignments = Context.EquipmentAssignement.Include(e => e.Room)
                .Include(e => e.Equipment)
                .Include(e => e.Employee)
                .ToList();
            return assignments;
        }

        public async Task<Models.EquipmentAssignement?> GetEquipmentAssignementByIdAsync(int id)
        {
            return await Context.EquipmentAssignement.Include(e => e.Room)
                .Include(e => e.Equipment)
                .Include(e => e.Employee).FirstOrDefaultAsync(x => x.EquipmentAssignementId == id);
        }

        public async Task UpdateEquipmentAssignementAsync(Models.EquipmentAssignement EquipmentAssignement, int id)
        {
            var existingEquipment = await Context.EquipmentAssignement.FirstOrDefaultAsync(x => x.EquipmentAssignementId == id);

            if (existingEquipment == null)
                return;

            existingEquipment.EquipmentId = EquipmentAssignement.EquipmentId;
            existingEquipment.EmployeeId = EquipmentAssignement.EmployeeId;
            existingEquipment.RoomId = EquipmentAssignement.RoomId;
            existingEquipment.DateBorrowed = EquipmentAssignement.DateBorrowed;

            await Context.SaveChangesAsync();
        }

        public IQueryable? Search(FilterRequestDTO model)
        {
            var filterQuery = Context.EquipmentAssignement.AsQueryable();


            if (model.Filters.Any())
            {
                var room = model.Filters
                    .FirstOrDefault(f => f.Name == "Room");

                if (room != null && Int32.Parse(room.Value) != -1)
                {
                    filterQuery = filterQuery.Where(ea => ea.RoomId == Int32.Parse(room.Value));
                }

                var employee = model.Filters
                    .FirstOrDefault(f => f.Name == "Employee");

                if (employee != null && Int32.Parse(employee.Value) != -1)
                {
                    filterQuery = filterQuery.Where(ea => ea.EmployeeId == Int32.Parse(employee.Value));
                }

                var equipmentType = model.Filters
                    .FirstOrDefault(f => f.Name == "EquipmentType");

                if (equipmentType != null && Int32.Parse(equipmentType.Value) != -1)
                {
                    filterQuery = filterQuery.Where(ea => (int)ea.Equipment.Type == Int32.Parse(equipmentType.Value));
                }

                var department = model.Filters
                    .FirstOrDefault(f => f.Name == "Department");

                if (department != null && department.Value != "")
                {
                    filterQuery = filterQuery.Where(ea => ea.Employee.Department == department.Value);
                }

            }
            return filterQuery;
        }
    }
}
