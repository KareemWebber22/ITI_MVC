namespace ITI_MVC.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string? ManagerName { get; set; }

        public List<Employee>? Emps { get; set; }
    }
}
 