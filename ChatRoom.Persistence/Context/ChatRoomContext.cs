using ChatRoom.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Persistence.Context
{
    public class ChatRoomContext : DbContext
    {
        public ChatRoomContext(
            DbContextOptions<ChatRoomContext> options
            ) : base(options)
        {
        }

        public DbSet<AssignmentUserChatRoomEntity> AssignmentUserChatRooms { get; set; }
        public DbSet<ChatRoomEntity> ChatRooms { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
