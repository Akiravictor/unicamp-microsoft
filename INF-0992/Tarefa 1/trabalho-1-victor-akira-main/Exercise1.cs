using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Class1
{
    public class Exercise1
    {
        public void run()
        {

            /*
              Leia os nomes dos arquivos no diretório `ex1data`,
              e escreva um por linha no arquivo `output/ex1output.txt`.
            */

            var directory_filepath = "../../../ex1data";
            var output_dir = "../../../output";
            var output_filepath = "../../../output/ex1output.txt";

            var dirInfo = new DirectoryInfo(directory_filepath);

            if (!Directory.Exists(output_dir))
            {
                Directory.CreateDirectory(output_dir);
            }

            using FileStream fs = new FileStream(output_filepath, FileMode.Create, FileAccess.Write);

            using StreamWriter sw = new StreamWriter(fs);

            foreach(var file in dirInfo.GetFiles())
            {
                sw.WriteLine(file.Name);
            }

            sw.Flush();
            sw.Close();

            fs.Close();
        }
    }
}
