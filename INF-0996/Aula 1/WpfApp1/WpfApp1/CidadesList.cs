using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CidadesList
    {
        public List<Cidade> Cidades { get; set; }

        public CidadesList()
        {
            Cidades = new List<Cidade>();

            Cidades.Add(new Cidade { CodCidade = "1", Nome = "Campinas", Estado = "SP" });
            Cidades.Add(new Cidade { CodCidade = "1", Nome = "São Paulo", Estado = "SP" });
            Cidades.Add(new Cidade { CodCidade = "1", Nome = "Rio de Janeiro", Estado = "RJ" });
        }
    }
}
