using ChatRoom.Persistence.Context;
using ChatRoom.Persistence.Entities;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoom.Persistence.Seeders.Impl
{
    public partial class ChatRoomSeederImpl: ChatRoomSeeder
    {
        private ChatRoomContext _chatRoomContext;
        public ChatRoomSeederImpl(
            ChatRoomContext chatRoomContext
            )
        {
            this._chatRoomContext = chatRoomContext;
        }

        public void LoadData()
        {
            this.LoadChatRooms();
        }

        public void LoadChatRooms()
        {
            if (this._chatRoomContext.ChatRooms.Count() > 0)
            {
                return;
            }
            this._chatRoomContext.AddRange(
                new ChatRoomEntity()
                {
                    Key = "SALA_1",
                    Status = StatusEnum.Active.GetDescription(),
                    Name = "Sala 1",
                    Description = "Sala 1"
                },
                new ChatRoomEntity()
                {
                    Key = "SALA_2",
                    Status = StatusEnum.Active.GetDescription(),
                    Name = "Sala 2",
                    Description = "Sala 2"
                });
            this._chatRoomContext.SaveChanges();
        }
    }
}
