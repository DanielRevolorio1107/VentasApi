using System.ComponentModel.DataAnnotations;

namespace VentasApi.Models.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [EmailAddress] // formato Email válido
        public string Email { get; set; } = string.Empty;
    }
}
