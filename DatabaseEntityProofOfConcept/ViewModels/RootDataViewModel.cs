using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System.Collections.ObjectModel;
using System.Linq;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public abstract class RootDataViewModel : BaseViewModel
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

        private ObservableCollection<BaseEntity> _entities = new ObservableCollection<BaseEntity>();
        public ObservableCollection<BaseEntity> Entities
        {
            get { return _entities; }
            set
            {
                if (_entities != value)
                {
                    _entities = value;
                    OnPropertyChanged(nameof(Entities));
                }
            }
        }
        #endregion

        #region Constructor
        public RootDataViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;
        }
        #endregion

        #region Protected Methods
        protected void GetAllCompanies()
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

        protected void GettAllEmployees()
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

        protected void SetupEntitiesCollection()
        {
            switch (CurrentEntity)
            {
                case Utils.Entities.Company:
                    Entities = new ObservableCollection<BaseEntity>(Companies);
                    break;
                case Utils.Entities.Employee:
                    Entities = new ObservableCollection<BaseEntity>(Employees);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
