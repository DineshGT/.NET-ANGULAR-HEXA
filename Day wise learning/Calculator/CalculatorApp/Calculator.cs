using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public double Divide(int a,int b)
        {  
                return a / b;
        }

        public double Mulitple(int a,int b)
        {
            return a * b;
        }
    }
}
