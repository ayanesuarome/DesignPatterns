using System;

namespace SOLID.Principles.LiskovSubstitution
{
    public class Ostrich : Animal
    {
        //public override void Fly()
        //{
        //    throw new NotSupportedException("Ostrich cannot fly");
        //}

        public void Run()
        {
            Console.WriteLine("Ostrich running...");
        }

        public override void ExecuteAction()
        {
            Run();
        }
    }
}
