using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.SRP
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Definition
        /* The Single Responsibility Principle states that "Each software module or class should have only one reason to change". 
         * In other words, we can say that each module or class should have only one responsibility to do.
         */
        #endregion

        #region Bad Code
        public class InvoiceBadCode
        {
            public long InvAmount { get; set; }
            public DateTime InvDate { get; set; }
            public void AddInvoice()
            {
                try
                {
                    // Here we need to write the Code for adding invoice
                    // Once the Invoice has been added, then send the  mail
                    MailMessage mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
                    this.SendInvoiceEmail(mailMessage);
                }
                catch (Exception ex)
                {
                    System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
                }
            }
            public void DeleteInvoice()
            {
                try
                {
                    //Here we need to write the Code for Deleting the already generated invoice
                }
                catch (Exception ex)
                {
                    System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
                }
            }
            public void SendInvoiceEmail(MailMessage mailMessage)
            {
                try
                {
                    // Here we need to write the Code for Email setting and sending the invoice mail
                }
                catch (Exception ex)
                {
                    System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
                }
            }
        }
        #endregion

        #region Good Code
        public interface ILogger
        {
            void Info(string info);
            void Debug(string info);
            void Error(string message, Exception ex);
        }
        public class Logger : ILogger
        {
            public Logger()
            {
                // here we need to write the Code for initialization 
                // that is Creating the Log file with necesssary details
            }
            public void Info(string info)
            {
                // here we need to write the Code for info information into the ErrorLog text file
            }
            public void Debug(string info)
            {
                // here we need to write the Code for Debug information into the ErrorLog text file
            }
            public void Error(string message, Exception ex)
            {
                // here we need to write the Code for Error information into the ErrorLog text file
            }
        }
        public class MailSender
        {
            public string EMailFrom { get; set; }
            public string EMailTo { get; set; }
            public string EMailSubject { get; set; }
            public string EMailBody { get; set; }
            public void SendEmail()
            {
                // Here we need to write the Code for sending the mail
            }
        }
        public class InvoiceGoodCode
        {
            public long InvAmount { get; set; }
            public DateTime InvDate { get; set; }
            private ILogger fileLogger;
            private MailSender emailSender;
            public InvoiceGoodCode()
            {
                fileLogger = new Logger();
                emailSender = new MailSender();
            }
            public void AddInvoice()
            {
                try
                {
                    fileLogger.Info("Add method Start");
                    // Here we need to write the Code for adding invoice
                    // Once the Invoice has been added, then send the  mail
                    emailSender.EMailFrom = "emailfrom@xyz.com";
                    emailSender.EMailTo = "emailto@xyz.com";
                    emailSender.EMailSubject = "Single Responsibility Princile";
                    emailSender.EMailBody = "A class should have only one reason to change";
                    emailSender.SendEmail();
                }
                catch (Exception ex)
                {
                    fileLogger.Error("Error Occurred while Generating Invoice", ex);
                }
            }
            public void DeleteInvoice()
            {
                try
                {
                    //Here we need to write the Code for Deleting the already generated invoice
                    fileLogger.Info("Delete Invoice Start at @" + DateTime.Now);
                }
                catch (Exception ex)
                {
                    fileLogger.Error("Error Occurred while Deleting Invoice", ex);
                }
            }
        }
        #endregion
    }
}
