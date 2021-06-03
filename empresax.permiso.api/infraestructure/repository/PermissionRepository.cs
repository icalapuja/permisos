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
    public class PermissionRepository : IPermissionRepository
    {
        private DB.ApplicationDbContext context;

        public PermissionRepository()
        {
            this.context = new DB.ApplicationDbContext(DB.ApplicationDB.GetDBContext());
        }

        public async Task<PermissionAggregate> create(PermissionAggregate aggregate)
        {
            aggregate.root.PermissionType = null;
            this.context.Permissions.Add(aggregate.root);
            await this.context.SaveChangesAsync();
            return this.get(aggregate.root.Id).Result;
        }

        public async Task<PermissionAggregate> update(PermissionAggregate aggregate)
        {
            aggregate.root.PermissionType = null;
            this.context.Update(aggregate.root);
            await this.context.SaveChangesAsync();
            return this.get(aggregate.root.Id).Result;
        }

        public async Task<PermissionAggregate> get(int id)
        {
            Permission model =  await this.context.Permissions
                .Include(m => m.PermissionType)
                .SingleOrDefaultAsync(m=>m.Id==id);

            return new PermissionAggregate(model);
        }

        public async Task<List<PermissionAggregate>> list()
        {
            List<PermissionAggregate> list = new List<PermissionAggregate>();
            (await this.context.Permissions
                .Include(m => m.PermissionType)
                .ToListAsync())
                .ForEach(item => list.Add(new PermissionAggregate(item)));
            
            return list;
        }

        public async void delete(int id)
        {
            var permission = await this.get(id);
            if(permission != null && permission.root != null){
                this.context.Permissions.Remove(permission.root);
                await this.context.SaveChangesAsync();
            }
        }
    }
}