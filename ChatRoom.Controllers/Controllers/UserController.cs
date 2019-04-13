using ChatRoom.Business.Services;
using ChatRoom.Controllers.Base;
using ChatRoom.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ChatRoom.Controllers.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ChatRoomBaseController
    {
        private ChatRoomService _chatRoomService;
        public UserController(ChatRoomService chatRoomService)
        {
            this._chatRoomService = chatRoomService;
        }

        [HttpPost("register-user")]
        public ActionResult RegisterUser([FromBody] UserModel user)
        {
            try
            {
                return this.SuccessResponse(this._chatRoomService.RegisterUser(user));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
