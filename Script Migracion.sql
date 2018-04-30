USE [GD1C2018]
 
SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 


IF EXISTS (SELECT * FROM sys.schemas WHERE name = 'RIP')
BEGIN
		DECLARE @Sql NVARCHAR(MAX) = '';

		-- Elimino las constraints
		SELECT @Sql = @Sql + 'ALTER TABLE '+ QUOTENAME('RIP') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(f.name)  + ';' + CHAR(13)
		FROM sys.tables t 
			inner join sys.foreign_keys f on f.parent_object_id = t.object_id 
			inner join sys.schemas s on t.schema_id = s.schema_id
		WHERE s.name = 'RIP'
		ORDER BY t.name;

		-- Elimino las tablas
		DECLARE @SqlStatement NVARCHAR(MAX)
		SELECT @SqlStatement = 
			COALESCE(@SqlStatement, N'') + N'DROP TABLE [RIP].' + QUOTENAME(TABLE_NAME) + N';' + CHAR(13)
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = 'RIP' and TABLE_TYPE = 'BASE TABLE'

		PRINT @SqlStatement
		EXEC  (@SqlStatement)

		DROP SCHEMA [RIP]
END
GO


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'RIP')
BEGIN
	EXEC ('CREATE SCHEMA [RIP] AUTHORIZATION [gdHotel2018]')
	PRINT 'Esquema creado RIP ... '
END
GO



-----
----- Creando las tablas
-----

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Clientes' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Clientes](
	[cliente_ID] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[cliente_Persona_ID][numeric](18,0),
	[cliente_Pasarporte_Nro] [numeric](18,0) not null,
	[cliente_Domicilio_ID][numeric](18,0),
	[cliente_Mail] [nvarchar] (255),
	[cliente_Nacionalidad_ID][numeric](18,0),
	[cliente_DatoCorrupto] [bit]
)
 PRINT '... tabla Clientes creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Facturas' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Facturas](
	[Factura_Numero] [numeric](18,0) PRIMARY KEY,
	[Factura_Estadia_ID][numeric](18,2),
	[Factura_Cliente_ID] [numeric](18,0),
	[Factura_Fecha] [datetime],
	[Factura_Total] [numeric] (18,2),
)
 PRINT '... tabla Facturas creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Usuarios' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Usuarios](
	[Usuario_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Usuario_User] [nvarchar](50) NOT NULL,
	[Usuario_Contrasena] [varbinary](100) NOT NULL,
	[Usuario_CantidadDeIntentos] [int] default 0,
	[Usuario_Estado][bit],
	[Usuario_DatoCorrupto][bit]
)
 PRINT '... tabla Usuarios creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Roles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Roles](
	[Rol_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Rol_Nombre] [nvarchar](50) CONSTRAINT UQ_NOMBRE_ROLES UNIQUE NOT NULL,
	[Rol_Estado] [bit] DEFAULT 1
)
 PRINT '... tabla Roles creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Usuario_Rol' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Usuario_Rol](
	[Usuario_Rol_Usuario_ID] [numeric](18,0) not null,
	[Usuario_Rol_Rol_ID] [numeric](18,0) not null
)
 PRINT '... tabla Usuario_Rol creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Habitaciones' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Habitaciones](
	[Habitaciones_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Habitaciones_hotel_ID][numeric](18,0),
	[Habitaciones_Numero][numeric](18,0),
	[Habitaciones_frente][nvarchar](5),
	[Habitaciones_tipo_codigo][numeric](18,0)
)
 PRINT '... tabla Habitaciones creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Habitaciones_Descripcion' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Habitaciones_Descripcion](
	[Habitaciones_Descripcion_ID][numeric](18,0) NOT NULL PRIMARY KEY,
	[Habitaciones_Descripcion_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_HABITACIONES_DESCRIPCION UNIQUE NOT NULL
)
 PRINT '... tabla Habitaciones_Descripcion creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Hoteles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Hoteles](
	[Hoteles_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Hoteles_Domicilio_ID][numeric](18,0),
	[Hoteles_Nro_Estrella][numeric](18,0),
	[Hoteles_Recarga_Estrella][numeric](18,0),
)
 PRINT '... tabla Hoteles creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Calles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Calles](
	[Calles_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Calles_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_CALLES unique NOT NULL
)
 PRINT '... tabla Calles creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Nacionalidad' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Nacionalidad](
	[Nacionalidad_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nacionalidad_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_NACIONALIDAD unique NOT NULL
)
 PRINT '... tabla Nacionalidad creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Ciudades' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Ciudades](
	[Ciudades_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Ciudades_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_CIUDADES unique NOT NULL
)
 PRINT '... tabla Ciudades creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Regimen' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Regimen](
	[Regimen_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Regimen_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_REGIMEN unique NOT NULL,
	[Regimen_Precio][numeric](18,2) NOT NULL
)
 PRINT '... tabla Regimen creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Reserva' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Reserva](
	[Reserva_Codigo][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Reserva_Fecha_Inicio][datetime],
	[Reserva_Cantidad_Noches][numeric](18,0),
	[Reserva_Cliente_ID][numeric](18,0),
	[Reserva_Hotel_ID][numeric](18,0),
	[Reserva_Habitacion_ID][numeric](18,0),
	[Reserva_Regimen_ID][numeric](18,0)
)
 PRINT '... tabla Reserva creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Estadia' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Estadia](
	[Estadia_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Estadia_Fecha_Inicio][datetime],
	[Estadia_Cantidad_Noches][numeric](18,0),
	[Estadia_Cliente_ID][numeric](18,0),
	[Estadia_Hotel_ID][numeric](18,0),
	[Estadia_Habitacion_ID][numeric](18,0),
	[Estadia_Precio_Total_Consumible][numeric](18,2),
	[Estadia_Regimen_ID][numeric](18,0)
)
 PRINT '... tabla Estadia creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Consumible' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Consumible](
	[Consumible_Codigo][numeric](18,0) NOT NULL PRIMARY KEY,
	[Consumible_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_CONSUMIBLE UNIQUE,
	[Consumible_Precio][numeric](18,2)
)
 PRINT '... tabla Consumible creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Consumidos' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Consumidos](
	[Consumidos_Estadia_ID][numeric](18,0) NOT NULL,
	[Consumidos_Consumible_ID][numeric](18,0) NOT NULL,
	[Consumidos_Cantidad][numeric](18,0) NOT NULL
)
 PRINT '... tabla Consumidos creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Item_Factura' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Item_Factura](
	[Item_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Item_Consumible_id] [numeric](18,0),
	[Item_Factura_ID] [numeric](18,0),
	[Item_Cantidad] [numeric](18,0),
	[Item_Factura_Monto] [numeric](18,2)
)
 PRINT '... tabla Item_Factura creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Domicilio' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Domicilio](
	[Domicilio_ID] [numeric](18,0) NOT NULL IDENTITY(1,1),
	[Domicilio_Ciudad_ID] [numeric](18,0),
	[Domicilio_Calle_ID] [numeric](18,0),
	[Domicilio_Nro_calle] [numeric](18,0),
	[Domicilio_Depto] [nvarchar](3),
	[Domicilio_Piso] [numeric](18,0),
)
 PRINT '... tabla Domicilio creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Persona' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Persona](
	[Persona_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Persona_nombre][nvarchar](255),
	[Persona_apellido][nvarchar](255),
	[Persona_fecha_nacimiento][datetime],
	[DatoCorrupto][bit]
)
 PRINT '... tabla Persona creada ... '
END
GO

-----
----- Hacemos los inserts
-----


--- Calles
INSERT INTO RIP.Calles (calles_descripcion)
select distinct hotel_calle from gd_esquema.Maestra
UNION
select distinct cliente_dom_calle from gd_esquema.Maestra


--- ciudades
INSERT INTO RIP.Ciudades (ciudades_descripcion)
select distinct Hotel_Ciudad from gd_esquema.Maestra


--- Nacionalidad
INSERT INTO RIP.Nacionalidad (nacionalidad_descripcion)
select distinct Cliente_Nacionalidad  from gd_esquema.Maestra


--- Regimen 
INSERT INTO RIP.Regimen (regimen_descripcion,regimen_precio)
select distinct Regimen_Descripcion, Regimen_Precio from gd_esquema.Maestra


--- Personas
 INSERT INTO RIP.Persona (persona_nombre,persona_apellido,persona_fecha_nacimiento)
select distinct Cliente_Nombre,Cliente_Apellido,Cliente_Fecha_Nac from gd_esquema.Maestra


--- Consumibles 
INSERT INTO RIP.Consumible (consumible_codigo,consumible_descripcion,consumible_precio)
select distinct Consumible_Codigo,Consumible_Descripcion,Consumible_Precio from gd_esquema.Maestra where Consumible_Descripcion IS NOT NULL


--- Habitaciones Descripcion
INSERT INTO RIP.Habitaciones_Descripcion (habitaciones_descripcion_ID,habitaciones_descripcion_descripcion)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion from gd_esquema.Maestra


--- Domicilio
INSERT INTO rip.domicilio 
            (domicilio_ciudad_id, 
             domicilio_calle_id, 
             domicilio_nro_calle) 
SELECT DISTINCT ciudades_id, 
                calles_id, 
                hotel_nro_calle 
FROM   gd_esquema.maestra 
       JOIN rip.ciudades 
         ON ciudades_descripcion = hotel_ciudad 
       JOIN rip.calles 
         ON calles_descripcion = hotel_calle 

INSERT INTO rip.domicilio 
            (domicilio_calle_id, 
             domicilio_nro_calle, 
             domicilio_depto, 
             domicilio_piso) 
SELECT DISTINCT calles_id, 
                cliente_nro_calle, 
                cliente_depto, 
                cliente_piso 
FROM   gd_esquema.maestra 
       JOIN rip.calles 
         ON calles_descripcion = cliente_dom_calle 


--Hoteles
INSERT INTO rip.hoteles 
            (hoteles_domicilio_id, 
             hoteles_nro_estrella, 
             hoteles_recarga_estrella) 
SELECT DISTINCT domicilio_id, 
                hotel_cantestrella, 
                hotel_recarga_estrella 
FROM   gd_esquema.maestra 
       JOIN rip.domicilio 
         ON hotel_nro_calle = domicilio_nro_calle 
            AND domicilio_ciudad_id IS NOT NULL 


---Habitaciones
INSERT INTO rip.habitaciones 
            (habitaciones_hotel_id, 
             Habitaciones_Numero, 
             habitaciones_frente, 
             habitaciones_tipo_codigo) 
SELECT DISTINCT hoteles_id, 
                habitacion_numero, 
                habitacion_frente, 
                habitacion_tipo_codigo 
FROM   gd_esquema.maestra 
       JOIN rip.domicilio 
         ON hotel_nro_calle = domicilio_nro_calle 
            AND domicilio_ciudad_id IS NOT NULL 
       JOIN rip.hoteles 
         ON hoteles_domicilio_id = domicilio_id 
ORDER  BY 1,2 


--Clientes
INSERT INTO rip.clientes 
            (cliente_persona_id, 
             cliente_pasarporte_nro, 
             cliente_domicilio_id, 
             cliente_mail, 
             cliente_nacionalidad_id) 
SELECT DISTINCT persona_id, 
                cliente_pasaporte_nro, 
                domicilio_id, 
                cliente_mail, 
                1 
FROM   gd_esquema.maestra 
       JOIN rip.persona 
         ON persona_nombre = cliente_nombre 
            AND persona_apellido = cliente_apellido 
            AND persona_fecha_nacimiento = cliente_fecha_nac 
       JOIN rip.calles 
         ON calles_descripcion = cliente_dom_calle 
       JOIN rip.domicilio 
         ON calles_id = domicilio_calle_id 
            AND cliente_nro_calle = domicilio_nro_calle 
ORDER  BY 2 
