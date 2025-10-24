using Domain.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Domain.BusinessDomain
{
    /// <summary>
    /// ViewModel class for handling Employee data in views (Create/Edit/List).
    /// It helps in binding both single employee and list of employees.
    /// </summary>
    public class Employee_Model
    {
        /// <summary>
        /// Holds a single employee object (used for Create/Edit view).
        /// </summary>
        [BindProperty]
        public virtual Employee? EmployeeModel { get; set; }

        /// <summary>
        /// Holds a list of employees (used for List or Grid view).
        /// </summary>
        [BindProperty]
        public virtual IList<Employee>? ListEmployeeModel { get; set; }

        /// <summary>
        /// Optional message or status info (used for success/error notifications).
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Optional flag to indicate success/failure.
        /// </summary>
        public bool IsSuccess { get; set; } = false;
    }
}
