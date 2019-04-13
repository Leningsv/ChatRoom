using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatRoom.Persistence.Entities
{
    [Table("chat-rooms")]
    public class ChatRoomEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Status { get; set; }
        [Required]
        [MaxLength(128)]
        public string Key { get; set; }
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public ICollection<AssignmentUserChatRoomEntity> AssignmentUserChatRooms { get; set; }
    }
}
