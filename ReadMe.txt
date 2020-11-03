

1. YMS5175_TwitterProject adýnda "blank project" açýlýr.
2. Solution sað týklayarak "add new project" diyerek YMS5175_TwitterProject.DomainLayer adýnda Class Library (Asp .NetCore) project eklenir.
	2.1. Entities klasö açýlýr.
		2.1.1. Abstraction & Concrete kalsörleri açýlýr. Proje kapsamýnda ihtiyaç duyulan sub domain'leri karþýlayacak entityler SOLID prensiplerine uyularak yaratýlýr.
		Not: AppRole.cs sýnýfýný IdentityRole<int> sýnýfý ile extend ettik. "IdentitRole" sýnýfý için "Microsoft.Extensions.Indetity.Store" paketini yükledik.
		2.1.2. Enums klasörü açýlýr. Ýçerisine "Status.cs" eklenir. Entity durum kontrolü için kullanýlacaktýr.
		2.1.3. Repositories klasörü açýlýr.
			2.1.3.2. Abstraction klasörü açýlýr. Akabinde Kernel klasörü açýlýr. Diðer bütün repository'lerde ortak olarak kullanýlacak CRUD iþlemlerini temel anlamda karþýlayacak methodlar burada açýlan IBaseRepository.cs içerisinde öbeklenir. 
			Not: Sub domaninlerin ihtiyaçlarýna yönelik varlýklar oluþturlur. Bu safhada bu varlýklarýn CRUD operasyonlarýnda kullanýlacak methodlarýn soyut birer temsili oluþturulur. Örneðin IAppUserRepository, IFolowRepository vb.
		2.1.4. UnitOfWork klasörleri açýlýr.
			2.1.4.1 Abstraction klasörü açýlýr. "IUnitofWork.cs" açýlýr ve IAsyncDisposable sýnýfý ile extend edilir. Unit of Work desing pattern'ý gereði oluþturulan repository arayüzleri burada çaðrýlýr.
3. Solution sað týklayarak "add new project" diyerek YMS5175_TwitterProject.InfrastructureLayer adýnda Class Library (Asp .NetCore) project eklenir.
	Not: EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools, AspNetCore.Identity.EntityFrameworkCore ve domainlayer katmaný referanslara eklenir.
	3.1. Mapping klasörü eklenir.
		3.1.1. Abstraction klasörü açýlýr.
			3.1.1.1. BaseMap.cs açýlýr. BaseEntity.cs sýnýfýnýn mapping iþlemi yeirne getirilir. Burada açýlan sýnýf fluent api gereði abstract olarak iþaretlenir.
		3.1.2. Concrete klasörü açýlýr.
			3.1.2.1. Projede kullanýlan varlýklarýn mapping iþlemleri yürütülür. Buradaki concrete sýnýflarýn hepsi "BaseMap.cs" sýnýfýndan miras alýr.
	3.2. Context klasörü eklenir.
	3.3. Repositories klasörü eklenir.
	3.4. UnitOfWork klasörü eklenir.
4. .PresentationLayer adýnda asp.netcore web projesi eklenir. 
	Not: EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools paketleri yüklenir.
	4.1. Startup.cs altýna applicationdbcontext nesnesi middleware olarak eklenir.
	4.2. ConnectionString application.json dosyasýna yazýlýr.
	4.3. Migration operasyonu yürütülür.
	4.4. Repository klasörü açýlýr.
