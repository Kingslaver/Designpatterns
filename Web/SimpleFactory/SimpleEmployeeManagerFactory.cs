using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.SimpleFactory
{
    public class SimpleEmployeeManagerFactory
    {
        IEmployeeManager IEM = null;
        Employee emp = null;
        public SimpleEmployeeManagerFactory(Employee emp)
        {
            switch (emp.EmployeeTypeID)
            {
                case 1:
                    this.IEM = new PermanentEmployeeManager();
                    break;
                case 2:
                    this.IEM = new ContractEmployeeManager();
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