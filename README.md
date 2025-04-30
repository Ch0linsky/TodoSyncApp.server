
# TodoSyncApp

## Descripción del Proyecto

**TodoSyncApp** es una aplicación de escritorio para gestionar tareas que permite la sincronización en tiempo real entre varios clientes utilizando **SignalR** para la comunicación en tiempo real y **WPF** (Windows Presentation Foundation) para la interfaz de usuario (UI). El servidor está basado en **.NET Framework** y la base de datos es **MS SQL Server**. El proyecto también incluye un sistema de autenticación simulada para facilitar el inicio de sesión sin la necesidad de una base de datos externa.

### Características Principales:
- **Autenticación Simulada**: Permite a los usuarios iniciar sesión con un nombre de usuario.
- **Interfaz de Usuario**: Una UI limpia y fácil de usar diseñada con **MVVM**.
- **Sincronización en Tiempo Real**: Cambios en las tareas se sincronizan en todos los clientes conectados.
- **Gestión de Tareas**: Agregar, editar, eliminar y marcar tareas como completadas.

## Requisitos

- **Visual Studio** con soporte para proyectos de tipo **WPF**.
- **.NET Framework 4.7.2** o superior.
- **MS SQL Server** (puede ser una instancia local o en la nube).
- **SignalR** para la comunicación en tiempo real.
  
## Estructura del Proyecto

El proyecto está dividido en tres partes principales:

1. **Cliente (WPF)**: Interfaz de usuario y lógica de presentación (carpeta `TodoSyncApp.Client`).
2. **Servidor (ASP.NET Web API)**: Lógica de negocio y API REST (carpeta `TodoSyncApp.Server`).
3. **Base de Datos**: Utiliza **MS SQL Server** y **Entity Framework** para el manejo de datos.

## Prerequisitos

Para ejecutar el proyecto, primero necesitas configurar la base de datos. Asegúrate de que **MS SQL Server** esté instalado y que las credenciales de la base de datos sean correctas.

### Crear la base de datos

1. **Crear la base de datos**:
   
   ```sql
   CREATE DATABASE TodoSyncAppDB;
   ```

2. **Crear la tabla de tareas**:

   ```sql
   CREATE TABLE Tasks (
       Id INT IDENTITY(1,1) PRIMARY KEY,
       Title NVARCHAR(100),
       IsCompleted BIT,
       Priority NVARCHAR(20),
       Tags NVARCHAR(255),
       DueDate DATETIME
   );
   ```

3. **Scripts adicionales**: Puedes ver los scripts de creación y migración en el proyecto `TodoSyncApp.Server/Data`.

## Configuración del Proyecto

1. **Configurar el proyecto del Servidor**:
   - Asegúrate de que la API esté configurada para usar la base de datos y **SignalR**.
   
2. **Configurar el Cliente**:
   - La aplicación WPF debe estar configurada para comunicarse con el servidor a través de **SignalR**.

## Flujo de Trabajo

1. **Inicio de sesión**:
   - Los usuarios deben iniciar sesión con un nombre de usuario.
   - La autenticación es simulada, lo que significa que la sesión del usuario se mantiene durante la ejecución de la aplicación.

2. **Interacción con las tareas**:
   - Los usuarios pueden agregar, editar, marcar como completadas y eliminar tareas.
   - Al editar o eliminar tareas, el cambio se sincroniza en tiempo real con otros clientes mediante **SignalR**.
   
3. **Sincronización en tiempo real**:
   - Los cambios realizados en el servidor son enviados a los clientes conectados para mantener la lista de tareas actualizada sin necesidad de recargar la página.

4. **Estructura del Cliente**:
   - La aplicación cliente tiene una interfaz WPF utilizando el patrón **MVVM** (Model-View-ViewModel).
   - La interfaz está diseñada para ser clara y fácil de usar, permitiendo al usuario gestionar sus tareas eficientemente.

## Manual de Usuario

### ¿Cómo usar la aplicación?

1. **Iniciar sesión**:
   - Al abrir la aplicación, se solicita un nombre de usuario. No es necesario crear una cuenta, simplemente introduce un nombre y haz clic en "Iniciar sesión".
   
2. **Ver la lista de tareas**:
   - La pantalla principal mostrará todas las tareas creadas.
   - Cada tarea tiene un **CheckBox** para marcarla como completada, y un **botón de editar** para cambiar el título, prioridad, o fecha de vencimiento.

3. **Agregar tareas**:
   - Puedes hacer clic en el botón **"Agregar Tarea"** en la parte inferior para crear una nueva tarea.
   - Se abrirá una ventana de edición donde podrás ingresar el título, prioridad, etiquetas y la fecha límite.
   
4. **Editar tareas**:
   - Haz clic en el icono del lápiz (✏️) para editar una tarea.
   - En la ventana de edición, podrás cambiar cualquier campo, incluyendo el título, prioridad, etiquetas y estado de la tarea.
   
5. **Eliminar tareas**:
   - Haz clic en el icono de la papelera (🗑) para eliminar una tarea.
   
6. **Sincronización en tiempo real**:
   - Cualquier cambio realizado en el servidor (como la creación, edición o eliminación de tareas) se reflejará automáticamente en todos los clientes conectados en tiempo real.

## Cómo Contribuir

Para contribuir al proyecto, sigue estos pasos:

1. **Fork del repositorio**:
   - Realiza un fork del repositorio a tu cuenta de GitHub.

2. **Clona tu fork**:
   - Clona tu fork al entorno local:

   ```bash
   git clone https://github.com/tu-usuario/TodoSyncApp.git
   ```

3. **Crear una nueva rama**:
   - Crea una nueva rama para tu contribución:

   ```bash
   git checkout -b feature/nueva-caracteristica
   ```

4. **Desarrolla tus cambios**:
   - Realiza tus cambios y prueba las funcionalidades antes de hacer commit.

5. **Haz commit de tus cambios**:
   - Después de haber hecho tus cambios, realiza un commit:

   ```bash
   git commit -am 'Agrega nueva característica'
   ```

6. **Envía un pull request**:
   - Envía un pull request a la rama principal de nuestro repositorio explicando tus cambios.



