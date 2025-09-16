using ITI_MVC.Models;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public EmployeeController()
        {
            
        }

        public IActionResult EmployeesList()
        {
            return View("EmployeesList", context.Employee.ToList());
        }

        //Handle Link
        public IActionResult Edit(int id)
        {
            Employee EmpModel = context.Employee.FirstOrDefault(e=>e.Id==id);
            return View("Edit", EmpModel);
        }

        [HttpPost]
        public IActionResult SaveEdit(Employee employeeFromRequest, int id)
        {
            if (employeeFromRequest.Name != null)
            {
                  Employee empFromDB = context.Employee.FirstOrDefault(e => e.Id == id);
                  empFromDB.Name = employeeFromRequest.Name;
                  empFromDB.Address = employeeFromRequest.Address;
                  empFromDB.Salary = employeeFromRequest.Salary;
                  empFromDB.DeptID = employeeFromRequest.DeptID;
                  empFromDB.ImageURL = employeeFromRequest.ImageURL;
                  empFromDB.JobTitle = employeeFromRequest.JobTitle;
                  context.SaveChanges();
                  return RedirectToAction("EmployeesList");
            }
            return View("Edit", employeeFromRequest);
        }

        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 35;
            List<string> branches = new List<string>();
            branches.Add("Ismailia");
            branches.Add("Portsaid");
            branches.Add("Cairo");


            Employee EmpModel = context.Employee.FirstOrDefault(e => e.Id == id);
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;
            ViewData["Color1"] = "Blue";
            ViewBag.Color2 = "Red";

            return View("Details", EmpModel);
        }

        public IActionResult DetailsVM(int id)
        {
            Employee EmpModelVM = context.Employee
                .Include(e => e.Dept)
                .FirstOrDefault(e => e.Id == id);

            List<string> branches = new List<string>();
            branches.Add("Ismailia");
            branches.Add("Portsaid");
            branches.Add("Cairo");

            //Declare viewmodel
            Emp_Dept_Color_Temp_Msg_BranchesViewModel EmpVM = 
                new Emp_Dept_Color_Temp_Msg_BranchesViewModel();
            //Mapping
            EmpVM.EmpName = EmpModelVM.Name;
            EmpVM.DeptName = EmpModelVM.Dept.DepartmentName;
            EmpVM.Color = "Red";
            EmpVM.Temp = 35;
            EmpVM.Msg = "Hello From VM";
            EmpVM.Branches = branches;

            return View("DetailsVM", EmpVM);//Emp_Dept_Color_Temp_Msg_BranchesViewModel
        }

        public IActionResult AllEmpDetails()
        {
            Employee AllEmps = context.Employee
                .SingleOrDefault(e => e.Id == 3);

            return View("AllEmpDetails", AllEmps);
        }
    }
}
