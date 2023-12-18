﻿using IRC.EFC.Interfaces;
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
    }
}
