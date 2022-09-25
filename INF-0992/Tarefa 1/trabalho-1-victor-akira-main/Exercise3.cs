using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO.Compression;
using System.Data;
using System.Xml;
using System.Text;

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

            var input_filepath = "../../../ex3data/Rubber duck debugging.docx";
            var output_filepath = "../../../output/ex3output.md";


            using var archive = ZipFile.OpenRead(input_filepath);

            archive.ExtractToDirectory("../../../ex3data/", true);

            var dirInfo = new DirectoryInfo("../../../ex3data");

            using XmlReader reader = XmlReader.Create("../../../ex3data/word/document.xml", new XmlReaderSettings { IgnoreWhitespace = true });

            var strBldr = new StringBuilder();

            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element && reader.Name.Contains("Style"))
                {
                    var attribute = reader.GetAttribute(0);

                    switch (attribute)
                    {
                        case "Title":
                            strBldr.Append("# ");
                            break;

                        case "Subtitle":
                            strBldr.Append("## ");
                            break;

                        case "Heading1":
                            strBldr.Append("### ");
                            break;

                        case "Heading2":
                            strBldr.Append("#### ");
                            break;
                    }
                }

                if (reader.NodeType == XmlNodeType.Text)
                {
                    strBldr.Append($"{reader.Value}\n\n");
                }

            }

            using FileStream fs = new FileStream(output_filepath, FileMode.Create, FileAccess.ReadWrite);
            using StreamWriter sw = new StreamWriter(fs);

            sw.Write(strBldr.ToString());

            sw.Flush();
            sw.Close();

            fs.Close();
            
        }
    }
}