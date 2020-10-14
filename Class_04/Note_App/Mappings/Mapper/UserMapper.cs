using Domain_Models.Models;
using DTO_Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mappings.Mapper
{
    public static class UserMapper
    {
        public static UserDTOM UserToUserModel(User user)
        {
            return new UserDTOM()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesToNotesModels(user.Notes.ToList())
            };
        } 
        public static User UserModelToUser(UserDTOM user)
        {
            return new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesModelsToNotes(user.Notes.ToList())
            };
        }
        public static List<UserDTOM> UsersToUsersModels(List<User>users)
        {
            return users.Select(user => new UserDTOM()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesToNotesModels(user.Notes.ToList())

            }).ToList();
        }
        public static List<User> UsersModelsToUsers(List<UserDTOM> users)
        {
            return users.Select(user => new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesModelsToNotes(user.Notes.ToList())
            }).ToList();
        }
        
    }
}
