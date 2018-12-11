using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Views;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields & Properties
        private readonly IDisplayRecordsWindowViewModel _displayRecordsWindowViewModel;
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

        private ICommand _insertButtonClickedCommand;
        public ICommand InsertButtonClickedCommand
        {
            get
            {
                return _insertButtonClickedCommand ?? (_insertButtonClickedCommand = new RelayCommand(x =>
                {
                    InsertButton_Clicked();
                }));
            }
        }

        private ICommand _deleteButtonClickedCommand;
        public ICommand DeleteButtonClickedCommand
        {
            get
            {
                return _deleteButtonClickedCommand ?? (_deleteButtonClickedCommand = new RelayCommand(x =>
                {
                    DeleteButton_Clicked();
                }));
            }
        }

        private ICommand _exitButtonClickedCommand;
        public ICommand ExitButtonClickedCommand
        {
            get
            {
                return _exitButtonClickedCommand ?? (_exitButtonClickedCommand = new RelayCommand(x =>
                {
                    ExitButton_Clicked();
                }));
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel(IDisplayRecordsWindowViewModel displayRecordsWindowViewModel, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this._displayRecordsWindowViewModel = displayRecordsWindowViewModel;
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;
        }
        #endregion

        #region Private Methods
        private void GetButton_Clicked()
        {
            var displayRecordsWindow = new DisplayRecordsWindow();
            displayRecordsWindow.DataContext = new DisplayRecordsWindowViewModel(_companyRepository, _employeeRepository);
            displayRecordsWindow.Show();
        }

        private void InsertButton_Clicked()
        {
            var insertDataWindow = new InsertDataWindow();
            insertDataWindow.DataContext = new InsertDataWindowViewModel(_companyRepository, _employeeRepository);
            insertDataWindow.Show();
        }

        private void DeleteButton_Clicked()
        {
            // TODO:
        }

        private void ExitButton_Clicked()
        {
            // TODO:
        }
        #endregion
    }
}
