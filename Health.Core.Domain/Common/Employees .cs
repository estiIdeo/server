using System.ComponentModel.DataAnnotations;

namespace Health.Core.Domain
{
    public class Employees : BaseEntity
    {
        //  public virtual BaseEntity BaseEntity { get; set; }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public decimal Salary
        {
            get;
            set;
        }
        public string Designation
        {
            get;
            set;
        }
        public string Address { get; set; }
    }
}