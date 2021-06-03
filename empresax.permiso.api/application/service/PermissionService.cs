using System;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.application.transform;
using empresax.permiso.api.application.validator;

namespace empresax.permiso.api.application.service
{
    public class PermissionService : GeneralService<PermissionDTO, PermissionAggregate, Int32>, IPermissionService
    {
        public PermissionService(IPermissionRepository repository, 
            IPermissionTransform transform,
            IPermissionValidator validator)
        {
            this.repository = repository;
            this.transform = transform;
            this.validator = validator;
        }
    }
}