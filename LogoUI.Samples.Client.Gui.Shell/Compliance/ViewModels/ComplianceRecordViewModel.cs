using LogoFX.Client.Mvvm.ViewModel;
using LogoUI.Samples.Client.Model.Contracts.Compliance;

namespace LogoUI.Samples.Client.Gui.Shell.Compliance.ViewModels
{
    public sealed class ComplianceRecordViewModel : ObjectViewModel<IComplianceRecord>       
    {
        public ComplianceRecordViewModel(IComplianceRecord model)
            : base(model)
        {
            
        }
    }
}