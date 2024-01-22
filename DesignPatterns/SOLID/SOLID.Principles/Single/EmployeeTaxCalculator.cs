namespace SOLID.Principles.Single
{
    public class EmployeeTaxCalculator
    {
        public void CalculateTax(Employee e)
        {
            if (e.Type == "fulltime")
            {
                // Tax for fulltime employee
            }
            if (e.Type == "contract")
            {
                // Tax for contract employee
            }
        }
    }
}
