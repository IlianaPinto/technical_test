# **Proyecto para la gestion de clientes y ordenes - Angular 19 y .Net Core 8.0**

## **Descripción**

Este proyecto es una prueba técnica desarrollada con .NET 8.0 para el backend y Angular 19 para el frontend. La aplicación permite gestionar productos y órdenes.

## **Tecnologías utilizadas**

Este proyecto es una prueba técnica desarrollada con .NET 8.0 para el backend y Angular 19 para el frontend. La aplicación permite gestionar productos y órdenes.

### **Backend**

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- Serilog
- JWT para autenticación
- Swagger para documentación de API

### **Frontend**

- Angular 19
- Angular Material
- RxJS
- Angular Router
- Angular HTTP Client

## **Configuración**

1. Clonar el repositorio:
   ```
    git clone https://github.com/IlianaPinto/technical_test.git
    cd technical_test
   ```

### **Backend**

1. Editar Connection String:

   ```
    "ConnectionStrings": {
        "Connection": "Server=\\SQLSERVER;Database=CustomerOrder;Integrated Security=True;TrustServerCertificate=True;"
    }
   ```

2. Migraciones y base de datos
   ```
    Add-Migration initial
    Update database
   ```

### **Frontend**

1. Instalar dependencias

   ```
    cd client
    npm install
   ```

2. Ejecutar aplicación
   ```
    npm start
   ```
