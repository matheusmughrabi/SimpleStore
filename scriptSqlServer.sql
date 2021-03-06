USE [extfactory]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](100) NOT NULL,
	[ParentId] [int] NULL,
	[InsertedAt] [date] NOT NULL,
	[UpdatedAt] [date] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_Category] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerAccounts]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ManagerPermissionsId] [int] NOT NULL,
 CONSTRAINT [PK_ManagerAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerPermissions]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionTitle] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ManagerPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Brand] [nvarchar](100) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[RegularPrice] [decimal](10, 2) NOT NULL,
	[DiscountedPrice] [decimal](10, 2) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[QuantityInStock] [int] NOT NULL,
	[InsertedAt] [date] NOT NULL,
	[UpdatedAt] [date] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](100) NOT NULL,
	[Last_Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Hashed_Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAccounts]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Balance] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_QuantityInStock]  DEFAULT ((0)) FOR [QuantityInStock]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories1] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories1]
GO
ALTER TABLE [dbo].[ManagerAccounts]  WITH CHECK ADD  CONSTRAINT [FK_ManagerAccounts_ManagerPermissions] FOREIGN KEY([ManagerPermissionsId])
REFERENCES [dbo].[ManagerPermissions] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagerAccounts] CHECK CONSTRAINT [FK_ManagerAccounts_ManagerPermissions]
GO
ALTER TABLE [dbo].[ManagerAccounts]  WITH CHECK ADD  CONSTRAINT [FK_ManagerAccounts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagerAccounts] CHECK CONSTRAINT [FK_ManagerAccounts_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[UsersAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAccounts] CHECK CONSTRAINT [FK_UserAccount_Users]
GO
/****** Object:  StoredProcedure [dbo].[spCreateAccount]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateAccount]
	@UserId int
AS
BEGIN
	insert into dbo.UsersAccounts values(@UserId, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateManager]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateManager]
	@UserId int,
	@ManagerPermissionId int,
	@Id int = 0 output
AS
BEGIN
	INSERT INTO dbo.ManagerAccounts VALUES (@UserId, @ManagerPermissionId);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountByUserId]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAccountByUserId]
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.Id, U.Id[UserId], U.First_Name, U.Last_Name, U.Username, A.Balance 
	FROM UsersAccounts AS A
	INNER JOIN Users AS U ON U.Id = A.UserId
	WHERE UserId = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAccounts]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAccounts]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.Id, U.Id[UserId], U.First_Name, U.Last_Name, U.Email, U.Username, A.Balance FROM UsersAccounts AS A
	INNER JOIN Users AS U ON U.Id = A.UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCategories]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCategories]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Categories;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetManagerPermissions]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetManagerPermissions]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.ManagerPermissions
END
GO
/****** Object:  StoredProcedure [dbo].[spGetManagers]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetManagers] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT M.Id, U.Id [UserId], U.First_Name, U.Last_Name, U.Email, U.Username, U.Hashed_Password, P.PermissionTitle
    FROM ManagerAccounts AS M
    INNER JOIN Users AS U ON U.Id = M.UserId
	INNER JOIN ManagerPermissions AS P ON P.Id = M.ManagerPermissionsId
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProducts]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProducts]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Products
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductsByCategory]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProductsByCategory]
	@CategoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Products WHERE CategoryId = @CategoryId;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUsers]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUsers]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Users;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUsersAndTitles]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUsersAndTitles]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT U.Id, U.First_Name, U.Last_Name, U.Email, U.Username, P.PermissionTitle 
	FROM Users AS U
	LEFT JOIN ManagerAccounts AS M ON M.UserId = U.Id
	LEFT JOIN ManagerPermissions AS P ON P.Id = M.ManagerPermissionsId; 
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertCategory]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertCategory]
	@Category nvarchar(100),
	@ParentId int,
	@InsertedAt date,
	@UpdatedAt date,
	@Id int = 0 output
AS
BEGIN
	insert into dbo.Categories values(@Category, @ParentId, @InsertedAt, @UpdatedAt);

	select @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertProduct]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertProduct]
	@Name nvarchar(100),
	@Brand nvarchar(100),
	@CategoryId int,
	@RegularPrice decimal(10, 2),
	@DiscountedPrice decimal(10, 2),
	@Description nvarchar(MAX),
	@QuantityInStock int,
	@InsertedAt date,
	@UpdatedAt date,
	@Id int = 0 output
AS
BEGIN
	insert into dbo.Products 
	values(@Name, @Brand, @CategoryId, @RegularPrice, @DiscountedPrice, @Description,
	       @QuantityInStock, @InsertedAt, @UpdatedAt);

	select @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRegisterUser]
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Email nvarchar(100),
	@Username nvarchar(100),
	@HashedPassword nvarchar(100),
	@Id int = 0 output
AS
BEGIN
	insert into dbo.Users values(@FirstName, @LastName, @Email, @Username, @HashedPassword);

	select @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccountBalance]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateAccountBalance]
    @UserId int,
	@Balance decimal(10,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE UsersAccounts
	SET Balance = @Balance
	Where UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProductQuantityInStock]    Script Date: 30/12/2020 10:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateProductQuantityInStock]
	@Id int,
	@QuantityInStock int,
	@UpdatedAt date
AS
BEGIN
	UPDATE Products
	SET QuantityInStock = @QuantityInStock, UpdatedAt = @UpdatedAt
	WHERE Id = @Id;
END
GO
