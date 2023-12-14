using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        double Sum(double value);
        double Subtruct(double value);
        double Multiply(double value);
        double Divide(double value);
        double Sum(int value);
        double Subtruct(int value);
        double Multiply(int value);
        double Divide(int value);
    }
}
