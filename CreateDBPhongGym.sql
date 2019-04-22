CREATE TABLE DMGoiTap(
   ID int IDENTITY(1,1),
   Name nvarchar(100) not null,
   ThoiGian int not null, -- (Thang)
   GhiChu nvarchar(max),
   PRIMARY KEY(ID)
);

--Loai bao gom: KhachHang, Admin, NhanVien phong gym, NhanVienKyThuat, Huan luyen vien,...
CREATE TABLE DMLoaiUsers(
   ID int IDENTITY(1,1),
   Name nvarchar(100) not null,
   PRIMARY KEY(ID)
);

--La khach hang thi luong = 0
CREATE TABLE DMUserNames(
   ID bigint IDENTITY(1,1),
   Name nvarchar(100) not null,
   NamSinh int,
   DiaChi nvarchar(250),
   Email nvarchar(100),
   Phone nvarchar(20),
   IDLoaiUser int not null,
   Username nvarchar(100),
   Pass nvarchar(100),
   Luong money,
   PRIMARY KEY(ID)
);

--Hinh thuc: sua chua, bao tri, thanh ly thiet bi...
CREATE TABLE DMHinhThuc(
   ID int IDENTITY(1,1),
   Name nvarchar(100) not null,
   PRIMARY KEY(ID)
);


--DANh sach thiet bi
CREATE TABLE DMThietBi(
   ID bigint IDENTITY(1,1),
   Name nvarchar(100) not null,
   Model nvarchar(100),
   Serial nvarchar(100),
   GiaMua money,
   NgayMua datetime,
   BaoHanh int,
   
   CuaHang nvarchar(100),
   DiaChi nvarchar(250),
   HangSX nvarchar(100),
   NuocSX nvarchar(100),
   
   PRIMARY KEY(ID)
);

--Dang ky goi tap, gia han se dang ky them goi tap, hoac tang ngay dung
CREATE TABLE DMDangKyGoiTap(
   ID bigint IDENTITY(1,1),
   IDGoiTap bigint not null,
   IDUser bigint not null,
   NgayDangKy datetime,
   NgayHetHan datetime,
   GhiChu nvarchar(max),
   IsBaoLuu bit default 0,
   NgayBaoLuu datetime,
   ChiPhi money,
   PRIMARY KEY(ID)
);

--bang yeu cau gia han goi tap
CREATE TABLE DMGiaHanGoiTap(
   ID bigint IDENTITY(1,1),
   IDGoiTap bigint not null,
   IDUser bigint not null,
   Ngay datetime,
   ThoiGianGiaHan datetime, -- thang
   ChiPhi money,
   GhiChu nvarchar(max),
   IsXuLu bit,
   IsDuyet bit,
   PRIMARY KEY(ID)
);

--thong tin tap luyen cua khach hang
CREATE TABLE DMTapLuyen_User(
   ID bigint IDENTITY(1,1),
   IDUser bigint not null,
   Ngay datetime,
   ThongTin nvarchar(max),
   DanhGia int, --Thang diem 1-10
   PRIMARY KEY(ID)
);

--Dang ky huan luyen vien
CREATE TABLE DMDangKyHLV(
   ID bigint IDENTITY(1,1),
   IDHLV bigint not null,
   IDUser bigint not null,
   NgayDangKy datetime,
   GhiChu nvarchar(max),
   IsHuy bit default 0,
   ChiPhi money,
   PRIMARY KEY(ID)
);

--lich su sua chua bao tri
--Don sua chua bao tri
CREATE TABLE DMDonSCBT(
   ID bigint IDENTITY(1,1),
   Ngay datetime,
   CuaHang nvarchar(max),
   DiaChi nvarchar(max),
   GhiChu nvarchar(max),
   TongChiPhi money,
   PRIMARY KEY(ID)
);

CREATE TABLE DMDonSCBT_ChiTiet(
   ID bigint IDENTITY(1,1),
   IDDon bigint,
   IDThietBi int not null,
   IDHinhThuc int not null,
   TinhTrangHienTai nvarchar(max),
   TinhTrangSauSuaChua nvarchar(max),
   ChiPhi money,
   BaoHanh int, 
   GhiChu nvarchar(max),
   PRIMARY KEY(ID)
);

ALTER TABLE DMDonSCBT_ChiTiet ADD CONSTRAINT fk_DMDonSCBT_ChiTiet_DMDonSCBT
FOREIGN KEY(IDDon) REFERENCES DMDonSCBT(ID);

ALTER TABLE DMDonSCBT_ChiTiet ADD CONSTRAINT fk_DMDonSCBT_ChiTiet_DMThietBi
FOREIGN KEY(IDThietBi) REFERENCES DMThietBi(ID);

ALTER TABLE DMDonSCBT_ChiTiet ADD CONSTRAINT fk_DMDonSCBT_ChiTiet_DMHinhThuc
FOREIGN KEY(IDHinhThuc) REFERENCES DMHinhThuc(ID);

--

ALTER TABLE DMThietBi_ThanhLy ADD CONSTRAINT fk_DMThietBi_ThanhLy_DMThietBi
FOREIGN KEY(IDThietBi) REFERENCES DMThietBi(ID);

ALTER TABLE DMThietBi_ThanhLy ADD CONSTRAINT fk_DMThietBi_ThanhLy_DMHinhThuc
FOREIGN KEY(IDHinhThuc) REFERENCES DMHinhThuc(ID);

-----------------
ALTER TABLE DMUserNames ADD CONSTRAINT fk_DMUserNames_DMLoaiUsers
FOREIGN KEY(IDLoaiUser) REFERENCES DMLoaiUsers(ID);


ALTER TABLE DMDangKyGoiTap ADD CONSTRAINT fk_DMDangKyGoiTap_DMUserNames
FOREIGN KEY(IDUser) REFERENCES DMUserNames(ID);

ALTER TABLE DMDangKyGoiTap ADD CONSTRAINT fk_DMDangKyGoiTap_DMGoiTap
FOREIGN KEY(IDGoiTap) REFERENCES DMGoiTap(ID);


ALTER TABLE DMDangKyHLV ADD CONSTRAINT fk_DMDangKyHLV_DMUserNames
FOREIGN KEY(IDHLV) REFERENCES DMUserNames(ID);

ALTER TABLE DMDangKyHLV ADD CONSTRAINT fk_DMDangKyHLV_DMUserNames
FOREIGN KEY(IDUser) REFERENCES DMUserNames(ID);

ALTER TABLE DMTapLuyen_User ADD CONSTRAINT fk_DMTapLuyen_User_DMUserNames
FOREIGN KEY(IDUser) REFERENCES DMUserNames(ID);

--Thu phi hoi vien -- (PhieuThu)
CREATE TABLE DMPhiHoiVien(
   ID bigint IDENTITY(1,1),
   Ngay datetime,
   IDUser bigint,
   TienThu money,
   GhiChu nvarchar(max),
   PRIMARY KEY(ID)
);

--Luong nhan vien, huan luyen vien (PhieuXuat)
CREATE TABLE DMPhieuXuatLuongNV(
   ID bigint IDENTITY(1,1),
   Ngay datetime,
   IDNnguoiXuat bigint,
   GhiChu nvarchar(max),
   PRIMARY KEY(ID)
);

CREATE TABLE DMPhieuXuatLuongNV_ChiTiet(
   ID bigint IDENTITY(1,1),
   IDPhieuXuatLuong bigint,
   IDUser,
   Luong money,
   PRIMARY KEY(ID)
);

--lich tap cua phong gym
CREATE TABLE DMLichTapPhongGym(
   ID bigint IDENTITY(1,1),
   Ngay datetime,
   IDNguoiLap bigint,
   PRIMARY KEY(ID)
);

--chi tiet tung ngay tap cai gi, co trong 7 ngay, moi dong du lieu la 1 ngay, va co cac khung gio
CREATE TABLE DMLichTapPhongGym_ChiTiet(
   ID bigint IDENTITY(1,1),
   IDLichTap,
   Sang nvarchar(100),
   Trua nvarchar(100),
   Chieu nvarchar(100),
   Toi nvarchar(100), 
   -- ...
   PRIMARY KEY(ID)
);

