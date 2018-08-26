using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SimpleFactory
{
    public class ContractEmployee : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5;
        }

        public decimal GetHourlyRate()
        {
            return 20;
        }
    }
}