using Class3.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Class3
{
	public class Ex2
	{
        public static void run(CalculatorUI ui)
        {

            // Implemente uma calculadora usando a interface gráfica que já está pronta. Há um exemplo no arquivo `Ex2.cs`.

            // Você pode criar quantos arquivos desejar, mas só pode modificar o arquivo `Ex2.cs`.

            // O objetivo deste laboratório é praticar o uso de _design patterns_. Documente o seu código e use nomes de classes/variáveis de forma que fique claro quais design patterns estão sendo usados.

            // Algumas sugestões:

            // - Use Singleton para acessar uma única instância da classe Calculadora.
            // - Use Observer para detectar cliques de botão.

            // Objetivos opcionais:

            // - Use o botão 'π' para calcular uma aproximação de π com uma precisão arbitrária. Execute o cálculo em outra thread, e tente acelerar com programação paralela.
            // - Use Commands para implementar uma funcionalidade de desfazer/refazer.

            // Nota: o método `SetDisplayText` só pode ser executado na thread principal.

            //-----------------

            // Use SetDisplayText e SetCallbackForButton.
            // Use os caracteres 0123456789+-*/π↶↷C para acessar os botões.

            // Exemplos:

            var calculator = SingletonCalculator.GetInstance();
            var observer = new ButtonObserver(calculator);

            ui.SetDisplayText("Hello, world!");

            ui.AddCallbackForButton('0', () =>
            {
                calculator.ButtonPressed("0");
            });

            ui.AddCallbackForButton('1', () =>
            {
				calculator.ButtonPressed("1");
			});

            ui.AddCallbackForButton('2', () =>
            {
				calculator.ButtonPressed("2");
			});

            ui.AddCallbackForButton('3', () =>
            {
				calculator.ButtonPressed("3");
			});

            ui.AddCallbackForButton('4', () =>
            {
				calculator.ButtonPressed("4");
			});

            ui.AddCallbackForButton('5', () =>
            {
				calculator.ButtonPressed("5");
			});

            ui.AddCallbackForButton('6', () =>
            {
				calculator.ButtonPressed("6");
			});

            ui.AddCallbackForButton('7', () =>
            {
				calculator.ButtonPressed("7");
			});

            ui.AddCallbackForButton('8', () =>
            {
				calculator.ButtonPressed("8");
			});

            ui.AddCallbackForButton('9', () =>
            {
				calculator.ButtonPressed("9");
			});

            ui.AddCallbackForButton('+', () =>
            {
				calculator.ButtonPressed("sum");
			});

            ui.AddCallbackForButton('-', () =>
            {
				calculator.ButtonPressed("subtraction");
			});

            ui.AddCallbackForButton('*', () =>
            {
				calculator.ButtonPressed("multiply");
			});

            ui.AddCallbackForButton('/', () =>
            {
				calculator.ButtonPressed("division");
			});

            ui.AddCallbackForButton('↶', () =>
            {
				calculator.ButtonPressed("undo");
			});

            ui.AddCallbackForButton('↷', () =>
            {
				calculator.ButtonPressed("redo");
			});

            ui.AddCallbackForButton('C', () =>
            {
				calculator.ButtonPressed("clear");
			});

            ui.AddCallbackForButton('.', () =>
            {
				calculator.ButtonPressed(".");
			});

            ui.AddCallbackForButton('=', () =>
            {
				calculator.ButtonPressed("equal");
			});

            ui.AddCallbackForButton('π', () =>
            {
				calculator.ButtonPressed("pi");
			});

        }
	}
}
calculator.ButtonPressed("0");