USE [master]
GO
/****** Object:  Database [Norne]    Script Date: 26/06/2016 03:30:53 ******/
CREATE DATABASE [Norne]
GO
ALTER DATABASE [Norne] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Norne].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
USE [Norne]
GO
/****** Object:  Table [dbo].[Agencia]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agencia](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cep] [varchar](8) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Estado] [varchar](2) NOT NULL,
	[Telefone] [varchar](10) NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Agencia] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conta]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conta](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CorrentistaTitular_Codigo] [int] NOT NULL,
	[Agencia_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Conta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContaCorrente]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContaCorrente](
	[Codigo] [int] NOT NULL,
	[StatusConta_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_ContaCorrente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContaCorrentistaDependente]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContaCorrentistaDependente](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Conta_Codigo] [int] NOT NULL,
	[Correntista_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_ContaCorrentistaDependente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContaPoupanca]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContaPoupanca](
	[Codigo] [int] NOT NULL,
	[StatusConta_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_ContaPoupanca] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Correntista]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Correntista](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[Rg] [varchar](14) NOT NULL,
	[Nacionalidade] [varchar](50) NOT NULL,
	[Naturalidade] [varchar](50) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Correntista] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionario](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[Matricula] [varchar](20) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Papel]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Papel](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Papel] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PapelFuncionario]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PapelFuncionario](
	[Papel_Codigo] [int] NOT NULL,
	[Funcionario_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_PapelFuncionario] PRIMARY KEY CLUSTERED 
(
	[Papel_Codigo] ASC,
	[Funcionario_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusConta]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusConta](
	[Codigo] [int] NOT NULL,
	[Descricao] [varchar](25) NOT NULL,
 CONSTRAINT [PK_StatusConta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoConta]    Script Date: 26/06/2016 03:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoConta](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Variacao] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Agencia] FOREIGN KEY([Agencia_Codigo])
REFERENCES [dbo].[Agencia] ([Codigo])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Agencia]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Correntista] FOREIGN KEY([CorrentistaTitular_Codigo])
REFERENCES [dbo].[Correntista] ([Codigo])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Correntista]
GO
ALTER TABLE [dbo].[ContaCorrente]  WITH CHECK ADD  CONSTRAINT [FK_ContaCorrente_Conta] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Conta] ([Codigo])
GO
ALTER TABLE [dbo].[ContaCorrente] CHECK CONSTRAINT [FK_ContaCorrente_Conta]
GO
ALTER TABLE [dbo].[ContaCorrente]  WITH CHECK ADD  CONSTRAINT [FK_ContaCorrente_StatusConta] FOREIGN KEY([StatusConta_Codigo])
REFERENCES [dbo].[StatusConta] ([Codigo])
GO
ALTER TABLE [dbo].[ContaCorrente] CHECK CONSTRAINT [FK_ContaCorrente_StatusConta]
GO
ALTER TABLE [dbo].[ContaCorrentistaDependente]  WITH CHECK ADD  CONSTRAINT [FK_ContaCorrentistaDependente_Conta] FOREIGN KEY([Conta_Codigo])
REFERENCES [dbo].[Conta] ([Codigo])
GO
ALTER TABLE [dbo].[ContaCorrentistaDependente] CHECK CONSTRAINT [FK_ContaCorrentistaDependente_Conta]
GO
ALTER TABLE [dbo].[ContaCorrentistaDependente]  WITH CHECK ADD  CONSTRAINT [FK_ContaCorrentistaDependente_Correntista] FOREIGN KEY([Correntista_Codigo])
REFERENCES [dbo].[Correntista] ([Codigo])
GO
ALTER TABLE [dbo].[ContaCorrentistaDependente] CHECK CONSTRAINT [FK_ContaCorrentistaDependente_Correntista]
GO
ALTER TABLE [dbo].[ContaPoupanca]  WITH CHECK ADD  CONSTRAINT [FK_ContaPoupanca_Conta] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Conta] ([Codigo])
GO
ALTER TABLE [dbo].[ContaPoupanca] CHECK CONSTRAINT [FK_ContaPoupanca_Conta]
GO
ALTER TABLE [dbo].[ContaPoupanca]  WITH CHECK ADD  CONSTRAINT [FK_ContaPoupanca_Status] FOREIGN KEY([StatusConta_Codigo])
REFERENCES [dbo].[StatusConta] ([Codigo])
GO
ALTER TABLE [dbo].[ContaPoupanca] CHECK CONSTRAINT [FK_ContaPoupanca_Status]
GO
ALTER TABLE [dbo].[PapelFuncionario]  WITH CHECK ADD  CONSTRAINT [FK_PapelFuncionario_Funcionario] FOREIGN KEY([Funcionario_Codigo])
REFERENCES [dbo].[Funcionario] ([Codigo])
GO
ALTER TABLE [dbo].[PapelFuncionario] CHECK CONSTRAINT [FK_PapelFuncionario_Funcionario]
GO
ALTER TABLE [dbo].[PapelFuncionario]  WITH CHECK ADD  CONSTRAINT [FK_PapelFuncionario_Papel] FOREIGN KEY([Papel_Codigo])
REFERENCES [dbo].[Papel] ([Codigo])
GO
ALTER TABLE [dbo].[PapelFuncionario] CHECK CONSTRAINT [FK_PapelFuncionario_Papel]
GO
USE [master]
GO
ALTER DATABASE [Norne] SET  READ_WRITE 
GO
