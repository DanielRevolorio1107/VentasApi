# Gestion-de-Ventas

 # Ventas API

Una **API RESTful** construida con **ASP.NET Core 8 Web API** y **SQL Server**, diseñada para gestionar productos, clientes y ventas.  
El proyecto incluye validaciones de stock, historial de ventas por cliente y soporte para procedimientos almacenados y vistas.

---

##  Tecnologías usadas
- **ASP.NET Core 8 Web API**
- **SQL Server 2022**
- **Dapper** (para acceso a datos)
- **Swagger / OpenAPI** (documentación de endpoints)
- **C# 12**

---

##  Estructura del proyecto

VentasApi/
│── Controllers/ # Controladores (Productos, Clientes, Ventas)
│── Models/ # DTOs y modelos de datos
│── Properties/ # Configuración del proyecto
│── appsettings.json # Configuración de conexión a BD
│── Program.cs # Configuración inicial de la API
##  Configuración inicial

1. Clonar el repositorio:

git clone https://github.com/tuusuario/VentasApi.git
cd VentasApi

dotnet restore
dotnet run

## Endpoints principales
 Productos

GET /api/productos → Listar productos disponibles.

POST /api/productos → Agregar un nuevo producto.

Clientes

GET /api/clientes → Listar clientes.

POST /api/clientes → Registrar un nuevo cliente (valida email).

 Ventas

POST /api/ventas → Registrar una venta con detalles.
 Valida stock antes de registrar.

GET /api/ventas/cliente/{id} → Historial de ventas de un cliente.

GET /api/ventas/{id} → Obtener detalle completo de una venta.


