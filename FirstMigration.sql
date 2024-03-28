IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Member] (
    [member_id] bigint NOT NULL IDENTITY,
    [member_name] varchar(500) NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY ([member_id])
);
GO

CREATE TABLE [Product] (
    [product_id] bigint NOT NULL IDENTITY,
    [product_name] varchar(500) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([product_id])
);
GO

CREATE TABLE [Order] (
    [order_id] bigint NOT NULL IDENTITY,
    [fk_memberid] bigint NOT NULL,
    [fk_productid] bigint NOT NULL,
    [order_dateorder] datetime2 NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([order_id]),
    CONSTRAINT [FK_Order_Member] FOREIGN KEY ([fk_memberid]) REFERENCES [Member] ([member_id]),
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([fk_productid]) REFERENCES [Product] ([product_id])
);
GO

CREATE INDEX [IX_Order_fk_memberid] ON [Order] ([fk_memberid]);
GO

CREATE INDEX [IX_Order_fk_productid] ON [Order] ([fk_productid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240328100051_InitialMigration', N'8.0.3');
GO

COMMIT;
GO

