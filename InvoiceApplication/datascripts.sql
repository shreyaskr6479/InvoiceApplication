USE [InvoiceApplication]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Electronics', N'this is a Electronics section')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'Furniture', N'this is a Furniture section')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N'Clothing', N'this is a Clothing section')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (1, N'Earphones', N'this is Earphones', CAST(1200.00 AS Decimal(18, 2)), 5, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (2, N'Iphone', N'this is Iphone', CAST(120000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (3, N'watch', N'this is watch', CAST(5000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (4, N'laptop', N'this is laptop', CAST(50000.00 AS Decimal(18, 2)), 3, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (5, N'sofa', N'this is sofa', CAST(18000.00 AS Decimal(18, 2)), 0, 2)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (6, N'cupboard', N'this is cupboard', CAST(12000.00 AS Decimal(18, 2)), 2, 2)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (7, N'table', N'this is table', CAST(8000.00 AS Decimal(18, 2)), 6, 2)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (8, N'shirt', N'this is shirt', CAST(2000.00 AS Decimal(18, 2)), 12, 3)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (9, N'pant', N'this is pant', CAST(3500.00 AS Decimal(18, 2)), 12, 3)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Quantity], [CategoryId]) VALUES (10, N'shoe', N'this is shoe', CAST(6000.00 AS Decimal(18, 2)), 4, 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceItems] ON 

INSERT [dbo].[InvoiceItems] ([Id], [CustomerId], [ProductId], [Quantity], [Discount], [TotalItemPrice]) VALUES (5, 1, 2, 2, CAST(40.00 AS Decimal(18, 2)), CAST(144000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceItems] ([Id], [CustomerId], [ProductId], [Quantity], [Discount], [TotalItemPrice]) VALUES (6, 1, 5, 1, CAST(20.00 AS Decimal(18, 2)), CAST(14400.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[InvoiceItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Email], [Address], [ContactNumber]) VALUES (1, N'Shrey', N'shrey@abc.com', N'mangaluru', N'12345')
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Address], [ContactNumber]) VALUES (2, N'Virat', N'virat@abc.com', N'Delhi', N'23456')
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Address], [ContactNumber]) VALUES (3, N'Rohit', N'rohit@abc.com', N'hyderabad', N'34567')
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Address], [ContactNumber]) VALUES (4, N'Sachin', N'sachin@abc.com', N'mumbai', N'45678')
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Address], [ContactNumber]) VALUES (5, N'king', N'king@abc.com', N'bengaluru', N'56789')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
