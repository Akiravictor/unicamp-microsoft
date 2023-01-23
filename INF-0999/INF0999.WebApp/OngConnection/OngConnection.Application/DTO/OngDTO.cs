using OngConnection.Domain.Enums;

namespace OngConnection.Application.DTO
{
    public class OngDTO
    {
		public Guid Id { get; set; }
		public string? NomeOng { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public OngType Tipo { get; set; }

        public int ErrorCount { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
