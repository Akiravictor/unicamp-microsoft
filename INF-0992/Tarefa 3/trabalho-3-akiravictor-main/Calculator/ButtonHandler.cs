using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3.Calculator
{
    public class ButtonHandler : Publisher
    {
        private readonly CalculatorUI _ui;
        public string keyPressed { get; private set; } = "";
        public ButtonHandler(CalculatorUI ui)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        public void SetCallbacks()
        {
            _ui.SetDisplayText("Hello, world!");

            _ui.AddCallbackForButton('0', () =>
            {
                keyPressed = "0";
                Notify();
            });

            _ui.AddCallbackForButton('1', () =>
            {
                keyPressed = "1";
                Notify();
            });

            _ui.AddCallbackForButton('2', () =>
            {
                keyPressed = "2";
                Notify();
            });

            _ui.AddCallbackForButton('3', () =>
            {
                keyPressed = "3";
                Notify();
            });

            _ui.AddCallbackForButton('4', () =>
            {
                keyPressed = "4";
                Notify();
            });

            _ui.AddCallbackForButton('5', () =>
            {
                keyPressed = "5";
                Notify();
            });

            _ui.AddCallbackForButton('6', () =>
            {
                keyPressed = "6";
                Notify();
            });

            _ui.AddCallbackForButton('7', () =>
            {
                keyPressed = "7";
                Notify();
            });

            _ui.AddCallbackForButton('8', () =>
            {
                keyPressed = "8";
                Notify();
            });

            _ui.AddCallbackForButton('9', () =>
            {
                keyPressed = "9";
                Notify();
            });

            _ui.AddCallbackForButton('+', () =>
            {
                keyPressed = "sum";
                Notify();
            });

            _ui.AddCallbackForButton('-', () =>
            {
                keyPressed = "subtract";
                Notify();
            });

            _ui.AddCallbackForButton('*', () =>
            {
                keyPressed = "multiply";
                Notify();
            });

            _ui.AddCallbackForButton('/', () =>
            {
                keyPressed = "divide";
                Notify();
            });

            _ui.AddCallbackForButton('↶', () =>
            {
                keyPressed = "undo";
                Notify();
            });

            _ui.AddCallbackForButton('↷', () =>
            {
                keyPressed = "redo";
                Notify();
            });

            _ui.AddCallbackForButton('C', () =>
            {
                keyPressed = "clear";
                Notify();
            });

            _ui.AddCallbackForButton('.', () =>
            {
                keyPressed = ".";
                Notify();
            });

            _ui.AddCallbackForButton('=', () =>
            {
                keyPressed = "equal";
                Notify();
            });

            _ui.AddCallbackForButton('π', () =>
            {
                keyPressed = "pi";
                Notify();
            });
        }

    }
}
