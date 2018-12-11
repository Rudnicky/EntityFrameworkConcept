namespace DatabaseEntityProofOfConcept.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetSingle(int employeeId);
    }
}
