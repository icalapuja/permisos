create schema empresax;

create table empresax.tipo_permiso(
	id serial primary key, 
	descripcion varchar(50) not null
);


create table empresax.permiso(
	id serial primary key, 
	nombre_empleado varchar(50) not null,
	apellidos_empleado varchar(50) not null,
	tipo_permiso int not null,
	fecha_permiso timestamp not null default current_timestamp,
	foreign key(tipo_permiso) references empresax.tipo_permiso(id)
);

insert into empresax.tipo_permiso(descripcion) values('Enfermedad')
insert into empresax.tipo_permiso(descripcion) values('Diligencias')
insert into empresax.tipo_permiso(descripcion) values('Otros')
