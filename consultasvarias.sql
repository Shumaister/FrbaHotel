
select * from rip.Usuarios

SELECT r.Rol_Nombre, r.Rol_Estado FROM rip.Roles r
INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID 
INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID
where u.Usuario_User = 'admin' and r.rol

select * from rip.funcionalidades
update rip.Funcionalidades set Funcionalidad_Funcionalidad = 'ABM_USUARIO' where Funcionalidad_Id = 1

SELECT f.Funcionalidad_Funcionalidad FROM rip.Funcionalidades f 
INNER JOIN RIP.Rol_Funcionalidad rf ON f.Funcionalidad_Id = rf.RolFunc_IdFuncionalidad
INNER JOIN RIP.Roles r ON rf.RolFunc_IdRol = r.Rol_ID
WHERE r.Rol_Nombre = 'Administrador'




Update rip.Usuarios set Usuario_CantidadDeIntentos = numerito where Usuario_User = user

---

select h.Hoteles_ID, r.Regimen_ID from gd_esquema.Maestra a
join rip.Calles c on c.Calles_Descripcion = a.Hotel_Calle
join rip.Ciudades ci on ci.Ciudades_Descripcion = a.Hotel_Ciudad
join rip.Domicilio d on d.Domicilio_Nro_calle = a.Hotel_Nro_Calle and d.Domicilio_Calle_ID=c.Calles_ID and d.Domicilio_Ciudad_ID=ci.Ciudades_ID
join rip.Hoteles h on h.Hoteles_Domicilio_ID = d.Domicilio_ID
join rip.Regimen r on r.Regimen_Descripcion=a.Regimen_Descripcion
 group by  h.Hoteles_ID, r.Regimen_ID
 order by 1

select r.regimen_descripcion from rip.Hoteles h
inner join rip.Hotel_Regimen hr on hr.Hotel_Regimen_IdHotel = h.Hoteles_ID
inner join rip.Regimen r on hr.Hotel_Regimen_IdRegimen = r.Regimen_ID
where h.Hoteles_ID=5


select h.hoteles_id from rip.Usuarios u
join rip.Hotel_Usuario hu on hu.hotel_usuario_idusuario = u.Usuario_ID
join rip.Hoteles h on hu.hotel_usuario_idhotel = h.Hoteles_ID
where u.Usuario_User = 'gaby'