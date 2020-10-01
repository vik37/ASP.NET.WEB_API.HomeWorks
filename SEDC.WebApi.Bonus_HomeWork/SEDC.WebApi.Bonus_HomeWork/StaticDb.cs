using SEDC.WebApi.Bonus_HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.Bonus_HomeWork
{
    public static class StaticDb
    {
        public static List<User> AllUsers = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Viktor",
                LastName = "Zafirovski"
            },
            new User()
            {
                Id = 2,
                FirstName = "Goce",
                LastName = "Kabov"
            },
            new User()
            {
                Id = 3,
                FirstName = "Darko",
                LastName = "Pancevski"
            },
            new User()
            {
                Id = 4,
                FirstName = "Marija",
                LastName = "Kiri"
            },
            new User()
            {
                Id = 5,
                FirstName = "Petre",
                LastName = "M.Adreevski"
            },
            new User()
            {
                Id = 6,
                FirstName = "Andrea",
                LastName = "Lekic"
            },
            new User()
            {
                Id = 7,
                FirstName = "Saban",
                LastName = "Trstena"
            }
        };
    }
}
