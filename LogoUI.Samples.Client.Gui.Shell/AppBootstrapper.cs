using Caliburn.Micro;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.Navigation;
using LogoUI.Samples.Client.Gui.Shell.UiServices;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;
using LogoUI.Samples.Client.Model.Contracts;
using LogoUI.Samples.Client.Model.Fake;

namespace LogoUI.Samples.Client.Gui.Shell
{
	public sealed class AppBootstrapper : NavigationBootstrapper<ShellViewModel,ExtendedSimpleIocContainer>
	{
	    protected override void OnConfigure(ExtendedSimpleIocContainer container)
		{
            base.OnConfigure(container);            
            
            container.RegisterSingleton<IShellCloseService, ShellViewModel>();
            container.RegisterSingleton<IWindowManager, ShellViewModel>("LikeRT"); 
            container.RegisterSingleton<ILoginService, FakeLoginService>();
            container.RegisterSingleton<IDataService, FakeDataService>();
        }	    
	}
}