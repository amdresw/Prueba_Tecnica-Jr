📋 Sistema de Facturación MVC
Sistema web de gestión de facturas desarrollado con ASP.NET Core MVC y PostgreSQL. Incluye API REST para integración con otros sistemas.
🎯 Características

✅ Gestión completa de clientes, productos y emisores
✅ Creación y visualización de facturas
✅ Cálculo automático de subtotales y totales
✅ Dashboard con estadísticas de ventas
✅ API REST para integración externa
✅ Validaciones robustas en frontend y backend
✅ Base de datos PostgreSQL con triggers y constraints

🛠️ Tecnologías

Backend: ASP.NET Core 8.0 MVC
Base de datos: PostgreSQL
ORM: Entity Framework Core
Frontend: Razor Pages, HTML5, CSS3, JavaScript
Patrón: MVC (Modelo-Vista-Controlador)

## Instalación 📥

### Requisitos Previos 🔧
- Tener instalado [Git](https://git-scm.com/)
- Tener instalado [Postgres](https://www.postgresql.org/download/)
- Tener instalado [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/)
- Un editor de código como Visual Studio Code, Visual Studio, o el de tu preferencia.

### Pasos para Ejecutar el proyecto 🚀

1. Clonar Repositorio, Ir al directorio del repositorio (En la terminal)

```
git clone https://github.com/amdresw/Prueba_Tecnica-Jr/tree/develop 
```
```
/cd Prueba_Tecnica-Jr
```

2. Configurar tu cadena de conexion  (Cambiar este bloque de codigo en appsettings.json por TUS credenciales para ingresar a postgres)

```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=sistema_automotriz;Username=postgres;Password=tu_contraseña"
}
```
3. Aplicar las migraciones de la base de datos

```
dotnet ef database update
```

4. Ejecucion del proyetco
```
dotnet run
```
5. Al ejecutar el proyecto, verás en la terminal una URL similar a la siguiente:
```
https://localhost:{puerto}
```
