create table Facturas(FacturaId int primary key identity(1,1),
Razon varchar(100));

create table MaterialesDetalle(MaterialDetalleId int primary key identity(1,1),
FacturaId int references Facturas(FacturaId),
Material varchar(50),
Cantidad int );

drop table MaterialesDetalle