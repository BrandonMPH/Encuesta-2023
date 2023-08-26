USE [SistemaEncuesta]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 26/08/2023 17:29:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdEncusta] [int] NULL,
	[NombreCampo] [varchar](100) NULL,
	[Titulo] [varchar](500) NULL,
	[EsRequerido] [varchar](1) NULL,
	[TipoCampo] [varchar](100) NULL,
	[TipoCampoValor] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encuesta]    Script Date: 26/08/2023 17:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encuesta](
	[IdEncusta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombre] [varchar](200) NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEncusta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 26/08/2023 17:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[IdEncuesta] [int] NULL,
	[IdDetalle] [int] NULL,
	[Valor] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/08/2023 17:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](100) NULL,
	[Correo] [varchar](100) NULL,
	[Clave] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Detalle] ON 
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (5, 5, N'Nombre', N'Nombre', N'S', N'T', N'text')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (6, 5, N'Edad', N'Edad', N'S', N'D', N'date')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (8, 7, N'Nombre', N'Apellido', N'S', N'T', N'text')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (9, 7, N'Apellido', N'Apellido', N'S', N'T', N'text')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (10, 7, N'Edad', N'Edad', N'S', N'N', N'number')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (11, 7, N'Fecha de nacimiento', N'Fecha de nacimiento', N'S', N'D', N'date')
GO
INSERT [dbo].[Detalle] ([IdDetalle], [IdEncusta], [NombreCampo], [Titulo], [EsRequerido], [TipoCampo], [TipoCampoValor]) VALUES (12, 8, N'Nombre', N'Nombre', N'S', N'T', N'text')
GO
SET IDENTITY_INSERT [dbo].[Detalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Encuesta] ON 
GO
INSERT [dbo].[Encuesta] ([IdEncusta], [IdUsuario], [Nombre], [Descripcion]) VALUES (5, 1, N'Elecciones', N'Encuesta de elecciones 2023')
GO
INSERT [dbo].[Encuesta] ([IdEncusta], [IdUsuario], [Nombre], [Descripcion]) VALUES (6, 1, N'Elecciones', N'Esta encuesta servira para ver quienes tiene usuarios web')
GO
INSERT [dbo].[Encuesta] ([IdEncusta], [IdUsuario], [Nombre], [Descripcion]) VALUES (7, 1, N'Usuario Web', N'Esta encuesta servira para ver quienes tiene usuarios web')
GO
INSERT [dbo].[Encuesta] ([IdEncusta], [IdUsuario], [Nombre], [Descripcion]) VALUES (8, 1, N'Usuario Web', N'Esta encuesta servira para ver quienes tiene usuarios web')
GO
SET IDENTITY_INSERT [dbo].[Encuesta] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuesta] ON 
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (2, 5, 5, N'brandiob')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (3, 5, 5, N'brandiob')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (4, 5, 5, N'asdfs')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (5, 5, 5, N'asdfs')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (6, 5, 5, N'asdfadf')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (7, 5, 6, N'2023-08-26')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (8, 5, 5, N'bradnin')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (9, 5, 6, N'2023-08-26')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (10, 5, 5, N'bradnin')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (11, 5, 6, N'2023-08-26')
GO
INSERT [dbo].[Respuesta] ([IdRespuesta], [IdEncuesta], [IdDetalle], [Valor]) VALUES (13, 8, 12, N'Brandon')
GO
SET IDENTITY_INSERT [dbo].[Respuesta] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Correo], [Clave]) VALUES (1, N'Admin', N'Admin@gmail.com', N'156058203c94d309c185ed67810cbde67f9cacf15ad0e134c1720fd0efc66a6c')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_EncuestaDetalle]    Script Date: 26/08/2023 17:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EncuestaDetalle](
@NumConsulta int = Null,
@IdEncuesta int = Null,
@IdDetalle int = Null,
@NombreCampo varchar(500) = Null,
@Titulo varchar(500) = Null,
@EsRequerido varchar(1) = Null,
@TipoCampo varchar(500) = Null,
@TipoCampoValor varchar(500) = Null,
@Creado bit = Null output,
@Mensaje varchar(100) = Null output
)
AS 
BEGIN 
	IF(@NumConsulta = 1)
	BEGIN
		INSERT INTO Detalle(IdEncusta, NombreCampo, Titulo, EsRequerido, TipoCampo, TipoCampoValor) VALUES (@IdEncuesta, @NombreCampo, @Titulo, @EsRequerido, @TipoCampo, @TipoCampoValor)
		SET @Creado = 1;
		SET @Mensaje = 'Detalle de encuesta creado existosamente'
	END

	IF(@NumConsulta = 2)
	BEGIN
		SELECT IdDetalle, IdEncusta, NombreCampo, Titulo, EsRequerido, TipoCampo, TipoCampoValor FROM Detalle Where IdEncusta = @IdEncuesta
	END

	IF(@NumConsulta = 3)
	BEGIN
		UPDATE Detalle SET NombreCampo = @NombreCampo, Titulo = @Titulo, EsRequerido = @EsRequerido, TipoCampo = @TipoCampo, TipoCampoValor = @TipoCampoValor WHERE IdDetalle = @IdDetalle;
		SET @Creado = 1;
		SET @Mensaje = 'Detalle actualizado existosamente'
	END

	IF(@NumConsulta = 4)
	BEGIN
		DELETE FROM Detalle WHERE IdDetalle = @IdDetalle;
		SET @Creado = 1;
		SET @Mensaje = 'Detalle Eliminado existosamente'
	END

	IF(@NumConsulta = 5)
	BEGIN
		DELETE FROM Encuesta WHERE IdEncusta = @IdEncuesta;
		DELETE FROM Detalle WHERE IdEncusta = @IdEncuesta;
		DELETE FROM Respuesta WHERE IdEncuesta = @IdEncuesta;
		SET @Creado = 1;
		SET @Mensaje = 'Encuesta Eliminada existosamente'
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_EncuestaEncabezado]    Script Date: 26/08/2023 17:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EncuestaEncabezado](
@IdUsuario int = NULL,
@NumConsulta int,
@Nombre varchar(500)= NULL,
@Descripcion varchar(500)= NULL,
@Encuesta int = Null,
@Creado bit = NULL output ,
@IdEncuesta int = NULL output,
@Mensaje varchar(100) = NULL output
)
AS 
BEGIN 
	IF(@NumConsulta = 1)
	BEGIN
		INSERT INTO Encuesta(IdUsuario, Nombre, Descripcion) VALUES (@IdUsuario, @Nombre, @Descripcion)
		SET @Creado = 1;
		SET @IdEncuesta = SCOPE_IDENTITY();
		SET @Mensaje = 'El usuario se creo correctamente'
	END

	IF(@NumConsulta = 2)
	BEGIN
		SELECT IdEncusta, IdUsuario, Nombre, Descripcion FROM Encuesta
	END

	IF(@NumConsulta = 3)
	BEGIN
		IF(EXISTS(SELECT * FROM Encuesta WHERE IdEncusta = @Encuesta AND Nombre = @Nombre))
			SELECT IdEncusta FROM Encuesta WHERE IdEncusta = @Encuesta AND Nombre = @Nombre
		ELSE 
			SELECT '0'
	END


END
GO
/****** Object:  StoredProcedure [dbo].[SP_EncuestaRespuesta]    Script Date: 26/08/2023 17:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EncuestaRespuesta](
@NumConsulta int = Null,
@IdEncuesta int = Null,
@IdDetalle int = Null,
@Valor varchar(500) = Null,
@Creado bit = Null output,
@Mensaje varchar(100) = Null output
)
AS 
BEGIN 
	IF(@NumConsulta = 1)
	BEGIN
	INSERT INTO Respuesta(IdEncuesta, IdDetalle, Valor) VALUES (@IdEncuesta, @IdDetalle, @Valor)
	SET @Creado = 1;
	SET @Mensaje = 'Respuesta creada existosamente'
	END

	IF(@NumConsulta = 2)
	BEGIN
	SELECT T0.Titulo, T1.Valor FROM Detalle T0 INNER JOIN RESPUESTA T1 ON T1.IDDETALLE = T0.IDDETALLE WHERE T0.IdEncusta = @IdEncuesta
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistroUsuario]    Script Date: 26/08/2023 17:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistroUsuario](
@Usuario varchar(100),
@Correo varchar(100),
@Clave varchar(500),
@Registrado bit output,
@Mensaje varchar(100) output
)
AS 
BEGIN 
	IF(NOT EXISTS(SELECT * FROM Usuario WHERE NombreUsuario = @Usuario))
	BEGIN
		INSERT INTO Usuario	(NombreUsuario, Correo, Clave) VALUES (@Usuario, @Correo, @Clave)
		SET @Registrado = 1
		SET @Mensaje = 'El usuario se creo correctamente'
	END
	ELSE 
	BEGIN 
		SET @Registrado = 0
		SET @Mensaje = 'El usuario ya existe en el sistema'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ValidarUsuario]    Script Date: 26/08/2023 17:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ValidarUsuario](
@Usuario varchar(100),
@Clave varchar(500)
)
AS 
BEGIN 
	IF(EXISTS(SELECT * FROM Usuario WHERE NombreUsuario = @Usuario AND Clave = @Clave))
		SELECT IdUsuario FROM Usuario WHERE NombreUsuario = @Usuario AND Clave = @Clave 
	ELSE 
		SELECT '0'
END
GO
