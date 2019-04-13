using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatRoom.Persistence.Entities
{
    [Table("assignments-users")]
    public class AssignmentUserChatRoomEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("ChatRoomId")]
        public int ChatRoomId { get; set; }
        [Required]
        [MaxLength(64)]
        public string Status { get; set; }
        public UserEntity User { get; set; }
        public ChatRoomEntity ChatRoom { get; set; }
        public ICollection<MessageEntity> Messages { get; set; }
    }
}
