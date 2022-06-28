namespace Health.Core.Framework.Account.Security
{
    public class RoleLogicModel
    {
        public long? Id { get; set; }
        public long? ParentRoleId { get; set; }
        public bool IsSystem { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }

    }
}
