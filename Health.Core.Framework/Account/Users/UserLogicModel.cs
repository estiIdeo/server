namespace Health.Core.Framework.Account.Users
{
    public class UserLogicModel
    {
        public long? Id { get; set; }
        public long? PartnerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? AvatarId { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public string Address { get; set; }
        public TimeSpan? UtcOffset { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> Roles { get; set; }


    }
}
