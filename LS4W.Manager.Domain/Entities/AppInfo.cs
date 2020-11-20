namespace LS4W.Manager.Domain.Entities
{
    public class AppInfo
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string IconPath { get; set; }
        public string Path { get; set; }
        public int InstanceId { get; set; }
        public bool IsActive { get; set; }
        public string DesktopEntryPath { get; set; }
    }
}