using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;

namespace empresax.permiso.api.domain.DTO
{
    public class ResponseErrorDTO
    {
        public ResponseErrorDTO(List<MessageDTO> errors)
        {
            this.errors = errors;
        }
        public List<MessageDTO> errors{get;set;}
    }
}