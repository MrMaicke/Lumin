CREATE DATABASE Ativos;

use ativos;

create table Usuario(
	id int primary key identity,
	email varchar(120) unique,
	nome varchar(120),
	senha varchar(15)
);

create table Locais(
	id int primary key identity,
	nome varchar(120)
);

create table Ativos(
	id int primary key identity,
	nome varchar(120),
	datRegistro datetime,
	statusAtivo bit,

	Usuario_id int,
	foreign key (Usuario_id) references Usuario(id),

	locais_id int,
	foreign key (locais_id) references locais(id)
);

insert into Usuario
	(nome, email, senha)
values
('Marchelo Cobichek', 'chelo@gmail.com', '12345'),
('Lucio Morales', 'lucindofut@gmail.com', '12345'),
('Carolina Jamaica', 'jami-mina@live.com', '12345');

select * from Usuario;

insert into Locais
	(nome)
values
	('Sala 01'),
	('Biblioteca'),
	('Coordenação');

select * from Locais;

insert into Ativos
	(nome, datregistro, statusAtivo, Usuario_id, Locais_id)
values
('computador de mesa 01', getdate(), 1, 1, 1),
('computador de mesa 02', getdate(), 1, 3, 3),
('computador de mesa 01', getdate(), 1, 2, 2),
('Projetor de sala 01', getdate(), 1, 1, 1),
('Projetor de sala 02', getdate(), 0, 2, 2);

select * from Ativos;
select * from Usuario;
select * from locais;

/* Especificar quais parametros iremos consultar */
select
	id, nome, Usuario_id
from
	Ativos;

/* Coorelacionar mais de uma entidade, para mesclar as informações */
select
	ativos.id,
	ativos.nome,
	usuario.nome as 'Responsavel'
from
	ativos
inner join
	usuario
on
	usuario.id = ativos.usuario_id
inner join
	Locais
on
	Locais.id = Ativos.Locais_id
where
	ativos.usuario_id = 3