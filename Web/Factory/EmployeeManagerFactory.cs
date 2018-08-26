using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Factory.FactoryMethods;
using Web.Models;

namespace Web.Factory
{
    public class EmployeeManagerFactory
    {
        public BaseEmployeeFactory GetFactory(Employee emp)
        {
            BaseEmployeeFactory returnValue = null;
            switch (emp.EmployeeTypeID)
            {
                case 1:
                    returnValue = new PermanentEmployeeFactory(emp);
                    break;
                case 2:
                    returnValue = new ContractEmployeeFactory(emp);
                    break;
            }

            return returnValue;
        }
    }
}