using ChatRoom.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Models.Base
{
    public class ResponseBaseModel
    {
        public ResponseCodeEnum Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
