using Data.Interfaces;
using Domain_Models.Models;
using DTO_Models.DTOModels;
using Mappings.Mapper;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServicesInplementation
{
    public class UserService : IUserServices
    {
        private IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public void AddUser(UserDTOM userModel)
        {
            UserHelper.ValidateUserEmptyString(userModel);
            var user = UserMapper.UserModelToUser(userModel);
           
            _userRepo.Insert(user);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            UserHelper.ValidateUserById(user.Id);
            _userRepo.Remove(id);

        }

        public List<UserDTOM> GetAllUsers()
        {
            return UserMapper.UsersToUsersModels(_userRepo.GetAll().ToList());
        }

        public UserDTOM GetUserById(int id)
        {
            var user = _userRepo.GetById(id);
            UserHelper.ValidateUserById(user.Id);
            return UserMapper.UserToUserModel(user);
        }

        public void UpdateUser(UserDTOM userModel)
        {
            var userCheck = _userRepo.GetById(userModel.Id);
            UserHelper.ValidateUserById(userCheck.Id);
            UserHelper.ValidateUserEmptyString(userModel);
            var user = UserMapper.UserModelToUser(userModel);
            _userRepo.Update(user);
        }
    }
}
