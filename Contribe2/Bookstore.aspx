<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bookstore.aspx.cs" Inherits="Contribe2.Bookstore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Kalles boklåda</title>
  <script src="jquery-1.10.2.js"></script>
  <script src="Contribe.js"></script>
  <script src="Bookstore.js"></script>
  <style type="text/css">
    span {
      font-weight: bold;
    }
  </style>
</head>
<body>
  <!-- Feldialog -->
  <div id="errorDialog" style="background-color: red;">
    Fel vid anrop till webserver: <span id="errorText"></span>
  </div>

  <!-- Feltest -->

  <input id="Feltest" type="button" value="Feltest" />

  <!-- Inloggning -->
  <form style="background-color: lawngreen;">
    <p id="LoggedIn" style="display: none">
      Du är inloggad som <span id="userid"></span>
      <input id="btnLogout" type="submit" value="Logga ut" />
    </p>
    <p id="NotLoggedIn">
      Ange din inloggning: <input type="text" id="txtLogin" />
      <input id="btnLogin" type="submit" value="Logga in" />
    </p>
  </form>

  <!-- Sökning -->
  <form style="background-color: aquamarine;">
    <h3 id="SearchHeader">Sökning</h3>
    <p>
      Ange (början av) ett eller flera ord i titel/författarnamn för att söka
        <input id="txtSearch" type="text" />
      <input id="btnSearch" type="submit" value="Sök" />
    </p>
    <h4 id="SearchresultHeader"></h4>
    <table id="tblSearchResult"></table>
  </form>

  <!-- Lista över objekt i kundvagn -->
  <div style="background-color: yellow">
    <h3 id="CartHeader">Kundvagn</h3>
    <table id="tblCart"></table>
    <hr />
    <p id="cartFooter">
      Totalsumma: <span id="cartSumPrice"></span>
      <input id="btnPlaceOrder" type="button" value="Beställ varorna i kundvagnen" />
    </p>
  </div>

  <!-- Beställning -->
  <div style="background-color: lawngreen;">
    <h3 id="OrderHeader">Beställda varor</h3>
    <table id="tblPlacedOrder"></table>
    <hr />
    <p id="orderFooter">
      Totalsumma: <span id="ordersSumPrice"></span>
    </p>
  </div>

  <!-- Mallar för rader i listorna -->
  <div id="templates" style="display: none;">
    <div id="SearchresultRowTemplate">
      Författare: <span class="Author"></span>
      Titel:<span class="Title"></span>
      Pris:<span class="Price"></span>
      Antal i lager:<span class="InStock"></span>
      <input class="BookID" type="hidden" />
      <input class="AddBookBtn" type="button" value="Lägg till" />
    </div>
    <div id="CartRowTemplate">
      Författare: <span class="Author"></span>
      Titel: <span class="Title"></span>
      Pris/st: <span class="Price"></span>
      Antal i kundvagn: <span class="NumItems"></span>
      Summa pris: <span class="Rowsum"></span>
      <input class="BookID" type="hidden" />
      <input class="RemoveBookBtn" type="button" value="Ta bort" />
    </div>
    <div id="OrderRowTemplate">
      Författare: <span class="Author"></span>
      Titel: <span class="Title"></span>
      Pris/st: <span class="Price"></span>
      Antal levererade: <span class="NumDelivered"></span>
      <span id="TextRestnoterade" style="background-color: red">
        Antal restnoterade: <span class="NumRest"></span>
      </span>
      Summa pris: <span class="Rowsum"></span>
    </div>
  </div>
</body>
</html>

