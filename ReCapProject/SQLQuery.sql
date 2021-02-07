CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(30),
)

CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(30),
)

CREATE TABLE Cars(
	CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear nvarchar(4),
	DailyPrice decimal,
	Descriptions nvarchar(200),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
	)

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Gri'), 
	('Kırmızı'),
	('Füme'),
	('Mavi'),
	('Sarı');

INSERT INTO Brands(BrandName)
VALUES
	('Fiat'), 
	('Volkswagen'), 
 	('Dacia'), 
	('Jeep'), 
	('Hyundai'),
	('Honda'),
	('Ford'),
	('Audi'),
	('BMW');


INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions) VALUES
	--Fiat
	('1','1','2016','125','Fiat Egea Sedan 4 Kapı 120.000km Dizel Manuel Vites 23 Yaş Sınırı'),
	('1','2','2018','120','Fiat Panda Cross Hatchback 4 Kapı 4x4 80.000km Benzin-LPG Otomatik Vites 21 Yaş Sınırı'),
	('1','5','2020','250','Fiat Doblo Panorama Panelvan 4 Kapı 5.000km Dizel Otomatik Vites 25 Yaş Sınırı'),
	('1','4','2021','400','Fiat 124 Spider Cabrio 2 Kapı 2.500km Benzin Otomatik Vites 25 Yaş Sınırı'),
	--Volkwagen
	('2','1','2015','110','Caddy Panelvan 4 Kapı 150.500km Dizel Manuel Vites 18 Yaş Sınırı'),
	('2','3','2018','400','Passat Sedan 4 Kapı 25.000km Benzin Otomatik Vites 25 Yaş Sınırı'),
	('2','7','2020','600','Arteon Sedan 4 Kapı 10.250km Benzin Otomatik Vites 27 Yaş Sınırı'),
	--Dacia
	('3','6','2017','135','Duster SUV 4 Kapı 175.500km Dizel Manuel Vites 18 Yaş Sınırı'),
	('3','2','2019','150','Sandero SUV 4 Kapı 55.000km Benzin-LPG Otomatik Vites 21 Yaş Sınırı'),
	('3','5','2020','250','Logan SUV 4 Kapı 22.250km Benzin Otomatik Vites 23 Yaş Sınırı'),
	--Jeep
	('4','2','2018','275','Renegade SUV 4 Kapı 75.000km Benzin Otomatik Vites 21 Yaş Sınırı'),
	--Hyundai
	('5','3','2016','90','i20 Hatchback 4 Kapı 300.000km Dizel Manuel 18 Yaş Sınırı'),
	('5','1','2018','110','i10 Hatchback 4 Kapı 210.000km Dizel Manuel 18 Yaş Sınırı'),
	--Honda
	('6','4','2015','100','Civic Sedan 4 Kapı 350.000km Dizel Manuel 18 Yaş Sınırı'),
	--Ford
	('7','5','2020','450','Mustang Sedan 4 Kapı 22.000km Benzin Otomatik 25 Yaş Sınırı'),
	('7','6','2019','250','Focus Hatchback 4 Kapı 37.000km Benzin-LPG Manuel 22 Yaş Sınırı'),
	--Audi
	('8','2','2019','375','A3 Sedan 4 Kapı 80.000km Benzin Otomatik 22 Yaş Sınırı'),
	('8','3','2018','280','A6 Sedan 4 Kapı 110.000km Dizel Otomatik 21 Yaş Sınırı'),
	--BMW
	('9','2','2019','335','M3 Sedan 4 Kapı 69.000km Benzin Otomatik 23 Yaş Sınırı'),
	('9','4','2020','525','530 Sedan 4 Kapı 50.000km Benzin Otomatik 25 Yaş Sınırı');



