using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.ISP
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Definition
        /*
         * The Interface Segregation Principle states that “Clients should not be forced to implement any methods they don’t use. 
         * Rather than one fat interface, numerous little interfaces are preferred based on groups of methods with each interface serving one submodule“.
         */

        #endregion

        #region Bad Code
        // Forcing a class to provide the body of an interface method means violating the Interface Segregation Principle
        public interface IPrinterTasksBadCode
        {
            void Print(string PrintContent);
            void Scan(string ScanContent);
            void Fax(string FaxContent);
            void PrintDuplex(string PrintDuplexContent);
        }
        public class HPLaserJetPrinter : IPrinterTasksBadCode
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }
            public void Fax(string FaxContent)
            {
                Console.WriteLine("Fax content");
            }
            public void PrintDuplex(string PrintDuplexContent)
            {
                Console.WriteLine("Print Duplex content");
            }
        }
        public class LiquidInkjetPrinter : IPrinterTasksBadCode
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }

            // Following methods are not required, despite of this we need to implement.
            public void Fax(string FaxContent)
            {
                throw new NotImplementedException();
            }
            public void PrintDuplex(string PrintDuplexContent)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Good Code
        public interface IPrinterTasks
        {
            void Print(string PrintContent);
            void Scan(string ScanContent);
        }
        interface IFaxTasks
        {
            void Fax(string content);
        }
        interface IPrintDuplexTasks
        {
            void PrintDuplex(string content);
        }

        public class HPLaserJetPrinterGoodCode : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }
            public void Fax(string FaxContent)
            {
                Console.WriteLine("Fax content");
            }
            public void PrintDuplex(string PrintDuplexContent)
            {
                Console.WriteLine("Print Duplex content");
            }
        }
        class LiquidInkjetPrinterGoodCode : IPrinterTasks
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }
        }
        #endregion
    }
}
