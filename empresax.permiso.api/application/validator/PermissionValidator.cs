using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;

namespace empresax.permiso.api.application.validator
{
    public class PermissionValidator : IPermissionValidator
    {
        public List<MessageDTO> ValidateCreation(PermissionDTO dto)
        {
            List<MessageDTO> messages = new List<MessageDTO>();
            
            if(dto is null)
            {
                messages.Add(new MessageDTO("E001", "Data is require"));
            }else{
                if(dto.type is null)
                {
                    messages.Add(new MessageDTO("E001", "file type is require"));
                }else{
                    if(dto.type.id == 0){
                        messages.Add(new MessageDTO("E001", "file type.id is require"));
                    }
                }
            }

            return messages;
        }

        public List<MessageDTO> ValidateChange(int id, PermissionDTO dto)
        {
            List<MessageDTO> messages = new List<MessageDTO>();
            
            if(dto is null)
            {
                messages.Add(new MessageDTO("E001", "Data is require"));
            }else{
                if(dto.type is null)
                {
                    messages.Add(new MessageDTO("E002", "file type is require"));
                }else{
                    if(dto.type.id == 0){
                        messages.Add(new MessageDTO("E003", "file type.id is require"));
                    }
                }

                if(dto.id != id)
                {
                    messages.Add(new MessageDTO("E004", "the id's are different"));
                }
            }

            return messages;
        }
    }
}