using System;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Practices.IoC;
using LogoFX.UI.Navigation;
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
            var commandBindings = new[] {CreateBrowseBackCommandBinding(), CreateBrowseForwardCommandBinding()};

            foreach (var commandBinding in commandBindings)
            {
                CommandManager.RegisterClassCommandBinding(typeof(MainViewModel),commandBinding);
                ((UIElement)view).CommandBindings.Add(commandBinding);
            }                        
            GC.Collect();
        }        

        private CommandBinding CreateBrowseBackCommandBinding()
        {
            return new CommandBinding(NavigationCommands.BrowseBack,
                (sender, args) => _navigationService.Back(),
                (sender, args) => args.CanExecute = _navigationService.CanNavigateBack);
        }

        private CommandBinding CreateBrowseForwardCommandBinding()
        {
            return new CommandBinding(NavigationCommands.BrowseForward,
                (sender, args) => _navigationService.Forward(),
                (sender, args) => args.CanExecute = _navigationService.CanNavigateForward);            
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