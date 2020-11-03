

1. YMS5175_TwitterProject ad�nda "blank project" a��l�r.
2. Solution sa� t�klayarak "add new project" diyerek YMS5175_TwitterProject.DomainLayer ad�nda Class Library (Asp .NetCore) project eklenir.
	2.1. Entities klas� a��l�r.
		2.1.1. Abstraction & Concrete kals�rleri a��l�r. Proje kapsam�nda ihtiya� duyulan sub domain'leri kar��layacak entityler SOLID prensiplerine uyularak yarat�l�r.
		Not: AppRole.cs s�n�f�n� IdentityRole<int> s�n�f� ile extend ettik. "IdentitRole" s�n�f� i�in "Microsoft.Extensions.Indetity.Store" paketini y�kledik.
		2.1.2. Enums klas�r� a��l�r. ��erisine "Status.cs" eklenir. Entity durum kontrol� i�in kullan�lacakt�r.
		2.1.3. Repositories klas�r� a��l�r.
			2.1.3.2. Abstraction klas�r� a��l�r. Akabinde Kernel klas�r� a��l�r. Di�er b�t�n repository'lerde ortak olarak kullan�lacak CRUD i�lemlerini temel anlamda kar��layacak methodlar burada a��lan IBaseRepository.cs i�erisinde �beklenir. 
			Not: Sub domaninlerin ihtiya�lar�na y�nelik varl�klar olu�turlur. Bu safhada bu varl�klar�n CRUD operasyonlar�nda kullan�lacak methodlar�n soyut birer temsili olu�turulur. �rne�in IAppUserRepository, IFolowRepository vb.
		2.1.4. UnitOfWork klas�rleri a��l�r.
			2.1.4.1 Abstraction klas�r� a��l�r. "IUnitofWork.cs" a��l�r ve IAsyncDisposable s�n�f� ile extend edilir. Unit of Work desing pattern'� gere�i olu�turulan repository aray�zleri burada �a�r�l�r.
3. Solution sa� t�klayarak "add new project" diyerek YMS5175_TwitterProject.InfrastructureLayer ad�nda Class Library (Asp .NetCore) project eklenir.
	Not: EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools, AspNetCore.Identity.EntityFrameworkCore ve domainlayer katman� referanslara eklenir.
	3.1. Mapping klas�r� eklenir.
		3.1.1. Abstraction klas�r� a��l�r.
			3.1.1.1. BaseMap.cs a��l�r. BaseEntity.cs s�n�f�n�n mapping i�lemi yeirne getirilir. Burada a��lan s�n�f fluent api gere�i abstract olarak i�aretlenir.
		3.1.2. Concrete klas�r� a��l�r.
			3.1.2.1. Projede kullan�lan varl�klar�n mapping i�lemleri y�r�t�l�r. Buradaki concrete s�n�flar�n hepsi "BaseMap.cs" s�n�f�ndan miras al�r.
	3.2. Context klas�r� eklenir.
	3.3. Repositories klas�r� eklenir.
	3.4. UnitOfWork klas�r� eklenir.
4. .PresentationLayer ad�nda asp.netcore web projesi eklenir. 
	Not: EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools paketleri y�klenir.
	4.1. Startup.cs alt�na applicationdbcontext nesnesi middleware olarak eklenir.
	4.2. ConnectionString application.json dosyas�na yaz�l�r.
	4.3. Migration operasyonu y�r�t�l�r.
	4.4. Repository klas�r� a��l�r.
