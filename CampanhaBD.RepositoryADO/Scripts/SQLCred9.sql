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
	[Id] [bigint],
	[ImportacaoId] [int],
	[Nome] [varchar](max),
	[Cpf] [nvarchar](15) UNIQUE NONCLUSTERED,
	[Uf] [varchar](3),
	[Cidade] [varchar](max),
	[Bairro] [varchar](max),
	[Ddd] [varchar](3),
	[Telefone] [nvarchar](16),
	[Ddd2] [varchar](3),
	[Telefone2] [nvarchar](16),
	[DataNascimento] [date],
	[Logradouro] [varchar](max),
	[Numero] [varchar](7),
	[Complemento] [varchar](max),
	[Cep] [varchar](11),
	[DataExpProcessa] [datetime],
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
	[DataInicioBeneficio] [date],
	[BancoPagamento] [int],
	[AgenciaPagamento] [int],
	[OrgaoPagador] [int],
	[ContaCorrente] [nvarchar](20),
	[DataIncluidoInss] [date],
	[DataExcluidoInss] [date],
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
	[ValorBruto] [float],
	[ParcelasNoContrato] [int],
	[ParcelasEmAberto] [int],
	[Saldo] [float],
	[InicioPagamento] [date],
	[FimPagamento] [date],
	[TipoEmprestimo] [int],
	[SituacaoEmprestimo] [int],
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

CREATE TABLE BaseOriginal
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Descricao] nvarchar(255) NULL,
	CONSTRAINT [PK_dbo.BaseOriginal] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

CREATE TABLE BaseOriginalDados
(
	[Id] bigint NOT NULL IDENTITY (1, 1),
	[BaseId] int NULL,
	[NumBeneficio] nvarchar(255) NULL,
	[Nome] nvarchar(255) NULL,
	[DataNascimento] nvarchar(255) NULL,
	[Cpf] nvarchar(255) NULL,
	[Especie] nvarchar(255) NULL,
	[DataInicioBeneficio] nvarchar(255) NULL,
	[ValorBeneficio] money NULL,
	[BancoPagamento] nvarchar(255) NULL,
	[AgenciaPagamento] nvarchar(255) NULL,
	[OrgaoPagador] nvarchar(255) NULL,
	[ContaCorrente] nvarchar(255) NULL,
	[Ddd] nvarchar(255) NULL,
	[Telefone] nvarchar(255) NULL,
	[aps-benef] nvarchar(255) NULL,
	[cs-meio-pagto] nvarchar(255) NULL,
	[BancoEmprestimo] nvarchar(255) NULL,
	[ContratoEmprestimo] nvarchar(255) NULL,
	[ValorEmprestimo] money NULL,
	[DataInicioPagamento] nvarchar(255) NULL,
	[DataFimPagamento] nvarchar(255) NULL,
	[ParcelasNoContrato] nvarchar(255) NULL,
	[ValorParcela] money NULL,
	[TipoEmprestimo] nvarchar(255) NULL,
	[Endereco] nvarchar(255) NULL,
	[Bairro] nvarchar(255) NULL,
	[Municipio] nvarchar(255) NULL,
	[Uf] nvarchar(255) NULL,
	[Cep] nvarchar(255) NULL,
	[SituacaoEmprestimo] nvarchar(255) NULL,
	[DataIncluidoINSS] nvarchar(255) NULL,
	[DataExcluidoINSS] nvarchar(255) NULL,
	[DataImportado] date NULL,
	[ResultadoImportacao] int null,
	[MsgLogImportacao] nvarchar(max) NULL,
	CONSTRAINT [PK_dbo.BaseOriginalDados] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

--Definindo Chaves Estrangeiras
--===========================================================

--Tabela BaseOriginalDados
ALTER TABLE [dbo].[BaseOriginalDados]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BaseOriginalDados_dbo.BaseOriginal_BaseId] FOREIGN KEY([BaseId])
REFERENCES [dbo].[BaseOriginal] ([Id])
GO
ALTER TABLE [dbo].[BaseOriginalDados] CHECK CONSTRAINT [FK_dbo.BaseOriginalDados_dbo.BaseOriginal_BaseId]
GO

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

/****** Criação de Indices ******/

CREATE NONCLUSTERED INDEX [IX_CpfCliente] ON [dbo].[Cliente]
(
	[Cpf] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Data_Atualizacao_Emp] ON [dbo].[Cliente]
(
	[DataEmpAtualizados] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Data_Atualizacao_Tel] ON [dbo].[Cliente]
(
	[DataTelAtualizado] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Data_Trabalhado] ON [dbo].[Cliente]
(
	[DataTrabalhado] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Data_Exp_Processa] ON [dbo].[Cliente]
(
	[DataExpProcessa] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Valor_Parcela] ON [dbo].[Emprestimo]
(
	[ValorParcela] ASC
) 
GO

CREATE NONCLUSTERED INDEX [IX_ParcelasEmAberto] ON [dbo].[Emprestimo]
(
	[ParcelasEmAberto] ASC
) 
GO

CREATE NONCLUSTERED INDEX [IX_CodigoBanco_BaseOriginalDados] ON [dbo].[BaseOriginalDados]
(
	[BancoEmprestimo] ASC
) 
GO

CREATE NONCLUSTERED INDEX [IX_TipoEmprestimo_BaseOriginalDados] ON [dbo].[BaseOriginalDados]
(
	[TipoEmprestimo] ASC
) 
GO

