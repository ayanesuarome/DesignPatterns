using System;

namespace SOLID.Principles.InterfaceSegregation
{
    class CannonPrinter : IPrint
    {
        public object GetPrintSpoolDetails()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
