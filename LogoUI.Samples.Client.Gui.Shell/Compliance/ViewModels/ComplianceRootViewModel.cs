﻿using Caliburn.Micro;
using LogoFX.Client.Mvvm.Navigation;
using LogoFX.Practices.IoC;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;

namespace LogoUI.Samples.Client.Gui.Shell.Compliance.ViewModels
{
    [Singleton]
    [NavigationViewModel(ConductorType = typeof(IMainViewModel), IsSingleton = true)]
    public sealed class ComplianceRootViewModel : Conductor<ConsoleViewModel>, INavigationViewModel
    {
        public ComplianceRootViewModel(ConsoleViewModel consoleViewModel)
        {
            ConsoleViewModel = consoleViewModel;            
        }

        public ConsoleViewModel ConsoleViewModel { get; set; }

        protected override void OnActivate()
        {
            ActivateItem(ConsoleViewModel);
        }

        public void OnNavigated(NavigationDirection direction, object argument)
        {
            if (direction == NavigationDirection.None && ActiveItem == null)
            {
                ActivateItem(ConsoleViewModel);
            }
        }        
    }
}