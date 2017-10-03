USE [CampanhaBD]
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS OFF
GO

--====================================================== PROCEDURES TABELA BASE ORIGINAL =======================================================================

--Listar Bases Originais
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODAS_BASES]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODAS_BASES]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODAS_BASES]
AS
BEGIN
	SELECT [Id], [Descricao] FROM [BaseOriginal]
END
GO

--Listar Clientes por Base
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_CLIENTES_BASE_ORIGINAL]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_CLIENTES_BASE_ORIGINAL]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_CLIENTES_BASE_ORIGINAL]
	@BaseId int
AS
BEGIN
	SELECT * FROM [BaseOriginalDados] WHERE [BaseId] = @BaseId
END
GO

--====================================================== PROCEDURES TABELA USUARIO =======================================================================

--Salvar Usuario
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_USUARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_USUARIO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_USUARIO]
	@Nome varchar(max),
	@Email varchar(max),
	@Login varchar(max),
	@Senha varchar(max)
AS
BEGIN
	INSERT INTO [Usuario] ([Nome], [Email], [Login], [Senha])
	VALUES (@Nome, @Email, @Login, @Senha)
END
GO

--Alterar Usuario
--===============================================


--Listar Todos Usuarios
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODOS_USUARIOS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODOS_USUARIOS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODOS_USUARIOS]
AS
BEGIN
	SELECT [Id], [Nome], [Email], [Login], [Senha] FROM [Usuario]
END
GO

--Selecionar por Id Usuario
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_USUARIO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_USUARIO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_USUARIO_ID]
	@Id int
AS
BEGIN
	SELECT [Nome], [Email], [Login], [Senha] FROM [Usuario] WHERE [Id] = @Id
END
GO

--Excluir Usuario
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_USUARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_USUARIO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_USUARIO]
	@Id int
AS
BEGIN
	DELETE FROM [Usuario] WHERE [Id] = @Id
END
GO

--====================================================== PROCEDURES TABELA BANCO =======================================================================

--Salvar Banco
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_BANCO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_BANCO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_BANCO]
	@Codigo int,
	@Nome varchar(max)
AS
BEGIN
	INSERT INTO [Banco] ([Codigo], [Nome])
	VALUES (@Codigo, @Nome)
END
GO

--Alterar Banco
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ALTERAR_BANCO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ALTERAR_BANCO]
GO

CREATE PROCEDURE [DBO].[SP_ALTERAR_BANCO]
	@Codigo int,
	@Nome varchar(max)
AS
BEGIN
	UPDATE [Banco] SET [Codigo] = @Codigo, [Nome] = @Nome WHERE [Codigo] = @Codigo
END
GO

--Listar Todos Bancos
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODOS_BANCOS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODOS_BANCOS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODOS_BANCOS]
AS
BEGIN
	SELECT [Codigo], [Nome] FROM [Banco]
END
GO

--Selecionar por Id Banco
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_BANCO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_BANCO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_BANCO_ID]
	@Codigo int
AS
BEGIN
	SELECT [Codigo], [Nome] FROM [Banco] WHERE [Codigo] = @Codigo
END
GO

--Excluir Banco
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_BANCO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_BANCO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_BANCO]
	@Codigo int
AS
BEGIN
	DELETE FROM [Banco] WHERE [Codigo] = @Codigo
END
GO

--Salvar Cliente
--===================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_CLIENTE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_CLIENTE]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_CLIENTE]
	@ImportacaoId int,
	@Nome varchar(max),
	@Cpf varchar(max),
	@Uf varchar(3) = null,
	@Cidade varchar(max) = null,
	@Bairro varchar(max) = null,
	@Ddd varchar(3) = null,
	@Telefone varchar(max) = null,
	@Ddd2 varchar(3) = null,
	@Telefone2 varchar(max) = null,
	@DataNascimento datetime = null,
	@Logradouro varchar(max) = null,
	@Numero varchar(7) = null,
	@Complemento varchar(max) = null,
	@Cep varchar(11) = null,
	@Ativado bit
AS
BEGIN
	INSERT INTO [Cliente] ([ImportacaoId], [Nome], [Cpf], [Uf], [Cidade], [Bairro], [Ddd], [Telefone], [Ddd2], [Telefone2], [DataNascimento], [Logradouro], [Numero], [Complemento], [Cep],
		[DataImportado], [Ativado])
	VALUES (@ImportacaoId, @Nome, @Cpf, @Uf, @Cidade, @Bairro, @Ddd, @Telefone, @Ddd2, @Telefone2, @DataNascimento, @Logradouro, @Numero, @Complemento, @Cep, 
		CONVERT(date, GETDATE()), @Ativado)

	DECLARE @ULTIMO_ID INT
	 
	SET @ULTIMO_ID = Scope_identity()

	SELECT @ULTIMO_ID
END
GO

--Atualizar Ativado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_ATIVADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_ATIVADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_ATIVADO]
	@Id bigint,
	@Ativado bit
AS
BEGIN
	UPDATE [Cliente] SET [Ativado] = @Ativado
END
GO

--Atualizar DataExpProcessa
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]
	@Id bigint
AS
BEGIN
	UPDATE [Cliente] SET [DataExpProcessa] = CONVERT(date, GETDATE()) WHERE [Id] = @Id
END
GO

--Atualizar DataEmpAtualizado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]
	@Id bigint
AS
BEGIN
	UPDATE [Cliente] SET [DataEmpAtualizados] = CONVERT(date, GETDATE()) WHERE [Id] = @Id
END
GO

--Atualizar DataEmpAtualizado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EXP_PROCESSA]
	@Id bigint
AS
BEGIN
	UPDATE [Cliente] SET [DataExpProcessa] = CONVERT(date, GETDATE()) WHERE [Id] = @Id
END
GO

--Atualizar DataTrabalhado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_TRABALHADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TRABALHADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TRABALHADO]
	@Id bigint
AS
BEGIN
	UPDATE [Cliente] SET [DataTrabalhado] = CONVERT(date, GETDATE()) WHERE [Id] = @Id
END
GO

--Atualizar DataTelefone
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_TEL_ATUALIZADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TEL_ATUALIZADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TEL_ATUALIZADO]
	@Id bigint,
	@DataTelAtualizado datetime
AS
BEGIN
	UPDATE [Cliente] SET [DataTelAtualizado] = @DataTelAtualizado WHERE [Id] = @Id
END
GO

--Listar Todos Clientes por Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_CLIENTES_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_CLIENTES_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_CLIENTES_IMPORTACAO]
	@ImportacaoId int
AS
BEGIN
	SELECT * FROM [Cliente] where [ImportacaoId] = @ImportacaoId
END
GO

--Selecionar Cliente por Id
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_CLIENTE_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_CLIENTE_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_CLIENTE_ID]
	@Id bigint
AS
BEGIN
	SELECT * FROM [Cliente] where [Id] = @Id
END
GO

--Selecionar Cliente por CPF
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_CLIENTE_CPF]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_CLIENTE_CPF]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_CLIENTE_CPF]
	@Cpf varchar(15)
AS
BEGIN
	SELECT * FROM [Cliente] where [Cpf] = @Cpf
END
GO

--Selecionar Id do Cliente por CPF
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_ID_CLIENTE_CPF]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_ID_CLIENTE_CPF]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_ID_CLIENTE_CPF]
	@Cpf varchar(15)
AS
BEGIN
	SELECT [Id] FROM [Cliente] where [Cpf] = @Cpf
END
GO

--Excluir Cliente
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_BANCO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_BANCO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_BANCO]
	@Id bigint
AS
BEGIN
	DELETE FROM [Cliente] WHERE [Id] = @Id
END
GO

--Trocar Importacao do Cliente
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_TROCAR_IMPORTACAO_CLIENTE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_TROCAR_IMPORTACAO_CLIENTE]
GO

CREATE PROCEDURE [DBO].[SP_TROCAR_IMPORTACAO_CLIENTE]
	@Id bigint,
	@ImportacaoId int
AS
BEGIN
	UPDATE [Cliente] SET [ImportacaoId] = @ImportacaoId WHERE [Id] = @Id
END
GO


--====================================================== PROCEDURES TABELA IMPORTACAO =======================================================================

--Salvar Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_IMPORTACAO]
	@UsuarioId int,
	@Nome varchar(max),
	@Terminado bit = null,
	@NumImportados int = null,
	@NumAtualizados int = null,
	@CaminhoArquivo varchar(max) = null
AS
BEGIN
	DECLARE @ULTIMO_ID INT

	INSERT INTO [Importacao] ([UsuarioId], [Nome], [Data], [Terminado], [NumImportados], [NumAtualizados], [CaminhoArquivo])
	VALUES (@UsuarioId, @Nome, CONVERT(date, GETDATE()), @Terminado, @NumImportados, @NumAtualizados, @CaminhoArquivo)

	 
	SET @ULTIMO_ID = Scope_identity()

	SELECT @ULTIMO_ID
END
GO

--Adicionar Caminho da Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_CAMINHO_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_CAMINHO_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_CAMINHO_IMPORTACAO]
	@Id int,
	@CaminhoArquivo varchar(max)
AS
BEGIN
	UPDATE [Importacao] SET [CaminhoArquivo] = @CaminhoArquivo WHERE [Id] = @Id
END
GO

--Adicionar Numero de Importados da Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_NUM_IMPORTADOS_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_NUM_IMPORTADOS_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_NUM_IMPORTADOS_IMPORTACAO]
	@Id int,
	@NumImportados int
AS
BEGIN
	UPDATE [Importacao] SET [NumImportados] = @NumImportados WHERE [Id] = @Id
END
GO

--Listar Todos Importacoes
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODOS_IMPORTACOES]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODOS_IMPORTACOES]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODOS_IMPORTACOES]
AS
BEGIN
	SELECT * FROM [Importacao]
END
GO

--Selecionar por Id Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_IMPORTACAO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_IMPORTACAO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_IMPORTACAO_ID]
	@Id int
AS
BEGIN
	SELECT * FROM [Importacao] WHERE [Id] = @Id
END
GO

--Selecionar por Nome Importacao
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_IMPORTACAO_NOME]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_IMPORTACAO_NOME]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_IMPORTACAO_NOME]
	@Nome varchar(max)
AS
BEGIN
	SELECT * FROM [Importacao] WHERE [Nome] = @Nome
END
GO

--Terminar Importação
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_TERMINAR_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_TERMINAR_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_TERMINAR_IMPORTACAO]
	@Id int
AS
BEGIN
	UPDATE [Importacao] SET [Terminado] = 1 WHERE [Id] = @Id
END
GO

--====================================================== PROCEDURES TABELA Emprestimo =======================================================================

--Listar Emprestimos do Cliente
--=====================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID]
	@ClienteId bigint
AS
BEGIN
	SELECT * FROM [Emprestimo] WHERE [ClienteId] = @ClienteId 
END
GO

--Excluir Emprestimos do Beneficio
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_EMPRESTIMO_BENEFICIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_BENEFICIO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_BENEFICIO]
	@NumBeneficio bigint,
	@BancoId int
AS
BEGIN	
	DELETE FROM [Emprestimo] WHERE [NumBeneficio] = @NumBeneficio AND [BancoId] = @BancoId
END
GO

--Excluir Emprestimos do CPF
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_EMPRESTIMO_CLIENTE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_CLIENTE]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_CLIENTE]
	@NumBeneficio bigint,
	@BancoId int
AS
BEGIN
	DELETE FROM [Emprestimo] WHERE [NumBeneficio] = @NumBeneficio AND [BancoId] = @BancoId
END
GO

--Selecionar Emprestimo por contrato
--=================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_EMPRESTIMO_CONTRATO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_EMPRESTIMO_CONTRATO]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_EMPRESTIMO_CONTRATO]
	@ClienteId bigint,
	@BancoId int,
	@CodigoContrato bigint
AS
BEGIN
	SELECT * FROM Emprestimo WHERE [ClienteId] = @ClienteId AND [BancoId] = @BancoId AND [CodigoContrato] = @CodigoContrato
END
GO

--Excluir Emprestimo por contrato
--=================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_EMPRESTIMO_CONTRATO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_CONTRATO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_EMPRESTIMO_CONTRATO]
	@ClienteId bigint,
	@BancoId int,
	@CodigoContrato bigint
AS
BEGIN
	DELETE FROM Emprestimo WHERE [ClienteId] = @ClienteId AND [BancoId] = @BancoId AND [CodigoContrato] = @CodigoContrato
END
GO

--Salvar Emprestimo
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_EMPRESTIMO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO]
	@ClienteId bigint,
	@NumBeneficio bigint,
	@ValorParcela float = null,
	@ValorBruto float = null,
	@ParcelasNoContrato int = null,
	@ParcelasEmAberto int = null,
	@Saldo float = null,
	@InicioPagamento date = null,
	@FimPagamento date = null,
	@BancoId int,
	@TipoEmprestimo int = null,
	@SituacaoEmprestimo int = null,
	@DataIncluidoInss date = null,
	@DataExcluidoInss date = null,
	@CodigoContrato bigint = null
AS
BEGIN
	DECLARE @NumEmprestimo INT 

	SET @NumEmprestimo = (SELECT (COUNT(*) + 1) FROM [Emprestimo] WHERE [ClienteId] = @ClienteId AND [NumBeneficio] = @NumBeneficio)

	INSERT INTO [Emprestimo] ([ClienteId], [NumBeneficio], [NumEmprestimo], [ValorParcela], [ParcelasNoContrato], [ParcelasEmAberto], [Saldo], [InicioPagamento], [BancoId],
		[ValorBruto], [FimPagamento], [TipoEmprestimo], [SituacaoEmprestimo], [DataIncluidoInss], [DataExcluidoInss], [CodigoContrato])
	VALUES (@ClienteId, @NumBeneficio, @NumEmprestimo, @ValorParcela, @ParcelasNoContrato, @ParcelasEmAberto, @Saldo, @InicioPagamento, @BancoId, @ValorBruto, @FimPagamento,
		@TipoEmprestimo, @SituacaoEmprestimo, @DataIncluidoInss, @DataExcluidoInss, @CodigoContrato)
END
GO

--Salvar Emprestimo Processa
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]
	@ClienteId bigint,
	@NumBeneficio bigint,
	@ValorParcela float = null,
	@ParcelasNoContrato int = null,
	@ParcelasEmAberto int = null,
	@Saldo float = null,
	@InicioPagamento date = null,
	@BancoId int = null
AS
BEGIN
	DECLARE @NumEmprestimo INT

	SET @NumEmprestimo = (SELECT (COUNT(*) + 1) FROM [Emprestimo] WHERE [ClienteId] = @ClienteId AND [NumBeneficio] = @NumBeneficio)

	INSERT INTO [Emprestimo] ([ClienteId], [NumBeneficio], [NumEmprestimo], [ValorParcela], [ParcelasNoContrato], [ParcelasEmAberto], [Saldo], [InicioPagamento], [BancoId])
	VALUES (@ClienteId, @NumBeneficio, @NumEmprestimo, @ValorParcela, @ParcelasNoContrato, @ParcelasEmAberto, @Saldo, @InicioPagamento, @BancoId)

	UPDATE [Cliente] SET [DataEmpAtualizados] = CONVERT(date, GETDATE()) WHERE [Id] = @ClienteId
END
GO

--====================================================== PROCEDURES TABELA Beneficio =======================================================================

--Salvar Beneficio
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_BENEFICIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_BENEFICIO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_BENEFICIO]
	@Numero bigint,
	@ClienteId bigint,
	@Salario float = null,
	@DataCompetencia date = null,
	@DataInicioBeneficio date = null,
	@BancoPagamento int = null,
	@AgenciaPagamento int = null,
	@OrgaoPagador int = null,
	@ContaCorrente nvarchar(20) = null,
	@Especie int = null
AS
BEGIN
	INSERT INTO [Beneficio] ([Numero], [ClienteId], [Salario], [DataCompetencia], [DataInicioBeneficio], [BancoPagamento], [AgenciaPagamento], [OrgaoPagador], [ContaCorrente],
		[Especie])
	VALUES (@Numero, @ClienteId, @Salario, @DataCompetencia, @DataInicioBeneficio, @BancoPagamento, @AgenciaPagamento, @OrgaoPagador, 
		@ContaCorrente, @Especie)
END
GO

--Alterar Beneficio
--========================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ALTERAR_BENEFICIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ALTERAR_BENEFICIO]
GO

CREATE PROCEDURE [DBO].[SP_ALTERAR_BENEFICIO]
	@Numero bigint,
	@ClienteId bigint,
	@Salario float = null,
	@DataInicioBeneficio date = null,
	@BancoPagamento int = null,
	@AgenciaPagamento int = null,
	@OrgaoPagador int = null,
	@ContaCorrente nvarchar(20) = null,
	@Especie int = null
AS
BEGIN

	UPDATE [Beneficio] SET [Salario] = @Salario, [DataCompetencia] = CONVERT(date, GETDATE()), [DataInicioBeneficio] = @DataInicioBeneficio, 
		[BancoPagamento] = @BancoPagamento, [AgenciaPagamento] = @AgenciaPagamento, [OrgaoPagador] = @OrgaoPagador, 
		[ContaCorrente] = @ContaCorrente, [Especie] = @Especie
END
GO

--Selecionar Beneficio Id
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_BENEFICIO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_BENEFICIO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_BENEFICIO_ID]
	@Numero bigint
AS
BEGIN
	SELECT * FROM [Beneficio] WHERE [Numero] = @Numero
END
GO

--Listar por Id do Cliente
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_BENEFICIO_CLIENTE_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_BENEFICIO_CLIENTE_ID]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_BENEFICIO_CLIENTE_ID]
	@ClienteId bigint
AS
BEGIN
	SELECT * FROM [Beneficio] WHERE [ClienteId] = @ClienteId
END
GO