using ServerTwo.Interface;
using ServerTwo.Interface.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessor
{
    public class CalculatorController : IController
    {
        private readonly ICalculatorService _service;

        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        [HttpGet("add")]
        public int AddTwoIntegers(int first, int second)
        {
            return _service.Add(first, second);
        }

        [HttpPost]
        public int Double(int number)
        {
            return _service.Double(number);
        }

        public int Subtract(int first, int second)
        {
            return _service.Subtract(first, second);
        }
    }
}
