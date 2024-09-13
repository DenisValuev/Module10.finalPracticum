using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Models
{
    class Calc : ICalculate
    {
        ILogger Logger { get; }
        public Calc(ILogger logger)
        {
            Logger = logger;
        }
        double ICalculate.Calculate(string value)
        {

            Logger.Event("Calculate начал свою работу");
            double result = Convert.ToDouble(new DataTable().Compute(value, null));
            Logger.Event("Calculate окончил свою работу");
            return result;
        }
    }
    public interface ICalculate
    {
        double Calculate(string value);
    }
}
