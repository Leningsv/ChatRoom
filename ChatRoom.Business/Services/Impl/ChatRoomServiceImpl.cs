using ChatRoom.Persistence.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl: ChatRoomService
    {
        private ChatRoomContext _chatRoomContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChatRoomServiceImpl(
            ChatRoomContext chatRoomContext,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this._chatRoomContext = chatRoomContext;
            this._httpContextAccessor = httpContextAccessor;
        }
    }
}
