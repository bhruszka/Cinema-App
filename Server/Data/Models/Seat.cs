using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models {
    public class Seat {
        public int SeatId { get; set; }
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Column { get; set; }
    }
}