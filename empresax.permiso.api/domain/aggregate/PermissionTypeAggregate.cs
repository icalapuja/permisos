using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.model;

namespace empresax.permiso.api.domain.aggregate
{
    public class PermissionTypeAggregate
    {
        public PermissionTypeAggregate(PermissionType root)
        {
            this.root = root;
        }

        public PermissionType root;
    }
}