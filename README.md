# ToDoList
ToDoList with Asure functions and local server(Microsoft SQL Server Management)/Postman/

ClassLibrary -> core 3 ra long support
EntityFramework nuget - fordit objektumot adatbazisra/vissza
 - kell a core, design, sqlserver, tools
Microsoft SQL server management studioban csatlakozol egy szerverre (memoQosat hasznaltunk => ellenben letrehozhatsz egy lokalisat a Microsoft serverrel)
A databasesben letrehozol egy adatbazist
A visual studiobol a View SQL server explorerrel megkeresed a letrehozott adatbazist (ennek kell legyen connection stringje (propertiesben))
DbContext -> ToDoListDbContext ebbol szarmazik le. Ez az EntityFramework.Core nak egy osztalya amivel modositgatod az elemeket az adatbazisban
ToDoListDbContextFactory osztaly => nezd meg mi a factory design pattern
Package manager consoleban =>
	$env:ToDoListDbConnection="Data Source=DESKTOP-MDPBI1D\MEMOQSERVER;Initial Catalog=ToDoItemsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" (a propertieben tarolt connection string)
	echo $env:ToDoListDbConnection (kiirja)
	Add-Migration ToDoItemInit (akarmilyen nev => letrejon egy migrations konyvtar a slnben, ahol leforditodik sqlre a modelunk)
	Update-Database (frissiti az adatbazist a Microsoft SQL serverben)
	Remove-Migration (amig nincs updatelve az utolso migraciot kidobja)

Uj projekt =>AzureFunction (Http Trigger)
	ez kell legyen a startup project
	inne kapod a http hivast, ha inditod azokra a fvnyekre, amik meg vannak irva
	Postmanbol hivod es a Raw nezetben jsonban adod meg a tartalmat, majd ellenorzod a cmndlinebol. Ha succeeded akkor a Microsoft sql server managementben is meg kell jelenjen a "hozza adott"/"torolt"/"modositott" ertek
	
Ha a tablat bovited uj migracio + end point kell es update, hogy befrissuljon a tablazat az SQL server managementben.

API => Startup.cs + local.settings.json file kapcsolodasert felel/dependency injection... (?)
____
feladat:
bovitsd ki egy osztallyal => user (first name, last name, age)
							 comment (tipus, letrehozasi ido, description)
							 elem torlese

contextben mi az az override OnModelCreating es hogyan hasznaljak
