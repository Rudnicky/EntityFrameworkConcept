using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class InsertDataWindowViewModel : BaseViewModel
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

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        private string _companyIndustry;
        public string CompanyIndustry
        {
            get { return _companyIndustry; }
            set
            {
                if (_companyIndustry != value)
                {
                    _companyIndustry = value;
                    OnPropertyChanged(nameof(CompanyIndustry));
                }
            }
        }

        private string _employeeName;
        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    OnPropertyChanged(nameof(EmployeeName));
                }
            }
        }

        private string _employeeSurname;
        public string EmployeeSurname
        {
            get { return _employeeSurname; }
            set
            {
                if (_employeeSurname != value)
                {
                    _employeeSurname = value;
                    OnPropertyChanged(nameof(EmployeeSurname));
                }
            }
        }

        private string _employeeAge;
        public string EmployeeAge
        {
            get { return _employeeAge; }
            set
            {
                if (_employeeAge != value)
                {
                    _employeeAge = value;
                    OnPropertyChanged(nameof(EmployeeAge));
                }
            }
        }

        private string _employeePosition;
        public string EmployeePosition
        {
            get { return _employeePosition; }
            set
            {
                if (_employeePosition != value)
                {
                    _employeePosition = value;
                    OnPropertyChanged(nameof(EmployeePosition));
                }
            }
        }
        #endregion

        #region Commands
        private ICommand _insertDataButtonClickedCommand;
        public ICommand InsertDataButtonClickedCommand
        {
            get
            {
                return _insertDataButtonClickedCommand ?? (_insertDataButtonClickedCommand = new RelayCommand(x =>
                {
                    InsertDataButton_Clicked();
                }));
            }
        }

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
        public InsertDataWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            GetAllCompanies();
        }
        #endregion

        #region Private Methods
        private void InsertDataButton_Clicked()
        {
            switch (CurrentEntity)
            {
                case Entities.Company:
                    InsertCompany();
                    break;
                case Entities.Employee:
                    InsertEmployee();
                    break;
                default:
                    break;
            }
        }

        private void InsertCompany()
        {
            var company = new Company
            {
                Name = CompanyName,
                Industry = CompanyIndustry
            };

            _companyRepository.Insert(company);
            _companyRepository.Save();
        }

        private void InsertEmployee()
        {
            var company = _companyRepository.GetAll().FirstOrDefault(x => x.Name == "Avid");

            var employee = new Employee
            {
                Name = EmployeeName,
                Surname = EmployeeSurname,
                Age = EmployeeAge,
                Position = EmployeePosition,
                CompanyId = company.CompanyId
            };

            _employeeRepository.Insert(employee);
            _employeeRepository.Save();
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
