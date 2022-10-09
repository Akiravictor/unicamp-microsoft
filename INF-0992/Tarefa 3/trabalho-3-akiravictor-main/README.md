# INF0992 - Programação Avançada em C#

## Enunciado do Trabalho 3

Esse trabalho é composto de 2 exercícios sobre _design patterns_.

Neste trabalho, você pode submeter qualquer número de arquivos. Submeta no Moodle um arquivo `.zip` com os arquivos que você criar, e com os arquivos `Ex[12].cs`.

O código deve estar legível e corretamente indentado, adicionando comentários onde necessário para a compreensão. É recomendado o uso do formatador automático de C# do VSCode. Note que a qualidade do código e dos comentários será levada em conta na avaliação.

O trabalho pode ser feito individualmenante ou em duplas.

## Exercício 1 - 3/10 pontos

Implemente três Visitors que operem na árvore dada.
- O primeiro Visitor deve retornar a profundidade da árvore.
- O segundo deve retornar o resultado das operações.
- O terceiro deve gerar uma string com a árvore em forma de expressão matemática.

Por exemplo, para a árvore

```
Addition(Number(1), Multiplication(Number(2), Number(3)))
```

os resultados devem ser:

```
Profundidade: 3
Resultado: 7
Expressão: (1 + (2 * 3))
```

Não é necessário implementar a precedência de operações: use parênteses em todas
as operações binárias.

Imprima os resultados no console.

## Exercício 2 - 7/10 pontos

Implemente uma calculadora usando a interface gráfica que já está pronta. Há um exemplo no arquivo `Ex2.cs`.

Você pode criar quantos arquivos desejar, mas só pode modificar o arquivo `Ex2.cs`.

O objetivo deste laboratório é praticar o uso de _design patterns_. Documente o seu código e use nomes de classes/variáveis de forma que fique claro quais design patterns estão sendo usados.

Algumas sugestões:

- Use Singleton para acessar uma única instância da classe Calculadora.
- Use Observer para detectar cliques de botão.

Objetivos opcionais:

- Use o botão 'π' para calcular uma aproximação de π com uma precisão arbitrária. Execute o cálculo em outra thread, e tente acelerar com programação paralela.
- Use Commands para implementar uma funcionalidade de desfazer/refazer.

Nota: o método `SetDisplayText` só pode ser executado na thread principal.
