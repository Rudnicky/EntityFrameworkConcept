using DatabaseEntityProofOfConcept.Interfaces;
using System.Linq;

namespace DatabaseEntityProofOfConcept.Utils
{
    public class CompanyRepository : GenericRepository<TestDatabaseEntities, Company>, ICompanyRepository
    {
        public Company GetSingle(int companyId)
        {
            var query = GetAll().FirstOrDefault(x => x.CompanyId == companyId);
            return query;
        }
    }
}
