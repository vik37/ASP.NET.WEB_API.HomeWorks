using SEDC.ASP.NET.WEB_API.SecondHomeWork_Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.ASP.NET.WEB_API.SecondHomeWork_Movies
{
    public static class StaticDb
    {

        public static List<Movie> GetMovies = new List<Movie>()
        {
                new Movie()
                {
                    Id = 1,
                    Name = "Bram Stoker's Dracula",
                    Genre = "Horror",
                    Duration = 2.08,
                    Actors = new List<string>()
                    {
                        "Gary Oldman", "Keanu Reeves", "Winona Ryder", "Anthony Hopkins"
                    }
                },
                new Movie()
                {
                    Id = 2,
                    Name = "The Naked Gun",
                    Genre = "Comedy",
                    Duration = 1.25,
                    Actors = new List<string>()
                    {
                        "Leslie Nilsen", "Priscilla Presley", "George Kennedy"
                    }
                },
                new Movie()
                {
                    Id = 3,
                    Name = "Johnny English Strikes Again",
                    Genre = "Comedy",
                    Duration = 1.29,
                    Actors = new List<string>()
                    {
                        "Rowan Atkinson", "Ben Miller", "Emma Thompson", "Adam James"
                    }
                },
                new Movie()
                {
                    Id = 4,
                    Name = "The Nun",
                    Genre = "Horror",
                    Duration = 1.36,
                    Actors = new List<string>()
                    {
                        "Taissa Farmiga", "Bonnie Aarons", "Demian Bichir", "Jonas Bloquet"
                    }
                },
                new Movie()
                {
                    Id = 5,
                    Name = "Star Wars: Episode I - The Phantom Menace",
                    Genre = "Sci-Fi",
                    Duration = 2.16,
                    Actors = new List<string>()
                    {
                        "Liam Neeson", "Ewan McGregor", "Natalie Portman", "Jake Lloyd", "Ian McDiarmid"
                    }
                },
                new Movie()
                {
                    Id = 6,
                    Name = "Escape Plan",
                    Genre = "Action",
                    Duration = 1.55,
                    Actors = new List<string>()
                    {
                        "Sylvester Stallone", "Arnold Schwarzenegger", "Jim Caviezel"
                    }
                },
                 new Movie()
                {
                    Id = 7,
                    Name = "The Conjuring",
                    Genre = "Horror",
                    Duration = 1.52,
                    Actors = new List<string>()
                    {
                        "Vera Farmiga", "Patrick Wilson", "Lili Taylor", "Ron Livingston"
                    }
                }


        };
    }
}
