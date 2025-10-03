namespace VentasApi.Models.Dtos
{
    public record ProductDto(
        int Id, 
        string Nombre, 
        decimal Precio, 
        int Stock
        );
}