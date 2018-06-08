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
PRINT '----- Tabla Funcionalidades creada -----'
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
CREATE TABLE [RIP].[Roles_Funcionalidades] (
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
	[Domicilio_NumeroCalle] [numeric](18,0),
	[Domicilio_Piso] [numeric](18,0),
	[Domicilio_Departamento] [nvarchar](50),
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
	CONSTRAINT FK_PERSONA_TIPO_DOCUMENTO FOREIGN KEY ([Persona_TipoDocumentoID]) REFERENCES [RIP].[TiposDocumentos] ([TipoDocumento_ID]),
	CONSTRAINT FK_PERSONA_DOMICILIO FOREIGN KEY ([Persona_DomicilioID]) REFERENCES [RIP].[Domicilios] ([Domicilio_ID])
	
)
PRINT '----- Tabla Personas creada -----'
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
	[Usuario_CantidadIntentos] [int] DEFAULT 0,
	[Usuario_PersonaID] [numeric](18,0),
	[Usuario_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_USUARIO_PERSONA FOREIGN KEY ([Usuario_PersonaID]) REFERENCES [RIP].[Personas] ([Persona_ID])
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
CREATE TABLE [RIP].[Usuarios_Roles] (
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
    AND TABLE_NAME = 'Clientes' 
	AND TABLE_SCHEMA = 'RIP'
) 
BEGIN
CREATE TABLE [RIP].[Clientes] (
	[Cliente_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cliente_PersonaID] [numeric](18,0),
	[Cliente_Estado] [bit] DEFAULT 1,
	--[Cliente_DatoCorrupto] [bit] DEFAULT 0,
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
	CONSTRAINT FK_HOTELES_DOMICILIO FOREIGN KEY ([Hotel_DomicilioID]) REFERENCES [RIP].[Domicilios] ([Domicilio_ID])
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
	[Regimen_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
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
CREATE TABLE [RIP].[Hoteles_Regimenes] (
	[HotelRegimen_HotelID] [numeric](18,0) NOT NULL,
	[HotelRegimen_RegimenID] [numeric](18,0) NOT NULL,
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
	[TipoHabitacion_ID] [numeric](18,0) NOT NULL PRIMARY KEY,
	[TipoHabitacion_Descripcion] [nvarchar](255),
	[TipoHabitacion_Porcentual] [numeric](18,2)
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
	[Habitacion_Frente] [nvarchar](50),
	[Habitacion_TipoHabitacionID] [numeric](18,0),
	[Habitacion_Descripcion] [nvarchar](255),
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
	[EstadoReserva_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
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
	[Reserva_FechaFin] [datetime],
	[Reserva_TipoHabitacionID] [numeric](18,0),
	[Reserva_RegimenID] [numeric](18,0),	
	[Reserva_EstadoReservaID] [numeric](18,0),
	[Reserva_UsuarioID] [numeric](18,0),
	CONSTRAINT FK_RESERVAS_CLIENTE FOREIGN KEY ([Reserva_ClienteID]) REFERENCES [RIP].[Clientes] ([Cliente_ID]),
	CONSTRAINT FK_RESERVAS_HOTEL FOREIGN KEY ([Reserva_HotelID]) REFERENCES [RIP].[Hoteles] ([Hotel_ID]),
	CONSTRAINT FK_RESERVAS_TIPO_HABITACION FOREIGN KEY ([Reserva_TipoHabitacionID])  REFERENCES [RIP].[TiposHabitaciones] ([TipoHabitacion_ID]),
	CONSTRAINT FK_RESERVAS_REGIMEN FOREIGN KEY ([Reserva_RegimenID])  REFERENCES [RIP].[Regimenes] ([Regimen_ID]),
	CONSTRAINT FK_RESERVAS_ESTADO FOREIGN KEY ([Reserva_EstadoReservaID])  REFERENCES [RIP].[EstadosReservas] ([EstadoReserva_ID]),
	CONSTRAINT FK_RESERVAS_USUARIO FOREIGN KEY ([Reserva_UsuarioID])  REFERENCES [RIP].[Usuarios] ([Usuario_ID])
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
	[ReservaCancelada_RerservaID] [numeric](18,0) NOT NULL PRIMARY KEY,
	[ReservaCancelada_Fecha] [datetime],
	[ReservaCancelada_UsuarioID] [numeric](18,0) NOT NULL,
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
	[Estadia_FechaFin] [datetime],
	[Estadia_CheckInUsuarioID] [numeric](18,0),
	[Estadia_CheckOutUsuarioID] [numeric](18,0),
	CONSTRAINT FK_ESTADIA_RESERVA FOREIGN KEY ([Estadia_ReservaID]) REFERENCES [RIP].[Reservas] ([Reserva_ID]),
	CONSTRAINT FK_ESTADIA_CHECK_IN_USUARIO FOREIGN KEY ([Estadia_CheckInUsuarioID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID]),
	CONSTRAINT FK_ESTADIA_CHECK_OUT_USUARIO FOREIGN KEY ([Estadia_CheckOutUsuarioID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID])
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
    AND TABLE_NAME = 'Estadias_Habitaciones' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Estadias_Habitaciones] (
	[EstadiaHabitacion_EstadiaID] [numeric](18,0) NOT NULL,
	[EstadiaHabitacion_HabitacionID] [numeric](18,0) NOT NULL,	
	CONSTRAINT PK_ESTADIA_HABITACION PRIMARY KEY ([EstadiaHabitacion_EstadiaID],[EstadiaHabitacion_HabitacionID]),
	CONSTRAINT FK_ESTADIA_HABITACION_ESTADIA_ID FOREIGN KEY ([EstadiaHabitacion_EstadiaID]) REFERENCES [RIP].[Estadias] ([Estadia_ID]),
	CONSTRAINT FK_ESTADIA_HABITACION_HABITACION_ID FOREIGN KEY ([EstadiaHabitacion_HabitacionID]) REFERENCES [RIP].[Habitaciones] ([Habitacion_ID])
)
PRINT '----- Tabla Estadias_Habitaciones creada -----'
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
	[Consumido_HabitacionID] [numeric](18,0),
	[Consumido_ConsumibleID] [numeric](18,0),
	[Consumido_Cantidad] [numeric](18,0),
	CONSTRAINT FK_CONSUMIDOS_CONSUMIBLE FOREIGN KEY ([Consumido_ConsumibleID]) REFERENCES [RIP].[Consumibles] ([Consumible_ID]),
	CONSTRAINT FK_CONSUMIDOS_ESTADIA FOREIGN KEY ([Consumido_EstadiaID]) REFERENCES [RIP].[Estadias] ([Estadia_ID]),
	CONSTRAINT FK_CONSUMIDOS_HABITACION FOREIGN KEY ([Consumido_HabitacionID]) REFERENCES [RIP].[Habitaciones] ([Habitacion_ID])
)
PRINT '----- Tabla Consumidos creada -----'
END
GO

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'FormasPagos' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[FormasPagos] (
	[FormaPago_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[FormaPago_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_FORMA_PAGO UNIQUE,
)
PRINT '----- Tabla FormasPagos creada -----'
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
	[Factura_ID] [numeric](18,0) NOT NULL PRIMARY KEY,
	[Factura_EstadiaID] [numeric](18,0),
	[Factura_DiasUtilizados] [numeric](18,0),
	[Factura_DiasNoUtilizados] [numeric](18,0),
	[Factura_Fecha] [datetime],
	[Factura_MontoTotal] [numeric] (18,2),
	[Factura_FormaPagoID] [numeric](18,0),
	CONSTRAINT FK_FACTURAS_ESTADIA FOREIGN KEY ([Factura_EstadiaID]) REFERENCES [RIP].[Estadias] ([Estadia_ID]),
	CONSTRAINT FK_FACTURAS_FORMA_PAGO FOREIGN KEY ([Factura_FormaPagoID]) REFERENCES [RIP].[FormasPagos] ([FormaPago_ID])	
)
PRINT '----- Tabla Facturas creada -----'
END
GO

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'ItemsFacturas' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[ItemsFacturas] (
	[ItemFactura_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ItemFactura_FacturaID] [numeric](18,0),
	[ItemFactura_ConsumidoID] [numeric](18,0),
	[ItemFactura_Cantidad] [numeric](18,0),
	[ItemFactura_Monto] [numeric] (18,2),
	CONSTRAINT FK_ITEMS_FACTURAS_FACTURA FOREIGN KEY ([ItemFactura_FacturaID]) REFERENCES [RIP].[Facturas] ([Factura_ID]),
	CONSTRAINT FK_ITEMS_FACTURAS_CONSUMIDO FOREIGN KEY ([ItemFactura_ConsumidoID]) REFERENCES [RIP].[Consumidos] ([Consumido_ID])	
)
PRINT '----- Tabla ItemsFacturas creada -----'
END
GO


-------------------------------------
--		INSERTS DE TABLAS
-------------------------------------

PRINT''
PRINT '----- Realizando inserts a tabla Ciudades -----'
INSERT INTO RIP.Ciudades (Ciudad_Nombre)
SELECT DISTINCT  Hotel_Ciudad 
FROM GD_Esquema.Maestra


PRINT''
PRINT '----- Realizando inserts a tabla Calles -----'
INSERT INTO RIP.Calles (Calle_Nombre)
SELECT DISTINCT Hotel_Calle 
FROM GD_Esquema.Maestra 
UNION
SELECT DISTINCT Cliente_Dom_Calle 
FROM GD_Esquema.Maestra


PRINT''
PRINT '----- Realizando inserts a tabla Nacionalidades -----'
INSERT INTO RIP.Nacionalidades (Nacionalidad_Descripcion)
SELECT DISTINCT Cliente_Nacionalidad 
FROM GD_Esquema.Maestra


PRINT''
PRINT '----- Realizando inserts a tabla TiposDocumentos -----'
INSERT INTO RIP.TiposDocumentos (TipoDocumento_Descripcion)
VALUES ('DNI'), ('Pasaporte')


PRINT''
PRINT '----- Realizando inserts a tabla Regimenes -----'
INSERT INTO RIP.Regimenes (Regimen_Descripcion, Regimen_Precio)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio 
FROM GD_Esquema.Maestra


PRINT''
PRINT '----- Realizando inserts a tabla EstadosReservas -----'
INSERT INTO RIP.EstadosReservas (EstadoReserva_Descripcion) 
VALUES ('Reserva correcta'),('Reserva modificada'),
('Reserva cancelada por Recepción'),('Reserva cancelada por Cliente')
,('Reserva cancelada por No-Show'),('Reserva con ingreso efectivo')


PRINT''
PRINT '----- Realizando inserts a tabla Consumibles -----'
INSERT INTO RIP.Consumibles (Consumible_ID, Consumible_Descripcion, Consumible_Precio)
SELECT DISTINCT  Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
FROM GD_Esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL


PRINT''
PRINT '----- Realizando inserts tabla Domicilios -----'
INSERT INTO RIP.Domicilios (Domicilio_CiudadID, Domicilio_CalleID, Domicilio_NumeroCalle)
SELECT DISTINCT Ciudad_ID, Calle_ID, Hotel_Nro_Calle 
FROM GD_Esquema.Maestra
JOIN RIP.Ciudades ON Hotel_Ciudad = Ciudad_Nombre
JOIN RIP.Calles ON Hotel_Calle = Calle_Nombre
 
INSERT INTO RIP.Domicilios (Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_Departamento, Domicilio_Piso)
SELECT DISTINCT Calle_ID, Cliente_Nro_Calle, Cliente_Depto, Cliente_Piso 
FROM GD_Esquema.Maestra
JOIN RIP.Calles ON Calle_Nombre = Cliente_Dom_Calle


PRINT''
PRINT '----- Realizando inserts tabla Hoteles -----'
INSERT INTO RIP.Hoteles (Hotel_DomicilioID, Hotel_CantidadEstrellas, Hotel_RecargaEstrellas)
SELECT DISTINCT Domicilio_ID, Hotel_CantEstrella, Hotel_Recarga_Estrella 
FROM GD_Esquema.Maestra
JOIN RIP.Domicilios ON Hotel_Nro_Calle = Domicilio_NumeroCalle 
AND Domicilio_CiudadID IS NOT NULL


PRINT''
PRINT '----- Realizando inserts tabla TiposHabitaciones -----'
INSERT INTO RIP.TiposHabitaciones (TipoHabitacion_ID, TipoHabitacion_Descripcion, TipoHabitacion_Porcentual)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual 
FROM GD_Esquema.Maestra


PRINT''
PRINT '----- Realizando inserts tabla Habitaciones -----'
INSERT INTO RIP.Habitaciones (Habitacion_HotelID, Habitacion_Numero, Habitacion_TipoHabitacionID, Habitacion_Piso, Habitacion_Frente)
SELECT DISTINCT Hotel_ID, Habitacion_Numero, TipoHabitacion_ID, Habitacion_Piso, Habitacion_Frente 
FROM GD_Esquema.Maestra
JOIN RIP.Domicilios ON Hotel_Nro_Calle = Domicilio_NumeroCalle 
AND Domicilio_CiudadID IS NOT NULL 
JOIN RIP.Hoteles ON Hotel_DomicilioID = Domicilio_ID
JOIN RIP.TiposHabitaciones ON Habitacion_Tipo_Codigo = TipoHabitacion_ID


PRINT''
PRINT '----- Realizando inserts tabla Personas -----'
INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_FechaNacimiento, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_DomicilioID, Persona_Email, Persona_NacionalidadID)
SELECT DISTINCT  Cliente_Nombre, Cliente_Apellido, Cliente_Fecha_Nac, 2, Cliente_Pasaporte_Nro, Domicilio_ID, Cliente_Mail, 1 
FROM GD_Esquema.Maestra
JOIN RIP.Calles ON Calle_Nombre = Cliente_Dom_Calle 
JOIN RIP.Domicilios ON Calle_ID = Domicilio_CalleID 
AND Cliente_Nro_Calle = Domicilio_NumeroCalle 
AND Domicilio_Departamento = Cliente_Depto 
AND Domicilio_Piso = Cliente_Piso


PRINT''
PRINT '----- Realizando inserts tabla Clientes -----'
INSERT INTO RIP.Clientes (Cliente_PersonaID)
SELECT DISTINCT Persona_ID 
FROM GD_Esquema.Maestra
JOIN RIP.Personas ON Persona_NumeroDocumento = Cliente_Pasaporte_Nro
AND Persona_Email = Cliente_Mail


PRINT''
PRINT '----- Realizando inserts tabla Hoteles_Regimenes -----'
INSERT INTO RIP.Hoteles_Regimenes (HotelRegimen_HotelID, HotelRegimen_RegimenID)
SELECT h.Hotel_ID, r.Regimen_ID 
FROM GD_Esquema.Maestra a
JOIN RIP.Calles c ON c.Calle_Nombre = a.Hotel_Calle
JOIN RIP.Ciudades ci ON ci.Ciudad_Nombre = a.Hotel_Ciudad
JOIN RIP.Domicilios d ON d.Domicilio_NumeroCalle = a.Hotel_Nro_Calle 
AND d.Domicilio_CalleID= c.Calle_ID 
AND d.Domicilio_CiudadID = ci.Ciudad_ID
JOIN RIP.Hoteles h ON h.Hotel_DomicilioID = d.Domicilio_ID
JOIN RIP.Regimenes r ON r.Regimen_Descripcion = a.Regimen_Descripcion
GROUP BY h.Hotel_ID, r.Regimen_ID


PRINT''
PRINT '----- Realizando inserts tabla Reservas -----'
INSERT INTO RIP.Reservas (Reserva_ID, Reserva_ClienteID, Reserva_HotelID, Reserva_FechaInicio, Reserva_FechaFin, Reserva_TipoHabitacionID, Reserva_RegimenID)
SELECT DISTINCT Reserva_Codigo, Cliente_ID, Hotel_ID, Reserva_Fecha_Inicio, DATEADD(DAY,Reserva_Cant_Noches,Reserva_Fecha_Inicio), Habitacion_Tipo_Codigo, Regimen_ID 
FROM GD_Esquema.Maestra g
JOIN RIP.Personas ON Cliente_Pasaporte_Nro = Persona_NumeroDocumento 
AND Cliente_Mail = Persona_Email
JOIN RIP.Clientes ON Persona_ID = Cliente_PersonaID
JOIN RIP.Ciudades ON Hotel_Ciudad = Ciudad_Nombre
JOIN RIP.Calles ON Hotel_Calle = Calle_Nombre
JOIN RIP.Domicilios ON Hotel_Nro_Calle = Domicilio_NumeroCalle
JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID
JOIN RIP.Regimenes r ON g.Regimen_Descripcion = r.Regimen_Descripcion


PRINT''
PRINT '----- Realizando inserts tabla Estadias -----'
INSERT INTO RIP.Estadias (Estadia_ReservaID, Estadia_FechaInicio, Estadia_FechaFin)
SELECT DISTINCT  Reserva_Codigo, Estadia_Fecha_Inicio, DATEADD(DAY,Reserva_Cant_Noches,Reserva_Fecha_Inicio) 
FROM GD_Esquema.Maestra
WHERE Estadia_Fecha_Inicio IS NOT NULL


PRINT''
PRINT '----- Realizando inserts tabla Estadias_Habitaciones -----'
INSERT INTO RIP.Estadias_Habitaciones (EstadiaHabitacion_EstadiaID, EstadiaHabitacion_HabitacionID)
SELECT DISTINCT Estadia_ID, Habitacion_ID 
FROM GD_Esquema.Maestra g
JOIN RIP.Estadias ON Estadia_ReservaID = Reserva_Codigo  
JOIN RIP.Ciudades ON Hotel_Ciudad = Ciudad_Nombre
JOIN RIP.Calles ON Hotel_Calle = Calle_Nombre
JOIN RIP.Domicilios ON Hotel_Nro_Calle = Domicilio_NumeroCalle
JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID 
JOIN RIP.Habitaciones h ON Hotel_ID = Habitacion_HotelID
AND g.Habitacion_Numero = h.Habitacion_Numero
AND g.Habitacion_Piso = h.Habitacion_Piso


PRINT''
PRINT '----- Realizando inserts tabla Huespedes -----'
INSERT INTO RIP.Huespedes (Huesped_ClienteID, Huesped_EstadiaID)
SELECT DISTINCT Cliente_ID, Estadia_ID 
FROM GD_Esquema.Maestra
JOIN RIP.Personas ON Cliente_Pasaporte_Nro = Persona_NumeroDocumento 
JOIN RIP.Clientes ON Persona_ID = Cliente_ID
JOIN RIP.Estadias ON Reserva_Codigo = Estadia_ReservaID


PRINT''
PRINT '----- Realizando inserts tabla Consumidos -----'
INSERT INTO RIP.Consumidos(Consumido_EstadiaID, Consumido_HabitacionID, Consumido_ConsumibleID, Consumido_Cantidad)
SELECT DISTINCT Estadia_ID, Habitacion_ID, Consumible_Codigo, Item_Factura_Cantidad
FROM GD_Esquema.Maestra g
JOIN RIP.Estadias ON Estadia_ReservaID = Reserva_Codigo
JOIN RIP.Ciudades ON Hotel_Ciudad = Ciudad_Nombre
JOIN RIP.Calles ON Hotel_Calle = Calle_Nombre
JOIN RIP.Domicilios ON Hotel_Nro_Calle = Domicilio_NumeroCalle
JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID 
JOIN RIP.Habitaciones h ON Hotel_ID = Habitacion_HotelID
AND g.Habitacion_Numero = h.Habitacion_Numero
AND g.Habitacion_Piso = h.Habitacion_Piso
WHERE Factura_Nro IS NOT NULL


PRINT''
PRINT '----- Realizando inserts tabla Facturas -----'
INSERT INTO RIP.Facturas (Factura_ID, Factura_EstadiaID, Factura_Fecha, Factura_MontoTotal)
SELECT Factura_Nro, Estadia_ID, Factura_Fecha, Factura_Total
FROM GD_Esquema.Maestra
JOIN RIP.Estadias ON Reserva_Codigo = Estadia_ReservaID
WHERE Factura_Nro IS NOT NULL AND Consumible_Codigo IS NULL


PRINT''
PRINT '----- Realizando inserts tabla ItemsFacturas -----'
INSERT INTO RIP.ItemsFacturas (ItemFactura_FacturaID, ItemFactura_ConsumidoID, ItemFactura_Cantidad, ItemFactura_Monto)
SELECT Factura_Nro, Consumido_ID, Item_Factura_Cantidad, Item_Factura_Monto
FROM GD_Esquema.Maestra g
JOIN RIP.Estadias ON Reserva_Codigo = Estadia_ReservaID
JOIN RIP.Consumidos ON
Consumido_EstadiaID = Estadia_ID 
AND Consumible_Codigo = Consumido_ConsumibleID
WHERE Factura_Nro IS NOT NULL
UNION ALL
SELECT Factura_Nro, Consumido_ID, Item_Factura_Cantidad, Item_Factura_Monto
FROM GD_Esquema.Maestra g
JOIN RIP.Estadias ON Reserva_Codigo = Estadia_ReservaID
JOIN RIP.Consumidos ON
Consumido_EstadiaID = Estadia_ID 
AND Consumible_Codigo IS NULL AND Consumido_ConsumibleID IS NULL
WHERE Factura_Nro IS NOT NULL
ORDER BY Factura_Nro

--Ver si hay que poner DISTINCT ya que hay valores repetidos deberia dar 345200

-------------------------------------
--		INSERTS DE PRUEBA
-------------------------------------

-- Insertando roles

INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Administrador')
INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Recepcionista')
INSERT INTO RIP.Roles (Rol_Nombre) VALUES ('Guest')

-- Insertando usuarios 'admin' y 'recep'

INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia) VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia) VALUES ('recep', HASHBYTES('SHA2_256', 'w23e'))

-- Insertando funcionalidades

INSERT INTO RIP.Funcionalidades (Funcionalidad_Nombre)
VALUES ('Usuarios'),('Hoteles'),('Habitaciones'),('Roles'),('Regimenes'),('Reservas'),('Facturas'),('Estadias'),('Clientes'),('Consumibles'),('Estadisticas')

-- Insertando funcionalidades a los distintos roles

INSERT INTO RIP.Roles_Funcionalidades (RolFuncionalidad_RolID, RolFuncionalidad_FuncionalidadID)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(3,6)

-- Asignando roles a usuarios 'admin' y 'recep'

INSERT INTO RIP.Usuarios_Roles(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'admin'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuarios_Roles(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'recep'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Recepcionista'))

-- Asignando hoteles a usuarios 'admin' y 'recep'

INSERT INTO RIP.Hoteles_Usuarios (HotelUsuario_HotelID, HotelUsuario_UsuarioID) SELECT Hotel_ID ,(SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'admin') FROM RIP.Hoteles
INSERT INTO RIP.Hoteles_Usuarios (HotelUsuario_HotelID, HotelUsuario_UsuarioID) SELECT Hotel_ID,(SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'recep') FROM RIP.Hoteles



-- Prueba Gaby

INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia) VALUES ('gaby', HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Paises (Pais_Nombre) VALUES ('Argentina')
INSERT INTO RIP.Domicilios (Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_CiudadID, Domicilio_PaisID) 
VALUES (2, 1816, 2, @@IDENTITY)
INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_FechaNacimiento, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_DomicilioID, Persona_Email, Persona_Telefono, Persona_NacionalidadID) 
VALUES ('Gabriel', 'Maiori', '19960725 13:31:00.000', 1, 39769742, @@IDENTITY, 'gabrielmaiori@gmail.com', '1154249902', 1)
UPDATE RIP.Usuarios SET Usuario_PersonaID = @@IDENTITY WHERE Usuario_Nombre = 'gaby'
INSERT INTO RIP.Usuarios_Roles(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'gaby'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuarios_Roles(UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES ( (SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'gaby'), (SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = 'Recepcionista'))
INSERT INTO RIP.Hoteles_Usuarios(HotelUsuario_HotelID, HotelUsuario_UsuarioID) SELECT Hotel_ID,(SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = 'gaby') FROM RIP.Hoteles