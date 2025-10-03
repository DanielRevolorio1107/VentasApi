using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using VentasApi.Models.Dtos;

namespace VentasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentasController : ControllerBase
{
    private readonly IDbConnection _db;
    public VentasController(IDbConnection db) => _db = db;

    // GET /api/ventas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VentaListItem>>> GetAll()
    {
        //Uso de sp_ListarVentas
        var rows = await _db.QueryAsync<VentaListItem>(
            "dbo.sp_ListarVentas",
            commandType: System.Data.CommandType.StoredProcedure);
        return Ok(rows);
    }

    // GET /api/ventas/cliente/id
    [HttpGet("cliente/{clienteId:int}")]
    public async Task<ActionResult<IEnumerable<VentaClienteDetalle>>> GetByCliente(int clienteId)
    {
        // Uso de sp_HistorialVentasPorCliente
        var p = new Dapper.DynamicParameters();
        p.Add("@id_cliente", clienteId);

        var ventas = (await _db.QueryAsync<VentaClienteItem>(
            "dbo.sp_HistorialVentasPorCliente",
            p,
            commandType: System.Data.CommandType.StoredProcedure)).ToList();

        var nombre = await _db.ExecuteScalarAsync<string>(
            "SELECT nombre FROM dbo.Cliente WHERE id_cliente = @clienteId",
            new { clienteId });

        if (nombre is null)
            return NotFound($"No existe el cliente {clienteId}.");

        var respuesta = ventas
            .Select(v => new VentaClienteDetalle(v.Id, v.Fecha, v.Total, nombre))
            .ToList();

        return Ok(respuesta);
    }


}
