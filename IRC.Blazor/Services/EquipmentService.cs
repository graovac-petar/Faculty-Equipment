using IRC.Blazor.ModelValidator;
using IRC.Blazor.Services.Interfaces;
using IRC.DTOs.Equipment;
using IRC.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace IRC.Blazor.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager navigationManager;

        public EquipmentService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            this.navigationManager = navigationManager;
        }
        public List<GetEquipmentDTO> Equipments { get; set; } = new();

        public async Task CreateEquipment(CreateEquipmentDTO createEquipmentDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("Equipment", createEquipmentDTO);
            //var response = await result.Content.ReadFromJsonAsync<List<GetEquipmentDTO>>();
            await Task.Delay(700);
            navigationManager.NavigateTo("Equipment/all");

        }

        public async Task DeleteEquipment(int id)
        {
            var result = await _httpClient.DeleteAsync($"Equipment/{id}");
            navigationManager.NavigateTo("Equipment/all");
        }

        public async Task<GetEquipmentDTO> GetEquipment(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<GetEquipmentDTO>($"Equipment/{id}");
            if (result != null)
                return result;
            throw new Exception();
        }
        public async Task<EquipmentF> GetEquipmentF(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<GetEquipmentDTO>($"Equipment/{id}");
            if (result != null)
            {
                EquipmentF? equipmentF = new EquipmentF();
                equipmentF.SerialNumber = result.SerialNumber;
                equipmentF.Name = result.Name;
                equipmentF.Quantity = result.Quantity;
                equipmentF.InventoryNumber = result.InventoryNumber;
                equipmentF.Type = (EquipmentType)result.Type;
                return equipmentF;
            }


            throw new Exception();
        }

        public async Task GetEquipments()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetEquipmentDTO>>("Equipment/all");
            if (result != null)
            {
                Equipments = result;
            }
        }

        public async Task UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"Equipment/{id}", updateEquipmentDTO);
            await Task.Delay(700);
            navigationManager.NavigateTo("Equipment/all");
        }
    }
}
