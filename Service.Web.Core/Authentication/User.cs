namespace Service.Web.Core.Authentication
{
    public class User
    {
        public string DisplayName { get; internal set; }
        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public object RoleId { get; internal set; }
        public int UserId { get; internal set; }
    }
}