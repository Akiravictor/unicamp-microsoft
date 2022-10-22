using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
	public class SingletonCalculator : Subscriber
	{
		private static SingletonCalculator? _instance;
		private readonly ButtonHandler _buttonHandler;
		private readonly CalculatorUI _ui;

		private StringBuilder display;
		private bool dotPressed = false;
		protected SingletonCalculator(ButtonHandler buttonHandler, CalculatorUI ui)
		{
			_buttonHandler = buttonHandler;
			_ui = ui;
			display = new StringBuilder();
		}

		public static SingletonCalculator GetInstance(ButtonHandler buttonHandler, CalculatorUI ui)
		{
			_ = buttonHandler ?? throw new ArgumentNullException(nameof(buttonHandler));
			_ = ui ?? throw new ArgumentNullException(nameof(ui));

			_instance ??= new SingletonCalculator(buttonHandler, ui);

			return _instance;
		}

		public override void Update()
		{
			switch (_buttonHandler.keyPressed)
			{
				case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
					NumberPressed(_buttonHandler.keyPressed);
					break;

				case ".":
					DotPressed();
					break;

				case "clear":
					Clear();
                    break;

				case "sum":
					Sum();
					break;

				case "subtract":
					Subtract();
					break;

				case "multiply":
					Multiply();
					break;

				case "divide":
					Divide();
                    break;

				case "undo":
					Undo();
                    break;

				case "redo":
					Redo();
                    break;

				case "equal":
					Equal();
                    break;

				case "pi":
					Pi();
					break;
            }

            ShowDisplay();

        }

		private void ShowDisplay()
		{
			_ui.SetDisplayText(display.ToString());
		}

		private void NumberPressed(string key)
		{
            display.Append(_buttonHandler.keyPressed);
        }

		private void DotPressed()
		{
            if (!dotPressed)
            {
                dotPressed = true;
                display.Append(_buttonHandler.keyPressed);
            }
        }

		private void Clear()
		{
            display.Clear();
            display.Append("0");
        }

		private void Sum()
		{

		}

		private void Subtract()
		{

		}

		private void Multiply()
		{

		}

		private void Divide()
		{

		}

		private void Equal()
		{

		}

		private void Undo()
		{

		}

		private void Redo()
		{

		}

		private void Pi()
		{

		}

	}
}
