-- Comando para criação do banco de dados
CREATE DATABASE meuPrimeiroBanco;

-- Utilizando o banco de dados criado
USE meuPrimeiroBanco;

-- Exemplo de criação de uma entidade no banco de dados
CREATE TABLE Produto(
	idUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(120),
	Email VARCHAR(60)
	-- Senha Varchar(120)
);

CREATE TABLE Produto(
	idProduto INT PRIMARY KEY,
	Nome VARCHAR(120) NOT NULL,

	Usuario_id INT, -- Crio uma coluna para salvar a referencia de Usuario
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(idUsuario) -- Crio o relacionamento entre produto e usuario
);

-- Adicionar uma coluna
ALTER TABLE Produto ADD Senha VARCHAR(15);

-- Remover uma coluna
ALTER TABLE Usuario DROP COLUMN Senha;

-- Alteracao das marcações de uma coluna
ALTER TABLE Usuario ALTER COLUMN Nome VARCHAR(120) NOT NULL;

-- Deletar uma tabela (NUNCA USE ISSO)
DROP TABLE Usuario;
DROP TABLE Produto;

/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
-- Inserindo Novas informações na Tabela.--
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

INSERT INTO Produto
	(/*idUsuario,*/ Nome, Email, Senha)
VALUES
	(/*1,*/ 'Marcelo Santiago', 'MarceloSantiago@gmail.com', '1234');

--consultar as informações da tabela de usuario
SELECT * FROM Usuario;

-- Aterar um registrooo
UPDATE Produto SET Nome = 'Marcelo Santiago de Oliveira' WHERE idUsuario = 1

-- Delete um registro
DELETE Produto WHERE idUsuario = 3;

INSERT INTO Produto
	(Nome, Usuario_id)
VALUES
	('Produto', 10);

SELECT * FROM Produto;