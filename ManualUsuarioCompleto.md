# Manual de Usuario Completo

Sistema de Gestión de Ventas (VentasApp)

Universidad Nacional del Nordeste (UNNE) – Taller de Programación II 2025

---

## Índice

- 1. Introducción
- 2. Requisitos Previos
- 3. Instalación y Configuración
  - 3.1 Configurar conexión a la base de datos (User Secrets)
  - 3.2 Requisitos de MySQL Client (mysqldump/mysql)
  - 3.3 Ejecutar la aplicación
- 4. Roles y Permisos
- 5. Navegación General
- 6. Gestión de Productos
- 7. Gestión de Proveedores
- 8. Gestión de Clientes
- 9. Gestión de Usuarios
- 10. Ventas y Facturación
- 11. Reportes Gerenciales (Dashboard)
- 12. Sistema y Configuración
- 13. Exportación de Datos a PDF
- 14. Seguridad y Permisos
- 15. Resolución de Problemas (FAQ)
- 16. Buenas Prácticas Operativas
- 17. Glosario
- 18. Notas y Limitaciones
- 19. Próximas Mejoras Sugeridas (Opcional)
- 20. Contacto / Soporte

## 1. Introducción

VentasApp es una aplicación de escritorio para la gestión integral de ventas, productos, clientes, proveedores, usuarios y reportes gerenciales. Incluye módulos de facturación, análisis de desempeño, panel de métricas (Dashboard), exportación de reportes en PDF y respaldo / restauración de la base de datos.

Este manual describe paso a paso cómo utilizar cada función según el rol del usuario y sus permisos.

---

## 2. Requisitos Previos

- Sistema Operativo: Windows 10 o superior.
- .NET 8 Runtime (si se distribuye solo el ejecutable).
- Conectividad con la base de datos MySQL configurada en los secretos de usuario (User Secrets).
- Herramienta `mysqldump` y cliente `mysql` disponibles en el PATH para realizar backup y restore.

---

## 3. Instalación y Configuración

### 3.1 Configurar conexión a la base de datos (User Secrets)

La aplicación lee la cadena de conexión MySQL desde los Secretos de Usuario (no se guarda en el repositorio), clave `MySqlConnection`.

Ejemplo de valor:

```
{"MySqlConnection": "server=localhost;uid=usuario;pwd=clave;database=ventasdb"}
```

Opciones para configurarlo:

- Visual Studio: clic derecho sobre el proyecto `VentasApp` > Manage User Secrets > pegue el JSON anterior ajustando credenciales y base.
- CLI (opcional):

```powershell
dotnet user-secrets init
dotnet user-secrets set "MySqlConnection" "server=localhost;uid=usuario;pwd=clave;database=ventasdb"
```

### 3.2 Requisitos de MySQL Client (mysqldump/mysql)

Para las funciones de respaldo y restauración, instale MySQL Client Tools y agregue al PATH del sistema los ejecutables `mysqldump` y `mysql`.

- Verifique desde PowerShell:

```powershell
mysqldump --version
mysql --version
```

### 3.3 Ejecutar la aplicación

- Desde Visual Studio: abra la solución `VentasApp.sln` y presione Iniciar.
- Desde ejecutable: use el binario compilado en `bin/Release/net8.0-windows/`.

---

## 4. Roles y Permisos

El sistema gestiona seguridad por Roles y Permisos (ver `PermissionManager`).

**Roles definidos:**

- Admin (Administrador General)
- SalesManager (Gerente / Responsable de Ventas)
- Salesperson (Vendedor)
- Inventory (Gestión de Inventario / Depósito)

**Permisos (resumen):**

1. SalesViewAll – Ver todas las ventas.
2. SalesCreate – Crear ventas / facturar.
3. SalesManage – Anular / gestionar ventas.
4. ProductsView – Ver productos.
5. ProductsManage – Crear / editar / activar / desactivar productos.
6. SuppliersView – Ver proveedores.
7. SuppliersManage – Registrar / editar proveedores.
8. CustomersView – Ver clientes.
9. CustomersManage – Registrar / activar / desactivar clientes.
10. UsersView – Ver usuarios.
11. UsersManage – Crear / editar / activar / desactivar usuarios.
12. DashboardView – Ver panel gerencial.
13. SystemView – Ver configuración del sistema.
14. SystemManage – Cambiar opciones del sistema (temas, etc.).
15. SystemBackup – Realizar respaldo / restauración.

Sugerencia rápida por rol:

- Admin: acceso completo a todos los módulos y respaldo.
- SalesManager: ventas, dashboard, reportes, visión global.
- Salesperson: ventas, facturación, clientes, listado de productos.
- Inventory: productos y proveedores.

El menú se adapta automáticamente: si el rol no posee un permiso, el botón / acción asociada no estará disponible.

---

## 5. Inicio y Acceso

1. Ejecute el archivo principal de la aplicación (o abra la solución y presione Iniciar).
2. Se mostrará la pantalla de inicio de sesión.
3. Ingrese su correo y contraseña.
4. Presione **Iniciar Sesión**.
5. El sistema carga su sesión y permisos (`SessionManager`).

Si las credenciales son válidas, se abrirá la vista principal (`MainView`) con el menú lateral adecuado a su rol.

---

## 6. Navegación General

El panel principal se compone de:

- Barra lateral: accesos a módulos (Productos, Ventas, Clientes, Proveedores, Reportes, Usuarios, Sistema).
- Área central: contenido dinámico (listas, formularios, gráficos, tablas).
- Botones de acción: Crear, Guardar, Exportar, Backup, Restaurar, etc.

Colores y estilo provienen del gestor de temas (`Themes.SetLightTheme` por defecto; también existe `SetDarkTheme`).

---

## 7. Gestión de Productos

Disponible para roles con permisos `ProductsView` y `ProductsManage`.

### 6.1 Listar Productos

1. Abra el módulo "Listar Productos".
2. Use campo de **Búsqueda** (por Nombre, Código, Marca, etc.).
3. Filtro por **Categoría** para acotar resultados.
4. La tabla muestra: Código, Nombre, Marca, Stock, Talle, Categoría.
5. Productos con stock = 0 pueden resaltarse (indicando falta de inventario).
6. Limpiar filtros para ver todo el listado nuevamente.

### 6.2 Registrar / Modificar Producto

1. Seleccione "Registrar Producto" o equivalente.
2. Complete: Código, Nombre, Descripción, Talle, Categoría, Color, Marca, Precio, Stock, Proveedor.
3. Verifique que el Código no exista previamente.
4. Presione **Guardar / Registrar**.
5. Use **Limpiar campos** para iniciar una nueva carga.

### 6.3 Análisis de Inventario

El panel de gestión puede mostrar:

- Alertas de stock bajo.
- Productos sin stock.
- Actividad reciente (altas, modificaciones, desactivaciones).
- Historial de movimientos.

### 6.4 Activar / Desactivar Producto

1. Seleccione producto en la lista.
2. Use botón Activar / Desactivar (si está implementado en su rol).
3. Confirme la acción.

---

## 8. Gestión de Proveedores

Permisos requeridos: `SuppliersView`, `SuppliersManage`.

### 7.1 Registrar Proveedor

1. Abra "Registrar Proveedor".
2. Complete: Nombre, Empresa, CUIT, Teléfono, Correo, Dirección, País, Ciudad.
3. Verifique CUIT y datos de contacto.
4. Presione **Registrar Proveedor**.
5. Use **Limpiar Campos** para nueva carga.

### 7.2 Listar / Filtrar

- Campo **Buscar por** y filtro de **Estado** (Activo / Desactivado / Todos).
- Tabla: Nombre, Empresa, CUIT, Teléfono, Estado.

### 7.3 Activar / Desactivar

Seleccionar fila y aplicar acción (si rol lo permite).

---

## 9. Gestión de Clientes

Permisos: `CustomersView`, `CustomersManage`.

### 8.1 Registrar Cliente

1. Abra "Registrar Cliente".
2. Complete: Nombre, Apellido, DNI, Teléfono, Correo, Dirección, País, Ciudad.
3. Presione **Registrar Cliente**.
4. Limpie para nueva carga.

### 8.2 Listar / Buscar

- Buscar por Nombre, Apellido, DNI.
- Filtrar por Estado (Activo / Inactivo).
- Tabla: DNI, Nombre, Apellido, Teléfono, Correo, Estado.

### 8.3 Activar / Desactivar Cliente

1. Seleccione fila del cliente.
2. Botón **Activar Cliente** (verde) o **Desactivar Cliente** (rojo).
3. Verificar estado actualizado.

---

## 10. Gestión de Usuarios

Permisos: `UsersView`, `UsersManage`.

### 9.1 Registrar Usuario

1. Abra "Registrar Usuario".
2. Complete: Nombre, Apellido, DNI, Teléfono, Dirección, País, Ciudad, Fecha Nacimiento, Correo.
3. Seleccione Rol (Admin, SalesManager, Salesperson, Inventory u otros definidos en la base).
4. Ingrese Contraseña y Confirmar Contraseña.
5. Presione **Registrar**.
6. Filtros para búsqueda: por nombre/apellido/DNI, Rol y Estado.

### 9.2 Listar Usuarios

- Tabla muestra: DNI, Nombre, Apellido, Teléfono, Rol, Estado.
- Usar filtros superiores para acotar.

### 9.3 Activar / Desactivar

Acción disponible en módulo de gestión si permisos lo permiten.

---

## 11. Ventas y Facturación

Permisos: `SalesViewAll`, `SalesCreate`, `SalesManage`.

### 10.1 Listar Ventas

1. Abra "Listar Ventas".
2. Filtros: Apellido / DNI cliente, Nº Factura, Rango de fechas.
3. Botón **Buscar** aplica filtros. **Limpiar** restaura lista completa.
4. Tabla: Nº Factura, Fecha, Cliente, Método de Pago, Total.
5. Botón **Ver factura** (si disponible) muestra detalle.

### 10.2 Facturación (Crear Venta)

1. Abra "Facturación" / "Nueva Venta".
2. Seleccione Cliente (ícono búsqueda). Datos se completan.
3. Busque Producto por nombre o código.
4. Indique Cantidad y agregue a la grilla.
5. Tabla interna: Código, Producto, Talle, Cantidad, Precio Unitario, Subtotal.
6. Seleccione Método de Pago.
7. Ingrese Monto recibido para cálculo automático del Vuelto.
8. Verifique Subtotal, IVA (21%) y Total.
9. Presione **Generar** para confirmar la venta.
10. Use **Cancelar** para descartar cambios.

### 10.3 Gestión / Anulación

- Solo disponible con `SalesManage`.
- Seleccionar venta y aplicar acción (según interfaz implementada).

### 10.4 Exportar Factura a PDF

1. Abra detalle de factura (o módulo de impresión).
2. Presione **Exportar / Imprimir PDF**.
3. Seleccione ubicación y nombre de archivo.
4. Confirmar; se genera factura PDF (usa `PdfService.ExportarFactura`).

---

## 12. Reportes Gerenciales (Dashboard)

Permiso: `DashboardView`.

### 11.1 Dashboard

1. Abra "Dashboard".
2. Defina período: rango personalizado (Desde / Hasta) o accesos rápidos (Última semana, Mes actual, Últimos meses).
3. Presione **Aplicar** para refrescar KPIs:
   - Ventas Totales.
   - Productos Vendidos.
   - Clientes Nuevos.
4. Gráficos: Ingresos diarios, Top Productos (gráfico circular), Top 5 productos (tabla), distribución por categoría.
5. Botón **Exportar resumen del periodo (PDF)** genera informe ejecutivo (usa `PdfService.ExportFullDashboard`).

### 11.2 Reportes de Rendimiento de Vendedores

1. Abra "Rendimiento".
2. Seleccione fecha Desde / Hasta.
3. Filtro Vendedor específico o "Todos".
4. Presione **Aplicar**.
5. KPIs: Ingresos (mes), Ventas (unidades).
6. Gráficos comparativos: barras (Ingresos mensuales / por vendedor), circular (Productos vendidos).
7. Exportar a PDF tabla de rendimiento si la vista lo ofrece (usa `PdfService.ExportarDatosTabla`).

### 11.3 Reportes de Productos (Si corresponde)

- Similar: seleccionar período, aplicar filtros y exportar.

### 11.4 Exportaciones PDF

- Dashboard completo.
- Facturas individuales.
- Listas (Productos, Vendedores, etc.) mediante `ExportarDatosTabla<T>`.

---

## 13. Sistema y Configuración

Permisos: `SystemView`, `SystemManage`, `SystemBackup`.

### 12.1 Temas (Apariencia)

El sistema carga tema claro al inicio (`SetLightTheme`). Existe soporte para tema oscuro (`SetDarkTheme`). Si la interfaz incluye un selector:

1. Abra "Configuración" / "Sistema".
2. Elija tema Claro u Oscuro.
3. Se actualizan colores de barra lateral, botones, texto y logos.

(Nota: Si el selector no está visible, esta función puede estar en desarrollo. Asunción documentada.)

### 12.2 Backup de Base de Datos

1. Abra módulo "Sistema" / "Backup".
2. Presione **Crear Backup** (botón habilitado si `SystemBackup`).
3. Seleccione ubicación y nombre sugerido (formato `backup_base_YYYYMMDD_HHMMSS.sql`).
4. Confirmar. El sistema ejecuta `mysqldump` y guarda archivo.
5. Mensaje de éxito muestra ruta.

### 12.3 Restauración de Base de Datos (¡Acción Crítica!)

1. Presione **Restaurar Backup**.
2. Seleccione archivo `.sql` válido.
3. Lea detenidamente la advertencia (la restauración sobrescribe TODOS los datos actuales).
4. Confirme solo si está seguro. (Irreversible.)
5. Se ejecuta cliente `mysql` para cargar el contenido.
6. Mensaje final indica éxito o error.

### 12.4 Buenas Prácticas Backup

- Realizar backup antes de actualizaciones masivas o cambios de versión.
- Mantener al menos 3 copias históricas (diaria/semanal/mensual).
- Almacenar respaldos en ubicación externa segura.

---

## 14. Exportación de Datos a PDF

Funciones gestionadas por `PdfService` usando QuestPDF (Licencia Community). Tipos:

- Facturas (detalle de venta + items + totales).
- Resumen ejecutivo Dashboard (gráficos y tablas).
- Listas tabulares genéricas (recupera propiedades reflejadas de DTO o modelos).

Pasos generales:

1. Presionar botón **Exportar** en la vista correspondiente.
2. Elegir destino y nombre.
3. Confirmar generación.
4. Abrir PDF para validar contenido.

---

## 15. Seguridad y Permisos

- Los controles visuales se habilitan/deshabilitan según `HasPermission`.
- No comparta credenciales.
- Revocar usuarios inactivos marcándolos como desactivados.
- Antes de restaurar un backup, corroborar integridad del archivo.

---

## 16. Resolución de Problemas (FAQ)

| Problema                      | Posible Causa                    | Solución                                                       |
| ----------------------------- | -------------------------------- | -------------------------------------------------------------- |
| No puedo iniciar sesión       | Credenciales incorrectas         | Verifique correo y contraseña. Solicite reset a administrador. |
| Botón de Backup deshabilitado | Falta permiso `SystemBackup`     | Inicie sesión con rol adecuado o solicite permiso.             |
| Error al generar Backup       | `mysqldump` no está en PATH      | Instale MySQL Client Tools y agregue al PATH.                  |
| PDF vacío o sin gráficos      | Gráfico no cargado en memoria    | Refresque Dashboard y reintente exportar.                      |
| Factura no genera PDF         | SalePresenter no encuentra venta | Verifique que la venta esté confirmada antes de imprimir.      |

---

## 17. Buenas Prácticas Operativas

- Mantener stocks actualizados para evitar ventas sin disponibilidad.
- Revisar Dashboard diariamente para detectar tendencias de ventas y productos top.
- Exportar reportes periódicos (semanales / mensuales) y conservarlos.
- Realizar backup al menos una vez al día o antes de cambios estructurales.
- Usar filtros de búsqueda para agilizar procesos de auditoría.

---

## 18. Glosario

- **Backup:** Copia de seguridad de la base de datos.
- **Restore:** Proceso de recuperación de un backup, reemplaza datos actuales.
- **KPIs:** Indicadores clave (Ventas Totales, Productos Vendidos, Clientes Nuevos).
- **DTO:** Objeto de Transferencia de Datos usado para exportar/reportar.
- **Stock Bajo:** Cantidad por debajo del umbral mínimo establecido.

---

## 19. Notas y Limitaciones

- Tema oscuro requiere que la interfaz exponga un selector (no siempre visible).
- Algunas funciones (activar/desactivar productos/usuarios) dependen de implementación en vistas específicas.
- Permisos y roles adicionales pueden existir en la base de datos aunque no se definan en el enumerado (ajuste en producción).

---

## 20. Próximas Mejoras Sugeridas (Opcional)

- Selector de tema en tiempo real para usuario final.
- Exportación a Excel además de PDF.
- Historial de auditoría expandido con filtros avanzados.
- Programación de backups automáticos.
- Búsqueda global (omnibox) para cualquier entidad.

---

## 21. Contacto / Soporte

Para incidencias técnicas contactar al Administrador del Sistema o al equipo docente responsable del proyecto.

---

_Fin del Manual._
