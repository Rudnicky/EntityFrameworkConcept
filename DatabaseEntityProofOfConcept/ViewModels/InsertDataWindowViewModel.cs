using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Extensions;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System.Linq;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class InsertDataWindowViewModel : RootDataViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private bool _isInsertEnabled;
        public bool IsInsertEnabled
        {
            get { return _isInsertEnabled; }
            set
            {
                if (_isInsertEnabled != value)
                {
                    _isInsertEnabled = value;
                    OnPropertyChanged(nameof(IsInsertEnabled));
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

        private ICommand _comboBoxSelectionChangedCommand;
        public ICommand ComboBoxSelectionChangedCommand
        {
            get
            {
                return _comboBoxSelectionChangedCommand ?? (_comboBoxSelectionChangedCommand = new RelayCommand<object>(x =>
                {
                    ComboBoxSelectionChanged(x);
                }));
            }
        }
        #endregion

        #region Constructor
        public InsertDataWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
            : base (companyRepository, employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            base.GetAllCompanies();

            // TODO: validation must be done in different way
            IsInsertEnabled = true;
        }
        #endregion

        #region Private Methods
        private void InsertDataButton_Clicked()
        {
            switch (CurrentEntity)
            {
                case Utils.Entities.Company:
                    InsertCompany();
                    break;
                case Utils.Entities.Employee:
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

        private void ComboBoxSelectionChanged(object obj)
        {
            if (obj != null)
            {
                IsInsertEnabled = true;
            }
        }

        private void SelectionChanged(object obj)
        {
            CurrentEntity = GlobalConverters.ConvertToEntities<Entities>(obj);

            IsInsertEnabled = false;
        }
        #endregion
    }
}
