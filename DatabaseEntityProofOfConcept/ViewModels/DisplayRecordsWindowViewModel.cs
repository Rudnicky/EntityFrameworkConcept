using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DisplayRecordsWindowViewModel : BaseViewModel, IDisplayRecordsWindowViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private Entities _currentEntity;
        public Entities CurrentEntity
        {
            get { return _currentEntity; }
            set
            {
                if (_currentEntity != value)
                {
                    _currentEntity = value;
                    OnPropertyChanged(nameof(CurrentEntity));
                }
            }
        }

        private ObservableCollection<Company> _companies = new ObservableCollection<Company>();
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set
            {
                if (_companies != value)
                {
                    _companies = value;
                    OnPropertyChanged(nameof(Companies));
                }
            }

        }

        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }

        }
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
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            GetAllCompanies();
            GettAllEmployees();
        }
        #endregion

        #region Private Methods
        private void SelectionChanged(object obj)
        {
            CurrentEntity = ConvertToEntities<Entities>(obj);
        }

        private void GetAllCompanies()
        {
            var companies = _companyRepository.GetAll().ToList();
            if (companies != null)
            {
                foreach (var company in companies)
                {
                    Companies.Add(company);
                }
            }
        }

        private void GettAllEmployees()
        {
            var employees = _employeeRepository.GetAll().ToList();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }

        public T ConvertToEntities<T>(object obj)
        {
            T enumValue = (T)Enum.Parse(typeof(T), obj.ToString());
            return enumValue;
        }
        #endregion
    }
}
