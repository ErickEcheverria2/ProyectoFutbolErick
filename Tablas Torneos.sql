--drop database  Proyecto_AdministracionTorneosFutbol;
-- use EEEG;
go
Create database Proyecto_AdministracionTorneosFutbol
go
USE Proyecto_AdministracionTorneosFutbol
go


--TABLA AMONESTACION
CREATE TABLE AMONESTACION
(
	ColorTarjeta varchar(200) NOT NULL, 
	Valor_multa varchar(200) NOT NULL,
	Comentario varchar(200) NOT NULL
	PRIMARY KEY(ColorTarjeta)
);
go
--TABLA ARBITRO
CREATE TABLE ARBITRO
(
	DPI bigInt NOT NULL  ,
	Nombre varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Direccion varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	Nacionalidad varchar(200) NOT NULL,
	FechaNac date NOT NULL,
	Correo varchar(200) NOT NULL,
	Rol	varchar(200) NOT NULL,
	PRIMARY KEY(DPI)
);
go
--TABLA JUGADOR
CREATE TABLE JUGADOR
(
	Identificacion	bigInt NOT NULL  default 0,
	Nombres	varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Fecha_nac date NOT NULL,
	Direccion varchar(250) NOT NULL,
	Nacionalidad varchar(200) NOT NULL,
	Correo varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	Menor_edad bit default 0,
	PRIMARY KEY(Identificacion)
);
go
--TABLA EQUIPO
CREATE TABLE EQUIPO
(
	Id_Equipo int NOT NULL IDENTITY(1,1),
	Nombre varchar(100) NOT NULL,
	CantidadJugadores int NOT NULL,
	Representante varchar(100) NOT NULL,
	PRIMARY KEY(Id_Equipo)
);
go
-- TABLA entrenador
CREATE TABLE ENTRENADOR
(
	DPI int NOT NULL,
	Id_Equipo int NOT NULL,
	Nombre varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Telefono varchar(200) NOT NULL,
	FechaNac date NOT NULL,
	Correo varchar(200) NOT NULL,
	Tiempo varchar(200) NOT NULL,
	Salario VARCHAR(200) NOT NULL,
	PRIMARY KEY(DPI)
);
go
ALTER TABLE ENTRENADOR
	ADD CONSTRAINT fk_entrenador_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo);

	go
	-- TABLA torneo
CREATE TABLE TORNEO
(
	Id_Torneo int NOT NULL IDENTITY(1,1),
	Nombre	varchar(200) NOT NULL,
	FechaInicio date NOT NULL,
	FechaFinal	date NOT NULL,
	Tipo varchar(200) NOT NULL,
	edadminima int NOT NULL,
	edadmaxima int NOT NULL,
	p_ganado int NOT NULL,
	pperdido int NOT NULL,
	pempatado int NOT NULL,
	precio_Torneo Float not null,
	 
	NumeroMaximoDeJugadores int NOT NULL,
	PRIMARY KEY(Id_Torneo)
);

go
--TABLA CANCHA
CREATE TABLE CANCHA
(
	NoCancha int NOT NULL IDENTITY(1,1),
	Nombre varchar(200) NOT NULL,
	Capacidad varchar(20) NOT NULL,
	estatus varchar(20) not null,
	precioDeAlquiler decimal(8,2) not null,
	PRIMARY KEY(NoCancha)
);

go
--TABLA TORNEO_EQUIPO 
CREATE TABLE TORNEO_EQUIPO
(
	Id_Torneo int NOT NULL ,
	Id_Equipo int NOT NULL,
	CostoInscripcion VARCHAR(200) NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo)
);
go
ALTER TABLE TORNEO_EQUIPO
	ADD CONSTRAINT fk_torneoEquipo_TORNEO FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE TORNEO_EQUIPO
	ADD CONSTRAINT fk_torneoEquipo_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
--TABLA POSICION_JUGADOR
 
CREATE TABLE POSICION_JUGADOR
(
	Id_Torneo int NOT NULL, 
	Id_Equipo int NOT NULL,
	Identificacion bigInt NOT NULL,
	Posicion varchar(200),
	NumeroCamisola int NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo,Identificacion)
);
go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
ALTER TABLE POSICION_JUGADOR
	ADD CONSTRAINT fk_posicion_jugador_jugador FOREIGN KEY (Identificacion)
	REFERENCES JUGADOR (Identificacion)  ;
	go


--TABLA partido
CREATE TABLE PARTIDO
(
	Id_Juego int NOT NULL IDENTITY(1,1),
	Id_Torneo int NOT NULL,
	Id_EquipoLocal int NOT NULL,
	Id_EquipoVisita int NOT NULL,
	Fecha date NOT NULL,
	HoraInicio time NOT NULL,
	HoraFinal time NOT NUll,
	MarcadorLocal  int NOT NUll,
	MarcadorVisita int NOT NUll,
	jugado BIT NOT NUll,
	PRIMARY KEY(Id_Juego)
);
go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES TORNEO (Id_Torneo)  ;
	go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES EQUIPO (Id_Equipo)  ;
	go
ALTER TABLE PARTIDO
	ADD CONSTRAINT fk_partido_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES EQUIPO (Id_Equipo);
	go

--TABLA punteo
CREATE TABLE PUNTEO
(
	Id_Punteo int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	Id_EquipoLocal int NOT NULL,
	Id_EquipoVisita	int NOT NULL,
	PunteoEquipoLocal int NOT NULL,
	PunteoEquipoVisita int NOT NULL,
	Golesvisita int NOT NULL,
	Goleslocal int NOT NULL,
	
	PRIMARY KEY(Id_Punteo)
);
go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES EQUIPO (Id_Equipo);
	go
ALTER TABLE PUNTEO
	ADD CONSTRAINT fk_PUNTEO_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES EQUIPO (Id_Equipo);
	go


-- TABLA CAMBIO
CREATE TABLE CAMBIO
(
	Id_Cambio int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	DPIJugadorEntra bigInt NOT NULL,
	DPIJugadorsale	bigInt NOT NULL,
	Tiempo_entrada varchar(200),
	Tiempo_salida varchar(200),
	PRIMARY KEY(Id_Cambio)
);
go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_CAMBIO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_CAMBIO_jugadorEntra FOREIGN KEY (DPIJugadorEntra)
	REFERENCES JUGADOR (Identificacion)  ;
	go
ALTER TABLE CAMBIO
	ADD CONSTRAINT fk_cambio_jugadorSale FOREIGN KEY (DPIJugadorSALE)
	REFERENCES JUGADOR (Identificacion)  ;
	go

--TABLA GOL
CREATE TABLE GOL
(
	Id_Gol int NOT NULL IDENTITY(1,1),
	Id_Juego int NOT NULL,
	Identificacion bigInt NOT NULL,
	Tipo varchar(200),
	Tiempo varchar(200),
	PRIMARY KEY(Id_Gol)
);
go
ALTER TABLE GOL
	ADD CONSTRAINT fk_GOL_JUGADOR FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
go
ALTER TABLE GOL
	ADD CONSTRAINT fk_GOL_JUGADOR2 FOREIGN KEY (Identificacion)
	REFERENCES JUGADOR (Identificacion)  ;
	go

--TABLA ARBITRO_PARTIDO 
CREATE TABLE ARBITRO_PARTIDO
(
	DPI_Arbitro bigInt NOT NULL,
	Id_Juego int NOT NULL,
	Pago varchar(100) NOT NULL,
	PRIMARY KEY(DPI_Arbitro, Id_Juego)
);
go
ALTER TABLE ARBITRO_PARTIDO
	ADD CONSTRAINT fk_ARBITRO_PARTIDO_ARBITRO FOREIGN KEY (DPI_Arbitro)
	REFERENCES ARBITRO (DPI)  ;
	go
ALTER TABLE ARBITRO_PARTIDO
	ADD CONSTRAINT fk_ARBITRO_PARTIDO_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go

--TABLA ADMINISTRACION_CANCHA
CREATE TABLE ADMINISTRACION_CANCHA
(
	Id_Status int NOT NULL IDENTITY(1,1),
	Status_ varchar(200) NOT NULL,
	NoCancha int NOT NULL,
	Id_Juego int NOT NULL,
	PRIMARY KEY(Id_Status)
);
go
ALTER TABLE ADMINISTRACION_CANCHA
	ADD CONSTRAINT fk_ADMINISTRACION_CANCHA_CANCHA FOREIGN KEY (NoCancha)
	REFERENCES CANCHA (NoCancha)  ;
	go
ALTER TABLE ADMINISTRACION_CANCHA
	ADD CONSTRAINT fk_ADMINISTRACION_CANCHA_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES PARTIDO (Id_Juego)  ;
	go

--TABLA registro_amonestacion
CREATE TABLE REGISTRO_AMONESTACION
(
	Id_Juego int NOT NULL,
	Id_Jugador bigInt NOT NULL,
	Color_Tarjeta varchar(200) NOT NULL,
	Tiempo varchar(200) NOT NULL,
	Pagado BIT DEFAULT 0,
	PRIMARY KEY(Id_Juego,Id_Jugador, Color_Tarjeta)
);
go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_PARTIDO FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego)  ;
	go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_JUGADOR FOREIGN KEY (Id_Jugador)
	REFERENCES   JUGADOR (Identificacion) ;
	go
ALTER TABLE REGISTRO_AMONESTACION
	ADD CONSTRAINT fk_REGISTRO_AMONESTACION_Color_Tarjeta FOREIGN KEY (Color_Tarjeta)
	REFERENCES AMONESTACION (ColorTarjeta)  ;
go
-- Tablas Erick Eduardo Echeverría Garrido (7-05-2021)
CREATE TABLE PersonaAlquiler(
	Id_Alquiler int IDENTITY(1,1) NOT NULL,
	DPI_Persona bigInt NOT NULL,
	Nombres		varchar(200) NOT NULL,
	Apellidos	varchar(200) NOT NULL,
	Telefono	varchar(200) NOT NULL,
	Correo		varchar(200) NOT NULL,
	NoCancha	int NOT NULL,
	DiaAlquiler Date NOT NULL,
	HoraInicio Time NOT NULL,
	HoraFinal TIME NOT NULL,
	costoAlquiler decimal(8,2) NOT NULL
	PRIMARY KEY(Id_Alquiler)
);
ALTER TABLE PersonaAlquiler
	ADD CONSTRAINT fk_PersonaAlquiler_Cancha FOREIGN KEY (NoCancha)
	REFERENCES CANCHA (NoCancha);
go
CREATE TABLE InformacionEmpresa(
	Id_InformacionEmpresa int DEFAULT 1 NOT NULL,
	Nombre		varchar(200) DEFAULT 'NombreDefecto',
	Direccion	varchar(200) DEFAULT 'DireccionDefecto',
	Telefono	varchar(200) DEFAULT '0000-0000',
	CostoArbitraje decimal(8,2) DEFAULT '0.00',
	HorarioEntradaLunes	time DEFAULT '00:00:00',
	HorarioSalidaLunes	time DEFAULT '00:00:00',
	HorarioEntradaMartes	time DEFAULT '00:00:00',
	HorarioSalidaMartes	time DEFAULT '00:00:00',
	HorarioEntradaMiercoles	time DEFAULT '00:00:00',
	HorarioSalidaMiercoles	time DEFAULT '00:00:00',
	HorarioEntradaJueves	time DEFAULT '00:00:00',
	HorarioSalidaJueves	time DEFAULT '00:00:00',
	HorarioEntradaViernes	time DEFAULT '00:00:00',
	HorarioSalidaViernes	time DEFAULT '00:00:00',
	HorarioEntradaSabado	time DEFAULT '00:00:00',
	HorarioSalidaSabado	time DEFAULT '00:00:00',
	HorarioEntradaDomingo	time DEFAULT '00:00:00',
	HorarioSalidaDomingo	time DEFAULT '00:00:00',
);
go
INSERT INTO InformacionEmpresa(Id_InformacionEmpresa) VALUES(1);
go
CREATE TABLE ServicioArbitraje(
	Id_Alquiler		INT NOT NULL,
	DPI_Arbitro		bigInt NOT NULL,
	pagoArbitraje	decimal(8,2) NOT NULL,
	DiaJuego Date NOT NULL,
	HoraInicio Time NOT NULL,
	HoraFinal TIME NOT NULL,
	PRIMARY KEY(Id_Alquiler,DPI_Arbitro)
);
go
ALTER TABLE ServicioArbitraje
	ADD CONSTRAINT fk_ServicioArbitraje_Alquiler FOREIGN KEY (Id_Alquiler)
	REFERENCES PersonaAlquiler (Id_Alquiler);
go
ALTER TABLE ServicioArbitraje
	ADD CONSTRAINT fk_ServicioArbitraje_Arbitro FOREIGN KEY (DPI_Arbitro)
	REFERENCES ARBITRO (DPI);
go
CREATE TABLE UsuarioSistema(
	Id_Usuario int IDENTITY(1,1) NOT NULL,
	DPI_Usuario bigInt NOT NULL,
	Nombre_Usuario	varchar(200) NOT NULL,
	Nombres		varchar(200) NOT NULL,
	Apellidos	varchar(200) NOT NULL,
	Telefono	varchar(200) NOT NULL,
	Direccion	varchar(250) NOT NULL,
	Correo		varchar(200) NOT NULL,
	Puesto		varchar(200) NOT NULL,
	estado		varchar(200) NOT NULL,
	Tipo		varchar(200) NOT NULL,
	Contrasena	varchar(200) NOT NULL
	PRIMARY KEY(Id_Usuario)
);
go
INSERT INTO UsuarioSistema (DPI_Usuario,Nombre_Usuario,Nombres,Apellidos,Telefono,Direccion,Correo,Puesto,estado,Tipo, Contrasena)
		          values (0000000000000,'Admin','Admin','Admin',00000000,'Admin','Admin','Administrador','Activo','Administrador','Admin');
go
CREATE TABLE RegistroDeAcceso(
	Id_Usuario		int NOT NULL,
	FechaHoraAcceso	DateTime NOT NULL,
	SeccionEntrada	varchar(200) NOT NULL,
	PRIMARY KEY(Id_Usuario,FechaHoraAcceso)
);
select * from UsuarioSistema

SELECT * FROM PUNTEO