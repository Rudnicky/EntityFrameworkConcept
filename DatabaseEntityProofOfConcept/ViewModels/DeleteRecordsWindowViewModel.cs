using DatabaseEntityProofOfConcept.Interfaces;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DeleteRecordsWindowViewModel : RootDataViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public DeleteRecordsWindowViewModel(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository) 
            : base(companyRepository, employeeRepository)
        {
            this._companyRepository = companyRepository;
            this._employeeRepository = employeeRepository;

            base.GetAllCompanies();
            base.GettAllEmployees();
        }
        #endregion
    }
}
