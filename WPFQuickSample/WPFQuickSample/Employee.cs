using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuickSample
{
    public class Employee
    {
        public int EmployeeID
        {
            get;
            set;
        }
        public string JobTitle
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public int Income
        {
            get;
            set;
        }

        public Employee()
        {

        }

        public Employee(int employeeID, string jobTitle, string name, int age, int income)
        {
            this.EmployeeID = employeeID;
            this.JobTitle = jobTitle;
            this.Name = name;
            this.Age = age;
            this.Income = income;
        }
    }
}
