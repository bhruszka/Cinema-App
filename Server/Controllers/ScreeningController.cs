using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase {

        private readonly CinemaDbContext _dbContext;

        public ScreeningController (CinemaDbContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Screening>> GetAll () {
            return _dbContext.Screenings.Include (x => x.Movie).OrderBy (x => x.Date).ToList ();
        }

        [HttpGet ("Seats/{id}")]
        [ProducesResponseType (200, Type = typeof (SeatsResponse))]
        [ProducesResponseType (404)]
        public ActionResult GetSeats (int id) {
            Screening screening;
            try {
                screening = _dbContext.Screenings.Include (s => s.Room).ThenInclude (r => r.Seats).Include (s => s.Reservations).Include (s => s.Movie).Single (s => s.ScreeningId == id);
            } catch (System.InvalidOperationException e) {
                return NotFound (new { error = "Screening cannot be found." });
            }
            var freeSeats = screening.Room.Seats.Where (s => (!screening.Reservations.Select (r => r.SeatId).Contains (s.SeatId)));
            return Ok (new SeatsResponse { screening = screening, freeSeats = freeSeats });
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (Reservation))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (409)]
        public ActionResult Create ([FromBody] CreateReservationRequest request) {
            var newReservation = new Reservation ();
            try {
                var screening = _dbContext.Screenings.Single (s => s.ScreeningId == request.screeningId);
                newReservation.Screening = screening;
            } catch (System.InvalidOperationException e) {
                return NotFound (new { error = "Screening cannot be found." });
            }
            try {
                var seat = _dbContext.Seats.Single (s => s.SeatId == request.seatId);
                newReservation.Seat = seat;
            } catch (System.InvalidOperationException e) {
                return NotFound (new { error = "Seat cannot be found." });
            }
            try {
                var entity = _dbContext.Reservations.Add (newReservation);
                var validationContext = new ValidationContext (entity);
                Validator.ValidateObject (entity, validationContext, validateAllProperties : true);
                _dbContext.SaveChanges ();
            } catch (ValidationException e) {
                return BadRequest (new { error = "Reservation cannot be created." });
            }
            catch (ArgumentException e) {
                return Conflict(new { error = "Reservation for this seat already exists."});
            }
            return Created(new Uri("http://localhost:8080/"), newReservation);
        }

        public class SeatsResponse {
            public Screening screening { get; set; }
            public IEnumerable<Seat> freeSeats { get; set; }
        }

        public class CreateReservationRequest {
            public int screeningId { get; set; }
            public int seatId { get; set; }
        }

    }
}