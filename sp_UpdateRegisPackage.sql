
ALTER PROC [dbo].[sp_UpdateRegisPackage]
@IDUser int,
@IDGoiTap int,
@NgayDK datetime,
@NgayHH datetime,
@GhiChu nvarchar(max),
@Price money,
@Quantity int,
@Total money,
@ID int
AS
declare @result int
Begin tran
	begin try
		update DMDangKyGoiTap set IDUser = @IDUser, IDGoiTap = @IDGoiTap, NgayDangKy = @NgayDK,
			 NgayHetHan =@NgayHH, GhiChu = @GhiChu, Price = @Price, Quantity = @Quantity, Total = @Total
		where ID = @ID
		set @result=@ID
commit tran
	end try
begin catch
set @result=-1
rollback tran
end catch

return @result

