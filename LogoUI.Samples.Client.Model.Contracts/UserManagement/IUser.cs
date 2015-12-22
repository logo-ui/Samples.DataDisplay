using LogoFX.Client.Mvvm.Model.Contracts;

namespace LogoUI.Samples.Client.Model.Contracts.UserManagement
{
    public interface IUser : IModel<int>
    {
        string LoginName { get; }
    }
}
