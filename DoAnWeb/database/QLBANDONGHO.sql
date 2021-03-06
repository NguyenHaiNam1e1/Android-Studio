USE [master]
GO
/****** Object:  Database [QLDONGHO]    Script Date: 12/2/2019 1:47:06 PM ******/
CREATE DATABASE [QLDONGHO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDONGHO', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER1\MSSQL\DATA\QLDONGHO.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLDONGHO_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER1\MSSQL\DATA\QLDONGHO_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLDONGHO] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDONGHO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDONGHO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDONGHO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDONGHO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDONGHO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDONGHO] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDONGHO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLDONGHO] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLDONGHO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDONGHO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDONGHO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDONGHO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDONGHO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDONGHO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDONGHO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDONGHO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDONGHO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLDONGHO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDONGHO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDONGHO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDONGHO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDONGHO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDONGHO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDONGHO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDONGHO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLDONGHO] SET  MULTI_USER 
GO
ALTER DATABASE [QLDONGHO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDONGHO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDONGHO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDONGHO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLDONGHO]
GO
/****** Object:  Table [dbo].[CHITIETDONHANG]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONHANG](
	[MADONHANG] [int] IDENTITY(1,1) NOT NULL,
	[MADH] [int] NOT NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [int] NULL,
 CONSTRAINT [PK_CTDH] PRIMARY KEY CLUSTERED 
(
	[MADONHANG] ASC,
	[MADH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangNhapAmin]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhapAmin](
	[TaiKhoan] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONGHO]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONGHO](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[TenDH] [nvarchar](max) NULL,
	[GiaBan] [money] NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayCapNhat] [datetime] NULL,
	[AnhBia] [nvarchar](max) NULL,
	[SoLuongTon] [int] NULL,
	[MaHA] [int] NULL,
	[XuatXu] [nvarchar](20) NULL,
	[Moi] [int] NULL,
 CONSTRAINT [PK_SP] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MADONHANG] [int] IDENTITY(1,1) NOT NULL,
	[NGAYGIAO] [datetime] NULL,
	[NGAYDAT] [datetime] NULL,
	[DATHANHTOAN] [nvarchar](50) NULL,
	[TINHTRANGGIAO] [int] NULL,
	[MAKH] [int] NULL,
	[TONGTIEN] [int] NULL,
 CONSTRAINT [PK_DH] PRIMARY KEY CLUSTERED 
(
	[MADONHANG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HANG]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANG](
	[MaHA] [int] IDENTITY(1,1) NOT NULL,
	[TenHA] [nvarchar](50) NULL,
 CONSTRAINT [PK_SPw] PRIMARY KEY CLUSTERED 
(
	[MaHA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[GIOITINH] [nvarchar](10) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[SDT] [varchar](40) NULL,
	[EMAIL] [varchar](50) NULL,
	[NGAYSINH] [date] NULL,
	[TAIKHOAN] [nvarchar](50) NULL,
	[MATKHAU] [nvarchar](50) NULL,
 CONSTRAINT [PK_KH] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[TENTK] [nvarchar](30) NULL,
	[MATKHAU] [nvarchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THELOAITIN]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAITIN](
	[MALOAI] [int] IDENTITY(1,1) NOT NULL,
	[TENTHELOAI] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TINTUC]    Script Date: 12/2/2019 1:47:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINTUC](
	[MATIN] [int] IDENTITY(1,1) NOT NULL,
	[MALOAI] [int] NULL,
	[TIEUDETIN] [nvarchar](100) NULL,
	[NOIDUNGTIN] [nvarchar](max) NULL,
	[NGAYDANGTIN] [date] NULL,
	[ANHTIN] [nvarchar](max) NULL,
	[MoiNhat] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MATIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CHITIETDONHANG] ON 

INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (19, 6, 1, 3850000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (20, 7, 1, 3850000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (21, 9, 1, 50000000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (22, 9, 1, 50000000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (23, 8, 1, 37750000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (24, 8, 1, 37750000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (25, 18, 1, 980000000)
INSERT [dbo].[CHITIETDONHANG] ([MADONHANG], [MADH], [SOLUONG], [DONGIA]) VALUES (26, 2, 1, 5390000)
SET IDENTITY_INSERT [dbo].[CHITIETDONHANG] OFF
INSERT [dbo].[DangNhapAmin] ([TaiKhoan], [MatKhau]) VALUES (N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[DONGHO] ON 

INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (2, N'JACQUES LEMANSL2', 5390000.0000, N'Jacques Lemans là hãng sản xuất đồng hồ quốc tế có trụ sở tại Carinthia \ Áo, Jacques Lemans đã tiếp thu được các thành tựu công nghệ mới của ngành chế tạo đồng hồ Thụy Sỹ', CAST(0x0000000000000000 AS DateTime), N'02.PNG', 10, 2, N'Áo', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (3, N'JACQUES 2L', 5000000.0000, N'Jacques Lemans là hãng sản xuất đồng hồ quốc tế có trụ sở tại Carinthia \ Áo, Jacques Lemans đã tiếp thu được các thành tựu công nghệ mới của ngành chế tạo đồng hồ Thụy Sỹ', CAST(0x0000000000000000 AS DateTime), N'03.PNG', 10, 3, N'Áo', 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (4, N'Đông hô Casio', 100000000.0000, N'Jacques Lemans là hãng sản xuất đồng hồ quốc tế có trụ sở tại Carinthia \ Áo, Jacques Lemans đã tiếp thu được các thành tựu công nghệ mới của ngành chế tạo đồng hồ Thụy Sỹ', CAST(0x0000000000000000 AS DateTime), N'04.PNG', 10, 4, N'Áo', 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (5, N'JACQUES 3', 5190000.0000, N'Jacques Lemans là hãng sản xuất đồng hồ quốc tế có trụ sở tại Carinthia \ Áo, Jacques Lemans đã tiếp thu được các thành tựu công nghệ mới của ngành chế tạo đồng hồ Thụy Sỹ', CAST(0x0000000000000000 AS DateTime), N'05.PNG', 10, 5, N'Áo', 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (6, N'ĐỒNG HỒ DIAMOND D DM6305B5', 3850000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'06.PNG', 20, 6, N'Đức', 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (7, N'ĐỒNG HỒ DIAMOND D DM38445', 3850000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'07.PNG', 20, 7, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (8, N'ĐỒNG HỒ DIAMOND DD DM36505IG', 37750000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'08.PNG', 20, 6, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (9, N'ĐỒNG HỒ DIAMOND DD DM5308B5IG', 50000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'09.PNG', 20, 6, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (10, N'ĐỒNG HỒ DIAMOND DDDM3645B5IG-R', 40000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'10.PNG', 20, 5, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (11, N'ĐỒNG HỒ DIAMOND DD DM5308B5IG', 50000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'11.PNG', 20, 5, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (12, N'ĐỒNG HỒ DIAMOND DD DM63175IG', 50000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'12.PNG', 20, 4, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (13, N'ĐỒNG HỒ DIAMOND DDDM3638L5IG-B', 48000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'13.PNG', 20, 3, N'Đức', 2)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (14, N'ĐỒNG HỒ DIAMOND DD DM61195', 525000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'14.PNG', 20, 2, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (15, N'ĐỒNG HỒ DIAMOND DD DM5308B5IG', 50000000.0000, N' Đồng hồ Genuine Diamond có nghĩa là đồng hồ kim cương tự nhiên. Khái niệm này cho biết tất cả những viên đá lấp lánh trên đồng hồ đều là kim cương thật từ thiên nhiên, không phải nhân tạo', CAST(0x0000000000000000 AS DateTime), N'15.PNG', 20, 1, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (16, N'ĐỒNG HỒ ATLANTIC AT-61352.45.21', 8320000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'16.PNG', 20, 4, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (17, N'ĐỒNG HỒ ATLANTIC SWISS AT-60347.45.21', 11000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'17.PNG', 20, 1, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (18, N'ĐỒNG HỒ ATLANTIC SWISS AT-29035.41.21', 980000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'18.PNG', 20, 2, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (19, N'ĐỒNG HỒ ATLANTIC SWISS AT-60347.43.31', 34000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'19.PNG', 20, 6, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (20, N'ĐỒNG HỒ ATLANTIC SWISS AT-60342.45.11', 12000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'20.PNG', 20, 6, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (21, N'ĐỒNG HỒ ATLANTIC SWISS AT-62341.45.31', 36000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'21.PNG', 20, 4, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (22, N'ĐỒNG HỒ ATLANTIC SWISS AT-62455.45.61', 10000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'22.PNG', 20, 2, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (23, N'ĐỒNG HỒ ATLANTIC SWISS AT-50354.45.21', 29000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'23.PNG', 20, 1, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (24, N'ĐỒNG HỒ ATLANTIC SWISS AT-62341.43.31', 19000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'24.PNG', 20, 3, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (25, N'ĐỒNG HỒ ATLANTIC SWISS AT-50354.45.91', 22000000.0000, N' Atlantic khi được thành lập bởi ông Eduard Kummer vào năm 1888 tại Bettlach, Thụy Sĩ. Chúng tôi tự hào có lịch sử lâu đời của hãng đồng hồ mang biểu tượng của Thụy Sỹ.', CAST(0x0000000000000000 AS DateTime), N'25.PNG', 20, 4, N'Đức', 3)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (26, N'1', NULL, N'1', NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (27, N'gt', NULL, N'334r4', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (28, N'1', 3.0000, N'4', CAST(0x00008E5000000000 AS DateTime), N'rf', 23, 2, N'e', 1)
INSERT [dbo].[DONGHO] ([MaDH], [TenDH], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaHA], [XuatXu], [Moi]) VALUES (29, N'2', 1.0000, N'1', CAST(0x0000AB1D00000000 AS DateTime), N'r4', 1, 1, N'rgt', 1)
SET IDENTITY_INSERT [dbo].[DONGHO] OFF
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (1, CAST(0x0000AAEB00000000 AS DateTime), CAST(0x0000AAE900000000 AS DateTime), NULL, NULL, 1, 2300000)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (2, CAST(0x0000AA5F00000000 AS DateTime), CAST(0x0000AA5C00000000 AS DateTime), NULL, NULL, 2, 40000000)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (3, CAST(0x0000AA6900000000 AS DateTime), CAST(0x0000AA6000000000 AS DateTime), NULL, NULL, 3, 14000000)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (4, CAST(0x0000AB2A00000000 AS DateTime), CAST(0x0000AB2900000000 AS DateTime), NULL, NULL, 3, 30000000)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (5, CAST(0x0000AA4100000000 AS DateTime), CAST(0x0000AA4000000000 AS DateTime), NULL, NULL, 4, 32000000)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (6, CAST(0x0000A9C900000000 AS DateTime), CAST(0x0000AB0900B19365 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (7, CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000AB0900B70A2F AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (8, CAST(0x0000A9E700000000 AS DateTime), CAST(0x0000AB0900B7DF52 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (9, CAST(0x0000AB3500000000 AS DateTime), CAST(0x0000AB0900B86247 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (10, CAST(0x0000A9E700000000 AS DateTime), CAST(0x0000AB09014E576E AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (11, CAST(0x0000AB3400000000 AS DateTime), CAST(0x0000AB090152D526 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (12, CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000AB0E00AEB210 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (13, CAST(0x0000A9CA00000000 AS DateTime), CAST(0x0000AB1200F24424 AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[DONHANG] ([MADONHANG], [NGAYGIAO], [NGAYDAT], [DATHANHTOAN], [TINHTRANGGIAO], [MAKH], [TONGTIEN]) VALUES (14, CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000AB1700DFF734 AS DateTime), NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
SET IDENTITY_INSERT [dbo].[HANG] ON 

INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (1, N'Atlantic Swiss')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (2, N'Diamond D')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (3, N'Aries Gold')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (4, N'Jacques Lemon')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (5, N'Epos Swiss')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (6, N'CitiZent')
INSERT [dbo].[HANG] ([MaHA], [TenHA]) VALUES (7, N'Casio')
SET IDENTITY_INSERT [dbo].[HANG] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [GIOITINH], [DIACHI], [SDT], [EMAIL], [NGAYSINH], [TAIKHOAN], [MATKHAU]) VALUES (1, N'NamPRO', N'Nam', N'234 Đường 3 tháng 2', N'0556234212', N'ngotienthanh@gmail.com', CAST(0xB8230B00 AS Date), N'nam', N'nam')
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [GIOITINH], [DIACHI], [SDT], [EMAIL], [NGAYSINH], [TAIKHOAN], [MATKHAU]) VALUES (2, N'Hứa Đăng Khôi', N'Nam', N'342 Hậu Giang , Quận 6 ,TPHCM', N'0226234212', N'dangkhoi@gmail.com', CAST(0xBE230B00 AS Date), N'khoi', N'quanlyphukien')
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [GIOITINH], [DIACHI], [SDT], [EMAIL], [NGAYSINH], [TAIKHOAN], [MATKHAU]) VALUES (3, N'Danh Thị Cẩm Nhung', N'Nam', N'200 Tân Thới Hòa , Quận Tân Phú,TPHCM', N'0126536222', N'camnhung@gmail.com', CAST(0xBA220B00 AS Date), N'nhung', N'quanlyphukien')
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [GIOITINH], [DIACHI], [SDT], [EMAIL], [NGAYSINH], [TAIKHOAN], [MATKHAU]) VALUES (4, N'Trần Thị Văn Lang', N'Nam', N'145 Lê Quang Sung ,TPHCM', N'0774422323', N'LangTran@gmail.com', CAST(0x801D0B00 AS Date), N'lang', N'quanlyphukien')
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [GIOITINH], [DIACHI], [SDT], [EMAIL], [NGAYSINH], [TAIKHOAN], [MATKHAU]) VALUES (5, NULL, N'nam', N'q,097433251', NULL, N'nam1@gmail.com', CAST(0x71400B00 AS Date), NULL, N'nam')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[THELOAITIN] ON 

INSERT [dbo].[THELOAITIN] ([MALOAI], [TENTHELOAI]) VALUES (1, N'Trong Nước')
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENTHELOAI]) VALUES (2, N'Ngoài Nước')
INSERT [dbo].[THELOAITIN] ([MALOAI], [TENTHELOAI]) VALUES (3, N'Trong nhà')
SET IDENTITY_INSERT [dbo].[THELOAITIN] OFF
SET IDENTITY_INSERT [dbo].[TINTUC] ON 

INSERT [dbo].[TINTUC] ([MATIN], [MALOAI], [TIEUDETIN], [NOIDUNGTIN], [NGAYDANGTIN], [ANHTIN], [MoiNhat]) VALUES (2, 1, N'Khá Bảnh', N'Khá Bảnh: Con đường từ “hiện tượng mạng” lệch chuẩn đến bản án 10 năm 6 tháng tù giam', CAST(0x47400B00 AS Date), N'h4.jpg', N'1         ')
INSERT [dbo].[TINTUC] ([MATIN], [MALOAI], [TIEUDETIN], [NOIDUNGTIN], [NGAYDANGTIN], [ANHTIN], [MoiNhat]) VALUES (3, 1, N'TRẦN DẦN ', N'Trần Dần - Tin tức Trần Dần cập nhật đầy đủ và mới nhất trên Báo Người Đưa Tin.', CAST(0x47400B00 AS Date), N'h2.jpg', N'1         ')
INSERT [dbo].[TINTUC] ([MATIN], [MALOAI], [TIEUDETIN], [NOIDUNGTIN], [NGAYDANGTIN], [ANHTIN], [MoiNhat]) VALUES (4, 1, N'Phú Lê', N'ca sĩ Phú Lê , Đọc tin ca sĩ Phú Lê mới nhất', CAST(0x47400B00 AS Date), N'h3.jpg', N'1         ')
INSERT [dbo].[TINTUC] ([MATIN], [MALOAI], [TIEUDETIN], [NOIDUNGTIN], [NGAYDANGTIN], [ANHTIN], [MoiNhat]) VALUES (5, 1, N'Minh Quang', N'Đối tượng bị truy nã gắt gao với tội danh trộm cắp tài sản', CAST(0x47400B00 AS Date), N'h1.PNG', N'1         ')
SET IDENTITY_INSERT [dbo].[TINTUC] OFF
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTDH_SP] FOREIGN KEY([MADH])
REFERENCES [dbo].[DONGHO] ([MaDH])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK_CTDH_SP]
GO
ALTER TABLE [dbo].[DONGHO]  WITH CHECK ADD  CONSTRAINT [FK_DONGHO_HANG] FOREIGN KEY([MaHA])
REFERENCES [dbo].[HANG] ([MaHA])
GO
ALTER TABLE [dbo].[DONGHO] CHECK CONSTRAINT [FK_DONGHO_HANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DH_KH] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DH_KH]
GO
ALTER TABLE [dbo].[TINTUC]  WITH CHECK ADD FOREIGN KEY([MALOAI])
REFERENCES [dbo].[THELOAITIN] ([MALOAI])
GO
USE [master]
GO
ALTER DATABASE [QLDONGHO] SET  READ_WRITE 
GO
