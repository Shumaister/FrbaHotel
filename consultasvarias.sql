
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
