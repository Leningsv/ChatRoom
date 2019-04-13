using ChatRoom.Models.Base;
using ChatRoom.Utils.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Controllers.Base
{
    public class ChatRoomBaseController : Controller
    {
        private readonly string _successDefaultMessage;
        private readonly string _badRequestDefaultMessage;

        public ChatRoomBaseController()
        {
            this._badRequestDefaultMessage = "Error";
            this._successDefaultMessage = "Success";
        }


        protected ActionResult SuccessResponse(object data)
        {
            return Ok(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.OK,
                Message = this._successDefaultMessage,
                Data = data
            });
        }
        protected ActionResult SuccessResponse(object data, string message)
        {
            return Ok(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.OK,
                Message = this._successDefaultMessage,
                Data = data
            });
        }

        protected ActionResult SuccessResponse()
        {
            return Ok(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.OK,
                Message = this._successDefaultMessage
            });
        }

        protected ActionResult ErrorResponse(string data)
        {
            return BadRequest(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.GENERIC_ERROR,
                Message = this._badRequestDefaultMessage,
                Data = data
            });
        }

        protected ActionResult ErrorResponse()
        {
            return BadRequest(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.GENERIC_ERROR,
                Message = this._badRequestDefaultMessage
            });
        }

        protected ActionResult BadRequest(string message, object data = null)
        {
            return BadRequest(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.BAD_REQUEST,
                Message = message,
                Data = data
            });
        }

        protected ActionResult BadRequest(string message)
        {
            return BadRequest(new ResponseBaseModel()
            {
                Code = ResponseCodeEnum.BAD_REQUEST,
                Message = message,
                Data = null
            });
        }
    }
}