# 📝 TodoSyncApp

Aplicación de lista de tareas de escritorio con sincronización en tiempo real entre múltiples clientes, usando WPF + .NET + SignalR + SQL Server.

---

## 📌 Objetivo

Crear una aplicación cliente-servidor escalable y en tiempo real, capaz de:

- Sincronizar tareas instantáneamente entre usuarios conectados.
- Gestionar tareas: crear, editar, eliminar, marcar como completadas/incompletas.
- Prevenir ediciones simultáneas (bloqueo de tareas).
- Tener una arquitectura limpia, documentada y mantenible.

---

## ⚙️ Tecnologías Usadas

| Capa         | Tecnología                        |
|--------------|------------------------------------|
| Cliente      | WPF (.NET Framework) + MVVM        |
| Servidor     | ASP.NET Core Web API + SignalR     |
| Comunicación | SignalR + REST API (HTTP)          |
| Base de Datos| SQL Server + Entity Framework Core |
| ORM          | EF Core                            |

---

## 🏗️ Estructura del Proyecto

TodoSyncApp/ ├── Client/ # Aplicación WPF │ ├── Models/ # Modelo TodoTask │ ├── ViewModels/ # Lógica MVVM │ ├── Services/ # Conexión API y SignalR │ └── Views/ # Interfaz XAML │ ├── Server/ # Web API + SignalR │ ├── Controllers/ # API REST │ ├── Data/ # DbContext │ ├── Hubs/ # TaskHub (SignalR) │ ├── Models/ # Modelo EF compartido │ └── Program.cs / Startup.cs # Configuración │ └── README.md # Este archivo


---

## 🚀 Instrucciones de instalación y ejecución

### 🔧 Requisitos Previos

- Visual Studio 2022 o superior
- .NET 6 SDK (o el framework que uses)
- SQL Server (LocalDB o completo)
- Git

---

### 🛠 Paso 1: Clona el repositorio

```bash
git clone https://github.com/tuusuario/TodoSyncApp.git
cd TodoSyncApp

Paso 2: Configura la base de datos
Crea una base de datos en SQL Server llamada TodoSyncDb

Ejecuta el siguiente script SQL:

sql
Copiar
Editar
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0,
    IsLocked BIT NOT NULL DEFAULT 0
);
En el archivo appsettings.json del servidor, coloca tu cadena de conexión:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoSyncDb;Trusted_Connection=True;"
}

Paso 3: Ejecuta el servidor
Abre la solución en Visual Studio

Establece el proyecto TodoSyncApp.Server como proyecto de inicio

Ejecuta el proyecto (F5)

Verifica en el navegador que la API responde:
https://localhost:5001/api/task

Paso 4: Ejecuta el cliente WPF
Establece el proyecto TodoSyncApp.Client como proyecto de inicio

Ejecuta (F5)

Prueba agregar tareas, abrir otra instancia del cliente, y verás la sincronización en tiempo real.

Desarrollado por Erick Earvin Alvarez Jimenez