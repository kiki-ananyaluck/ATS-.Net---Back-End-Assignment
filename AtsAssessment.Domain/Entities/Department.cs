namespace AtsAssessment.Domain.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public string Department_Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
