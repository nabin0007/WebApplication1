using Domain.BusinessDomain;
using Domain.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {

       // [BindProperty]
     //   public Employee_Model? Models { get; set; }

        [BindProperty]
        public Employee_Model Models { get; set; } = new Employee_Model();


        // Simulated in-memory DB
        private static List<Employee> EmployeeDb = new List<Employee>
        {
            new Employee { EmployeeID = 1, FirstName = "Nobin", LastName = "Huda", Division = "IT", Building = "Head Office", Title = "Manager", Room = "305" },
            new Employee { EmployeeID = 2, FirstName = "Milad", LastName = "Sotudeh", Division = "Design", Building = "Branch A", Title = "Painter", Room = "102" }
        };

        public void OnGet()
        {
           // Models = new Employee_Model();
            Models.ListEmployeeModel = EmployeeDb;
        }

        public IActionResult OnPostSubmit_AccSubHead()
        {
            if (Models.EmployeeModel != null)
            {
                var existing = EmployeeDb.Find(e => e.EmployeeID == Models.EmployeeModel.EmployeeID);
                if (existing != null)
                {
                    // Edit
                    existing.FirstName = Models.EmployeeModel.FirstName;
                    existing.LastName = Models.EmployeeModel.LastName;
                    existing.Division = Models.EmployeeModel.Division;
                    existing.Building = Models.EmployeeModel.Building;
                    existing.Title = Models.EmployeeModel.Title;
                    existing.Room = Models.EmployeeModel.Room;
                }
                else
                {
                    // Add new
                    Models.EmployeeModel.EmployeeID = EmployeeDb.Count + 1;
                    EmployeeDb.Add(Models.EmployeeModel);
                }
            }
            return new JsonResult(new { success = true });
        }

        public IActionResult OnPostDeleteRow([FromBody] long employeeID)
        {
            var existing = EmployeeDb.Find(e => e.EmployeeID == employeeID);
            if (existing != null)
            {
                EmployeeDb.Remove(existing);
                return new JsonResult(new { success = true });
            }
            return StatusCode(410, "Employee not found");
        }

        public IActionResult OnGetEmp_Data()
        {
          //  return new JsonResult(EmployeeDb);
            return new JsonResult(EmployeeDb);
        }

    }
}
