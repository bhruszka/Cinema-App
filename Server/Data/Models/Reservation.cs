using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models {
    public class Reservation {
        
        [Required]
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        [Required]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}