USE [Consulta]
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS OFF
GO

--Listar Consulta
--====================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODOS_CONSULTAS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODOS_CONSULTAS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODOS_CONSULTAS]
AS
BEGIN
	SELECT [Consulta], [Descricao], [Data], [Integracao], [SAFRA_Usuario], [SAFRA_Senha] FROM [Consultas_INSS]
END
GO

--Listar Emprestimos Refin de Consulta
--=====================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_EMPRESTIMOS_CONSULTA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_EMPRESTIMOS_CONSULTA]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_EMPRESTIMOS_CONSULTA]
	@Consulta int
AS
BEGIN
	SELECT [CPF], [Matricula], [Tipo], [Codigo_Banco], [Data_Consulta], [Parcelas_Contrato], [Parcelas_Aberto], [Parcelas_Refin], [Valor_Contrato], [Valor_Parcela], [Saldo_Contrato],
	[Saldo_Refin], [Status], [OK] FROM [Saldo_Refin] WHERE [Consulta] = @Consulta
END
GO

--Salvar Consulta
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_CONSULTA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_CONSULTA]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_CONSULTA]
	@Descricao nchar(100) = null,
	@SAFRA_Usuario nchar(30) = null,
	@SAFRA_Senha nchar(30) = null
AS
BEGIN

	DECLARE @Consulta INT 

	SET @Consulta = (SELECT (COUNT(*) + 1) FROM [Consultas_INSS])

	INSERT INTO [Consultas_INSS] ([Consulta], [Descricao], [Data], [SAFRA_Usuario], [SAFRA_Senha])
	VALUES (@Consulta, @Descricao, CONVERT(date, GETDATE()), @SAFRA_Usuario, @SAFRA_Senha)

	SELECT @Consulta
END
GO

--Salvar Dados Clientes da Consulta
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_CONSULTA_DADOS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_CONSULTA_DADOS]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_CONSULTA_DADOS]
	@Consulta int,
	@Beneficio nchar(20) = null,
	@DataNascimento nchar(10) = null,
	@Cpf nchar(14) = null,
	@Nome nchar(60) = null
AS
BEGIN
	INSERT INTO [Consultas_INSS_Dados] ([Consulta], [Beneficio], [Data_Nascimento], [CPF], [Nome])
	VALUES (@Consulta, @Beneficio, CONVERT(DATE, @DataNascimento), REPLICATE('0', 11 - LEN(@Cpf)) + @Cpf, @Nome)
END
GO