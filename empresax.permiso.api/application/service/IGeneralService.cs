using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;
using System.Threading.Tasks;

namespace empresax.permiso.api.application.service
{
    public interface IGeneralService <D, ID>
    {
        public Task<ResponseDTO<D>> create(D dto);
        public Task<ResponseDTO<D>> update(ID id, D dto);

        public void delete(ID id);

        public Task<ResponseDTO<D>> get(ID id);
        public Task<ResponseDTO<List<D>>> list();
    }
}