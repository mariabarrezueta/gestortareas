# Gestor de Tareas Personal

Proyecto web fullstack para la gestión de tareas personales. Permite crear, editar, listar, filtrar y eliminar tareas con campos como título, descripción, fecha límite, prioridad, estado y categoría.

## Tecnologías utilizadas

- Frontend: Angular 16
- Backend: ASP.NET Core 7 (Web API)
- Base de Datos: Azure SQL
- Despliegue: Azure App Service

## Principios y Patrones aplicados

Principios SOLID:
- S: Separación de responsabilidades entre controladores, servicios y repositorios.
- D: Inversión de dependencias: interfaces ITareaRepository e ITareaService.

Patrones de Diseño:
- Repositorio: abstrae el acceso a datos.
- Inyección de dependencias: en Program.cs.

## Instrucciones de uso

### Backend

1. Configurar la cadena de conexión a Azure SQL en appsettings.json:
2. Ejecutar migraciones
dotnet ef database update
3. Ejecutar la aplicacion
dotnet run

### Frontend
1. Instalar dependencias
cd gestor-tareas-frontend
npm install
2. Ejecutar en desarrollo:
ng serve
3. Para producción:
ng build --configuration production

Esto generará los archivos dentro de wwwroot/ listos para despliegue en Azure.

## Despliegue en Azure
El backend (.NET Core) fue desplegado en Azure App Service.
El frontend Angular fue compilado y embebido dentro de la carpeta wwwroot para servirlo como SPA.
CORS está configurado correctamente en Program.cs para permitir llamadas desde el dominio del frontend en Azure

Autora: Rebeca Barrezueta maria.barrezueta@udla.edu.ec
