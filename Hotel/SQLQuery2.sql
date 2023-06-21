CREATE DATABASE DBHotel

GO

USE DBHotel

GO

CREATE TABLE Usuario(
	IdUsuario int primary key identity,
	NombreCompleto varchar(50),
	Correo varchar(50),
	IdRolUsuario int,
	Clave varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

Go
create table RolUsuario
(
	IdRolUsuario int primary key identity,
	Descripcion varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

Go

ALTER TABLE Usuario
ADD FOREIGN KEY (IdRolUsuario) REFERENCES RolUsuario(IdRolUsuario)

GO

CREATE TABLE Cliente(
	IdCliente int primary key identity,
	TipoDocumento  varchar(15),
	Documento varchar(15),
	NombreCompleto varchar(50),
	Correo varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

go

CREATE TABLE  Categoria(
	IdCategoria int primary key identity,
	Descripcion varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

GO

CREATE TABLE  Piso(
	IdPiso int primary key identity,
	Descripcion varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

GO

CREATE TABLE  EstadoHabitacion(
	IdEstadoHabitacion int primary key,
	Descripcion varchar(50),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

GO

CREATE TABLE Habitacion(
	IdHabitacion int primary key identity,
	Numero varchar(50),
	Detalle varchar(100),
	Precio decimal(10,2),
	IdEstadoHabitacion int references EstadoHabitacion(IdEstadoHabitacion),
	IdPiso int references PISO(IdPiso),
	IdCategoria int references CATEGORIA(IdCategoria),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

GO
CREATE TABLE Recepcion(
	IdRecepcion int primary key identity,
	IdCliente int references Cliente(IdCliente),
	IdHabitacion int references HABITACION(IdHabitacion),
	FechaEntrada datetime default getdate(),
	FechaSalida datetime,
	FechaSalidaConfirmacion datetime,
	PrecioInicial decimal(10,2),
	Adelanto decimal(10,2),
	PrecioRestante decimal(10,2),
	TotalPagado decimal(10,2) default 0,
	CostoPenalidad decimal(10,2) default 0,
	Observacion varchar(500),
	UsuarioCreacion int,
	FechaCreacion datetime DEFAULT GETDATE(),
	UsuarioModificacion int NULL,
	FechaModificacion datetime NULL,
	UsuarioEliminacion int NULL,
	FechaEliminacion datetime NULL,
	Estado bit DEFAULT 1,
	FOREIGN KEY (UsuarioCreacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioModificacion) REFERENCES Usuario(IdUsuario),
	FOREIGN KEY (UsuarioEliminacion) REFERENCES Usuario(IdUsuario)
)

GO

INSERT INTO RolUsuario (Descripcion, UsuarioCreacion)
VALUES ('Administrador', null)

GO

INSERT INTO Usuario (NombreCompleto, Correo, IdRolUsuario, Clave, UsuarioCreacion)
VALUES ('John Doe', 'johndoe@example.com', 1, 'password123', 1)

GO

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, Correo, UsuarioCreacion)
VALUES ('DNI', '12345678', 'Jane Smith', 'janesmith@example.com', 1)

GO

INSERT INTO Categoria (Descripcion, UsuarioCreacion)
VALUES ('Individual', 1)

GO

INSERT INTO Piso (Descripcion, UsuarioCreacion)
VALUES ('Primer Piso', 1)

GO

INSERT INTO EstadoHabitacion (IdEstadoHabitacion, Descripcion, UsuarioCreacion)
VALUES (1, 'Disponible', 1)

GO

INSERT INTO Habitacion (Numero, Detalle, Precio, IdEstadoHabitacion, IdPiso, IdCategoria, UsuarioCreacion)
VALUES ('101', 'Habitación individual con vista al mar', 100.00, 1, 1, 1, 1)

GO

INSERT INTO Recepcion (IdCliente, IdHabitacion, FechaEntrada, PrecioInicial, Adelanto, PrecioRestante, Observacion, UsuarioCreacion)
VALUES (1, 1, GETDATE(), 100.00, 50.00, 50.00, 'Sin observaciones', 1)

GO

INSERT INTO RolUsuario (Descripcion, UsuarioCreacion) 
VALUES ('Recepcionista', 1)

GO

INSERT INTO RolUsuario (Descripcion, UsuarioCreacion)
VALUES ('Cliente', 1)

GO

create login Luis with password = '12345'
Grant All privileges on Hotel;
