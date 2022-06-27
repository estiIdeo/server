namespace Health.Core.Types.Application
{
    public class ApplicationPermission
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }

        public virtual ICollection<PermissionRole> Roles { get; set; }

    }
}
