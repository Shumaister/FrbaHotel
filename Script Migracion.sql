USE [GD1C2018]
 
SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'RIP')
BEGIN
	DECLARE @Sql NVARCHAR(MAX) = '';

-------------------------------------
--		ELIMINACION DE CONSTRAINTS
-------------------------------------

	SELECT @Sql = @Sql + 'ALTER TABLE ' + QUOTENAME('RIP') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(f.name)  + ';' + CHAR(13)
	FROM SYS.TABLES t 
	INNER JOIN SYS.FOREIGN_KEYS f ON f.parent_object_id = t.object_id 
	INNER JOIN SYS.SCHEMAS s ON t.SCHEMA_ID = s.SCHEMA_ID
	WHERE s.name = 'RIP'
	ORDER BY t.name;
	PRINT @Sql
	EXEC  (@Sql)

-------------------------------------
--		ELIMINACION DE TABLAS
-------------------------------------

	DECLARE @SqlStatement NVARCHAR(MAX)
	SELECT @SqlStatement = COALESCE(@SqlStatement, N'') + N'DROP TABLE [RIP].' + QUOTENAME(TABLE_NAME) + N';' + CHAR(13)
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'RIP' AND TABLE_TYPE = 'BASE TABLE'
	PRINT @SqlStatement
	EXEC  (@SqlStatement)
	DROP SCHEMA [RIP]
END
GO

-------------------------------------
--		CREACION DE ESQUEMA
-------------------------------------

IF NOT EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'RIP')
BEGIN
	EXEC ('CREATE SCHEMA [RIP] AUTHORIZATION [gdHotel2018]')
	PRINT '----- Esquema RIP creado -----'
END
GO

-------------------------------------
--		CREACION DE TABLAS
-------------------------------------

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Roles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Roles] (
	[Rol_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Rol_Nombre] [nvarchar](50) CONSTRAINT UQ_NOMBRE_ROLES UNIQUE NOT NULL,
	[Rol_Estado] [bit] DEFAULT 1
)
PRINT '----- Tabla Roles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Funcionalidades' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Funcionalidades] (
	[Funcionalidad_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Funcionalidad_Nombre] [nvarchar](50) NOT NULL
)
PRINT '----- Tabla Roles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Roles_Funcionalidades' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Rol_Funcionalidad] (
	[RolFuncionalidad_RolID] [numeric](18,0) NOT NULL,
	[RolFuncionalidad_FuncionalidadID] [numeric](18,0) NOT NULL
	CONSTRAINT PK_ROL_FUNCIONALIDAD PRIMARY KEY ([RolFuncionalidad_RolID], [RolFuncionalidad_FuncionalidadID]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_ROL FOREIGN KEY ([RolFuncionalidad_RolID]) REFERENCES [RIP].[Roles] ([Rol_ID]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_FUNCIONALIDAD FOREIGN KEY ([RolFuncionalidad_FuncionalidadID]) REFERENCES [RIP].[Funcionalidades] ([Funcionalidad_ID])
)
PRINT '----- Tabla Roles_Funcionalidades creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Usuarios' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Usuarios] (
	[Usuario_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Usuario_Nombre] [nvarchar](50) NOT NULL,
	[Usuario_Contrasenia] [varbinary](100) NOT NULL,
	[Usuario_PersonaID] [numeric](18,0),
	[Usuario_CantidadIntentos] [int] DEFAULT 0,
	[Usuario_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_USUARIO_PERSONA FOREIGN KEY ([Usuario_PersonaID]) REFERENCES [RIP].[Persona] ([Persona_ID])
)
PRINT '----- Tabla Usuarios creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Usuarios_Roles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Usuario_Rol] (
	[UsuarioRol_UsuarioID] [numeric](18,0) NOT NULL,
	[UsuarioRol_RolID] [numeric](18,0) NOT NULL,
	CONSTRAINT PK_USUARIO_ROL PRIMARY KEY ([UsuarioRol_UsuarioID], [UsuarioRol_RolID]),
	CONSTRAINT FK_USUARIO_ROL_USUARIO FOREIGN KEY ([UsuarioRol_UsuarioID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID]),
	CONSTRAINT FK_USUARIO_ROL_ROL FOREIGN KEY ([UsuarioRol_RolID]) REFERENCES [RIP].[Roles] (Rol_ID)
)
PRINT '----- Tabla Usuarios_Roles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Calles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Calles] (
	[Calle_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Calle_Nombre] [nvarchar](255) CONSTRAINT UQ_DESC_CALLES UNIQUE NOT NULL
)
PRINT '----- Tabla Calles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Ciudades' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Ciudades] (
	[Ciudad_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Ciudad_Nombre] [nvarchar](255) CONSTRAINT UQ_DESC_CIUDADES UNIQUE NOT NULL
)
PRINT '----- Tabla Ciudades creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Paises' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Paises] (
	[Pais_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Pais_Nombre] [nvarchar](255) CONSTRAINT UQ_DESC_PAISES UNIQUE NOT NULL
)
PRINT '----- Tabla Paises creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Domicilios' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Domicilios] (
	[Domicilio_ID] [numeric](18,0) NOT NULL IDENTITY(1,1),
	[Domicilio_PaisID] [numeric](18,0),
	[Domicilio_CiudadID] [numeric](18,0),
	[Domicilio_CalleID] [numeric](18,0),
	[Domicilio_Numero] [numeric](18,0),
	[Domicilio_Piso] [numeric](18,0),
	[Domicilio_Departamento] [nvarchar](3),
	CONSTRAINT PK_DOMICILIO PRIMARY KEY ([Domicilio_ID]),
	CONSTRAINT FK_DOMICILIO_PAIS FOREIGN KEY ([Domicilio_PaisID]) REFERENCES [RIP].[Paises] ([Pais_ID]),
	CONSTRAINT FK_DOMICILIO_CIUDAD FOREIGN KEY ([Domicilio_CiudadID]) REFERENCES [RIP].[Ciudades] ([Ciudad_ID]),
	CONSTRAINT FK_DOMICILIO_CALLE FOREIGN KEY ([Domicilio_CalleID]) REFERENCES [RIP].[Calles] ([Calle_ID])	
)
PRINT '----- Tabla Domicilios creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Nacionalidades' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Nacionalidades] (
	[Nacionalidad_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nacionalidad_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_NACIONALIDAD UNIQUE NOT NULL
)
PRINT '----- Tabla Nacionalidades creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'TiposDocumentos' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[TiposDocumentos] (
	[TipoDocumento_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TipoDocumento_Descripcion] [nvarchar](15) CONSTRAINT UQ_DESC_TIPODOCUMENTO UNIQUE NOT NULL
)
PRINT '----- Tabla TiposDocumentos creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Personas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Personas] (
	[Persona_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Persona_Nombre] [nvarchar](255),
	[Persona_Apellido] [nvarchar](255),
	[Persona_NacionalidadID] [numeric](18,0),
	[Persona_TipoDocumentoID] [numeric](18,0),
	[Persona_NumeroDocumento] [numeric](18,0),
	[Persona_FechaNacimiento] [datetime],
	[Persona_DomicilioID] [numeric](18,0),
	[Persona_Telefono] [nvarchar](50),
	[Persona_Email] [nvarchar](255), 
	--[Persona_DatoCorrupto] [bit] DEFAULT 0
	CONSTRAINT FK_PERSONA_NACIONALIDAD FOREIGN KEY ([Persona_NacionalidadID]) REFERENCES [RIP].[Nacionalidades] ([Nacionalidad_ID]),
	CONSTRAINT FK_PERSONA_TIPO_DOCUMENTO FOREIGN KEY ([Persona_TipoDocumentoID]) REFERENCES [RIP].[Domicilios] ([TipoDocumento_ID]),
	CONSTRAINT FK_PERSONA_DOMICILIO FOREIGN KEY ([Persona_DomicilioID]) REFERENCES [RIP].[Domicilios] ([Domicilio_ID])
	
)
PRINT '----- Tabla Personas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Clientes' 
	AND TABLE_SCHEMA = 'RIP'
) 
BEGIN
CREATE TABLE [RIP].[Clientes] (
	[Cliente_ID] [numeric](18,0) NOT NULL IDENTITY(1,1),
	[Cliente_PersonaID] [numeric](18,0),
	[Cliente_Estado] [bit] DEFAULT 1,
	--[Cliente_DatoCorrupto] [bit] DEFAULT 0,
	CONSTRAINT PK_CLIENTE PRIMARY KEY ([Cliente_ID]),
	CONSTRAINT FK_CLIENTES_PERSONA FOREIGN KEY ([Cliente_PersonaID]) REFERENCES [RIP].[Personas] ([Persona_ID])
)
PRINT '----- Tabla Clientes creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Hoteles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Hoteles] (
	[Hotel_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Hotel_Nombre] [nvarchar](255),
	[Hotel_CantidadEstrellas] [numeric](18,0),
	[Hotel_RecargaEstrellas] [numeric](18,0),
	[Hotel_DomicilioID] [numeric](18,0),	
	[Hotel_Telefono] [numeric](18,0),
	[Hotel_Email] [nvarchar](255),
	[Hotel_FechaCreacion] [datetime],
	[Hotel_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_HOTELES_DOMICILIO FOREIGN KEY ([Hotel_DomicilioID]) REFERENCES [RIP].[Domicilio] ([Domicilio_ID])
)
PRINT '----- Tabla Hoteles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'HotelesCerrados' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[HotelesCerrados] (
	[HotelCerrado_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[HotelCerrado_HotelID] [numeric](18,0) NOT NULL,
	[HotelCerrado_FechaInicio] [datetime],
	[HotelCerrado_FechaFin] [datetime],
	[HotelCerrado_Motivo] [nvarchar](255),
	CONSTRAINT FK_CIERRE_MANTENIMIENTO_HOTEL FOREIGN KEY ([HotelCerrado_ID]) REFERENCES [RIP].[Hoteles] ([Hotel_ID])
)
PRINT '----- Tabla HotelesCerrados creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Regimenes' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Regimenes] (
	[Regimen_ID] [numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Regimen_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_REGIMEN UNIQUE NOT NULL,
	[Regimen_Precio] [numeric](18,2) NOT NULL,
	[Regimen_Estado] [bit] DEFAULT 1
)
PRINT '----- Tabla Regimenes creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Hoteles_Regimenes' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Hotel_Regimen] (
	[HotelRegimen_HotelID] [numeric](18,0) NOT NULL,
	[HotelRegimen_RegimenID] [numeric](3,0) NOT NULL,
	CONSTRAINT PK_HOTEL_REGIMEN PRIMARY KEY ([HotelRegimen_HotelID], [HotelRegimen_RegimenID]),
	CONSTRAINT FK_HOTEL_REGIMEN_HOTEL FOREIGN KEY ([HotelRegimen_HotelID]) REFERENCES [RIP].[Hoteles] ([Hotel_ID]),
	CONSTRAINT FK_HOTEL_REGIMEN_REGIMEN FOREIGN KEY ([HotelRegimen_RegimenID]) REFERENCES [RIP].[Regimenes] ([Regimen_ID])
)
PRINT '----- Tabla Hoteles_Regimenes creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Hoteles_Usuarios' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Hoteles_Usuarios] (
	[HotelUsuario_HotelID] [numeric](18,0) NOT NULL,
	[HotelUsuario_UsuarioID] [numeric](18,0) NOT NULL,
	CONSTRAINT PK_HOTEL_USUARIO PRIMARY KEY ([HotelUsuario_HotelID], [HotelUsuario_UsuarioID]),
	CONSTRAINT FK_HOTEL_USUARIO_HOTEL FOREIGN KEY ([HotelUsuario_HotelID]) REFERENCES [RIP].[Hoteles] ([Hotel_ID]),
	CONSTRAINT FK_HOTEL_USUARIO_USUARIO FOREIGN KEY ([HotelUsuario_UsuarioID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID])
)
PRINT '----- Tabla Hoteles_Usuarios creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'TiposHabitaciones' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[TiposHabitaciones] (
	[TipoHabitacion_Codigo] [numeric](18,0) NOT NULL PRIMARY KEY,
	[TipoHabitacion_Descripcion] [numeric](18,0),
	[TipoHabitacion_Porcentual] [numeric](18,0)
)
PRINT '----- Tabla TiposHabitaciones creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Habitaciones' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Habitaciones] (
	[Habitacion_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Habitacion_HotelID] [numeric](18,0),
	[Habitacion_Numero] [numeric](18,0),
	[Habitacion_Piso] [numeric](18,0),
	[Habitacion_Frente] [nvarchar](5),
	[Habitacion_TipoHabitacionID] [numeric](18,0),
	[Habitacion_Descripcion] [nvarchar](255) NOT NULL,
	[Habitacion_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_HABITACIONES_HOTEL FOREIGN KEY ([Habitacion_HotelID]) REFERENCES [RIP].[Hoteles] ([Hotel_ID]),
	CONSTRAINT FK_HABITACIONES_TIPO FOREIGN KEY ([Habitacion_TipoHabitacionID]) REFERENCES [RIP].[TiposHabitaciones] ([TipoHabitacion_ID])
)
PRINT '----- Tabla Habitaciones creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'EstadosReservas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[EstadosReservas] (
	[EstadoReserva_ID] [numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[EstadoReserva_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_RESERVA_ESTADO UNIQUE NOT NULL
)
PRINT '----- Tabla EstadosReservas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Reservas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Reservas] (
	[Reserva_ID] [numeric](18,0) NOT NULL PRIMARY KEY,
	[Reserva_ClienteID] [numeric](18,0),
	[Reserva_HotelID] [numeric](18,0),
	[Reserva_FechaCreacion] [datetime],
	[Reserva_FechaInicio] [datetime],
	[Reserva_CantidadNoches] [numeric](18,0),
	[Reserva_CantidadHuespedes] [numeric](18,0),	
	[Reserva_UsuarioID] [numeric](18,0),
	[Reserva_RegimenID] [numeric](3,0),
	[Reserva_EstadoReservaID] [numeric](3,0),
	CONSTRAINT FK_RESERVAS_CLIENTES FOREIGN KEY ([Reserva_ClienteID]) REFERENCES [RIP].[Clientes] ([Cliente_ID]),
	CONSTRAINT FK_RESERVAS_HOTEL FOREIGN KEY ([Reserva_HotelID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_RESERVAS_REGIMEN FOREIGN KEY ([Reserva_RegimenID])  REFERENCES [RIP].[Regimenes] ([Regimen_ID]),
	CONSTRAINT FK_RESERVAS_ESTADO FOREIGN KEY ([Reserva_EstadoReservaID])  REFERENCES [RIP].[EstadosReservas] ([EstadoReserva_ID])
)
PRINT '----- Tabla Reservas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'ReservasCanceladas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[ReservasCanceladas] (
	[ReservaCancelada_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ReservaCancelada_RerservaID] [numeric](18,0)NOT NULL,
	[ReservaCancelada_UsuarioID] [numeric](18,0)NOT NULL,
	[ReservaCanceladan_FechaCancelacion] [datetime],
	[ReservaCancelada_Motivo] [nvarchar](255),
	CONSTRAINT FK_RESERVA_CANCELADA_RESERVA FOREIGN KEY ([ReservaCancelada_RerservaID]) REFERENCES [RIP].[Reservas] ([Reserva_ID]),
	CONSTRAINT FK_RESERVA_CANCELADA_USUARIO FOREIGN KEY ([ReservaCancelada_UsuarioID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID])
)
PRINT '----- Tabla ReservasCanceladas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Estadias' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Estadias] (
	[Estadia_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Estadia_ReservaID] [numeric](18,0),
	[Estadia_FechaInicio] [datetime],
	[Estadia_CantidadNoches] [numeric](18,0),
	[Estadia_UsuarioCheckIn] [nvarchar](50),
	[estadia_UsuarioCheckOut] [nvarchar](50),
	[Estadia_PrecioTotalConsumible] [numeric](18,2)
	CONSTRAINT FK_ESTADIA_RESERVA FOREIGN KEY ([Estadia_ReservaID]) REFERENCES [RIP].[Reservas] ([Reserva_ID])
)
PRINT '----- Tabla Estadias creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Huespedes' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Huespedes] (
	[Huesped_ClienteID] [numeric](18,0),
	[Huesped_EstadiaID] [numeric](18,0),
	[Huesped_Presente] [bit] DEFAULT 1
)
PRINT '----- Tabla Huespedes creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Facturas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Facturas] (
	[Factura_Numero] [numeric](18,0) PRIMARY KEY,
	[Factura_ClienteID] [numeric](18,0),
	[Factura_EstadiaID] [numeric](18,0),
	[Factura_DiasEfectivos] [numeric](18,0),
	[Factura_DiasNoUtilizados] [numeric](18,0),
	[Factura_FechaEmision] [datetime], 
	[Factura_FormaDePago] [nvarchar](50),
	[Factura_Total] [numeric] (18,2),
	CONSTRAINT FK_FACTURAS_CLIENTE FOREIGN KEY ([Factura_ClienteID]) REFERENCES [RIP].[Clientes] ([Cliente_ID]),
	CONSTRAINT FK_FACTURAS_ESTADIA FOREIGN KEY ([Factura_EstadiaID]) REFERENCES [RIP].[Estadias] ([Estadia_ID])
)
PRINT '----- Tabla Facturas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Consumibles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Consumibles] (
	[Consumible_ID] [numeric](18,0) NOT NULL PRIMARY KEY,
	[Consumible_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_CONSUMIBLE UNIQUE,
	[Consumible_Precio] [numeric](18,2)
)
PRINT '----- Tabla Consumibles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Consumidos' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Consumidos] (
	[Consumido_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Consumido_EstadiaID] [numeric](18,0),
	[Consumido_ReservaID] [numeric](18,0),
	[Consumido_ConsumibleID] [numeric](18,0),
	[Consumido_ConsumibleCantidad] [numeric](18,0),
	[Consumido_ConsumiblesPrecio] [numeric](18,2),
	[Consumido_HabitacionesPrecio] [numeric](18,2),
)
PRINT '----- Tabla Consumidos creada -----'
END
GO


--ALTER TABLE [RIP].[Item_Factura]
--	ADD CONSTRAINT FK_ITEM_FACTURA_CONSUMIBLE FOREIGN KEY ([Item_Consumible_Id]) REFERENCES [RIP].[Consumible] ([Consumible_Codigo]),
--	CONSTRAINT FK_ITEM_FACTURA_FACTURA FOREIGN KEY ([Item_Factura_ID]) REFERENCES [RIP].[Facturas] ([Factura_Numero])
--GO

-------------------------------------
--		INSERTS DE TABLAS
-------------------------------------

-- Realizando inserts a tabla Calles
INSERT INTO RIP.Calles (Calle_Nombre)
SELECT DISTINCT Hotel_Calle FROM GD_Esquema.Maestra 
UNION
SELECT DISTINCT Cliente_Dom_Calle FROM GD_Esquema.Maestra

-- Realizando inserts a tabla Nacionalidades
INSERT INTO RIP.Nacionalidades (Nacionalidad_Descripcion)
SELECT DISTINCT Cliente_Nacionalidad FROM GD_Esquema.Maestra

-- Realizando inserts a tabla Ciudades
INSERT INTO RIP.Ciudades (ciudades_descripcion)
SELECT DISTINCT  Hotel_Ciudad FROM GD_Esquema.Maestra

-- Realizando inserts a tabla Regimenes
INSERT INTO RIP.Regimenes (Regimen_Descripcion, Regimen_Precio)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio FROM GD_Esquema.Maestra

-- Realizando inserts a tabla Reserva_Estado
INSERT INTO RIP.Reserva_Estado (Reserva_EstadoDescripcion) 
VALUES ('Reserva Correcta'),('Reserva modificada'),('Reserva cancelada por Recepción'),('Reserva cancelada por Cliente'),('Reserva cancelada por No-Show'),('Reserva con ingreso efectivo')

-- Realizando inserts a tabla Consumibles
INSERT INTO RIP.Consumibles (Consumible_Codigo, Consumible_Descripcion, Consumible_Precio)
SELECT DISTINCT  Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
FROM GD_Esquema.Maestra
WHERE Consumible_Descripcion IS NOT NULL

-- Realizando inserts a tabla Domicilios
INSERT INTO RIP.Domicilios (Domicilio_CiudadID, Domicilio_CalleID, Domicilio_NumeroCalle)
SELECT DISTINCT  Ciudad_ID, Calle_ID, Hotel_Nro_Calle 
FROM GD_Esquema.Maestra 
JOIN RIP.Ciudades ON Ciudad_Nombre = Hotel_Ciudad 
JOIN RIP.Calles ON Calle_Nombre = Hotel_Calle

INSERT INTO RIP.Domicilio (Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_Departamento, Domicilio_Piso)
SELECT DISTINCT Calle_ID, Cliente_Nro_Calle, Cliente_Depto, Cliente_Piso 
FROM GD_Esquema.Maestra 
JOIN RIP.Calle ON Calle_Nombre = Cliente_Dom_Calle

-- Realizando inserts a tabla Hoteles
INSERT INTO RIP.Hoteles (Hotel_DomicilioID, Hotel_CantidadEstrellas, Hotel_RecargaEstrellas)
SELECT DISTINCT Domicilio_ID, Hotel_CantEstrella, Hotel_Recarga_Estrella 
FROM GD_Esquema.Maestra
JOIN RIP.Domicilio ON Hotel_Nro_Calle = Domicilio_Nro_Calle AND Domicilio_CiudadID IS NOT NULL

-- Realizando inserts a tabla Habitaciones
INSERT INTO RIP.Habitaciones(habitaciones_hotel_ID,habitaciones_numero,habitaciones_piso,habitaciones_frente,habitaciones_tipo_codigo,habitaciones_descripcion)
SELECT DISTINCT hoteles_ID,Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion from gd_esquema.Maestra
join rip.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null join RIP.Hoteles on hoteles_domicilio_ID=domicilio_ID
 --order by 1,2

-- Realizando inserts a tabla TiposDocumentos
INSERT INTO Rip.TiposDocumentos(TipoDocumento_Descripcion) VALUES ('Pasaporte'),('DNI')

-- Realizando inserts a tabla Personas
INSERT INTO RIP.Persona (persona_nombre,persona_apellido,persona_fecha_nacimiento,persona_Tipo_Documento,Persona_Identificacion_Nro,Persona_Domicilio_ID,Persona_Mail,Persona_Nacionalidad_ID)
SELECT DISTINCT  Cliente_Nombre,Cliente_Apellido,Cliente_Fecha_Nac,1,Cliente_Pasaporte_Nro,Domicilio_ID,Cliente_Mail,1 from gd_esquema.Maestra
join rip.Calles on calles_descripcion=Cliente_Dom_Calle 
join rip.Domicilio on calles_ID=domicilio_calle_ID and Cliente_Nro_Calle=domicilio_nro_calle and domicilio_depto=Cliente_Depto and domicilio_piso=Cliente_Piso

-- Realizando inserts a tabla Clientes
INSERT INTO RIP.Clientes (cliente_persona_ID)
SELECT DISTINCT  persona_ID from gd_esquema.Maestra
join RIP.Persona on persona_Identificacion_Nro=Cliente_Pasaporte_Nro

-- Realizando inserts a tabla Reservas
SELECT DISTINCT * from rip.Persona a join rip.Persona b on a.Persona_Identificacion_Nro=b.Persona_Identificacion_Nro and a.Persona_nombre!=b.Persona_nombre
select * from rip.Persona where Persona_ID=61841
select * from gd_esquema.Maestra where Cliente_Pasaporte_Nro=5833450
--INSERT INTO rip.Reservas(Reserva_Codigo,Reserva_Fecha_Inicio,Reserva_Cantidad_Noches,Reserva_Cliente_ID,Reserva_Hotel_ID,Reserva_Regimen_ID)
select distinct Reserva_Codigo,Reserva_Fecha_Inicio,Reserva_Cant_Noches,cliente_ID,Hoteles_ID,Regimen_ID from gd_esquema.Maestra
join rip.Persona on Cliente_Pasaporte_Nro=Persona_Identificacion_Nro
join rip.Clientes on cliente_Persona_ID=Persona_ID
join rip.Domicilio on Domicilio_Nro_calle=Hotel_Nro_Calle and Domicilio_Ciudad_ID is not null
join rip.Hoteles on Hoteles_Domicilio_ID=Domicilio_ID and Hoteles_Nro_Estrella=Hotel_CantEstrella
join rip.Regimen on regimen.regimen_descripcion=gd_esquema.Maestra.Regimen_Descripcion
where Reserva_Codigo=10225
select * from rip.Reservas

-- Realizando inserts a tabla Estadias
 INSERT INTO RIP.Estadia(Estadia_Reserva_ID,Estadia_Fecha_Inicio,Estadia_Cantidad_Noches,Estadia_Precio_Total_Consumible)
SELECT DISTINCT  Reserva_Codigo,Estadia_Fecha_Inicio,Estadia_Cant_Noches,sum(isnull(Consumible_Precio,0)) from gd_esquema.Maestra
 where Estadia_Fecha_Inicio is not null
 group by Estadia_Fecha_Inicio,Estadia_Cant_Noches,Reserva_Codigo

 -- Realizando inserts a tabla Hotel_Regimen
INSERT INTO RIP.Hotel_Regimen (Hotel_Regimen_IdHotel,Hotel_Regimen_IdRegimen)
select h.Hoteles_ID, r.Regimen_ID from gd_esquema.Maestra a
join rip.Calles c on c.Calles_Descripcion = a.Hotel_Calle
join rip.Ciudades ci on ci.Ciudades_Descripcion = a.Hotel_Ciudad
join rip.Domicilio d on d.Domicilio_Nro_calle = a.Hotel_Nro_Calle and d.Domicilio_Calle_ID=c.Calles_ID and d.Domicilio_Ciudad_ID=ci.Ciudades_ID
join rip.Hoteles h on h.Hoteles_Domicilio_ID = d.Domicilio_ID
join rip.Regimen r on r.Regimen_Descripcion=a.Regimen_Descripcion
 group by  h.Hoteles_ID, r.Regimen_ID
 order by 1

--Facturas
--INSERT INTO RIP.Facturas(Factura_Numero,Factura_Fecha,Factura_Total,Factura_Estadia_ID,Factura_Cliente_ID)
--select distinct b.Factura_Nro,b.Factura_Fecha,b.Factura_Total,a.Estadia_ID,a.Estadia_Cliente_ID from gd_esquema.Maestra b
--join rip.Estadia a on a.Estadia_Cantidad_Noches=b.Estadia_Cant_Noches and a.Estadia_Fecha_Inicio=b.Estadia_Fecha_Inicio
--join rip.Clientes on clientes.cliente_Documento_Nro=b.Cliente_Pasaporte_Nro
--where Factura_Nro is not null and b.Cliente_Pasaporte_Nro=a.Estadia_Cliente_ID
--and clientes.cliente_DatoCorrupto!=1
--order by 1

--- Item_Factura
--INSERT INTO RIP.Item_Factura(Item_Consumible_Id,Item_Factura_ID,Item_Cantidad,Item_Factura_Monto)
--select Consumible_Codigo,Factura_Nro,Item_Factura_Cantidad,Item_Factura_Monto from gd_esquema.Maestra
--where Factura_Nro is not null



-------------------------------------
--		INSERTS DE PRUEBA
-------------------------------------

-- Insertando roles
INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Administrador')
INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Recepcionista')
INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Guest')

-- Insertando usuarios 'admin' y 'recep'
INSERT INTO RIP.Usuarios (Usuario_nombre, Usuario_Contrasenia) VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Usuarios (Usuario_nombre, Usuario_Contrasenia) VALUES ('recep', HASHBYTES('SHA2_256', 'w23e'))

-- Insertando funcionalidades
INSERT INTO RIP.Funcionalidades (Funcionalidad_Nombre)
VALUES ('Usuarios'),('Hoteles'),('Habitaciones'),('Roles'),('Regimenes'),('Reservas'),('Facturas'),('Clientes'),('Consumibles'),('Estadias'),('Estadisticas')

-- Insertando funcionalidades a roles
INSERT INTO RIP.Rol_Funcionalidad (RolFuncionalidad_RolID, RolFuncionalidad_FuncionalidadID)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(3,6)

-- Asignando roles a usuarios 'admin' y 'recep'
INSERT INTO RIP.Usuario_Rol(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'admin'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuario_Rol(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'recep'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Recepcionista'))

-- Asignando hoteles a usuarios 'admin' y 'recep'
INSERT INTO RIP.Hotel_Usuario (Hotel_Usuario_HotelID, Hotel_Usuario_UsuarioID) SELECT Hotel_ID ,(SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'admin') FROM RIP.Hoteles
INSERT INTO RIP.Hotel_Usuario (Hotel_Usuario_HotelID, Hotel_Usuario_UsuarioID) SELECT Hotel_ID,(SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'recep') FROM RIP.Hoteles






-- Prueba Gaby
INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasenia) VALUES ('gaby', HASHBYTES('SHA2_256', 'w23e'))

INSERT INTO RIP.Domicilios (Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_CiudadID, Domicilio_Pais)
VALUES (2, 1816, 2, 'Argentina')

INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_FechaNacimiento, Persona_TipoDocumento, Persona_NumeroDocumento, Persona_DomicilioID, Persona_Email, Persona_Telefono, Persona_NacionalidadID) 
VALUES ('Gabriel', 'Maiori', '19960725 13:31:00.000', 2, 39769742, @@IDENTITY, 'gabrielmaiori@gmail.com', '1154249902', 1)

UPDATE RIP.Usuarios SET Usuario_PersonaID = @@IDENTITY WHERE Usuario_Nombre = 'gaby'

INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Recepcionista'))

INSERT INTO RIP.Hotel_Usuario(Hotel_Usuario_IdHotel,Hotel_Usuario_IdUsuario) select h.hoteles_id,(select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby') from rip.Hoteles h