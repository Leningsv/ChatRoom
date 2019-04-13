using ChatRoom.Business.Mappers;
using ChatRoom.Models.AssignmentUserChatRooms;
using ChatRoom.Persistence.Entities;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoom.Business.Services.Impl
{
    public partial class ChatRoomServiceImpl : ChatRoomService
    {
        public AssignmentUserChatRoomModel RegisterAssignmentUserChatRoom(AssignmentUserChatRoomModel assignmentUserChatRoom)
        {
            AssignmentUserChatRoomEntity assignmentUserChatRoomEntity = this._chatRoomContext.AssignmentUserChatRooms
                .Include(x => x.ChatRoom)
                .Where(x => x.Id == assignmentUserChatRoom.ChatRoomId)
                .Where(x => x.UserId == assignmentUserChatRoom.UserId).FirstOrDefault();
            if(assignmentUserChatRoomEntity != null)
            {
                throw new Exception("Currently exist this user in the chat room:" + assignmentUserChatRoomEntity.ChatRoom.Name);
            }
            assignmentUserChatRoom.Status = StatusEnum.Active.GetDescription();
            assignmentUserChatRoomEntity = Mapper.MapAssignmentUserChatRoomModelToAssignmentUserChatRoomEntity(assignmentUserChatRoom);
            this.InsertAssignmentUserChatRoom(assignmentUserChatRoomEntity);
            return Mapper.MapAssignmentUserChatRoomEntityToAssignmentUserChatRoomModel(assignmentUserChatRoomEntity);
        }

        private void InsertAssignmentUserChatRoom(AssignmentUserChatRoomEntity assignmentUserChatRoom)
        {
            this._chatRoomContext.Add<AssignmentUserChatRoomEntity>(assignmentUserChatRoom);
            this._chatRoomContext.SaveChanges();
        }
    }
}
