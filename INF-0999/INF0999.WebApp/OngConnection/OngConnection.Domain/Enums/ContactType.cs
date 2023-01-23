using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Enums
{
    public enum ContactType
    {
        [Description("Não Atendido")]
        NaoAtendido,
        [Description("Em Atendimento")]
        EmAtendimento,
        [Description("Concluído")]
        Concluido,
        [Description("Recusado")]
        Recusado
    }
}
