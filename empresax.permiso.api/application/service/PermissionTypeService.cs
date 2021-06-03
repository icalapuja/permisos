using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.application.transform;
using empresax.permiso.api.application.validator;
using System.Threading.Tasks;

namespace empresax.permiso.api.application.service
{
    public class PermissionTypeService: GeneralService<PermissionTypeDTO, PermissionTypeAggregate, Int32>, IPermissionTypeService
    {
        public PermissionTypeService(IPermissionTypeRepository repository, 
            IPermissionTypeTransform transform,
            IPermissionTypeValidator validator)
        {
            this.repository = repository;
            this.transform = transform;
            this.validator = validator;
        }
    }
}
