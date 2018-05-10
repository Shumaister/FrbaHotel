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
	[cliente_ID][numeric](18,0) IDENTITY (1,1) PRIMARY KEY,
	[cliente_Persona_ID][numeric](18,0),
	[cliente_Tipo_Documento][numeric](18,0),
	[cliente_Documento_Nro] [numeric](18,0),
	[cliente_Domicilio_ID][numeric](18,0),
	[cliente_Mail] [nvarchar] (255),
	[cliente_Telefono][numeric](18,0),
	[cliente_Nacionalidad_ID][numeric](18,0),
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
	[Habitaciones_frente][nvarchar](5),
	[Habitaciones_tipo_codigo][numeric](18,0),
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
	[Hotel_Regimen_IdRegimen] [numeric](18,0) NOT NULL
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
	[Reserva_Codigo][numeric](18,0) NOT NULL PRIMARY KEY,
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
	[DatoCorrupto][bit] DEFAULT 0
)
 PRINT '... tabla Persona creada ... '
END
GO

-----
----- Hacemos los inserts
-----



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
INSERT INTO RIP.Habitaciones(habitaciones_hotel_ID,habitaciones_numero,habitaciones_piso,habitaciones_frente,habitaciones_tipo_codigo)
select distinct hoteles_ID,Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo from gd_esquema.Maestra
join rip.Domicilio on Hotel_Nro_Calle=domicilio_nro_calle and domicilio_ciudad_ID is not null join RIP.Hoteles on hoteles_domicilio_ID=domicilio_ID
 order by 1,2

--TipoDocumento
INSERT INTO Rip.TipoDocumento(TipoDocumento_Descripcion) VALUES ('Pasaporte')
INSERT INTO Rip.TipoDocumento(TipoDocumento_Descripcion) VALUES ('DNI')

--Clientes
INSERT INTO RIP.Clientes (cliente_persona_ID,cliente_Tipo_Documento,cliente_Documento_Nro,cliente_domicilio_ID,cliente_Mail,cliente_nacionalidad_ID)
select distinct persona_ID,1,Cliente_Pasaporte_Nro,domicilio_ID,Cliente_Mail,1 from gd_esquema.Maestra
join RIP.Persona on persona_nombre=Cliente_Nombre and persona_apellido=Cliente_Apellido and persona_fecha_nacimiento=Cliente_Fecha_Nac
join rip.Calles on calles_descripcion=Cliente_Dom_Calle 
join rip.Domicilio on calles_ID=domicilio_calle_ID and Cliente_Nro_Calle=domicilio_nro_calle and domicilio_depto=Cliente_Depto and domicilio_piso=Cliente_Piso

update rip.Clientes set cliente_DatoCorrupto = 1
where cliente_Documento_Nro=27682640

--Reserva
INSERT INTO RIP.Reserva (Reserva_Codigo,Reserva_Fecha_Inicio,Reserva_Cantidad_Noches,Reserva_Cliente_ID,Reserva_Hotel_ID,Reserva_Habitacion_ID,Reserva_Regimen_ID)
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



--- Aniadimos constraints faltantes

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

ALTER TABLE [RIP].[Clientes]
	ADD CONSTRAINT FK_TIPODOCUMENTO FOREIGN KEY ([cliente_Tipo_Documento]) REFERENCES [RIP].[TipoDocumento] ([TipoDocumento_ID])
GO

--Insertar roles
INSERT INTO RIP.Roles (Rol_Nombre) values('Administrador')
INSERT INTO RIP.Roles (Rol_Nombre) values('Recepcionista')
INSERT INTO RIP.Roles (Rol_Nombre) values('Guest')


--- Creamos el usuario administrador y recepcionista genericos

 

INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('admin',HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('recep',HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO RIP.Usuarios (Usuario_User, Usuario_Contrasena) values('gaby',HASHBYTES('SHA2_256', 'w23e'))

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