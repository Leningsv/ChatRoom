using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Models.Messages
{
    public struct MessageModel
    {
        public int Id { get; set; }
        public int AssignmentUserChatRoomId { get; set; }
        public string Status { get; set; }
        public string StockCode { get; set; }
        public string Value { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
