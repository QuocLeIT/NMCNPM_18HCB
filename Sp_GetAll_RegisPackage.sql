Create PROC [dbo].[Sp_GetAll_RegisPackage]
AS
select dk.ID, dk.IDGoiTap, dk.IDUser, us.Name as Username, gt.Name as GoiTap, dk.Price, 
	dk.NgayDangKy, dk.Quantity, dk.Total, dk.NgayHetHan, dk.GhiChu
from DMDangKyGoiTap as dk
inner join DMGoiTap as gt on dk.IDGoiTap = gt.ID
inner join DMUserNames as us on dk.IDUser = us.ID
order by dk.NgayDangKy DESC