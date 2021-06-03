using System;
using System.Collections.Generic;

namespace empresax.permiso.api.application.transform
{
    public interface IGeneralTransform <D,A>
    {
        public D getDTO(A aggregate);
        public A getAggregate(D dto);
        public List<D> getDTOs(List<A> aggregates);
        public List<A> getAggregates(List<D> DTOs);
    }
}