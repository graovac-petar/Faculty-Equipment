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
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Equipment", createEquipmentDTO);
                result.EnsureSuccessStatusCode();
                await Task.Delay(700);
                navigationManager.NavigateTo("Equipment/all");
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Failed to create equipment. Please try again later.", ex);
            }
        }

        public async Task DeleteEquipment(int id)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"Equipment/{id}");
                result.EnsureSuccessStatusCode();
                navigationManager.NavigateTo("Equipment/all");
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error deleting equipment.", ex);
            }
        }

        public async Task<GetEquipmentDTO> GetEquipment(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<GetEquipmentDTO>($"Equipment/{id}");
                if (result != null)
                    return result;
                else
                    throw new InvalidOperationException("Equipment not found.");
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Failed to fetch equipment. Please try again later.", ex);
            }
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


            throw new Exception("Failed to fetch equipment. Please try again later.");
        }

        public async Task GetEquipments()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<GetEquipmentDTO>>("Equipment/all");
                if (result != null)
                {
                    Equipments = result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error fetching equipment list.", ex);
            }
        }

        public async Task UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO, int id)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"Equipment/{id}", updateEquipmentDTO);
                result.EnsureSuccessStatusCode(); // Ensure a successful HTTP status code (200-299)
                await Task.Delay(700);
                navigationManager.NavigateTo("Equipment/all");
            }
            catch (HttpRequestException ex)
            {
                HandleHttpRequestException("Error updating equipment.", ex);
            }
        }
        private void HandleHttpRequestException(string errorMessage, HttpRequestException ex)
        {
            // Log or handle the exception
            // For example: _logger.LogError(ex, "{ErrorMessage}: {ExceptionMessage}", errorMessage, ex.Message);
            throw new InvalidOperationException($"{errorMessage} Please try again later.", ex);
        }
    }
}
