using System.ComponentModel;

namespace OngConnection.Domain.Enums
{
    public enum OngType
    {
        Vazio,
        Animais,
        Mulheres,
        Arte,
        Criancas,
        Cultura,
        [Description("Dependentes Quimicos")]
        DependentesQuimicos,
        [Description("Direitos Humanos")]
        DireitosHumanos,
        [Description("Doação Órgãos")]
        DoacaoOrgaos,
        Educacao,
        Financas,
        Renda,
        Idosos,
        Medicamentos,
        [Description("Meio Ambiente")]
        MeioAmbiente,
        Moradia,
        Saude,
        Emergencia,
        Tecnologia,
        Trabalho,
        Voluntariado,
        Alimentacao
    }
}
