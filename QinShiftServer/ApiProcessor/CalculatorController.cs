using ServerTwo.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessor
{
    public class CalculatorController : IController
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Double(int number)
        {
            return number * 2;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
        }
    }
}
