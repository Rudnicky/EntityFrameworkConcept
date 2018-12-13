using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Extensions;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System.Linq;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DeleteWindowViewModel : RootDataViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private bool _isDeleteButtonEnabled;
        public bool IsDeleteButtonEnabled
        {
            get { return _isDeleteButtonEnabled; }
            set
            {
                if (_isDeleteButtonEnabled != value)
                {
                    _isDeleteButtonEnabled = value;
                    OnPropertyChanged(nameof(IsDeleteButtonEnabled));
                }
            }
        }

        private bool _isTypeOfEntityPicked;
        public bool IsTypeOfEntityPicked
        {
            get { return _isTypeOfEntityPicked; }
            set
            {
                if (_isTypeOfEntityPicked != value)
                {
                    _isTypeOfEntityPicked = value;
                    OnPropertyChanged(nameof(IsTypeOfEntityPicked));
                }
            }
        }


        private BaseEntity _selectedEntity;
        public BaseEntity SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (_selectedEntity != value)
                {
                    _selectedEntity = value;
                    OnPropertyChanged(nameof(SelectedEntity));
                }
            }
        }
        #endregion

        #region Commands
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

        private ICommand _collectionComboBoxSelectionChangedCommand;
        public ICommand CollectionComboBoxSelectionChangedCommand
        {
            get
            {
                return _collectionComboBoxSelectionChangedCommand ?? (_collectionComboBoxSelectionChangedCommand = new RelayCommand<object>(obj =>
                {
                    CollectionComboBox_SelectionChanged(obj);
                }));
            }
        }

        private ICommand _entityComboBoxSelectionChangedCommand;
        public ICommand EntityComboBoxSelectionChangedCommand
        {
            get
            {
                return _entityComboBoxSelectionChangedCommand ?? (_entityComboBoxSelectionChangedCommand = new RelayCommand<object>(obj =>
                {
                    EntityComboBox_SelectionChanged(obj);
                }));
            }
        }
        #endregion

        #region Constructor
        public DeleteWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository) 
            : base(companyRepository, employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            base.GetAllCompanies();
            base.GettAllEmployees();
        }
        #endregion

        #region Private Methods
        private void DeleteButton_Clicked()
        {
            if (SelectedEntity != null)
            {
                switch (CurrentEntity)
                {
                    case Utils.Entities.Company:

                        // delete entity
                        _companyRepository.Delete(GetCompanyFromBaseEntity(SelectedEntity));
                        _companyRepository.Save();

                        // items source needs to be refreshed
                        base.Entities.Remove(SelectedEntity);

                        // selected items shouldn't be visible at this point
                        SelectedEntity = null;

                        // disable delete button
                        IsDeleteButtonEnabled = false;

                        break;
                    case Utils.Entities.Employee:

                        // delete entity
                        _employeeRepository.Delete(GetEmployeeFromBaseEntity(SelectedEntity));
                        _employeeRepository.Save();

                        // items source needs to be refreshed
                        base.Entities.Remove(SelectedEntity);

                        // selected items shouldn't be visible at this point
                        SelectedEntity = null;

                        // disable delete button
                        IsDeleteButtonEnabled = false;

                        break;
                    default:
                        break;
                }
            }
        }

        private void CollectionComboBox_SelectionChanged(object obj)
        {
            // setup current entity
            CurrentEntity = GlobalConverters.ConvertToEntities<Entities>(obj);

            // fill entities collection
            SetupEntitiesCollection();

            // let user pick up entity
            IsTypeOfEntityPicked = true;
        }

        private void EntityComboBox_SelectionChanged(object obj)
        {
            IsDeleteButtonEnabled = true;
        }

        private Company GetCompanyFromBaseEntity(BaseEntity entity)
        {
            return _companyRepository.GetAll().FirstOrDefault(x => x.CompanyId == ((Company)entity).CompanyId);
        }

        private Employee GetEmployeeFromBaseEntity(BaseEntity entity)
        {
            return _employeeRepository.GetAll().FirstOrDefault(x => x.EmployeeId == ((Employee)entity).EmployeeId);
        }
        #endregion
    }
}
