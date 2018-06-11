using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models {
    public class Reservation {
        public int ReservationId { get; set; }

        [Required]
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        [Required]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}