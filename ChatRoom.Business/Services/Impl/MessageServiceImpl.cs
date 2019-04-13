using ChatRoom.Business.Mappers;
using ChatRoom.Models.Messages;
using ChatRoom.Persistence.Entities;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl : ChatRoomService
    {
        public MessageModel RegisterMessage(MessageModel messageModel, string stock)
        {
            messageModel.Status = StatusEnum.Active.GetDescription();
            messageModel.CreateAt = DateTime.Now;
            messageModel.StockCode = stock;
            MessageEntity messageEntity = Mapper.MapMessageModelToMessageEntity(messageModel);
            this.InsertMessage(messageEntity);
            return Mapper.MapMessageEntityToMessageModel(messageEntity);
        }

        private void InsertMessage(MessageEntity message)
        {
            this._chatRoomContext.Add<MessageEntity>(message);
            this._chatRoomContext.SaveChanges();
        }

        public List<MessageModel> GetMessages(int chatRoomId)
        {
            List<MessageEntity> messages = this._chatRoomContext.Messages
                .Where(x => x.AssignmentUserChatRoom.ChatRoomId == chatRoomId)
                .Take(50)
                .OrderByDescending(x => x.CreateAt).ToList();
            return Mapper.MapMesMapMessageEntityToMessageModel(messages);
        }
    }
}
