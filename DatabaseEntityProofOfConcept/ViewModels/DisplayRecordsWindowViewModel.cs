using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DisplayRecordsWindowViewModel : RootDataViewModel, IDisplayRecordsWindowViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

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
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            base.GetAllCompanies();
            base.GettAllEmployees();
        }
        #endregion

        #region Private Methods
        private void SelectionChanged(object obj)
        {
            CurrentEntity = ConvertToEntities<Entities>(obj);
        }

        public T ConvertToEntities<T>(object obj)
        {
            T enumValue = (T)Enum.Parse(typeof(T), obj.ToString());
            return enumValue;
        }
        #endregion
    }
}
