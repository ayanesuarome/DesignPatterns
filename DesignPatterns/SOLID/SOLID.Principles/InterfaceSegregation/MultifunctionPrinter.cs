using System;

namespace SOLID.Principles.InterfaceSegregation
{
    class MultifunctionPrinter : IPrint, IScan, IFax
    {
        public void Fax()
        {
            throw new NotImplementedException();
        }

        public object GetPrintSpoolDetails()
        {
            throw new NotImplementedException();
        }

        public object InternetFax()
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
