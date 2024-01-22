using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Principles.LiskovSubstitution
{
    public class Bird : Animal
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird Flying...");
        }

        public override void ExecuteAction()
        {
            Fly();
        }
    }
}
