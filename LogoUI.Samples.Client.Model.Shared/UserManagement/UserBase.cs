using LogoUI.Samples.Client.Model.Contracts.UserManagement;

namespace LogoUI.Samples.Client.Model.Shared.UserManagement
{
    public class UserBase : DomainModel, IUser
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
