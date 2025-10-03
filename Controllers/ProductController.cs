using System.Data;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using VentasApi.Models.Dtos;

namespace VentasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController(IDbConnection db) : ControllerBase
{
	// GET /api/productos
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
	{
		// Uso de sp_ListarProductos
		var productos = await db.QueryAsync<ProductDto>(
			"dbo.sp_ListarProductos",
			commandType: System.Data.CommandType.StoredProcedure
		);
		return Ok(productos);
	}
}
