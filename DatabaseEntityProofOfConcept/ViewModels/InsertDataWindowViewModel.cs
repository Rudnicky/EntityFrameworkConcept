using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System;
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
        }
        #endregion

        #region Private Methods
        private void InsertDataButton_Clicked()
        {
            var company = new Company();
            company.Name = CompanyName;
            company.Industry = CompanyIndustry;

            _companyRepository.Insert(company);
            _companyRepository.Save();
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
