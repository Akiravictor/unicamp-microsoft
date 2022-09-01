/*

1- Tipos de dados numéricos

Tipos de dados inteiros com sinal
	sbyte s = 20;
	short t = -32;
	int i = -1;
	long l = -3000;

Tipos de dados inteiros sem sinal
	byte b = 255;
	ushort us = 2;
	uint ui = 5;
	ulong ul = 5000;

Tipos de dados reais

	float f = 3.14F;
	double d = 1.23;
	decimal g = 2.32M;

Sufixo é obrigatório para alguns tipos de dados
F - Float, D - Double, M = Decimal, U = UInt, L = Long, UL = ULong

	long lng = 5;            // Nenhum sufixo é necessário: Conversão implícita de int para long
	double db = 4.0;        // O sufixo D é redundante
	float flt = 4.5F;        // Não irá compilar sem o sufixo F
	decimal dc = -1.23M;    // Não irá compilar sem o sufixo M

Outras notações como a Hexadecimal e Binario
	int x = 127;
	long hex = 0x7F;
	int bin = 0b1010_1011_1100_1101_1110_1111;

Outras notações
	int million = 1_000_000;
	double doubleMillion = 1E06; // Notação exponencial é permitida com o sufixo E

Conversões implicitas
	int a = 12345;       // int é um inteiro de 32-bits
	long y = a;          // Conversão implícita para inteiro de 64-bits
	short z = (short)a;  // Conversão explícita para inteiro de 16-bits

Todos os tipos inteiros podem ser implicitamente convertidos para tipos de ponto flutante:
	int it = 1;
	float fl = it;

O processo reverso deve ser explícito
	int iExplicit = (int)f;

Conversao de int para float mantém a magnitude, mas perde-se a precisão
	int i1 = 100000001;
	float f1 = i1;          // Magnitude preservada, precisão foi perdida
	int i2 = (int)f1;       // 100000000

O resto da divisão por inteiros é truncado
	int div = 2 / 3;      // 0

Divisão por zero lança exceção
	int b = 0;
	int divZero = 5 / b;      // throws DivisionByZeroException

Por padrão, operações aritméticas overflow silenciosamente:
	int overFlw = int.MinValue;
	a--;
	Console.WriteLine(a == int.MaxValue);  // True

2- Tipos de dados Booleanos
	bool a = true;
	bool b = false;

Operadores == e != testam qualquer tipo de dado, mas retornam sempre booleano
	int x = 1;
	int y = 2;
	int z = 1;

	Console.WriteLine(x == y);    // False
	Console.WriteLine(x != y);    // True
	Console.WriteLine(x == z);    // True

	Console.WriteLine(x < y);    // True
	Console.WriteLine(x >= z);    // True

Operadores de interseção &&, união || e exclusão ! operam sobre booleanos
	bool UseUmbrella(bool rainy, bool sunny, bool windy)
	{
	  return !windy && (rainy || sunny);
	}

	UseUmbrella(true, false, false);  // True
	UseUmbrella(true, true, true);    // False

Operadores && e || são essenciais para avaliar expressões que possam retornar NullReferenceException
	StringBuilder sb = null;

	if (sb != null && sb.Length > 0) 
	  Console.WriteLine("sb has data");
	else
	  Console.WriteLine("sb is null or empty");

Operador ternário
	int Max(int a, int b)
	{
	  return (a > b) ? a : b;
	}

	Max(2, 3);   // 3
	Max(3, 2);   // 3

3- Tipo de dados Literais
	char c = 'A';       // Caracter simples
	string h = "Heat";

Operador de igualdade segue a mesma lógica
	string a = "test";
	string b = "test";
	Console.WriteLine (a == b);  // True

Character de Escape
	char newLine = '\n';  // Quebra de linha
	char backSlash = '\\';

	string t = "Here's a tab:\t"; // Tab
	string escaped  = "First Line\r\nSecond Line"; // Escaped

Multi-Line
	string verbatim = @"First Line
						Second Line";

	// Adição de aspas duplas é feita escrevendo-as duplicadas:
	string xml = @"id=""123"";

Operador + concatena duas string
	string s1 = "a" + "b"; // ab

	string s2 = "a" + 5;   // a5

String interpolation
	int x = 4;
	Console.WriteLine($"A square has {x} sides");    // A square has 4 sides

	string s = $"255 in hex is {byte.MaxValue:X2}";  // X2 = 2-digit Hexadecimal

	x = 2;
	s = $@"this spans {
			x} lines";

4- Tipos de dados Array
	char[] vowels = new char[5];    // Um vetor de tamanho 5 do tipo char

	vowels[0] = 'a';
	vowels[1] = 'e';
	vowels[2] = 'i';
	vowels[3] = 'o';
	vowels[4] = 'u';
	Console.WriteLine(vowels[1]);      // e

Inicialização simplificada
	char[] easy = {'a','e','i','o','u'};

Elementos de um vetor são sempre inicializados com 0 por padrão
	int[] a = new int[1000];
	Console.Write(a[123]);    // 0

Indices diferentes
	char[] vowels = new char[] {'a','e','i','o','u'};
	char lastElement  = vowels[^1];   // 'u'
	char secondToLast = vowels[^2];   // 'o'

	Index first = 0;
	Index last = ^1;
	char firstElement = vowels[first];   // 'a'
	char lastElement2 = vowels[last];    // 'u'

Uso de intervalos
	char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

	char[] firstTwo = vowels[..2];     // 'a', 'e'
	char[] lastThree = vowels[2..];    // 'i', 'o', 'u'
	char[] middleOne = vowels[2..3];   // 'i'

	char[] lastTwo = vowels[^2..];     // 'o', 'u'

	Range firstTwoRange = 0..2;
	char[] firstTwo2 = vowels[firstTwoRange];   // 'a', 'e'

Matriz
	int[,] matrix = new int[3, 3];    // Vetor de inteiros com duas dimensões

	for (int i = 0; i < matrix.GetLength(0); i++) // O metodo GetLength retorna o tamanho de um vetor
	  for (int j = 0; j < matrix.GetLength(1); j++)
		matrix[i, j] = i * 3 + j;

	int[,] matrix2 = new int[,]
	{
	  {0,1,2},
	  {3,4,5},
	  {6,7,8}
	};

Formas simplificadas de inicialização
	char[] vowels = {'a','e','i','o','u'};

	int[,] rectangularMatrix =
	{
	  {0,1,2},
	  {3,4,5},
	  {6,7,8}
	};

	int[][] jaggedMatrix =
	{
	  new int[] {0,1,2},
	  new int[] {3,4,5},
	  new int[] {6,7,8}
	};

Todos os acessos são checados com relação ao index
	int[] arr = new int[3];
	arr[3] = 1;               // Exceção IndexOutOfRangeException

*/