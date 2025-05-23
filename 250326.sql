USE [master]
GO
/****** Object:  Database [CompFirm]    Script Date: 26.03.2025 15:19:57 ******/
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompFirm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompFirm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompFirm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompFirm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompFirm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompFirm] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompFirm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompFirm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompFirm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompFirm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompFirm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompFirm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompFirm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompFirm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompFirm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompFirm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompFirm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompFirm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompFirm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompFirm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompFirm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompFirm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompFirm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompFirm] SET RECOVERY FULL 
GO
ALTER DATABASE [CompFirm] SET  MULTI_USER 
GO
ALTER DATABASE [CompFirm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompFirm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompFirm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompFirm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompFirm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompFirm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CompFirm', N'ON'
GO
ALTER DATABASE [CompFirm] SET QUERY_STORE = ON
GO
ALTER DATABASE [CompFirm] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CompFirm]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[catitems_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatItems]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatItems](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[image] [nvarchar](50) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[quantity] [int] NOT NULL,
	[edizm_id] [int] NOT NULL,
	[catsection_id] [int] NOT NULL,
	[country_id] [int] NOT NULL,
	[producer_id] [int] NOT NULL,
	[supplier_id] [int] NOT NULL,
 CONSTRAINT [PK_CatItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatPrices]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatPrices](
	[id] [int] NOT NULL,
	[price] [int] NOT NULL,
	[date] [date] NOT NULL,
	[catitems_id] [int] NOT NULL,
 CONSTRAINT [PK_CatPrices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatSections]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatSections](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CatSections] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[id] [int] NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoneStates]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoneStates](
	[id] [int] NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_DoneStates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdIzm]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdIzm](
	[id] [int] NOT NULL,
	[title] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_EdIzm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[user_id] [int] NOT NULL,
	[donestate_id] [int] NOT NULL,
	[paymentstate_id] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersItems]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersItems](
	[id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[catitems_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrdersItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentState]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentState](
	[id] [int] NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_PaymentState] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[datefrom] [date] NOT NULL,
	[dateto] [date] NOT NULL,
	[user_id] [int] NOT NULL,
	[donestate_id] [int] NOT NULL,
	[paymentstate_id] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.03.2025 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] NOT NULL,
	[surname] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[patronymic] [nvarchar](30) NOT NULL,
	[phone] [nchar](10) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Roles] ([id], [title]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([id], [title]) VALUES (2, N'Менеджер')
INSERT [dbo].[Roles] ([id], [title]) VALUES (3, N'Клиент')
GO
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (0, N'5', N'5', N'5', N'5         ', N'5@mail.ru', N'5', 3)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'9111111111', N'admin@mail.ru', N'123', 1)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (2, N'Петров', N'Петр', N'Петрович', N'9222222222', N'manager@mail.ru', N'123', 2)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (3, N'Сидоров', N'Олег', N'Васильевич', N'9333333333', N'client@mail.ru', N'123', 3)
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_CatItems] FOREIGN KEY([catitems_id])
REFERENCES [dbo].[CatItems] ([id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_CatItems]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users]
GO
ALTER TABLE [dbo].[CatItems]  WITH CHECK ADD  CONSTRAINT [FK_CatItems_CatSections] FOREIGN KEY([catsection_id])
REFERENCES [dbo].[CatSections] ([id])
GO
ALTER TABLE [dbo].[CatItems] CHECK CONSTRAINT [FK_CatItems_CatSections]
GO
ALTER TABLE [dbo].[CatItems]  WITH CHECK ADD  CONSTRAINT [FK_CatItems_Countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[Countries] ([id])
GO
ALTER TABLE [dbo].[CatItems] CHECK CONSTRAINT [FK_CatItems_Countries]
GO
ALTER TABLE [dbo].[CatItems]  WITH CHECK ADD  CONSTRAINT [FK_CatItems_EdIzm] FOREIGN KEY([edizm_id])
REFERENCES [dbo].[EdIzm] ([id])
GO
ALTER TABLE [dbo].[CatItems] CHECK CONSTRAINT [FK_CatItems_EdIzm]
GO
ALTER TABLE [dbo].[CatItems]  WITH CHECK ADD  CONSTRAINT [FK_CatItems_Producers] FOREIGN KEY([producer_id])
REFERENCES [dbo].[Producers] ([id])
GO
ALTER TABLE [dbo].[CatItems] CHECK CONSTRAINT [FK_CatItems_Producers]
GO
ALTER TABLE [dbo].[CatItems]  WITH CHECK ADD  CONSTRAINT [FK_CatItems_Suppliers] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[Suppliers] ([id])
GO
ALTER TABLE [dbo].[CatItems] CHECK CONSTRAINT [FK_CatItems_Suppliers]
GO
ALTER TABLE [dbo].[CatPrices]  WITH CHECK ADD  CONSTRAINT [FK_CatPrices_CatItems] FOREIGN KEY([catitems_id])
REFERENCES [dbo].[CatItems] ([id])
GO
ALTER TABLE [dbo].[CatPrices] CHECK CONSTRAINT [FK_CatPrices_CatItems]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_DoneStates] FOREIGN KEY([donestate_id])
REFERENCES [dbo].[DoneStates] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_DoneStates]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentState] FOREIGN KEY([paymentstate_id])
REFERENCES [dbo].[PaymentState] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentState]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[OrdersItems]  WITH CHECK ADD  CONSTRAINT [FK_OrdersItems_CatItems] FOREIGN KEY([catitems_id])
REFERENCES [dbo].[CatItems] ([id])
GO
ALTER TABLE [dbo].[OrdersItems] CHECK CONSTRAINT [FK_OrdersItems_CatItems]
GO
ALTER TABLE [dbo].[OrdersItems]  WITH CHECK ADD  CONSTRAINT [FK_OrdersItems_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[OrdersItems] CHECK CONSTRAINT [FK_OrdersItems_Orders]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_DoneStates] FOREIGN KEY([donestate_id])
REFERENCES [dbo].[DoneStates] ([id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_DoneStates]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_PaymentState] FOREIGN KEY([paymentstate_id])
REFERENCES [dbo].[PaymentState] ([id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_PaymentState]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carts'
GO
USE [master]
GO
ALTER DATABASE [CompFirm] SET  READ_WRITE 
GO
