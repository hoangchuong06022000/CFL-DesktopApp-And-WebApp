-- Tao DB
create database TRUNGTAMNGOAINGU
use TRUNGTAMNGOAINGU
-- Tao TABLE cho DB
-- Table THISINH
create table THISINH
(
	CMND char(12) not null, --pk
	HOTEN nvarchar(100) not null,
	GIOITINH nvarchar(3) not null,
	NGAYSINH datetime not null,
	NOISINH nvarchar(100) not null,
	SDT char(10) not null,
	NGAYCAP datetime not null,
	NOICAP nvarchar(100) not null,
	EMAIL nvarchar(100) not null
)
-- Table KHOATHI
create table KHOATHI
(
	MAKHOA char(4) not null, --pk (K001)
	TENKHOA nvarchar(100) not null,
	NGAYTHI datetime not null
)
-- Table PHONGTHI
create table PHONGTHI
(
	MAPHONG char(4) not null, --pk (P001)
	MAKHOA char(4) not null, --fk reference KHOATHI(MAKHOA)
	TENPHONG char(5) not null, -- Ten trinh do +P+ so TT: vi du A2P01, A2P02, B1P03
	TRINHDO char(2) not null, -- (A2 or B1)
	CATHI nvarchar(50) not null
)
-- Table DANGKY
create table DANGKY
(
	CMND char(12) not null, --fk reference CMND(THISINH)
	MAKHOA char(4) not null, --fk reference KHOATHI(MAKHOA)
	TRINHDO char(2) not null
)
-- Table GIAOVIEN
create table GIAOVIEN
(
	MAGV char(5) not null, --pk (GV001)
	MAPHONG char(4) not null, --fk reference PHONGTHI(MAPHONG)
	HOTEN nvarchar(100) not null
)
-- Table DSTHISINHTHEOPHONG
create table DSTHISINHTHEOPHONG
(
	UNIQUEID char(4) not null, --pk (U001)
	CMND char(12) not null, --fk reference CMND(THISINH)
	MAPHONG char(4) not null, --fk reference PHONGTHI(MAPHONG)
	SBD char(5) not null, -- Ten trinh do + so TT: vi du A2001, A2002, B1001, B1002
	DIEMNGHE float,
	DIEMNOI float,
	DIEMDOC float,
	DIEMVIET float
)
-- PK
alter table THISINH add constraint PK_THISINH primary key (CMND)
alter table KHOATHI add constraint PK_KHOATHI primary key (MAKHOA)
alter table PHONGTHI add constraint PK_PHONGTHI primary key (MAPHONG)
alter table GIAOVIEN add constraint PK_GIAOVIEN primary key (MAGV)
alter table DSTHISINHTHEOPHONG add constraint PK_DSTHISINHTHEOPHONG primary key (UNIQUEID)
alter table DANGKY add constraint PK_DANGKY primary key (CMND, MAKHOA)

-- FK
alter table PHONGTHI add constraint FK_PHONGTHI foreign key (MAKHOA) references KHOATHI(MAKHOA)
alter table GIAOVIEN add constraint FK_GIAOVIEN foreign key (MAPHONG) references PHONGTHI(MAPHONG)
alter table DSTHISINHTHEOPHONG add constraint FK_DSTHISINHTHEOPHONG1 foreign key (MAPHONG) references PHONGTHI(MAPHONG)
alter table DSTHISINHTHEOPHONG add constraint FK_DSTHISINHTHEOPHONG2 foreign key (CMND) references THISINH(CMND)
alter table DANGKY add constraint FK_DANGKY1 foreign key (CMND) references THISINH(CMND)
alter table DANGKY add constraint FK_DANGKY2 foreign key (MAKHOA) references KHOATHI(MAKHOA)
-- Insert data
-- THISINH
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072145783465', N'Nguyễn Thùy Chi', N'Nữ', '2002-03-15', N'TP.Hồ Chí Minh', '0321589102', '2017-05-25', N'TP.Hồ Chí Minh', 'thuychi@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072182374584', N'Nguyễn Đức Minh', N'Nam', '2000-06-11', N'TP.Hồ Chí Minh', '0705145202', '2015-08-21', N'TP.Hồ Chí Minh', 'ducminh@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072148376014', N'Nguyễn Tuyết Nhi', N'Nữ', '2001-09-22', N'TP.Hồ Chí Minh', '0934123521', '2016-11-25', N'TP.Hồ Chí Minh', 'tuyetnhi@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072132459731', N'Nguyễn Gia An', N'Nam', '2003-11-20', N'TP.Hồ Chí Minh', '0924151325', '2018-12-22', N'TP.Hồ Chí Minh', 'giaan@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072103502234', N'Phạm Ánh Dương', N'Nữ', '2002-01-11', N'TP.Hồ Chí Minh', '0935120275', '2017-04-06', N'TP.Hồ Chí Minh', 'anhduong@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072177381353', N'Vũ Hà My', N'Nữ', '2000-11-11', N'TP.Hồ Chí Minh', '0351298632', '2015-11-11', N'TP.Hồ Chí Minh', 'hamy@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072243531123', N'Hoàng Vân Khánh', N'Nữ', '2002-01-06', N'TP.Hồ Chí Minh', '0924582906', '2017-01-06', N'TP.Hồ Chí Minh', 'vankhanh@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072158301345', N'Đỗ Thái Dương', N'Nam', '2003-05-16', N'TP.Hồ Chí Minh', '0705643219', '2018-05-16', N'TP.Hồ Chí Minh', 'thaiduong@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072113857182', N'Đỗ Quang Khải', N'Nam', '2001-09-11', N'TP.Hồ Chí Minh', '0399641785', '2016-09-11', N'TP.Hồ Chí Minh', 'quangkhai@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072149502586', N'Đặng Gia Hân', N'Nữ', '2002-10-19', N'TP.Hồ Chí Minh', '0761297518', '2017-10-19', N'TP.Hồ Chí Minh', 'giahan@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072132151233', N'Đặng Trúc Lâm', N'Nam', '2001-10-19', N'TP.Hồ Chí Minh', '0927965634', '2016-10-19', N'TP.Hồ Chí Minh', 'truclam@gmail.com')
insert into THISINH(CMND, HOTEN, GIOITINH, NGAYSINH, NOISINH, SDT, NGAYCAP, NOICAP, EMAIL) values ('072100345812', N'Phạm Hùng Cường', N'am', '2002-10-29', N'TP.Hồ Chí Minh', '0937841679', '2017-10-29', N'TP.Hồ Chí Minh', 'hungcuong@gmail.com')
-- KHOATHI
insert into KHOATHI(MAKHOA, TENKHOA, NGAYTHI) values ('K001', N'Khoá 1', '2021-06-01')
insert into KHOATHI(MAKHOA, TENKHOA, NGAYTHI) values ('K002', N'Khoá 2', '2021-07-01')
insert into KHOATHI(MAKHOA, TENKHOA, NGAYTHI) values ('K003', N'Khoá 3', '2022-02-01')
-- PHONGTHI
insert into PHONGTHI(MAPHONG, MAKHOA, TENPHONG, TRINHDO, CATHI) values ('P001', 'K001', 'A2P01', 'A2', N'Ca sáng')
insert into PHONGTHI(MAPHONG, MAKHOA, TENPHONG, TRINHDO, CATHI) values ('P002', 'K001', 'B1P01', 'B1', N'Ca Chiều')
insert into PHONGTHI(MAPHONG, MAKHOA, TENPHONG, TRINHDO, CATHI) values ('P003', 'K002', 'A2P02', 'A2', N'Ca sáng')
insert into PHONGTHI(MAPHONG, MAKHOA, TENPHONG, TRINHDO, CATHI) values ('P004', 'K002', 'B1P02', 'B1', N'Ca chiều')
-- GIAOVIEN
insert into GIAOVIEN(MAGV, MAPHONG, HOTEN) values ('GV001', 'P001', N'Phạm Diệu Linh')
insert into GIAOVIEN(MAGV, MAPHONG, HOTEN) values ('GV002', 'P002', N'Phạm Hùng Cường')
insert into GIAOVIEN(MAGV, MAPHONG, HOTEN) values ('GV003', 'P003', N'Đỗ Đan Hạ')
insert into GIAOVIEN(MAGV, MAPHONG, HOTEN) values ('GV004', 'P004', N'Đinh Nhã Uyên')
-- DSTHISINHTHEOPHONG
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U001', '072145783465', 'P001', 'A2001', 7.5, 8, 9, 8.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U002', '072182374584', 'P001', 'A2002', 7.8, 9, 9, 8)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U003', '072148376014', 'P001', 'A2003', 7.9, 7.5, 9, 9.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U004', '072132459731', 'P002', 'B1001', 8.5, 8, 9, 10)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U005', '072103502234', 'P002', 'B1002', 9.5, 8.2, 9, 8.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U006', '072177381353', 'P002', 'B1003', 8.3, 9.3, 9, 9.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U007', '072243531123', 'P003', 'A2001', 7.4, 8.7, 9, 7.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U008', '072158301345', 'P003', 'A2002', 8, 8, 9, 6.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U009', '072113857182', 'P003', 'A2003', 7, 8, 9, 8.6)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U010', '072149502586', 'P004', 'B1001', 9.5, 8.1, 9, 9.5)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U011', '072132151233', 'P004', 'B1002', 9, 8.2, 9, 8.9)
insert into DSTHISINHTHEOPHONG(UNIQUEID, CMND, MAPHONG, SBD, DIEMNGHE, DIEMNOI, DIEMDOC, DIEMVIET) values ('U012', '072100345812', 'P004', 'B1003', 9, 8, 9, 8.3)
