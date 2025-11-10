# ??? Guía Completa de Backups y MySQL Workbench - VentasApp

## ?? Tabla de Contenidos

1. [Sistema de Backups Implementado](#sistema-de-backups-implementado)
2. [Uso desde la Aplicación](#uso-desde-la-aplicación)
3. [Guía de MySQL Workbench](#guía-de-mysql-workbench)
4. [Operaciones Comunes en Base de Datos](#operaciones-comunes-en-base-de-datos)
5. [Resolución de Problemas](#resolución-de-problemas)
6. [Mejores Prácticas](#mejores-prácticas)

---

## 1. Sistema de Backups Implementado

### ?? Archivos Creados

```
VentasApp/
??? Services/
?   ??? IBackupService.cs           ? NUEVO - Interfaz del servicio
?   ??? MySqlBackupService.cs     ? NUEVO - Implementación
?
??? Views/Backup/
?   ??? IBackupView.cs              ? NUEVO - Interfaz de vista
?   ??? BackupView.cs       ? NUEVO - Vista de gestión
?   ??? BackupView.Designer.cs      ? NUEVO - Diseñador
?
??? Presenters/
?   ??? BackupPresenter.cs          ? NUEVO - Lógica de presentación
?
??? backups/     ?? AUTO-CREADO - Directorio de backups
```

### ?? Características Implementadas

? **Crear backup completo** de la base de datos  
? **Restaurar** desde archivo de backup  
? **Listar** todos los backups disponibles  
? **Eliminar** backups antiguos  
? **Backup automático programado** (cada X horas)  
? **Limpieza automática** de backups antiguos  
? **Interfaz gráfica** completa  
? **Logging** de todas las operaciones  

---

## 2. Uso desde la Aplicación

### 2.1 Integrar en MainView

**Paso 1**: Agregar botón en `Views/IMainView.cs`

```csharp
public interface IMainView : IBaseForm
{
    event EventHandler BackupButtonEvent; // ? AGREGAR
    // ... otros eventos existentes
}
```

**Paso 2**: Agregar botón en `Views/MainView.Designer.cs`

```csharp
// En el SideLayoutPanel, agregar:
BackupButton = new Button();

// Configurar el botón
BackupButton.BackColor = Color.White;
BackupButton.FlatAppearance.BorderSize = 0;
BackupButton.FlatStyle = FlatStyle.Flat;
BackupButton.Font = new Font("Segoe UI", 11F);
BackupButton.Location = new Point(10, 400); // Después de Usuarios
BackupButton.Margin = new Padding(0, 0, 0, 5);
BackupButton.Name = "BackupButton";
BackupButton.Size = new Size(200, 40);
BackupButton.TabIndex = 7;
BackupButton.Text = "Backups";
BackupButton.TextAlign = ContentAlignment.MiddleLeft;
BackupButton.UseVisualStyleBackColor = false;

SideLayoutPanel.Controls.Add(BackupButton);
```

**Paso 3**: Implementar evento en `Views/MainView.cs`

```csharp
public event EventHandler BackupButtonEvent;

private void SetupEventsHandler()
{
    // ... eventos existentes ...
    BackupButton.Click += delegate { BackupButtonEvent?.Invoke(this, EventArgs.Empty); };
}

protected override void CustomTheme()
{
    // ... código existente ...
    ApplySidebarButtonTheme(BackupButton, "???");
}
```

**Paso 4**: Manejar evento en `Presenters/MainViewPresenter.cs`

```csharp
public MainViewPresenter(IMainView mainView, ILoginView loginView)
{
    // ... código existente ...
    this.view.BackupButtonEvent += LoadBackupView;
}

private void LoadBackupView(object? sender, EventArgs e)
{
    BackupView backupView = new BackupView();
    
    ILogger logger = new FileLogger();
    IBackupService backupService = new MySqlBackupService(logger);
    
    new BackupPresenter(backupView, backupService, logger);
    
    view.LoadMainPanelView(backupView);
}
```

### 2.2 Usar el Sistema de Backups

#### Interfaz de Usuario

```
???????????????????????????????????????????????????????
? ??? Gestión de Backups   ?
???????????????????????????????????????????????????????
?      ?
? ???????????????????????????????????????????????   ?
? ? Archivo         ? Fecha Creación ? Tamaño   ?   ?
? ???????????????????????????????????????????????   ?
? ? backup_20240... ? 2024-12-15...  ? 2.5 MB   ?   ?
? ? backup_20240... ? 2024-12-14...  ? 2.4 MB   ?   ?
? ???????????????????????????????????????????????   ?
?      ?
? [?? Crear Backup] [?? Restaurar] [??? Eliminar]    ?
? [?? Actualizar]  ?
?              ?
? Backup Automático: [24] horas          ?
? [? Programar] [?? Detener] Status: ? Inactivo     ?
?           ?
? [???????????????????????????] Procesando...    ?
???????????????????????????????????????????????????????
```

#### Crear Backup Manual

```csharp
// Desde código:
ILogger logger = new FileLogger();
IBackupService backupService = new MySqlBackupService(logger);

try
{
    string backupPath = backupService.CreateBackup();
    MessageBox.Show($"Backup creado: {backupPath}");
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}");
}
```

#### Restaurar Backup

```csharp
// Desde código:
try
{
string backupFile = @"C:\...\backups\backup_ventasdb_20241215_143022.sql";
    backupService.RestoreBackup(backupFile);
    MessageBox.Show("Backup restaurado exitosamente");
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}");
}
```

#### Programar Backup Automático

```csharp
// Backup cada 24 horas
backupService.ScheduleAutoBackup(intervalHours: 24);

// Backup cada 6 horas
backupService.ScheduleAutoBackup(intervalHours: 6);

// Detener backup automático
backupService.StopAutoBackup();
```

### 2.3 Archivo de Backup Generado

**Ubicación**: `<AppDirectory>/backups/`

**Nombre**: `backup_<database>_<timestamp>.sql`

**Ejemplo**: `backup_ventasdb_20241215_143022.sql`

**Contenido**:
```sql
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: ventasdb
-- ------------------------------------------------------

DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(150) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

LOCK TABLES `category` WRITE;
INSERT INTO `category` VALUES (1,'Electrónica'),(2,'Ropa');
UNLOCK TABLES;

-- ... más tablas y datos
```

---

## 3. Guía de MySQL Workbench

### 3.1 Instalación y Conexión

#### Descargar MySQL Workbench

1. Ir a: https://dev.mysql.com/downloads/workbench/
2. Descargar versión para Windows
3. Instalar siguiendo el wizard

#### Crear Conexión

```
1. Abrir MySQL Workbench
2. Click en [+] junto a "MySQL Connections"
3. Configurar:
   ???????????????????????????????????
   ? Connection Name: VentasApp      ?
   ? Hostname: localhost     ?
   ? Port: 3306   ?
   ? Username: root   ?
   ? Password: [Click Store...]      ?
   ?   ??> Ingresar password         ?
   ? Default Schema: ventasdb        ?
   ???????????????????????????????????
4. [Test Connection]
5. [OK]
```

### 3.2 Backup Manual desde MySQL Workbench

#### Método 1: Data Export

```
1. Click en Server ? Data Export
2. Seleccionar schema: [?] ventasdb
3. Seleccionar todas las tablas o específicas
4. Export Options:
   ? Export to Dump Project Folder
   ? Export to Self-Contained File
   
5. Path: C:\Backups\ventasdb_manual.sql
6. Include Options:
   [?] Include Create Schema
   [?] Include Drop Schema
   
7. [Start Export]
```

#### Método 2: Server Administration

```
1. Click en Management ? Data Export
2. Seleccionar ventasdb
3. Export to Self-Contained File
4. Browse: elegir ubicación
5. [Start Export]
```

### 3.3 Restaurar Backup desde MySQL Workbench

#### Método 1: Data Import

```
1. Click en Server ? Data Import
2. Import from Self-Contained File
3. Browse: seleccionar archivo .sql
4. Default Target Schema: ventasdb
5. [Start Import]
```

#### Método 2: SQL Editor

```
1. File ? Open SQL Script...
2. Seleccionar archivo backup.sql
3. ? Click en Execute (rayo)
4. Esperar a que termine
```

### 3.4 Operaciones Comunes

#### Ver Estructura de Tablas

```sql
-- Ver todas las tablas
SHOW TABLES;

-- Ver estructura de una tabla
DESCRIBE product;
-- o
SHOW CREATE TABLE product;
```

#### Ver Datos

```sql
-- Ver todos los productos
SELECT * FROM product;

-- Ver productos activos
SELECT * FROM product WHERE active_state = 1;

-- Ver productos con categoría
SELECT 
    p.product_id,
    p.product_name,
    p.price,
    c.category_name
FROM product p
JOIN category c ON p.category_id = c.category_id;
```

#### Estadísticas de la Base de Datos

```sql
-- Tamaño de la base de datos
SELECT 
    table_schema AS 'Database',
    ROUND(SUM(data_length + index_length) / 1024 / 1024, 2) AS 'Size (MB)'
FROM information_schema.TABLES
WHERE table_schema = 'ventasdb'
GROUP BY table_schema;

-- Tamaño por tabla
SELECT 
    table_name AS 'Table',
    ROUND(((data_length + index_length) / 1024 / 1024), 2) AS 'Size (MB)'
FROM information_schema.TABLES
WHERE table_schema = 'ventasdb'
ORDER BY (data_length + index_length) DESC;

-- Cantidad de registros por tabla
SELECT 
    table_name AS 'Table',
    table_rows AS 'Rows'
FROM information_schema.TABLES
WHERE table_schema = 'ventasdb'
ORDER BY table_rows DESC;
```

---

## 4. Operaciones Comunes en Base de Datos

### 4.1 Mantenimiento

#### Optimizar Tablas

```sql
-- Optimizar tabla específica
OPTIMIZE TABLE product;

-- Optimizar todas las tablas
OPTIMIZE TABLE category, product, sale, sale_item, customer, supplier, user;
```

#### Verificar Integridad

```sql
-- Verificar tabla
CHECK TABLE product;

-- Reparar tabla (si es necesario)
REPAIR TABLE product;
```

#### Analizar Tablas

```sql
-- Analizar tabla para estadísticas
ANALYZE TABLE product;
```

### 4.2 Índices

#### Ver Índices Existentes

```sql
-- Ver índices de una tabla
SHOW INDEX FROM product;
```

#### Crear Índices (si es necesario)

```sql
-- Índice simple
CREATE INDEX idx_product_name ON product(product_name);

-- Índice compuesto
CREATE INDEX idx_sale_user_date ON sale(user_id, created_at);

-- Índice único
CREATE UNIQUE INDEX idx_user_username ON user(username);
```

#### Eliminar Índice

```sql
DROP INDEX idx_product_name ON product;
```

### 4.3 Limpieza de Datos

#### Eliminar Registros Antiguos

```sql
-- Ver ventas canceladas hace más de 6 meses
SELECT COUNT(*) 
FROM sale 
WHERE canceled_at IS NOT NULL 
  AND canceled_at < DATE_SUB(NOW(), INTERVAL 6 MONTH);

-- Eliminar (con cuidado)
DELETE FROM sale 
WHERE canceled_at IS NOT NULL 
  AND canceled_at < DATE_SUB(NOW(), INTERVAL 6 MONTH);
```

#### Limpiar Logs (si existen)

```sql
-- Si tienes tabla de logs
DELETE FROM audit_log 
WHERE created_at < DATE_SUB(NOW(), INTERVAL 3 MONTH);
```

### 4.4 Consultas Útiles

#### Productos Más Vendidos

```sql
SELECT 
    p.product_id,
    p.product_name,
    SUM(si.amount) as total_vendido,
    SUM(si.amount * si.price) as valor_total
FROM product p
JOIN sale_item si ON p.product_id = si.product_id
JOIN sale s ON si.sale_id = s.sale_id
WHERE s.canceled_at IS NULL
GROUP BY p.product_id, p.product_name
ORDER BY total_vendido DESC
LIMIT 10;
```

#### Ventas por Mes

```sql
SELECT 
    DATE_FORMAT(created_at, '%Y-%m') as mes,
    COUNT(*) as cantidad_ventas,
    SUM(total_price) as total
FROM sale
WHERE canceled_at IS NULL
GROUP BY DATE_FORMAT(created_at, '%Y-%m')
ORDER BY mes DESC;
```

#### Productos con Bajo Stock

```sql
SELECT 
    product_id,
    product_name,
    stock,
    price
FROM product
WHERE active_state = 1 
  AND stock < 10
ORDER BY stock ASC;
```

---

## 5. Resolución de Problemas

### 5.1 mysqldump no encontrado

**Error**: "No se encontró mysqldump.exe"

**Solución 1: Agregar a PATH**

```
1. Buscar instalación de MySQL:
   - C:\Program Files\MySQL\MySQL Server 8.0\bin\
   - C:\xampp\mysql\bin\

2. Agregar a Variables de Entorno:
   - Windows + Pause ? Configuración avanzada del sistema
   - Variables de entorno
   - Path (del sistema)
   - Nuevo ? Agregar ruta de MySQL\bin
   - OK

3. Reiniciar aplicación
```

**Solución 2: Configurar Manualmente**

En `MySqlBackupService.cs`, modificar `FindMySqlDumpPath()`:

```csharp
private string FindMySqlDumpPath()
{
    // Agregar tu ruta específica
    string[] possiblePaths = new[]
    {
        @"C:\TU_RUTA_MYSQL\bin\mysqldump.exe", // ? TU RUTA
        "mysqldump",
        @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
      // ... otros paths
    };
    // ... resto del código
}
```

### 5.2 Error de Permisos

**Error**: "Access denied for user"

**Solución**:

```sql
-- En MySQL Workbench, ejecutar como root:
GRANT ALL PRIVILEGES ON ventasdb.* TO 'root'@'localhost';
FLUSH PRIVILEGES;
```

### 5.3 Archivo de Backup Corrupto

**Síntomas**: Error al restaurar

**Solución**:

1. Verificar tamaño del archivo (> 0 bytes)
2. Abrir con editor de texto, verificar que empiece con:
   ```sql
   -- MySQL dump
   ```
3. Verificar que termine con:
   ```sql
   -- Dump completed
   ```
4. Si está incompleto, usar backup anterior

### 5.4 Backup Muy Grande

**Problema**: Backup tarda mucho o es muy grande

**Solución 1: Comprimir**

```csharp
// Modificar CreateBackup para comprimir
string fileName = GenerateBackupFileName().Replace(".sql", ".sql.gz");
// Usar GZipStream para comprimir
```

**Solución 2: Backup Parcial**

```bash
# Backup solo estructura (sin datos)
mysqldump --no-data ventasdb > estructura.sql

# Backup solo datos de tablas pequeñas
mysqldump ventasdb category product > datos_principales.sql
```

---

## 6. Mejores Prácticas

### 6.1 Estrategia de Backups

#### Política Recomendada

```
DIARIOS (Retener 7 días)
  ??> Backup automático cada 24h
  
SEMANALES (Retener 4 semanas)
  ??> Backup manual cada domingo
  
MENSUALES (Retener 12 meses)
  ??> Backup manual primer día del mes
  
ANTES DE CAMBIOS CRÍTICOS
  ??> Backup manual inmediato
```

#### Implementación en Código

```csharp
public class BackupPolicy
{
    public void ApplyPolicy(IBackupService service)
    {
        // Diario automático
        service.ScheduleAutoBackup(24);
        
        // Limpiar backups > 7 días
     service.CleanOldBackups(7);
  }
    
    public void CreateWeeklyBackup(IBackupService service)
    {
     string weeklyPath = Path.Combine(
 AppDomain.CurrentDomain.BaseDirectory,
  "backups",
         "weekly",
            $"weekly_{DateTime.Now:yyyyMMdd}.sql"
        );
service.CreateBackup(weeklyPath);
    }
}
```

### 6.2 Almacenamiento

#### Local

```
? Rápido y fácil
? Riesgo si falla el disco
?? Usar para backups diarios
```

#### Red/NAS

```csharp
string networkPath = @"\\servidor\backups\ventasapp\";
backupService.CreateBackup(Path.Combine(networkPath, fileName));
```

#### Nube (OneDrive, Google Drive, Dropbox)

```csharp
string cloudPath = @"C:\Users\Usuario\OneDrive\Backups\VentasApp\";
backupService.CreateBackup(Path.Combine(cloudPath, fileName));
```

### 6.3 Verificación de Backups

#### Test de Restauración Mensual

```csharp
public bool TestBackupRestore(string backupPath)
{
    try
    {
    // Crear base de datos de prueba
  string testDb = "ventasdb_test";
        
        // Restaurar en DB de prueba
        // ... código de restauración
        
    // Verificar integridad
        // ... consultas de verificación
  
        return true;
  }
    catch
    {
        return false;
    }
}
```

### 6.4 Monitoreo

#### Log de Backups

```csharp
public class BackupMonitor
{
    private ILogger logger;
 
    public void LogBackupStatus()
    {
        var backups = GetAvailableBackups();
        logger.LogInformation($"Total backups: {backups.Count()}");
        logger.LogInformation($"Último backup: {backups.First().CreatedDate}");
        logger.LogInformation($"Tamaño total: {CalculateTotalSize(backups)} MB");
    }
}
```

---

## 7. Checklist de Implementación

### Para Desarrollador

- [ ] Copiar archivos de servicios y vistas
- [ ] Agregar botón en MainView
- [ ] Conectar eventos en MainViewPresenter
- [ ] Verificar que MySQL esté en PATH
- [ ] Crear primer backup de prueba
- [ ] Probar restauración en BD de prueba
- [ ] Documentar ubicación de backups
- [ ] Configurar backup automático

### Para Usuario Final

- [ ] Explicar ubicación de backups
- [ ] Mostrar cómo crear backup manual
- [ ] Advertir sobre restauración
- [ ] Establecer política de backups
- [ ] Configurar almacenamiento externo
- [ ] Programar backups automáticos
- [ ] Verificar primer backup automático

---

## 8. Ejemplo Completo de Uso

### Escenario: Backup Antes de Actualización

```csharp
// 1. Crear backup pre-actualización
ILogger logger = new FileLogger();
IBackupService backupService = new MySqlBackupService(logger);

try
{
    logger.LogInformation("Iniciando backup pre-actualización...");
    
    // Backup con nombre específico
    string updateBackupPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "backups",
        $"pre_update_v{Application.ProductVersion}_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
    );
    
    string backupPath = backupService.CreateBackup(updateBackupPath);
    logger.LogInformation($"Backup pre-actualización creado: {backupPath}");
    
    // 2. Realizar actualización
    PerformDatabaseUpdate();
    
    // 3. Verificar que todo funcione
    if (VerifyDatabaseIntegrity())
    {
        logger.LogInformation("Actualización exitosa");
    }
    else
    {
        // 4. Restaurar si algo falla
        logger.LogWarning("Restaurando backup...");
        backupService.RestoreBackup(backupPath);
        logger.LogInformation("Base de datos restaurada a estado pre-actualización");
    }
}
catch (Exception ex)
{
    logger.LogError("Error en actualización", ex);
    throw;
}
```

---

## ? Conclusión

El sistema de backups implementado proporciona:

? **Protección completa** de datos  
? **Automatización** de backups periódicos  
? **Interfaz intuitiva** para gestión  
? **Integración** con MySQL Workbench  
? **Logging** de todas las operaciones  
? **Flexibilidad** de configuración  

**¡Tu base de datos está protegida!** ????

---

**Versión**: 1.0  
**Framework**: .NET 8  
**Base de Datos**: MySQL  
**Última actualización**: 2024
