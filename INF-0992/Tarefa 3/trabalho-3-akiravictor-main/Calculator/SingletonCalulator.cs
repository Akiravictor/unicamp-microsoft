using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class SingletonCalulator
	{
		public static SingletonCalulator Instance;

		private double currentValue = 0;

		protected SingletonCalulator()
		{

		}

		public static SingletonCalulator GetInstance()
		{
			if(Instance == null)
			{
				Instance = new SingletonCalulator();
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
