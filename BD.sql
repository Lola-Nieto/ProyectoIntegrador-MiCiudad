CREATE DATABASE [MiCiudad];
GO

USE [MiCiudad];
GO

-- Crear tabla BARRIO
CREATE TABLE [dbo].[BARRIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(100) NULL,
    [CodigoPostal] NVARCHAR(20) NULL,
    [Comuna] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- Crear tabla CUADRA
CREATE TABLE [dbo].[CUADRA](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Campo] NVARCHAR(50) NULL,
    [Nombre] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- Crear tabla EDIFICIO
CREATE TABLE [dbo].[EDIFICIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Calle] NVARCHAR(100) NULL,
    [Altura] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- Crear tabla GRUPO_BARRIO
CREATE TABLE [dbo].[GRUPO_BARRIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idBarrio] INT NULL,
    [Campo] NVARCHAR(50) NULL,
    [Nombre] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idBarrio]) REFERENCES [dbo].[BARRIO]([ID])
);
GO

-- Crear tabla GRUPO_CONTACTOS
CREATE TABLE [dbo].[GRUPO_CONTACTOS](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(50) NULL,
    [FechaDeCreacion] DATE NULL,
    [CantDeMiembros] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- Crear tabla GRUPO_EDIFICIO
CREATE TABLE [dbo].[GRUPO_EDIFICIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idEdificio] INT NULL,
    [Campo] NVARCHAR(50) NULL,
    [Nombre] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idEdificio]) REFERENCES [dbo].[EDIFICIO]([ID])
);
GO

-- Crear tabla GRUPO_CUADRA
CREATE TABLE [dbo].[GRUPO_CUADRA](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idCuadra] INT NULL,
    [Campo] NVARCHAR(50) NULL,
    [Nombre] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idCuadra]) REFERENCES [dbo].[CUADRA]([ID])
);
GO

-- Crear tabla USUARIO
CREATE TABLE [dbo].[USUARIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(50) NULL,
    [Apellido] NVARCHAR(50) NULL,
    [Contraseña] NVARCHAR(50) NULL,
    [UserName] NVARCHAR(50) NULL,
    [Altura] INT NULL,
    [Calle] NVARCHAR(100) NULL,
    [DNI] NVARCHAR(20) NULL,
    [Mail] NVARCHAR(100) NULL,
    [Patente] NVARCHAR(10) NULL,
    [idGrupoServicios] INT NULL,
    [idGrupoEdificio] INT NULL,
    [idGrupoBarrio] INT NULL,
    [idGrupoCuadra] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idGrupoServicios]) REFERENCES [dbo].[GRUPO_CONTACTOS]([ID]),
    FOREIGN KEY ([idGrupoEdificio]) REFERENCES [dbo].[GRUPO_EDIFICIO]([ID]),
    FOREIGN KEY ([idGrupoBarrio]) REFERENCES [dbo].[GRUPO_BARRIO]([ID]),
    FOREIGN KEY ([idGrupoCuadra]) REFERENCES [dbo].[GRUPO_CUADRA]([ID])
);
GO

-- Crear tabla GRUPO_CONTACTOS_X_VECINO
CREATE TABLE [dbo].[GRUPO_CONTACTOS_X_VECINO](
    [idGrupoContactos] INT NOT NULL,
    [idVecino] INT NOT NULL,
    [FechaIngreso] DATE NULL,
    PRIMARY KEY CLUSTERED ([idGrupoContactos] ASC, [idVecino] ASC),
    FOREIGN KEY ([idGrupoContactos]) REFERENCES [dbo].[GRUPO_CONTACTOS]([ID]),
    FOREIGN KEY ([idVecino]) REFERENCES [dbo].[USUARIO]([ID])
);
GO

-- Crear tabla MENSAJE_BARRIO
CREATE TABLE [dbo].[MENSAJE_BARRIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idGrupo] INT NULL,
    [idUsuario] INT NULL,
    [Hora] DATETIME NULL,
    [Contenido] NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idGrupo]) REFERENCES [dbo].[GRUPO_BARRIO]([ID]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[USUARIO]([ID])
);
GO

-- Crear tabla MENSAJE_CUADRA
CREATE TABLE [dbo].[MENSAJE_CUADRA](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idGrupo] INT NULL,
    [idUsuario] INT NULL,
    [Hora] DATETIME NULL,
    [Contenido] NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idGrupo]) REFERENCES [dbo].[GRUPO_CUADRA]([ID]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[USUARIO]([ID])
);
GO

-- Crear tabla MENSAJE_EDIFICIO
CREATE TABLE [dbo].[MENSAJE_EDIFICIO](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [idGrupo] INT NULL,
    [idUsuario] INT NULL,
    [Hora] DATETIME NULL,
    [Contenido] NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([idGrupo]) REFERENCES [dbo].[GRUPO_EDIFICIO]([ID]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[USUARIO]([ID])
);
GO
