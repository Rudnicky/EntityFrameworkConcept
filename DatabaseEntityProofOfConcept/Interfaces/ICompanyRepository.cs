namespace DatabaseEntityProofOfConcept.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Company GetSingle(int companyId);
    }
}
