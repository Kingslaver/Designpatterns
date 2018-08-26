using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.SimpleFactory
{
    public class EmployeeManagerFactory
    {
        IEmployeeManager IEM = null;
        Employee emp = null;
        public EmployeeManagerFactory(Employee emp)
        {
            switch (emp.EmployeeTypeID)
            {
                case 1:
                    this.IEM = new PermanentEmployee();
                    break;
                case 2:
                    this.IEM = new ContractEmployee();
                    break;
            }

            this.emp = emp;
        }



        public void CalculateSalary()
        {
            this.emp.Bonus = this.IEM.GetBonus();
            this.emp.HourlyRate = this.IEM.GetHourlyRate();
        }

    }
}