using ChatRoom.Models.AssignmentUserChatRooms;
using ChatRoom.Models.Messages;
using ChatRoom.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Services
{
    public interface ChatRoomService
    {
        UserModel RegisterUser(UserModel userModel);
        AssignmentUserChatRoomModel RegisterAssignmentUserChatRoom(AssignmentUserChatRoomModel assignmentUserChatRoom);
        MessageModel RegisterMessage(MessageModel messageModel, string stock);
        List<MessageModel> GetMessages(int chatRoomId);
    }
}
