using Caliburn.Micro;
using LogoFX.Client.Mvvm.Navigation;
using LogoFX.Practices.IoC;
using LogoUI.Samples.Client.Gui.Shell.Compliance.ViewModels;

namespace LogoUI.Samples.Client.Gui.Shell.ViewModels
{    
    [Singleton]
    [NavigationViewModel(ConductorType = typeof (ShellViewModel), IsSingleton = true)]
    [NavigationSynonym(typeof(IMainViewModel))]
    public sealed class MainViewModel : Conductor<IScreen>, INavigationViewModel, IMainViewModel
    {
        public ComplianceRootViewModel ComplianceRootViewModel { get; set; }
        private readonly INavigationService _navigationService;

        public MainViewModel(
            INavigationService navigationService,
            ComplianceRootViewModel complianceRootViewModel)
        {
            ComplianceRootViewModel = complianceRootViewModel;
            _navigationService = navigationService;
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            NavigationHelper.RegisterNavigationCommands(typeof(MainViewModel),view, _navigationService);
        }                

        void INavigationConductor.NavigateTo(object viewModel, object argument)
        {
            ActivateItemImpl(viewModel);            
        }                

        private void ActivateItemImpl(object viewModel)
        {
            ActivateItem((IScreen)viewModel);
        }

        public void OnNavigated(NavigationDirection direction, object argument)
        {
            ActivateItemImpl(ComplianceRootViewModel);
        }
    }
}