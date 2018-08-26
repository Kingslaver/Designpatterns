using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.SimpleFactory
{
    public interface IEmployeeManager
    {
        decimal GetHourlyRate();
        decimal GetBonus();
    }
}
