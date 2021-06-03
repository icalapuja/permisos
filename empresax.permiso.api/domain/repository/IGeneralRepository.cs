using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empresax.permiso.api.domain.repository
{
    public interface IGeneralRepository <A, ID>
    {
        public Task<A> create(A aggregate);
        public Task<A> update(A aggregate);
        public void delete(ID id);
        public Task<A> get(ID id);
        public Task<List<A>> list();
    }
}