//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntityProofOfConcept
{
    using DatabaseEntityProofOfConcept.Utils;
    using System;

    public partial class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Position { get; set; }
        public Nullable<int> CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
