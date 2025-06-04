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

ALTER TABLE tipoCorte
ADD Precio DECIMAL(10, 2) NOT NULL DEFAULT 0.00;

INSERT INTO estadoReservaciones VALUES('Completado', 'Se realizo el corte')
INSERT INTO estadoReservaciones VALUES('Cancelado', 'No se realizo el corte')
INSERT INTO estadoReservaciones VALUES('Pendiente', 'A la espera del cliente')




INSERT INTO tipoReservacion VALUES('Sin cita', 'El cliente no posee una cita agendada')
INSERT INTO tipoReservacion VALUES('Con sita', 'El cliente agendó una cita con anticipación')

SELECT * from estadoReservaciones
SELECT * FROM historialCortes
SELECT * FROM personal
SELECT * FROM rolPersonal
SELECT * FROM tipoCorte
SELECT * FROM tipoReservacion