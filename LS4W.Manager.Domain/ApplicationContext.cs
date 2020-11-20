using LS4W.Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LS4W.Manager.Domain
{
    public class ApplicationContext: DbContext
    {
        public DbSet<AppInfo> Apps { get; set; }
        public DbSet<InstanceInfo> Instances { get; set; }
    }
}