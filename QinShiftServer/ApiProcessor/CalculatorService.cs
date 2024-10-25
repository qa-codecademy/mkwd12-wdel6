using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessor
{
    public interface ICalculatorService { 
        int Add(int first, int second);
        int Double(int number);
        int Subtract(int first, int second);

    }


    public class CalculatorService: ICalculatorService
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
