using System.Threading.Tasks;
using LS4W.Manager.Application.Infrastructure;
using LS4W.Manager.Application.Repositories;
using LS4W.Manager.Domain.Entities;

namespace LS4W.Manager.Application.Services
{
    public class ApplicationService
    {
        private readonly ApplicationRepository _appRepo;
        private readonly DesktopEntryService _desktopEntryService;

        public ApplicationService(ApplicationRepository appRepo, DesktopEntryService desktopEntryService)
        {
            _appRepo = appRepo;
            _desktopEntryService = desktopEntryService;
        }
        public async Task AddApplication(AppInfo appInfo)
        {
            await _appRepo.AddApp(appInfo);
            if(appInfo.IsActive)
                _desktopEntryService.CreateDesktopEntry(appInfo);
        }

        public async Task EnableApplication(int appId)
        {
            await _appRepo.SetAppActiveStatus(appId, true);
            var app = await _appRepo.GetAppInfoById(appId);
            _desktopEntryService.CreateDesktopEntry(app);
        }

        public async Task DisableApplication(int appId)
        {
            await _appRepo.SetAppActiveStatus(appId, false);
            var app = await _appRepo.GetAppInfoById(appId);
            _desktopEntryService.DeleteDesktopEntry(app.DesktopEntryPath);
        }

        public async Task DeleteApplication(int appId)
        {
            var app = await _appRepo.GetAppInfoById(appId);
            _desktopEntryService.DeleteDesktopEntry(app.DesktopEntryPath);
            await _appRepo.DeleteApp(app);
        }
    }
}