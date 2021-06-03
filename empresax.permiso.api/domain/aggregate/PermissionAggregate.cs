using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.model;

namespace empresax.permiso.api.domain.aggregate
{
    public class PermissionAggregate
    {
        public PermissionAggregate(Permission entity)
        {
            this.root = entity;
        }
        public Permission root {get;} 
    }
}