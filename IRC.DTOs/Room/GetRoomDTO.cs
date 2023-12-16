namespace IRC.DTOs.Room
{
    public class GetRoomDTO
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public override string ToString()
        {
            return $"{RoomNumber}";
        }
    }
}
