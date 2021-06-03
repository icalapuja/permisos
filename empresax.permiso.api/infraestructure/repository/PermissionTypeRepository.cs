using System;
using System.Linq;
using System.Collections.Generic;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.domain.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace empresax.permiso.api.infraestructure.repository
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private DB.ApplicationDbContext context;

        public PermissionTypeRepository()
        {
            this.context = new DB.ApplicationDbContext(DB.ApplicationDB.GetDBContext());
        }


        public async Task<List<PermissionTypeAggregate>> list()
        {
            List<PermissionTypeAggregate> list = new List<PermissionTypeAggregate>();
            
            (await this.context.PermissionTypes
                .ToListAsync())
                .ForEach(item => list.Add(new PermissionTypeAggregate(item)));
            
            return list;
        }

        public Task<PermissionTypeAggregate> create(PermissionTypeAggregate aggregate)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PermissionTypeAggregate> get(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<PermissionTypeAggregate> update(PermissionTypeAggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}