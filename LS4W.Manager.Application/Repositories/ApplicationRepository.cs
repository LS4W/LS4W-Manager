using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LS4W.Manager.Domain;
using LS4W.Manager.Domain.Entities;

namespace LS4W.Manager.Application.Repositories
{
    public class ApplicationRepository
    {
        private readonly ApplicationContext _db;

        public ApplicationRepository(ApplicationContext db)
        {
            _db = db;
        }
        
        public ValueTask<AppInfo> GetAppInfoById(int id)
        {
            return _db.Apps.FindAsync(id);
        }

        public async Task AddApp(AppInfo app)
        {
            await _db.Apps.AddAsync(app);
            await _db.SaveChangesAsync();
        }

        public async Task SetAppActiveStatus(int id, bool active)
        {
            var app = await _db.Apps.FindAsync(id);
            app.IsActive = active;
            await _db.SaveChangesAsync();
        }

        public IEnumerable<AppInfo> GetAppsByInstanceId(int id)
        {
            return _db.Apps.Where(x => x.InstanceId == id);
        }

        public Task DeleteApp(AppInfo app)
        {
            _db.Apps.Remove(app);
            return _db.SaveChangesAsync();
        }
    }
}