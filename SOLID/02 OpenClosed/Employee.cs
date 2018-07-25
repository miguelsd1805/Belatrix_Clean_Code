namespace SOLID._02_OpenClosed
{
    public class EmployeePermanent : Employee
    {
        public EmployeePermanent(int id, string name) : base (id,name, "Permanent") {}

        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .1M;
        }
    }

    public abstract class Employee
    {
        public int ID { get; set; }
        public string EmployeeType { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name, string type)
        {
            this.ID = id;
            this.Name = name;
            this.EmployeeType = type;
        }
        public virtual decimal CalculateBonus(decimal salary)
        {
            return salary * .05M;
        }
    }
}