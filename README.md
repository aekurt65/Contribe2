
Länken till arbetsprovet är https://github.com/aekurt65/Contribe2

Inledning
===========

Det är utvecklat i Visual Studio Express 2015, det är vad jag hade hemma och eftersom min maskin redan gåt på knäna känns det inte aktuellat att installera något nyare.


Då inte inte stött på Task innan och endast arbetat minimalt med Webservice så var det ganska lärorikt, men jag lyckades aldrig komma underfund med varken varför man skall använda sig av Task<T> som returobjekt i ett webinterface, eller hur man skall använda en webserviceklient med metoder som returnerar Task, och fick ta till en litet udda lösning för att komma runt problemet. Mer om det och några andra funderingar nedan.


Översikt
===========

Lösningen består av följande 7 delprojekt:

1. ContribeInterface är interfacet mellan server och klienter

2. ContribeCommon innehåller rutiner som kan användas av både server och klient

3. ContribeServer implementerar själva boklådan

4. ContribeWeb innehåller websida och och en webservice. Borde väl varit i två olika projekt, men de får vara i samma för att websidan enkelt skall kunna hitta servicen

5. ContribeClient innehåller klientimplementationen av interfacet.

6. ContribeWinForms en winforms-applikation för åtkomst till bokaffären.

7. ContribeTest innehåller några unit-tester



ContribeWeb är startprojekt, med både websida och webservice, websidan för boklådan heter Bookstore.html, och dessutom kan man starta en winforms-klient med projektet ContribeWinForms (som förutsätter att ContribeWeb är startad innan)

Gränssnittet är en webservice i filen BookstoreService.amsx och kommunikationen åt båda håll sker med json.

Tredjepartsprodukter är jQuery för att lättare kunna manipulera objekt på websidan och Newtonsoft/Json för att koda/avkoda json.


Centrala moduler
===============
ContribeInterface.BookstoreInterface.IBookstoreService.cs 
- Interfacet

ContribeWeb.BookstoreService.asmx
- Serversidans implementation av interfacet

ContribeServer.BookstoreServer.Bookstore.cs
- Gränssnittet mellan servicen och serverapplikationen

ContribeWeb.Bookstore.html / Bookstore.js
- Websida med tillhörande javascript

ContribeClient.BookstoreClient.BookstoreService.cs
- Klientimplementation av interfacet

ContribeClient.Commonclient.JsonClient.cs
- Basklass till föregående, udda lösning eftersom jag inte kom underfund med hur man använder Task som returobjekt i webservice.





Kommentarer till programmets funktion
=====================================

Inloggning - ingen hantering av inloggning, för att kunna hantera en kundvagn och lägga en order måste man ange ett användarnamn, anger man ett användarnamn som inte finns så skapas helt enkelt en ny användare.

Order - För varje användare skapas en kundvagn och ett orderobjekt, när man lägger en beställning så flyttas böcker från kundvagnen till orderobjektet. I verkligheten hade man väl skapat ett order-objekt för varje beställningstillfälle

Om man lägger en order på böcker och kundvagnen ändrats från annat håll görs en koll att de böcker man försöker beställa verkligen finns i kundvagnen.

Felhantering - 
Som jag ser det finns två typer av fel, dels förväntade fel (t.ex. att man försöker lägga på en bok som inte finns i kundvagnen) eller fel som inte "borde" kunna uppkomma. Jag skiljer på dessa genom att ha skapat typen InfoException för de förra, som ger upphov till en enklare feldialog.


Problem och udda lösningar
==========================

Följande 3 problem känner jag kanske borde ha lösts på annat sätt:

1. Kom inte underfund med hur man får Task<T> som returobjekt i service-reference att fungera, jag fick den omvandlad till nåt objekt av typen TaskOfString och liknande som jag inte begrep mig på och inte lyckades hitta nåt om heller. För att komma runt detta skapade jag modulen JsonClient.cs, för att "manuellt" koda/avkoda parametrar/returobjekt till/från json.

2. Lyckades inte serialisera Task-objekt innehållande Exception. I stället skapar jag en fejk-Task i de fall Exception har kastats för att kunna serialisera. Även vid avkodningen av Task-objektet på kientsidan blev det problem om det ligger med ett exception och jag använde mig även där av ett fejkobjekt.  Jag vet inte hur det är tänkt att göra annars... varken att koda in felinformation i vartenda möjliga returobjekt eller använda sig av 500/server error för dessa fall låter speciellt tilltalande. 

3. Anrop till metoden PlaceOrderAsync i interfacet vill jag ha en IDictionary eller Dictionary som parameter, men fick det inte att fungera. Rimligtvis går det väl på något sätt, men för att få ihop det bytte jag ut parametertypen till string och (de-)serialiserar parametern manuellt.

Funderingar
===========

Jag har inte riktigt kommit underfund med syftet att ha Task<T> i interfacet. Som jag ser det representerar en Task något som exekveras i en specifik tråd på en specifik maskin och är inte något man har nytta av på någon annan maskin. Varför då ha med det i interfacet?

1. För att man vill tvinga/uppmuntra klienten till att göra anropen asynkront. Även om det nu kanske är rimligt att man gör så så kan jag inte se varför interfacet skulle styra hur klienten arbetar, och det går ju bra att gör anropen asynkront även om det inte är angivet i interfacet.

2. Dra nytta av den extra övriga information (förutom det egentliga returobjektet) som kan finnas i Task-objektet. Då borde man ju lätt få med eventuell exception-information till klienten, himla listigt tänkte jag tills jag kom underfund med att en Task med Exception inte går att serialisera (((

3. Något 3:e skäl som jag ännu inte insett, men som jag hoppas jag blir informerad om i kommande feedback.
















