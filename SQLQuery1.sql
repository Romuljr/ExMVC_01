﻿CREATE TABLE CLIENTE(
	ID	UNIQUEIDENTIFIER NOT NULL,
	NOME NVARCHAR(150) NOT NULL,
	EMAIL NVARCHAR(100) NOT NULL UNIQUE,
	CPF NVARCHAR(11) NOT NULL UNIQUE,
	DATANASCIMENTO DATE NOT NULL,
	SEXO CHAR(1) NOT NULL,
	DATACRIACAO DATETIME NOT NULL,
	DATAALTERACAO DATETIME NOT NULL,
	ATIVO	INT	NOT NULL,
	PRIMARY KEY(ID)
)

GO

ALTER TABLE CLIENTE 
ADD CONSTRAINT CHECK_SEXO
CHECK(SEXO IN('F', 'M'))

GO

ALTER TABLE CLIENTE ADD CONSTRAINT CHECK_ATIVO
CHECK(ATIVO IN(0,1))

GO

-- STOREDPROCEDURES --

CREATE PROCEDURE SP_INCLUIR_CLIENTE
	@P_NOME NVARCHAR(150),
	@P_EMAIL NVARCHAR(100),
	@P_CPF NVARCHAR(11),
	@P_DATANASCIMENTO DATE,
	@P_SEXO CHAR(1)

AS
BEGIN

	BEGIN TRANSACTION

	INSERT INTO TBL_CLIENTE
	(ID, NOME, EMAIL, CPF, DATANASCIMENTO, SEXO, DATACRIACAO,
	DATAALTERACAO, ATIVO) VALUES
	(NEWID(), @P_NOME, @P_EMAIL, @P_CPF, @P_DATANASCIMENTO,
	@P_SEXO, GETDATE(), GETDATE(), 1)

	COMMIT
END
GO

CREATE PROCEDURE SP_ALTERAR_CLIENTE
	@P_ID UNIQUEIDENTIFIER,
	@P_NOME NVARCHAR(150),
	@P_DATANASCIMENTO DATE,
	@P_SEXO CHAR(1)
AS
BEGIN
	BEGIN TRANSACTION

	UPDATE TBL_CLIENTE
	SET
		NOME = @P_NOME,
		DATANASCIMENTO = @P_DATANASCIMENTO,
		SEXO = @P_SEXO,
		DATAALTERACAO = GETDATE()
	WHERE
		ID = @P_ID
	COMMIT
END
GO

CREATE PROCEDURE SP_EXCLUIR_CLIENTE
	@P_ID UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE TBL_CLIENTE
	SET
		ATIVO = 0
	WHERE
		ID = @P_ID
	COMMIT
END
GO