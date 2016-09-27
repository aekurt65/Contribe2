using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonClient {
  static class Txt {
    public const string IncorrectUrlFormat =
      "{0} är inte en giltig webadress av typen HTTP.\n" +
      "Formatet skall vara t.ex. http://contribe.se:1234";
    public const string ServerCallNoResult = "Fel vid serveranrop, inget resultat tillbaka";
    public const string ServerCallError = "Fel vid serveranrop:\n\n{0}";
    public const string MissingUrl = "Du måste ange en giltig serveradress för att kunna använda programmet";
  }
}
