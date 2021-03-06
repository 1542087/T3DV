use master
go

if exists (select name from master..sysdatabases where name = 'BankingManagement_ver3')
	drop database BankingManagement_ver3
go

create database BankingManagement_ver3
go

use BankingManagement_ver3
go

create table MSTUSER
(
	PSN_CD decimal,
	--Trung-NM Tu dong zen userid theo manv add new
	USERID varchar(8),
	PASSWD varchar(8),
	--Trung-NM USERNAME nvarchar(80),
	DELETE_YMD datetime,
	INSERT_YMD datetime
	primary key(PSN_CD)
)
go

create table KhachHang
(
	MaKH nvarchar(30),
	cmnd varchar(11),
	TenKH nvarchar(100),
	DiaChi nvarchar(100),
	SoDienThoai varchar(11),
	NgaySinh varchar(10),
	GioiTinh varchar(1)
	primary key(MaKH)
)
go

create table NganHang
(
	MaNH nvarchar(30),
	TenNH nvarchar(100),
	LoaiNH nvarchar(100)
	primary key(MaNH)
)
go

create table NhanVien
(
	--Trung-NM Tao moi nhan vien MaNV lam sao cho tu tang
	MaNV nvarchar(30),
	cmnd int,
	ChucVu nvarchar(10),
	TenNV nvarchar(50),
	CNTrucThuoc nvarchar(30),
	NgayVaoCongTy datetime,
	NgayRaCongTy datetime,
	DiaChi nvarchar(100),
	SoDienThoai int,
	NgaySinh datetime,
	ChuThich nvarchar(200)
	primary key(MaNV)
)
go

create table TaiKhoan
(
	MaTK nvarchar(30),
	SoTK int,
	--add-start ThanhTH
	MaPIN nvarchar(10),
	--add-end
	MaKH nvarchar(30),
	NgayTao datetime,
	NgayHuy datetime,
	MaNV nvarchar(30),
	--Trung-NM add them SoDu
	SoDu decimal,
	MaCN nvarchar(30),
	--add-start ThanhTH
	--SoTien double,
	LoaiTK int,
	--add-end
	ChuThich nvarchar(200)
	primary key(MaTK)
)
go

create table SoTietKiem
(
	MaSTK nvarchar(30),
	MaKH nvarchar(30),
	NgayTao datetime,
	NgayHuy datetime,
	MaNV nvarchar(30),
	MaCN nvarchar(30),
	LoaiTK nvarchar(30),
	SoTien numeric(28,0)
	primary key(MaSTK)
)
go

create table ChiNhanhNganHang
(
	MaCN nvarchar(30),
	LoaiCN nvarchar(30),
	DiaChi nvarchar(100),
	TenCN nvarchar(200),
	DTNoiBo int,
	LoaiNH nvarchar(30),
	ChuThich nvarchar(200)
	primary key(MaCN)
)
go

create table GiaoDich
(
	MaGD nvarchar(30),
	MaKH nvarchar(30),
	--start-delete ThanhTH ko can luu MaKH. cai can luu la taikhoan nao dang giao dich.
	--add-start ThanhTH
	MaTK nvarchar(30),
	--add-end
	SoTien numeric(28,0),
	NgayCapNhat datetime
	primary key(MaGD)
)
go

create table ChiTietGiaoDich
(
	MaGD nvarchar(30),
	MaKH nvarchar(30),--start-delete ThanhTH
	--add-start ThanhTH
	MaTK nvarchar(30),
	--add-end
	NgayGD datetime,
	MaNV nvarchar(30),
	MaCNNH nvarchar(30),
	SoTienGD numeric(28,0),
	NoiDungGD nvarchar(200),
	TrangThai nvarchar(1),
	PhiGD int,
	MaTKNguoiNhan nvarchar(30),
	--add-start ThanhTH loai 1 la RutTien, loai 2 la chuyen tien, loai 3 la nap tien,...
	LoaiGD nvarchar(30),
	--add-end
	primary key(NgayGD,MaKH)
)
go
--add-start ThanhTH
create table KhachHang_TaiKhoan
(
	id int,
	MaKH nvarchar(30),
	MaTK nvarchar(30)
)
--dd-end
go

alter table NhanVien
	add constraint fk_CN_NV foreign key (CNTrucThuoc) references ChiNhanhNganHang (MaCN)

alter table TaiKhoan
	add constraint fk_TK_KH foreign key (MaKH) references KhachHang (MaKH)

alter table TaiKhoan
	add constraint fk_TK_NV foreign key (MaNV) references NhanVien (MaNV)

alter table TaiKhoan
	add constraint fk_TK_CN foreign key (MaCN) references ChiNhanhNganHang (MaCN)

alter table SoTietKiem
	add constraint fk_STK_KH foreign key (MaKH) references KhachHang (MaKH)

alter table SoTietKiem
	add constraint fk_STK_NV foreign key (MaNV) references NhanVien (MaNV)

alter table SoTietKiem
	add constraint fk_STK_CNNH foreign key (MaCN) references ChiNhanhNganHang(MaCN)

alter table ChiNhanhNganHang
	add constraint fk_CNNH_NH foreign key (LoaiNH) references NganHang (MaNH)

alter table ChiTietGiaoDich
	add constraint fk_CTGD_NV foreign key (MaNV) references NhanVien (MaNV)

alter table ChiTietGiaoDich
	add constraint fk_CTGD_CN foreign key (MaCNNH) references ChiNhanhNganHang (MaCN)

alter table ChiTietGiaoDich
	add constraint fk_CTGD_KH foreign key (MaKH) references  KhachHang (MaKH)

alter table ChiTietGiaoDich
	add constraint fk_CTGD_GD foreign key (MaGD) references  GiaoDich (MaGD)
