namespace Health.Core.Framework.Account.Authentication
{
    public class AuthenticationResponseLogicModel
    {
        public string Username { get; set; }
        public long UserId { get; set; }
        public string Type { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? AvatarId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
