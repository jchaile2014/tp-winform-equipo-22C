Sistema de Gestión de Artículos — WinForms + SQL Server

Aplicación de escritorio en C# / WinForms con arquitectura en 3 capas, desarrollada como Trabajo Práctico grupal en la Tecnicatura Universitaria en Programación (UTN).

🇪🇸 Español · 🇬🇧 English

🇪🇸 Español
📋 Descripción
Sistema de gestión de artículos desarrollado en C# con Windows Forms, conectado a una base de datos SQL Server. Permite administrar el catálogo completo de productos de un comercio, con operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los artículos.
El proyecto está construido siguiendo el patrón de arquitectura en 3 capas, ampliamente usado en aplicaciones empresariales, lo que separa responsabilidades y facilita el mantenimiento del código.
✨ Funcionalidades

📦 Gestión completa de artículos (alta, baja, modificación y consulta)
🔍 Búsqueda y filtrado de productos
🖼️ Visualización de imágenes asociadas a cada artículo
💾 Persistencia de datos en SQL Server
🖥️ Interfaz gráfica intuitiva en WinForms

🛠️ Tecnologías utilizadas
TecnologíaUsoC#Lenguaje de programación principal.NET FrameworkPlataforma de desarrolloWindows FormsInterfaz gráfica de usuarioSQL ServerBase de datos relacionalADO.NETAcceso a datosVisual StudioEntorno de desarrolloGit / GitHubControl de versiones
🏗️ Arquitectura
El proyecto implementa el patrón arquitectura en 3 capas (Three-Tier Architecture), separando responsabilidades en módulos independientes:
TPWinForm_equipo-22C/
│
├── 📁 aplicacion-winform/   → Capa de Presentación (UI)
│                              Formularios y controles WinForms
│
├── 📁 negocio/              → Capa de Negocio (Business Logic)
│                              Lógica de la aplicación, validaciones,
│                              comunicación con la base de datos
│
└── 📁 dominio/              → Capa de Dominio (Entities)
                               Modelos y entidades del sistema
Ventajas de esta arquitectura:

✅ Separación clara de responsabilidades
✅ Código más mantenible y escalable
✅ Facilita las pruebas unitarias
✅ Permite reemplazar capas sin afectar al resto

🚀 Cómo ejecutar el proyecto
Requisitos previos

Visual Studio 2022 (o superior)
.NET Framework 4.7.2 o superior
SQL Server (Express o superior)

Pasos

Clonar el repositorio:

bash   git clone https://github.com/jchaile2014/tp-winform-equipo-22C.git

Abrir el archivo TPWinForm_equipo-22C.slnx en Visual Studio
Restaurar la base de datos en SQL Server (script en /db si está disponible)
Configurar la cadena de conexión en la capa de negocio
Compilar y ejecutar (F5)

👥 Trabajo en equipo
Este proyecto fue desarrollado de forma colaborativa por el Equipo 22C de la cátedra. Mi participación incluyó trabajo activo en todas las capas del proyecto: desarrollo de formularios WinForms, implementación de la lógica de negocio y diseño de las clases del dominio, en coordinación con el resto del equipo a través de Git.
📚 Aprendizajes obtenidos

Aplicación práctica de POO (clases, herencia, encapsulamiento)
Implementación de arquitectura en capas en un proyecto real
Manejo de ADO.NET para conexión con SQL Server
Uso de Git y GitHub para trabajo en equipo
Resolución de conflictos de merge y trabajo con ramas
Buenas prácticas de organización de código


🇬🇧 English
📋 Description
Articles management system built with C# and Windows Forms, connected to a SQL Server database. It allows managing the complete product catalog of a business, with full CRUD operations on articles.
The project follows the three-tier architecture pattern, widely used in enterprise applications, which separates responsibilities and makes the code easier to maintain.
✨ Features

📦 Full article management (create, read, update, delete)
🔍 Product search and filtering
🖼️ Display of images associated with each article
💾 Data persistence in SQL Server
🖥️ Intuitive WinForms graphical interface

🛠️ Tech Stack

C# · .NET Framework · Windows Forms · SQL Server · ADO.NET · Visual Studio · Git / GitHub

🏗️ Architecture
Three-tier architecture with clear separation of concerns:

aplicacion-winform/ → Presentation Layer (WinForms UI)
negocio/ → Business Logic Layer
dominio/ → Domain Layer (Entities)

👥 Teamwork
Collaborative project developed by Team 22C. My contributions included active work across all layers: WinForms development, business logic implementation, and domain class design, coordinated with the team through Git.

📬 Contacto / Contact
Jorge Ariel Chaile
Estudiante avanzado de Tecnicatura en Programación (UTN) — Desarrollador C# .NET Jr

💼 LinkedIn: jorge-ariel-chaile
📧 Email: jchaile2014@gmail.com
📍 Catamarca, Argentina
