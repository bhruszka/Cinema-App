using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}