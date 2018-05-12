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
		
		PRINT @Sql
		EXEC  (@Sql)
		
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
 [cliente_ID][numeric](18,0) NOT NULL IDENTITY (1,1) PRIMARY KEY,
 [cliente_Documento_Nro][numeric](18,0), -- TODO DROPREAR AL FINAL
 [cliente_Persona_ID][numeric](18,0),
 [cliente_Habilitado][numeric](18,0) default 1,
 [cliente_DatoCorrupto] [bit] default 0
)
 PRINT '... tabla Clientes creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='TipoDocumento' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[TipoDocumento](
	[TipoDocumento_ID] [numeric](18,0)NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TipoDocumento_Descripcion][nvarchar](15) CONSTRAINT UQ_DESC_TIPODOCUMENTO UNIQUE NOT NULL
)
 PRINT '... tabla TipoDocumento creada ... '
END
GO


IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Facturas' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Facturas](
	[Factura_Numero] [numeric](18,0) PRIMARY KEY,
	[Factura_Estadia_ID][numeric](18,0) NOT NULL,
	[Factura_Cliente_ID] [numeric](18,0) NOT NULL,
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
	[Usuario_Persona_ID][numeric](18,0),
	[Usuario_User] [nvarchar](50) NOT NULL,
	[Usuario_Contrasena] [varbinary](100) NOT NULL,
	[Usuario_CantidadDeIntentos] [int] default 0,
	[Usuario_Estado][bit],
)
 PRINT '... tabla Usuarios creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Hotel_Usuario' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Hotel_Usuario](
	[Hotel_Usuario_IdHotel][numeric](18,0) NOT NULL,
	[Hotel_Usuario_IdUsuario] [numeric](18,0) NOT NULL
)
 PRINT '... tabla Hotel_Usuario creada ... '
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
            AND TABLE_NAME='Funcionalidades' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Funcionalidades](
	[Funcionalidad_Id][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Funcionalidad_Funcionalidad] [nvarchar](50) NOT NULL
)
 PRINT '... tabla Funcionalidades creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Rol_Funcionalidad' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Rol_Funcionalidad](
	[RolFunc_IdRol][numeric](18,0) NOT NULL,
	[RolFunc_IdFuncionalidad] [numeric](18,0) NOT NULL
)
 PRINT '... tabla Rol_Funcionalidad creada ... '
END
GO


IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Usuario_Rol' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Usuario_Rol](
	[Usuario_Rol_Usuario_ID] [numeric](18,0) NOT NULL,
	[Usuario_Rol_Rol_ID] [numeric](18,0) NOT NULL
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
	[Habitaciones_Piso][numeric](18,0),
	[Habitaciones_Frente][nvarchar](5),
	[Habitaciones_Tipo_Codigo][numeric](18,0),
	[Habitaciones_Habilitada][bit] DEFAULT 1
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
	[Hoteles_Nombre][nvarchar](255),
	[Hoteles_Mail][nvarchar](255),
	[Hoteles_Telefono][numeric](18,0),
	[Hoteles_Domicilio_ID][numeric](18,0),
	[Hoteles_Nro_Estrella][numeric](18,0),
	[Hoteles_Recarga_Estrella][numeric](18,0),
	[Hoteles_Fecha_Creacion][datetime],
	[Hoteles_Fecha_Inicio_Mantemiento][datetime],
	[Hoteles_Fecha_Final_Mantemiento][datetime],
	[Hoteles_Habilitado][bit] default 1
)
 PRINT '... tabla Hoteles creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Hotel_Regimen' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Hotel_Regimen](
	[Hotel_Regimen_IdHotel][numeric](18,0) NOT NULL,
	[Hotel_Regimen_IdRegimen] [numeric](3,0) NOT NULL
)
 PRINT '... tabla Hotel_Regimen creada ... '
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
	[Regimen_ID][numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Regimen_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_REGIMEN unique NOT NULL,
	[Regimen_Precio][numeric](18,2) NOT NULL,
	[Regimen_Habilitado][bit] DEFAULT 1
)
 PRINT '... tabla Regimen creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Reservas' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Reservas](
	[Reserva_Codigo][numeric](18,0) NOT NULL PRIMARY KEY,
	[Reserva_Fecha_Creacion][datetime],
	[Reserva_Fecha_Inicio][datetime],
	[Reserva_Fecha_Fin][datetime],
	[Reserva_Cantidad_Noches][numeric](18,0),
	[Reserva_Cliente_ID][numeric](18,0),
	[Reserva_Usuario][varchar](50),
	[Reserva_Hotel_ID][numeric](18,0),
	[Reserva_Habitacion_ID][numeric](18,0),
	[Reserva_Regimen_ID][numeric](3,0),
	[Reserva_Estado][numeric](3,0)
)
 PRINT '... tabla Reservas creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Reserva_Estado' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Reserva_Estado](
	[Reserva_Estado_ID][numeric](3,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Reserva_Estado_Descripcion][nvarchar](255) CONSTRAINT UQ_DESC_RESERVA_ESTADO unique NOT NULL
)
 PRINT '... tabla Reserva_Estado creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Estadia' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Estadia]( -- TODO ESTO REVISAR< PORQUE AL PEDO TENER TODOS ESOS DATOS SI YA LOS TENGO EN LA RESERVA PAPUUUUUUUUUUUU
	[Estadia_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Estadia_Fecha_Inicio][datetime],
	[Estadia_Cantidad_Noches][numeric](18,0),
	[Estadia_Cliente_ID][numeric](18,0), -- TODO FK CLIENTE
	[Estadia_Hotel_ID][numeric](18,0), --- TODO FK HOTEL
	[Estadia_Habitacion_ID][numeric](18,0), -- TODO FK HABITACION
	[Estadia_Precio_Total_Consumible][numeric](18,2),
	[Estadia_Regimen_ID][numeric](3,0) -- TODO FK REGIMEN
)
 PRINT '... tabla Estadia creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Hab_NoDisponibles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Hab_NoDisponibles](
	[NoDisponible_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[NoDisponible_Reserva_ID][numeric](18,0) NOT NULL, -- TODO ID RESERVA
	[NoDisponible_Habitacion_ID][numeric](18,0) NOT NULL, -- TODO ID HABITACION
	[NoDisponible_Fecha_Inicio][datetime] NOT NULL,
	[NoDisponible_Fecha_Fin][datetime] NOT NULL,
	[NoDisponible_Finalizado][bit] DEFAULT 1
)
 PRINT '... tabla Hab_NoDisponibles creada ... '
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
            AND TABLE_NAME='Item_Factura' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Item_Factura](
	[Item_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Item_Consumible_Id] [numeric](18,0),
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
	[Domicilio_Pais_ID] [numeric](18,0),
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
            AND TABLE_NAME='Paises' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Paises](
	[Pais_Id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Pais_Nombre] [nvarchar](50),
)
 PRINT '... tabla Paises creada ... '
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
	[Persona_Tipo_Documento][nvarchar](15), 
	[Persona_Identificacion_Nro] [numeric](18,0),
	[Persona_Domicilio_ID][numeric](18,0),
	[Persona_Mail] [nvarchar] (255), 
	[Persona_Telefono][nvarchar](50),
	[Persona_Pais_Origen][numeric](18,0),
	[Persona_Nacionalidad_ID][numeric](18,0),
	[Persona_DatoCorrupto][bit] DEFAULT 0
)
PRINT '... tabla Persona creada ... '
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Cierre_Mantenimiento' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Cierre_Mantenimiento](
	[Cierre_ID][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cierre_Hotel_ID][numeric](18,0)NOT NULL,
	[Cierre_Fecha_Inicio][datetime],
	[Cierre_Fecha_Fin][datetime],
	[Cierre_Motivo][nvarchar](255),
)
PRINT '... tabla Cierre_Mantenimiento creada ... '
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
PRINT '... tabla Cancelacion_Reserva creada ... '
END
GO

-----
----- Hacemos los inserts
-----

-- CALLES
INSERT INTO RIP.Calles (calles_descripcion)
select distinct hotel_calle from gd_esquema.Maestra UNION
select distinct cliente_dom_calle from gd_esquema.Maestra

-- Paises
INSERT INTO RIP.Paises (Pais_Nombre) VALUES ('Argentina')


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

--- Habitaciones Descripcion
INSERT INTO RIP.Habitaciones_Descripcion (habitaciones_descripcion_ID,habitaciones_descripcion_descripcion)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion from gd_esquema.Maestra

--- Domicilio
INSERT INTO rip.Domicilio (domicilio_ciudad_ID,domicilio_calle_ID,domicilio_nro_calle)
select distinct ciudades_ID,calles_ID,Hotel_Nro_Calle from gd_esquema.Maestra join rip.Ciudades on ciudades_descripcion=Hotel_Ciudad join rip.Calles on calles_descripcion=Hotel_Calle
INSERT INTO rip.Domicilio (domicilio_calle_ID,domicilio_nro_calle,domicilio_depto,domicilio_piso)
select distinct calles_ID,Cliente_Nro_Calle,Cliente_Depto,Cliente_Piso from gd_esquema.Maestra join rip.Calles on calles_descripcion=Cliente_Dom_Calle

--Hoteles
INSERT INTO RIP.Hoteles (hoteles_domicilio_ID,hoteles_nro_estrella,hoteles_recarga_estrella)
select distinct domicilio_ID,Hotel_CantEstrella,Hotel_Recarga_Estrella from gd_esquema.Maestra join RIP.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null

---Habitaciones
INSERT INTO RIP.Habitaciones(habitaciones_hotel_ID,habitaciones_numero,habitaciones_piso,habitaciones_frente,habitaciones_tipo_codigo)
select distinct hoteles_ID,Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo from gd_esquema.Maestra
join rip.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null join RIP.Hoteles on hoteles_domicilio_ID=domicilio_ID
 order by 1,2

--TipoDocumento
INSERT INTO Rip.TipoDocumento(TipoDocumento_Descripcion) VALUES ('Pasaporte'),('DNI')


--Personas
INSERT INTO RIP.Persona (persona_nombre,persona_apellido,persona_fecha_nacimiento,persona_Tipo_Documento,Persona_Identificacion_Nro,Persona_Domicilio_ID,Persona_Mail,Persona_Nacionalidad_ID)
select distinct Cliente_Nombre,Cliente_Apellido,Cliente_Fecha_Nac,1,Cliente_Pasaporte_Nro,Domicilio_ID,Cliente_Mail,1 from gd_esquema.Maestra
join rip.Calles on calles_descripcion=Cliente_Dom_Calle 
join rip.Domicilio on calles_ID=domicilio_calle_ID and Cliente_Nro_Calle=domicilio_nro_calle and domicilio_depto=Cliente_Depto and domicilio_piso=Cliente_Piso


--Clientes
INSERT INTO RIP.Clientes (cliente_persona_ID,cliente_Documento_Nro)
select distinct persona_ID,Cliente_Pasaporte_Nro from gd_esquema.Maestra
join RIP.Persona on persona_Identificacion_Nro=Cliente_Pasaporte_Nro


update rip.Clientes set cliente_DatoCorrupto = 1
where cliente_Documento_Nro=27682640

--Reservas
INSERT INTO RIP.Reservas (Reserva_Codigo,Reserva_Fecha_Inicio,Reserva_Cantidad_Noches,Reserva_Cliente_ID,Reserva_Hotel_ID,Reserva_Habitacion_ID,Reserva_Regimen_ID)
select distinct Reserva_Codigo,Reserva_Fecha_Inicio,Reserva_Cant_Noches,clientes.cliente_Documento_Nro,Hoteles_ID,Habitaciones_ID,Regimen_ID from gd_esquema.Maestra 
join rip.Clientes on clientes.cliente_Documento_Nro = gd_esquema.Maestra.Cliente_Pasaporte_Nro
join rip.Domicilio on Domicilio_Nro_calle=Hotel_Nro_Calle and Domicilio_Ciudad_ID is not null
join rip.Hoteles on Hoteles_Domicilio_ID=Domicilio_ID and Hoteles_Nro_Estrella=Hotel_CantEstrella
join rip.Habitaciones on Habitaciones_hotel_ID=Hoteles_ID and Habitaciones_Numero=Habitacion_Numero and habitaciones_frente=Habitacion_Frente and habitaciones_tipo_codigo=Habitacion_Tipo_Codigo
join rip.Regimen on regimen.regimen_descripcion=gd_esquema.Maestra.Regimen_Descripcion
where clientes.cliente_DatoCorrupto!=1

--Estadia
INSERT INTO RIP.Estadia(Estadia_Fecha_Inicio,Estadia_Cantidad_Noches,Estadia_Cliente_ID,Estadia_Hotel_ID,Estadia_Habitacion_ID,Estadia_Precio_Total_Consumible,Estadia_Regimen_ID)
select distinct Estadia_Fecha_Inicio,Estadia_Cant_Noches,clientes.cliente_Documento_Nro,Hoteles_ID,Habitaciones_ID,sum(isnull(Consumible_Precio,0)),Regimen_ID from gd_esquema.Maestra
join rip.Clientes on clientes.cliente_Documento_Nro = gd_esquema.Maestra.Cliente_Pasaporte_Nro
join rip.Domicilio on Domicilio_Nro_calle=Hotel_Nro_Calle and Domicilio_Ciudad_ID is not null
join rip.Hoteles on Hoteles_Domicilio_ID=Domicilio_ID and Hoteles_Nro_Estrella=Hotel_CantEstrella
join rip.Habitaciones on Habitaciones_hotel_ID=Hoteles_ID and Habitaciones_Numero=Habitacion_Numero and habitaciones_frente=Habitacion_Frente and habitaciones_tipo_codigo=Habitacion_Tipo_Codigo
join rip.Regimen on regimen.regimen_descripcion=gd_esquema.Maestra.Regimen_Descripcion
where Estadia_Fecha_Inicio is not null and clientes.cliente_DatoCorrupto!=1
group by Estadia_Fecha_Inicio,Estadia_Cant_Noches,clientes.cliente_Documento_Nro,Hoteles_ID,Habitaciones_ID,Regimen_ID

--Facturas
INSERT INTO RIP.Facturas(Factura_Numero,Factura_Fecha,Factura_Total,Factura_Estadia_ID,Factura_Cliente_ID)
select distinct b.Factura_Nro,b.Factura_Fecha,b.Factura_Total,a.Estadia_ID,a.Estadia_Cliente_ID from gd_esquema.Maestra b
join rip.Estadia a on a.Estadia_Cantidad_Noches=b.Estadia_Cant_Noches and a.Estadia_Fecha_Inicio=b.Estadia_Fecha_Inicio
join rip.Clientes on clientes.cliente_Documento_Nro=b.Cliente_Pasaporte_Nro
where Factura_Nro is not null and b.Cliente_Pasaporte_Nro=a.Estadia_Cliente_ID
and clientes.cliente_DatoCorrupto!=1
order by 1

--- Item_Factura
INSERT INTO RIP.Item_Factura(Item_Consumible_Id,Item_Factura_ID,Item_Cantidad,Item_Factura_Monto)
select Consumible_Codigo,Factura_Nro,Item_Factura_Cantidad,Item_Factura_Monto from gd_esquema.Maestra
where Factura_Nro is not null

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
	CONSTRAINT FK_DOMICILIO_PAIS FOREIGN KEY ([Domicilio_Pais_ID]) REFERENCES [RIP].[Paises] ([Pais_Id]),
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
	ADD CONSTRAINT FK_HABITACIONES_HOTEL FOREIGN KEY ([Habitaciones_hotel_ID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_HABITACIONES_TIPO FOREIGN KEY ([Habitaciones_Tipo_Codigo]) REFERENCES [RIP].[Habitaciones_Descripcion] ([Habitaciones_Descripcion_ID])
GO

ALTER TABLE [RIP].[Hoteles]
	ADD CONSTRAINT FK_HOTELES_DOMICILIO FOREIGN KEY ([Hoteles_Domicilio_ID]) REFERENCES [RIP].[Domicilio] ([Domicilio_ID])
GO

ALTER TABLE [RIP].[Reservas]
	ADD CONSTRAINT FK_RESERVAS_CLIENTE FOREIGN KEY ([Reserva_Cliente_ID]) REFERENCES [RIP].[Clientes] ([cliente_ID]),
	CONSTRAINT FK_RESERVAS_HOTEL FOREIGN KEY ([Reserva_Hotel_ID]) REFERENCES [RIP].[Hoteles] ([Hoteles_ID]),
	CONSTRAINT FK_RESERVAS_HABITACION FOREIGN KEY ([Reserva_Habitacion_ID]) REFERENCES [RIP].[Habitaciones] ([Habitaciones_ID]), -- ESTO MUERE
	CONSTRAINT FK_RESERVAS_REGIMEN FOREIGN KEY ([Reserva_Regimen_ID])  REFERENCES [RIP].[Regimen] ([Regimen_ID])
GO

ALTER TABLE [RIP].[Persona]
	ADD CONSTRAINT FK_PERSONA_DOMICILIO FOREIGN KEY ([Persona_Domicilio_ID]) REFERENCES [RIP].[Domicilio] ([Domicilio_ID]),
    CONSTRAINT FK_PERSONA_PAIS_ORIGEN FOREIGN KEY ([Persona_Pais_Origen]) REFERENCES [RIP].[Paises] ([Pais_Id]),
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

ALTER TABLE [RIP].[Item_Factura]
	ADD CONSTRAINT FK_ITEM_FACTURA_CONSUMIBLE FOREIGN KEY ([Item_Consumible_Id]) REFERENCES [RIP].[Consumible] ([Consumible_Codigo]),
	CONSTRAINT FK_ITEM_FACTURA_FACTURA FOREIGN KEY ([Item_Factura_ID]) REFERENCES [RIP].[Facturas] ([Factura_Numero])
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

INSERT INTO RIP.Domicilio (Domicilio_Calle_ID,Domicilio_Nro_calle,Domicilio_Ciudad_ID,Domicilio_Pais_ID)
VALUES (2,1816,2,1)

INSERT INTO RIP.Persona (Persona_nombre, Persona_apellido, Persona_fecha_nacimiento, persona_tipo_documento, Persona_Identificacion_Nro,persona_domicilio_id, persona_mail, persona_telefono, persona_pais_origen, Persona_Nacionalidad_ID) 
VALUES ('Gabriel', 'Maiori', '19960725 13:31:00.000', 2, 39769742, @@IDENTITY, 'gabrielmaiori@gmail.com', '1154249902', 1 , 1 )

UPDATE RIP.Usuarios set Usuario_Persona_ID = @@IDENTITY where Usuario_User = 'gaby'

INSERT INTO RIP.Funcionalidades(Funcionalidad_Funcionalidad)
values ('AMB_USUARIO'),('ABM_ROL'),('ABM_CLIENTE'),('ABM_HOTEL'),('ABM_RESERVA'),('ABM_ESTADIA')

INSERT INTO RIP.Rol_Funcionalidad(RolFunc_IdRol,RolFunc_IdFuncionalidad)
values(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(2,6),(3,5)

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

