use master
go

if exists (select name from master..sysdatabases where name = 'BankingManagement')
	drop database BankingManagement
go

create database BankingManagement
go

use BankingManagement
go

create table MSTUSER
(
	PSN_CD decimal,
	USERID varchar(8),
	PASSWD varchar(8),
	USERNAME nvarchar(80),
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
	MaKH nvarchar(30),
	NgayTao datetime,
	NgayHuy datetime,
	MaNV nvarchar(30),
	MaCN nvarchar(30),
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
	SoTien numeric(28,0),
	NgayCapNhat datetime
	primary key(MaGD)
)
go

create table ChiTietGiaoDich
(
	MaGD nvarchar(30),
	MaKH nvarchar(30),
	NgayGD datetime,
	MaNV nvarchar(30),
	MaCNNH nvarchar(30),
	SoTienGD numeric(28,0),
	NoiDungGD nvarchar(200),
	TrangThai nvarchar(1),
	PhiGD int
	primary key(NgayGD,MaKH)
)
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
