using System;

namespace SOLID._04_Interface_Segregation
{
    public interface ICommonPrinterTasks //<- Accomplishes more reusability.
    {
        bool PrintContent(string content);
        bool ScanContent(string content);
        bool PhotoCopyContent(string content);
    }
    public interface ICannonMG2470Tasks : ICommonPrinterTasks //<- Not sure if neccesary.
    {
    }
    public interface IHPLaserJetTasks : ICommonPrinterTasks
    {
        bool FaxContent(string content);
        bool PrintDuplexContent(string content);
    }

    public class HPLaserJet : IHPLaserJetTasks
    {
        public bool PrintContent(string content)
        {
            Console.WriteLine("Print Done"); return true;
        }
        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done"); return true;
        }
        public bool FaxContent(string content)
        {
            Console.WriteLine("Fax Done"); return true;
        }
        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done"); return true;
        }
        public bool PrintDuplexContent(string content)
        {
            Console.WriteLine("Print Duplex Done"); return true;
        }
    }

    public class CannonMG2470 : ICannonMG2470Tasks
    {
        public bool PrintContent(string content)
        {
            Console.WriteLine("Print Done"); return true;
        }
        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done"); return true;
        }
        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done"); return true;
        }
    }
}
