# ToDoList
ToDoList with Asure functions and local server(Microsoft SQL Server Management)/Postman/

# Install
	* Visual Studio (with Asure)
	* Postman
	* Microsoft SQL Server (if we have no memoQ server :D)
	* Microsoft SQL Server Management

# Description
* ClassLibrary -> core 3 ra long support
* .BLL projekt
	* EntityFramework nuget - fordit objektumot adatbazisra/vissza + kellenek a EnityFrameworktol => core, design, sqlserver, tools
	* Microsoft SQL server management studioban csatlakozol egy szerverre (memoQosat hasznaltunk => ellenben letrehozhatsz egy lokalisat a Microsoft serverrel)
	* A visual studiobol a View/SQL server object explorer-rel megkeresed a letrehozott adatbazist (ennek kell legyen connection stringje (propertiesben))
	* ToDoListDbContext a DbContext -bol szarmazik le. Ez az EntityFramework.Core nak egy osztalya amivel modositgatod az elemeket az adatbazisban
	* ToDoListDbContextFactory osztaly => nezd meg mi a factory design pattern
	* Package manager consoleban => 	
		* kornyezeti valtozo beallitasa => $env:ToDoListDbConnection="a propertieben tarolt connection string" - pl: $env:ToDoListDbConnection="Data Source=DESKTOP-MDPBI1D\MEMOQSERVER;Initial Catalog=ToDoItemsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
		* kornyezeti valtozo kiirassa a package manager consoleban => echo $env:ToDoListDbConnection (kiirja)
		* Migracio => Add-Migration ToDoItemInit (akarmilyen nev => letrejon egy Migrations konyvtar a slnben (.BLL alatt). Ezen belul forditodnak le sqlre a modeleink)
		* Update-Database (frissiti az adatbazist a Microsoft SQL serverben)
		* Remove-Migration (amig nincs updatelve az utolso migraciot kidobja)
		* MEGJ: 
			* a .BLL kell legyen a StartUpProject es a DefaultProject-nek is ez kell legyen allitva a Package Manager Consolban
			* minden update/migration eseteben be kell allitani a kornyezeti valtozot a connection stringgel
			* minden tablazatbeli adatvaltoztatas (fokent tipus vagy uj adat felvetele vagy torlese ...) eseteben kell egy uj migracio
* .API projekt - ez a 
	* Uj projekt => AzureFunction (Http Trigger)
	* Futtataskor ez kell legyen a startup project ahonnan megkapod a http-t (console) minden megirt fuggvenyre
	* Postmanbol hivod a http-ket a megfelelo otasitassal (get, post, patch, delete...) es adott helyzetben pl modositas a Raw nezetben jsonban adod meg a tartalmat (cmndlineban kiirodik a hivas es hogy sikerult-e). Ha succeeded akkor a Microsoft sql server managementben is meg kell jelenjen a "hozza adott"/"torolt"/"modositott" ertek
	
----------
# Feladat:
* elem torlese
* bovitsd ki az adatokat (ToDoItem) ugy, hogy legyen neki egy propertyje, aminek a tipusa egy masik osztaly. Pl => user (first name, last name, age), description (long, short).

# Jarj utana:
API => Startup.cs + local.settings.json file kapcsolodasert felel/dependency injection... (?)
contextben mi az az override OnModelCreating es hogyan hasznaljak

---------
Asure Storage Emulator (blop storage)

https://azure.microsoft.com/en-us/features/storage-explorer/
https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator 