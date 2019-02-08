
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/07/2019 18:24:09
-- Generated from EDMX file: C:\Users\Myuri\Documents\GitHub\tech_academy_c_sharp_projects\carRentalApplication\carRentalApplication\Models\carRental.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_carRental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[rentalCharts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rentalCharts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'rentalCharts'
CREATE TABLE [dbo].[rentalCharts] (
    [Id] int  NOT NULL,
    [FirstName] varchar(25)  NOT NULL,
    [LastName] varchar(25)  NOT NULL,
    [EmailAddress] varchar(50)  NOT NULL,
    [DateOfBirth] nvarchar(max)  NOT NULL,
    [SpeedingTickets] int  NOT NULL,
    [UnderInfluence] int  NOT NULL,
    [CarMake] varchar(25)  NOT NULL,
    [CarModel] varchar(25)  NOT NULL,
    [CarYear] int  NOT NULL,
    [FullCoverage] int  NOT NULL,
    [MonthlyTotal] decimal(19,4)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'rentalCharts'
ALTER TABLE [dbo].[rentalCharts]
ADD CONSTRAINT [PK_rentalCharts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------