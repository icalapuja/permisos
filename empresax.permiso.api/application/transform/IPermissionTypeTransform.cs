using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.aggregate;

namespace empresax.permiso.api.application.transform
{
    public interface IPermissionTypeTransform: IGeneralTransform<PermissionTypeDTO, PermissionTypeAggregate>
    {
        
    }
}