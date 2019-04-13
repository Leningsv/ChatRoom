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
            string key = this.GetUserKey();
            UserEntity user = this._chatRoomContext.Users.FirstOrDefault(u => u.Key == key);
            if (user != null)
            {
                throw new Exception("Currently exist an user register with this key");
            }
            user = Mapper.MapUserModelToUserEntity(userModel);
            user.Key = this.GetUserKey();
            user.Status = StatusEnum.Active.GetDescription();
            this.InsertUser(user);
            return Mapper.MapUserEntityToUserModel(user);
        }

        private void InsertUser(UserEntity user)
        {
            this._chatRoomContext.Add<UserEntity>(user);
            this._chatRoomContext.SaveChanges();
        }
        private string GetUserKey()
        {
            return this._httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
        }
    }
}
