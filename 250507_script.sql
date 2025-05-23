USE [master]
GO
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
/****** Object:  Table [dbo].[Carts]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[catitems_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatItems]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[CatPrices]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatPrices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [int] NOT NULL,
	[date] [date] NOT NULL,
	[catitems_id] [int] NOT NULL,
 CONSTRAINT [PK_CatPrices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatSections]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatSections](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CatSections] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoneStates]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoneStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_DoneStates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdIzm]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdIzm](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_EdIzm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[OrdersItems]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[catitems_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrdersItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentStates]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_PaymentState] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[datefrom] [date] NOT NULL,
	[dateto] [date] NULL,
	[user_id] [int] NOT NULL,
	[donestate_id] [int] NOT NULL,
	[paymentstate_id] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07.05.2025 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([id], [title]) VALUES (1, N'Россия')
INSERT [dbo].[Countries] ([id], [title]) VALUES (1002, N'США')
INSERT [dbo].[Countries] ([id], [title]) VALUES (1003, N'Канада')
INSERT [dbo].[Countries] ([id], [title]) VALUES (1004, N'Швеция')
INSERT [dbo].[Countries] ([id], [title]) VALUES (1005, N'Китай. Все делают в Китае')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[DoneStates] ON 

INSERT [dbo].[DoneStates] ([id], [title]) VALUES (1, N'Новый')
INSERT [dbo].[DoneStates] ([id], [title]) VALUES (2, N'В процессе')
INSERT [dbo].[DoneStates] ([id], [title]) VALUES (3, N'Выполнен')
SET IDENTITY_INSERT [dbo].[DoneStates] OFF
GO
SET IDENTITY_INSERT [dbo].[EdIzm] ON 

INSERT [dbo].[EdIzm] ([id], [title]) VALUES (1, N'шт.')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (2, N'л.')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (3, N'м.')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (4, N'бут.')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (7, N'поллитра')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (1002, N'кубометр')
INSERT [dbo].[EdIzm] ([id], [title]) VALUES (1004, N'тюбик')
SET IDENTITY_INSERT [dbo].[EdIzm] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentStates] ON 

INSERT [dbo].[PaymentStates] ([id], [title]) VALUES (1, N'Не оплачен')
INSERT [dbo].[PaymentStates] ([id], [title]) VALUES (2, N'Оплачен')
SET IDENTITY_INSERT [dbo].[PaymentStates] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([id], [title], [description], [datefrom], [dateto], [user_id], [donestate_id], [paymentstate_id]) VALUES (2, N'Не работает мышь', N'Не работает мышка', CAST(N'2025-03-26' AS Date), CAST(N'2025-03-26' AS Date), 4, 1, 1)
INSERT [dbo].[Requests] ([id], [title], [description], [datefrom], [dateto], [user_id], [donestate_id], [paymentstate_id]) VALUES (3, N'Не работает монитор', N'Сгорел', CAST(N'2025-03-25' AS Date), CAST(N'2025-03-26' AS Date), 5, 1, 1)
INSERT [dbo].[Requests] ([id], [title], [description], [datefrom], [dateto], [user_id], [donestate_id], [paymentstate_id]) VALUES (5, N'Новая заявка', N'Что-то сломалось. Это длинное тестовое описание. Неужели будет такая длинная строка в таблице? Что-то сломалось. Это длинное тестовое описание. Неужели будет такая длинная строка в таблице? ', CAST(N'2025-05-07' AS Date), CAST(N'2025-05-09' AS Date), 3, 1, 1)
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [title]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([id], [title]) VALUES (2, N'Мастер')
INSERT [dbo].[Roles] ([id], [title]) VALUES (3, N'Клиент')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'9111111111', N'admin@mail.ru', N'123', 1)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (2, N'Петров', N'Петр', N'Петрович', N'9222222222', N'manager@mail.ru', N'123', 2)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (3, N'Сидоров', N'Олег', N'Васильевич', N'9333333333', N'client@mail.ru', N'123', 3)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (4, N'1', N'1', N'1', N'1         ', N'1@mail.ru', N'1', 3)
INSERT [dbo].[Users] ([id], [surname], [name], [patronymic], [phone], [email], [password], [role_id]) VALUES (5, N'2', N'2', N'2', N'2         ', N'2@mail.ru', N'2', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
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
REFERENCES [dbo].[PaymentStates] ([id])
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
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_PaymentStates] FOREIGN KEY([paymentstate_id])
REFERENCES [dbo].[PaymentStates] ([id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_PaymentStates]
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
