USE [GD1C2018]

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'RIP')
BEGIN
 EXEC ('CREATE SCHEMA [RIP] AUTHORIZATION [gdHotel2018]')
END
GO
-----
IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Clientes' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Clientes](
	[cliente_persona_ID][numeric](18,0),
	[cliente_Pasarporte_Nro] [numeric](18,0) not null,
	[cliente_domicilio_ID][numeric](18,0),
	[cliente_Mail] [nvarchar] (255),
	[cliente_nacionalidad_ID][numeric](18,0),
	[cliente_Dato_corrupto] [bit]
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Facturas' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Facturas](
	[factura_numero] [numeric](18,0),
	[factura_estadia_ID][numeric](18,2),
	[factura_cliente_ID] [numeric](18,0),
	[factura_fecha] [datetime],
	[factura_total] [numeric] (18,2),
)
END
GO



---Crear Tablas

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Usuarios' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Usuarios](
	[usuario_ID][numeric](18,0),
	[usuario_user] [nvarchar](50) not null,
	[usuario_contrasena] [varbinary](100),
	[usuario_cantidadDeIntentos] [int] default 0,
	[usuario_estado][bit],
	[usuario_datoCorrupto][bit]

)
END
GO
IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Roles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Roles](
	[rol_ID][numeric](18,0),
	[rol_nombre] [nvarchar](50) not null,
	[rol_estado] [bit] default 1
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Usuario_Rol' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Usuario_Rol](

	[usuario_Rol_Usuario_ID] [numeric](18,0) not null,
	[usuario_Rol_rol_ID] [numeric](18,0) not null
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Habitaciones' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Habitaciones](
	[habitaciones_ID][numeric](18,0) not null identity(1,1),
	[habitaciones_numero][numeric](18,0),
	[habitaciones_hotel_ID][numeric](18,0),
	[habitaciones_frente][nvarchar](5),
	[habitaciones_tipo_codigo][numeric](18,0)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Habitaciones_Descripcion' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Habitaciones_Descripcion](
	[habitaciones_Descripcion_ID][numeric](18,0),
	[Habitaciones_Descripcion_Descripcion][nvarchar](255)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Hoteles' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Hoteles](
	[hoteles_ID][numeric](18,0)not null identity(1,1),
	[hoteles_domicilio_ID][numeric](18,0),
	[hoteles_nro_estrella][numeric](18,0),
	[hoteles_recarga_estrella][numeric](18,0),
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Calles' AND TABLE_SCHEMA='RIP') 
BEGIN

CREATE TABLE [RIP].[Calles](
	[calles_ID][numeric](18,0) not null identity(1,1),
	[calles_descripcion][nvarchar](255) unique
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Nacionalidad' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Nacionalidad](
	[nacionalidad_ID][numeric](18,0)not null identity(1,1),
	[nacionalidad_descripcion][nvarchar](255)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Ciudades' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Ciudades](
	[ciudades_ID][numeric](18,0) not null identity(1,1),
	[ciudades_descripcion][nvarchar](255)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Regimen' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Regimen](
	[regimen_ID][numeric](18,0)not null identity(1,1),
	[regimen_descripcion][nvarchar](255),
	[regimen_precio][numeric](18,2)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Reserva' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Reserva](
	[reserva_codigo][numeric](18,0),
	[reserva_Fecha_Inicio][datetime],
	[reserva_cantidad_noches][numeric](18,0),
	[reserva_cliente_ID][numeric](18,0),
	[reserva_hotel_ID][numeric](18,0),
	[reserva_habitacion_ID][numeric](18,0),
	[reserva_regimen_ID][numeric](18,0)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Estadia' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Estadia](
	[estadia_ID][numeric](18,0),
	[estadia_fecha_inicio][datetime],
	[estadia_cantidad_noches][numeric](18,0),
	[estadia_cliente_ID][numeric](18,0),
	[estadia_hotel_ID][numeric](18,0),
	[estadia_habitacion_ID][numeric](18,0),
	[estadia_precio_total_consumible][numeric](18,2),
	[estadia_regimen_ID][numeric](18,0)

)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Consumible' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Consumible](
	[consumible_codigo][numeric](18,0),
	[consumible_descripcion][nvarchar](255),
	[consumible_precio][numeric](18,2)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Consumidos' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Consumidos](
	[consumidos_estadia_ID][numeric](18,0),
	[consumidos_consumible_ID][numeric](18,0),
	[consumidos_cantidad][numeric](18,0)

)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Item_Factura' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Item_Factura](
	[item_ID][numeric](18,0),
	[item_consumible_id] [numeric](18,0),
	[item_factura_ID] [numeric](18,0),
	[item_cantidad] [numeric](18,0),
	[item_factura_monto] [numeric](18,2)
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Domicilio' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Domicilio](
	[domicilio_ID] [numeric](18,0) not null identity(1,1),
	[domicilio_ciudad_ID] [numeric](18,0),
	[domicilio_calle_ID] [numeric](18,0),
	[domicilio_nro_calle] [numeric](18,0),
	[domicilio_depto] [nvarchar](3),
	[domicilio_piso] [numeric](18,0),
)
END
GO

IF NOT EXISTS (SELECT 1 
   FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE='BASE TABLE' 
            AND TABLE_NAME='Persona' AND TABLE_SCHEMA='RIP') 
BEGIN
CREATE TABLE [RIP].[Persona](
	[persona_ID][numeric](18,0)not null identity(1,1),
	[persona_nombre][nvarchar](255),
	[persona_apellido][nvarchar](255),
	[persona_fecha_nacimiento][datetime],
	[datoCorrupto][bit]

)
END
GO

--



-- CALLES
INSERT INTO RIP.Calles (calles_descripcion)
select distinct hotel_calle from gd_esquema.Maestra UNION
select distinct cliente_dom_calle from gd_esquema.Maestra
 --Personas
 INSERT INTO RIP.Persona (persona_nombre,persona_apellido,persona_fecha_nacimiento)
select distinct Cliente_Nombre,Cliente_Apellido,Cliente_Fecha_Nac from gd_esquema.Maestra
---Nacionalidad
INSERT INTO RIP.Nacionalidad (nacionalidad_descripcion)
select distinct Cliente_Nacionalidad  from gd_esquema.Maestra
--- ciudades
INSERT INTO RIP.Ciudades (ciudades_descripcion)
select distinct Hotel_Ciudad from gd_esquema.Maestra
--Regimen 
INSERT INTO RIP.Regimen (regimen_descripcion,regimen_precio)
select distinct Regimen_Descripcion,Regimen_Precio from gd_esquema.Maestra
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
INSERT INTO RIP.Habitaciones(habitaciones_hotel_ID,habitaciones_numero,habitaciones_frente,habitaciones_tipo_codigo)
select distinct hoteles_ID,Habitacion_Numero,Habitacion_Frente,Habitacion_Tipo_Codigo from gd_esquema.Maestra
join rip.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null join RIP.Hoteles on hoteles_domicilio_ID=domicilio_ID
 order by 1,2

--Clientes
select * from rip.Clientes
INSERT INTO RIP.Clientes (cliente_persona_ID,cliente_Pasarporte_Nro,cliente_domicilio_ID,cliente_Mail,cliente_nacionalidad_ID)
select distinct persona_ID,Cliente_Pasaporte_Nro,domicilio_ID,Cliente_Mail,1 from gd_esquema.Maestra join RIP.Persona on persona_nombre=Cliente_Nombre and persona_apellido=Cliente_Apellido and persona_fecha_nacimiento=Cliente_Fecha_Nac
join rip.Calles on calles_descripcion=Cliente_Dom_Calle join rip.Domicilio on calles_ID=domicilio_calle_ID and Cliente_Nro_Calle=domicilio_nro_calle order by 2
select * from rip.Persona
select * from rip.Domicilio
select * from RIP.Calles