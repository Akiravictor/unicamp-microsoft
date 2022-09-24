using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class1
{
  public class Exercise3
  {
    public void run()
    {
      /* Leia um arquivo docx e o converta para Markdown.
      
      Converta o estilo Title para
      
      # Title

      , o estilo Subtitle para

      ## Subtitle

      , o estilo Heading1 para
      
      ### Heading1
      
      , e o estilo Heading2 para

      #### Heading2

      Não é preciso implementar nenhuma das outras funcionalidades do Markdown.

      Dica: arquivos .docx são na verdade apenas arquivos ZIP com uma extensão diferente.
      */

      var input_filepath = "./ex3data/Rubber duck debugging.docx";
      var output_filepath = "output/ex3output.md";
    }
  }
}