using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult DeptList()
        {
            List<Department> departmentList = context.Department
                .Include(d=>d.Emps)
                .ToList();
            
            return View("DeptList", departmentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");  
        }

        [HttpPost] //Filter
        public IActionResult SaveAdd(Department newDeptFromRequest)
        {
            if(newDeptFromRequest.DepartmentName != null && newDeptFromRequest.ManagerName != null)
            {
                context.Department.Add(newDeptFromRequest);
                context.SaveChanges();
                //return View("DeptList", context.Department.ToList());
                //Call Action from another action
                return RedirectToAction("DeptList");
            }
            return View("Add", newDeptFromRequest);//Model Department
        }
    }
}
 