using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult DeptList()
        {
            List<Department> departmentList = context.Department
                .ToList();
            
            return View("DeptList", departmentList);
        }
    }
}
 