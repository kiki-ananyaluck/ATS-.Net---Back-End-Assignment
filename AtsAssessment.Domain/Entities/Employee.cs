namespace AtsAssessment.Domain.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string Emp_Code { get; set; }
        public string Full_Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public long? Department_Id { get; set; }
        public Department? Department { get; set; }

    }
}
