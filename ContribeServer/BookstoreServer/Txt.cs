using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using System.Resources;


namespace BookstoreServer {
  static class Txt {
    public const string BookNotExists = "Fel vid anrop till databas, bok med ID {0} finns inte";
    public const string CartChanged = "Böckerna du försöker beställa stämmer inte med innehållet i kundvagnen.\n" +
              "Kanske har innehållet i kundvagnen ändrats från en annan websida?\n" +
              "Prova att visa om kundvagnen innan du gör en ny beställning.";
    public const string InvalidUserID = "Ogiltigt användarnamn";
    public const string InformationTest = "Boklådan har just nu kafferast. Var vänlig återkom senare.";
    public const string ExceptionTest = "Ett allvarligt fel av typen TEST inträffade";
    public const string LongRunningResponse = "Anropet varade {0} -- {1}";
  }
}
