using ChatRoom.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatRoom.Models.AssignmentUserChatRooms
{
    public struct AssignmentUserChatRoomModel
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ChatRoomId { get; set; }
        public string Status { get; set; }
    }
}
