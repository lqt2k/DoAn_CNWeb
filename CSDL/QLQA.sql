USE master
CREATE DATABASE QLQA
GO
USE QLQA
go
CREATE TABLE KHACHHANG
(
	MAKH INT IDENTITY(1,1),
	TENKH NVARCHAR(30),
	DIACHI NVARCHAR(30),
	GIOITINH NCHAR(5),
	EMAIL NVARCHAR(30),
	TENDN CHAR(20),
	MATKHAU CHAR(20),
	MALOAITK INT,
	PRIMARY KEY(MAKH)
)
CREATE TABLE LOAITK
(
	MALOAITK INT,
	TENLOATK NVARCHAR(20),
	PRIMARY KEY(MALOAITK)
)
INSERT INTO LOAITK VALUES ('1','ADMIN')
INSERT INTO LOAITK VALUES ('2','KHÁCH HÀNG')
ALTER TABLE KHACHHANG
ADD CONSTRAINT FK_KH_LOAITK FOREIGN KEY(MALOAITK) REFERENCES LOAITK(MALOAITK)

INSERT INTO KHACHHANG(TENKH, DIACHI, GIOITINH, EMAIL, TENDN, MATKHAU,MALOAITK)
VALUES(N'Lê Quang Trung',N'TP.HCM',N'Nam','trung@gmail.com','trung','123','2')

INSERT INTO KHACHHANG(TENKH, DIACHI, GIOITINH, EMAIL, TENDN, MATKHAU,MALOAITK)
VALUES(N'Nguyễn Văn Đô',N'TP.HCM',N'Nam','donguyen412@gmail.com','do','123','1')


CREATE TABLE LOAI
(
	MALOAI INT,
	TENLOAI NVARCHAR(50)
	PRIMARY KEY(MALOAI)
)
INSERT INTO LOAI VALUES(1,N'T-Shirts & Polos')
INSERT INTO LOAI VALUES(2,N'Hoodies')
INSERT INTO LOAI VALUES(3,N'Backpacks')
INSERT INTO LOAI VALUES(4,N'Accessories')
INSERT INTO LOAI VALUES(5,N'Pants & Shorts')
INSERT INTO LOAI VALUES(6,N'Jackets')
SELECT * FROM LOAI
CREATE TABLE NHASANXUAT
(
	MANSX INT,
	TENNSX NVARCHAR (30),
	PRIMARY KEY(MANSX)
)
INSERT INTO NHASANXUAT  VALUES (100, N'Ralph Lauren')
INSERT INTO NHASANXUAT VALUES (101, N'Brooks Brother')
INSERT INTO NHASANXUAT VALUES (102, N'Zara')
INSERT INTO NHASANXUAT VALUES (103, N'Guess')
INSERT INTO NHASANXUAT VALUES (104, N'H&M')
INSERT INTO NHASANXUAT VALUES (105, N'Calvin Klein')
INSERT INTO NHASANXUAT VALUES (106, N'J.Crew')
INSERT INTO NHASANXUAT VALUES (107, N'Topman')
INSERT INTO NHASANXUAT VALUES (108, N'Gucci')
INSERT INTO NHASANXUAT VALUES (109, N'Kenneth Cole')

CREATE TABLE SANPHAM
(
	MASP INT IDENTITY(1,1),
	TENSP NVARCHAR(50),
	MOTA NVARCHAR(1000),
	DONGIA FLOAT,
	HINHANH NVARCHAR(30),
	MALOAI INT,
	MANSX INT,
	PRIMARY KEY(MASP)
)
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SP_LOAI FOREIGN KEY(MALOAI) REFERENCES LOAI(MALOAI)
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_NSX_SP FOREIGN KEY(MANSX) REFERENCES NHASANXUAT(MANSX)

INSERT INTO SANPHAM VALUES(N'MONARCH BUTTERFLY T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo. Logo được thêu ở tay áo',400000,N'ts01.png',1,100)
INSERT INTO SANPHAM VALUES(N'GRYNCH T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',259000,N'ts02.png',1,100)
INSERT INTO SANPHAM VALUES(N'SPACE PROGRAM T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',290000,N'ts03.png',1,100)
INSERT INTO SANPHAM VALUES(N'IM HAPPY T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',350000,N'ts04.png',1,101)
INSERT INTO SANPHAM VALUES(N'HOLOGRAM MERCURY TIE-DYE T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',450000,N'ts05.png',1,101)
INSERT INTO SANPHAM VALUES(N'POLO ACADEMY',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',390000,N'ts06.png',1,101)
INSERT INTO SANPHAM VALUES(N'ACADEMY DCS T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',350000,N'ts07.png',1,102)
INSERT INTO SANPHAM VALUES(N'DIRTYCOINS BASIC CASUAL T-SHIRT',N'Sản phẩm 100% cotton. Form áo cơ bản. Hình in được in lên trước ngực và lưng áo.',190000,N'ts08.png',1,102)

INSERT INTO SANPHAM VALUES(N'HOODIE BIG LOGO SEASON 2020',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',549000,N'hd01.png',2,103)
INSERT INTO SANPHAM VALUES(N'SOTY HOODIE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',650000,N'hd02.png',2,103)
INSERT INTO SANPHAM VALUES(N'HOODIES TIE-DYE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',700000,N'hd03.png',2,104)
INSERT INTO SANPHAM VALUES(N'UNICORN HOODIE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',550000,N'hd04.png',2,104)
INSERT INTO SANPHAM VALUES(N'DIRTY COINS ANGEL HOODIE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',250000,N'hd05.png',2,105)
INSERT INTO SANPHAM VALUES(N'BREAKING NEWS HD',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',349000,N'hd06.png',2,105)
INSERT INTO SANPHAM VALUES(N'GRYNCH HOODIE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',290000,N'hd07.png',2,105)
INSERT INTO SANPHAM VALUES(N'ACADEMY ZIPPED HOODIE',N'Form áo oversize. Phần nón áo được trang bị dây rút. Họa tiết được in ở mặt trước và mặt sau. Áo có 2 túi ở hai bên hông áo. Ống tay có khóa dán velcro và được thêu logo.',349000,N'hd08.png',2,105)

INSERT INTO SANPHAM VALUES(N'LOGO PATTERN BACKPACK - BLACK',N'Balo được làm từ da P.U được lót dù phía trong balo. Balo sỡ hữu đến 8 ngăn đựng. Họa tiết được in và khâu trực tiếp lên bề mặt. Quai đeo có thể tùy chỉnh độ dài.Kích thước balo: Dài x Rộng x Cao: 35cm x 15cm x 44cm',800000,N'pb01.png',3,105)
INSERT INTO SANPHAM VALUES(N'ACADEMY BACKPACK',N'Balo được làm từ da P.U được lót dù phía trong balo. Balo sỡ hữu đến 8 ngăn đựng. Họa tiết được in và khâu trực tiếp lên bề mặt. Quai đeo có thể tùy chỉnh độ dài. 1 Ngăn sở hữu mặt ngoài làm từ nhựa trong suốt. Kích thước balo: Dài x Rộng x Cao: 35cm x 15cm x 44cm',700000,N'pb02.png',3,105)
INSERT INTO SANPHAM VALUES(N'DIRTY COINS ANGEL BACKPACK',N'Mặt ngoài balo được làm từ vải bố, kèm với phía trong được lót dù. Mặt trước balo được in hình, có độ bền cao. Balo có 1 ngăn chính và 1 ngăn phụ phía mặt trước balo. Hai ngăn đựng bình nước tiện dụng ở hai bên hông balo. Kích thước balo: Dài x Rộng x Cao: 34cm x 17cm x 43cm',500000,N'pb03.png',3,106)
INSERT INTO SANPHAM VALUES(N'SPACE PROGRAM ASTRO BACKPACK',N'Mặt ngoài balo được làm từ vải bố, kèm với phía trong được lót dù. Mặt trước balo được in hình, có độ bền cao.',730000,N'pb04.png',3,106)
INSERT INTO SANPHAM VALUES(N'SPACE PROGRAM CROSS BAG',N' Toàn bộ thân túi được dùng vải canvas Korea. Phần miệng túi kết hợp nắp mở với velcro kèm zipper, Phần ngăn phụ trước túi được gia công vải lưới. Dây đeo có thể tùy chỉnh độ dài và có phản quang',349000,N'pb05.png',3,106)
INSERT INTO SANPHAM VALUES(N'THE SPHYNX PYRAMID BACKPACK',N'Mặt ngoài balo được làm từ vải bố, kèm với phía trong được lót dù. Mặt trước balo được in hình, có độ bền cao. Balo có 1 ngăn chính và 1 ngăn phụ phía mặt trước balo. Hai ngăn đựng bình nước tiện dụng ở hai bên hông balo. Kích thước balo: Dài x Rộng x Cao: 34cm x 17cm x 43cm',390000,N'pb06.png',3,106)
INSERT INTO SANPHAM VALUES(N'MINI-UZI CROSSBODY BAGS',N'Sản phẩm được làm từ vải dù. Túi có 1 ngăn lớn và 1 ngăn phụ trang bị khóa zip YKK. Dây đeo có thể tùy chỉnh độ dài. Kích thước: Dài x Rộng x Cao = 20cm x 5cm x 25cm',299000,N'pb07.png',3,106)
INSERT INTO SANPHAM VALUES(N'DIRTYCOINS MINI CROSSBODY BAGS',N'Chất liệu túi làm từ vải bố,1 Ngăn lớn, 1 ngăn nhỏ. Dây đeo không tháo rời (có thể tùy chỉnh độ dài). Tag cao su được may trực tiếp vào túi. Kích thước sản phẩm : Cao 30cm/Ngang 24cm/Dày 11cm. Kích thước dây đeo: 60cm-120cm (tùy chỉnh)',299000,N'pb08.png',3,107)

INSERT INTO SANPHAM VALUES(N'DIRTYCOINS WALLY WALLET',N'Ví được làm từ vải canvas. Lót bên trong ví được sử dụng từ dù và vải canvas. Logo Y được in trực tiếp lên bề mặt. Ví đóng mở có khóa bấm an toàn. Ví có 2 ngăn chính, có khóa kéo cho 1 ngăn. Số lượng ngăn đựng thẻ lên đến 8 ngăn. Kích thước mở: Dài x Rộng x Cao: 22cm x 0.8~2.2cm x 9cm',290000,N'as01.png',4,107)
INSERT INTO SANPHAM VALUES(N'DIRTYCOINS HEADBAND - BLACK',N'Sản phẩm được làm từ cotton nhập khẩu - Tag cao su được thêu trực tiếp lên sản phẩm - Free size',143900,N'as02.png',4,106)
INSERT INTO SANPHAM VALUES(N'SIGNATURE Y ZIPPED WALLET',N'Ví được gia công từ da P.U nhập khẩu. Lót bên trong ví được sử dụng từ dù và da P.U. Logo Y được khắc laser. Zipper vòng quanh miệng ví. 1 ngăn phụ bên trong có khóa zipper. Số lượng ngăn đựng lên đến 12 ngăn. Kích thước trong 200x20x90 (mm)',275000,N'as03.png',4,107)
INSERT INTO SANPHAM VALUES(N'CROCS SHORT WALLET',N' Ví tiền vuông - Mặt ngoài ví với logo được ép chìm và bề mặt được ép nhiệt tạo hiệu ứng. Ví có 3 ngăn đựng tiền chính với 1 ngăn có khóa zip cùng 6 khe đựng thẻ. Kích thước đóng: Cao x Rộng x Sâu: 12 x 9.5 x 2 cm',190000,N'as04.png',4,107)
INSERT INTO SANPHAM VALUES(N'CROCS LONG WALLET',N'Ví tiền dài đóng mở - Mặt ngoài ví với logo được ép chìm và bề mặt được ép nhiệt tạo hiệu ứng. Ví có 2 ngăn lớn, 9 khe đựng thẻ và 2 ngăn đựng giấy tờ. Kích thước đóng: Cao x Rộng x Sâu: 18.5 x 8.5 x 2 cm',600000,N'as05.png',4,107)
INSERT INTO SANPHAM VALUES(N'SPRING OF THE Y SOCKS',N'Tất được làm từ chất liệu 100% cotton',90000,N'as06.png',4,107)
INSERT INTO SANPHAM VALUES(N'BASIC BEANIES',N'Nón được dệt từ sợi Len và nỉ. Tag cao su được may trực tiếp vào thân nón. Nón fit từ vòng đầu 50cm trở lên.',189000,N'as07.png',4,108)
INSERT INTO SANPHAM VALUES(N'DIRTY COINS LOGO CAP',N'Nón được dệt từ sợi Len và nỉ. Logo may trực tiếp vào thân nón.',239000,N'as08.png',4,108)

INSERT INTO SANPHAM VALUES(N'PLAID PANTS IN BRED',N'Quần được làm sản xuất từ khakhi. Logo được thêu ở phía túi trái. Form oversize. Lưng quần bo vải gân kèm drawstring thun bên trong.',450000,N'ps01.png',5,108)
INSERT INTO SANPHAM VALUES(N'GRYNCH ALL OVER PRINT PANTS',N'Quần được làm từ Cotton pha Poly. Hình in được in phủ khắp quần. Tag cao su được thêu trực tiếp ở phía túi trái. Form oversize. Lưng quần bo vải gân kèm drawstring thun bên trong.',500000,N'ps02.png',5,108)
INSERT INTO SANPHAM VALUES(N'YOSHINO DRAGON SHORTS',N'Quần dù ngắn. Hình ảnh được in ở ống quần bên trái. Lưng quần được may bằng vải gân có dây rút. Dây rút quần có sở hữu đầu mút.',520000,N'ps03.png',5,108)
INSERT INTO SANPHAM VALUES(N'Y SHORT',N'Form quần cơ bản. Dây quần có đầu dây bằng nhựa. 2 Túi ở phía trái phải quần. 1 Túi sau có zipper. Tag cao su được may ở phần ống quần. Bên trong có lót một lớp vải lưới tăng độ thoáng mát và độ giữ form.',329000,N'ps04.png',5,108)
INSERT INTO SANPHAM VALUES(N'ACADEMY UNIFORM PANTS',N'Quần được làm từ Cotton pha Poly.',500000,N'ps05.png',5,108)
INSERT INTO SANPHAM VALUES(N'DIRTY COINS SWEAT TRACK PANTS',N'Sản phẩm 100% cotton. Hình in được in ở hai bên phía ngoài ống quần. Quần sở hữu dây rút được trang bị đầu mút dây. Lưng quần có dây chun co giãn.',440000,N'ps06.png',5,108)
INSERT INTO SANPHAM VALUES(N'DCS SHORT',N'Form quần cơ bản. Dây quần có đầu dây bằng nhựa. 2 Túi ở phía trái phải quần. 1 Túi sau có zipper. Tag cao su được may ở phần ống quần. Bên trong có lót một lớp vải lưới tăng độ thoáng mát và độ giữ form.',315000,N'ps07.png',5,109)
INSERT INTO SANPHAM VALUES(N'DIRTYCOINS SWEAT SHORTS',N'Form quần cơ bản. Dây quần có đầu dây bằng nhựa. 2 Túi ở phía trái phải quần. 1 Túi sau có zipper. Bên trong có lót một lớp vải lưới tăng độ thoáng mát và độ giữ form.',390000,N'ps08.png',5,109)

INSERT INTO SANPHAM VALUES(N'MONARCH ALL OVER PRINT JACKET',N'Jacket chất liệu vải dù. Form oversize. Khóa áo được sử dụng nút bấm tiện dụng. Áo có hai túi ở hai bên thân áo',650000,N'jk01.png',6,109)
INSERT INTO SANPHAM VALUES(N'HOLOGRAM ZIP JACKETS',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Hình in phản quang. Ống tay áo có nút bấm tùy chỉnh ôm. Áo có hood được trang bị dây rút.',620000,N'jk02.png',6,109)
INSERT INTO SANPHAM VALUES(N'SIGNATURE Y ZIP COACH JACKET',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm. Áo có hood được trang bị dây rút.',600000,N'jk03.png',6,109)
INSERT INTO SANPHAM VALUES(N'REFLECTIVE LOGO SWEAT TRACK JACKETS',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm. Áo có hood được trang bị dây rút.',209000,N'jk04.png',6,109)
INSERT INTO SANPHAM VALUES(N'Y - SPACE JACKET',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm.',339000,N'jk05.png',6,109)
INSERT INTO SANPHAM VALUES(N'DIRTY COINS EYES-CREAM JACKET',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm.',490000,N'jk06.png',6,109)
INSERT INTO SANPHAM VALUES(N'TRACK JACKET',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm. Áo có hood được trang bị dây rút.',450000,N'jk07.png',6,109)
INSERT INTO SANPHAM VALUES(N'ALL OVER PRINT DALAT COACH JACKET',N'Chất liệu dù. Có zipper từ tà áo đến cổ áo, kèm lớp che có nút bấm. Ống tay áo có nút bấm tùy chỉnh ôm',550000,N'jk08.png',6,109)
SELECT * FROM SANPHAM

CREATE TABLE HOADON
(
	MAHD INT Identity(1,1),
	NGAYLAP DATE,
	MAKH INT,
	THANHTIEN MONEY,
	PRIMARY KEY(MAHD)
)

ALTER TABLE HOADON
ADD CONSTRAINT FK_HD_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

CREATE TABLE CHITIETHD
(
	MAHD INT,
	MASP INT,
	SOLUONG INT,
	TONGTIEN MONEY,
	PRIMARY KEY(MAHD, MASP)
)
ALTER TABLE CHITIETHD
ADD CONSTRAINT FK_CT_SP FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP),
	CONSTRAINT FK_CT_HD FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD)
go
create trigger capnhatTongTien on CHITIETHD
FOR INSERT, UPDATE
AS
	UPDATE CHITIETHD
	SET TONGTIEN = SOLUONG * (SELECT DONGIA FROM SANPHAM WHERE SANPHAM.MASP = (SELECT MASP FROM inserted))
	WHERE CHITIETHD.MAHD = (SELECT MAHD FROM inserted)
	AND CHITIETHD.MASP = (SELECT MASP FROM inserted)

	UPDATE HOADON
	SET THANHTIEN = (SELECT SUM(TONGTIEN) FROM CHITIETHD WHERE CHITIETHD.MAHD = (SELECT MAHD FROM inserted))
	WHERE HOADON.MAHD = (SELECT MAHD FROM inserted)
GO
