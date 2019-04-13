using ChatRoom.Models.Messages;
using ChatRoom.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Mappers
{
    public static partial class Mapper
    {
        public static MessageEntity MapMessageModelToMessageEntity(MessageModel message)
        {
            return new MessageEntity
            {
                AssignmentUserChatRoomId = message.AssignmentUserChatRoomId,
                CreateAt = message.CreateAt,
                Id = message.Id,
                Status = message.Status,
                StockCode = message.StockCode,
                Value = message.Value
            };
        }

        public static MessageModel MapMessageEntityToMessageModel(MessageEntity message)
        {
            return new MessageModel
            {
                AssignmentUserChatRoomId = message.AssignmentUserChatRoomId,
                CreateAt = message.CreateAt,
                Id = message.Id,
                Status = message.Status,
                StockCode = message.StockCode,
                Value = message.Value
            };
        }
    }
}
