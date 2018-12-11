using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DisplayRecordsWindowViewModel : BaseViewModel, IDisplayRecordsWindowViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Commands
        private ICommand _getButtonClickedCommand;
        public ICommand GetButtonClickedCommand
        {
            get
            {
                return _getButtonClickedCommand ?? (_getButtonClickedCommand = new RelayCommand(x =>
                {
                    GetButton_Clicked();
                }));
            }
        }

        private void GetButton_Clicked()
        {
            var dupson = _companyRepository.GetAll();
        }
        #endregion

        #region Constructor
        public DisplayRecordsWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;
        }
        #endregion
    }
}
