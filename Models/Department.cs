namespace ITI_MVC.Models
{
    public class Department
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<Employee>? Emps { get; set; }
    }
}
