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
    AND TABLE_NAME = 'Clientes' 
	AND TABLE_SCHEMA = 'RIP'
) 
BEGIN
CREATE TABLE [RIP].[Clientes] (
	[Cliente_ID] [numeric](18,0) NOT NULL IDENTITY(1,1),
	[Cliente_IDPersona] [numeric](18,0),
	[Cliente_Habilitado] [bit] DEFAULT 1,
	[Cliente_DatoCorrupto] [bit] DEFAULT 0,
	CONSTRAINT PK_CLIENTE PRIMARY KEY ([Cliente_ID])
)
PRINT '----- Tabla Clientes creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'TiposDocumento' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[TiposDocumento] (
	[TipoDocumento_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TipoDocumento_Descripcion] [nvarchar](15) CONSTRAINT UQ_DESC_TIPODOCUMENTO UNIQUE NOT NULL
)
PRINT '----- Tabla TiposDocumento creada -----'
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
	[Factura_IDEstadia] [numeric](18,0),
	[Factura_IDCliente] [numeric](18,0),
	[Factura_DiasEfectivos] [numeric](18,0),
	[Factura_DiasNoUtilizados] [numeric](18,0),
	[Factura_Fecha] [datetime],
	[Factura_Total] [numeric] (18,2),
	[Factura_FormaDePago] [nvarchar](50),
)
PRINT '----- Tabla Facturas creada -----'
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
	[Usuario_IDPersona] [numeric](18,0),
	[Usuario_Nombre] [nvarchar](50) NOT NULL,
	[Usuario_Contrasenia] [varbinary](100) NOT NULL,
	[Usuario_CantidadIntentos] [int] DEFAULT 0,
	[Usuario_Estado] [bit],
)
PRINT '----- Tabla Usuarios creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Hotel_Usuario' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Hotel_Usuario] (
	[HotelUsuario_IDHotel] [numeric](18,0) NOT NULL,
	[HotelUsuario_IDUsuario] [numeric](18,0) NOT NULL
)
PRINT '----- Tabla Hotel_Usuario creada -----'
END
GO


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
    AND TABLE_NAME = 'Rol_Funcionalidad' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Rol_Funcionalidad] (
	[RolFuncionalidad_IDRol] [numeric](18,0) NOT NULL,
	[RolFuncionalidad_IDFuncionalidad] [numeric](18,0) NOT NULL
)
PRINT '----- Tabla Rol_Funcionalidad creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Usuario_Rol' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Usuario_Rol] (
	[UsuarioRol_IDUsuario] [numeric](18,0) NOT NULL,
	[UsuarioRol_IDRol] [numeric](18,0) NOT NULL
)
PRINT '----- Tabla Usuario_Rol creada -----'
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
	[Habitacion_IDHotel] [numeric](18,0),
	[Habitacion_Numero] [numeric](18,0),
	[Habitacion_Piso] [numeric](18,0),
	[Habitacion_Frente] [nvarchar](5),
	[Habitacion_TipoCodigo] [numeric](18,0),
	[Habitacion_Descripcion] [nvarchar](255) NOT NULL,
	[Habitacion_Habilitada] [bit] DEFAULT 1
)
PRINT '----- Tabla Habitaciones creada -----'
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
	[Hotel_Email] [nvarchar](255),
	[Hotel_Telefono] [numeric](18,0),
	[Hotel_IDDomicilio] [numeric](18,0),
	[Hotel_CantidadEstrellas] [numeric](18,0),
	[Hotel_RecargaEstrellas] [numeric](18,0),
	[Hotel_FechaCreacion] [datetime],
	[Hotel_Habilitado] [bit] DEFAULT 1
)
PRINT '----- Tabla Hoteles creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Hotel_Regimen' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Hotel_Regimen] (
	[HotelRegimen_IDHotel] [numeric](18,0) NOT NULL,
	[HotelRegimen_IDRegimen] [numeric](3,0) NOT NULL
)
PRINT '----- Tabla Hotel_Regimen creada -----'
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
    AND TABLE_NAME = 'Nacionalidad' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Nacionalidad] (
	[Nacionalidad_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nacionalidad_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_NACIONALIDAD UNIQUE NOT NULL
)
PRINT '----- Tabla Nacionalidad creada -----'
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
    AND TABLE_NAME = 'Regimenes' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Regimenes] (
	[Regimen_ID] [numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Regimen_Descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_REGIMEN UNIQUE NOT NULL,
	[Regimen_Precio] [numeric](18,2) NOT NULL,
	[Regimen_Habilitado] [bit] DEFAULT 1
)
PRINT '----- Tabla Regimenes creada -----'
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
	[Reserva_Codigo] [numeric](18,0) NOT NULL PRIMARY KEY,
	[Reserva_FechaCreacion] [datetime],
	[Reserva_FechaInicio] [datetime],
	[Reserva_CantidadNoches] [numeric](18,0),
	[Reserva_CantidadHuespedes] [numeric](18,0),
	[Reserva_IDCliente] [numeric](18,0),
	[Reserva_IDUsuario] [numeric](18,0),
	[Reserva_IDHotel] [numeric](18,0),
	[Reserva_IDRegimen] [numeric](3,0),
	[Reserva_Estado] [numeric](3,0)
)
PRINT '----- Tabla Reservas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Reserva_Estado' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Reserva_Estado] (
	[ReservaEstado_IDEstado] [numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ReservaEstado_DescripcionEstado] [nvarchar](255) CONSTRAINT UQ_DESC_RESERVA_ESTADO UNIQUE NOT NULL
)
PRINT '----- Tabla Reserva_Estado creada -----'
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
	[Estadia_PrecioTotalConsumible] [numeric](18,2),
)
PRINT '----- Tabla Estadias creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'HabitacionesNoDisponibles' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[HabitacionesNoDisponibles] (
	[HabitacionNoDisponible_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[HabitacionNoDisponible_ReservaID] [numeric](18,0) NOT NULL,
	[HabitacionNoDisponible_HabitacionID] [numeric](18,0) NOT NULL,
	[HabitacionNoDisponible_FechaInicio] [datetime] NOT NULL,
	[HabitacionNoDisponible_FechaFin] [datetime] NOT NULL,
	[HabitacionNoDisponible_Finalizado] [bit] DEFAULT 1
)
PRINT '----- Tabla HabitacionesNoDisponibles creada -----'
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
	[Consumible_Codigo] [numeric](18,0) NOT NULL PRIMARY KEY,
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
	[Consumido_ConsumiblePrecio] [numeric](18,2),
	[Consumido_ConsumibleCantidad] [numeric](18,0),
	[Consumido_HabitacionesPrecio] [numeric](18,2),
)
PRINT '----- Tabla Consumidos creada -----'
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
	[Domicilio_Pais] [nvarchar](50),
	[Domicilio_CiudadID] [numeric](18,0),
	[Domicilio_CalleID] [numeric](18,0),
	[Domicilio_NumeroCalle] [numeric](18,0),
	[Domicilio_Departamento] [nvarchar](3),
	[Domicilio_Piso] [numeric](18,0),
)
PRINT '----- Tabla Domicilios creada -----'
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
	[Persona_Apellido][nvarchar](255),
	[Persona_FechaNacimiento][datetime],
	[Persona_TipoDocumento][nvarchar](15), 
	[Persona_NumeroDocumento] [numeric](18,0),
	[Persona_DomicilioID][numeric](18,0),
	[Persona_Email] [nvarchar] (255), 
	[Persona_Telefono][nvarchar](50),
	[Persona_NacionalidadID][numeric](18,0),
	[Persona_DatoCorrupto][bit] DEFAULT 0
)
PRINT '----- Tabla Personas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Cierre_Mantenimiento' 
	AND TABLE_SCHEMA = 'RIP'
)
BEGIN
CREATE TABLE [RIP].[Cierre_Mantenimiento](
	[Cierre_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cierre_Hotel_ID][numeric](18,0)NOT NULL,
	[Cierre_Fecha_Inicio][datetime],
	[Cierre_Fecha_Fin][datetime],
	[Cierre_Motivo][nvarchar](255),
)
PRINT '----- Tabla HabitacionesNoDisponibles creada -----'
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Cancelacion_Reserva' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Cancelacion_Reserva](
	[Cancelacion_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cancelacion_Rerserva_ID][numeric](18,0)NOT NULL,
	[Cancelacion_Usuario_ID][numeric](18,0)NOT NULL,
	[Cancelacion_Fecha_Cancelacion][datetime],
	[Cancelacion_Motivo][nvarchar](255),
)
PRINT '----- Tabla HabitacionesNoDisponibles creada -----'
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Huespedes' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Huespedes](
	[Huespedes_Cliente_ID][numeric](18,0),
	[Huespedes_Estadia_ID][numeric](18,0),
	[Huespedes_Presente][bit] DEFAULT 1
	)
PRINT '----- Tabla HabitacionesNoDisponibles creada -----'
END
GO

---
--- Aniadimos constraints faltantes
---

ALTER TABLE [RIP].[Rol_Funcionalidad]
	ADD CONSTRAINT PK_ROL_FUNCIONALIDAD PRIMARY KEY ([RolFunc_IdRol], [RolFunc_IdFuncionalidad]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_ROL FOREIGN KEY ([RolFunc_IdRol]) REFERENCES [RIP].[Roles] ([Rol_Id]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_FUNCIONALIDAD FOREIGN KEY ([RolFunc_IdFuncionalidad]) REFERENCES [RIP].[Funcionalidades] ([Funcionalidad_Id])
GO

ALTER TABLE [RIP].[Usuario_Rol]
	ADD CONSTRAINT PK_USUARIO_ROL PRIMARY KEY ([Usuario_Rol_Usuario_ID], [Usuario_Rol_Rol_ID]),
	CONSTRAINT FK_USUARIO_ROL_USUARIO FOREIGN KEY ([Usuario_Rol_Usuario_ID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID]),
	CONSTRAINT FK_USUARIO_ROL_ROL FOREIGN KEY ([Usuario_Rol_Rol_ID]) REFERENCES [RIP].[Roles] (Rol_Id)
GO

ALTER TABLE [RIP].[Hotel_Regimen]
	ADD CONSTRAINT PK_HOTEL_REGIMEN PRIMARY KEY ([Hotel_Regimen_IdHotel], [Hotel_Regimen_IdRegimen]),
	CONSTRAINT FK_HOTEL_REGIMEN_HOTEL FOREIGN KEY ([Hotel_Regimen_IdHotel]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_HOTEL_REGIMEN_REGIMEN FOREIGN KEY ([Hotel_Regimen_IdRegimen]) REFERENCES [RIP].[Regimen] ([Regimen_ID])
GO

ALTER TABLE [RIP].[Hotel_Usuario]
	ADD CONSTRAINT PK_HOTEL_USUARIO PRIMARY KEY ([Hotel_Usuario_IdHotel], [Hotel_Usuario_IdUsuario]),
	CONSTRAINT FK_HOTEL_USUARIO_HOTEL FOREIGN KEY ([Hotel_Usuario_IdHotel]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_HOTEL_USUARIO_USUARIO FOREIGN KEY ([Hotel_Usuario_IdUsuario]) REFERENCES [RIP].[Usuarios] ([Usuario_ID])
GO

ALTER TABLE [RIP].[Domicilio]
	ADD CONSTRAINT PK_DOMICILIO PRIMARY KEY ([Domicilio_ID]),
	CONSTRAINT FK_DOMICILIO_CIUDAD FOREIGN KEY ([Domicilio_Ciudad_ID]) REFERENCES [RIP].[Ciudades] ([Ciudades_ID]),
	CONSTRAINT FK_DOMICILIO_CALLE FOREIGN KEY ([Domicilio_Calle_ID]) REFERENCES [RIP].[Calles] ([Calles_ID])
GO

ALTER TABLE [RIP].[Clientes]
	ADD CONSTRAINT FK_CLIENTES_PERSONA FOREIGN KEY ([cliente_Persona_ID]) REFERENCES [RIP].[Persona] ([Persona_ID])
GO

ALTER TABLE [RIP].[Facturas]
	ADD CONSTRAINT FK_FACTURAS_ESTADIA FOREIGN KEY ([Factura_Estadia_ID]) REFERENCES [RIP].[Estadia] ([Estadia_ID]),
	CONSTRAINT FK_FACTURAS_CLIENTE FOREIGN KEY ([Factura_Cliente_ID]) REFERENCES [RIP].[Clientes] ([cliente_ID])
GO

ALTER TABLE [RIP].[Usuarios]
	ADD CONSTRAINT FK_USUARIO_PERSONA FOREIGN KEY ([Usuario_Persona_ID]) REFERENCES [RIP].[Persona] ([Persona_ID])
GO

ALTER TABLE [RIP].[Habitaciones]
	ADD CONSTRAINT FK_HABITACIONES_HOTEL FOREIGN KEY ([Habitaciones_hotel_ID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID])
GO

ALTER TABLE [RIP].[Hoteles]
	ADD CONSTRAINT FK_HOTELES_DOMICILIO FOREIGN KEY ([Hoteles_Domicilio_ID]) REFERENCES [RIP].[Domicilio] ([Domicilio_ID])
GO

ALTER TABLE [RIP].[Reservas]
	ADD CONSTRAINT FK_RESERVAS_CLIENTES FOREIGN KEY ([Reserva_Cliente_ID]) REFERENCES [RIP].[Clientes] ([cliente_ID]),
	CONSTRAINT FK_RESERVAS_HOTEL FOREIGN KEY ([Reserva_Hotel_ID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_RESERVAS_REGIMEN FOREIGN KEY ([Reserva_Regimen_ID])  REFERENCES [RIP].[Regimen] ([Regimen_ID])
GO

ALTER TABLE [RIP].[Persona]
	ADD CONSTRAINT FK_PERSONA_DOMICILIO FOREIGN KEY ([Persona_Domicilio_ID]) REFERENCES [RIP].[Domicilio] ([Domicilio_ID]),
	CONSTRAINT FK_PERSONA_NACIONALIDAD FOREIGN KEY ([Persona_Nacionalidad_ID]) REFERENCES [RIP].[Nacionalidad] ([Nacionalidad_ID])
GO


ALTER TABLE [RIP].[Cierre_Mantenimiento]
	ADD CONSTRAINT FK_CIERRE_MANTENIMIENTO_HOTEL FOREIGN KEY ([Cierre_Hotel_ID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID])
GO

ALTER TABLE [RIP].[Cancelacion_Reserva]
	ADD CONSTRAINT FK_CANCELACION_RESERVA_RESERVA FOREIGN KEY ([Cancelacion_Rerserva_ID]) REFERENCES [RIP].[Reservas] ([Reserva_Codigo]),
	CONSTRAINT FK_CANCELACION_RESERVA_USUARIO FOREIGN KEY ([Cancelacion_Usuario_ID]) REFERENCES [RIP].[Usuarios] ([Usuario_ID])
GO

ALTER TABLE [RIP].[Hab_NoDisponibles]
	ADD CONSTRAINT FK_HAB_NODISPONIBLES_RESERVA FOREIGN KEY ([NoDisponible_Reserva_ID]) REFERENCES [RIP].[Reservas] ([Reserva_Codigo]),
	CONSTRAINT FK_HAB_NODISPONIBLES_HABITACION FOREIGN KEY ([NoDisponible_Habitacion_ID])REFERENCES [RIP].[Habitaciones] ([Habitaciones_ID])
GO

--ALTER TABLE [RIP].[Item_Factura]
--	ADD CONSTRAINT FK_ITEM_FACTURA_CONSUMIBLE FOREIGN KEY ([Item_Consumible_Id]) REFERENCES [RIP].[Consumible] ([Consumible_Codigo]),
--	CONSTRAINT FK_ITEM_FACTURA_FACTURA FOREIGN KEY ([Item_Factura_ID]) REFERENCES [RIP].[Facturas] ([Factura_Numero])
--GO



-----
----- Hacemos los inserts
-----

-- CALLES
INSERT INTO RIP.Calles (calles_descripcion)
select distinct hotel_calle from gd_esquema.Maestra UNION
select distinct cliente_dom_calle from gd_esquema.Maestra


---Nacionalidad
INSERT INTO RIP.Nacionalidad (nacionalidad_descripcion)
select distinct Cliente_Nacionalidad  from gd_esquema.Maestra

--- ciudades
INSERT INTO RIP.Ciudades (ciudades_descripcion)
select distinct Hotel_Ciudad from gd_esquema.Maestra

--Regimen 
INSERT INTO RIP.Regimen (regimen_descripcion,regimen_precio)
select distinct Regimen_Descripcion,Regimen_Precio from gd_esquema.Maestra

-- Reserva_Estado
INSERT INTO RIP.Reserva_Estado (Reserva_Estado_Descripcion) VALUES ('Reserva Correcta'),('Reserva modificada'),('Reserva cancelada por Recepción'),('Reserva cancelada por Cliente'),('Reserva cancelada por No-Show'),('Reserva con ingreso efectivo')

--consumibles 
INSERT INTO RIP.Consumible (consumible_codigo,consumible_descripcion,consumible_precio)
select distinct Consumible_Codigo,Consumible_Descripcion,Consumible_Precio from gd_esquema.Maestra where Consumible_Descripcion IS NOT NULL

--- Domicilio
INSERT INTO rip.Domicilio (domicilio_ciudad_ID,domicilio_calle_ID,domicilio_nro_calle)
select distinct ciudades_ID,calles_ID,Hotel_Nro_Calle from gd_esquema.Maestra join rip.Ciudades on ciudades_descripcion=Hotel_Ciudad join rip.Calles on calles_descripcion=Hotel_Calle
INSERT INTO rip.Domicilio (domicilio_calle_ID,domicilio_nro_calle,domicilio_depto,domicilio_piso)
select distinct calles_ID,Cliente_Nro_Calle,Cliente_Depto,Cliente_Piso from gd_esquema.Maestra join rip.Calles on calles_descripcion=Cliente_Dom_Calle

--Hoteles
INSERT INTO RIP.Hoteles (hoteles_domicilio_ID,hoteles_nro_estrella,hoteles_recarga_estrella)
select distinct domicilio_ID,Hotel_CantEstrella,Hotel_Recarga_Estrella from gd_esquema.Maestra join RIP.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null

--Habitaciones
INSERT INTO RIP.Habitaciones(habitaciones_hotel_ID,habitaciones_numero,habitaciones_piso,habitaciones_frente,habitaciones_tipo_codigo,habitaciones_descripcion)
select distinct hoteles_ID,Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion from gd_esquema.Maestra
join rip.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null join RIP.Hoteles on hoteles_domicilio_ID=domicilio_ID
 --order by 1,2

--TipoDocumento
INSERT INTO Rip.TipoDocumento(TipoDocumento_Descripcion) VALUES ('Pasaporte'),('DNI')


--Personas
INSERT INTO RIP.Persona (persona_nombre,persona_apellido,persona_fecha_nacimiento,persona_Tipo_Documento,Persona_Identificacion_Nro,Persona_Domicilio_ID,Persona_Mail,Persona_Nacionalidad_ID)
select distinct Cliente_Nombre,Cliente_Apellido,Cliente_Fecha_Nac,1,Cliente_Pasaporte_Nro,Domicilio_ID,Cliente_Mail,1 from gd_esquema.Maestra
join rip.Calles on calles_descripcion=Cliente_Dom_Calle 
join rip.Domicilio on calles_ID=domicilio_calle_ID and Cliente_Nro_Calle=domicilio_nro_calle and domicilio_depto=Cliente_Depto and domicilio_piso=Cliente_Piso


--Clientes
INSERT INTO RIP.Clientes (cliente_persona_ID)
select distinct persona_ID from gd_esquema.Maestra
join RIP.Persona on persona_Identificacion_Nro=Cliente_Pasaporte_Nro


--update rip.Clientes set cliente_DatoCorrupto = 1
--where cliente_Documento_Nro=27682640



--Reservas
select distinct * from rip.Persona a join rip.Persona b on a.Persona_Identificacion_Nro=b.Persona_Identificacion_Nro and a.Persona_nombre!=b.Persona_nombre
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


 
 --Estadia
 INSERT INTO RIP.Estadia(Estadia_Reserva_ID,Estadia_Fecha_Inicio,Estadia_Cantidad_Noches,Estadia_Precio_Total_Consumible)
select distinct Reserva_Codigo,Estadia_Fecha_Inicio,Estadia_Cant_Noches,sum(isnull(Consumible_Precio,0)) from gd_esquema.Maestra
 where Estadia_Fecha_Inicio is not null
 group by Estadia_Fecha_Inicio,Estadia_Cant_Noches,Reserva_Codigo

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

--- Regimen de hotel
INSERT INTO RIP.Hotel_Regimen (Hotel_Regimen_IdHotel,Hotel_Regimen_IdRegimen)
select h.Hoteles_ID, r.Regimen_ID from gd_esquema.Maestra a
join rip.Calles c on c.Calles_Descripcion = a.Hotel_Calle
join rip.Ciudades ci on ci.Ciudades_Descripcion = a.Hotel_Ciudad
join rip.Domicilio d on d.Domicilio_Nro_calle = a.Hotel_Nro_Calle and d.Domicilio_Calle_ID=c.Calles_ID and d.Domicilio_Ciudad_ID=ci.Ciudades_ID
join rip.Hoteles h on h.Hoteles_Domicilio_ID = d.Domicilio_ID
join rip.Regimen r on r.Regimen_Descripcion=a.Regimen_Descripcion
 group by  h.Hoteles_ID, r.Regimen_ID
 order by 1

GO


---
--- Hacemos insert iniciales necesarios
--- 

--Insertar roles
INSERT INTO RIP.Roles (Rol_Nombre) values('Administrador')
INSERT INTO RIP.Roles (Rol_Nombre) values('Recepcionista')
INSERT INTO RIP.Roles (Rol_Nombre) values('Guest')

--- Creamos el usuario administrador y recepcionista genericos
INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('admin',HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('recep',HASHBYTES('SHA2_256', 'w23e'))

INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('gaby',HASHBYTES('SHA2_256', 'w23e'))

INSERT INTO RIP.Domicilio (Domicilio_Calle_ID,Domicilio_Nro_calle,Domicilio_Ciudad_ID,Domicilio_Pais)
VALUES (2,1816,2,'Argentina')

INSERT INTO RIP.Persona (Persona_nombre, Persona_apellido, Persona_fecha_nacimiento, persona_tipo_documento, Persona_Identificacion_Nro,persona_domicilio_id, persona_mail, persona_telefono, persona_pais_origen, Persona_Nacionalidad_ID) 
VALUES ('Gabriel', 'Maiori', '19960725 13:31:00.000', 2, 39769742, @@IDENTITY, 'gabrielmaiori@gmail.com', '1154249902', 'Argentina' , 1 )

UPDATE RIP.Usuarios set Usuario_Persona_ID = @@IDENTITY where Usuario_User = 'gaby'

INSERT INTO RIP.Funcionalidades(Funcionalidad_Funcionalidad)
values ('Usuarios'),('Hoteles'),('Habitaciones'),('Roles'),('Regimenes'),('Reservas'),('Facturas'),('Clientes'),('Consumibles'),('Estadias'),('Estadisticas')

INSERT INTO RIP.Rol_Funcionalidad(RolFunc_IdRol,RolFunc_IdFuncionalidad)
values(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(3,6)

-- Asignamos rol al admin y recepcionista
INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'admin'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'recep'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Recepcionista'))

-- Me asigno roles 
INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Administrador'))
INSERT INTO RIP.Usuario_Rol(Usuario_Rol_Usuario_ID, Usuario_Rol_Rol_ID) values ( (select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby'), (select Rol_ID from rip.Roles where Rol_Nombre = 'Recepcionista'))

-- Asignamos hoteles a los usuarios iniciales
INSERT INTO RIP.Hotel_Usuario(Hotel_Usuario_IdHotel,Hotel_Usuario_IdUsuario) select h.hoteles_id,(select Usuario_ID from rip.Usuarios where Usuario_User = 'admin') from rip.Hoteles h
INSERT INTO RIP.Hotel_Usuario(Hotel_Usuario_IdHotel,Hotel_Usuario_IdUsuario) select h.hoteles_id,(select Usuario_ID from rip.Usuarios where Usuario_User = 'recep') from rip.Hoteles h
INSERT INTO RIP.Hotel_Usuario(Hotel_Usuario_IdHotel,Hotel_Usuario_IdUsuario) select h.hoteles_id,(select Usuario_ID from rip.Usuarios where Usuario_User = 'gaby') from rip.Hoteles h