using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
    public class CalculatorCommand : Command
    {
        private string operation;
        private double operand;
        private readonly SingletonCalculator _calculator;

        public CalculatorCommand(SingletonCalculator calculator, string command, double value)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            operation = command;
            operand = value;
        }

        public override void Execute()
        {
            ExecuteOperation();
        }

        public override void Unexecute()
        {
            ExecuteReverseOperation();
		}

        private void ExecuteOperation()
        {
            switch (operation)
            {
                case "sum":
                    _calculator.currentValue += operand;
                    break;

                case "subtract":
                    _calculator.currentValue -= operand;
                    break;

                case "multiply":
                    _calculator.currentValue *= operand;
                    break;

                case "divide":
                    _calculator.currentValue /= operand;
                    break;
            }

            _calculator.SetDisplay(_calculator.currentValue.ToString());
        }

        private void ExecuteReverseOperation()
        {
            switch (operation)
            {
                case "sum":
                    _calculator.currentValue -= operand;
					break;

                case "subtract":
                    _calculator.currentValue += operand;
					break;

                case "multiply":
                    _calculator.currentValue /= operand;
                    break;

                case "divide":
                    _calculator.currentValue *= operand;
					break;
            }
        }
    }
}
