create proc updtorneo @id int , @name varchar(200),@inicio date,@final date ,@tp varchar(200),@edmn int,@edmx int,@pga int,@ppe int,@pemp int,@campo int
as  update  Torneo set
[Nombre]=@name,[FechaInicio]=@inicio ,[FechaFinal]=@final,[Tipo]=@tp ,[edadminima]=@edmn,[edadmaxima]=@edmx ,[p_ganado]=@pga,[pperdido]=@ppe ,[pempatado]=@pemp,[NumeroMaximoDeJugadores]=@campo
where  id_Torneo=@id
go

create proc dtltorneo @id int 
as delete from TORNEO where Id_Torneo=@id;

create proc vertorneos
as select * from torneo
go
 

create proc getidtorneo @id int
as select * from torneo where [Id_Torneo]=@id

go
create proc instorneo @name varchar(200),@inicio date,@final date ,@tp varchar(200),@edmn int,@edmx int,@pga int,@ppe int,@pemp int,@campo int,@precio float 
as INSERT INTO [TORNEO] ([Nombre],[FechaInicio] ,[FechaFinal],[Tipo] ,[edadminima],[edadmaxima] ,[p_ganado],[pperdido] ,[pempatado],[NumeroMaximoDeJugadores],[precio_Torneo])
     VALUES (@name,@inicio,@final,@tp,@edmn,@edmx,@pga,@ppe,@pemp,@campo,@precio)
 go

 create proc newidt
as select  case when count(*)> 0 then max(id_torneo) else 0 end as id_torneo  from torneo

go
 

 -- equipos 

 CREATE PROCEDURE SP_VIEW_EQUIPOS
AS BEGIN
	SELECT * FROM EQUIPO
END
GO

CREATE PROCEDURE SP_INSERT_EQUIPO @Nombre VARCHAR(100), @CantidadJugadores INT, @Representante VARCHAR(100)
AS BEGIN
    INSERT INTO EQUIPO (Nombre, CantidadJugadores, Representante) 
        VALUES (@Nombre,@CantidadJugadores,@Representante);
END
GO

CREATE PROCEDURE SP_UPDATE_EQUIPO @Id_Equipo INT, @Nombre VARCHAR(100), @CantidadJugadores INT, @Representante VARCHAR(100)
AS BEGIN
	UPDATE EQUIPO SET Nombre=@Nombre, CantidadJugadores=@CantidadJugadores, Representante=@Representante WHERE Id_Equipo = @Id_Equipo
END
GO

CREATE PROCEDURE SP_DELETE_EQUIPO @Id_Equipo INT
AS BEGIN
	DELETE FROM EQUIPO WHERE Id_Equipo = @Id_Equipo
END
GO

--jugadores 

create proc verjugadores
as
select * from JUGADOR

create proc verjugadoresporid @id int
as
select * from JUGADOR where Identificacion=@id

 


create proc insjs @id int , @nb varchar(200) , @ap varchar(200),@fn date ,@drc varchar(250) , @nac varchar(200), @cr varchar(200), @tf varchar(200),@medad bit
as 
INSERT INTO [dbo].[JUGADOR]
           ([Identificacion]
           ,[Nombres]
           ,[Apellidos]
           ,[Fecha_nac]
           ,[Direccion]
           ,[Nacionalidad]
           ,[Correo]
           ,[Telefono]
           ,[Menor_edad])
     VALUES (@id  , @nb , @ap ,@fn,@drc  , @nac , @cr , @tf,@medad )



	 create proc dtljs @id int 
	 as delete from JUGADOR
	 where Identificacion=@id;




	 create proc updjs @id int , @nb varchar(200) , @ap varchar(200),@fn date ,@drc varchar(250) , @nac varchar(200), @cr varchar(200), @tf varchar(200),@medad bit
as  update JUGADOR  
set   [Nombres]=@nb , [Apellidos]=@ap ,Fecha_nac=@fn, Direccion=@drc  , Nacionalidad=@nac ,Correo= @cr ,Telefono= @tf,Menor_edad= @medad
where Identificacion=@id




-- entrenador 
CREATE PROCEDURE SP_VIEW_ENTRENADORES
AS BEGIN
	SELECT * FROM ENTRENADOR
END
GO 

CREATE PROCEDURE SP_INSERT_ENTRENADOR 
	@DPI INT, 
	@Id_Equipo INT, 
	@Nombre VARCHAR (200), 
	@Apellidos VARCHAR (200), 
	@Telefono VARCHAR (200),
	@FechaNac DATETIME,
	@Correo VARCHAR (200),
	@Tiempo VARCHAR (200),
	@Salario VARCHAR (200)
AS BEGIN
	INSERT INTO ENTRENADOR ( DPI,
		Id_Equipo, 
		Nombre, 
		Apellidos, 
		Telefono, 
		FechaNac, 
		Correo, 
		Tiempo, 
		Salario)
	VALUES (
		@DPI,
		@Id_Equipo,
		@Nombre,
		@Apellidos,
		@Telefono,
		@FechaNac,
		@Correo,
		@Tiempo,
		@Telefono
	)
END
GO

CREATE PROCEDURE SP_SEARCH_ENTRENADOR @opcion INT, @busqueda VARCHAR(200)
AS BEGIN
	IF @opcion = 0		
		SELECT EN.DPI, 
			EN.Id_Equipo, 
			EN.Nombre, 
			EN.Apellidos,
			EN.Telefono,
			EN.FechaNac,
			EN.Correo,
			EN.Tiempo,
			EN.Salario
		FROM ENTRENADOR EN INNER JOIN EQUIPO EQ 
		ON EN.Id_Equipo = EQ.Id_Equipo
		WHERE EQ.Nombre = @busqueda
	ELSE IF	@opcion = 1
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.Nombre = @busqueda
	ELSE IF @opcion = 2
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.Apellidos = @busqueda
	ELSE IF @opcion = 3
		SELECT *
		FROM ENTRENADOR EN
		WHERE EN.DPI = @busqueda
END
GO

CREATE PROCEDURE SP_UPDATE_ENTRENADOR 
	@DPI INT, 
	@Id_Equipo INT, 
	@Nombre VARCHAR (200), 
	@Apellidos VARCHAR (200), 
	@Telefono VARCHAR (200),
	@FechaNac DATETIME,
	@Correo VARCHAR (200),
	@Tiempo VARCHAR (200),
	@Salario VARCHAR (200)
AS BEGIN
	UPDATE ENTRENADOR SET 
	Id_Equipo = @Id_Equipo,
	Nombre = @Nombre,
	Apellidos = @Apellidos,
	Telefono = @Telefono,
	FechaNac = @FechaNac,
	Correo = @Correo,
	Tiempo = @Tiempo,
	Salario = @Salario
	WHERE DPI = @DPI
END
GO

CREATE PROCEDURE SP_DELETE_ENTRENADOR @DPI INT
AS BEGIN
	DELETE FROM ENTRENADOR WHERE DPI = @DPI
END
GO

--torneo queipo 

CREATE PROCEDURE INSERT_TORNEO_EQUIPO @Id_Torneo int, @Id_Equipo int, @CostoInscripcion varchar(100)
AS BEGIN 
	INSERT INTO TORNEO_EQUIPO (Id_Torneo,Id_Equipo, CostoInscripcion)
	VALUES (@Id_Torneo,@Id_Equipo, @CostoInscripcion);
END 
GO 

 CREATE PROCEDURE VIEWTORNEO_EQUIPO @Id_Torneo int
AS BEGIN 
	SELECT * FROM TORNEO_EQUIPO WHERE Id_Torneo = @Id_Torneo
END 
GO


CREATE PROCEDURE UPDATE_TORNEO_EQUIPO @Id_Torneo int, @Id_Equipo int, @CostoInscripcion varchar(100)
AS BEGIN
	UPDATE TORNEO_EQUIPO SET Id_Torneo = @Id_Torneo, Id_Equipo= @Id_Equipo, CostoInscripcion = @CostoInscripcion WHERE Id_Equipo = @Id_Equipo and Id_Torneo = @Id_Torneo
END
GO


CREATE PROCEDURE DELETE_TORNEO_EQUIPO @Id_Equipo INT, @Id_Torneo Int
AS BEGIN
	DELETE FROM TORNEO_EQUIPO WHERE Id_Equipo = @Id_Equipo and Id_Torneo = @Id_Torneo
END
GO

--canchas 
 create proc newich
as select  case when count(*)> 0 then max(NoCancha) else 0 end as n_cancha  from CANCHA

 go

-- jornadas

create proc getPartido
	as
	Select * from PARTIDO
	go

	 


	create proc getEquipos @id int
	as
	select * from TORNEO_EQUIPO
	where Id_Torneo=@id
	exec getEquipos 2
 

 go
 drop proc getListaPartidos 
 go
	create proc getListaPartidos @id int
	as 
	select  p.Id_Juego,p.Id_Torneo,p.Id_EquipoLocal,p.Id_EquipoVisita, e.Nombre , e2.Nombre ,p.Fecha , p.HoraInicio , p.HoraFinal ,p.MarcadorLocal ,p.MarcadorVisita, p.jugado
	from PARTIDO p , EQUIPO e , equipo e2
	where Id_Torneo=@id
	and p.Id_EquipoLocal = e.Id_Equipo
	and p.Id_EquipoVisita= e2.Id_Equipo
	go



	create proc ingresoJornada  @idT int,@EL int,@Ev int
	as insert into PARTIDO(Id_Torneo,Id_EquipoLocal,Id_EquipoVisita,fecha, HoraInicio,HoraFinal,MarcadorLocal,MarcadorVisita,jugado) values(@idT,@EL,@Ev,GETDATE(),GETDATE(),GETDATE(),0,0,0)
	go
	
	
	 
	 go

	 create proc editjornada @id int , @fc datetime , @in datetime , @fn datetime , @gl int , @gv int 
	 as  update PARTIDO 
	 set  Fecha=@fc , HoraInicio=@in , HoraFinal=@fn , MarcadorLocal=@gl , MarcadorVisita=@gv , jugado=1
	 where id_juego=@id;

	 go
	
	 
	  
	  create proc getdata @id int 
	  as select * from partido where Id_Juego=@id
	  go
	 --puuntois 


	 create proc insertpuntos @id int , @el int , @ev int , @pl int , @pv int  , @gl int ,@gv int
	 as insert into PUNTEO ([Id_Juego],[Id_EquipoLocal],[Id_EquipoVisita],[PunteoEquipoLocal],[PunteoEquipoVisita],[Golesvisita],[Goleslocal]) values (@id  , @el  , @ev  , @pl  , @pv   , @gl  ,@gv )

	 go
	 

 --- Reporte de Tablas 
drop proc tablalocal 
 go 
 drop proc tablavisitante
 go
 create proc tablalocal @id int
as
select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres  ,  count(p.Id_EquipoLocal)  as PJ ,
case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) end as PG
,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) end as PP
,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) end as PE, sum(pr.MarcadorLocal) as GF  
,  sum(pr.MarcadorVisita) as GC , sum(pr.MarcadorLocal)-sum(pr.MarcadorVisita) as DG , case  when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end as PTS from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
where pr.Id_Torneo=@id
group by  pr.Id_EquipoLocal
order by PTS desc;
 go
 
--visitante
 
 create proc tablavisitante @id int
as
select (select e.Nombre from EQUIPO e where pr.Id_EquipoVisita=e.Id_Equipo) as Nombres   ,  count(p.Id_EquipoVisita)  as PJ , 
case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) end as PG
,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) end as PP
,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) end as PE  ,
sum(pr.MarcadorVisita) as GF  ,  sum(pr.MarcadorLocal) as GC , sum(pr.MarcadorVisita)- sum(pr.MarcadorLocal) as DG , case  when sum(p.PunteoEquipoVisita) is null then 0 else sum(p.PunteoEquipoVisita) end as PTS from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
where pr.Id_Torneo=@id
group by  pr.Id_EquipoVisita
order by PTS desc
 
 go

 exec tablavisitante 5
-- total

drop proc tablageneral
go 
 create proc tablageneral  @tr int
 as 
 
select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres   , count(p.Id_EquipoLocal)+ (
 select   count(p2.Id_EquipoVisita)   from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
) as PJ, 
case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoVisita) end as PG
,
case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal < p2.Golesvisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal > p2.Golesvisita  group by p2.Id_EquipoVisita) end as PP
,
case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@tr and pr2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.Goleslocal = p2.Golesvisita  group by p2.Id_EquipoVisita) end as PE


, case when sum(p.Goleslocal) is null then 0  else sum(p.Goleslocal) end + (
 select  case when  sum(p2.Golesvisita) is null then 0 else  sum(p2.Golesvisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as GF ,
 case when sum(p.Golesvisita) is null then 0  else sum(p.Golesvisita) end + (
 select  case when  sum(p2.Goleslocal) is null then 0 else  sum(p2.Goleslocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as GC,
case when sum(p.Goleslocal) is null then 0  else sum(p.Goleslocal) end + (
 select  case when  sum(p2.Golesvisita) is null then 0 else  sum(p2.Golesvisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  - ( case when sum(p.Golesvisita) is null then 0  else sum(p.Golesvisita) end + (
 select  case when  sum(p2.Goleslocal) is null then 0 else  sum(p2.Goleslocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
) )as DF,
case when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end + (
 select  case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@tr
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as PTS

from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
where pr.Id_Torneo=@tr
group by  pr.Id_EquipoLocal
order by PTS desc

 

-- posicion jugador

--create 
CREATE PROCEDURE SP_VIEW_POSICION_JUGADOR @Id_Torneo INT, @Id_Equipo INT
AS BEGIN
	SELECT * FROM POSICION_JUGADOR WHERE Id_Torneo = @Id_Torneo AND Id_Equipo = @Id_Equipo
END
GO


CREATE PROCEDURE SP_INSERT_POSICION_JUGADOR
	@Id_Torneo INT, 
	@Id_Equipo INT, 
	@Identificacion INT, 
	@Posicion VARCHAR(200),
	@NumeroCamisola INT
AS BEGIN
	INSERT INTO POSICION_JUGADOR ( 
		Id_Torneo,
		Id_Equipo, 
		Identificacion, 
		Posicion,
		NumeroCamisola
	)
	VALUES (
		@Id_Torneo,
		@Id_Equipo, 
		@Identificacion, 
		@Posicion,
		@NumeroCamisola
	)
END
GO



CREATE PROCEDURE SP_UPDATE_POSICION_JUGADOR
	@Id_Torneo INT, 
	@Id_Equipo INT, 
	@Identificacion INT, 
	@Posicion VARCHAR(200),
	@NumeroCamisola INT
AS BEGIN
	UPDATE POSICION_JUGADOR SET 
		Id_Torneo = @Id_Torneo, 
		Id_Equipo= @Id_Equipo, 
		Identificacion = @Identificacion,
		Posicion = @Posicion,
		NumeroCamisola = @NumeroCamisola 
	WHERE Identificacion = @Identificacion 
	AND Id_Torneo = @Id_Torneo
	AND Id_Equipo= @Id_Equipo
END
GO

CREATE PROCEDURE SP_DELETE_POSICION_JUGADOR 
	@Identificacion INT, 
	@Id_Torneo INT,
	@Id_Equipo INT
AS BEGIN
	DELETE FROM POSICION_JUGADOR 
	WHERE Identificacion = @Identificacion
	AND Id_Torneo = @Id_Torneo
	AND Id_Equipo = @Id_Equipo
END
GO
---------Arbitros-----
	
 create proc getArbitros
as
select*from ARBITRO

--insertar arbitros

create proc insertar_arbitros @DPI int, @nombre varchar(200),@apellido varchar(200),@direccion varchar(200),@telefono varchar(200),@nacionalidad varchar(200),@fechaNac date,@correo varchar(200),@rol varchar(200)
as
	insert into ARBITRO(DPI,nombre,apellidos,Direccion,telefono,Nacionalidad,FechaNac,Correo,Rol)values(@DPI, @nombre,@apellido,@direccion,@telefono,@nacionalidad,@fechaNac,@correo,@rol)

--ACTUALIZAR
create proc actualizar_arbitros @DPI int, @nombre varchar(200),@apellido varchar(200),@direccion varchar(200),@telefono varchar(200),@nacionalidad varchar(200),@fechaNac date,@correo varchar(200),@rol varchar(200)
as
update ARBITRO set  Nombre= @nombre, Apellidos= @apellido, Direccion= @direccion, Telefono= @telefono, Nacionalidad=@nacionalidad, FechaNac=@fechaNac,Correo= @correo ,Rol= @rol  where DPI= @DPI

 --control cancha
 CREATE PROCEDURE SP_INSERT_CONTROL_CANCHA @Status_ VARCHAR(200), @NoCancha INT, @Id_Juego INT
AS BEGIN
    INSERT INTO ADMINISTRACION_CANCHA (Status_, NoCancha, Id_Juego)
    VALUES (@Status_, @NoCancha, @Id_Juego)
END
GO
--repiorte
create PROCEDURE SP_VIEW_REPORTE_PARTIDOS_AFECTADOS @Capacidad INT
AS BEGIN
    SELECT P.Id_Torneo,
        P.Id_Juego,  
        P.Id_EquipoLocal, 
        P.Id_EquipoVisita, 
        P.Fecha,
        p.HoraInicio,
        P.HoraFinal,
        P.jugado
    FROM TORNEO T INNER JOIN PARTIDO P 
    ON T.Id_Torneo = P.Id_Torneo
    INNER JOIN ADMINISTRACION_CANCHA AC
    ON NOT P.Id_Juego = AC.Id_Juego
    INNER JOIN CANCHA C
    ON AC.NoCancha = C.NoCancha
    WHERE T.NumeroMaximoDeJugadores = @Capacidad
	and p.jugado=0
    ORDER BY Id_Torneo;
END
GO


 
 
 --amonestacion 
 create proc Tarjetas @tar varchar(200), @multa varchar(200), @com varchar(200)
 as insert into AMONESTACION (ColorTarjeta,Valor_multa,Comentario) values (@tar,@multa,@com)

 create proc editarjeta  @tar varchar(200), @multa varchar(200), @com varchar(200)
 as update AMONESTACION set Valor_multa=@multa , Comentario=@com where ColorTarjeta=@tar

 create proc vertarjetas 
 as select * from AMONESTACION


 create proc vertarjeta @tar varchar(200)
 as select * from AMONESTACION where ColorTarjeta = @tar

 create proc dtltarjeta @tar varchar(200)
 as delete AMONESTACION where ColorTarjeta=@tar;

 ---


 create proc identificacionJugadores @id_juego int
as
select j.Identificacion from jugador j
where j.Identificacion =any
(
select pj.Identificacion from posicion_jugador pj
where Id_Equipo =any(select p.Id_EquipoLocal  from partido p 
where p.Id_Juego=@id_juego)
or Id_Equipo =any ( select p.Id_EquipoVisita  from partido p 
where p.Id_Juego=@id_juego)
)

exec identificacionJugadores @id_juego

--obtener nombre de jugador 

create proc nombre_jugador @identificacion int
as
select * from jugador where identificacion=@identificacion


create proc getCambio
as
select * from CAMBIO


create proc insertar_cambios @id_juego int,@DPIEntrada int, @DPISalida int,@tiempoEntrada varchar(200),@tiempoSalida varchar(200)
as
	insert into CAMBIO(Id_Juego,DPIJugadorEntra,DPIJugadorsale,Tiempo_entrada,Tiempo_salida)values(@id_juego,@DPIEntrada, @DPISalida,@tiempoEntrada,@tiempoSalida)

	--  CONTROL AMONESTACION

	CREATE PROCEDURE SP_INSERT_CONTROL_AMONESTACION @Id_Juego INT, @Id_Jugador INT, @Color_Tarjeta VARCHAR(200), @Tiempo VARCHAR(200)
AS BEGIN
    INSERT INTO REGISTRO_AMONESTACION (Id_Juego, Id_Jugador, Color_Tarjeta, Tiempo)
    VALUES (@Id_Juego, @Id_Jugador, @Color_Tarjeta, @Tiempo)
END
GO

CREATE PROCEDURE SP_VIEW_CONTROL_AMONESTACION @Id_Juego INT
AS BEGIN
    SELECT * FROM REGISTRO_AMONESTACION WHERE Id_Juego = @Id_Juego;
END
GO





-- nuevo 
--delete de puntos para actualizar marcador 


create proc dtl @id int 
as delete  PUNTEO where Id_Juego=@id;

 --- goles 
 
  create proc goles @jg int ,@dpi int ,@tipo varchar (200), @tiemp int
 as insert into Gol (id_juego,Identificacion,Tipo,Tiempo)  values ( @jg,@dpi,@tipo, @tiemp)
  

 go 
 drop proc vergoles  --se cambia el select de los datos el principal , el que trae la lista completa  , solo este se cambiara para traer oos datos de los nombres 
 go 
 create proc vergoles @id int
 as select g.Id_Gol , g.Id_Juego , g.Identificacion , j.Nombres + ' ' + j.Apellidos as Nombre , g.Tipo , g.Tiempo from gol  g , JUGADOR j where Id_Juego=@id  and g.Identificacion=j.Identificacion
 
-- delete de goles 

create proc dtlgoles @id int 
as delete GOL where Id_Juego=@id;


-- golid

create proc getgolbyid @id int 
as select * from gol where Id_Gol = @id

--golpudt
  create proc golesupd @id int ,@dpi int ,@tipo varchar (200), @tiemp int
 as update gol set Identificacion= @dpi , Tipo=@tipo , Tiempo =@tiemp WHERE Id_Gol=@id
  ----

  

create proc estadisticasportorneo @tr int 
as 

select   ROW_NUMBER() over(PARTITION by pr.Id_Torneo order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc ) as POS ,
 (select e.Nombre from EQUIPO e where e.Id_Equipo=pr.Id_EquipoLocal) as Nombres

from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join (select pr2.Id_EquipoVisita,   case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo= @tr

group by  pr2.Id_EquipoVisita
) as valor on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
where pr.Id_Torneo=  @tr
group by  pr.Id_EquipoLocal ,pr.Id_Torneo, valor.pts_visita

 go 
 -- si se selecciona equipo y torneo 
 

create proc estadisticasportorneoyqueipo @tr int , @name varchar(200)
as 
 

select pr.Id_Torneo,pos.POS,(select e.Nombre from EQUIPO e where e.Id_Equipo=pr.Id_EquipoVisita) as Nombres   from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join 
(
select  pr.Id_Torneo, pr.Id_EquipoLocal, ROW_NUMBER() over(PARTITION by pr.Id_Torneo order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc ) as POS 
 
from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join (select pr2.Id_EquipoVisita,   case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo= @tr

group by  pr2.Id_EquipoVisita
) as valor on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
where pr.Id_Torneo=  @tr
group by  pr.Id_EquipoLocal , pr.Id_Torneo, valor.pts_visita


)  as pos on pos.Id_EquipoLocal=pr.Id_EquipoVisita
where pr.Id_Torneo = @tr
and pr.Id_EquipoVisita = (select Id_Equipo from EQUIPO where Nombre=@name)
and pos.Id_Torneo=pr.Id_Torneo
group by pr.Id_EquipoVisita,pr.Id_Torneo,pos.POS

 
 
  go 


 

create proc estadisticaporquipo @name varchar(200)
as 


select pr.Id_Torneo,pos.POS,(select e.Nombre from EQUIPO e where e.Id_Equipo=pr.Id_EquipoVisita) as Nombres   from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join 
(
select  pr.Id_Torneo, pr.Id_EquipoLocal, ROW_NUMBER() over(PARTITION by pr.Id_Torneo order by sum(p.PunteoEquipoLocal)+valor.pts_visita desc ) as POS 
 
from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego join (select pr2.Id_EquipoVisita,   case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end as pts_visita  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=any(select  tq.Id_Torneo from EQUIPO e join TORNEO_EQUIPO tq on  e.Id_Equipo=tq.Id_Equipo
where e.Nombre= @name)

group by  pr2.Id_EquipoVisita
) as valor on  valor.Id_EquipoVisita = pr.Id_EquipoLocal
where pr.Id_Torneo= any(select  tq.Id_Torneo from EQUIPO e join TORNEO_EQUIPO tq on  e.Id_Equipo=tq.Id_Equipo
where e.Nombre= @name)
group by  pr.Id_EquipoLocal , pr.Id_Torneo, valor.pts_visita


)  as pos on pos.Id_EquipoLocal=pr.Id_EquipoVisita
where pr.Id_Torneo in (select  tq.Id_Torneo from EQUIPO e join TORNEO_EQUIPO tq on  e.Id_Equipo=tq.Id_Equipo
where e.Nombre= @name)
and pr.Id_EquipoVisita = (select Id_Equipo from EQUIPO where Nombre=@name)
and pos.Id_Torneo=pr.Id_Torneo
group by pr.Id_EquipoVisita,pr.Id_Torneo,pos.POS


go
 