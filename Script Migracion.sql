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
	[client_ID] [numeric](18,0),
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
	[habitaciones_ID][numeric](18,0),
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
	[hoteles_ID][numeric](18,0),
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
	[nacionalidad_ID][numeric](18,0),
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
	[ciudades_ID][numeric](18,0),
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
	[regimen_ID][numeric](18,0),
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
	[domicilio_ID] [numeric](18,0),
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
	[persona_ID][numeric](18,0),
	[persona_nombre][nvarchar](255),
	[persona_apellido][nvarchar](255),
	[persona_fecha_nacimiento][datetime],
	[datoCorrupto][bit]

)
END
GO

--



-- CLIENTES
INSERT INTO RIP.Calles (calles_descripcion)
select distinct hotel_calle from gd_esquema.Maestra UNION
select distinct cliente_dom_calle from gd_esquema.Maestra



select * from rip.calles
