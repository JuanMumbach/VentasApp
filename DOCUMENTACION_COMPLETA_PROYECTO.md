# ?? DOCUMENTACIÓN COMPLETA DEL PROYECTO - VentasApp

---

## ?? ÍNDICE

1. [Descripción General](#1-descripción-general)
2. [Arquitectura del Proyecto](#2-arquitectura-del-proyecto)
3. [Tecnologías Utilizadas](#3-tecnologías-utilizadas)
4. [Estructura de Carpetas](#4-estructura-de-carpetas)
5. [Patrones de Diseño Implementados](#5-patrones-de-diseño-implementados)
6. [Flujo de la Aplicación](#6-flujo-de-la-aplicación)
7. [Componentes Principales](#7-componentes-principales)
8. [Sistema de Permisos y Roles](#8-sistema-de-permisos-y-roles)
9. [Sistema de Temas](#9-sistema-de-temas)
10. [Base de Datos](#10-base-de-datos)
11. [Guía para Agregar Nuevas Funcionalidades](#11-guía-para-agregar-nuevas-funcionalidades)
12. [Buenas Prácticas del Proyecto](#12-buenas-prácticas-del-proyecto)
13. [Resolución de Problemas Comunes](#13-resolución-de-problemas-comunes)

---

## 1. DESCRIPCIÓN GENERAL

**VentasApp** es una aplicación de escritorio para Windows desarrollada en C# con .NET 8.0 y Windows Forms. Su propósito es gestionar un sistema de ventas completo que incluye:

- ?? **Gestión de Productos**: Crear, editar, eliminar y listar productos
- ?? **Gestión de Ventas**: Realizar ventas y consultar historial
- ?? **Gestión de Clientes**: Administrar información de clientes
- ?? **Gestión de Proveedores**: Administrar proveedores
- ?? **Gestión de Usuarios**: Control de usuarios y roles
- ?? **Sistema de Autenticación y Permisos**: Login y control de acceso basado en roles

---

## 2. ARQUITECTURA DEL PROYECTO

### 2.1 Patrón MVP (Model-View-Presenter)

El proyecto implementa el patrón **MVP** (Model-View-Presenter), que separa la lógica de presentación de la lógica de negocio:

```
???????????????         ???????????????         ???????????????
?    VIEW     ? ??????? ?  PRESENTER  ? ??????? ?    MODEL    ?
?  (IView)    ?         ?             ?         ? (Entities)  ?
???????????????         ???????????????         ???????????????
                               ?
                               ?
                        ???????????????
                        ? REPOSITORY  ?
                        ? (Data Layer)?
                        ???????????????
```

### 2.2 Capas de la Aplicación

#### **CAPA DE PRESENTACIÓN (Views)**
- Formularios de Windows Forms
- Implementan interfaces IView
- Solo manejan la UI y eventos del usuario
- **Ubicación**: `Views/`

#### **CAPA DE PRESENTADOR (Presenters)**
- Contiene la lógica de presentación
- Coordina entre View y Repository
- Maneja eventos de la vista
- **Ubicación**: `Presenters/`

#### **CAPA DE MODELO (Models)**
- Entidades del dominio
- DTOs (Data Transfer Objects)
- DbContext de Entity Framework
- **Ubicación**: `Models/`

#### **CAPA DE ACCESO A DATOS (Repositories)**
- Implementa el patrón Repository
- Acceso a la base de datos mediante Entity Framework
- **Ubicación**: `Repositories/`

#### **CAPA DE SERVICIOS (Services)**
- Servicios transversales (Temas, Sesión, Permisos)
- **Ubicación**: `Services/`

---

## 3. TECNOLOGÍAS UTILIZADAS

| Tecnología | Versión | Propósito |
|-----------|---------|-----------|
| **.NET** | 8.0 | Framework principal |
| **C#** | 12.0 | Lenguaje de programación |
| **Windows Forms** | - | Framework de UI |
| **Entity Framework Core** | 9.0.9 | ORM para acceso a datos |
| **MySQL** | - | Base de datos |
| **Pomelo.EntityFrameworkCore.MySql** | 9.0.0 | Proveedor de MySQL para EF Core |
| **User Secrets** | 6.0.1 | Almacenamiento seguro de configuración |

---

## 4. ESTRUCTURA DE CARPETAS

```
VentasApp/
?
??? ?? Models/                          # Entidades y DTOs
?   ??? ?? ProductModel.cs              # Entidad Producto
?   ??? ?? SaleModel.cs                 # Entidad Venta
?   ??? ?? CustomerModel.cs             # Entidad Cliente
?   ??? ?? SupplierModel.cs             # Entidad Proveedor
?   ??? ?? UserModel.cs                 # Entidad Usuario
?   ??? ?? RoleModel.cs                 # Entidad Rol
?   ??? ?? PermissionModel.cs           # Entidad Permiso
?   ??? ?? VentasDBContext.cs           # Contexto de Entity Framework
?   ??? ?? DTOs/                        # Data Transfer Objects
?       ??? ?? AddProductDTO.cs
?       ??? ?? UpdateProductDTO.cs
?       ??? ...
?
??? ?? Views/                           # Vistas (Windows Forms)
?   ??? ?? BaseForm.cs                  # Formulario base con temas
?   ??? ?? MainView.cs                  # Vista principal
?   ??? ?? LoginView.cs                 # Vista de login
?   ??? ?? Product/
?   ?   ??? ?? IListProductsView.cs     # Interfaz de vista
?   ?   ??? ?? ListProductsView.cs      # Lista de productos
?   ?   ??? ?? IProductView.cs
?   ?   ??? ?? ProductView.cs           # Formulario producto
?   ??? ?? Sale/
?   ??? ?? Customer/
?   ??? ?? Supplier/
?   ??? ?? User/
?
??? ?? Presenters/                      # Presentadores (lógica)
?   ??? ?? LoginPresenter.cs
?   ??? ?? MainViewPresenter.cs
?   ??? ?? ListProductsPresenter.cs
?   ??? ?? ProductPresenter.cs
?   ??? ...
?
??? ?? Repositories/                    # Acceso a datos
?   ??? ?? IproductRepository.cs        # Interfaz
?   ??? ?? ProductRepository.cs         # Implementación
?   ??? ?? IUserRepository.cs
?   ??? ?? UserRepository.cs
?   ??? ...
?
??? ?? Services/                        # Servicios
?   ??? ?? SessionManager.cs            # Gestión de sesión
?   ??? ?? PermissionManager.cs         # Gestión de permisos
?   ??? ?? Themes.cs                    # Gestión de temas
?   ??? ?? PrinterManager.cs            # Impresión
?
??? ?? Program.cs                       # Punto de entrada
??? ?? VentasApp.csproj                 # Archivo de proyecto

```

---

## 5. PATRONES DE DISEÑO IMPLEMENTADOS

### 5.1 MVP (Model-View-Presenter)
**Usado en**: Toda la aplicación

**Propósito**: Separar la lógica de presentación de la interfaz de usuario.

**Ejemplo**:
```csharp
// INTERFAZ (Contrato)
public interface IListProductsView
{
    event EventHandler SearchProductEvent;
    string searchValue { get; set; }
    void SetProductosListBindingSource(BindingSource source);
}

// VISTA (Implementación)
public partial class ListProductsView : BaseForm, IListProductsView
{
    public event EventHandler SearchProductEvent;
    // Implementación...
}

// PRESENTADOR (Lógica)
public class ListProductsPresenter
{
    private IListProductsView view;
    private IproductRepository repository;
    
    public ListProductsPresenter(IListProductsView view, IproductRepository repository)
    {
        this.view = view;
        this.repository = repository;
        this.view.SearchProductEvent += SearchProduct;
    }
}
```

### 5.2 Repository Pattern
**Usado en**: Capa de acceso a datos

**Propósito**: Abstraer el acceso a datos y facilitar el testing.

**Ejemplo**:
```csharp
// INTERFAZ
public interface IproductRepository
{
    IEnumerable<ProductModel> GetAllProducts();
    void AddProduct(AddProductDTO productDTO);
    void UpdateProduct(UpdateProductDTO productDTO);
    void DeleteProduct(int id);
}

// IMPLEMENTACIÓN
public class ProductRepository : IproductRepository
{
    public IEnumerable<ProductModel> GetAllProducts()
    {
        using (var context = new VentasDBContext())
        {
            return context.Products.Include(p => p.Category).ToList();
        }
    }
}
```

### 5.3 DTO (Data Transfer Object)
**Usado en**: Transferencia de datos entre capas

**Propósito**: Transferir solo los datos necesarios y validar entrada.

**Ejemplo**:
```csharp
public class AddProductDTO
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public uint Stock { get; set; }
    public int CategoryId { get; set; }
    public int? SupplierId { get; set; }
    public string? ImagePath { get; set; }
}
```

### 5.4 Singleton (Static Classes)
**Usado en**: SessionManager, Themes, PermissionManager

**Propósito**: Mantener un estado global en toda la aplicación.

---

## 6. FLUJO DE LA APLICACIÓN

### 6.1 Flujo de Inicio de Sesión

```
????????????????
?   Program.cs ? ??? PUNTO DE ENTRADA
????????????????
       ?
       ??? 1. Inicializa aplicación
       ??? 2. Establece tema (Themes.SetLightTheme())
       ?
       ?
????????????????
?  LoginView   ? ??? VISTA DE LOGIN
????????????????
       ?
       ??? 3. Usuario ingresa credenciales
       ??? 4. LoginPresenter valida credenciales
       ?
       ?
????????????????????
? UserRepository   ? ??? VALIDA EN BD
????????????????????
       ?
       ? ? CREDENCIALES VÁLIDAS
       ?
????????????????????
? SessionManager   ? ??? GUARDA SESIÓN
? - CurrentUserId  ?
? - CurrentUsername?
? - CurrentRoleId  ?
????????????????????
       ?
       ?
????????????????
?  MainView    ? ??? VENTANA PRINCIPAL
????????????????
```

### 6.2 Flujo de Navegación en MainView

```
???????????????????????
?     MainView        ?
?  (Ventana Principal)?
???????????????????????
           ?
           ??? Botón "Productos" ??????? ListProductsView
           ??? Botón "Ventas" ?????????? SaleView
           ??? Botón "Clientes" ???????? CustomerListView
           ??? Botón "Proveedores" ????? ListSuppliersView
           ??? Botón "Usuarios" ???????? ListUsersView
           ??? Botón "Cerrar Sesión" ??? LoginView
```

### 6.3 Flujo CRUD de Productos (Ejemplo Completo)

```
?????????????????????
? ListProductsView  ? ??? LISTA DE PRODUCTOS
?????????????????????
          ?
          ??? EVENTO: Click en "Buscar"
          ?   ???? ListProductsPresenter.SearchProduct()
          ?       ???? ProductRepository.SearchProducts(term)
          ?           ???? VentasDBContext
          ?
          ??? EVENTO: Click en "Agregar"
          ?   ???? ProductView (modo crear)
          ?       ???? ProductPresenter
          ?           ???? ProductRepository.AddProduct(dto)
          ?
          ??? EVENTO: Click en "Editar"
          ?   ???? ProductView (modo editar, id)
          ?       ???? ProductPresenter
          ?           ???? ProductRepository.UpdateProduct(dto)
          ?
          ??? EVENTO: Click en "Eliminar"
              ???? ProductRepository.DeleteProduct(id)
                  ???? Marca producto.Active = false
```

---

## 7. COMPONENTES PRINCIPALES

### 7.1 BaseForm

**Ubicación**: `Views/BaseForm.cs`

**Propósito**: Clase base para todos los formularios que proporciona:
- Sistema de temas automático
- Evento `FormLoadEvent`
- Método `CloseView()`

**Uso**:
```csharp
public partial class MyView : BaseForm, IMyView
{
    public MyView()
    {
        InitializeComponent();
        // Los temas se aplican automáticamente
    }
    
    protected override void CustomTheme()
    {
        // Personaliza temas específicos aquí
        MyButton.BackColor = Themes.MainActionButtonColor;
    }
}
```

**Funcionalidad**:
- **LoadColorTheme()**: Aplica colores del tema a todos los controles
- **SetAcceptButton()**: Configura el botón principal con estilo especial
- **ApplyThemeToControls()**: Aplica temas recursivamente a controles hijos

### 7.2 SessionManager

**Ubicación**: `Services/SessionManager.cs`

**Propósito**: Mantener información de la sesión actual del usuario.

```csharp
public static class SessionManager
{
    public static int CurrentUserId { get; set; }
    public static string CurrentUsername { get; set; }
    public static int CurrentUserRoleId { get; set; }
}
```

**Uso**:
```csharp
// Después del login
SessionManager.CurrentUserId = user.Id;
SessionManager.CurrentUsername = user.Username;
SessionManager.CurrentUserRoleId = user.RoleId;

// En cualquier parte de la aplicación
string username = SessionManager.CurrentUsername;
```

### 7.3 PermissionManager

**Ubicación**: `Services/PermissionManager.cs`

**Propósito**: Gestionar permisos basados en roles.

**Enumeraciones**:
```csharp
public enum Roles
{
    SysAdmin = 1,
    SalesManager = 2,
    Salesperson = 3,
    InventoryManager = 4,
    Accountant = 5,
    ExecutiveViewer = 6
}

public enum Permissions
{
    SalesViewAll = 1,
    SalesCreate = 2,
    ProductsView = 4,
    ProductsManage = 5,
    // ... más permisos
}
```

**Uso**:
```csharp
// Verificar si el usuario tiene permiso
if (PermissionManager.HasPermission(
    (Roles)SessionManager.CurrentUserRoleId, 
    Permissions.ProductsManage))
{
    // Permitir acceso
}
else
{
    MessageBox.Show("No tiene permisos");
    view.CloseView();
}
```

### 7.4 Themes

**Ubicación**: `Services/Themes.cs`

**Propósito**: Sistema de temas (claro/oscuro) para toda la aplicación.

**Propiedades**:
```csharp
public static Color SidebarBackgroundColor;
public static Color MainViewBackgroundColor;
public static Color MainActionButtonColor;
public static Color ColorNormalText;
// ... más colores
```

**Métodos**:
```csharp
Themes.SetLightTheme();  // Tema claro
Themes.SetDarkTheme();   // Tema oscuro
```

**Aplicación automática**: BaseForm aplica automáticamente el tema a todos los controles al cargar.

---

## 8. SISTEMA DE PERMISOS Y ROLES

### 8.1 Estructura de la Base de Datos

```
????????????        ????????????????????        ????????????????
?   User   ?????????? role_permission  ??????????  Permission  ?
?          ?        ?  (Many-to-Many)  ?        ?              ?
? RoleId   ?        ????????????????????        ?              ?
????????????        ? RoleId           ?        ????????????????
                    ? PermissionId     ?
      ?             ????????????????????
      ?
????????????
?   Role   ?
?          ?
????????????
```

### 8.2 Roles Predefinidos

| ID | Rol | Descripción |
|----|-----|-------------|
| 1 | SysAdmin | Acceso total al sistema |
| 2 | SalesManager | Gestión de ventas |
| 3 | Salesperson | Realizar ventas |
| 4 | InventoryManager | Gestión de inventario |
| 5 | Accountant | Visualización contable |
| 6 | ExecutiveViewer | Visualización ejecutiva |

### 8.3 Permisos Disponibles

- **SalesViewAll**: Ver todas las ventas
- **SalesCreate**: Crear ventas
- **SalesManage**: Gestión completa de ventas
- **ProductsView**: Ver productos
- **ProductsManage**: Gestión de productos
- **SuppliersView/Manage**: Proveedores
- **CustomersView/Manage**: Clientes
- **UsersView/Manage**: Usuarios
- **SystemManage**: Administración del sistema

### 8.4 Implementación en Presenters

**Patrón Recomendado**:
```csharp
public class ListProductsPresenter
{
    private bool accessGranted = false;
    
    private void CheckForPermission(object? sender, EventArgs e)
    {
        // Verificar permiso de gestión (completo)
        if (HasPermission((Roles)SessionManager.CurrentUserRoleId, 
                         Permissions.ProductsManage))
        {
            accessGranted = true;
            LoadAllProductsList();
            return;
        }
        
        // Verificar permiso de solo lectura
        if (HasPermission((Roles)SessionManager.CurrentUserRoleId, 
                         Permissions.ProductsView))
        {
            accessGranted = true;
            view.SetViewOnlyMode(); // Ocultar botones de edición
            LoadAllProductsList();
            return;
        }
        
        // Sin permisos
        MessageBox.Show("No tiene permisos para acceder a esta sección.");
        view.CloseView();
    }
}
```

---

## 9. SISTEMA DE TEMAS

### 9.1 Arquitectura del Sistema de Temas

El sistema de temas está implementado en tres niveles:

#### **Nivel 1: Themes (Service)**
Define los colores y configuraciones.

#### **Nivel 2: BaseForm**
Aplica automáticamente los temas a todos los controles.

#### **Nivel 3: CustomTheme() Override**
Cada formulario puede personalizar su tema.

### 9.2 Colores Disponibles

```csharp
// TEMA CLARO
MainViewBackgroundColor = Color.White;
MainViewButtonColor = Color.FromArgb(220, 220, 220);
ColorNormalText = Color.Black;
MainActionButtonColor = Color.FromArgb(0, 123, 255); // Azul

// TEMA OSCURO
MainViewBackgroundColor = Color.FromArgb(45, 45, 48);
MainViewButtonColor = Color.FromArgb(73, 80, 87);
ColorNormalText = Color.White;
MainActionButtonColor = Color.FromArgb(108, 168, 255); // Azul claro
```

### 9.3 Controles Soportados

- **Button**: Cambia color de fondo, texto y efectos hover
- **Panel**: Mantiene transparencia y aplica color
- **Label**: Cambia color de texto
- **TextBox**: Cambia fondo y texto
- **DataGridView**: Aplica tema completo con headers

### 9.4 Personalizar Temas en un Formulario

```csharp
public partial class MainView : BaseForm, IMainView
{
    protected override void CustomTheme()
    {
        // Personalización específica
        SidePanel.BackColor = Themes.SidebarBackgroundColor;
        
        // Aplicar a botones específicos
        foreach (Control control in SidePanel.Controls)
        {
            if (control is Button button)
            {
                button.BackColor = Themes.SidebarButtonColor;
            }
        }
        
        // Aplicar imágenes según tema
        LogoPicturebox.Image = Themes.LogoImage;
    }
}
```

---

## 10. BASE DE DATOS

### 10.1 Configuración de Conexión

La cadena de conexión se almacena de forma segura usando **User Secrets**.

**Configurar User Secrets**:
```bash
# En la terminal
dotnet user-secrets init
dotnet user-secrets set "MySqlConnection" "server=localhost;database=ventasdb;user=root;password=tupassword"
```

**Acceso en el código**:
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    IConfiguration configuration = new ConfigurationBuilder()
        .AddUserSecrets<VentasDBContext>()
        .Build();

    string connectionString = configuration["MySqlConnection"];
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}
```

### 10.2 Entidades Principales

#### **ProductModel**
```csharp
[Table("product")]
public class ProductModel
{
    [Key, Column("product_id")]
    public int Id { get; set; }
    
    [Column("product_name"), Required]
    public string Name { get; set; }
    
    [Column("price"), Required]
    public decimal Price { get; set; }
    
    [Column("stock"), Required]
    public uint Stock { get; set; }
    
    [Column("category_id"), Required]
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public CategoryModel Category { get; set; }
    
    [Column("active_state"), Required]
    public bool Active { get; set; }
}
```

#### **Relaciones**
- **Product** ? **Category**: Many-to-One
- **Product** ? **Supplier**: Many-to-One (opcional)
- **Product** ? **SaleItem**: One-to-Many
- **Sale** ? **Customer**: Many-to-One
- **Sale** ? **User**: Many-to-One
- **User** ? **Role**: Many-to-One
- **Role** ? **Permission**: Many-to-Many

### 10.3 Migraciones (Entity Framework)

```bash
# Crear migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update

# Revertir migración
dotnet ef database update MigracionAnterior

# Eliminar última migración
dotnet ef migrations remove
```

---

## 11. GUÍA PARA AGREGAR NUEVAS FUNCIONALIDADES

### 11.1 Agregar un Nuevo Módulo Completo (Ejemplo: "Categorías")

#### **PASO 1: Crear el Modelo**

**Archivo**: `Models/CategoryModel.cs`
```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasApp.Models
{
    [Table("category")]
    public class CategoryModel
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }
        
        [Column("category_name")]
        [Required]
        public string CategoryName { get; set; }
        
        [Column("active_state")]
        public bool Active { get; set; }
        
        public ICollection<ProductModel> Products { get; set; }
    }
}
```

#### **PASO 2: Crear DTOs**

**Archivo**: `Models/DTOs/AddCategoryDTO.cs`
```csharp
namespace VentasApp.Models.DTOs
{
    public class AddCategoryDTO
    {
        public string CategoryName { get; set; }
    }
}
```

**Archivo**: `Models/DTOs/UpdateCategoryDTO.cs`
```csharp
namespace VentasApp.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
```

#### **PASO 3: Crear el Repository**

**Archivo**: `Repositories/ICategoryRepository.cs`
```csharp
namespace VentasApp.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(int id);
        void AddCategory(AddCategoryDTO dto);
        void UpdateCategory(UpdateCategoryDTO dto);
        void DeleteCategory(int id);
    }
}
```

**Archivo**: `Repositories/CategoryRepository.cs`
```csharp
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            using (var context = new VentasDBContext())
            {
                return context.Categories
                    .Where(c => c.Active == true)
                    .ToList();
            }
        }
        
        public void AddCategory(AddCategoryDTO dto)
        {
            using (var context = new VentasDBContext())
            {
                var category = new CategoryModel
                {
                    CategoryName = dto.CategoryName,
                    Active = true
                };
                
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        
        // ... implementar otros métodos
    }
}
```

#### **PASO 4: Crear la Interfaz de Vista**

**Archivo**: `Views/Category/IListCategoriesView.cs`
```csharp
namespace VentasApp.Views.Category
{
    public interface IListCategoriesView : IBaseForm
    {
        event EventHandler SearchCategoryEvent;
        event EventHandler AddCategoryEvent;
        event EventHandler EditCategoryEvent;
        event EventHandler DeleteCategoryEvent;
        
        string SearchValue { get; set; }
        
        void SetCategoriesBindingSource(BindingSource source);
        int? GetSelectedCategoryId();
    }
}
```

#### **PASO 5: Crear la Vista (Windows Form)**

**Archivo**: `Views/Category/ListCategoriesView.cs`
```csharp
public partial class ListCategoriesView : BaseForm, IListCategoriesView
{
    public event EventHandler SearchCategoryEvent;
    public event EventHandler AddCategoryEvent;
    public event EventHandler EditCategoryEvent;
    public event EventHandler DeleteCategoryEvent;
    
    public string SearchValue 
    { 
        get => SearchTextBox.Text; 
        set => SearchTextBox.Text = value; 
    }
    
    public ListCategoriesView()
    {
        InitializeComponent();
        SetupEventHandlers();
    }
    
    private void SetupEventHandlers()
    {
        SearchButton.Click += (s, e) => SearchCategoryEvent?.Invoke(this, EventArgs.Empty);
        AddButton.Click += (s, e) => AddCategoryEvent?.Invoke(this, EventArgs.Empty);
        EditButton.Click += (s, e) => EditCategoryEvent?.Invoke(this, EventArgs.Empty);
        DeleteButton.Click += (s, e) => DeleteCategoryEvent?.Invoke(this, EventArgs.Empty);
    }
    
    public void SetCategoriesBindingSource(BindingSource source)
    {
        CategoriesDataGridView.DataSource = source;
    }
    
    public int? GetSelectedCategoryId()
    {
        if (CategoriesDataGridView.CurrentRow != null)
        {
            return (int)CategoriesDataGridView.CurrentRow.Cells["CategoryId"].Value;
        }
        return null;
    }
}
```

#### **PASO 6: Crear el Presenter**

**Archivo**: `Presenters/ListCategoriesPresenter.cs`
```csharp
using VentasApp.Repositories;
using VentasApp.Views.Category;

namespace VentasApp.Presenters
{
    public class ListCategoriesPresenter
    {
        private IListCategoriesView view;
        private ICategoryRepository repository;
        private BindingSource categoriesBindingSource;
        
        public ListCategoriesPresenter(IListCategoriesView view, ICategoryRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.categoriesBindingSource = new BindingSource();
            
            // Suscribir eventos
            this.view.FormLoadEvent += LoadCategories;
            this.view.SearchCategoryEvent += SearchCategories;
            this.view.AddCategoryEvent += AddCategory;
            this.view.EditCategoryEvent += EditCategory;
            this.view.DeleteCategoryEvent += DeleteCategory;
            
            // Configurar binding
            this.view.SetCategoriesBindingSource(categoriesBindingSource);
        }
        
        private void LoadCategories(object? sender, EventArgs e)
        {
            var categories = repository.GetAllCategories();
            categoriesBindingSource.DataSource = categories;
        }
        
        private void SearchCategories(object? sender, EventArgs e)
        {
            // Implementar búsqueda
        }
        
        private void AddCategory(object? sender, EventArgs e)
        {
            // Mostrar formulario de agregar
        }
        
        // ... otros métodos
    }
}
```

#### **PASO 7: Integrar en MainView**

**En `Views/IMainView.cs`**:
```csharp
public interface IMainView : IBaseForm
{
    event EventHandler CategoriesButtonEvent;
    // ... otros eventos
}
```

**En `Views/MainView.cs`**:
```csharp
public event EventHandler CategoriesButtonEvent;

private void SetupEventsHandler()
{
    CategoriesButton.Click += delegate { CategoriesButtonEvent?.Invoke(this, EventArgs.Empty); };
}
```

**En `Presenters/MainViewPresenter.cs`**:
```csharp
public MainViewPresenter(IMainView mainView, ILoginView loginView)
{
    this.view.CategoriesButtonEvent += LoadCategoriesView;
}

private void LoadCategoriesView(object? sender, EventArgs e)
{
    ListCategoriesView categoriesView = new ListCategoriesView();
    new ListCategoriesPresenter(categoriesView, new CategoryRepository());
    view.LoadMainPanelView(categoriesView);
}
```

---

### 11.2 Agregar una Nueva Columna a una Entidad Existente

#### **PASO 1: Modificar el Modelo**

```csharp
[Table("product")]
public class ProductModel
{
    // ... propiedades existentes ...
    
    [Column("discount_percentage")]
    public decimal? DiscountPercentage { get; set; } // Nueva propiedad
}
```

#### **PASO 2: Actualizar DTOs**

```csharp
public class AddProductDTO
{
    // ... propiedades existentes ...
    public decimal? DiscountPercentage { get; set; }
}
```

#### **PASO 3: Crear y Aplicar Migración**

```bash
dotnet ef migrations add AddDiscountToProduct
dotnet ef database update
```

#### **PASO 4: Actualizar Repository**

```csharp
public void AddProduct(AddProductDTO productDTO)
{
    var product = new ProductModel
    {
        // ... asignaciones existentes ...
        DiscountPercentage = productDTO.DiscountPercentage
    };
}
```

#### **PASO 5: Actualizar Vista**

Agregar control en el formulario y exponerlo en la interfaz.

---

## 12. BUENAS PRÁCTICAS DEL PROYECTO

### 12.1 Naming Conventions

#### **Clases**
- Models: `NombreModel.cs` (ej: `ProductModel.cs`)
- Views: `NombreView.cs` (ej: `ListProductsView.cs`)
- Presenters: `NombrePresenter.cs` (ej: `ProductPresenter.cs`)
- Repositories: `NombreRepository.cs` (ej: `ProductRepository.cs`)
- Interfaces: `INombre.cs` (ej: `IProductRepository.cs`, `IProductView.cs`)

#### **Eventos**
- Sufijo: `Event` (ej: `SearchProductEvent`, `AddButtonEvent`)
- Tipo: `EventHandler`

#### **Métodos de Presenter**
- Usar verbos descriptivos (ej: `LoadProducts()`, `SearchProduct()`, `DeleteProduct()`)

### 12.2 Gestión de Recursos

#### **using Statements**
Siempre usar `using` con DbContext:
```csharp
using (var context = new VentasDBContext())
{
    return context.Products.ToList();
}
```

#### **Dispose de Formularios**
Los formularios se cierran automáticamente con `CloseView()`.

### 12.3 Validación de Datos

#### **En DTOs**
```csharp
public class AddProductDTO
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Name { get; set; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Price { get; set; }
}
```

#### **En Presenters**
```csharp
private void SaveProduct(object? sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(view.ProductName))
    {
        MessageBox.Show("El nombre es requerido", "Validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
    
    // Proceder a guardar...
}
```

### 12.4 Manejo de Errores

```csharp
public void AddProduct(AddProductDTO productDTO)
{
    try
    {
        using (var context = new VentasDBContext())
        {
            var product = new ProductModel { /* ... */ };
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
    catch (DbUpdateException ex)
    {
        // Log del error
        MessageBox.Show("Error al guardar el producto: " + ex.InnerException?.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### 12.5 Uso de BindingSource

```csharp
private BindingSource productsBindingSource;

public ListProductsPresenter(IListProductsView view, IproductRepository repository)
{
    this.productsBindingSource = new BindingSource();
    this.view.SetProductosListBindingSource(productsBindingSource);
}

private void LoadProducts()
{
    var products = repository.GetAllProducts();
    
    var displayList = products.Select(p => new
    {
        Id = p.Id,
        Nombre = p.Name,
        Precio = p.Price,
        Stock = p.Stock
    }).ToList();
    
    productsBindingSource.DataSource = displayList;
}
```

---

## 13. RESOLUCIÓN DE PROBLEMAS COMUNES

### 13.1 Error de Conexión a Base de Datos

**Problema**: `Unable to connect to any of the specified MySQL hosts`

**Solución**:
1. Verificar que MySQL esté ejecutándose
2. Revisar User Secrets:
   ```bash
   dotnet user-secrets list
   ```
3. Actualizar cadena de conexión:
   ```bash
   dotnet user-secrets set "MySqlConnection" "server=localhost;database=ventasdb;user=root;password=tupassword"
   ```

### 13.2 Formulario no Aplica Temas

**Problema**: Los colores no cambian al aplicar tema

**Solución**:
1. Verificar que la clase herede de `BaseForm`:
   ```csharp
   public partial class MyView : BaseForm, IMyView
   ```
2. Llamar a `LoadColorTheme()` si es necesario:
   ```csharp
   protected override void CustomTheme()
   {
       base.CustomTheme();
       // Tus personalizaciones
   }
   ```

### 13.3 Permisos no Funcionan

**Problema**: Usuario con permisos no puede acceder

**Solución**:
1. Verificar que `SessionManager.CurrentUserRoleId` esté configurado
2. Revisar tabla `role_permission` en la base de datos
3. Verificar llamada a `CheckForPermission` en el evento `FormLoadEvent`

### 13.4 DataGridView no Muestra Datos

**Problema**: El grid aparece vacío

**Solución**:
1. Verificar que `DataSource` esté configurado:
   ```csharp
   view.SetProductosListBindingSource(productsBindingSource);
   ```
2. Verificar que el repositorio retorne datos:
   ```csharp
   var products = repository.GetAllProducts();
   Debug.WriteLine($"Productos obtenidos: {products.Count()}");
   ```
3. Revisar que las propiedades del objeto anónimo coincidan con las columnas

### 13.5 Migración Falla

**Problema**: Error al aplicar migración

**Solución**:
1. Revertir migración:
   ```bash
   dotnet ef database update MigracionAnterior
   ```
2. Eliminar migración:
   ```bash
   dotnet ef migrations remove
   ```
3. Crear nueva migración:
   ```bash
   dotnet ef migrations add NombreDescriptivo
   ```

---

## ?? CONCLUSIÓN

Este documento cubre todos los aspectos fundamentales del proyecto **VentasApp**. Para profundizar en algún tema específico:

- **Arquitectura MVP**: Revisar implementación de `ListProductsView`, `ListProductsPresenter` y `ProductRepository`
- **Sistema de Permisos**: Estudiar `PermissionManager.cs` y su uso en Presenters
- **Temas**: Analizar `Themes.cs` y `BaseForm.cs`
- **Entity Framework**: Revisar `VentasDBContext.cs` y modelos

### Recursos Adicionales

- [Documentación de Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Patrón MVP en C#](https://docs.microsoft.com/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Windows Forms Best Practices](https://docs.microsoft.com/dotnet/desktop/winforms/)

---

**Última actualización**: Diciembre 2024  
**Versión del proyecto**: 1.0  
**Framework**: .NET 8.0

