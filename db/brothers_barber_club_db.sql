CREATE DATABASE brothers_barber_club_db
go


use brothers_barber_club_db
go




CREATE TABLE rolPersonal(
Id_rolPersonal int identity(1,1) PRIMARY KEY,
Tipo_rol varchar(100),
Descripcion varchar(200)
)
go

CREATE TABLE estadoReservaciones(
Id_estado int identity(1,1) PRIMARY KEY,
Estado varchar(100),
Descripcion varchar(200)
)
go


CREATE TABLE tipoReservacion(
Id_tipoReservacion int identity(1,1) PRIMARY KEY,
Tipo_reservacion varchar(100),
Descripcion varchar(200)
)
go


CREATE TABLE tipoCorte(
Id_corte int identity(1,1) PRIMARY KEY,
Tipo_corte varchar(100),
Descripcion varchar(200)
)
go

CREATE TABLE personal(
Id_personal int identity(1,1) PRIMARY KEY,
NombrePersonal varchar(100),
DireccionPersonal varchar(20),
FechaNacimiento date,
Id_rol int FOREIGN KEY REFERENCES rolPersonal(Id_RolPersonal)
)
go

CREATE TABLE historialCortes(
Id_historial int identity(1,1) PRIMARY KEY,
nombreReservacion varchar (100),
fechaReservacion date,
horaReervacion time,
Id_barbero  int FOREIGN KEY REFERENCES personal(Id_personal),
Id_tipoCorte int FOREIGN KEY REFERENCES tipoCorte(Id_corte),
Id_tipoReservacion int FOREIGN KEY REFERENCES tipoReservacion(Id_tipoReservacion),
Id_estadoReservacion int FOREIGN KEY REFERENCES estadoReservaciones(Id_estado)
)
go



create table cuentausuario(
ID_usuario int identity(1,1) not null,
usuario varchar(100) not null,
password varchar(200) not null,
id_personal int FOREIGN KEY REFERENCES personal(Id_personal)
)




ALTER TABLE tipoCorte
ADD Precio DECIMAL(10, 2) NOT NULL DEFAULT 0.00;




SELECT * FROM cuentausuario
SELECT * FROM personal
SELECT * from estadoReservaciones
SELECT * FROM tipoCorte
SELECT * FROM rolPersonal

update personal set Id_rol=1 where Id_personal=1



update rolPersonal set Tipo_rol='Administrador', Descripcion='Rol Administrador' where Id_rolPersonal=1


INSERT INTO estadoReservaciones VALUES('Completado', 'Se realizo el corte')
INSERT INTO estadoReservaciones VALUES('Cancelado', 'No se realizo el corte')
INSERT INTO estadoReservaciones VALUES('Pendiente', 'A la espera del cliente')





INSERT INTO tipoReservacion VALUES('Sin cita', 'El cliente no posee una cita agendada')
INSERT INTO tipoReservacion VALUES('Con cita', 'El cliente agendó una cita con anticipación')

SELECT * from estadoReservaciones
SELECT * FROM historialCortes
SELECT * FROM personal
SELECT * FROM rolPersonal
SELECT * FROM tipoCorte
SELECT * FROM tipoReservacion
=======
INSERT INTO rolPersonal VALUES('Administrador', 'Rol Administracion')
INSERT INTO rolPersonal VALUES('Barbero', 'Rol Barbero')
INSERT INTO rolPersonal VALUES('Limpieza', 'Rol Limpieza')


INSERT INTO cuentausuario VALUES('alex', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
INSERT INTO cuentausuario VALUES('admin', '123', 1)


SELECT * FROM historialCortes h 
JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
WHERE r.Tipo_reservacion = 'Con cita';

update tipoReservacion set Tipo_reservacion = 'Con cita' where Id_tipoReservacion=2