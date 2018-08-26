using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SimpleFactory
{
    public class PermanentEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10;
        }

        public decimal GetHourlyRate()
        {
            return 15;
        }

        public decimal GetHRA()
        {
            return 150;
        }
    }
}