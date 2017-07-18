USE [Consulta]
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS OFF
GO


--Salvar Consulta
--===============================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_CONSULTA]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_CONSULTA]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_CONSULTA]
	@Descricao nchar(100),
	@Data datetime,
	@Integracao nchar(3),
	@SAFRA_Usuario nchar(30),
	@SAFRA_Senha nchar(30)
AS
BEGIN
	INSERT INTO [Consultas_INSS] ([Descricao], [Data], [Integracao], [SAFRA_Usuario], [SAFRA_Senha])
	VALUES (@Descricao, @Data, @Integracao, @SAFRA_Usuario, @SAFRA_Senha)
END
GO