using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.SimpleFactory;

namespace Web.Factory.FactoryMethods
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(Employee emp) : base(emp)
        {
        }

        public override IEmployeeManager create()
        {
            ContractEmployeeManager empManager = new ContractEmployeeManager();
            this._emp.EmployeeAllowances.Add(new EmployeeAllowance { MedicalAllowance = empManager.GetMedicalAllowance() });
            return empManager;
        }

    }
}