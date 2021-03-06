USE [animewolf]
GO
/****** Object:  StoredProcedure [dbo].[listarAnimes]    Script Date: 20/09/2017 19:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listarAnimes]
AS
BEGIN 
	SELECT a.idanime, a.nombre, a.sinopsis, a.idgenero, g.nombre AS genero 
	FROM anime a INNER JOIN genero g
	ON a.idgenero = g.idgenero;	
END
GO
/****** Object:  StoredProcedure [dbo].[registrarAnime]    Script Date: 20/09/2017 19:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[registrarAnime]
@nombre varchar(50),
@sinopsis varchar(MAX),
@estado tinyint,
@idgenero int,
@parametro1 int out,
@parametro2 varchar(100) out
AS
BEGIN
	
	INSERT INTO anime(nombre, sinopsis, estado, idgenero) 
	VALUES(@nombre, @sinopsis, @estado, @idgenero);

	SET @parametro1 = 1024;
	SET @parametro2 = 'Soy un parámetro de salida';
	
	SELECT @parametro1, @parametro2;	
END


GO
/****** Object:  StoredProcedure [dbo].[verificarUsuario]    Script Date: 20/09/2017 19:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[verificarUsuario]
@usuario varchar(50),
@password varchar(50)
AS
BEGIN 
	SELECT * FROM usuario
	WHERE usuario = @usuario AND password = @password;
END
GO
/****** Object:  Table [dbo].[anime]    Script Date: 20/09/2017 19:03:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[anime](
	[idanime] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[sinopsis] [varchar](max) NULL,
	[estado] [tinyint] NULL,
	[idgenero] [int] NULL,
 CONSTRAINT [PK_anime] PRIMARY KEY CLUSTERED 
(
	[idanime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[episodio]    Script Date: 20/09/2017 19:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[episodio](
	[idepisodio] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](50) NULL,
	[urlvideo] [varchar](max) NULL,
	[idanime] [int] NULL,
 CONSTRAINT [PK_episodio] PRIMARY KEY CLUSTERED 
(
	[idepisodio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[genero]    Script Date: 20/09/2017 19:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[genero](
	[idgenero] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
 CONSTRAINT [PK_genero] PRIMARY KEY CLUSTERED 
(
	[idgenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 20/09/2017 19:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[anime] ON 

INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (1, N'Death Note', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 1)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (2, N'Dragon Ball Super', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 2)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (3, N'Naruto', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 2)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (4, N'Hunter x Hunter', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 3)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (5, N'One Piece', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 3)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (6, N'Yu Yu Hakusho', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus quod quas illum. Sunt, voluptatem, sit! Itaque inventore perferendis architecto quas libero, quasi eos animi iusto tenetur porro quae hic dolores.', 1, 2)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (7, N'Caballeros del Zoadico', N'Lorem', 1, 3)
INSERT [dbo].[anime] ([idanime], [nombre], [sinopsis], [estado], [idgenero]) VALUES (8, N'Code Breaker', N'Lorem', 1, 3)
SET IDENTITY_INSERT [dbo].[anime] OFF
SET IDENTITY_INSERT [dbo].[episodio] ON 

INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (1, N'1', NULL, 1)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (2, N'2', NULL, 1)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (3, N'3', NULL, 1)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (4, N'4', NULL, 1)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (5, N'5', NULL, 1)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (6, N'1', NULL, 2)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (7, N'2', NULL, 2)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (8, N'3', NULL, 2)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (9, N'4', NULL, 2)
INSERT [dbo].[episodio] ([idepisodio], [numero], [urlvideo], [idanime]) VALUES (10, N'5', NULL, 2)
SET IDENTITY_INSERT [dbo].[episodio] OFF
SET IDENTITY_INSERT [dbo].[genero] ON 

INSERT [dbo].[genero] ([idgenero], [nombre]) VALUES (1, N'Psicológico')
INSERT [dbo].[genero] ([idgenero], [nombre]) VALUES (2, N'Artes Marciales')
INSERT [dbo].[genero] ([idgenero], [nombre]) VALUES (3, N'Aventura')
SET IDENTITY_INSERT [dbo].[genero] OFF
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idusuario], [usuario], [password]) VALUES (1, N'geo', N'123')
INSERT [dbo].[usuario] ([idusuario], [usuario], [password]) VALUES (2, N'pet', N'123')
INSERT [dbo].[usuario] ([idusuario], [usuario], [password]) VALUES (3, N'jose', N'123')
INSERT [dbo].[usuario] ([idusuario], [usuario], [password]) VALUES (4, N'carlos', N'123')
SET IDENTITY_INSERT [dbo].[usuario] OFF
