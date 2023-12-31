# KareAjansi Bitirme Projesi

## NTier katmanl� mimariye sahip bir projedir.

### KareAjansi.DAL k�s�mnda
 Models �at�s� alt�nda verilerimizin oldu�u Entity klas�r�,�st s�n�f olan BaseClass�n oldu�u Base kla�sr�,Sabit de�erler i�in Enum klas�r� ve son olarak veri taban�m�z� temsil eden Context klas�r�.

### KareAjansi.Common
Yard�mc� Classlar bulunmaktad�r.

### KareAjansi.BLL k�sm�
As�l verilermizin verilerini web �zerinde g�stermesi i�in DTOs yani Data transfer object, CRUD methodlar�n�n  oldu�u Repositories, Son olarak CRUD methodlar�n i�lemleri i�in Services klas�r�.

### KareAjansi.API
BLL klas�r�ndek i�lemlerimizn hem HTTP protok�l hemde MVC web �zerinde g�ndermemiz i�in Controllers klas�r� 

### KareAjansi.MVC
DAL i�inde bulunan entitylerin sayfalar� ve api �zerinden verilermizin web �zernide g�r�nmesi i�in Controllers ve Views k�s�mlar�. Models i�erisinde ise ViewModels klas�r� alt�nda RegisterVM,LoginVM,UserVM i�lemleri var.

### Nuget Paketler
-Microsoft.AspNetCore.Identity.EntityFrameworkCore

-Microsoft.EntityFrameworkCore.SqlServer

-Microsoft.EntityFrameworkCore.Tools