using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatRoom.Business.Services;
using ChatRoom.Controllers.Base;
using ChatRoom.Models.AssignmentUserChatRooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoom.Controllers.Controllers
{
    [Authorize]
    [Route("api/assignments-users-chats-rooms")]
    [ApiController]
    public class AssignmentUserChatRoomController : ChatRoomBaseController
    {
        private ChatRoomService _chatRoomService;
        public AssignmentUserChatRoomController(ChatRoomService chatRoomService)
        {
            this._chatRoomService = chatRoomService;
        }
        // POST: api/RegisterAssignmentUserChatRoom
        [HttpPost("register-assignment-user-chat-room")]
        public ActionResult Post([FromBody] AssignmentUserChatRoomModel assignmentUserChatRoom)
        {
            try
            {
                return this.SuccessResponse(this._chatRoomService.RegisterAssignmentUserChatRoom(assignmentUserChatRoom));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        // PUT: api/RegisterAssignmentUserChatRoom/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
