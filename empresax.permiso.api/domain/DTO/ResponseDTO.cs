using System;
using System.Collections.Generic;

namespace empresax.permiso.api.domain.DTO
{
    public class ResponseDTO <T>
    {
        public ResponseDTO(T data)
        {
            this.Data = data;
        }

        public ResponseDTO(List<MessageDTO> errors)
        {
            this.Errors = errors;
        }

        public ResponseDTO(MessageDTO error)
        {
            if(this.Errors is null){
                this.Errors = new List<MessageDTO>();
            }

            this.Errors.Add(error);
        }

        public T Data {get;set;}
        public List<MessageDTO> Errors{get;set;}
    }
}