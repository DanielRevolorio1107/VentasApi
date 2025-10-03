using System.ComponentModel.DataAnnotations;

namespace VentasApi.Models.Dtos
{
    public class ClientCreateDto
    {
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    }
}