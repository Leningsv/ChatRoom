using ChatRoom.Models.AssignmentUserChatRooms;
using ChatRoom.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Business.Mappers
{
    public static partial class Mapper
    {
        public static AssignmentUserChatRoomModel MapAssignmentUserChatRoomEntityToAssignmentUserChatRoomModel(AssignmentUserChatRoomEntity assignmentUserChatRoom)
        {
            return new AssignmentUserChatRoomModel
            {
                ChatRoomId = assignmentUserChatRoom.ChatRoomId,
                Id = assignmentUserChatRoom.Id,
                Status = assignmentUserChatRoom.Status,
                UserId = assignmentUserChatRoom.UserId
            };
        }
        public static AssignmentUserChatRoomEntity MapAssignmentUserChatRoomModelToAssignmentUserChatRoomEntity(AssignmentUserChatRoomModel assignmentUserChatRoom)
        {
            return new AssignmentUserChatRoomEntity
            {
                ChatRoomId = assignmentUserChatRoom.ChatRoomId,
                Id = assignmentUserChatRoom.Id,
                Status = assignmentUserChatRoom.Status,
                UserId = assignmentUserChatRoom.UserId
            };
        }
    }
}
