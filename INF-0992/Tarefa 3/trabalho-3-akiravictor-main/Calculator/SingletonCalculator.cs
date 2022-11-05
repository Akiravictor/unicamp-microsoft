using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class3.Calculator
{
	public class SingletonCalculator : Subscriber
	{
		private static SingletonCalculator? _instance;
		private readonly ButtonHandler _buttonHandler;
		private readonly CalculatorUI _ui;

		private StringBuilder display;
		private bool dotPressed = false;
		private bool cmdPressed = false;
		private bool waitValue = false;

		private string lastCommand = "";

		public double currentValue = 0;
		private List<Command> commandHistory = new List<Command>();
		private int cmdIndex = 0;

		protected SingletonCalculator(ButtonHandler buttonHandler, CalculatorUI ui)
		{
			_buttonHandler = buttonHandler;
			_ui = ui;
			display = new StringBuilder();

			display.Append(currentValue.ToString());
			_ui.SetDisplayText(display.ToString());
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
				case "subtract":
				case "multiply":
				case "divide":
					IssueCommand(_buttonHandler.keyPressed);
                    break;

				case "undo":
					Undo();
                    break;

				case "equal":
					ExecuteLastCommand();
                    break;

				case "redo":
					Redo();
                    break;

				case "pi":
					Pi();
					break;
            }

            ShowDisplay();

        }

		public void SetDisplay(string value)
		{
			display.Clear();
			display.Append(value);
		}

		private void ShowDisplay()
		{
			_ui.SetDisplayText(display.ToString());
		}

		private void NumberPressed(string key)
		{
			if (cmdPressed)
			{
				display.Clear();
				cmdPressed = false;
			}

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

		private void IssueCommand(string command)
		{
			_ = _instance ?? throw new InvalidOperationException();
			double value = double.Parse(display.ToString());

			cmdPressed = true;

			if (string.IsNullOrEmpty(lastCommand))
			{
				currentValue = value;
				lastCommand = command;
				waitValue = true;
			}
			else
			{
				if (waitValue)
				{
					Command cmd = new CalculatorCommand(_instance, lastCommand, value);
					cmd.Execute();
					commandHistory.Add(cmd);
					cmdIndex++;

					lastCommand = command;
					waitValue = true;
				}
			}
		}


		private void ExecuteLastCommand()
		{
			_ = _instance ?? throw new InvalidOperationException();
			double value = double.Parse(display.ToString());
			Command cmd = new CalculatorCommand(_instance, lastCommand, value);
			cmd.Execute();
			commandHistory.Add(cmd);
			cmdIndex++;

			waitValue = false;
			cmdPressed = true;
			lastCommand = "";
		}

		private void Undo()
		{
			cmdIndex--;
			var cmd = commandHistory[cmdIndex] as CalculatorCommand;
			
			_ = cmd ?? throw new InvalidOperationException();

			cmd.Unexecute();
		}

		private void Redo()
		{
			cmdIndex++;
			var cmd = commandHistory[cmdIndex] as CalculatorCommand;

			_ = cmd ?? throw new InvalidOperationException();

			cmd.Execute();
		}

		private void Pi()
		{
			int max = 100;
			double[] partialSums = new double[max];
			double acc = 0;

			Thread[] threads = new Thread[max];

			for(int i = 0; i < max; i++)
			{
				int index = i;

				threads[i] = new Thread(() =>
				{
					int start = 100 * index;
					int end = 100 * (index + 1);
					partialSums[index] = partialPi(start, end);
				});
			}

			for (int j = 0; j < max; j++)
			{
				threads[j].Start();
			}

			for (int k = 0; k < max; k++)
			{
				threads[k].Join();
			}

			for (int l = 0; l < max; l++)
			{
				acc += partialSums[l];
			}

			currentValue = (double)(4 * acc);
			SetDisplay(currentValue.ToString());
			ShowDisplay();
		}

		private double partialPi(int start, int end)
		{
			double acc = 0;

			for(int i = start; i < end; i++)
			{
				acc += 2.0 / ((4.0 * i + 1.0) * (4.0 * i + 3.0));
			}

			return acc;
		}
	}
}
