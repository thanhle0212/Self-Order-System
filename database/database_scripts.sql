-- 1.Create Database
CREATE DATABASE InstantPOS
GO
USE [InstantPOS]
GO
-- 2.Product 
CREATE TABLE [dbo].[Product](
       [ProductID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
       [ProductKey] [nvarchar](50) NOT NULL,
       [ProductName] [nvarchar](250) NOT NULL,
       [ProductImageUri] [nvarchar](250) NULL,
       [ProductTypeID] [uniqueidentifier] NOT NULL,
       [RecordStatus] [smallint] NOT NULL,
       [CreatedDate] [datetime] NOT NULL,
       [UpdatedDate] [datetime] NULL,
       [UpdatedUser] [uniqueidentifier] NULL,
CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED
(
       [ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [IX_Product] UNIQUE NONCLUSTERED
(
       [ProductKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
 
-- 3.Product Type  
CREATE TABLE [dbo].[ProductType](
       [ProductTypeID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
       [ProductTypeKey] [nvarchar](250) NOT NULL,
       [ProductTypeName] [nvarchar](250) NOT NULL,
       [RecordStatus] [smallint] NOT NULL,
       [CreatedDate] [datetime] NOT NULL,
       [UpdatedDate] [datetime] NULL,
       [UpdatedUser] [uniqueidentifier] NULL,
CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED
(
       [ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [IX_ProductType] UNIQUE NONCLUSTERED
(
       [ProductTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductID]  DEFAULT (newid()) FOR [ProductID]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductType_ProductTypeID]  DEFAULT (newid()) FOR [ProductTypeID]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductType] ([ProductTypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO