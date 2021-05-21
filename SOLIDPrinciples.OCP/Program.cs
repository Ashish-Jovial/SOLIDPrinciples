using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.OCP
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Definition
        /* The Liskov Substitution Principle is a Substitutability principle in object-oriented programming Language. 
         * This principle states that, if S is a subtype of T, then objects of type T should be replaced with the objects of type S. 
         * In other words, we can say that objects in an application should be replaceable with the instances of their subtypes without modifying the correctness of that application. 
         */
        #endregion

        #region Bad Code
        public class InvoiceWithoutOCP
        {
            public double GetInvoiceDiscountWithoutOCP(double amount, InvoiceType invoiceType)
            {
                double finalAmount = 0;

                #region bad code explaination: If one more INvoice Type comes then we need to add another else if condition within the source code of the above GetInvoiceDiscountWithoutOCP() method which violates the OCP.
                if (invoiceType == InvoiceType.FinalInvoice)
                {
                    finalAmount = amount - 100;
                }
                else if (invoiceType == InvoiceType.ProposedInvoice)
                {
                    finalAmount = amount - 50;
                }
                return finalAmount;
                #endregion
            }
        }
        public enum InvoiceType
        {
            FinalInvoice,
            ProposedInvoice
        };
        #endregion

        #region Good Code
        public class InvoiceWithOCP
        {
            public virtual double GetInvoiceDiscountWithOCP(double amount)
            {
                return amount - 10;
            }
        }

        public class FinalInvoice : InvoiceWithOCP
        {
            public override double GetInvoiceDiscountWithOCP(double amount)
            {
                return base.GetInvoiceDiscountWithOCP(amount);
            }
        }
        public class ProposedInvoice : InvoiceWithOCP
        {
            public override double GetInvoiceDiscountWithOCP(double amount)
            {
                return base.GetInvoiceDiscountWithOCP(amount) - 40;
            }
        }
        public class RecurringInvoice : InvoiceWithOCP
        {
            public override double GetInvoiceDiscountWithOCP(double amount)
            {
                return base.GetInvoiceDiscountWithOCP(amount) - 30;
            }
        }
        #endregion
    }
}
