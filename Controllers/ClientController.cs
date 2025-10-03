using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using VentasApi.Models.Dtos;
using Microsoft.Data.SqlClient;

namespace VentasApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IDbConnection db;
    public ClientesController(IDbConnection db) => this.db = db;

    // GET /api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        // Uso de sp_ListarClientes
        var clientes = await db.QueryAsync<ClientDto>(
            "dbo.sp_ListarClientes",
            commandType: CommandType.StoredProcedure
        );
        return Ok(clientes);
    }

    // POST /api/clientes
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ClientCreateDto dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        try
        {
            var sql = @"
            INSERT INTO dbo.Cliente (nombre, email)
            VALUES (@Nombre, @Email);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var id = await db.QuerySingleAsync<int>(sql, new { dto.Nombre, dto.Email });

            return CreatedAtAction(nameof(Get), new { id }, new { id, dto.Nombre, dto.Email });
        }
        catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            // 2627/2601 violación de UNIQUE es decir, email duplicado
            return Conflict("El email ya existe.");
        }
    }

}