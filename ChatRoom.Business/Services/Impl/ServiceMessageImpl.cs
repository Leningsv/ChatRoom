using ChatRoom.Business.Mappers;
using ChatRoom.Models.Messages;
using ChatRoom.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl : ChatRoomService
    {
        public MessageModel RegisterMessage(MessageModel messageModel)
        {
            MessageEntity message = Mapper.MapMessageModelToMessageEntity(messageModel);
            this._chatRoomContext.Add<MessageEntity>(message);
            return Mapper.MapMessageEntityToMessageModel(message);
        }
    }
}
