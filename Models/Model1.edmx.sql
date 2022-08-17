
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/22/2020 01:47:34
-- Generated from EDMX file: C:\Users\goner\Desktop\canteen_management_system\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [canteen_manege_system];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_chef_collect_order_master_order_assign_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chef_collect_order_master] DROP CONSTRAINT [FK_chef_collect_order_master_order_assign_master];
GO
IF OBJECT_ID(N'[dbo].[FK_feedback_master_user_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[feedback_master] DROP CONSTRAINT [FK_feedback_master_user_master];
GO
IF OBJECT_ID(N'[dbo].[FK_food_item_master_food_category_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[food_item_master] DROP CONSTRAINT [FK_food_item_master_food_category_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_assign_master_order_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_assign_master] DROP CONSTRAINT [FK_order_assign_master_order_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_assign_master_speciality_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_assign_master] DROP CONSTRAINT [FK_order_assign_master_speciality_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_item_food_item_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_item] DROP CONSTRAINT [FK_order_item_food_item_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_item_order_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_item] DROP CONSTRAINT [FK_order_item_order_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_master_food_item_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_master] DROP CONSTRAINT [FK_order_master_food_item_master];
GO
IF OBJECT_ID(N'[dbo].[FK_order_master_user_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_master] DROP CONSTRAINT [FK_order_master_user_master];
GO
IF OBJECT_ID(N'[dbo].[FK_payment_master_order_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[payment_master] DROP CONSTRAINT [FK_payment_master_order_master];
GO
IF OBJECT_ID(N'[dbo].[FK_rating_master_food_item_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[rating_master] DROP CONSTRAINT [FK_rating_master_food_item_master];
GO
IF OBJECT_ID(N'[dbo].[FK_speciality_master_food_category_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[speciality_master] DROP CONSTRAINT [FK_speciality_master_food_category_master];
GO
IF OBJECT_ID(N'[dbo].[FK_speciality_master_user_master]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[speciality_master] DROP CONSTRAINT [FK_speciality_master_user_master];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[chef_collect_order_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[chef_collect_order_master];
GO
IF OBJECT_ID(N'[dbo].[feedback_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[feedback_master];
GO
IF OBJECT_ID(N'[dbo].[food_category_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[food_category_master];
GO
IF OBJECT_ID(N'[dbo].[food_item_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[food_item_master];
GO
IF OBJECT_ID(N'[dbo].[order_assign_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_assign_master];
GO
IF OBJECT_ID(N'[dbo].[order_item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_item];
GO
IF OBJECT_ID(N'[dbo].[order_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_master];
GO
IF OBJECT_ID(N'[dbo].[payment_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[payment_master];
GO
IF OBJECT_ID(N'[dbo].[rating_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rating_master];
GO
IF OBJECT_ID(N'[dbo].[speciality_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[speciality_master];
GO
IF OBJECT_ID(N'[dbo].[user_master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_master];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'chef_collect_order_master'
CREATE TABLE [dbo].[chef_collect_order_master] (
    [chef_collect_order_id] int IDENTITY(1,1) NOT NULL,
    [Order_assign_id] int  NOT NULL,
    [is_start] bit  NOT NULL,
    [is_done] bit  NOT NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL
);
GO

-- Creating table 'feedback_master'
CREATE TABLE [dbo].[feedback_master] (
    [feedback_id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [feedback] varchar(max)  NOT NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'food_category_master'
CREATE TABLE [dbo].[food_category_master] (
    [food_cat_id] int IDENTITY(1,1) NOT NULL,
    [food_cat_name] varchar(50)  NOT NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'food_item_master'
CREATE TABLE [dbo].[food_item_master] (
    [food_item_id] int IDENTITY(1,1) NOT NULL,
    [food_cat__id] int  NOT NULL,
    [item_name] varchar(50)  NOT NULL,
    [item_description] varchar(max)  NOT NULL,
    [amount] float  NOT NULL,
    [quantity] int  NOT NULL,
    [discount] int  NOT NULL,
    [image] varchar(max)  NOT NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'order_assign_master'
CREATE TABLE [dbo].[order_assign_master] (
    [Order_assign_id] int IDENTITY(1,1) NOT NULL,
    [order_master_id] int  NULL,
    [speciality_id] int  NULL,
    [cheif_type] int  NULL,
    [Reject_msg] nchar(10)  NULL
);
GO

-- Creating table 'order_item'
CREATE TABLE [dbo].[order_item] (
    [order_item_id] int IDENTITY(1,1) NOT NULL,
    [order_master_id] int  NOT NULL,
    [food_item_id] int  NOT NULL,
    [total_price] float  NOT NULL,
    [status] int  NOT NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'order_master'
CREATE TABLE [dbo].[order_master] (
    [order_master_id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [food_item_id] int  NULL,
    [total_price] float  NULL,
    [quantity] int  NULL,
    [order_deliverytime] time  NOT NULL,
    [order_date] datetime  NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'payment_master'
CREATE TABLE [dbo].[payment_master] (
    [payment_id] int IDENTITY(1,1) NOT NULL,
    [order_master_id] int  NOT NULL,
    [payment_mode] int  NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'rating_master'
CREATE TABLE [dbo].[rating_master] (
    [rating_id] int IDENTITY(1,1) NOT NULL,
    [food_item_id] int  NOT NULL,
    [rating] int  NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'speciality_master'
CREATE TABLE [dbo].[speciality_master] (
    [speciality_id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [food_cat_id] int  NOT NULL,
    [qualification] varchar(50)  NOT NULL,
    [experience] int  NOT NULL,
    [is_approed] bit  NOT NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL
);
GO

-- Creating table 'user_master'
CREATE TABLE [dbo].[user_master] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [first_name] varchar(50)  NULL,
    [middle_name] varchar(50)  NULL,
    [last_name] varchar(50)  NULL,
    [e_mail] varchar(50)  NULL,
    [phone_no] varchar(50)  NULL,
    [user_name] varchar(50)  NULL,
    [password] varchar(50)  NULL,
    [address] varchar(max)  NULL,
    [city] varchar(50)  NULL,
    [district] varchar(50)  NULL,
    [state] varchar(50)  NULL,
    [country] varchar(50)  NULL,
    [pincode] int  NULL,
    [create_datetime] datetime  NULL,
    [update_datetime] datetime  NULL,
    [is_active] bit  NULL,
    [is_delete] bit  NULL,
    [user_type] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [chef_collect_order_id] in table 'chef_collect_order_master'
ALTER TABLE [dbo].[chef_collect_order_master]
ADD CONSTRAINT [PK_chef_collect_order_master]
    PRIMARY KEY CLUSTERED ([chef_collect_order_id] ASC);
GO

-- Creating primary key on [feedback_id] in table 'feedback_master'
ALTER TABLE [dbo].[feedback_master]
ADD CONSTRAINT [PK_feedback_master]
    PRIMARY KEY CLUSTERED ([feedback_id] ASC);
GO

-- Creating primary key on [food_cat_id] in table 'food_category_master'
ALTER TABLE [dbo].[food_category_master]
ADD CONSTRAINT [PK_food_category_master]
    PRIMARY KEY CLUSTERED ([food_cat_id] ASC);
GO

-- Creating primary key on [food_item_id] in table 'food_item_master'
ALTER TABLE [dbo].[food_item_master]
ADD CONSTRAINT [PK_food_item_master]
    PRIMARY KEY CLUSTERED ([food_item_id] ASC);
GO

-- Creating primary key on [Order_assign_id] in table 'order_assign_master'
ALTER TABLE [dbo].[order_assign_master]
ADD CONSTRAINT [PK_order_assign_master]
    PRIMARY KEY CLUSTERED ([Order_assign_id] ASC);
GO

-- Creating primary key on [order_item_id] in table 'order_item'
ALTER TABLE [dbo].[order_item]
ADD CONSTRAINT [PK_order_item]
    PRIMARY KEY CLUSTERED ([order_item_id] ASC);
GO

-- Creating primary key on [order_master_id] in table 'order_master'
ALTER TABLE [dbo].[order_master]
ADD CONSTRAINT [PK_order_master]
    PRIMARY KEY CLUSTERED ([order_master_id] ASC);
GO

-- Creating primary key on [payment_id] in table 'payment_master'
ALTER TABLE [dbo].[payment_master]
ADD CONSTRAINT [PK_payment_master]
    PRIMARY KEY CLUSTERED ([payment_id] ASC);
GO

-- Creating primary key on [rating_id] in table 'rating_master'
ALTER TABLE [dbo].[rating_master]
ADD CONSTRAINT [PK_rating_master]
    PRIMARY KEY CLUSTERED ([rating_id] ASC);
GO

-- Creating primary key on [speciality_id] in table 'speciality_master'
ALTER TABLE [dbo].[speciality_master]
ADD CONSTRAINT [PK_speciality_master]
    PRIMARY KEY CLUSTERED ([speciality_id] ASC);
GO

-- Creating primary key on [user_id] in table 'user_master'
ALTER TABLE [dbo].[user_master]
ADD CONSTRAINT [PK_user_master]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Order_assign_id] in table 'chef_collect_order_master'
ALTER TABLE [dbo].[chef_collect_order_master]
ADD CONSTRAINT [FK_chef_collect_order_master_order_assign_master]
    FOREIGN KEY ([Order_assign_id])
    REFERENCES [dbo].[order_assign_master]
        ([Order_assign_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_chef_collect_order_master_order_assign_master'
CREATE INDEX [IX_FK_chef_collect_order_master_order_assign_master]
ON [dbo].[chef_collect_order_master]
    ([Order_assign_id]);
GO

-- Creating foreign key on [user_id] in table 'feedback_master'
ALTER TABLE [dbo].[feedback_master]
ADD CONSTRAINT [FK_feedback_master_user_master]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user_master]
        ([user_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_feedback_master_user_master'
CREATE INDEX [IX_FK_feedback_master_user_master]
ON [dbo].[feedback_master]
    ([user_id]);
GO

-- Creating foreign key on [food_cat__id] in table 'food_item_master'
ALTER TABLE [dbo].[food_item_master]
ADD CONSTRAINT [FK_food_item_master_food_category_master]
    FOREIGN KEY ([food_cat__id])
    REFERENCES [dbo].[food_category_master]
        ([food_cat_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_food_item_master_food_category_master'
CREATE INDEX [IX_FK_food_item_master_food_category_master]
ON [dbo].[food_item_master]
    ([food_cat__id]);
GO

-- Creating foreign key on [food_cat_id] in table 'speciality_master'
ALTER TABLE [dbo].[speciality_master]
ADD CONSTRAINT [FK_speciality_master_food_category_master]
    FOREIGN KEY ([food_cat_id])
    REFERENCES [dbo].[food_category_master]
        ([food_cat_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_speciality_master_food_category_master'
CREATE INDEX [IX_FK_speciality_master_food_category_master]
ON [dbo].[speciality_master]
    ([food_cat_id]);
GO

-- Creating foreign key on [food_item_id] in table 'order_item'
ALTER TABLE [dbo].[order_item]
ADD CONSTRAINT [FK_order_item_food_item_master]
    FOREIGN KEY ([food_item_id])
    REFERENCES [dbo].[food_item_master]
        ([food_item_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_item_food_item_master'
CREATE INDEX [IX_FK_order_item_food_item_master]
ON [dbo].[order_item]
    ([food_item_id]);
GO

-- Creating foreign key on [food_item_id] in table 'order_master'
ALTER TABLE [dbo].[order_master]
ADD CONSTRAINT [FK_order_master_food_item_master]
    FOREIGN KEY ([food_item_id])
    REFERENCES [dbo].[food_item_master]
        ([food_item_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_master_food_item_master'
CREATE INDEX [IX_FK_order_master_food_item_master]
ON [dbo].[order_master]
    ([food_item_id]);
GO

-- Creating foreign key on [food_item_id] in table 'rating_master'
ALTER TABLE [dbo].[rating_master]
ADD CONSTRAINT [FK_rating_master_food_item_master]
    FOREIGN KEY ([food_item_id])
    REFERENCES [dbo].[food_item_master]
        ([food_item_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_rating_master_food_item_master'
CREATE INDEX [IX_FK_rating_master_food_item_master]
ON [dbo].[rating_master]
    ([food_item_id]);
GO

-- Creating foreign key on [order_master_id] in table 'order_assign_master'
ALTER TABLE [dbo].[order_assign_master]
ADD CONSTRAINT [FK_order_assign_master_order_master]
    FOREIGN KEY ([order_master_id])
    REFERENCES [dbo].[order_master]
        ([order_master_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_assign_master_order_master'
CREATE INDEX [IX_FK_order_assign_master_order_master]
ON [dbo].[order_assign_master]
    ([order_master_id]);
GO

-- Creating foreign key on [speciality_id] in table 'order_assign_master'
ALTER TABLE [dbo].[order_assign_master]
ADD CONSTRAINT [FK_order_assign_master_speciality_master]
    FOREIGN KEY ([speciality_id])
    REFERENCES [dbo].[speciality_master]
        ([speciality_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_assign_master_speciality_master'
CREATE INDEX [IX_FK_order_assign_master_speciality_master]
ON [dbo].[order_assign_master]
    ([speciality_id]);
GO

-- Creating foreign key on [order_master_id] in table 'order_item'
ALTER TABLE [dbo].[order_item]
ADD CONSTRAINT [FK_order_item_order_master]
    FOREIGN KEY ([order_master_id])
    REFERENCES [dbo].[order_master]
        ([order_master_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_item_order_master'
CREATE INDEX [IX_FK_order_item_order_master]
ON [dbo].[order_item]
    ([order_master_id]);
GO

-- Creating foreign key on [user_id] in table 'order_master'
ALTER TABLE [dbo].[order_master]
ADD CONSTRAINT [FK_order_master_user_master]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user_master]
        ([user_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_master_user_master'
CREATE INDEX [IX_FK_order_master_user_master]
ON [dbo].[order_master]
    ([user_id]);
GO

-- Creating foreign key on [order_master_id] in table 'payment_master'
ALTER TABLE [dbo].[payment_master]
ADD CONSTRAINT [FK_payment_master_order_master]
    FOREIGN KEY ([order_master_id])
    REFERENCES [dbo].[order_master]
        ([order_master_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_payment_master_order_master'
CREATE INDEX [IX_FK_payment_master_order_master]
ON [dbo].[payment_master]
    ([order_master_id]);
GO

-- Creating foreign key on [user_id] in table 'speciality_master'
ALTER TABLE [dbo].[speciality_master]
ADD CONSTRAINT [FK_speciality_master_user_master]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user_master]
        ([user_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_speciality_master_user_master'
CREATE INDEX [IX_FK_speciality_master_user_master]
ON [dbo].[speciality_master]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------