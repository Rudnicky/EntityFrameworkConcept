using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntityProofOfConcept.Interfaces;

namespace DatabaseEntityProofOfConcept.ViewModels
{
    public class DeleteWindowViewModel : RootDataViewModel
    {
        #region Fields & Properties
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
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
    }
}
