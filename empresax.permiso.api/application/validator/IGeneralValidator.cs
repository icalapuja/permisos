using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;


namespace empresax.permiso.api.application.validator
{
    public interface IGeneralValidator <T, ID>
    {
        public List<MessageDTO> ValidateCreation(T dto);
        public List<MessageDTO> ValidateChange(ID id,T dto);
    }
}