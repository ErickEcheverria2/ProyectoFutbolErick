drop database  Proyecto_AdministracionTorneosFutbol;
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
	DPI int NOT NULL  ,
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

	Identificacion	int NOT NULL  default 0,
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
	Identificacion int NOT NULL,
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
	Fecha datetime NOT NULL,
	HoraInicio datetime NOT NULL,
	HoraFinal datetime NOT NUll,
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
	DPIJugadorEntra int NOT NULL,
	DPIJugadorsale	int NOT NULL,
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
	Identificacion int NOT NULL,
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
	DPI_Arbitro int NOT NULL,
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
	Id_Jugador int NOT NULL,
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



 