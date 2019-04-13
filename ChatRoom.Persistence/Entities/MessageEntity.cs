using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatRoom.Persistence.Entities
{
    [Table("messages")]
    public class MessageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("AssignmentUserChatRoomId")]
        public int AssignmentUserChatRoomId { get; set; }
        [Required]
        [MaxLength(64)]
        public string Status { get; set; }
        [Required]
        [MaxLength(128)]
        public string StockCode { get; set; }
        [Required]
        public string Value { get; set; }
        public AssignmentUserChatRoomEntity AssignmentUserChatRoom { get; set; }
    }
}
