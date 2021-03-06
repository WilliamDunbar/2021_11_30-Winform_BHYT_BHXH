USE [QuanLyNhanSuDB]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNV] [varchar](15) NOT NULL,
	[ngaysinh] [datetime] NULL,
	[maDanToc] [varchar](15) NULL,
	[maTonGiao] [varchar](15) NULL,
	[maTinh] [varchar](15) NULL,
	[maTrinhDo] [varchar](15) NULL,
	[gioiTinh] [nvarchar](5) NULL,
	[dienthoai] [varchar](15) NULL,
	[maHonNhan] [varchar](15) NULL,
	[maChuyenMon] [varchar](15) NULL,
	[diaChi] [nvarchar](100) NULL,
	[tenNV] [nvarchar](70) NULL,
	[hinhAnh] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ThongTinCaNhan]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ThongTinCaNhan] as
select NhanVien.maNV, NhanVien.tenNV,NhanVien.gioiTinh, NhanVien.ngaysinh, NhanVien.dienthoai, NhanVien.diaChi, NhanVien.maChuyenMon, NhanVien.maDanToc, NhanVien.maHonNhan, NhanVien.maTinh, NhanVien.maTonGiao, NhanVien.maTrinhDo
from NhanVien
GO
/****** Object:  Table [dbo].[HopDongLD]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongLD](
	[maHD] [varchar](15) NOT NULL,
	[maNV] [varchar](15) NULL,
	[ghiChu] [nvarchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHopDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHopDong](
	[maHD] [varchar](15) NOT NULL,
	[maLanHD] [varchar](15) NOT NULL,
	[ngayHD] [datetime] NULL,
	[maLHD] [varchar](15) NULL,
	[ngayBD] [datetime] NULL,
	[ngayKT] [datetime] NULL,
	[maPhongBan] [varchar](15) NULL,
	[maChucVu] [varchar](15) NULL,
	[mucLuong] [int] NULL,
	[anTrua] [int] NULL,
	[tongLuong] [int] NULL,
	[nguoiKy] [nvarchar](30) NULL,
	[maChucVuNguoiKy] [varchar](15) NULL,
 CONSTRAINT [HD_id] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC,
	[maLanHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ThongTinHopDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ThongTinHopDong]
AS
SELECT        dbo.ChiTietHopDong.maHD, dbo.HopDongLD.maNV, dbo.ChiTietHopDong.maLanHD, dbo.ChiTietHopDong.ngayBD, dbo.ChiTietHopDong.ngayKT, dbo.ChiTietHopDong.maPhongBan, dbo.ChiTietHopDong.tongLuong, 
                         dbo.ChiTietHopDong.nguoiKy, dbo.ChiTietHopDong.ngayHD, dbo.ChiTietHopDong.anTrua, dbo.ChiTietHopDong.maLHD, dbo.ChiTietHopDong.maChucVu, dbo.ChiTietHopDong.mucLuong, dbo.ChiTietHopDong.maChucVuNguoiKy, 
                         dbo.HopDongLD.ghiChu
FROM            dbo.ChiTietHopDong INNER JOIN
                         dbo.HopDongLD ON dbo.ChiTietHopDong.maHD = dbo.HopDongLD.maHD
GO
/****** Object:  Table [dbo].[SoBHXH]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoBHXH](
	[maBHXH] [varchar](15) NOT NULL,
	[maNV] [varchar](15) NULL,
	[ngayCap] [datetime] NULL,
	[maNoiCap] [varchar](15) NULL,
	[giaTri] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[maBHXH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDongBHXH]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDongBHXH](
	[maBHXH] [varchar](15) NOT NULL,
	[maLanDong] [varchar](15) NOT NULL,
	[thang] [varchar](2) NULL,
	[nam] [varchar](4) NULL,
	[ngayDong] [datetime] NULL,
	[soTien] [float] NULL,
 CONSTRAINT [BHXH_id] PRIMARY KEY CLUSTERED 
(
	[maBHXH] ASC,
	[maLanDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ThongTinBHXH]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ThongTinBHXH]
AS
SELECT        dbo.SoBHXH.maBHXH, dbo.SoBHXH.maNV, dbo.ChiTietDongBHXH.maLanDong, dbo.SoBHXH.ngayCap, dbo.ChiTietDongBHXH.ngayDong, dbo.SoBHXH.giaTri, dbo.ChiTietDongBHXH.soTien, dbo.ChiTietDongBHXH.thang, 
                         dbo.ChiTietDongBHXH.nam, dbo.SoBHXH.maNoiCap
FROM            dbo.SoBHXH INNER JOIN
                         dbo.ChiTietDongBHXH ON dbo.SoBHXH.maBHXH = dbo.ChiTietDongBHXH.maBHXH
GO
/****** Object:  Table [dbo].[SoBHYT]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoBHYT](
	[maBHYT] [varchar](15) NOT NULL,
	[maNV] [varchar](15) NULL,
	[ngayCap] [datetime] NULL,
	[maNoiCap] [varchar](15) NULL,
	[giaTri] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[maBHYT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDongBHYT]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDongBHYT](
	[maBHYT] [varchar](15) NOT NULL,
	[maLanDong] [varchar](15) NOT NULL,
	[thang] [varchar](2) NULL,
	[nam] [varchar](4) NULL,
	[ngayDong] [datetime] NULL,
	[soTien] [float] NULL,
 CONSTRAINT [BHYT_id] PRIMARY KEY CLUSTERED 
(
	[maBHYT] ASC,
	[maLanDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ThongTinBHYT]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ThongTinBHYT]
AS
SELECT        dbo.SoBHYT.maBHYT, dbo.SoBHYT.maNV, dbo.ChiTietDongBHYT.maLanDong, dbo.SoBHYT.ngayCap, dbo.ChiTietDongBHYT.ngayDong, dbo.SoBHYT.giaTri, dbo.ChiTietDongBHYT.soTien, dbo.ChiTietDongBHYT.thang, 
                         dbo.ChiTietDongBHYT.nam, dbo.SoBHYT.maNoiCap
FROM            dbo.SoBHYT INNER JOIN
                         dbo.ChiTietDongBHYT ON dbo.SoBHYT.maBHYT = dbo.ChiTietDongBHYT.maBHYT
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[maChucVu] [varchar](15) NOT NULL,
	[tenChucVu] [nvarchar](50) NULL,
	[phuCapChucVu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenMon]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenMon](
	[maChuyenMon] [varchar](15) NOT NULL,
	[tenChuyenMon] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maChuyenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanToc]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanToc](
	[maDanToc] [varchar](15) NOT NULL,
	[tenDanToc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maDanToc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HonNhan]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HonNhan](
	[maHonNhan] [varchar](15) NOT NULL,
	[tenHonNhan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHonNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHopDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHopDong](
	[maLHD] [varchar](15) NOT NULL,
	[tenLHD] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maLHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoiCap]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoiCap](
	[maNoiCap] [varchar](15) NOT NULL,
	[tenNoiCap] [nvarchar](50) NULL,
	[diaChi] [nvarchar](70) NULL,
	[dienThoai] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[maNoiCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[maPhongBan] [varchar](15) NOT NULL,
	[tenPhongBan] [nvarchar](50) NULL,
	[diaChi] [nvarchar](70) NULL,
	[dienThoai] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[maTk] [varchar](10) NOT NULL,
	[tenDangNhap] [varchar](15) NULL,
	[matKhau] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tinh]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tinh](
	[maTinh] [varchar](15) NOT NULL,
	[tenTinh] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TonGiao]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonGiao](
	[maTonGiao] [varchar](15) NOT NULL,
	[tenTonGiao] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTonGiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrinhDoVH]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoVH](
	[maTrinhDo] [varchar](15) NOT NULL,
	[tenTrinhDo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTrinhDo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDongBHXH]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDo__maBHX__6B24EA82] FOREIGN KEY([maBHXH])
REFERENCES [dbo].[SoBHXH] ([maBHXH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDongBHXH] CHECK CONSTRAINT [FK__ChiTietDo__maBHX__6B24EA82]
GO
ALTER TABLE [dbo].[ChiTietDongBHYT]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDo__maBHY__6A30C649] FOREIGN KEY([maBHYT])
REFERENCES [dbo].[SoBHYT] ([maBHYT])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDongBHYT] CHECK CONSTRAINT [FK__ChiTietDo__maBHY__6A30C649]
GO
ALTER TABLE [dbo].[ChiTietHopDong]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__maLHD__66603565] FOREIGN KEY([maLHD])
REFERENCES [dbo].[LoaiHopDong] ([maLHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHopDong] CHECK CONSTRAINT [FK__ChiTietHo__maLHD__66603565]
GO
ALTER TABLE [dbo].[ChiTietHopDong]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__maPho__6754599E] FOREIGN KEY([maPhongBan])
REFERENCES [dbo].[PhongBan] ([maPhongBan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHopDong] CHECK CONSTRAINT [FK__ChiTietHo__maPho__6754599E]
GO
ALTER TABLE [dbo].[ChiTietHopDong]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHop__maHD__656C112C] FOREIGN KEY([maHD])
REFERENCES [dbo].[HopDongLD] ([maHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHopDong] CHECK CONSTRAINT [FK__ChiTietHop__maHD__656C112C]
GO
ALTER TABLE [dbo].[HopDongLD]  WITH CHECK ADD  CONSTRAINT [FK__HopDongLD__maNV__628FA481] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HopDongLD] CHECK CONSTRAINT [FK__HopDongLD__maNV__628FA481]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maChuy__4D94879B] FOREIGN KEY([maDanToc])
REFERENCES [dbo].[DanToc] ([maDanToc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maChuy__4D94879B]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maChuy__52593CB8] FOREIGN KEY([maChuyenMon])
REFERENCES [dbo].[ChuyenMon] ([maChuyenMon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maChuy__52593CB8]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maHonN__5165187F] FOREIGN KEY([maHonNhan])
REFERENCES [dbo].[HonNhan] ([maHonNhan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maHonN__5165187F]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maTinh__4F7CD00D] FOREIGN KEY([maTinh])
REFERENCES [dbo].[Tinh] ([maTinh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maTinh__4F7CD00D]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maTonG__4E88ABD4] FOREIGN KEY([maTonGiao])
REFERENCES [dbo].[TonGiao] ([maTonGiao])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maTonG__4E88ABD4]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__maTrin__5070F446] FOREIGN KEY([maTrinhDo])
REFERENCES [dbo].[TrinhDoVH] ([maTrinhDo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__maTrin__5070F446]
GO
ALTER TABLE [dbo].[SoBHXH]  WITH CHECK ADD  CONSTRAINT [FK__SoBHXH__maNoiCap__5BE2A6F2] FOREIGN KEY([maNoiCap])
REFERENCES [dbo].[NoiCap] ([maNoiCap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoBHXH] CHECK CONSTRAINT [FK__SoBHXH__maNoiCap__5BE2A6F2]
GO
ALTER TABLE [dbo].[SoBHXH]  WITH CHECK ADD  CONSTRAINT [FK__SoBHXH__maNV__5AEE82B9] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoBHXH] CHECK CONSTRAINT [FK__SoBHXH__maNV__5AEE82B9]
GO
ALTER TABLE [dbo].[SoBHYT]  WITH CHECK ADD  CONSTRAINT [FK__SoBHYT__maNoiCap__5812160E] FOREIGN KEY([maNoiCap])
REFERENCES [dbo].[NoiCap] ([maNoiCap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoBHYT] CHECK CONSTRAINT [FK__SoBHYT__maNoiCap__5812160E]
GO
ALTER TABLE [dbo].[SoBHYT]  WITH CHECK ADD  CONSTRAINT [FK__SoBHYT__maNV__571DF1D5] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoBHYT] CHECK CONSTRAINT [FK__SoBHYT__maNV__571DF1D5]
GO
/****** Object:  StoredProcedure [dbo].[HopDongMoiNhat]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HopDongMoiNhat]
@maNV varchar(10)
as 
begin
	select *
	from ThongTinHopDong t
	where not exists (select maLanHD, maHD, maNV from ThongTinHopDong t2 where (t2.maLanHD>t.maLanHD and t2.maNV = @maNV ) )
end
GO
/****** Object:  StoredProcedure [dbo].[LoadDanhSachHopDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[LoadDanhSachHopDong]
as 
begin
	select HopDongLD.maHD, HopDongLD.maNV, ChiTietHopDong.maLanHD, ChiTietHopDong.maPhongBan, 
	ChiTietHopDong.mucLuong, ChiTietHopDong.tongLuong , ChiTietHopDong.nguoiKy, ChiTietHopDong.ngayBD, ChiTietHopDong.ngayKT
	from HopDongLD left join ChiTietHopDong on HopDongLD.maHD = ChiTietHopDong.maHD

end
GO
/****** Object:  StoredProcedure [dbo].[LoadThongTinBHXH]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LoadThongTinBHXH]
as 
begin
	select *from SoBHXH left join ChiTietDongBHXH on SoBHXH.maBHXH = ChiTietDongBHXH.maBHXH

end
GO
/****** Object:  StoredProcedure [dbo].[LoadThongTinBHYT]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LoadThongTinBHYT]
as 
begin
	select *from SoBHYT left join ChiTietDongBHYT on SoBHYT.maBHYT = ChiTietDongBHYT.maBHYT

end
GO
/****** Object:  StoredProcedure [dbo].[LoadThongTinHopDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LoadThongTinHopDong]
as 
begin
	select *from HopDongLD left join ChiTietHopDong on HopDongLD.maHD = ChiTietHopDong.maHD

end
GO
/****** Object:  StoredProcedure [dbo].[LoadThongTinNhanVien]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LoadThongTinNhanVien]
AS
BEGIN
	select * from NhanVien
END
GO
/****** Object:  StoredProcedure [dbo].[TimKiemBHXH_TheoMaNhanVien]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemBHXH_TheoMaNhanVien]
@maNhanVien varchar(10)
as 
begin
	select *
	from SoBHXH left join ChiTietDongBHXH on SoBHXH.maBHXH = ChiTietDongBHXH.maBHXH
	where maNV like '%' + @maNhanVien +'%'
end

GO
/****** Object:  StoredProcedure [dbo].[TimKiemBHXH_TheoNamDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[TimKiemBHXH_TheoNamDong]
@nam varchar(10)
as 
begin
	select *
	from SoBHXH left join ChiTietDongBHXH on SoBHXH.maBHXH = ChiTietDongBHXH.maBHXH
	where nam like '%' + @nam +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemBHYT_TheoMaNhanVien]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[TimKiemBHYT_TheoMaNhanVien]
@maNhanVien varchar(10)
as 
begin
	select *
	from SoBHYT left join ChiTietDongBHYT on SoBHYT.maBHYT = ChiTietDongBHYT.maBHYT
	where maNV like '%' + @maNhanVien +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemBHYT_TheoNamDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[TimKiemBHYT_TheoNamDong]
@nam varchar(10)
as 
begin
	select *
	from SoBHYT left join ChiTietDongBHYT on SoBHYT.maBHYT = ChiTietDongBHYT.maBHYT
	where nam like '%' + @nam +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemHopDong_TheoLanDong]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemHopDong_TheoLanDong]
@lanDong varchar(10)
as 
begin
	select *
	from HopDongLD left join ChiTietHopDong on HopDongLD.maHD = ChiTietHopDong.maHD
	where maLanHD like '%' + @lanDong +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemHopDong_TheoMaNhanVien]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemHopDong_TheoMaNhanVien]
@maNhanVien varchar(10)
as 
begin
	select *
	from HopDongLD left join ChiTietHopDong on HopDongLD.maHD = ChiTietHopDong.maHD
	where maNV like '%' + @maNhanVien +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemHopDong_TheoMaPhongBan]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemHopDong_TheoMaPhongBan]
@maPhongBan varchar(10)
as 
begin
	select *
	from HopDongLD left join ChiTietHopDong on HopDongLD.maHD = ChiTietHopDong.maHD
	where maPhongBan like '%' + @maPhongBan +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemNhanVien_TheoMa]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemNhanVien_TheoMa]
@TimKiem varchar(10)
as 
begin
	select *from ThongTinCaNhan where maNV like '%'+@TimKiem+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TimKiemNhanVien_TheoTen]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemNhanVien_TheoTen]
@TimKiem varchar(10)
as 
begin
	select *from ThongTinCaNhan where tenNV like '%'+@TimKiem+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[TongLuongMoiNhat]    Script Date: 12/1/2021 4:06:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TongLuongMoiNhat]
@maNV varchar(10), @tongluong int output
as 
begin
	 select @tongluong = tongLuong
	from ThongTinHopDong t
	where not exists (select maLanHD, maHD, maNV from ThongTinHopDong t2 where (t2.maLanHD>t.maLanHD and t2.maNV = @maNV ) )
	print @tongluong
	return
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SoBHXH"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ChiTietDongBHXH"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinBHXH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinBHXH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SoBHYT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ChiTietDongBHYT"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinBHYT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinBHYT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ChiTietHopDong"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HopDongLD"
            Begin Extent = 
               Top = 6
               Left = 270
               Bottom = 119
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinHopDong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ThongTinHopDong'
GO
