using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SimpleFactory
{
    public class PermanentEmployee : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10;
        }

        public decimal GetHourlyRate()
        {
            return 15;
        }
    }
}