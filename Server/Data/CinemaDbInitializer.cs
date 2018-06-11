using System;
using System.Collections.Generic;
using Data;
using Server.Data.Models;

namespace Server.Data {
    public static class CinemaDbInitializer {
        public static void Seed (CinemaDbContext context) {
            var movies = new Movie[] {
                new Movie () {
                MovieName = "AVENGERS: WOJNA BEZ GRANIC"
                },
                new Movie () {
                MovieName = "DEADPOOL 2"
                },
                new Movie () {
                MovieName = "ELLA I JOHN"
                },
                new Movie () {
                MovieName = "HAN SOLO: GWIEZDNE WOJNY - HISTORIE"
                },
                new Movie () {
                MovieName = "JURASSIC WORLD: UPADŁE KRÓLESTWO"
                }
            };
            context.Movies.AddRange (movies);

            var rooms = new Room[] {
                new Room (),
                new Room (),
                new Room ()
            };

            context.Rooms.AddRange (rooms);

            var seats = GenerateSeats (rooms[0], 10, 20);
            seats.AddRange(GenerateSeats (rooms[1], 10, 10));
            seats.AddRange(GenerateSeats (rooms[2], 10, 30));

            context.Seats.AddRange(seats);

            context.Screenings.AddRange(new Screening[] {
                // Time +0|1:
                new Screening() {
                    Date = DateTime.Now.AddHours(1),
                    Movie = movies[0],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(1),
                    Movie = movies[2],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(1),
                    Movie = movies[3],
                    Room = rooms[2]
                },
                // Time +0|3:
                new Screening() {
                    Date = DateTime.Now.AddHours(3),
                    Movie = movies[4],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(3),
                    Movie = movies[1],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(3),
                    Movie = movies[0],
                    Room = rooms[2]
                },
                // Time +0|5:
                new Screening() {
                    Date = DateTime.Now.AddHours(5),
                    Movie = movies[3],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(5),
                    Movie = movies[0],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(5),
                    Movie = movies[2],
                    Room = rooms[2]
                },
                // Time +0|7:
                new Screening() {
                    Date = DateTime.Now.AddHours(7),
                    Movie = movies[2],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(7),
                    Movie = movies[1],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(7),
                    Movie = movies[4],
                    Room = rooms[2]
                },
                // Time +0|9:
                new Screening() {
                    Date = DateTime.Now.AddHours(9),
                    Movie = movies[2],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(9),
                    Movie = movies[1],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(9),
                    Movie = movies[4],
                    Room = rooms[2]
                },
                // Time +0|11:
                new Screening() {
                    Date = DateTime.Now.AddHours(11),
                    Movie = movies[4],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(11),
                    Movie = movies[1],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddHours(11),
                    Movie = movies[3],
                    Room = rooms[2]
                },
                // Time +1|1:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(1),
                    Movie = movies[0],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(1),
                    Movie = movies[2],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(1),
                    Movie = movies[4],
                    Room = rooms[2]
                },
                // Time +1|3:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(3),
                    Movie = movies[4],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(3),
                    Movie = movies[3],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(3),
                    Movie = movies[2],
                    Room = rooms[2]
                },
                // Time +1|5:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(5),
                    Movie = movies[1],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(5),
                    Movie = movies[3],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(5),
                    Movie = movies[4],
                    Room = rooms[2]
                },
                // Time +1|7:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(7),
                    Movie = movies[3],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(7),
                    Movie = movies[1],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(7),
                    Movie = movies[0],
                    Room = rooms[2]
                },
                // Time +1|9:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(9),
                    Movie = movies[2],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(9),
                    Movie = movies[4],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(9),
                    Movie = movies[3],
                    Room = rooms[2]
                },
                // Time +1|11:
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(11),
                    Movie = movies[3],
                    Room = rooms[0]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(11),
                    Movie = movies[0],
                    Room = rooms[1]
                },
                new Screening() {
                    Date = DateTime.Now.AddDays(1).AddHours(11),
                    Movie = movies[1],
                    Room = rooms[2]
                },


            });

            context.SaveChanges();
        }

        private static List<Seat> GenerateSeats (Room room, int rows, int columns) {
            var seats = new List<Seat> ();
            for (int i = 0; i < columns; i++) {
                for (int j = 0; j < rows; j++) {
                    var seat = new Seat () {
                        Room = room,
                        Column = i,
                        Row = j
                    };
                    seats.Add(seat);
                }
            }
            return seats; 
        }
    }
}