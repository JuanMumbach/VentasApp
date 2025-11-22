# Manual de Usuario - VentasApp

**Bienvenido a VentasApp.** Este manual está diseñado para guiarte a través de las funcionalidades del sistema.

---

## Índice

1. [Acceso](#1-acceso)
2. [Rol: Vendedor (Salesperson)](#2-rol-vendedor)
3. [Rol: Encargado de Inventario (Inventory)](#3-rol-encargado-de-inventario)
4. [Rol: Gerente de Ventas (SalesManager)](#4-rol-gerente-de-ventas)
5. [Rol: Administrador (Admin)](#5-rol-administrador)
6. [Solución de Problemas Comunes](#6-solución-de-problemas-comunes)

---

## 1. Acceso

### Iniciar Sesión
1. Al abrir la aplicación, verás la pantalla de **Login**.
2. Ingresa tu **Nombre de Usuario** y **Contraseña**.
3. Haz clic en **"Iniciar Sesión"**.
   - *Nota: Si olvidaste tu contraseña, contacta al Administrador.*

![Login](/Docs/user-guide-images/login.png)


### Menú Principal
Una vez dentro, verás una barra lateral izquierda con los botones que te dan acceso a las distintas funcionalidades del sistema.

**Importante:** Solo podrás interactuar con los botones de las funcionalidades para las que tu rol tiene permiso. Si notas que hay opciones del menú que tienen colores más apagados (ej. "Usuarios" o "Backup"), es porque tu perfil no tiene permiso para acceder a esa área.

![Vista principal](/Docs/user-guide-images/mainview-salesperson.png)

### Cerrar Sesión
Para salir, haz clic en el botón **"Cerrar Sesión"** ubicado en la parte inferior de la barra lateral.

---

## 2. Rol: Vendedor
**Objetivo:** Realizar ventas de mostrador y gestionar la cartera de clientes.

### 2.1. Realizar una Venta (Facturación)
1. Ve a la sección **"VENDER"**.

![Venta](/Docs/user-guide-images/salesperson-sale.png)

2. **Seleccionar Cliente:**
   - Puedes saltarte este paso si se trata de una venta ocasional a un cliente no habitual.
   - Puedes seleccionar un cliente existente del menú desplegable o usar el botón de búsqueda (lupa).
   - Si es un cliente nuevo, ve al módulo de Clientes (en el menú lateral) para crearlo.
3. **Agregar Productos:**
   - Haz clic en **"Agregar"**. Se abrirá una ventana para buscar productos.
   - Busca por nombre o ID. Verifica que haya **Stock** disponible.
   - Ingresa la cantidad y confirma.

![Venta](/Docs/user-guide-images/salesperson-saleitem.png)

4. **Finalizar Venta:**
   - Verifica el total en pantalla.
   - Haz clic en **"Finalizar Venta"**.
   - **Imprimir:** Se te preguntará si deseas generar el comprobante en PDF.

### 2.2. Gestión de Clientes
1. Ve a la sección **"Clientes"**.

![Clientes](/Docs/user-guide-images/salesperson-customers.png)

2. **Buscar:** Usa la barra superior para buscar por nombre o DNI.
3. **Nuevo Cliente:** Haz clic en "Agregar" y completa los datos (Nombre, Apellido, DNI, Teléfono, Dirección).
4. **Editar:** Si un cliente cambió de dirección o teléfono, selecciónalo y haz clic en "Editar".

![Crear/editar cliente](/Docs/user-guide-images/salesperson-customeredit.png)

### 2.3. Consultar Productos
1. Ve a la sección **"Productos"**.
2. Podrás ver la lista de precios y el stock actual.
   - *Nota: Como vendedor, solo tienes permiso de lectura. No podrás editar precios ni stock.*

![Productos](/Docs/user-guide-images/salesperson-products.png)

### 2.4. Historial de Ventas
1. Ve a la sección **"Historial Ventas"**.

![Historial ventas](/Docs/user-guide-images/salesperson-sales.png)

2. Aquí verás todas las ventas que realizaste.
3. **Revisión:**
   - Puedes ver el detalle de cada factura.
   - Tienes permiso para **Cancelar Ventas** (si hubo un error operativo) o **Restaurar** ventas canceladas.
   - Puedes cambiar el **Estado de Entrega** (ej. de "Pendiente" a "Entregado").

*Nota: solo tienes acceso a las ventas que tú realizaste. Para realizar cambios en ventas de otros vendedores (ej. por reclamos de un cliente) comunícate con tu supervisor.*

![Detalle venta](/Docs/user-guide-images/salesperson-saledetail.png)

---

## 3. Rol: Encargado de Inventario
**Objetivo:** Mantener actualizado el catálogo de productos y proveedores.

### 3.1. Gestión de Productos
1. Ve a la sección **"Productos"**.
2. **Nuevo Producto:**
   - Haz clic en **"Agregar"**.
   - Completa: Nombre, Descripción, Precio, Stock Inicial, Categoría y Proveedor.
   - **Imagen:** Puedes subir una imagen del producto para identificarlo mejor.
3. **Actualizar Stock/Precio:**
   - Selecciona un producto y haz clic en **"Editar"**.
   - Modifica el campo "Stock" (entrada de mercadería) o "Precio" (actualización de costos).
4. **Eliminar/Restaurar:**
   - Puedes desactivar productos que ya no se vendan.
   - Usa la casilla "Mostrar eliminados" para ver productos antiguos y restaurarlos si vuelven a entrar.

![Productos](/Docs/user-guide-images/inventory-products.png)

### 3.2. Gestión de Proveedores
1. Ve a la sección **"Proveedores"**.
2. Aquí debes registrar a las empresas que suministran la mercadería.
3. Datos requeridos: Nombre de la empresa, CUIL, Email y Teléfono.
4. Es vital mantener esto actualizado para poder asignar productos a proveedores al momento de crearlos.

![Proveedores](/Docs/user-guide-images/inventory-suppliers.png)

---

## 4. Rol: Gerente de Ventas
**Objetivo:** Analizar el rendimiento del negocio y auditar las operaciones.

### 4.1. Dashboard (Tablero de Control)
1. Ve a la sección **"Dashboard"**.
2. **Filtros de Tiempo:** Selecciona "Semanal", "Mensual", "Trimestral" o "Anual" para ver la evolución de las ventas. También puedes elegir un periodo específico de tiempo seleccionando las fechas para inicio y fin.
3. **Datos Disponibles:**
   - Curva de ventas en el tiempo.
   - Top productos más vendidos.
   - Top categorías.
   - Ranking de los 3 mejores vendedores.
4. **Exportar:** Puedes generar un PDF con el resumen ejecutivo haciendo clic en "Exportar resumen".

![Dashboard](/Docs/user-guide-images/salesmanager-dashboard1.png)

### 4.2. Reportes Detallados
Desde el Dashboard, accede a:
- **Informe de Vendedores:** Detalle de cuánto facturó cada vendedor y cuántas ventas canceladas tiene.
- **Informe de Productos:** Análisis de stock vs. ventas y mercadería estancada.

![Reportes detallados](/Docs/user-guide-images/salesmanager-dashboard2.png)

### 4.3. Historial de Ventas
1. Ve a la sección **"Historial Ventas"**.
2. Aquí verás todas las operaciones realizadas por el equipo.
3. **Auditoría:**
   - Puedes ver el detalle de cada factura.
   - Tienes permiso para **Cancelar Ventas** (si hubo un error operativo) o **Restaurar** ventas canceladas.
   - Puedes cambiar el **Estado de Entrega** (ej. de "Pendiente" a "Entregado").

### 4.4. Visualización General
Tienes acceso de **solo lectura** a las listas de:
- Productos
- Clientes
- Proveedores
- Usuarios (para ver el staff activo, pero no para editar sus contraseñas).

---

## 5. Rol: Administrador
**Objetivo:** Mantenimiento del sistema, seguridad y gestión del personal.

### 5.1. Gestión de Usuarios
1. Ve a la sección **"Usuarios"**.
2. **Crear Usuario:**
   - Registra nuevos empleados.
   - **Asignación de Roles:** Es crítico asignar el rol correcto (Vendedor, Inventario, Gerente) para limitar sus permisos adecuadamente.
   - *Importante:* No compartas contraseñas. Crea un usuario individual para cada empleado.
3. **Bajas:** Si un empleado deja la empresa, usa el botón "Eliminar" para desactivar su acceso sin borrar su historial de operaciones.

![Gestión usuarios](/Docs/user-guide-images/admin-users.png)

### 5.2. Configuración del Sistema y Backups
1. Ve a la sección **"Sistema"**.
2. **Realizar Backup:**
   - Haz clic en "Realizar Backup" regularmente (se recomienda al cierre de caja diario o semanal).
   - Guarda el archivo `.sql` en una ubicación segura (disco externo o nube).
3. **Restaurar Base de Datos:**
   - **¡PELIGRO!** Esta función borra todos los datos actuales y los reemplaza por los del archivo de respaldo. Úsala solo en casos de emergencia técnica.

![Configuración sistema](/Docs/user-guide-images/admin-system.png)

---

## 6. Solución de Problemas Comunes

| Problema | Causa Probable | Solución |
| :--- | :--- | :--- |
| **Botón "Vender" no funciona** | Tu usuario no tiene el rol de Vendedor. | Si crees que se trata de un error, comunícate con el administrador. |
| **No puedo editar el stock** | Eres Vendedor o Gerente. | Solo el rol "Inventario" puede modificar el stock maestro. |
| **Error al hacer Backup** | Falta configuración de `mysqldump`. | Contacta a soporte técnico para verificar la instalación de MySQL en el servidor. |
| **El producto no aparece al vender** | El producto está marcado como "Inactivo" o sin stock. | Verifica con Inventario si el producto fue eliminado o si el stock es 0. |

---
*VentasApp v1.0 - Manual de Usuario*