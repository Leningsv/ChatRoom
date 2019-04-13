using ChatRoom.Business.Mappers;
using ChatRoom.Models.Users;
using ChatRoom.Persistence.Entities;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using System;
using System.Linq;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl : ChatRoomService
    {
        public UserModel RegisterUser(UserModel userModel)
        {
            UserEntity user = this._chatRoomContext.Users.FirstOrDefault(u => u.Key == userModel.Key);
            if (user != null)
            {
                throw new Exception("Currently exist an user register with this key");
            }
            user = Mapper.MapUserModelToUserEntity(userModel);
            user.Status = StatusEnum.Active.GetDescription();
            this.InsertUser(user);
            return Mapper.MapUserEntityToUserModel(user);
        }

        private void InsertUser(UserEntity user)
        {
            this._chatRoomContext.Add<UserEntity>(user);
            this._chatRoomContext.SaveChanges();
        }
    }
}
