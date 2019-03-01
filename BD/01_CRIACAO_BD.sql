-- Arquivo de criação e modelagem de dados

create database Senatur_Tarde;

use Senatur_Tarde;

create table PACOTES (
	PacoteId int identity primary key
   ,NomePacote varchar(250) not null unique
   ,Descricao text not null
   ,DataIda date not null
   ,DataVolta date not null
   ,Valor decimal(10, 2) not null
   ,Ativo bit not null
   ,NomeCidade varchar(250) not null 
);

create table USUARIOS (
	UsuarioId int identity primary key
   ,Email varchar(250) not null unique
   ,Senha varchar(250) not null
   ,TipoUsuario varchar(150) not null
);