using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class ButtonObserver
	{
		private SingletonCalculator _calculator;

		public ButtonObserver(SingletonCalculator calculator)
		{
			_calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
		}

		public void Notify()
		{
			
		}

		public void Update()
		{

		}
	}
}
