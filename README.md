# VentasApp

Sistema de gestión de ventas desarrollado en **C# .NET 8** con **Windows Forms**, siguiendo el patrón arquitectónico **MVP (Model-View-Presenter)**.

---

## ?? Características Principales

- ? **Sistema de Autenticación Completo** (Login y Registro)
- ? **Gestión de Usuarios** con roles (Admin/Employee)
- ? **Gestión de Productos** (CRUD completo)
- ? **Sistema de Ventas** con items
- ? **Control de Sesiones** con SessionManager (Singleton)
- ? **Seguridad**: Contraseñas hasheadas con SHA256
- ? **Base de datos** con Entity Framework Core

---

## ??? Arquitectura del Proyecto

### Patrón MVP (Model-View-Presenter)

```
VentasApp/
??? Models/                    # Entidades y contexto de BD
?   ??? UserModel.cs
?   ??? ProductModel.cs
?   ??? SaleModel.cs
?   ??? VentasDBContext.cs
?   ??? DTOs/                  # Data Transfer Objects
?       ??? AddUserDTO.cs
?       ??? UpdateUserDTO.cs
?       ??? ...
??? Views/                     # Interfaces de usuario
?   ??? Auth/                  # Autenticación
?   ?   ??? LoginView.cs
?   ?   ??? RegisterView.cs
?   ??? User/                  # Gestión de usuarios
?   ?   ??? ListUsersView.cs
?   ?   ??? UserView.cs
?   ??? Product/               # Gestión de productos
?   ?   ??? ListProductsView.cs
?   ?   ??? ProductView.cs
?   ??? Sale/                  # Sistema de ventas
?   ?   ??? SaleView.cs
?   ??? MainView.cs            # Ventana principal
??? Presenters/                # Lógica de presentación
?   ??? LoginPresenter.cs
?   ??? RegisterPresenter.cs
?   ??? ListUsersPresenter.cs
?   ??? UserPresenter.cs
?   ??? ListProductsPresenter.cs
?   ??? ProductPresenter.cs
?   ??? SalePresenter.cs
?   ??? MainViewPresenter.cs
??? Repositories/              # Acceso a datos
?   ??? IUserRepository.cs
?   ??? UserRepository.cs
?   ??? IProductRepository.cs
?   ??? ProductRepository.cs
?   ??? ...
??? Utilities/                 # Utilidades
?   ??? SessionManager.cs      # Gestión de sesión (Singleton)
?   ??? DatabaseTestHelper.cs  # Test de conexión BD
??? Program.cs                 # Punto de entrada
```

---

## ?? Sistema de Autenticación

### Flujo de Login
1. Usuario ingresa credenciales
2. `LoginPresenter` valida con `UserRepository`
3. Credenciales se verifican contra contraseñas hasheadas (SHA256)
4. Si es válido: `SessionManager.Login(user)`
5. Abre `MainView` con información del usuario

### Flujo de Registro
1. Usuario completa formulario de registro
2. `RegisterPresenter` valida todos los campos:
   - Username único (mínimo 3 caracteres)
   - Email válido y único
   - Contraseña (mínimo 6 caracteres)
   - Confirmación de contraseña
3. Se crea el usuario con rol "Employee"
4. Login automático después del registro

### Gestión de Sesión
- **SessionManager** (Patrón Singleton)
- Almacena el usuario autenticado
- Verifica roles (Admin/Employee)
- Accesible desde cualquier parte: `SessionManager.Instance`

**Ver documentación completa:** [AUTHENTICATION_GUIDE.md](AUTHENTICATION_GUIDE.md)

---

## ?? Gestión de Usuarios

### Características:
- CRUD completo de usuarios
- Roles: Admin (1) y Employee (2)
- Soft delete (desactivación en lugar de eliminación)
- Búsqueda y filtrado
- Restricción de acceso según permisos

### Modelo de Usuario:
```csharp
- Id (int)
- Username (string, único)
- Email (string, único)
- PasswordHash (string, SHA256)
- FullName (string)
- RoleId (int) - 1: Admin, 2: Employee
- Phone (string, opcional)
- Active (bool)
- CreatedAt (DateTime)
- UpdatedAt (DateTime)
```

---

## ?? Gestión de Productos

### Características:
- CRUD completo de productos
- Categorización y proveedores
- Control de stock
- Imágenes de productos
- Soft delete
- Búsqueda y filtrado

---

## ?? Sistema de Ventas

### Características:
- Creación de ventas con múltiples items
- Cálculo automático de totales
- Registro del usuario que realiza la venta
- Historial de ventas

---

## ?? Tecnologías Utilizadas

- **Framework**: .NET 8
- **UI**: Windows Forms
- **ORM**: Entity Framework Core
- **Base de Datos**: SQL Server / PostgreSQL (configurable)
- **Lenguaje**: C# 12.0
- **Patrón de Arquitectura**: MVP (Model-View-Presenter)
- **Patrón de Diseño**: Singleton (SessionManager)
- **Seguridad**: SHA256 para hash de contraseñas

---

## ?? Diagrama de Flujo General

```
Inicio ? Login/Registro ? Autenticación ? MainView
                              ?
                    SessionManager (Singleton)
                              ?
        ?????????????????????????????????????????????
        ?                     ?                     ?
    Usuarios              Productos              Ventas
        ?                     ?                     ?
   Repositorio          Repositorio           Repositorio
        ?                     ?                     ?
                    Base de Datos (EF Core)
```

---

## ?? Patrones de Diseño Implementados

### 1. MVP (Model-View-Presenter)
**Propósito**: Separar la lógica de presentación de la interfaz de usuario.

- **Model**: Entidades y lógica de datos (UserModel, ProductModel, etc.)
- **View**: Interfaz de usuario (Forms de Windows Forms)
- **Presenter**: Lógica de presentación que coordina Model y View

**Ventajas**:
- Testing más fácil (presenter sin dependencias de UI)
- Reutilización de lógica
- Mantenimiento simplificado

### 2. Singleton (SessionManager)
**Propósito**: Garantizar una única instancia de gestión de sesión.

**Implementación**:
```csharp
public sealed class SessionManager
{
    private static SessionManager? _instance;
    private static readonly object _lock = new object();
    
    public static SessionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SessionManager();
                    }
                }
            }
            return _instance;
        }
    }
}
```

### 3. Repository Pattern
**Propósito**: Abstraer el acceso a datos.

Cada entidad tiene:
- Una interfaz `IXRepository`
- Una implementación `XRepository`

**Ventajas**:
- Desacoplamiento de la lógica de negocio
- Facilita el testing con mocks
- Centraliza el acceso a datos

### 4. DTO (Data Transfer Object)
**Propósito**: Transferir datos entre capas sin exponer las entidades completas.

Ejemplos:
- `AddUserDTO`: Datos para crear usuario
- `UpdateUserDTO`: Datos para actualizar usuario

---

## ?? Cómo Ejecutar el Proyecto

### Requisitos:
- .NET 8 SDK
- SQL Server o PostgreSQL
- Visual Studio 2022 (recomendado)

### Pasos:
1. Clonar el repositorio
2. Configurar la cadena de conexión en `VentasDBContext.cs`
3. Ejecutar migraciones de Entity Framework (si es necesario)
4. Compilar y ejecutar el proyecto
5. Usar las credenciales de un usuario existente o registrar uno nuevo

---

## ?? Uso del Sistema

### Primer Inicio:
1. La aplicación muestra la pantalla de Login
2. Si no tienes cuenta, haz clic en "Registrarse"
3. Completa el formulario de registro
4. Automáticamente inicia sesión y abre la ventana principal

### Navegación:
- **Productos**: Gestionar catálogo de productos
- **Vender**: Realizar ventas
- **Usuarios**: Gestionar usuarios (requiere permisos)
- **Cerrar Sesión**: Volver al login

---

## ?? Seguridad

### Contraseñas:
- Hasheadas con **SHA256**
- Nunca se almacenan en texto plano
- Validación en cada login

### Validaciones:
- Campos obligatorios
- Formatos de email
- Longitud mínima de contraseñas
- Unicidad de username y email
- Usuarios activos solamente

### Control de Acceso:
- SessionManager verifica autenticación
- Roles para control de permisos
- Verificación de usuario activo

---

## ?? Conceptos Clave

### Para entender el código:

1. **Eventos**: Comunicación entre View y Presenter
2. **Inyección de Dependencias**: Presenter recibe View y Repository
3. **Binding**: DataGridView enlazado a BindingSource
4. **Soft Delete**: Desactivar en lugar de eliminar registros
5. **Thread Safety**: SessionManager con doble verificación
6. **Hash de Contraseñas**: SHA256 para seguridad

---

## ?? Ejemplo de Flujo Completo

### Agregar un Usuario:

```
Usuario ? ListUsersView ? Click "Agregar"
           ?
ListUsersPresenter ? Crea UserView
           ?
UserView ? Usuario completa formulario ? Click "Guardar"
           ?
UserPresenter ? Valida datos ? Crea AddUserDTO
           ?
UserRepository ? Hashea contraseña ? Guarda en BD
           ?
ListUsersPresenter ? Recarga lista de usuarios
           ?
ListUsersView ? Muestra lista actualizada
```

---

## ????? Autor

Desarrollado como proyecto académico de Taller de Programación.

---

## ?? Documentación Adicional

- [Guía de Autenticación](AUTHENTICATION_GUIDE.md) - Documentación completa del sistema de Login/Registro

---

## ?? Uso Educativo

Este proyecto es ideal para aprender:
- Patrón MVP en aplicaciones de escritorio
- Entity Framework Core
- Windows Forms
- Gestión de sesiones
- Seguridad básica (hashing)
- Patrones de diseño (Singleton, Repository)
- Arquitectura por capas

---

**Versión**: 1.0  
**Framework**: .NET 8  
**Lenguaje**: C# 12.0