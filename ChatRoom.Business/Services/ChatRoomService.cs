using ChatRoom.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Services
{
    public interface ChatRoomService
    {
        UserModel RegisterUser(UserModel userModel);
    }
}
