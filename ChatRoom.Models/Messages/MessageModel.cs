using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatRoom.Models.Messages
{
    public struct MessageModel
    {
        public int Id { get; set; }
        [Required]
        public int AssignmentUserChatRoomId { get; set; }
        public string Status { get; set; }
        public string StockCode { get; set; }
        [Required]
        public string Value { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
