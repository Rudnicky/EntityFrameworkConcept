using DatabaseEntityProofOfConcept.Commands;
using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class InsertDataWindowViewModel : BaseViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private ObservableCollection<BaseEntity> _typeOfEntitiesCollection = new ObservableCollection<BaseEntity>();
        public ObservableCollection<BaseEntity> TypeOfEntitiesCollection
        {
            get { return _typeOfEntitiesCollection; }
            set
            {
                if (_typeOfEntitiesCollection != value)
                {
                    _typeOfEntitiesCollection = value;
                    OnPropertyChanged(nameof(TypeOfEntitiesCollection));
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
        #endregion

        #region Constructor
        public InsertDataWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            SetupEntitiesCollection();
        }
        #endregion

        #region Private Methods
        private void InsertDataButton_Clicked()
        {

        }

        private void SetupEntitiesCollection()
        {
            TypeOfEntitiesCollection.Add(InstanceOfEntity(new Employee()));
            TypeOfEntitiesCollection.Add(InstanceOfEntity(new Company()));
        }

        private BaseEntity InstanceOfEntity(BaseEntity entity)
        {
            entity.ClassName = GetEntityClassName(entity);
            return entity;
        }

        private string GetEntityClassName(BaseEntity entity)
        {
            string fullClassName = entity.GetType().ToString();
            return fullClassName.Substring(fullClassName.IndexOf('.') + 1);
        }
        #endregion
    }
}
