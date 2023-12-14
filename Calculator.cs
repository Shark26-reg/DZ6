using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    internal class Calculator : ICalc
    {
            public event EventHandler<EventArgs> GotResult;

            public double Result = 0;           

            public double Sum(double value)
            {
                Result += value;
                RaiseEvent();
                return Result;
            }
            public double Subtruct(double value)
            {
                Result -= value;
                RaiseEvent();
                return Result;
            }

            public double Multiply(double value)
            {
                Result *= value;
                RaiseEvent();
                return Result;
            }
            public double Divide(double value)
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("На 0 делить нельзя");
                }
                else
                {
                    Result /= value;
                    RaiseEvent();
                    return Result;
                }

            }
            public double Sum(int value)
            {
                return Sum((double)value);
            }

            public double Subtruct(int value)
            {
                return Subtruct((double)value);
            }            

            public double Multiply(int value)
            {
                return Multiply((double)value);
            }

            public double Divide(int value)
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("На 0 делить нельзя");
                }
                return Divide((double)value);
            }

        private void RaiseEvent()
            {
                GotResult?.Invoke(this, EventArgs.Empty);
            }

    }
}

