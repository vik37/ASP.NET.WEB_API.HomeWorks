using Domain_Models.Models;
using DTO_Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        List<UserDTOM> GetAllUsers();
        UserDTOM GetUserById(int id);
        void AddUser(UserDTOM user);
        void UpdateUser(UserDTOM user);
        void DeleteUser(int id);
    }
}
