
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2011 10:58:49
-- Generated from EDMX file: C:\Documents and Settings\chaiwat.k\Desktop\MyEverything\CarPass\VSS\Devs\CarPass.TicTacToe.Model\CarPass.TicTacToe.Model\TicTacToeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TRAINING];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TicTacToeGameSet'
CREATE TABLE [dbo].[TicTacToeGameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] smallint  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [DurationInSec] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TicTacToeGameSet'
ALTER TABLE [dbo].[TicTacToeGameSet]
ADD CONSTRAINT [PK_TicTacToeGameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------