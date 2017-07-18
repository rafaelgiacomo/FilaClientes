USE [CampanhaBD]
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS OFF
GO

--====================================================== PROCEDURES TABELA USUARIO =======================================================================

--Salvar Usuario
--===============================================
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

--====================================================== PROCEDURES TABELA CLIENTE =======================================================================

--Salvar Cliente
--===============================================
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
	@DataNascimento datetime = null,
	@Logradouro varchar(max) = null,
	@Numero varchar(7) = null,
	@Complemento varchar(max) = null,
	@Cep varchar(11) = null,
	@DataImportado datetime
AS
BEGIN
	INSERT INTO [Cliente] ([ImportacaoId], [Nome], [Cpf], [Uf], [Cidade], [Bairro], [Ddd], [Telefone], [DataNascimento], [Logradouro], [Numero], [Complemento], [Cep],
		[DataImportado])
	VALUES (@ImportacaoId, @Nome, @Cpf, @Uf, @Cidade, @Bairro, @Ddd, @Telefone, @DataNascimento, @Logradouro, @Numero, @Complemento, @Cep, @DataImportado)

	DECLARE @ULTIMO_ID INT 
	SET @ULTIMO_ID = Scope_identity()

	SELECT @ULTIMO_ID
END
GO

--Atualizar DataEmpAtualizado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_EMP_ATUALIZADO]
	@Id bigint,
	@DataEmpAtualizados datetime
AS
BEGIN
	UPDATE [Cliente] SET [DataEmpAtualizados] = @DataEmpAtualizados WHERE [Id] = @Id
END
GO

--Atualizar DataTrabalhado
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ATUALIZAR_DATA_TRABALHADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TRABALHADO]
GO

CREATE PROCEDURE [DBO].[SP_ATUALIZAR_DATA_TRABALHADO]
	@Id bigint,
	@DataTrabalhado datetime
AS
BEGIN
	UPDATE [Cliente] SET [DataTrabalhado] = @DataTrabalhado WHERE [Id] = @Id
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
	SELECT [Id], [ImportacaoId], [Nome], [Cpf], [Uf], [Cidade], [Bairro], [Ddd], [Telefone], [DataNascimento], [Logradouro], [Numero], [Complemento], [Cep],
		[DataImportado], [DataTelAtualizado], [DataEmpAtualizados], [DataTrabalhado] FROM [Cliente] where [ImportacaoId] = @ImportacaoId
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
	SELECT [Id], [ImportacaoId], [Nome], [Cpf], [Uf], [Cidade], [Bairro], [Ddd], [Telefone], [DataNascimento], [Logradouro], [Numero], [Complemento], [Cep],
		[DataImportado], [DataTelAtualizado], [DataEmpAtualizados], [DataTrabalhado] FROM [Cliente] where [Id] = @Id
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
	SELECT [Id], [ImportacaoId], [Nome], [Cpf], [Uf], [Cidade], [Bairro], [Ddd], [Telefone], [DataNascimento], [Logradouro], [Numero], [Complemento], [Cep],
		[DataImportado], [DataTelAtualizado], [DataEmpAtualizados], [DataTrabalhado] FROM [Cliente] where [Cpf] = @Cpf
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


--====================================================== PROCEDURES TABELA IMPORTACAO =======================================================================

--Salvar Cliente
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_IMPORTACAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_IMPORTACAO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_IMPORTACAO]
	@UsuarioId int,
	@Nome varchar(max),
	@Data datetime,
	@Terminado bit = null,
	@NumImportados int = null,
	@NumAtualizados int = null,
	@CaminhoArquivo varchar(max) = null
AS
BEGIN
	INSERT INTO [Importacao] ([UsuarioId], [Nome], [Data], [Terminado], [NumImportados], [NumAtualizados], [CaminhoArquivo])
	VALUES (@UsuarioId, @Nome, @Data, @Terminado, @NumImportados, @NumAtualizados, @CaminhoArquivo)

	DECLARE @ULTIMO_ID INT 
	SET @ULTIMO_ID = Scope_identity()

	SELECT @ULTIMO_ID
END
GO

--Alterar Importacao
--===============================================


--Listar Todos Importacoes
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODOS_IMPORTACOES]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODOS_IMPORTACOES]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODOS_IMPORTACOES]
AS
BEGIN
	SELECT [Id], [UsuarioId], [Nome], [Data], [Terminado], [NumImportados], [NumAtualizados], [CaminhoArquivo] FROM [Importacao]
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
	SELECT [Id], [UsuarioId], [Nome], [Data], [Terminado], [NumImportados], [NumAtualizados], [CaminhoArquivo] FROM [Importacao] WHERE [Id] = @Id
END
GO

--====================================================== PROCEDURES TABELA Emprestimo =======================================================================

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

--Salvar Emprestimo
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_EMPRESTIMO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO]
	@ClienteId bigint,
	@NumBeneficio bigint,
	@ValorParcela float,
	@ParcelasNoContrato int = null,
	@ParcelasEmAberto int = null,
	@Saldo float = null,
	@InicioPagamento date = null,
	@BancoId int
AS
BEGIN
	DECLARE @NumEmprestimo INT 

	SET @NumEmprestimo = (SELECT COUNT(*) FROM [Emprestimo] WHERE [ClienteId] = @ClienteId AND [NumBeneficio] = @NumBeneficio)

	IF(@NumEmprestimo IS NULL)
		SET @NumEmprestimo = 1
	ELSE
		SET @NumEmprestimo = @NumEmprestimo + 1

	INSERT INTO [Emprestimo] ([ClienteId], [NumBeneficio], [NumEmprestimo], [ValorParcela], [ParcelasNoContrato], [ParcelasEmAberto], [Saldo], [InicioPagamento], [BancoId])
	VALUES (@ClienteId, @NumBeneficio, @NumEmprestimo, @ValorParcela, @ParcelasNoContrato, @ParcelasEmAberto, @Saldo, @InicioPagamento, @BancoId)
END
GO

--Salvar Emprestimo Processa
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_EMPRESTIMO_PROCESSA]
	@NumBeneficio bigint,
	@ValorParcela float,
	@ParcelasNoContrato int = null,
	@ParcelasEmAberto int = null,
	@Saldo float = null,
	@InicioPagamento date = null,
	@BancoId int
AS
BEGIN
	DECLARE @NumEmprestimo INT, @ClienteId BIGINT
	
	SET @ClienteId = (SELECT [ClienteId] FROM [Beneficio] WHERE [Numero] = @NumBeneficio)  

	SET @NumEmprestimo = (SELECT COUNT(*) FROM [Emprestimo] WHERE [ClienteId] = @ClienteId AND [NumBeneficio] = @NumBeneficio)

	IF(@NumEmprestimo IS NULL)
		SET @NumEmprestimo = 1
	ELSE
		SET @NumEmprestimo = @NumEmprestimo + 1

	INSERT INTO [Emprestimo] ([ClienteId], [NumBeneficio], [NumEmprestimo], [ValorParcela], [ParcelasNoContrato], [ParcelasEmAberto], [Saldo], [InicioPagamento], [BancoId])
	VALUES (@ClienteId, @NumBeneficio, @NumEmprestimo, @ValorParcela, @ParcelasNoContrato, @ParcelasEmAberto, @Saldo, @InicioPagamento, @BancoId)
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
	@DataCompetencia date = null
AS
BEGIN
	INSERT INTO [Beneficio] ([Numero], [ClienteId], [Salario], [DataCompetencia])
	VALUES (@Numero, @ClienteId, @Salario, @DataCompetencia)
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
	SELECT [Numero], [ClienteId], [Salario], [DataCompetencia] FROM [Beneficio] WHERE [Numero] = @Numero
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
	SELECT [Numero], [ClienteId], [Salario], [DataCompetencia] FROM [Beneficio] WHERE [ClienteId] = @ClienteId
END
GO

