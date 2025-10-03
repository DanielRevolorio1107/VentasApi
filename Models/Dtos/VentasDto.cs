namespace VentasApi.Models.Dtos;


public record VentaListItem(
    int Id, 
    DateTime Fecha, 
    int ClienteId, 
    decimal? Total
    );

public record VentaClienteItem(
    int Id, 
    DateTime Fecha,
    decimal? Total
    );  

public record VentaClienteDetalle(
    int Id, 
    DateTime Fecha, 
    decimal? Total, 
    string ClienteNombre
    );


public class NuevaVentaRequest
{
    public int ClienteId { get; set; }
    public DateTime? Fecha { get; set; } 
    public List<DetalleVentaRequest> Detalles { get; set; } = new();
}

public class DetalleVentaRequest
{
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
