using Domain_Models.Models;
using DTO_Models.DTOModels;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public static class UserHelper 
    {
       
        public static void ValidateUserEmptyString(UserDTOM user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                 throw new UserException(null, "UserName field is required!");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new UserException(null, "Password field is required");
            }
            if (user.FirstName.Count() > 50)
            {
                throw new UserException(null, "FirstName field can not have more then 50 characters");
            }
            
        }
        public static void ValidateUserById(int? id)
        {
            if (id == null) throw new UserException(id, "Invalid user ID!");            
        }
    }
}
