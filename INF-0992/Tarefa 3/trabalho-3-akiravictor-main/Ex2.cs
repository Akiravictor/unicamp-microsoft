using Class3.Calculator;
using JetBrains.Annotations;
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

            var buttonHandler = new ButtonHandler(ui);
            var calculator = SingletonCalculator.GetInstance(buttonHandler, ui);


            buttonHandler.AddObserver(calculator);

            buttonHandler.SetCallbacks();
        }
	}
}
