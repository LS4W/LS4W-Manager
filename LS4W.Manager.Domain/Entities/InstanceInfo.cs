using System.Collections.Generic;

namespace LS4W.Manager.Domain.Entities
{
    public class InstanceInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRemote { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public List<AppInfo> Apps { get; set; }
    }
}