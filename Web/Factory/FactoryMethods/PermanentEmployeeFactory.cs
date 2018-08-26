using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.SimpleFactory;

namespace Web.Factory.FactoryMethods
{
    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(Employee emp) : base(emp)
        {
        }

        public override IEmployeeManager create()
        {
            PermanentEmployeeManager empManager = new PermanentEmployeeManager();
            this._emp.EmployeeAllowances.Add(new EmployeeAllowance { HRA = empManager.GetHRA() });
            return empManager;
        }

    }
}