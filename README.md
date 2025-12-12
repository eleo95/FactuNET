# 🧾 FactuNET

**FactuNET** es una aplicación de escritorio desarrollada en **C# y .NET 8** que permite la gestión de facturación de manera sencilla y moderna. 



## 🎯 Características principales

- **Gestión de clientes**: CRUD completo con validaciones y confirmaciones.
- **Gestión de productos**: administración de catálogo con precios y stock.
- **Facturación**: creación de facturas con líneas dinámicas (producto, cantidad, precio, total).
- **Interfaz moderna**: uso de controles WinForms (DataGridView, ComboBox, TabControls, etc.).
- **Arquitectura limpia**: separación de capas (UI, servicios, datos).
- **Persistencia**: integración con **Entity Framework Core** y **SQL Server**.
- **DTOs para DataGridView**: proyecciones ligeras para mostrar datos sin exponer entidades completas.
- **Validaciones en UI**: botones habilitados/deshabilitados según reglas (ej. generar factura solo si hay cliente y líneas).



## 🛠️ Tecnologías utilizadas

- **Lenguaje**: C# (.NET 8)
- **Framework UI**: Windows Forms
- **ORM**: Entity Framework Core
- **Base de datos**: SQL Server
- **Patrones**:
  - Repository & Unit of Work
  - Principios S.O.L.I.D
  - Separation of Concerns



## 📂 Estructura del proyecto

```text
FactuNET/
├── Presentation.Winforms/              # Capa de presentación (WinForms)
├── BusinessLogicLayer/                 # Lógica de negocio y servicios
├── DataAccessLayer/                    # Contexto EF Core y repositorios
├── EntityLayer/                        # Entidades y modelos
└── README.md                           # Este archivo
```



## 🚀 Cómo ejecutar el proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/eleo95/FactuNET.git
   ```
2. Configurar la base de datos en appsettings.json:
   ```json
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Database=FactuNET;Trusted_Connection=True;"
      }
   ```

3. Ejecutar el proyecto:
    ```bash
    dotnet run
    ```
  



## 📖 Instrucciones de uso
1. Selecciona un cliente desde el ComboBox.
2. Agrega productos en la table (DataGridView) de líneas de factura.
3. El sistema calculará automáticamente precios y totales.
4. El botón Generar Factura se habilita solo si:
    * Hay un cliente seleccionado.
    * Existe al menos una línea con producto y precio.

5. Se guarda la factura en la base de datos y se actualizan las relaciones.
