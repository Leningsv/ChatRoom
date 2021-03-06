﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatRoom.Business.Services;
using ChatRoom.Controllers.Base;
using ChatRoom.Models.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoom.Controllers.Controllers
{
    [Authorize]
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ChatRoomBaseController
    {
        private ChatRoomService _chatRoomService;
        public MessageController(ChatRoomService chatRoomService)
        {
            this._chatRoomService = chatRoomService;
        }

        [HttpPost("register-message")]
        public ActionResult Post([FromBody] MessageModel message, [FromQuery] string stock)
        {
            try
            {
                 return this.SuccessResponse(this._chatRoomService.RegisterMessage(message, stock));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
        [HttpGet("messages")]
        public ActionResult GetMessages([FromQuery] int chatRoomId)
        {
            try
            {
                return this.SuccessResponse(this._chatRoomService.GetMessages(chatRoomId));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
