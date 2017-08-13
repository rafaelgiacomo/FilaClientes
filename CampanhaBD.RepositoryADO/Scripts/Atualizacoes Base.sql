USE CampanhaBD;
GO

ALTER TABLE [Beneficio] ADD [DataInicioBeneficio] [date] NULL, [BancoPagamento] [int] NULL, [AgenciaPagamento] [int] NULL, 
	[OrgaoPagador] [int] NULL, [ContaCorrente] [nvarchar](20) NULL, [DataIncluidoInss] [date] NULL, [DataExcluidoInss] [date] NULL
GO

ALTER TABLE [Emprestimo] ADD [ValorBruto] [float] NULL, [FimPagamento] [date] NULL, [TipoEmprestimo] [int] NULL, [SituacaoEmprestimo] [int] NULL
GO

ALTER TABLE [Cliente] ADD [Ddd2] [varchar](3) NULL, [Telefone2] [varchar](16) NULL
GO