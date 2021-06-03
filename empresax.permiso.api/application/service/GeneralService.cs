using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.application.transform;
using empresax.permiso.api.application.validator;


namespace empresax.permiso.api.application.service
{

    public abstract class GeneralService<D,A,ID> : IGeneralService<D, ID>
    {
        protected IGeneralRepository<A,ID> repository;
        protected IGeneralTransform<D,A> transform;
        protected IGeneralValidator<D, ID> validator;

        public async Task<ResponseDTO<List<D>>> list() =>
            new ResponseDTO<List<D>>(this.transform.getDTOs(await this.repository.list()));
    

        public async Task<ResponseDTO<D>> get(ID id) =>
            new ResponseDTO<D>(this.transform.getDTO(await this.repository.get(id)));

        public void delete(ID id) =>
            this.repository.delete(id);
        

        public async Task<ResponseDTO<D>> create(D dto)
        {
            ResponseDTO<D> res = new ResponseDTO<D>(this.validator.ValidateCreation(dto));
            if(res.Errors.Count>0)
            {
                return res;
            }

            res.Data = this.transform.getDTO(await this.repository.create(this.transform.getAggregate(dto)));

            return res;
        }


        public async Task<ResponseDTO<D>> update(ID id, D dto)
        {
            ResponseDTO<D> res = new ResponseDTO<D>(this.validator.ValidateCreation(dto));
            if(res.Errors.Count>0)
            {
                return res;
            }

            res.Data = this.transform.getDTO(await this.repository.update(this.transform.getAggregate(dto)));

            return res;
        }
    }
}