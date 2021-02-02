Select	Products.ProductName as ÜrünAdı,		
		--İndirim Uygulanmış fiyatın hesabı (unitprice Order Detailsden çekiliyor. {Hoca öyle istemiş.} )
		--Ben örnek olarak "Northwoods Cranberry Sauce" ürününde çalıştım ve elle hesapladım.
		--Product tablosundaki unitPrice sabit olup order details tablosunda unitPrice bazI order'larda değişiyor.
		Sum(([Order Details].Quantity*[Order Details].UnitPrice)
		-([Order Details].Quantity*[Order Details].UnitPrice)*[Order Details].Discount) 
		as KazanılanToplamMiktar
		/*
			--İndirimsiz Fiyatın Hesabı 
			Sum(([Order Details].Quantity*[Order Details].UnitPrice)) 
			as KazanılanToplamMiktar
		*/

from Products left join   [Order Details]
on [Order Details].ProductID = Products.ProductID
group by Products.ProductName 
order by Products.ProductName









