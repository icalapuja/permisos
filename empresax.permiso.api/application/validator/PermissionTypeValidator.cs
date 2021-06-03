using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;

namespace empresax.permiso.api.application.validator
{
    public class PermissionTypeValidator : IPermissionTypeValidator
    {
        public List<MessageDTO> ValidateChange(int id, PermissionTypeDTO dto)
        {
            return new List<MessageDTO>();
        }

        public List<MessageDTO> ValidateCreation(PermissionTypeDTO dto)
        {
            return new List<MessageDTO>();
        }
    }
}