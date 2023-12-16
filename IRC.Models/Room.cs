﻿using System.ComponentModel.DataAnnotations;

namespace IRC.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string RoomNumber { get; set; }
        public ICollection<EquipmentAssignement> EquipmentAssignments { get; set; }
    }
}