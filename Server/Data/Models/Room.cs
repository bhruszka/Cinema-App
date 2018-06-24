using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models {
    public class Room {
        public int RoomId { get; set; }
        public List<Seat> Seats { get; set; }

        public int NColumns { get; set; }
        public int NRows { get; set; }
    }
}