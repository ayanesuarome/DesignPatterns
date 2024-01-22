using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Principles.Single
{
    // Achieve High Cohesion and Loose Coupling
    public class Employee
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Type { get; set; }

        // Low Cohesion between CalculateTax() and the properties.
        public void CalculateTax()
        {
            if (Type == "fulltime")
            {
                // Tax for fulltime employee
            }
            if (Type == "contract")
            {
                // Tax for contract employee
            }
        }

        // Low Cohesion between Save, CalculateTax() and the properties.
        // Tight Coupling between Save and the Employee
        // Solution: move into a Repository class (Loose Coupling)
        public void Save()
        {
            // Save into DB
        }
    }
}
