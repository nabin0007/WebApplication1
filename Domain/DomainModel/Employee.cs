using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModel
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Division { get; set; }
        public string? Building { get; set; }
        public string? Title { get; set; }
        public string? Room { get; set; }

      
    }
}
