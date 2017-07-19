USE [CampanhaBD]
GO

create table Usuario(
	[Id] [int] identity(1,1),
	[Nome] [varchar](max),
	[Email] [varchar](max),
	[Login] [varchar](max),
	[Senha] [varchar](max),
	CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Banco(
	[Codigo] [int],
	[Nome] [varchar](max),
	CONSTRAINT [PK_dbo.Banco] PRIMARY KEY CLUSTERED
	(
		[Codigo] ASC
	)
)
GO

create table Importacao(
	[Id] [int] identity(1,1),
	[UsuarioId] [int],
	[Nome] [varchar](max),
	[Data] [date],
	[Terminado] [bit],
	[NumImportados] [int],
	[NumAtualizados] [int],
	[CaminhoArquivo] [varchar](max),
	CONSTRAINT [PK_dbo.Importacao] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Cliente(
	[Id] [bigint] identity(1,1),
	[ImportacaoId] [int],
	[Nome] [varchar](max),
	[Cpf] [nvarchar](15) UNIQUE NONCLUSTERED,
	[Uf] [varchar](3),
	[Cidade] [varchar](max),
	[Bairro] [varchar](max),
	[Ddd] [varchar](3),
	[Telefone] [nvarchar](16),
	[DataNascimento] [date],
	[Logradouro] [varchar](max),
	[Numero] [varchar](7),
	[Complemento] [varchar](max),
	[Cep] [varchar](11),
	[DataImportado] [datetime],
	[DataTelAtualizado] [datetime],
	[DataEmpAtualizados] [datetime],
	[DataTrabalhado] [datetime],
	CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Beneficio(
	[Numero] [bigint],
	[ClienteId] [bigint],
	[Salario] [float],
	[DataCompetencia] [date],
	CONSTRAINT [PK_dbo.Beneficio] PRIMARY KEY CLUSTERED
	(
		[Numero] ASC
	)
)
GO

create table Emprestimo(
	[BancoId] [int],
	[ClienteId] [bigint],
	[NumBeneficio] [bigint],
	[NumEmprestimo] [int],
	[ValorParcela] [float],
	[ParcelasNoContrato] [int],
	[ParcelasEmAberto] [int],
	[Saldo] [float],
	[InicioPagamento] [date],
	CONSTRAINT [PK_dbo.Emprestimo] PRIMARY KEY CLUSTERED
	(
		[ClienteId] ASC,
		[NumBeneficio] ASC,
		[NumEmprestimo] ASC
	)
)
GO

create table Campanha(
	[Id] [int] identity(1,1),
	[UsuarioId] [int],
	[Nome] [varchar](max),
	[MinParcela] [float],
	[MaxParcela] [float],
	[MinInicioPag] [varchar](10),
	[MaxInicioPag] [varchar](10),
	[MinParcelasPagas] [int],
	[MaxParcelasPagas] [int],
	[MinDataNascimento] [date],
	[ApenasNaoExportados] [bit],
	[ApenasComTelefone] [bit],
	[ApenasNaoTrabalhados] [bit],
	[MinCep] [varchar](11),
	[MaxCep] [varchar](11),
	[CodigoBanco] [int],
	CONSTRAINT [PK_dbo.Camapanha] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table CampanhaImportacao(
	[UsuarioId] [int],
	[ImportacaoId] [int],
	[CampanhaId] [int],
	CONSTRAINT [PK_dbo.CampanhaImportacao] PRIMARY KEY CLUSTERED
	(
		[UsuarioId] ASC,
		[ImportacaoId] ASC,
		[CampanhaId] ASC
	)
)
GO

--Definindo Chaves Estrangeiras
--===========================================================

--Tabela Cliente
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cliente_dbo.Importacao_ImportacaoId] FOREIGN KEY([ImportacaoId])
REFERENCES [dbo].[Importacao] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_dbo.Cliente_dbo.Importacao_ImportacaoId]
GO


--Tabela Emprestimo
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Emprestimo_dbo.Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_dbo.Emprestimo_dbo.Cliente_ClienteId]
GO

ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Emprestimo_dbo.Beneficio_BeneficioId] FOREIGN KEY(NumBeneficio)
REFERENCES [dbo].[Beneficio] ([Numero])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_dbo.Emprestimo_dbo.Beneficio_BeneficioId]
GO

--Tabela Beneficio
ALTER TABLE [dbo].[Beneficio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Beneficio_dbo.Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Beneficio] CHECK CONSTRAINT [FK_dbo.Beneficio_dbo.Cliente_ClienteId]
GO

--Tabela Importacao
ALTER TABLE [dbo].[Importacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Importacao_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Importacao] CHECK CONSTRAINT [FK_dbo.Importacao_dbo.Usuario_UsuarioId]
GO

--Tabela Campanha
ALTER TABLE [dbo].[Campanha]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Campanha_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Campanha] CHECK CONSTRAINT [FK_dbo.Campanha_dbo.Usuario_UsuarioId]
GO

--Tabela CampanhaImportacao
ALTER TABLE [dbo].[CampanhaImportacao]  WITH CHECK ADD CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Campanha_CampanhaId] FOREIGN KEY([CampanhaId])
REFERENCES [dbo].[Campanha] ([Id])
GO
ALTER TABLE [dbo].[CampanhaImportacao] CHECK CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Campanha_CampanhaId]
GO

ALTER TABLE [dbo].[CampanhaImportacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Importacao_ImportacaoId] FOREIGN KEY([ImportacaoId])
REFERENCES [dbo].[Importacao] ([Id])
GO
ALTER TABLE [dbo].[CampanhaImportacao] CHECK CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Importacao_ImportacaoId]
GO

ALTER TABLE [dbo].[CampanhaImportacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[CampanhaImportacao] CHECK CONSTRAINT [FK_dbo.CampanhaImportacao_dbo.Usuario_UsuarioId]
GO