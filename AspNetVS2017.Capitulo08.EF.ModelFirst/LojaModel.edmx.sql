
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2018 22:23:03
-- Generated from EDMX file: C:\Users\no4815\source\repos\ImpactaAspNet\AspNetVS2017.Capitulo08.EF.ModelFirst\LojaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LojaModel];
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

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL,
    [Preco] decimal(9,2)  NOT NULL,
    [Categoria_Id] int  NOT NULL
);
GO

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ProdutoImagem'
CREATE TABLE [dbo].[ProdutoImagem] (
    [Produto_Id] int  NOT NULL,
    [Imagem] varbinary(max)  NOT NULL
);
GO

-- Creating table 'CategoriaFornecedor'
CREATE TABLE [dbo].[CategoriaFornecedor] (
    [Categoria_Id] int  NOT NULL,
    [Fornecedor_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Produto_Id] in table 'ProdutoImagem'
ALTER TABLE [dbo].[ProdutoImagem]
ADD CONSTRAINT [PK_ProdutoImagem]
    PRIMARY KEY CLUSTERED ([Produto_Id] ASC);
GO

-- Creating primary key on [Categoria_Id], [Fornecedor_Id] in table 'CategoriaFornecedor'
ALTER TABLE [dbo].[CategoriaFornecedor]
ADD CONSTRAINT [PK_CategoriaFornecedor]
    PRIMARY KEY CLUSTERED ([Categoria_Id], [Fornecedor_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_CategoriaProduto]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaProduto'
CREATE INDEX [IX_FK_CategoriaProduto]
ON [dbo].[Produto]
    ([Categoria_Id]);
GO

-- Creating foreign key on [Categoria_Id] in table 'CategoriaFornecedor'
ALTER TABLE [dbo].[CategoriaFornecedor]
ADD CONSTRAINT [FK_CategoriaFornecedor_Categoria]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Fornecedor_Id] in table 'CategoriaFornecedor'
ALTER TABLE [dbo].[CategoriaFornecedor]
ADD CONSTRAINT [FK_CategoriaFornecedor_Fornecedor]
    FOREIGN KEY ([Fornecedor_Id])
    REFERENCES [dbo].[Fornecedor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaFornecedor_Fornecedor'
CREATE INDEX [IX_FK_CategoriaFornecedor_Fornecedor]
ON [dbo].[CategoriaFornecedor]
    ([Fornecedor_Id]);
GO

-- Creating foreign key on [Produto_Id] in table 'ProdutoImagem'
ALTER TABLE [dbo].[ProdutoImagem]
ADD CONSTRAINT [FK_ProdutoProdutoImagem]
    FOREIGN KEY ([Produto_Id])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------