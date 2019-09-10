using StringCalculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        private static IStringCalculatorService _StringCalculatorService;
        public static void Main(string[] args)
        {
            _StringCalculatorService = new StringCalculatorService();
            _StringCalculatorService.Add();
        }
    }
}
