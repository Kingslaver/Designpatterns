using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.SimpleFactory;

namespace Web.Factory.FactoryMethods
{
    public abstract class BaseEmployeeFactory
    {
        protected Employee _emp = null;

        public BaseEmployeeFactory(Employee emp)
        {
            this._emp = emp;

        }
        public abstract IEmployeeManager create();

        public Employee CalculateSalary()
        {
            IEmployeeManager empManager = this.create();

            this._emp.Bonus = empManager.GetBonus();
            this._emp.HourlyRate = empManager.GetHourlyRate();

            return this._emp;
        }
    }
}