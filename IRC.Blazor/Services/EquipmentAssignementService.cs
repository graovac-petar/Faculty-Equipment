using IRC.Blazor.Services.Interfaces;
using IRC.DTOs.Employee;
using IRC.DTOs.EquipmentAssaignement;
using IRC.DTOs.Filter;
using IRC.DTOs.Room;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace IRC.Blazor.Services
{
    public class EquipmentAssignementService : IEquipmentAssignementService
    {
        public HttpClient _http { get; }
        public NavigationManager NavigationManager { get; }
        public EquipmentAssignementService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _http = httpClient;
            NavigationManager = navigationManager;
        }
        public List<GetEquipmentAssignementDTO> EquipmentAssignements { get; set; } = new List<GetEquipmentAssignementDTO>();
        public List<GetRoomDTO> Rooms { get; set; } = new List<GetRoomDTO>();
        public List<GetEmployeeDTO> Employees { get; set; } = new List<GetEmployeeDTO>();


        public async Task CreateEquipmentAssignement(CreateEquipmentAssignementDTO createEquipmentAssignement)
        {
            var result = await _http.PostAsJsonAsync("/EquipmentAssignement", createEquipmentAssignement);
            NavigationManager.NavigateTo("Equipment/all");
        }

        public async Task GetEmployee()
        {
            var result = await _http.GetFromJsonAsync<List<GetEmployeeDTO>>("/Employee");
            if (result != null)
                Employees = result;
        }
        public async Task GetRooms()
        {
            var result = await _http.GetFromJsonAsync<List<GetRoomDTO>>("/Room");
            if (result != null)
                Rooms = result;
        }

        public async Task GetEquipmentAssignements()
        {
            var result = await _http.GetFromJsonAsync<List<GetEquipmentAssignementDTO>>("/EquipmentAssignement");
            if (result != null)
                EquipmentAssignements = result;
        }

        public async Task Filter(FilterRequestDTO filterRequest)
        {
            var result = await _http.PostAsJsonAsync("/EquipmentAssignement/search", filterRequest);
            if (result.IsSuccessStatusCode)
                EquipmentAssignements = await result.Content.ReadFromJsonAsync<List<GetEquipmentAssignementDTO>>();
        }
    }
}
