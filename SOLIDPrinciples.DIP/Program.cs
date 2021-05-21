using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.DIP
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Definition
        /* The Dependency Inversion Principle(DIP) states that high-level modules/classes should not depend on low-level modules/classes.
         * Both should depend upon abstractions.Secondly, abstractions should not depend upon details.Details should depend upon abstractions.
         */
        #endregion

        #region Bad Code
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public int Salary { get; set; }
        }
        public class EmployeeBusinessLogic
        {
            EmployeeDataAccess _EmployeeDataAccess;
            public EmployeeBusinessLogic()
            {
                _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
            }
            public Employee GetEmployeeDetails(int id)
            {
                return _EmployeeDataAccess.GetEmployeeDetails(id);
            }
        }
        public class DataAccessFactory
        {
            public static EmployeeDataAccess GetEmployeeDataAccessObj()
            {
                return new EmployeeDataAccess();
            }
        }
        public class EmployeeDataAccess
        {
            public Employee GetEmployeeDetails(int id)
            {
                // In real time get the employee details from db
                //but here we are hard coded the employee details
                Employee emp = new Employee()
                {
                    ID = id,
                    Name = "Pranaya",
                    Department = "IT",
                    Salary = 10000
                };
                return emp;
            }
        }
        #endregion

        #region Good Code
        public interface IEmployeeDataAccessGoodCode
        {
            Employee GetEmployeeDetails(int id);
        }
        public class EmployeeDataAccessGoodCode : IEmployeeDataAccessGoodCode
        {
            public Employee GetEmployeeDetails(int id)
            {
                // In real time get the employee details from db
                //but here we are hardcoded the employee details
                Employee emp = new Employee()
                {
                    ID = id,
                    Name = "Pranaya",
                    Department = "IT",
                    Salary = 10000
                };
                return emp;
            }
        }
        public class DataAccessFactoryGoodCode
        {
            public static IEmployeeDataAccessGoodCode GetEmployeeDataAccessObj()
            {
                return new EmployeeDataAccessGoodCode();
            }
        }
        public class EmployeeBusinessLogicGoodCode
        {
            IEmployeeDataAccessGoodCode _EmployeeDataAccess;
            public EmployeeBusinessLogicGoodCode()
            {
                _EmployeeDataAccess = DataAccessFactoryGoodCode.GetEmployeeDataAccessObj();
            }
            public Employee GetEmployeeDetails(int id)
            {
                return _EmployeeDataAccess.GetEmployeeDetails(id);
            }
        }
        #endregion
    }
}
