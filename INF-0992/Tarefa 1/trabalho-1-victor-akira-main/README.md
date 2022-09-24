# INF0992 - Programação Avançada em C#

##  Enunciado do Trabalho 1

Esse trabalho é composto de 3 exercícios sobre arquivos e database.

Complete os arquivos `Exercise(1|2|3).cs`, de forma que gerem corretamente os arquivos de saída pedidos. O resultado esperado está na pasta `output_expected`.

O código deve estar legível e corretamente indentado, adicionando comentários onde necessário para a compreensão. É recomendado o uso do formatador automático de C# do VSCode. Note que a qualidade do código e dos comentários será levada em conta na avaliação.

Os três arquivos `.cs` devem ser submetidos no Moodle. O trabalho pode ser feito individualmenante ou em duplas.

## Exercício 1 - 2/10 pontos

Leia os nomes dos arquivos no diretório `ex1data`,
e escreva um por linha no arquivo `output/ex1output.txt`.

## Exercício 2 - 4/10 pontos

Gere um JSON com os corpos astrais disponíveis no banco de dados que sejam luas de Júpiter, em ordem decrescente de massa, no formato:

```
{
  'Moons of Jupiter': [
    {
      "Body": "Europa",
      "RadiusKm": 1560.8,
      "VolumeE9Km3": 15.93,
      "MassE21Kg": 48,
      "SurfaceAreaKm2": 30613000,
      "DensityGCm3": 3.013,
      "GravityMS2": 1.316,
      "Type": "moon of Jupiter (terrestrial)",
      "ParentBody": "Jupiter",
      "Discovery": "1610"
    },
    {...},
    ...
  ]
}
```

O *schema* do banco pode ser inspecionado nos arquivos
BodiesDb.cs e AstralBody.cs. As chaves dos objetos JSON são idênticas aos nomes das colunas da tabela. A instanciação do banco de dados já está pronta no exemplo.

O JSON deve ser salvo no arquivo `output/ex2output.json`.

### Instalação do Link2Db

Para acessar o arquivo SQLite que contém o banco de dados, recomendamos o uso da biblioteca Linq2Db. Usando o DotNet por linha de comando, ele pode ser instalado com:

```
dotnet add package linq2db
dotnet add package System.Data.SQLite
```

## Exercício 3 - 4/10 pontos

Leia um arquivo docx e o converta para Markdown.

Converta o estilo Title para

`# Texto`

, o estilo Subtitle para

`## Texto`

, o estilo Heading1 para

`### Texto`

, e o estilo Heading2 para

`#### Texto`

Não é preciso implementar nenhuma das outras funcionalidades do Markdown.

O resultado deve ser salvo no arquivo `output/ex3output.md`.

__Dica:__ arquivos .docx são na verdade apenas arquivos ZIP com uma extensão diferente.
