using Microsoft.EntityFrameworkCore;
using empresax.permiso.api.domain.model;

namespace empresax.permiso.api.infraestructure.repository.DB
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

    }
}