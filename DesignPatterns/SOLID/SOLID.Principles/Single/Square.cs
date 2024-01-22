using System;

namespace SOLID.Principles.Single
{
    // Achieve High Cohesion and Loose Coupling
    public class Square
    {
        public int Side { get; set; }

        // High Cohesion between CalculateArea() and CalculatePerimeter()
        public int CalculateArea() => Side * Side;
        public int CalculatePerimeter() => Side * 4;

        // Low Cohesion between Draw() and the rest.
        public void Draw(string resolution)
        {
            if(resolution == "Wide")
            {
                Console.WriteLine("Wide");
            }
            else if(resolution == "SuperWide")
            {
                Console.WriteLine("SuperWide");
            }
        }

        // Low Cohesion between Draw() and the rest.
        // Tight Coupling between Save and the Square
        // Solution: move into a Repository class (Loose Coupling)
        public void Save(Square s)
        {
            // Save into DB
        }
    }
}
