using ChatRoom.Models.Users;
using ChatRoom.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Mappers
{
    public static partial class Mapper
    {
        public static UserEntity MapUserModelToUserEntity(UserModel user)
        {
            return new UserEntity
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Key = user.Key,
                Id = user.Id,
                LastName = user.LastName,
                Status = user.Status
            };
        }
        public static UserModel MapUserEntityToUserModel(UserEntity user)
        {
            return new UserModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Key = user.Key,
                Id = user.Id,
                LastName = user.LastName,
                Status = user.Status
            };
        }
    }
}
