/*

Operadores e Expressões

1- Operador Null
Variáveis com tipo por referência podem asusmir um valor null
	string s1 = null;
	string s2 = s1 ?? "nothing";   // s2 é avaliado para "nothing"

Operador ?? é chamado de null-coalescing
Operador ??= é semelhante a ??, mas caso a ??= b e a seja null, ele substitui seu valor por b, mantendo o valor original de a, caso contrário
	string s1 = null;
	s1 ??= "something";
	Console.WriteLine(s1);  // something

	s1 ??= "everything";
	Console.WriteLine(s1);  // something

Nesse caso, ele avalia se sb é null antes de invocar o método
	string sb = null;
	string s = sb?.ToString();              // Sem erros, nesse caso, s é avaliado para nulo

	string sb = null;
	int? length = sb?.ToString().Length;      // OK : int? pode ser nulo
	string s = sb?.ToString() ?? "nothing";   // s é avaliada para "nothing"


=======================================
1) Reescreva os trechos de código abaixo usando a notação do operador nulo.
	if (valor != null)
	{
		 valor = valor.Trim().ToUpper();
	}

	int? tamanho = (pessoa != null) ? (int?)pessoa.Length : null;
=======================================
1)
*/
string? valor = null;
valor = valor?.Trim().ToUpper();
Console.WriteLine($"valor: {valor}");

valor = "algum valor aqui";
valor = valor?.Trim().ToUpper();
Console.WriteLine($"valor: {valor}");

int[] pessoa = null;
int? tamanho = (int?)pessoa?.Length ?? null;
Console.WriteLine($"tamanho: {tamanho}");

pessoa = new int[] { 1,2,3,4,5 };
tamanho = (int?)pessoa?.Length ?? null;
Console.WriteLine($"tamanho: {tamanho}");

/*
2- Definição de variáveis
Variáveis podem ser declaradas na mesma linha, desde q separadas por vírgula
	string someWord = "rosebud";
	int someNumber = 42;
	bool rich = true, famous = false;

Constantes são declaras com a keyword const e uma vez definidas, não podem ser alteradas
	const double c = 2.99792458E08;

Operações comuns
	x = 1 + 2;                 // Atribuição
	x++;                       // Incremento após uso
	x--;                       // Decremento após uso 
	++x;                       // Incremento antes do uso
	--x;                       // Decremento antes do uso
	y = Math.Max(x, 5);        // Atribuição
	Console.WriteLine(y);      // Chamada de método
	sb = new StringBuilder();  // Atribuição 
	new StringBuilder();       // Instanciação de objeto

=======================================
1) Declare uma variável inteira sem atribuir nenhum valor a ela. Tente imprimir na tela. O que acontece?
2) Faça um programa que altera o valor de uma constante. O que acontece?
3) Faça um programa que incremente o valor de um char. O que acontece?
=======================================
1)
	int a;
	Console.WriteLine($"a: {a}"); //Use of unassigned local variable 'a'

2)
	const int a = 1000;
	a = a + 20; //The left-hand side of an assignment must be a variable, property or indexer

3)
*/
char a = 'a';
a++;
Console.WriteLine($"a: {a}"); //Pega o próximo char

/*
3- Tipagem implícita
	var i = 3;           // i é implicitamente do tipo int
	var s = "sausage";   // s é implicitamente do tipo string

	var rectMatrix = new int[,]    // rectMatrix é implicitamente do tipo int[,]
	{
	  {0,1,2},
	  {3,4,5},
	  {6,7,8}
	};

	var vowels = new[] {'a','e','i','o','u'};   // Compilador infere o tipo char[]
	var x = new[] { 1, 10000000000 };           // Legal - todos os elementos são convertidos para o tipo long

=======================================
1) Declare e inicialize uma variável inteira sem especificar o tipo. Tente atribuir uma valor literal a essa variável. O que acontece?
2) Declare e inicialize uma variável inteira sem especificar o tipo. Tente somar um char a essa variável. O que acontece?
=======================================
1)

	var b = 10;
	b = "batata"; //Cannot implicitly convert type 'string' to 'int'

2)

*/
var b = 10;
b = b + 'c';

Console.WriteLine($"b: {b}"); //Converce o char para o int (seguindo a tabela ASCII)