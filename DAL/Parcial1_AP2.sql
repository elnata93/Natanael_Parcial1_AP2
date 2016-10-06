create table Materiales(IdMaterial int primary key identity(1,1),
Descripcion varchar(100),
Precio float );

create table Solicitudes(IdSolicitud int primary key identity(1,1),
Fecha date,
Razon varchar(100),
Total float);

create table SolicitudesDetalle(Id int primary key identity(1,1),
IdSolicitud int 
IdMaterial int references Materiales(IdMateriales),
Cantidad int,
Precio float );

drop table MaterialesDetalle
drop  table Factura