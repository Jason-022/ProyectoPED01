# Brothers Barber Club - Sistema de Gestión

## Descripción
Brothers Barber Club es un sistema de gestión integral para barberías, desarrollado en C# con Windows Forms. El sistema permite gestionar personal, citas, tipos de cortes y reservaciones de manera eficiente y organizada.

## Requisitos del Sistema
- Windows 10 o superior
- .NET Framework 4.7.2
- SQL Server 2019 o superior
- Visual Studio 2019 o superior (para desarrollo)

## Instalación

### 1. Base de Datos
1. Abrir SQL Server Management Studio
2. Ejecutar el script `db/brothers_barber_club_db.sql` para crear la base de datos y sus tablas
3. Verificar que la base de datos `brothers_barber_club_db` se haya creado correctamente

### 2. Configuración de la Aplicación
1. Abrir el archivo `ProyectoCatedra.sln` en Visual Studio
2. Modificar el archivo `App.config` para configurar la conexión a la base de datos:
   ```xml
   <add name="BrothersBarberClubConnection"
        connectionString="Data Source=localhost;Initial Catalog=brothers_barber_club_db;Integrated Security=True;TrustServerCertificate=True"
        providerName="System.Data.SqlClient" />
   ```
   - Reemplazar `localhost` con el nombre de tu servidor SQL si es necesario
   - Ajustar `Integrated Security=True` según tu configuración de autenticación

### 3. Compilación
1. Restaurar los paquetes NuGet necesarios
2. Compilar la solución en modo Release
3. Ejecutar la aplicación

## Estructura de la Base de Datos

### Tablas Principales
- **personal**: Almacena información del personal de la barbería
- **rolPersonal**: Define los roles del personal
- **tipoCorte**: Catálogo de tipos de cortes disponibles
- **tipoReservacion**: Tipos de reservaciones (con cita/sin cita)
- **estadoReservaciones**: Estados posibles de las reservaciones
- **historialCortes**: Registro de todos los cortes realizados

## Funcionalidades Principales

### Gestión de Personal
- Registro de nuevo personal
- Modificación de datos del personal
- Eliminación de registros
- Búsqueda eficiente por nombre
- Asignación de roles

### Gestión de Citas
- Creación de citas
- Modificación de citas existentes
- Cancelación de citas
- Visualización del historial de cortes

### Tipos de Cortes
- Registro de nuevos tipos de cortes
- Actualización de precios
- Gestión de descripciones

### Reservaciones
- Registro de clientes con y sin cita
- Seguimiento del estado de las reservaciones
- Historial de cortes por barbero

## Uso del Sistema

### Inicio de Sesión
1. Ejecutar la aplicación
2. Ingresar las credenciales de acceso
3. Seleccionar el rol correspondiente

### Gestión de Personal
1. Acceder al módulo de Administración
2. Seleccionar "Gestión de Personal"
3. Utilizar los botones correspondientes para:
   - Agregar nuevo personal
   - Modificar registros existentes
   - Eliminar personal
   - Buscar personal por nombre

### Gestión de Citas
1. Acceder al módulo de Citas
2. Seleccionar el tipo de reservación
3. Completar los datos del cliente
4. Asignar barbero y tipo de corte
5. Confirmar la reservación

## Solución de Problemas

### Problemas de Conexión
- Verificar que SQL Server esté en ejecución
- Confirmar que las credenciales de conexión sean correctas
- Validar que la base de datos exista y sea accesible

### Errores de Compilación
- Asegurarse de tener instalado .NET Framework 4.7.2
- Verificar que todos los paquetes NuGet estén restaurados
- Limpiar y reconstruir la solución
