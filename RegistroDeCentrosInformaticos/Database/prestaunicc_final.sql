-- Eliminar la base de datos si existe
IF DB_ID('prestaunicc') IS NOT NULL
BEGIN
    ALTER DATABASE prestaunicc SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE prestaunicc;
END
GO

-- Crear la base de datos
CREATE DATABASE prestaunicc;
GO

-- Utilizar la base de datos recién creada
USE prestaunicc;
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.tipo_usuario', 'U') IS NOT NULL
    DROP TABLE dbo.tipo_usuario;
GO

-- Crear la tabla
CREATE TABLE dbo.tipo_usuario (
    tipo_usua INT NOT NULL PRIMARY KEY,
    nom_usuari VARCHAR(15) NOT NULL
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.usuarios', 'U') IS NOT NULL
    DROP TABLE dbo.usuarios;
GO

-- Crear la tabla
CREATE TABLE dbo.usuarios (
    carnet VARCHAR(17) NOT NULL PRIMARY KEY,
    apellidos VARCHAR(50) NOT NULL,
    nombres VARCHAR(75) NOT NULL,
    tipo_usua INT NOT NULL,
    correo VARCHAR(100) NOT NULL,
    passve VARCHAR(32) NOT NULL,
    -- Clave foránea para tipo_usua
    FOREIGN KEY (tipo_usua) REFERENCES dbo.tipo_usuario(tipo_usua)
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.decanatos', 'U') IS NOT NULL
    DROP TABLE dbo.decanatos;
GO

-- Crear la tabla
CREATE TABLE dbo.decanatos (
    cod_deca INT NOT NULL PRIMARY KEY,
    nom_deca VARCHAR(75) NOT NULL
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.carreras', 'U') IS NOT NULL
    DROP TABLE dbo.carreras;
GO

-- Crear la tabla
CREATE TABLE dbo.carreras (
    cod_carr INT NOT NULL,
    nom_carr VARCHAR(150) NOT NULL,
    cod_deca INT NOT NULL,
    PRIMARY KEY (cod_carr, cod_deca),
    -- Clave foránea para cod_deca
    FOREIGN KEY (cod_deca) REFERENCES dbo.decanatos(cod_deca)
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.alu_datos', 'U') IS NOT NULL
    DROP TABLE dbo.alu_datos;
GO

-- Crear la tabla
CREATE TABLE dbo.alu_datos (
    carnet VARCHAR(17) NOT NULL,
    cod_carr INT NOT NULL,
    cod_deca INT NOT NULL,
    PRIMARY KEY (carnet),
    FOREIGN KEY (carnet) REFERENCES dbo.usuarios(carnet),
    FOREIGN KEY (cod_carr, cod_deca) REFERENCES dbo.carreras(cod_carr, cod_deca)
);
GO

-- Crear índice para la columna cod_carr
CREATE INDEX idx_cod_carr ON dbo.alu_datos (cod_carr);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.computo', 'U') IS NOT NULL
    DROP TABLE dbo.computo;
GO

-- Crear la tabla
CREATE TABLE dbo.computo (
    idcomputo INT NOT NULL,
    descripcion VARCHAR(35) NOT NULL,
    PRIMARY KEY (idcomputo)
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.estadoscc', 'U') IS NOT NULL
    DROP TABLE dbo.estadoscc;
GO

-- Crear la tabla de estados
CREATE TABLE dbo.estadoscc (
    idestado INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
    PRIMARY KEY (idestado)
);
GO

-- Eliminar la tabla si existe
IF OBJECT_ID('dbo.prestamos', 'U') IS NOT NULL
    DROP TABLE dbo.prestamos;
GO

-- Crear la tabla de prestamos
CREATE TABLE dbo.prestamos (
    idprestamo INT NOT NULL PRIMARY KEY,
    carnet VARCHAR(17) NOT NULL,
    idcomputo INT NOT NULL,
    idestado INT NOT NULL,
    hora_entrada DATE NOT NULL,
    hora_salida DATE NOT NULL,
    comentario VARCHAR(100) NOT NULL,
    -- Claves foráneas para carnet, idcomputo e idestado
    FOREIGN KEY (carnet) REFERENCES dbo.usuarios(carnet),
    FOREIGN KEY (idcomputo) REFERENCES dbo.computo(idcomputo),
    FOREIGN KEY (idestado) REFERENCES dbo.estadoscc(idestado)
);
GO


