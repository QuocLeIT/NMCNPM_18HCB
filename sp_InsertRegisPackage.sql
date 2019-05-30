
Create PROC [dbo].[sp_InsertRegisPackage]
@IDUser int,
@IDGoiTap int,
@NgayDK datetime,
@NgayHH datetime,
@GhiChu nvarchar(max),
@Price money,
@Quantity int,
@Total money
AS
declare @result int
Begin tran
	begin try
		insert into DMDangKyGoiTap(IDUser, IDGoiTap, NgayDangKy, NgayHetHan, GhiChu, Price, Quantity, Total)
		values(@IDUser, @IDGoiTap,@NgayDK, @NgayHH, @GhiChu, @Price, @Quantity, @Total)
		set @result=(select @@Identity)
commit tran
	end try
begin catch
set @result=-1
rollback tran
end catch

return @result

