using DatabaseEntityProofOfConcept.Interfaces;
using System.Linq;

namespace DatabaseEntityProofOfConcept.Utils
{
    public class EmployeeRepository : GenericRepository<TestDatabaseEntities, Employee>, IEmployeeRepository
    {
        public Employee GetSingle(int employeeId)
        {
            var query = GetAll().FirstOrDefault(x => x.EmployeeId == employeeId);
            return query;
        }
    }
}
