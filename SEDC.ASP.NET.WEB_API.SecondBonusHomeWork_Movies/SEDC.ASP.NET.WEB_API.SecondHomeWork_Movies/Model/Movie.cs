using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.ASP.NET.WEB_API.SecondHomeWork_Movies.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Duration { get; set; }
        public List<string> Actors { get; set; } 
    }
}
