DROP TRIGGER tg_ThemDiem
CREATE TRIGGER tg_ThemDiem ON HocSinh
AFTER INSERT
AS
begin
declare @id int=( SELECT c.IDHS FROM inserted c)
declare @mamh int=(SELECT Count(MaMH) FROM MonHoc)
declare @i int=1
while(@i!=@mamh)
begin
insert into BangDiem values (@id,@i,0,0,0,1)
insert into BangDiem values (@id,@i,0,0,0,2)
set @i=@i+1
end
end
insert into HocSinh ( Ho, Ten, GioiTinh, NgaySinh, DiaChi, Email, Sdt) values ( 'Benito', 'Sauvan', 0, '6/28/2000', '5239 Swallow Plaza', 'bsauvan0@yahoo.com', '3644526347');

declare @i int=0
while(@i!=10)
begin
print(@i)
set @i=@i+1
end