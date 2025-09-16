using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    public class BindingController : Controller
    {
        //Request HTML Data
        //Binding Primitive (int, string,....)
        //Binding/TestPrimitive?name=ahmed&age=12&id=10&color=red&color=blue
        //<form action= "Binding/TestPrimitive" method="get">
        //    <input type="text" name="name">
        //    <input type="text" name="age">

        public IActionResult TestPrimitive(string name, int age, int id, string[] color)
        {
            return Content($"{name} \t {age}");
        }

        //Binding Collection
        //Binding/TestDict?Phones[Kareem]=123&Phones[Yahia]=456
        public IActionResult TestDict(Dictionary<string, string> Phones, string name)
        {
            Phones["ahmed"] = "1234";
            return Content("Ok");
        }

        //Binding/TestObj/3?DepartmentName=Automation&ManagerName=MostafaElghannam&color=red
        public IActionResult TestObj(Department deptObj, string color)
        {
            return Content("Obj");
        }
    }
}
 