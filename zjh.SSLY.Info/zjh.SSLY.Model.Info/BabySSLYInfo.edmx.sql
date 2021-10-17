
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2015 22:10:38
-- Generated from EDMX file: D:\zjh.SSLY.Info\zjh.SSLY.Model.Info\BabySSLYInfo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BabySSLYInfo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActionInfoActionGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfo] DROP CONSTRAINT [FK_ActionInfoActionGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionInfoRole] DROP CONSTRAINT [FK_ActionInfoRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUserInfo_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUserInfo] DROP CONSTRAINT [FK_RoleUserInfo_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUserInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUserInfo] DROP CONSTRAINT [FK_RoleUserInfo_UserInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ActionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionGroup];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoRole];
GO
IF OBJECT_ID(N'[dbo].[AnalysisKeywordsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnalysisKeywordsSet];
GO
IF OBJECT_ID(N'[dbo].[BillDeliveryDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillDeliveryDtl];
GO
IF OBJECT_ID(N'[dbo].[BillDeliveryHdr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillDeliveryHdr];
GO
IF OBJECT_ID(N'[dbo].[BillGoodsReceiptDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillGoodsReceiptDtl];
GO
IF OBJECT_ID(N'[dbo].[BillGoodsReceiptHdr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillGoodsReceiptHdr];
GO
IF OBJECT_ID(N'[dbo].[BillPurchaseDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillPurchaseDtl];
GO
IF OBJECT_ID(N'[dbo].[BillPurchaseHdr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillPurchaseHdr];
GO
IF OBJECT_ID(N'[dbo].[BuyersAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuyersAccount];
GO
IF OBJECT_ID(N'[dbo].[Document]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Document];
GO
IF OBJECT_ID(N'[dbo].[HotAttributeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotAttributeSet];
GO
IF OBJECT_ID(N'[dbo].[Page_Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Page_Product];
GO
IF OBJECT_ID(N'[dbo].[ProAttribute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProAttribute];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[ProductDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductDtl];
GO
IF OBJECT_ID(N'[dbo].[ProductHdr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductHdr];
GO
IF OBJECT_ID(N'[dbo].[ProjectMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectMenu];
GO
IF OBJECT_ID(N'[dbo].[Pvuv]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pvuv];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[RoleUserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUserInfo];
GO
IF OBJECT_ID(N'[dbo].[Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supplier];
GO
IF OBJECT_ID(N'[dbo].[TbLogisticsCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TbLogisticsCompanies];
GO
IF OBJECT_ID(N'[dbo].[TbOrderDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TbOrderDtl];
GO
IF OBJECT_ID(N'[dbo].[TbOrderHdr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TbOrderHdr];
GO
IF OBJECT_ID(N'[dbo].[TbStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TbStore];
GO
IF OBJECT_ID(N'[dbo].[TbTraderates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TbTraderates];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserManage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserManage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Document'
CREATE TABLE [dbo].[Document] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Type] varchar(10)  NULL,
    [Uid] decimal(18,0)  NULL,
    [Delete] bit  NULL,
    [Path] varchar(500)  NULL,
    [SKU] varchar(20)  NULL,
    [CreateTime] datetime  NULL
);
GO

-- Creating table 'ProductDtl'
CREATE TABLE [dbo].[ProductDtl] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [SKU] varchar(10)  NOT NULL,
    [Delete] bit  NULL,
    [Uid] decimal(18,0)  NULL,
    [CreateTime] datetime  NULL,
    [AttributeID] decimal(18,0)  NOT NULL,
    [Source] varchar(1000)  NULL,
    [GrossWeight] decimal(18,0)  NULL,
    [NetWeight] decimal(18,0)  NULL,
    [Cost] decimal(18,2)  NULL,
    [Remark] varchar(max)  NULL,
    [State] varchar(100)  NULL,
    [MainImage] varchar(200)  NULL,
    [Brand] varchar(100)  NULL,
    [Color] nvarchar(5)  NULL,
    [SalePrice] decimal(18,2)  NULL,
    [CodeNum] nvarchar(10)  NULL,
    [AgeBracket] decimal(18,0)  NULL,
    [GxQty] int  NOT NULL
);
GO

-- Creating table 'UserManage'
CREATE TABLE [dbo].[UserManage] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] varchar(20)  NULL,
    [Password] varchar(150)  NULL,
    [CreateTime] datetime  NULL,
    [Email] varchar(150)  NULL,
    [Phone] varchar(150)  NULL,
    [Address] varchar(500)  NULL,
    [Department] varchar(20)  NULL,
    [Position] varchar(20)  NULL,
    [Delete] bit  NULL,
    [UserGroup] varchar(20)  NULL
);
GO

-- Creating table 'AnalysisKeywordsSet'
CREATE TABLE [dbo].[AnalysisKeywordsSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Keywords] nchar(30)  NULL,
    [ProName] nchar(30)  NULL,
    [ProAttribute] nvarchar(max)  NULL,
    [ProCount] int  NOT NULL,
    [ExpectedRank] nchar(30)  NULL,
    [CreateTime] datetime  NULL,
    [CreateUser] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [Category] nvarchar(max)  NULL
);
GO

-- Creating table 'HotAttributeSet'
CREATE TABLE [dbo].[HotAttributeSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AKID] int  NULL,
    [AttrName] nvarchar(max)  NOT NULL,
    [FieldName] nvarchar(max)  NOT NULL,
    [FieldType] nvarchar(max)  NOT NULL,
    [CreateUser] nvarchar(max)  NOT NULL,
    [CreateTime] time  NOT NULL
);
GO

-- Creating table 'BuyersAccount'
CREATE TABLE [dbo].[BuyersAccount] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreateTime] datetime  NULL,
    [UID] int  NULL,
    [TbAccount] nvarchar(20)  NULL,
    [TbPassword] nvarchar(20)  NULL,
    [ZfbAccount] nvarchar(50)  NULL,
    [ZfbPassword] nvarchar(20)  NULL,
    [Email] nvarchar(20)  NULL,
    [Phone] varchar(11)  NULL,
    [Credit] int  NULL,
    [AccountTime] datetime  NULL,
    [State] int  NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'Page_Product'
CREATE TABLE [dbo].[Page_Product] (
    [ID] decimal(18,0)  NOT NULL,
    [SKU] varchar(10)  NULL,
    [Title] varchar(100)  NULL,
    [Describe] varchar(max)  NULL,
    [Delete] int  NULL,
    [MainImage] varchar(200)  NULL,
    [CreateUser] decimal(18,0)  NULL,
    [CreateTime] datetime  NULL,
    [UpdateTime] datetime  NULL,
    [AttributeID] decimal(18,0)  NULL,
    [Source] varchar(1000)  NULL,
    [GrossWeight] decimal(18,0)  NULL,
    [NetWeight] decimal(18,0)  NULL,
    [Cost] decimal(18,2)  NULL,
    [SupplierID] decimal(18,0)  NULL,
    [Remark] varchar(max)  NULL,
    [State] varchar(100)  NULL,
    [Brand] varchar(100)  NULL,
    [SalePrice] decimal(18,2)  NULL,
    [ManufacturerCode] varchar(20)  NULL,
    [AgeBracket] decimal(18,0)  NULL,
    [PAID] decimal(18,0)  NOT NULL,
    [Age] nvarchar(50)  NULL,
    [CodeNum] nvarchar(10)  NULL,
    [Color] nvarchar(20)  NULL,
    [Price] decimal(18,2)  NULL
);
GO

-- Creating table 'ProAttribute'
CREATE TABLE [dbo].[ProAttribute] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Color] nvarchar(20)  NULL,
    [CodeNum] nvarchar(10)  NULL,
    [PID] decimal(18,0)  NULL,
    [Age] nvarchar(50)  NULL,
    [Price] decimal(18,2)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RName] nvarchar(32)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [Remark] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'TbStore'
CREATE TABLE [dbo].[TbStore] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Account] nvarchar(50)  NULL,
    [Access_token] nvarchar(200)  NULL,
    [Refresh_token] nvarchar(200)  NULL,
    [CreateTime] datetime  NULL,
    [UID] int  NULL,
    [TaobaoUserId] nvarchar(50)  NULL,
    [W2ExpiresIn] int  NULL,
    [TaobaoUserNick] nvarchar(250)  NULL,
    [W1ExpiresIn] int  NULL,
    [ReExpiresIn] int  NULL,
    [ExpiresIn] int  NULL,
    [TokenType] nvarchar(20)  NULL,
    [R1ExpiresIn] int  NULL,
    [SessionKey] nvarchar(200)  NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [UserPwd] nvarchar(32)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [LastModfiedDate] datetime  NOT NULL,
    [LastLoginTime] datetime  NOT NULL,
    [ErrorCount] int  NOT NULL,
    [Email] nvarchar(128)  NOT NULL,
    [Phone] varchar(32)  NOT NULL,
    [Remark] nvarchar(256)  NOT NULL,
    [Role] int  NOT NULL,
    [EmployeeCode] int  NOT NULL,
    [CreateTime] datetime  NOT NULL
);
GO

-- Creating table 'TbOrderDtl'
CREATE TABLE [dbo].[TbOrderDtl] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Formno] nvarchar(30)  NOT NULL,
    [SKU] nvarchar(60)  NULL,
    [Qty] int  NOT NULL,
    [Cost] decimal(9,2)  NOT NULL,
    [Price] decimal(9,2)  NOT NULL,
    [Uid] int  NOT NULL,
    [Sn] nvarchar(40)  NULL,
    [Delete] bit  NOT NULL,
    [CreateTime] datetime  NULL,
    [PicPath] nvarchar(300)  NULL
);
GO

-- Creating table 'ProductHdr'
CREATE TABLE [dbo].[ProductHdr] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SKU] nvarchar(10)  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Describe] nvarchar(max)  NULL,
    [Delete] bit  NOT NULL,
    [Uid] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [State] nvarchar(max)  NULL,
    [DocID] int  NOT NULL,
    [ManufacturerCode] varchar(20)  NOT NULL,
    [SupplierID] int  NULL,
    [ZImage] nvarchar(200)  NULL,
    [SalePrice] decimal(9,2)  NULL,
    [Cost] decimal(9,2)  NULL,
    [ShippingFee] decimal(9,2)  NULL,
    [GrossWeight] decimal(9,2)  NULL,
    [NetWeight] decimal(9,2)  NULL,
    [CategoryCode] int  NULL,
    [PublishedDate] datetime  NULL
);
GO

-- Creating table 'Supplier'
CREATE TABLE [dbo].[Supplier] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SupplierID] nvarchar(10)  NOT NULL,
    [Linkman] nvarchar(20)  NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(20)  NULL,
    [Remark] nvarchar(2000)  NULL,
    [CreateTime] datetime  NOT NULL,
    [Uid] int  NOT NULL,
    [Delete] bit  NOT NULL,
    [Company] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pvuv'
CREATE TABLE [dbo].[Pvuv] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SKU] nvarchar(20)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [Uid] int  NOT NULL,
    [KeyWord] nvarchar(60)  NOT NULL,
    [Impression] int  NULL,
    [Click] int  NULL,
    [Iuv] int  NULL,
    [Crate] nvarchar(20)  NULL,
    [AlipayNum] int  NULL,
    [Num] int  NULL,
    [puTime] datetime  NULL,
    [Roc] nvarchar(20)  NULL,
    [ClientType] nvarchar(20)  NULL,
    [Account] nvarchar(50)  NULL
);
GO

-- Creating table 'ProductCategory'
CREATE TABLE [dbo].[ProductCategory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FID] int  NULL,
    [Delete] bit  NULL,
    [Active] bit  NULL,
    [Sort] int  NULL,
    [Node] nvarchar(200)  NULL,
    [CreateTime] datetime  NULL,
    [Uid] int  NULL
);
GO

-- Creating table 'BillPurchaseDtl'
CREATE TABLE [dbo].[BillPurchaseDtl] (
    [Sn] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] varchar(10)  NULL,
    [CreateTime] datetime  NOT NULL,
    [Formno] varchar(20)  NOT NULL,
    [RackNo] varchar(10)  NULL,
    [Code] varchar(20)  NULL,
    [Qty] decimal(9,2)  NULL,
    [Leave] decimal(9,2)  NULL,
    [Freeze] decimal(9,2)  NULL,
    [ParentSn] varchar(20)  NULL,
    [Tag] bit  NULL,
    [Price] decimal(9,2)  NULL
);
GO

-- Creating table 'BillPurchaseHdr'
CREATE TABLE [dbo].[BillPurchaseHdr] (
    [Formno] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] int  NULL,
    [CreateTime] datetime  NULL,
    [Checker] int  NULL,
    [CheckDate] datetime  NULL,
    [Description] varchar(2000)  NULL,
    [PFormno] varchar(20)  NULL,
    [State] decimal(18,0)  NULL,
    [SupplierID] varchar(10)  NULL,
    [Department] nvarchar(20)  NULL,
    [ProductManager] nvarchar(20)  NULL,
    [Freight] decimal(18,2)  NULL,
    [CheckState] varchar(50)  NULL
);
GO

-- Creating table 'BillGoodsReceiptDtl'
CREATE TABLE [dbo].[BillGoodsReceiptDtl] (
    [Sn] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] varchar(10)  NULL,
    [CreateTime] datetime  NOT NULL,
    [Formno] varchar(20)  NOT NULL,
    [RackNo] varchar(10)  NULL,
    [Code] varchar(20)  NULL,
    [Qty] decimal(9,2)  NULL,
    [Leave] decimal(9,2)  NULL,
    [Freeze] decimal(9,2)  NULL,
    [ParentSn] varchar(20)  NULL,
    [Tag] bit  NULL,
    [Price] decimal(9,2)  NULL
);
GO

-- Creating table 'BillGoodsReceiptHdr'
CREATE TABLE [dbo].[BillGoodsReceiptHdr] (
    [Formno] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] int  NULL,
    [CreateTime] datetime  NULL,
    [Checker] int  NULL,
    [CheckDate] datetime  NULL,
    [Description] varchar(2000)  NULL,
    [PFormno] varchar(20)  NULL,
    [State] decimal(18,0)  NULL,
    [SupplierID] varchar(10)  NULL,
    [Department] nvarchar(20)  NULL,
    [ProductManager] nvarchar(20)  NULL,
    [Freight] decimal(18,2)  NULL,
    [CheckState] varchar(50)  NULL
);
GO

-- Creating table 'TbOrderHdr'
CREATE TABLE [dbo].[TbOrderHdr] (
    [Formno] nvarchar(30)  NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderId] nvarchar(30)  NULL,
    [BuyerNick] nvarchar(50)  NULL,
    [Uid] int  NULL,
    [Payment] decimal(9,2)  NULL,
    [ReceiverState] nvarchar(25)  NULL,
    [ReceiverCity] nvarchar(25)  NULL,
    [ReceiverDistrict] nvarchar(25)  NULL,
    [ReceiverAddress] nvarchar(150)  NULL,
    [ReceiverZip] nvarchar(25)  NULL,
    [ReceiverMobile] nvarchar(25)  NULL,
    [ReceiverPhone] nvarchar(25)  NULL,
    [CreateTime] datetime  NOT NULL,
    [Delete] bit  NOT NULL,
    [PayTime] datetime  NULL,
    [Status] nvarchar(30)  NULL,
    [TotalPrice] decimal(9,2)  NOT NULL,
    [ShippingFee] decimal(9,2)  NOT NULL,
    [OrderStatus] int  NULL,
    [Account] nvarchar(50)  NULL,
    [AlipayAccount] nvarchar(50)  NULL,
    [ReceiverName] nvarchar(50)  NULL,
    [PicPath] nvarchar(300)  NULL,
    [ReceiverTown] nvarchar(25)  NULL,
    [Type] nvarchar(20)  NULL,
    [TradeFrom] nvarchar(20)  NULL,
    [CreditCardFee] decimal(9,2)  NULL,
    [Flag] nvarchar(20)  NULL,
    [TrackingNo] nvarchar(50)  NULL
);
GO

-- Creating table 'ProjectMenu'
CREATE TABLE [dbo].[ProjectMenu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FID] int  NULL,
    [Delete] bit  NULL,
    [Active] bit  NULL,
    [Sort] int  NULL,
    [Node] nvarchar(200)  NULL,
    [CreateTime] datetime  NULL,
    [Uid] int  NULL,
    [Link] nvarchar(200)  NULL,
    [iconCls] nvarchar(100)  NULL
);
GO

-- Creating table 'TbTraderates'
CREATE TABLE [dbo].[TbTraderates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderId] nvarchar(50)  NULL,
    [Oid] nvarchar(50)  NULL,
    [Role] nvarchar(50)  NULL,
    [Nick] nvarchar(50)  NULL,
    [Result] nvarchar(500)  NULL,
    [Created] datetime  NULL,
    [RatedNick] nvarchar(50)  NULL,
    [ItemTitle] nvarchar(50)  NULL,
    [ItemPrice] decimal(9,2)  NULL,
    [Content] nvarchar(500)  NULL,
    [Reply] nvarchar(500)  NULL,
    [NumIid] nvarchar(50)  NULL,
    [ValidScore] bit  NULL
);
GO

-- Creating table 'ActionGroup'
CREATE TABLE [dbo].[ActionGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(32)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [GroupType] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [URL] nvarchar(256)  NOT NULL,
    [HttpType] smallint  NOT NULL,
    [ActionName] nvarchar(32)  NOT NULL,
    [Remark] nvarchar(256)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Sort] int  NOT NULL,
    [ActionGroupID] int  NOT NULL,
    [ActionGroup_ID] int  NOT NULL
);
GO

-- Creating table 'TbLogisticsCompanies'
CREATE TABLE [dbo].[TbLogisticsCompanies] (
    [Id] int  NULL,
    [AutoID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(30)  NULL,
    [RegMailNo] nvarchar(250)  NULL,
    [Default] int  NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [SKU] varchar(10)  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Delete] bit  NOT NULL,
    [Uid] decimal(18,0)  NULL,
    [CreateTime] datetime  NULL,
    [AttributeID] decimal(18,0)  NULL,
    [Source] varchar(1000)  NULL,
    [GrossWeight] decimal(18,0)  NULL,
    [NetWeight] decimal(18,0)  NULL,
    [Cost] decimal(18,2)  NULL,
    [Remark] varchar(max)  NULL,
    [State] nvarchar(20)  NULL,
    [ManufacturerCode] varchar(20)  NULL,
    [MainImage] varchar(200)  NULL,
    [Brand] varchar(100)  NULL,
    [Color] nvarchar(5)  NULL,
    [SalePrice] decimal(18,2)  NULL,
    [CodeNum] nvarchar(10)  NULL,
    [AgeBracket] decimal(18,0)  NULL,
    [GxQty] int  NULL,
    [SupplierID] int  NULL,
    [ShippingFee] decimal(9,2)  NULL,
    [CategoryID] int  NOT NULL,
    [PublishedDate] datetime  NULL
);
GO

-- Creating table 'BillDeliveryDtl'
CREATE TABLE [dbo].[BillDeliveryDtl] (
    [Sn] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] varchar(10)  NULL,
    [CreateTime] datetime  NOT NULL,
    [Formno] varchar(20)  NOT NULL,
    [RackNo] varchar(10)  NULL,
    [Code] varchar(20)  NULL,
    [Qty] decimal(9,2)  NULL,
    [Leave] decimal(9,2)  NULL,
    [Freeze] decimal(9,2)  NULL,
    [ParentSn] varchar(20)  NULL,
    [Tag] bit  NULL,
    [Price] decimal(9,2)  NULL,
    [OrderFormno] nchar(10)  NULL,
    [OrderDtlID] decimal(18,0)  NULL
);
GO

-- Creating table 'BillDeliveryHdr'
CREATE TABLE [dbo].[BillDeliveryHdr] (
    [Formno] varchar(20)  NOT NULL,
    [WHID] varchar(10)  NOT NULL,
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [Active] bit  NULL,
    [Uid] int  NULL,
    [CreateTime] datetime  NULL,
    [Checker] int  NULL,
    [CheckDate] datetime  NULL,
    [Description] varchar(2000)  NULL,
    [PFormno] varchar(20)  NULL,
    [State] decimal(18,0)  NULL,
    [SupplierID] varchar(10)  NULL,
    [Department] nvarchar(20)  NULL,
    [ProductManager] nvarchar(20)  NULL,
    [Freight] decimal(18,2)  NULL,
    [CheckState] varchar(50)  NULL
);
GO

-- Creating table 'RoleUserInfo'
CREATE TABLE [dbo].[RoleUserInfo] (
    [RoleUser_ID] int  NOT NULL,
    [UserInfo_ID] int  NOT NULL
);
GO

-- Creating table 'ActionInfoRole'
CREATE TABLE [dbo].[ActionInfoRole] (
    [ActionInfo_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Document'
ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [PK_Document]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductDtl'
ALTER TABLE [dbo].[ProductDtl]
ADD CONSTRAINT [PK_ProductDtl]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserManage'
ALTER TABLE [dbo].[UserManage]
ADD CONSTRAINT [PK_UserManage]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AnalysisKeywordsSet'
ALTER TABLE [dbo].[AnalysisKeywordsSet]
ADD CONSTRAINT [PK_AnalysisKeywordsSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HotAttributeSet'
ALTER TABLE [dbo].[HotAttributeSet]
ADD CONSTRAINT [PK_HotAttributeSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BuyersAccount'
ALTER TABLE [dbo].[BuyersAccount]
ADD CONSTRAINT [PK_BuyersAccount]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [PAID] in table 'Page_Product'
ALTER TABLE [dbo].[Page_Product]
ADD CONSTRAINT [PK_Page_Product]
    PRIMARY KEY CLUSTERED ([ID], [PAID] ASC);
GO

-- Creating primary key on [ID] in table 'ProAttribute'
ALTER TABLE [dbo].[ProAttribute]
ADD CONSTRAINT [PK_ProAttribute]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TbStore'
ALTER TABLE [dbo].[TbStore]
ADD CONSTRAINT [PK_TbStore]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TbOrderDtl'
ALTER TABLE [dbo].[TbOrderDtl]
ADD CONSTRAINT [PK_TbOrderDtl]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductHdr'
ALTER TABLE [dbo].[ProductHdr]
ADD CONSTRAINT [PK_ProductHdr]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Supplier'
ALTER TABLE [dbo].[Supplier]
ADD CONSTRAINT [PK_Supplier]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pvuv'
ALTER TABLE [dbo].[Pvuv]
ADD CONSTRAINT [PK_Pvuv]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [PK_ProductCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Sn] in table 'BillPurchaseDtl'
ALTER TABLE [dbo].[BillPurchaseDtl]
ADD CONSTRAINT [PK_BillPurchaseDtl]
    PRIMARY KEY CLUSTERED ([Sn] ASC);
GO

-- Creating primary key on [Formno] in table 'BillPurchaseHdr'
ALTER TABLE [dbo].[BillPurchaseHdr]
ADD CONSTRAINT [PK_BillPurchaseHdr]
    PRIMARY KEY CLUSTERED ([Formno] ASC);
GO

-- Creating primary key on [Sn] in table 'BillGoodsReceiptDtl'
ALTER TABLE [dbo].[BillGoodsReceiptDtl]
ADD CONSTRAINT [PK_BillGoodsReceiptDtl]
    PRIMARY KEY CLUSTERED ([Sn] ASC);
GO

-- Creating primary key on [Formno] in table 'BillGoodsReceiptHdr'
ALTER TABLE [dbo].[BillGoodsReceiptHdr]
ADD CONSTRAINT [PK_BillGoodsReceiptHdr]
    PRIMARY KEY CLUSTERED ([Formno] ASC);
GO

-- Creating primary key on [Formno] in table 'TbOrderHdr'
ALTER TABLE [dbo].[TbOrderHdr]
ADD CONSTRAINT [PK_TbOrderHdr]
    PRIMARY KEY CLUSTERED ([Formno] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectMenu'
ALTER TABLE [dbo].[ProjectMenu]
ADD CONSTRAINT [PK_ProjectMenu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TbTraderates'
ALTER TABLE [dbo].[TbTraderates]
ADD CONSTRAINT [PK_TbTraderates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionGroup'
ALTER TABLE [dbo].[ActionGroup]
ADD CONSTRAINT [PK_ActionGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [AutoID] in table 'TbLogisticsCompanies'
ALTER TABLE [dbo].[TbLogisticsCompanies]
ADD CONSTRAINT [PK_TbLogisticsCompanies]
    PRIMARY KEY CLUSTERED ([AutoID] ASC);
GO

-- Creating primary key on [ID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Sn] in table 'BillDeliveryDtl'
ALTER TABLE [dbo].[BillDeliveryDtl]
ADD CONSTRAINT [PK_BillDeliveryDtl]
    PRIMARY KEY CLUSTERED ([Sn] ASC);
GO

-- Creating primary key on [Formno] in table 'BillDeliveryHdr'
ALTER TABLE [dbo].[BillDeliveryHdr]
ADD CONSTRAINT [PK_BillDeliveryHdr]
    PRIMARY KEY CLUSTERED ([Formno] ASC);
GO

-- Creating primary key on [RoleUser_ID], [UserInfo_ID] in table 'RoleUserInfo'
ALTER TABLE [dbo].[RoleUserInfo]
ADD CONSTRAINT [PK_RoleUserInfo]
    PRIMARY KEY CLUSTERED ([RoleUser_ID], [UserInfo_ID] ASC);
GO

-- Creating primary key on [ActionInfo_ID], [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [PK_ActionInfoRole]
    PRIMARY KEY CLUSTERED ([ActionInfo_ID], [Role_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleUser_ID] in table 'RoleUserInfo'
ALTER TABLE [dbo].[RoleUserInfo]
ADD CONSTRAINT [FK_RoleUserInfo_Role]
    FOREIGN KEY ([RoleUser_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserInfo_ID] in table 'RoleUserInfo'
ALTER TABLE [dbo].[RoleUserInfo]
ADD CONSTRAINT [FK_RoleUserInfo_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUserInfo_UserInfo'
CREATE INDEX [IX_FK_RoleUserInfo_UserInfo]
ON [dbo].[RoleUserInfo]
    ([UserInfo_ID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'ActionInfoRole'
ALTER TABLE [dbo].[ActionInfoRole]
ADD CONSTRAINT [FK_ActionInfoRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoRole_Role'
CREATE INDEX [IX_FK_ActionInfoRole_Role]
ON [dbo].[ActionInfoRole]
    ([Role_ID]);
GO

-- Creating foreign key on [ActionGroup_ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [FK_ActionInfoActionGroup]
    FOREIGN KEY ([ActionGroup_ID])
    REFERENCES [dbo].[ActionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoActionGroup'
CREATE INDEX [IX_FK_ActionInfoActionGroup]
ON [dbo].[ActionInfo]
    ([ActionGroup_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------