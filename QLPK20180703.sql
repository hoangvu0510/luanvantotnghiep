USE [master]
GO
/****** Object:  Database [QLPK]    Script Date: 07/03/2018 16:44:56 ******/
CREATE DATABASE [QLPK] ON  PRIMARY 
( NAME = N'QLPK', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QLPK.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPK_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QLPK_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPK] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPK] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLPK] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLPK] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLPK] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLPK] SET ARITHABORT OFF
GO
ALTER DATABASE [QLPK] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLPK] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLPK] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLPK] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLPK] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLPK] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLPK] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLPK] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLPK] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLPK] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLPK] SET  DISABLE_BROKER
GO
ALTER DATABASE [QLPK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLPK] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLPK] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLPK] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLPK] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLPK] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLPK] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLPK] SET  READ_WRITE
GO
ALTER DATABASE [QLPK] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QLPK] SET  MULTI_USER
GO
ALTER DATABASE [QLPK] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLPK] SET DB_CHAINING OFF
GO
USE [QLPK]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VaiTro](
	[IDVaiTro] [int] IDENTITY(1,1) NOT NULL,
	[MaVaiTro] [varchar](50) NULL,
	[TenVaiTro] [nvarchar](200) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ChucVu_1] PRIMARY KEY CLUSTERED 
(
	[IDVaiTro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[VaiTro] ON
INSERT [dbo].[VaiTro] ([IDVaiTro], [MaVaiTro], [TenVaiTro], [TrangThai]) VALUES (1, N'TRO', N'Trống', 1)
INSERT [dbo].[VaiTro] ([IDVaiTro], [MaVaiTro], [TenVaiTro], [TrangThai]) VALUES (2, N'QTR', N'Quản Trị', NULL)
INSERT [dbo].[VaiTro] ([IDVaiTro], [MaVaiTro], [TenVaiTro], [TrangThai]) VALUES (3, N'BSI', N'Bác Sĩ', NULL)
INSERT [dbo].[VaiTro] ([IDVaiTro], [MaVaiTro], [TenVaiTro], [TrangThai]) VALUES (4, N'TNH', N'Tiếp Nhận', NULL)
INSERT [dbo].[VaiTro] ([IDVaiTro], [MaVaiTro], [TenVaiTro], [TrangThai]) VALUES (5, N'TNG', N'Thu Ngân', NULL)
SET IDENTITY_INSERT [dbo].[VaiTro] OFF
/****** Object:  Table [dbo].[Thuoc]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Thuoc](
	[IDThuoc] [int] IDENTITY(1,1) NOT NULL,
	[MaThuoc] [varchar](50) NULL,
	[TenThuoc] [nvarchar](200) NULL,
	[DonViTinh] [nvarchar](200) NULL,
	[DuongDung] [nvarchar](200) NULL,
	[DonGiaThuoc] [decimal](18, 0) NULL,
	[CongDung] [nvarchar](200) NULL,
 CONSTRAINT [PK_Thuoc] PRIMARY KEY CLUSTERED 
(
	[IDThuoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Thuoc] ON
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (1, N'T000000001', N'Thuốc A', N'viên', N'uống', CAST(25000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (2, N'T000000002', N'Thuốc B', N'ống', N'uống', CAST(200000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (3, N'T000000003', N'Thuốc C', N'ống', N'tiêm', CAST(65000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (4, N'T000000004', N'Thuốc D', N'tuýp', N'thoa', CAST(30000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (5, N'T000000005', N'Thuốc E', N'viên', N'uống', CAST(1000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (6, N'T000000006', N'Thuốc F', N'viên', N'uống', CAST(2000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Thuoc] ([IDThuoc], [MaThuoc], [TenThuoc], [DonViTinh], [DuongDung], [DonGiaThuoc], [CongDung]) VALUES (7, N'T000000007', N'Thuốc G', N'viên', N'uống', CAST(3000 AS Decimal(18, 0)), NULL)
SET IDENTITY_INSERT [dbo].[Thuoc] OFF
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[IDLoaiDV] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiDV] [varchar](50) NULL,
	[TenLoaiDV] [nvarchar](200) NULL,
 CONSTRAINT [PK_LoaiDichVu] PRIMARY KEY CLUSTERED 
(
	[IDLoaiDV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiDichVu] ON
INSERT [dbo].[LoaiDichVu] ([IDLoaiDV], [MaLoaiDV], [TenLoaiDV]) VALUES (1, N'KHAMBENH', N'Khám bệnh')
INSERT [dbo].[LoaiDichVu] ([IDLoaiDV], [MaLoaiDV], [TenLoaiDV]) VALUES (2, N'CANLAMSAN', N'Cận lâm sàn')
SET IDENTITY_INSERT [dbo].[LoaiDichVu] OFF
/****** Object:  Table [dbo].[ChuyenKhoa]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChuyenKhoa](
	[IDChuyenKhoa] [int] IDENTITY(1,1) NOT NULL,
	[MaChuyenKhoa] [varchar](50) NULL,
	[TenChuyenKhoa] [nvarchar](200) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[IDChuyenKhoa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] ON
INSERT [dbo].[ChuyenKhoa] ([IDChuyenKhoa], [MaChuyenKhoa], [TenChuyenKhoa]) VALUES (1, N'CKT', N'Trống')
INSERT [dbo].[ChuyenKhoa] ([IDChuyenKhoa], [MaChuyenKhoa], [TenChuyenKhoa]) VALUES (2, N'CKTQ', N'Khoa tổng quát')
INSERT [dbo].[ChuyenKhoa] ([IDChuyenKhoa], [MaChuyenKhoa], [TenChuyenKhoa]) VALUES (3, N'CKNGOAI', N'Khoa ngoại')
INSERT [dbo].[ChuyenKhoa] ([IDChuyenKhoa], [MaChuyenKhoa], [TenChuyenKhoa]) VALUES (4, N'CKNOI', N'Khoa nội')
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] OFF
/****** Object:  Table [dbo].[CaTruc]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CaTruc](
	[IDCaTruc] [int] IDENTITY(1,1) NOT NULL,
	[MaCaTruc] [varchar](50) NULL,
	[TenCaTruc] [nvarchar](100) NULL,
	[ThoiGianBD] [time](7) NULL,
	[ThoiGianKT] [time](7) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_CaTruc] PRIMARY KEY CLUSTERED 
(
	[IDCaTruc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CaTruc] ON
INSERT [dbo].[CaTruc] ([IDCaTruc], [MaCaTruc], [TenCaTruc], [ThoiGianBD], [ThoiGianKT], [TrangThai]) VALUES (1, N'CA1', N'Ca sáng', CAST(0x0700D85EAC3A0000 AS Time), CAST(0x07007870335C0000 AS Time), 1)
INSERT [dbo].[CaTruc] ([IDCaTruc], [MaCaTruc], [TenCaTruc], [ThoiGianBD], [ThoiGianKT], [TrangThai]) VALUES (2, N'CA2', N'Ca chiều', CAST(0x070048F9F66C0000 AS Time), CAST(0x0700E80A7E8E0000 AS Time), 1)
SET IDENTITY_INSERT [dbo].[CaTruc] OFF
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[IDBenhNhan] [int] IDENTITY(1,1) NOT NULL,
	[MaBenhNhan] [varchar](50) NULL,
	[CMND] [varchar](50) NULL,
	[HoTen] [nvarchar](200) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[IDBenhNhan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BenhNhan] ON
INSERT [dbo].[BenhNhan] ([IDBenhNhan], [MaBenhNhan], [CMND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai]) VALUES (1, N'BN000000001', N'12345698765', N'Bệnh nhân số 1', CAST(0x3C3E0B00 AS Date), 1, N'Quận 9', N'0962475096')
INSERT [dbo].[BenhNhan] ([IDBenhNhan], [MaBenhNhan], [CMND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai]) VALUES (2, N'BN000000002', N'1111117654', N'Bệnh nhân số 2', CAST(0xA21D0B00 AS Date), 1, N'Quận Bình Thạnh', N'0989878765')
SET IDENTITY_INSERT [dbo].[BenhNhan] OFF
/****** Object:  Table [dbo].[DichVu]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DichVu](
	[IDDichVu] [int] IDENTITY(1,1) NOT NULL,
	[MaDichVu] [varchar](50) NULL,
	[TenDichVu] [nvarchar](200) NULL,
	[DonGiaDichVu] [decimal](18, 0) NULL,
	[MoTa] [nvarchar](200) NULL,
	[LoaiDichVuID] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DonGiaKham] PRIMARY KEY CLUSTERED 
(
	[IDDichVu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (1, N'KHAMNOI', N'Khám Nội', CAST(150000 AS Decimal(18, 0)), N'', 1, 1)
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (2, N'XNMAU', N'Xét nghiệm máu', CAST(200000 AS Decimal(18, 0)), N'', 2, 1)
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (3, N'KHAMNGOAI', N'Khám ngoại', CAST(120000 AS Decimal(18, 0)), NULL, 1, 1)
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (4, N'KHAMTQ', N'Khám tổng quát', CAST(2000000 AS Decimal(18, 0)), NULL, 1, 1)
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (5, N'SIEUAM', N'Siêu âm', CAST(60000 AS Decimal(18, 0)), NULL, 2, 1)
INSERT [dbo].[DichVu] ([IDDichVu], [MaDichVu], [TenDichVu], [DonGiaDichVu], [MoTa], [LoaiDichVuID], [TrangThai]) VALUES (6, N'CHUPX', N'Chụp X quang', CAST(110000 AS Decimal(18, 0)), NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[DichVu] OFF
/****** Object:  Table [dbo].[NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [varchar](50) NULL,
	[HoTen] [nvarchar](200) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[CMND] [varchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
	[VaiTroID] [int] NULL,
	[MatKhau] [binary](16) NULL,
	[TrangThai] [bit] NULL,
	[HieuLuc] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (1, N'admin', N'admin', CAST(0x1F190B00 AS Date), 1, N'987654321', N'admin', N'0962475096', 2, 0x202CB962AC59075B964B07152D234B70, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (2, N'bhvu', N'Bùi Hoàng Vũ', CAST(0xCE1C0B00 AS Date), 1, N'123456789', N'Quận 8', N'0989999999', 4, 0x202CB962AC59075B964B07152D234B70, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (3, N'khoa', N'Nguyễn Khoa', CAST(0xCB190B00 AS Date), 1, N'024583473', N'Q8', N'01265299196', 5, 0x202CB962AC59075B964B07152D234B70, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (4, N'tn', N'Tên Tiếp Nhận', CAST(0x5C160B00 AS Date), 0, N'123456789', N'HCM', N'0123456789', 2, 0x067DF58264F49A236505689881B25953, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (5, N'thungan', N'Tên Thu Ngân', CAST(0x5C160B00 AS Date), 0, N'123456789', N'HCM', N'0123456789', 5, 0x067DF58264F49A236505689881B25953, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (6, N'tiepnhan', N'Tên Tiếp Nhận', CAST(0x5C160B00 AS Date), 0, N'123456789', N'HCM', N'0123456789', 4, 0x067DF58264F49A236505689881B25953, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (7, N'bacsi1', N'Tên Bác Sĩ 1', CAST(0x5C160B00 AS Date), 1, N'123456789', N'HCM', N'0123456789', 3, 0x202CB962AC59075B964B07152D234B70, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (8, N'bacsi2', N'Tên Bác Sĩ 2', CAST(0x5C160B00 AS Date), 1, N'123456789', N'HCM', N'0123456789', 3, 0x202CB962AC59075B964B07152D234B70, 1, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [DienThoai], [VaiTroID], [MatKhau], [TrangThai], [HieuLuc]) VALUES (9, N'bacsi3', N'Tên Bác Sĩ 3', CAST(0x5C160B00 AS Date), 0, N'123456789', N'HCM', N'0123456789', 3, 0x067DF58264F49A236505689881B25953, 1, 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
/****** Object:  Table [dbo].[PhongKham]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongKham](
	[IDPhongKham] [int] IDENTITY(1,1) NOT NULL,
	[MaPhongKham] [varchar](50) NULL,
	[TenPhongKham] [nvarchar](200) NULL,
	[TrangThai] [bit] NULL,
	[ChuyenKhoaID] [int] NULL,
 CONSTRAINT [PK_PhongKham] PRIMARY KEY CLUSTERED 
(
	[IDPhongKham] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PhongKham] ON
INSERT [dbo].[PhongKham] ([IDPhongKham], [MaPhongKham], [TenPhongKham], [TrangThai], [ChuyenKhoaID]) VALUES (1, N'PKT', N'Trống', 1, 1)
INSERT [dbo].[PhongKham] ([IDPhongKham], [MaPhongKham], [TenPhongKham], [TrangThai], [ChuyenKhoaID]) VALUES (2, N'PKTQ01', N'Phòng số 1', 1, 2)
INSERT [dbo].[PhongKham] ([IDPhongKham], [MaPhongKham], [TenPhongKham], [TrangThai], [ChuyenKhoaID]) VALUES (3, N'PKTQ02', N'Phòng số 2', 1, 3)
INSERT [dbo].[PhongKham] ([IDPhongKham], [MaPhongKham], [TenPhongKham], [TrangThai], [ChuyenKhoaID]) VALUES (4, N'PKTQ03', N'Phòng số 3', 1, 4)
SET IDENTITY_INSERT [dbo].[PhongKham] OFF
/****** Object:  Table [dbo].[CTCNBenhNhan]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTCNBenhNhan](
	[IDCTCNBN] [int] IDENTITY(1,1) NOT NULL,
	[BenhNhanID] [int] NULL,
	[CMND] [varchar](50) NULL,
	[HoTen] [nvarchar](200) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
	[NhanVienID] [int] NULL,
	[NgayCapNhat] [datetime] NULL,
	[HanhDong] [varchar](50) NULL,
	[DuLieuCu] [text] NULL,
 CONSTRAINT [PK_CTCNBenhNhan] PRIMARY KEY CLUSTERED 
(
	[IDCTCNBN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CTCNBenhNhan] ON
INSERT [dbo].[CTCNBenhNhan] ([IDCTCNBN], [BenhNhanID], [CMND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [NhanVienID], [NgayCapNhat], [HanhDong], [DuLieuCu]) VALUES (2, 1, NULL, N'Bệnh nhân số 1', CAST(0x3C3E0B00 AS Date), 1, N'Quận 9', N'0962475096', 1, CAST(0x0000A8E501450D76 AS DateTime), N'SUA', NULL)
INSERT [dbo].[CTCNBenhNhan] ([IDCTCNBN], [BenhNhanID], [CMND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [NhanVienID], [NgayCapNhat], [HanhDong], [DuLieuCu]) VALUES (3, 2, N'1111117654', N'Bệnh nhân số 2', CAST(0xA21D0B00 AS Date), 1, N'Quận Bình Thạnh', N'0989878765', 1, CAST(0x0000A8E5014692D2 AS DateTime), N'THEM', NULL)
INSERT [dbo].[CTCNBenhNhan] ([IDCTCNBN], [BenhNhanID], [CMND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [NhanVienID], [NgayCapNhat], [HanhDong], [DuLieuCu]) VALUES (4, 1, N'12345698765', N'Bệnh nhân số 1', CAST(0x3C3E0B00 AS Date), 1, N'Quận 9', N'0962475096', 1, CAST(0x0000A8E50147B149 AS DateTime), N'SUA', NULL)
SET IDENTITY_INSERT [dbo].[CTCNBenhNhan] OFF
/****** Object:  Table [dbo].[PhieuDKKham]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuDKKham](
	[IDPhieuDKK] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuDKK] [varchar](50) NULL,
	[NgayLap] [datetime] NULL,
	[TrieuChung] [nvarchar](250) NULL,
	[BenhNhanID] [int] NULL,
	[NhanVienLapID] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_PhieuDKKham] PRIMARY KEY CLUSTERED 
(
	[IDPhieuDKK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuDKKham] ON
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (15, N'PDKK000000001', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (16, N'PDKK000000002', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (17, N'PDKK000000003', CAST(0x0000A90000000000 AS DateTime), N'', 2, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (18, N'PDKK000000004', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (19, N'PDKK000000005', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 0)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (20, N'PDKK000000006', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 0)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (21, N'PDKK000000007', CAST(0x0000A90000000000 AS DateTime), N'', 1, 2, 0)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (22, N'PDKK000000008', CAST(0x0000A90000000000 AS DateTime), N'', 2, 2, 0)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (47, N'PDKK000000009', CAST(0x0000A90200000000 AS DateTime), N'dau bụn', 1, 2, 0)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (48, N'PDKK000000010', CAST(0x0000A90200000000 AS DateTime), N'', 1, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (49, N'PDKK000000011', CAST(0x0000A90E012F2EB8 AS DateTime), N'', 2, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (52, N'PDKK000000012', CAST(0x0000A91000BE0100 AS DateTime), N'', 1, 2, NULL)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (54, N'PDKK000000013', CAST(0x0000A91000BF2B05 AS DateTime), N'', 1, 2, NULL)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (55, N'PDKK000000014', CAST(0x0000A91200EA4C46 AS DateTime), N'dau bụn', 2, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (56, N'PDKK000000015', CAST(0x0000A91201026898 AS DateTime), N'aa', 1, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (57, N'PDKK000000016', CAST(0x0000A91201028631 AS DateTime), N'1', 2, 2, 1)
INSERT [dbo].[PhieuDKKham] ([IDPhieuDKK], [MaPhieuDKK], [NgayLap], [TrieuChung], [BenhNhanID], [NhanVienLapID], [TrangThai]) VALUES (58, N'PDKK000000017', CAST(0x0000A9120110391F AS DateTime), N'', 2, 2, 1)
SET IDENTITY_INSERT [dbo].[PhieuDKKham] OFF
/****** Object:  Table [dbo].[LichKham]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LichKham](
	[IDLichKham] [int] IDENTITY(1,1) NOT NULL,
	[MaLichKham] [varchar](50) NULL,
	[NhanVienID] [int] NULL,
	[PhongKhamID] [int] NULL,
	[CaTrucID] [int] NULL,
	[Ngay] [date] NULL,
 CONSTRAINT [PK_LichKham] PRIMARY KEY CLUSTERED 
(
	[IDLichKham] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LichKham] ON
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (0, N'LK000000001', 2, 2, 1, CAST(0x463E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (2, N'LK000000002', 3, 3, 2, CAST(0x4C3E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (3, N'LK000000003', 1, 4, 1, CAST(0x4E3E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (4, N'LK000000004', 7, 4, 2, CAST(0x693E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (5, N'LK000000005', 7, 2, 1, CAST(0x6B3E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (6, N'LK000000006', 8, 3, 2, CAST(0x6B3E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (7, N'LK000000007', 7, 2, 2, CAST(0x6D3E0B00 AS Date))
INSERT [dbo].[LichKham] ([IDLichKham], [MaLichKham], [NhanVienID], [PhongKhamID], [CaTrucID], [Ngay]) VALUES (8, N'LK000000008', 8, 3, 2, CAST(0x6D3E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[LichKham] OFF
/****** Object:  Table [dbo].[CTDKPhongKham]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDKPhongKham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhieuDKKID] [int] NOT NULL,
	[PhongKhamID] [int] NOT NULL,
 CONSTRAINT [PK_CTDKPhongKham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CTDKPhongKham] ON
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (32, 47, 2)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (33, 48, 1)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (34, 49, 4)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (37, 52, 1)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (39, 54, 3)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (40, 55, 2)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (41, 56, 3)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (42, 57, 3)
INSERT [dbo].[CTDKPhongKham] ([ID], [PhieuDKKID], [PhongKhamID]) VALUES (43, 58, 3)
SET IDENTITY_INSERT [dbo].[CTDKPhongKham] OFF
/****** Object:  Table [dbo].[PhieuSDDV]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuSDDV](
	[IDPhieuSDDV] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuSDDV] [varchar](50) NULL,
	[PhieuDKKID] [int] NULL,
	[NgayLap] [datetime] NULL,
	[NhanVienLapID] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_PhieuSDDV] PRIMARY KEY CLUSTERED 
(
	[IDPhieuSDDV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuSDDV] ON
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (44, N'PSDDV000000001', 48, CAST(0x0000A90900000000 AS DateTime), 7, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (45, N'PSDDV000000002', 48, CAST(0x0000A90900000000 AS DateTime), 7, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (46, N'PSDDV000000003', 18, CAST(0x0000A90900000000 AS DateTime), 7, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (47, N'PSDDV000000004', 49, CAST(0x0000A90E012F2EB8 AS DateTime), 2, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (49, N'PSDDV000000005', 52, CAST(0x0000A91000BE0100 AS DateTime), 2, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (51, N'PSDDV000000006', 54, CAST(0x0000A91000BF2B05 AS DateTime), 2, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (52, N'PSDDV000000007', 55, CAST(0x0000A91200EA4C46 AS DateTime), 2, CAST(210000 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (53, N'PSDDV000000008', 56, CAST(0x0000A91201026898 AS DateTime), 2, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (54, N'PSDDV000000009', 57, CAST(0x0000A91201028631 AS DateTime), 2, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (55, N'PSDDV000000010', 58, CAST(0x0000A9120110391F AS DateTime), 2, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (56, N'PSDDV000000011', 58, CAST(0x0000A91201106C36 AS DateTime), 8, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[PhieuSDDV] ([IDPhieuSDDV], [MaPhieuSDDV], [PhieuDKKID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (57, N'PSDDV000000012', 58, CAST(0x0000A91201136A97 AS DateTime), 8, CAST(110000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[PhieuSDDV] OFF
/****** Object:  Table [dbo].[PhieuKhamBenh]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuKhamBenh](
	[IDPhieuKB] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuKB] [varchar](50) NULL,
	[NgayLap] [datetime] NULL,
	[NhanVienLapID] [int] NULL,
	[ChanDoan] [nvarchar](200) NULL,
	[PhieuDKKID] [int] NULL,
 CONSTRAINT [PK_PhieuKhamBenh] PRIMARY KEY CLUSTERED 
(
	[IDPhieuKB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuKhamBenh] ON
INSERT [dbo].[PhieuKhamBenh] ([IDPhieuKB], [MaPhieuKB], [NgayLap], [NhanVienLapID], [ChanDoan], [PhieuDKKID]) VALUES (15, N'PKB000000001', CAST(0x0000A90900000000 AS DateTime), 7, N'ko benh', 15)
INSERT [dbo].[PhieuKhamBenh] ([IDPhieuKB], [MaPhieuKB], [NgayLap], [NhanVienLapID], [ChanDoan], [PhieuDKKID]) VALUES (16, N'PKB000000002', CAST(0x0000A90E012FA828 AS DateTime), 7, N'aaaaa', 49)
INSERT [dbo].[PhieuKhamBenh] ([IDPhieuKB], [MaPhieuKB], [NgayLap], [NhanVienLapID], [ChanDoan], [PhieuDKKID]) VALUES (17, N'PKB000000003', CAST(0x0000A91200FFBF71 AS DateTime), 7, N'a', 55)
SET IDENTITY_INSERT [dbo].[PhieuKhamBenh] OFF
/****** Object:  Table [dbo].[PhieuThu]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuThu](
	[IDPhieuThu] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThu] [varchar](50) NULL,
	[NhanVienLapID] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[NgayLap] [datetime] NULL,
	[PhieuSDDVID] [int] NULL,
 CONSTRAINT [PK_PhieuThu] PRIMARY KEY CLUSTERED 
(
	[IDPhieuThu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuThu] ON
INSERT [dbo].[PhieuThu] ([IDPhieuThu], [MaPhieuThu], [NhanVienLapID], [TongTien], [NgayLap], [PhieuSDDVID]) VALUES (1, N'PT000000001', 3, CAST(150000 AS Decimal(18, 0)), CAST(0x0000A912010F3CB2 AS DateTime), 54)
INSERT [dbo].[PhieuThu] ([IDPhieuThu], [MaPhieuThu], [NhanVienLapID], [TongTien], [NgayLap], [PhieuSDDVID]) VALUES (2, N'PT000000002', 3, CAST(150000 AS Decimal(18, 0)), CAST(0x0000A912010F8B27 AS DateTime), 53)
INSERT [dbo].[PhieuThu] ([IDPhieuThu], [MaPhieuThu], [NhanVienLapID], [TongTien], [NgayLap], [PhieuSDDVID]) VALUES (3, N'PT000000003', 3, CAST(200000 AS Decimal(18, 0)), CAST(0x0000A91201108F27 AS DateTime), 56)
INSERT [dbo].[PhieuThu] ([IDPhieuThu], [MaPhieuThu], [NhanVienLapID], [TongTien], [NgayLap], [PhieuSDDVID]) VALUES (4, N'PT000000004', 3, CAST(150000 AS Decimal(18, 0)), CAST(0x0000A9120110BF15 AS DateTime), 55)
SET IDENTITY_INSERT [dbo].[PhieuThu] OFF
/****** Object:  Table [dbo].[DonThuoc]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonThuoc](
	[IDDonThuoc] [int] IDENTITY(1,1) NOT NULL,
	[MaDonThuoc] [varchar](50) NULL,
	[PhieuKhamBenhID] [int] NULL,
	[NgayLap] [datetime] NULL,
	[NhanVienLapID] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_DonThuoc] PRIMARY KEY CLUSTERED 
(
	[IDDonThuoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DonThuoc] ON
INSERT [dbo].[DonThuoc] ([IDDonThuoc], [MaDonThuoc], [PhieuKhamBenhID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (15, N'DT000000001', 15, NULL, NULL, NULL)
INSERT [dbo].[DonThuoc] ([IDDonThuoc], [MaDonThuoc], [PhieuKhamBenhID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (16, N'DT000000002', 16, CAST(0x0000A90E012FA828 AS DateTime), 7, CAST(25000 AS Decimal(18, 0)))
INSERT [dbo].[DonThuoc] ([IDDonThuoc], [MaDonThuoc], [PhieuKhamBenhID], [NgayLap], [NhanVienLapID], [TongTien]) VALUES (17, N'DT000000003', 17, CAST(0x0000A91200FFBF71 AS DateTime), NULL, CAST(25000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[DonThuoc] OFF
/****** Object:  Table [dbo].[CTDKDichVu]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDKDichVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhieuSDDVID] [int] NOT NULL,
	[DichVuID] [int] NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_CTDKDichVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CTDKDichVu] ON
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (55, 44, 2, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (56, 45, 2, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (57, 46, 2, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (58, 47, 1, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (61, 49, 1, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (64, 51, 1, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (65, 52, 1, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (66, 52, 5, NULL)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (67, 53, 1, 1)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (68, 54, 1, 1)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (69, 55, 1, 1)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (70, 56, 2, 1)
INSERT [dbo].[CTDKDichVu] ([ID], [PhieuSDDVID], [DichVuID], [TrangThai]) VALUES (71, 57, 6, NULL)
SET IDENTITY_INSERT [dbo].[CTDKDichVu] OFF
/****** Object:  Table [dbo].[CTDonThuoc]    Script Date: 07/03/2018 16:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDonThuoc](
	[DonThuocID] [int] NOT NULL,
	[ThuocID] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGiaCTDT] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_CTDonThuoc_1] PRIMARY KEY CLUSTERED 
(
	[DonThuocID] ASC,
	[ThuocID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTDonThuoc] ([DonThuocID], [ThuocID], [SoLuong], [DonGiaCTDT], [ThanhTien]) VALUES (16, 1, 1, CAST(25000 AS Decimal(18, 0)), CAST(25000 AS Decimal(18, 0)))
INSERT [dbo].[CTDonThuoc] ([DonThuocID], [ThuocID], [SoLuong], [DonGiaCTDT], [ThanhTien]) VALUES (16, 2, 22, CAST(222 AS Decimal(18, 0)), CAST(222 AS Decimal(18, 0)))
INSERT [dbo].[CTDonThuoc] ([DonThuocID], [ThuocID], [SoLuong], [DonGiaCTDT], [ThanhTien]) VALUES (17, 1, 1, CAST(25000 AS Decimal(18, 0)), CAST(25000 AS Decimal(18, 0)))
/****** Object:  ForeignKey [FK_DichVu_LoaiDichVu]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_LoaiDichVu] FOREIGN KEY([LoaiDichVuID])
REFERENCES [dbo].[LoaiDichVu] ([IDLoaiDV])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DichVu_LoaiDichVu]
GO
/****** Object:  ForeignKey [FK_NhanVien_VaiTro]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_VaiTro] FOREIGN KEY([VaiTroID])
REFERENCES [dbo].[VaiTro] ([IDVaiTro])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_VaiTro]
GO
/****** Object:  ForeignKey [FK_PhongKham_ChuyenKhoa]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhongKham]  WITH CHECK ADD  CONSTRAINT [FK_PhongKham_ChuyenKhoa] FOREIGN KEY([ChuyenKhoaID])
REFERENCES [dbo].[ChuyenKhoa] ([IDChuyenKhoa])
GO
ALTER TABLE [dbo].[PhongKham] CHECK CONSTRAINT [FK_PhongKham_ChuyenKhoa]
GO
/****** Object:  ForeignKey [FK_CTCNBenhNhan_BenhNhan]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTCNBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_CTCNBenhNhan_BenhNhan] FOREIGN KEY([BenhNhanID])
REFERENCES [dbo].[BenhNhan] ([IDBenhNhan])
GO
ALTER TABLE [dbo].[CTCNBenhNhan] CHECK CONSTRAINT [FK_CTCNBenhNhan_BenhNhan]
GO
/****** Object:  ForeignKey [FK_CTCNBenhNhan_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTCNBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_CTCNBenhNhan_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[CTCNBenhNhan] CHECK CONSTRAINT [FK_CTCNBenhNhan_NhanVien]
GO
/****** Object:  ForeignKey [FK_PhieuDKKham_BenhNhan]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuDKKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDKKham_BenhNhan] FOREIGN KEY([BenhNhanID])
REFERENCES [dbo].[BenhNhan] ([IDBenhNhan])
GO
ALTER TABLE [dbo].[PhieuDKKham] CHECK CONSTRAINT [FK_PhieuDKKham_BenhNhan]
GO
/****** Object:  ForeignKey [FK_PhieuDKKham_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuDKKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDKKham_NhanVien] FOREIGN KEY([NhanVienLapID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[PhieuDKKham] CHECK CONSTRAINT [FK_PhieuDKKham_NhanVien]
GO
/****** Object:  ForeignKey [FK_LichKham_CaTruc]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[LichKham]  WITH CHECK ADD  CONSTRAINT [FK_LichKham_CaTruc] FOREIGN KEY([CaTrucID])
REFERENCES [dbo].[CaTruc] ([IDCaTruc])
GO
ALTER TABLE [dbo].[LichKham] CHECK CONSTRAINT [FK_LichKham_CaTruc]
GO
/****** Object:  ForeignKey [FK_LichKham_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[LichKham]  WITH CHECK ADD  CONSTRAINT [FK_LichKham_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[LichKham] CHECK CONSTRAINT [FK_LichKham_NhanVien]
GO
/****** Object:  ForeignKey [FK_LichKham_PhongKham]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[LichKham]  WITH CHECK ADD  CONSTRAINT [FK_LichKham_PhongKham] FOREIGN KEY([PhongKhamID])
REFERENCES [dbo].[PhongKham] ([IDPhongKham])
GO
ALTER TABLE [dbo].[LichKham] CHECK CONSTRAINT [FK_LichKham_PhongKham]
GO
/****** Object:  ForeignKey [FK_CTDKPhongKham_PhieuDKKham1]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDKPhongKham]  WITH CHECK ADD  CONSTRAINT [FK_CTDKPhongKham_PhieuDKKham1] FOREIGN KEY([PhieuDKKID])
REFERENCES [dbo].[PhieuDKKham] ([IDPhieuDKK])
GO
ALTER TABLE [dbo].[CTDKPhongKham] CHECK CONSTRAINT [FK_CTDKPhongKham_PhieuDKKham1]
GO
/****** Object:  ForeignKey [FK_CTDKPhongKham_PhongKham1]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDKPhongKham]  WITH CHECK ADD  CONSTRAINT [FK_CTDKPhongKham_PhongKham1] FOREIGN KEY([PhongKhamID])
REFERENCES [dbo].[PhongKham] ([IDPhongKham])
GO
ALTER TABLE [dbo].[CTDKPhongKham] CHECK CONSTRAINT [FK_CTDKPhongKham_PhongKham1]
GO
/****** Object:  ForeignKey [FK_PhieuSDDV_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuSDDV]  WITH CHECK ADD  CONSTRAINT [FK_PhieuSDDV_NhanVien] FOREIGN KEY([NhanVienLapID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[PhieuSDDV] CHECK CONSTRAINT [FK_PhieuSDDV_NhanVien]
GO
/****** Object:  ForeignKey [FK_PhieuSDDV_PhieuDKKham]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuSDDV]  WITH CHECK ADD  CONSTRAINT [FK_PhieuSDDV_PhieuDKKham] FOREIGN KEY([PhieuDKKID])
REFERENCES [dbo].[PhieuDKKham] ([IDPhieuDKK])
GO
ALTER TABLE [dbo].[PhieuSDDV] CHECK CONSTRAINT [FK_PhieuSDDV_PhieuDKKham]
GO
/****** Object:  ForeignKey [FK_PhieuKhamBenh_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuKhamBenh]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKhamBenh_NhanVien] FOREIGN KEY([NhanVienLapID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[PhieuKhamBenh] CHECK CONSTRAINT [FK_PhieuKhamBenh_NhanVien]
GO
/****** Object:  ForeignKey [FK_PhieuKhamBenh_PhieuDKKham]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuKhamBenh]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKhamBenh_PhieuDKKham] FOREIGN KEY([PhieuDKKID])
REFERENCES [dbo].[PhieuDKKham] ([IDPhieuDKK])
GO
ALTER TABLE [dbo].[PhieuKhamBenh] CHECK CONSTRAINT [FK_PhieuKhamBenh_PhieuDKKham]
GO
/****** Object:  ForeignKey [FK_PhieuThu_NhanVien]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_NhanVien] FOREIGN KEY([NhanVienLapID])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_NhanVien]
GO
/****** Object:  ForeignKey [FK_PhieuThu_PhieuSDDV]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_PhieuSDDV] FOREIGN KEY([PhieuSDDVID])
REFERENCES [dbo].[PhieuSDDV] ([IDPhieuSDDV])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_PhieuSDDV]
GO
/****** Object:  ForeignKey [FK_DonThuoc_PhieuKhamBenh]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_DonThuoc_PhieuKhamBenh] FOREIGN KEY([PhieuKhamBenhID])
REFERENCES [dbo].[PhieuKhamBenh] ([IDPhieuKB])
GO
ALTER TABLE [dbo].[DonThuoc] CHECK CONSTRAINT [FK_DonThuoc_PhieuKhamBenh]
GO
/****** Object:  ForeignKey [FK_CTDKDichVu_DichVu1]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDKDichVu]  WITH CHECK ADD  CONSTRAINT [FK_CTDKDichVu_DichVu1] FOREIGN KEY([DichVuID])
REFERENCES [dbo].[DichVu] ([IDDichVu])
GO
ALTER TABLE [dbo].[CTDKDichVu] CHECK CONSTRAINT [FK_CTDKDichVu_DichVu1]
GO
/****** Object:  ForeignKey [FK_CTDKDichVu_PhieuSDDV1]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDKDichVu]  WITH CHECK ADD  CONSTRAINT [FK_CTDKDichVu_PhieuSDDV1] FOREIGN KEY([PhieuSDDVID])
REFERENCES [dbo].[PhieuSDDV] ([IDPhieuSDDV])
GO
ALTER TABLE [dbo].[CTDKDichVu] CHECK CONSTRAINT [FK_CTDKDichVu_PhieuSDDV1]
GO
/****** Object:  ForeignKey [FK_CTDonThuoc_DonThuoc]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_CTDonThuoc_DonThuoc] FOREIGN KEY([DonThuocID])
REFERENCES [dbo].[DonThuoc] ([IDDonThuoc])
GO
ALTER TABLE [dbo].[CTDonThuoc] CHECK CONSTRAINT [FK_CTDonThuoc_DonThuoc]
GO
/****** Object:  ForeignKey [FK_CTDonThuoc_Thuoc]    Script Date: 07/03/2018 16:44:56 ******/
ALTER TABLE [dbo].[CTDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_CTDonThuoc_Thuoc] FOREIGN KEY([ThuocID])
REFERENCES [dbo].[Thuoc] ([IDThuoc])
GO
ALTER TABLE [dbo].[CTDonThuoc] CHECK CONSTRAINT [FK_CTDonThuoc_Thuoc]
GO
