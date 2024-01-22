using System;

namespace SOLID.Principles.InterfaceSegregation
{
    class HPPrinterScanner : IPrint, IScan
    {
        public object GetPrintSpoolDetails()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Scan()
        {
            throw new NotImplementedException();
        }

        public object ScanPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
