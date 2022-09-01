/*
Laços e Controle de Fluxo e Repetição
1- If e Else
	if(5 < 2 * 3)
	{
	  Console.WriteLine("true");       // True
	}

	if(2 + 2 == 5)
	{
	  Console.WriteLine("Does not compute");
	}
	else
	{
	  Console.WriteLine("false");      // False
	}

	if(2 + 2 == 5)
	  Console.WriteLine("Does not compute");
	else if(2 + 2 == 4)
	  Console.WriteLine("Computes");   // Computes

=======================================
Para os exercícios a seguir, utilizaremos outro método da classe Console, que é o ReadLine.
Com ele, podemos ler um string digitado pelo usuário. O método ReadLine retorna uma string.
Para usarmos os valores numericamente, podemos converter essa string em um valor, usando o método Parse, como no exemplo a seguir:

	string meustring = Console.ReadLine();
	int n = int.Parse(meustring);
	Console.WriteLine(n);

1) Faça um programa que leia o ano de nascimento do usuário, imprima na tela se ele poderá votar esse ano.
2) Faça um programa que leia três números binários, imprima na tela o maior e o menor deles.
3) Faça um programa que leia as medidas de um triângulo (decimal inteiro), imprima na tela se ele é Equilátero, Isósceles ou Escaleno.
Imprima também a área do triângulo com 3 casas decimais de precisão.

=======================================

*/
//1)
Console.Write("Digite sua idade: ");
int.TryParse(Console.ReadLine(), out int idade);
if(idade > 15)
{
	Console.WriteLine("Usuário pode votar.");
}
else
{
	Console.WriteLine("Usuário não pode votar.");
}


//2)
Console.Write("Digite um numero binário: ");
string? input1 = Console.ReadLine();
int bin1 = Convert.ToInt32(input1, 2);

Console.Write("Digite mais um numero binário: ");
string? input2 = Console.ReadLine();
int bin2 = Convert.ToInt32(input2, 2);

if(bin1 > bin2)
{
	Console.WriteLine($"O primeiro binário é maior que o segundo");
}
else if (bin1 < bin2)
{
	Console.WriteLine($"O segundo binário é maior que o primeiro");
}
else
{
	Console.WriteLine("Os dois binários são iguais");
}

//3)
Console.Write("Digite o lado a: ");
double.TryParse(Console.ReadLine(), out double a);

Console.Write("Digite o lado b: ");
double.TryParse(Console.ReadLine(), out double b);

Console.Write("Digite o lado c: ");
double.TryParse(Console.ReadLine(), out double c);


if(!(a + b > c) || !(b + c > a) || !(a + c > b))
{
	Console.WriteLine("Triângulo não pode existir.");
	return;
}


if(a != b && a != c && b != c)
{
	double area = Math.Sqrt((2 * b * b * c * c) - Math.Pow(a, 4) + (2 * a * a * b * b) + (2 * a * a * c * c) - Math.Pow(b, 4) - Math.Pow(c, 4)) / 4;

	Console.WriteLine($"O triângulo é escaleno e sua área é {area.ToString("#.000")}.");
}
else if((a == b && a != c) || (b == c && b != a) || (a == c && a != b))
{
	double area = 0;

	if(a == b)
	{
		double altura = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(c / 2, 2));
		area = c * altura / 2;
	}
	else if(b == c)
	{
		double altura = Math.Sqrt(Math.Pow(b, 2) - Math.Pow(a / 2, 2));
		area = a * altura / 2;
	}
	else if(a == c)
	{
		double altura = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b / 2, 2));
		area = b * altura / 2;
	}

	Console.WriteLine($"O triângulo é isosceles e sua área é {area.ToString("#.000")}.");
}
else if(a == b && b == c && c == a)
{
	var area = Math.Sqrt(3) * a / 4;
	Console.WriteLine($"O triângulo é equilátero e sua área é {area.ToString("#.000")}");
}

/*
2- Switch

	ShowCard (5);
	ShowCard (11);
	ShowCard (13);

	static void ShowCard(int cardNumber)
	{
	  switch(cardNumber)
	  {
		case 13:
		  Console.WriteLine("King");
		  break;
		case 12:
		  Console.WriteLine("Queen");
		  break;
		case 11:
		  Console.WriteLine("Jack");
		  break;
		case -1:        
		  goto case 12; 
		default:
		  Console.WriteLine(cardNumber);
		  break;
	  }
	}

Quando uma mesma execução deve ser utilizada para diferentes valores

	int cardNumber = 12;

	switch(cardNumber)
	{
	  case 13:
	  case 12:
	  case 11:
		Console.WriteLine("Face card");
		break;
	  default:
		Console.WriteLine("Plain card");
		break;
	}

=======================================
1) Faça um programa que leia dois números do teclado, juntamente com a operação desejada (soma, subtração, divisão, multiplicação). 
Execute a operação e mostre na tela. Use o comando switch na sua solução.
2) Faça um programa que imprima a estação do ano (verão, inverno, outono, primavera) de acordo com o número do mês informado. 
Use o comando switch na sua solução.
3) Faça um programa de conversão de base numérica, leia um número decimal inteiro e a base desejada para conversão (octal, hexadecimal, binária). 
Use o comando switch na sua solução.
=======================================
*/

//1)
Console.WriteLine("Digite 2 numeros seguidos de um dos seguintes comandos (+ - * /)");
Console.WriteLine("Exemplo 2 2 +");

var input = Console.ReadLine();

var cmd = input?.Split(' ')[^1];
double.TryParse(input?.Split(' ')[0], out double num1);
double.TryParse(input?.Split(' ')[1], out double num2);

switch (cmd)
{
	case "+":
		Console.WriteLine($"Resultado: {num1 + num2}");
		break;
	case "-":
		Console.WriteLine($"Resultado: {num1 - num2}");
		break;
	case "*":
		Console.WriteLine($"Resultado: {num1 * num2}");
		break;
	case "/":
		Console.WriteLine($"Resultado: {num1 / num2}");
		break;
	default:
		Console.WriteLine("Comando não suportado.");
		break;
}

//2)
Console.Write("Informe o némero mês: ");
int.TryParse(Console.ReadLine(), out int mes);

switch (mes)
{
	case 12:
	case 1:
	case 2:
		Console.WriteLine("Verão");
		break;

	case 3:
	case 4:
	case 5:
		Console.WriteLine("Outono");
		break;

	case 6:
	case 7:
	case 8:
		Console.WriteLine("Inverno");
		break;

	case 9:
	case 10:
	case 11:
		Console.WriteLine("Primavera");
		break;

	default:
		Console.WriteLine("Mês inexistente");
		break;
}

//3)
Console.WriteLine("Digite um número na base 10 seguido de um número representando a base para convertê-lo.");
Console.WriteLine("2 - Binário, 8 - Octal, 16 - Hexadecimal");
input = Console.ReadLine();

int.TryParse(input?.Split(' ')[1], out int convert);
int.TryParse(input?.Split(' ')[0], out int num);

switch (convert)
{
	case 8:
		Console.WriteLine($"{num} em Octal: {Convert.ToString(num, 8).ToUpper()}");
		break;
	case 2:
		Console.WriteLine($"{num} em Binário: {Convert.ToString(num, 2).ToUpper()}");
		break;
	case 16:
		Console.WriteLine($"{num} em Hexadecimal: {Convert.ToString(num, 16).ToUpper()}");
		break;
	default:
		Console.WriteLine("Base não identificada.");
		break;
}

/*
3 - While, Do
Laço com o While é executado se a condição é satisfeita
	
	int i = 0;
	while(i < 3)
	{
	  Console.WriteLine(i);
	  i++;
	}

Laço Do-While é executado pelo menos 1 vez
	
	int i = 0;
	do
	{
	  Console.WriteLine(i);
	  i++;
	}
	while(i < 3);

=======================================
1) Faça um programa que leia um número do teclado até encontrar um número menor ou igual a 1. Ao final, mostre a soma de todos os números digitados.
2) Faça um programa que verifica se duas strings são iguais.
=======================================
*/

//1)

do
{
	Console.Write("Digite um numero: ");
	int.TryParse(Console.ReadLine(), out num);

	if(num <= 1)
	{
		Console.WriteLine("Bingo!");
	}

}while (num > 1);

//2)

Console.Write("Digite 1 palavra: ");
var str1 = Console.ReadLine();

Console.Write("Digite mais 1 palavra: ");
var str2 = Console.ReadLine();

if(string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase) == 0)
{
	Console.WriteLine($"{str1} e {str2} são iguais.");
}

/*
4 - For e Foreach
Laço de repetição for

	for(int i = 0; i < 3; i++)
	  Console.WriteLine(i);

For com mais de uma variável de inicialização

	for(int i = 0, prevFib = 1, curFib = 1; i < 10; i++)
	{
	  Console.WriteLine(prevFib);
	  int newFib = prevFib + curFib;
		prevFib = curFib; curFib = newFib;
	}

Foreach permite a iteração sobre objetos Enumeráveis (objetos que implementam IEnumerable)

	foreach(char c in "beer")   // c é a variável de iteração
	  Console.WriteLine(c);

=======================================
1) Faça um programa que imprima a tabuada de 1 até 9.
2) Faça um programa que imprima todos os números primos até 100.
3) Faça um programa que determina se uma string é um palíndromo, palavra que ser lida indiferentemente da esquerda para a direita ou vice-versa.
Implemente sua solução com o comando foreach.
=======================================
*/

//1)

Console.WriteLine("Tabuada...");

Console.WriteLine("    00  01  02  03  04  05  06  07  08  09  10");

for(int i = 0; i < 11; i++)
{
	Console.Write(i.ToString("#00") + "  ");

	for(int j = 0; j < 11; j++)
	{
		Console.Write($"{(i*j).ToString("#00")}  ");
	}
	Console.WriteLine();
}

//2)
Console.WriteLine("Primos menores que 100...");
for(int i = 1; i < 100; i++)
{
	var divs = 0;

	for(int j = 1; j <= i; j++)
	{
		if(i % j == 0)
		{
			divs++;
		}
	}

	if(divs == 2)
	{
		Console.Write($"{i}  ");
	}
}
Console.WriteLine();

//3)
Console.Write("Digite uma palavra: ");
var word = Console.ReadLine();

if ( word.SequenceEqual(word.Reverse()))
{
	Console.WriteLine($"{word} é um palindromo.");
}

/*
5 - Break e Continue
Comando break interrompe a execução de um laço

	int x = 0;
	while(true)
	{
	  if(x++ > 5)
		break ;      // quebra o laço
	}

Comando continue faz com que os comando seja desconsiderado

	for(int i = 0; i < 10; i++)
	{
	  if((i % 2) == 0)    // se i é par
		continue;         // continua para a próxima iteração

	  Console.Write(i + " ");
	}

=======================================
1) Faça um programa que imprima o primeiro número, entre 1 e 1000, que seja divisível por 7, 13, 17. Implemente sua solução com o comando break.
2) Faça um programa que some todos os números de 1 até 1000, exceto os múltiplo de 5. Implemente duas versões: com e sem o comando continue.
=======================================
*/

//1)
Console.WriteLine("Numero divisivel por 7 13 e 17...");
for(int i = 1; i <= 2000; i++)
{
	if(i % 7 == 0 && i % 13 == 0 && i % 17 == 0)
	{
		Console.WriteLine($"{i}");
		break;
	}
}

//2)
Console.WriteLine("Soma de todos os numeros não multiplos de 5...");

var soma = 0;

for(int i = 0; i <= 1000; i++)
{
	if(i % 5 == 0)
	{
		continue;
	}

	soma += i;
}

Console.WriteLine(soma);

soma = 0;
for(int i = 0; i <= 1000; i++)
{
	if(i % 5 != 0)
	{
		soma += i;
	}
}