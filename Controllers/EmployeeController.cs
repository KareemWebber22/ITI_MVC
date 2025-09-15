using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public EmployeeController()
        {
            
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
            ViewData["Color"] = "Blue";
            ViewBag.Color = "Red";

            return View("Details", EmpModel);
        }
    }
}
