
L�nken till arbetsprovet �r https://github.com/aekurt65/Contribe2

Inledning
===========

Det �r utvecklat i Visual Studio Express 2015, det �r vad jag hade hemma och eftersom min maskin redan g�t p� kn�na k�nns det inte aktuellat att installera n�got nyare.


D� inte inte st�tt p� Task innan och endast arbetat minimalt med Webservice s� var det ganska l�rorikt, men jag lyckades aldrig komma underfund med varken varf�r man skall anv�nda sig av Task<T> som returobjekt i ett webinterface, eller hur man skall anv�nda en webserviceklient med metoder som returnerar Task, och fick ta till en litet udda l�sning f�r att komma runt problemet. Mer om det och n�gra andra funderingar nedan.


�versikt
===========

L�sningen best�r av f�ljande 7 delprojekt:

1. ContribeInterface �r interfacet mellan server och klienter

2. ContribeCommon inneh�ller rutiner som kan anv�ndas av b�de server och klient

3. ContribeServer implementerar sj�lva bokl�dan

4. ContribeWeb inneh�ller websida och och en webservice. Borde v�l varit i tv� olika projekt, men de f�r vara i samma f�r att websidan enkelt skall kunna hitta servicen

5. ContribeClient inneh�ller klientimplementationen av interfacet.

6. ContribeWinForms en winforms-applikation f�r �tkomst till bokaff�ren.

7. ContribeTest inneh�ller n�gra unit-tester



ContribeWeb �r startprojekt, med b�de websida och webservice, websidan f�r bokl�dan heter Bookstore.html, och dessutom kan man starta en winforms-klient med projektet ContribeWinForms (som f�ruts�tter att ContribeWeb �r startad innan)

Gr�nssnittet �r en webservice i filen BookstoreService.amsx och kommunikationen �t b�da h�ll sker med json.

Tredjepartsprodukter �r jQuery f�r att l�ttare kunna manipulera objekt p� websidan och Newtonsoft/Json f�r att koda/avkoda json.


Centrala moduler
===============
ContribeInterface.BookstoreInterface.IBookstoreService.cs 
- Interfacet

ContribeWeb.BookstoreService.asmx
- Serversidans implementation av interfacet

ContribeServer.BookstoreServer.Bookstore.cs
- Gr�nssnittet mellan servicen och serverapplikationen

ContribeWeb.Bookstore.html / Bookstore.js
- Websida med tillh�rande javascript

ContribeClient.BookstoreClient.BookstoreService.cs
- Klientimplementation av interfacet

ContribeClient.Commonclient.JsonClient.cs
- Basklass till f�reg�ende, udda l�sning eftersom jag inte kom underfund med hur man anv�nder Task som returobjekt i webservice.





Kommentarer till programmets funktion
=====================================

Inloggning - ingen hantering av inloggning, f�r att kunna hantera en kundvagn och l�gga en order m�ste man ange ett anv�ndarnamn, anger man ett anv�ndarnamn som inte finns s� skapas helt enkelt en ny anv�ndare.

Order - F�r varje anv�ndare skapas en kundvagn och ett orderobjekt, n�r man l�gger en best�llning s� flyttas b�cker fr�n kundvagnen till orderobjektet. I verkligheten hade man v�l skapat ett order-objekt f�r varje best�llningstillf�lle

Om man l�gger en order p� b�cker och kundvagnen �ndrats fr�n annat h�ll g�rs en koll att de b�cker man f�rs�ker best�lla verkligen finns i kundvagnen.

Felhantering - 
Som jag ser det finns tv� typer av fel, dels f�rv�ntade fel (t.ex. att man f�rs�ker l�gga p� en bok som inte finns i kundvagnen) eller fel som inte "borde" kunna uppkomma. Jag skiljer p� dessa genom att ha skapat typen InfoException f�r de f�rra, som ger upphov till en enklare feldialog.


Problem och udda l�sningar
==========================

F�ljande 3 problem k�nner jag kanske borde ha l�sts p� annat s�tt:

1. Kom inte underfund med hur man f�r Task<T> som returobjekt i service-reference att fungera, jag fick den omvandlad till n�t objekt av typen TaskOfString och liknande som jag inte begrep mig p� och inte lyckades hitta n�t om heller. F�r att komma runt detta skapade jag modulen JsonClient.cs, f�r att "manuellt" koda/avkoda parametrar/returobjekt till/fr�n json.

2. Lyckades inte serialisera Task-objekt inneh�llande Exception. I st�llet skapar jag en fejk-Task i de fall Exception har kastats f�r att kunna serialisera. �ven vid avkodningen av Task-objektet p� kientsidan blev det problem om det ligger med ett exception och jag anv�nde mig �ven d�r av ett fejkobjekt.  Jag vet inte hur det �r t�nkt att g�ra annars... varken att koda in felinformation i vartenda m�jliga returobjekt eller anv�nda sig av 500/server error f�r dessa fall l�ter speciellt tilltalande. 

3. Anrop till metoden PlaceOrderAsync i interfacet vill jag ha en IDictionary eller Dictionary som parameter, men fick det inte att fungera. Rimligtvis g�r det v�l p� n�got s�tt, men f�r att f� ihop det bytte jag ut parametertypen till string och (de-)serialiserar parametern manuellt.

Funderingar
===========

Jag har inte riktigt kommit underfund med syftet att ha Task<T> i interfacet. Som jag ser det representerar en Task n�got som exekveras i en specifik tr�d p� en specifik maskin och �r inte n�got man har nytta av p� n�gon annan maskin. Varf�r d� ha med det i interfacet?

1. F�r att man vill tvinga/uppmuntra klienten till att g�ra anropen asynkront. �ven om det nu kanske �r rimligt att man g�r s� s� kan jag inte se varf�r interfacet skulle styra hur klienten arbetar, och det g�r ju bra att g�r anropen asynkront �ven om det inte �r angivet i interfacet.

2. Dra nytta av den extra �vriga information (f�rutom det egentliga returobjektet) som kan finnas i Task-objektet. D� borde man ju l�tt f� med eventuell exception-information till klienten, himla listigt t�nkte jag tills jag kom underfund med att en Task med Exception inte g�r att serialisera (((

3. N�got 3:e sk�l som jag �nnu inte insett, men som jag hoppas jag blir informerad om i kommande feedback.
















