USE brothers_barber_club_db;
GO

-- Insertar roles básicos
INSERT INTO rolPersonal (Tipo_rol, Descripcion) VALUES 
('Barbero', 'Personal encargado de realizar los cortes de cabello'),
('Recepcionista', 'Personal encargado de la atención al cliente y agenda'),
('Administrador', 'Personal encargado de la gestión del negocio'),
('Aprendiz', 'Personal en entrenamiento para convertirse en barbero');
GO 