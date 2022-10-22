using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class SingletonCalculator
	{
		private static SingletonCalculator? _instance;
		private ButtonObserver? _observer;

		private double currentValue = 0;
		public string lastKeyPressed { get; private set; } = "";

		protected SingletonCalculator()
		{
		}

		public static SingletonCalculator GetInstance()
		{
			if(_instance == null)
			{
				_instance = new SingletonCalculator();
			}

			return _instance;
		}

		public void AddObserver(ButtonObserver observer)
		{
			_observer = observer ?? throw new ArgumentNullException(nameof(observer));
		}


		public void ButtonPressed(string button)
		{
			if(_observer != null)
			{
				lastKeyPressed = button;
				_observer.Notify();
			}
		}
	}
}
