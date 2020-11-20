using System.IO;
using LS4W.Manager.Domain.Entities;

namespace LS4W.Manager.Application.Infrastructure
{
    public class DesktopEntryService
    {
        public DesktopEntry CreateDesktopEntry(AppInfo app)
        {
            return default;
        }

        public void DeleteDesktopEntry(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return;
            File.Delete(path);
        }
    }
}