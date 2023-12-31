# KareAjansi Bitirme Projesi

## NTier katmanlý mimariye sahip bir projedir.

### KareAjansi.DAL kýsýmnda
 Models çatýsý altýnda verilerimizin olduðu Entity klasörü,Üst sýnýf olan BaseClassýn olduðu Base klaösrü,Sabit deðerler için Enum klasörü ve son olarak veri tabanýmýzý temsil eden Context klasörü.

### KareAjansi.Common
Yardýmcý Classlar bulunmaktadýr.

### KareAjansi.BLL kýsmý
Asýl verilermizin verilerini web üzerinde göstermesi için DTOs yani Data transfer object, CRUD methodlarýnýn  olduðu Repositories, Son olarak CRUD methodlarýn iþlemleri için Services klasörü.

### KareAjansi.API
BLL klasöründek iþlemlerimizn hem HTTP protoköl hemde MVC web üzerinde göndermemiz için Controllers klasörü 

### KareAjansi.MVC
DAL içinde bulunan entitylerin sayfalarý ve api üzerinden verilermizin web üzernide görünmesi için Controllers ve Views kýsýmlarý. Models içerisinde ise ViewModels klasörü altýnda RegisterVM,LoginVM,UserVM iþlemleri var.

### Nuget Paketler
-Microsoft.AspNetCore.Identity.EntityFrameworkCore

-Microsoft.EntityFrameworkCore.SqlServer

-Microsoft.EntityFrameworkCore.Tools