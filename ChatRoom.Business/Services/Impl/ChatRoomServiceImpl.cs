using ChatRoom.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl: ChatRoomService
    {
        private ChatRoomContext _chatRoomContext;
        public ChatRoomServiceImpl(ChatRoomContext chatRoomContext)
        {
            this._chatRoomContext = chatRoomContext;
        }
    }
}
