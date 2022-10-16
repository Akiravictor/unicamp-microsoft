using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class SingletonCalculator
	{
		public static SingletonCalculator? Instance;
		public ButtonObserver observer;

		private double currentValue = 0;

		protected SingletonCalculator()
		{
			observer = new();
		}

		public static SingletonCalculator GetInstance()
		{
			if(Instance == null)
			{
				Instance = new SingletonCalculator();
			}

			return Instance;
		}

		public void Sum()
		{

		}

		public void Subtract()
		{

		}

		public void Multiply()
		{

		}

		public void Divide()
		{

		}

		public void Clear()
		{

		}

		public void Equal()
		{

		}
	}
}
