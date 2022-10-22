using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class SingletonCalculator
	{
		public static SingletonCalculator? instance;

		private double currentValue = 0;
		private char lastKeyPressed;

		protected SingletonCalculator()
		{
		}

		public static SingletonCalculator GetInstance()
		{
			if(instance == null)
			{
				instance = new SingletonCalculator();
			}

			return instance;
		}

		public void ButtonPressed(string button)
		{

		}
	}
}
