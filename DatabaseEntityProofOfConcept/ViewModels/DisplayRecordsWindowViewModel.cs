using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Extensions;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DisplayRecordsWindowViewModel : RootDataViewModel, IDisplayRecordsWindowViewModel
    {
        #region Commands
        private ICommand _selectionChangedCommand;
        public ICommand SelectionChangedCommand
        {
            get
            {
                return _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<object>(x =>
                {
                    SelectionChanged(x);
                }));
            }
        }
        #endregion

        #region Constructor
        public DisplayRecordsWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
            : base(companyRepository, employeeRepository)
        {
            base.GetAllCompanies();
            base.GettAllEmployees();
        }
        #endregion

        #region Private Methods
        private void SelectionChanged(object obj)
        {
            CurrentEntity = GlobalConverters.ConvertToEntities<Entities>(obj);
        }
        #endregion
    }
}
