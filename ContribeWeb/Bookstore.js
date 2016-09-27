jQuery(document).ready(function ($) {
  var UserID = "";
  var cartItems = null;

  //==================================================
  // PageLoad
  //==================================================

  function PageLoad() {
    ClearUserinfo();
    $("#errorDialog").hide();
  }

  //==================================================
  // Testfuktioner
  //==================================================

  $("#Feltest").click(function () {
    var params = {};
    WSMethod("ExceptionTestAsync", params, doAlert);
  });

  $("#Infotest").click(function () {
    var params = {};
    WSMethod("InformationTestAsync", params, doAlert);
  });

  $("#LongTest").click(function () {
    var params = { milliSeconds: 3000 };
    WSMethod("LongRunningTestAsync", params, doAlert);
  });

  function doAlert(result) {
    var obj = checkAjaxTaskResult(result, false);
    if (obj) {
      alert(obj);
    }
  }

  //==================================================
  // In- och utloggning
  //==================================================

  $("#btnLogin").click(function () {
    UserID = $("#txtLogin").val().trim();
    if (UserID) {
      $("#userid").text(UserID);
      $("#LoggedIn").show();
      $("#NotLoggedIn").hide();
      GetCustomerInfo();
    }
    return false; // Cancel submit
  });

  function GetCustomerInfo() {
    var params = { UserID: UserID };
    WSMethod("GetCustomerInfoAsync", params, HandleIUserInfo);
  }

  $("#btnLogout").click(function () {
    UserID = "";
    $("#LoggedIn").hide();
    $("#NotLoggedIn").show();
    ClearUserinfo();
    return false; // Cancel submit
  });

  //==================================================
  // Eventhanterare
  //==================================================

  // Sökfunktion

  $("#btnSearch").click(function () {
    var strSearch = $("#txtSearch").val();
    var params = { searchString: strSearch };
    WSMethod("GetBooksAsync", params, HandleSearchResult);
    return false; // Cancel submit
  });

  // Lägga till i kundvagn

  function AddToCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = { UserID: UserID, BookID: bookid };
    WSMethod("AddBookAsync", params, HandleICart);
  }

  // Ta bort från kundvagn

  function RemoveFromCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = { UserID: UserID, BookID: bookid };
    WSMethod("RemoveBookAsync", params, HandleICart);
  }

  // Utför beställning

  $("#btnPlaceOrder").click(function () {
    if (!UserID) {
      alert("Du måste logga in igen");
      return;
    }

    var dicItemsToOrder = {};
    cartItems.forEach(function(item) {
      dicItemsToOrder[item.book.bookid] = item.nItems;
    });
    var jsonDicBooksToOrder = JSON.stringify(dicItemsToOrder);

    var params = { UserID: UserID, jsonDicBooksToOrder: jsonDicBooksToOrder };
    WSMethod("PlaceOrderAsync", params, HandleIUserInfo);
  });

  //==================================================
  // Callbackhanterare för olika typer av objekt
  //==================================================

  // Callbackhanterare för Task<IEnumerable<IBook>>

  function HandleSearchResult(result) {
    var obj = checkAjaxTaskResult(result, false);
    obj && FillSearchResultRows(obj);
  }

  // Callbackhanterare för Task<ICart>

  function HandleICart(result) {
    var obj = checkAjaxTaskResult(result, false);
    obj && FillCartRows(obj);
  }

  // Callbackhanterare för Task<ICustomerInfo>

  function HandleIUserInfo(result) {
    var obj = checkAjaxTaskResult(result, false);
    if (obj) {
      FillCartRows(obj.cart);
      FillOrderRows(obj.customerOrder);
    }
  }

  //==================================================
  // Uppdatering bild
  //==================================================

  // Fyll sökresultat

  function FillSearchResultRows(objResult) {
    var template = $("#SearchresultRowTemplate");
    $("#tblSearchResult tbody > tr").remove();
    for (var i = 0; i < objResult.length; i++) {
      var book = objResult[i];
      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(FormatCurrency(book.price));
      $(newRow).find(".InStock").text(book.inStock);
      $(newRow).find(".AddBookBtn").attr("bookid", book.bookid).click(function () {
        AddToCart($(this).attr("bookid"));
      });
      var $tr = $("<tr>").append("<td>").append(newRow);
      $tr.appendTo("#tblSearchResult");
    }
    if (objResult.length > 0) {
      $("#SearchresultHeader").text("Sökresultat");
    } else {
      $("#SearchresultHeader").text("Inga böcker matcher sökvillkoret");
    }
  }

  // Fyll kundvagninfo

  function FillCartRows(objResult) {
    cartItems = objResult.cartItems;

    $("#tblCart tbody > tr").remove();
    var template = $("#CartRowTemplate");
    var totSum = 0;
    for (var i = 0; i < cartItems.length; i++) {
      var item = cartItems[i];
      var book = item.book;
      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(FormatCurrency(book.price));
      $(newRow).find(".NumItems").text(item.nItems);

      var rowSum = book.price * item.nItems;
      totSum += rowSum;
      $(newRow).find(".Rowsum").text(FormatCurrency(rowSum));

      $(newRow).find(".RemoveBookBtn").attr("bookid", book.bookid).click(function () {
        RemoveFromCart($(this).attr("bookid"));
      });

      var $tr = $("<tr>").append("<td>").append(newRow);
      $tr.appendTo("#tblCart");
    }

    if (0 < cartItems.length) {
      $("#cartSumPrice").text(FormatCurrency(totSum));
      $("#cartFooter").show();
    }
    else {
      $("#cartFooter").hide();
    }

  }

  // Fyll orderinfo

  function FillOrderRows(objResult) {
    $("#tblPlacedOrder tbody > tr").remove();
    var template = $("#OrderRowTemplate");
    var orderItems = objResult.orderItems;
    var totSum = 0;
    for (var i = 0; i < orderItems.length; i++) {
      var item = orderItems[i];
      var book = item.book;

      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(FormatCurrency(book.price));
      $(newRow).find(".NumDelivered").text(item.nDelivered);
      $(newRow).find(".NumRest").text(item.nRest);
      if (item.nRest == 0) {
        $(newRow).find(".TextRestnoterade").hide()
      }
      var rowSum = book.price * (item.nDelivered + item.nRest);
      totSum += rowSum;
      $(newRow).find(".Rowsum").text(FormatCurrency(rowSum));

      var $tr = $("<tr>").append("<td>").append(newRow);
      $tr.appendTo("#tblPlacedOrder");
    }

    if (0 < orderItems.length) {
      $("#ordersSumPrice").text(FormatCurrency(totSum));
      $("#orderFooter").show();
    }
    else {
      $("#orderFooter").hide();
    }
  }

  // Rensa kundvagn och orderinfo

  function ClearUserinfo() {
    $("#tblCart tbody > tr").remove();
    $("#cartFooter").hide();

    $("#tblPlacedOrder tbody > tr").remove();
    $("#orderFooter").hide();
  }

  //==================================================
  // Avkodning o felhantering av resultat från servernarop
  //==================================================

  // Kontrollera resultatet ifall det innehåller någon
  // felinfomration, visa i så fall denna, annars returnera
  // data-delen av resultatet

  // Om result förväntas vara en IServiceReply<T>
  function checkAjaxServiceReplyResult(result, acceptNull) {

    if (!result || !result.d) {
      return showNoResultErrorMsg();
    }

    var serviceReply = result.d;

    if (!serviceReply) {
      return showNoResultErrorMsg();
    } else if (serviceReply.Error) {
      return showErrorMsg(serviceReply.Error);
    } else if (serviceReply.Info) {
      return showErrorMsg(serviceReply.Info);
    }

    var obj = serviceReply.Result;
    if (!obj && !acceptNull) {
      return showNoResultErrorMsg();
    }

    allOK();
    return obj;
  }

  // Om result förväntas vara objekt innehållande en Task<T>
  function checkAjaxTaskResult(result, acceptNull) {

    if (!result || !result.d) {
      return showNoResultErrorMsg();
    }

    var task = result.d;

    if (task.Exception) {
      return showException(task.Exception);
    }

    var obj = task.Result;
    if (!obj && !acceptNull) {
      return showNoResultErrorMsg();
    }

    allOK();
    return obj;
  }

  // Visar lämplig felinfo om vi inte fick något resultat,
  // eller resultatet var helt otydbart
  function showNoResultErrorMsg() {
    return showErrorMsg("Fel vid serveranrop, fick inget resultat tillbaka");
  }

  // Visar innehållet i ett Exception-objekt på lämpligt sätt.
  // Om Info-exception visas endast message, annars visas även stacktrace
  function showException(ex) {
    var msg;

    while (ex.ClassName.endsWith("AggregateException") && ex.InnerException) {
      ex = ex.InnerException;
    }

    if (ex.ClassName.endsWith("InfoException")) {
      msg = ex.Message;
    } else {
      msg = ex.Message + "\n\n" + ex.StackTraceString;
    }
    return showErrorMsg(msg);
  }

  // Callback för error från $.ajax
  function failedAjaxFn(jqXHR, textStatus, errorThrown) {
    var msg;
    msg = textStatus;
    msg += (errorThrown ? ": " + errorThrown : "");
    if (jqXHR) {
      if (jqXHR.status || jqXHR.statusText || jqXHR.responseText) {
        msg += "\n\n";
      }
      msg += jqXHR.status + (jqXHR.statusText ? ": " + jqXHR.statusText : "");
      msg += jqXHR.responseText ? "\n\n" + jqXHR.responseText : "";
    }
    if(!msg) {
      msg = "Okänt fel vid serveranrop";
    }
    showErrorMsg(msg);
  }

  // Fyll och visa felinfodialogen
  function showErrorMsg(msg) {
    var obj = $("#errorText").text(msg);
    obj.html(obj.html().replace(/\n/g, "<br/>"));
    $("#errorDialog").fadeIn("slow");
    return null;
  }

  // Om allt gick bra dölj felinfodialogen
  function allOK() {
    $("#errorDialog").hide();
  }


  //==================================================
  // Utils
  //==================================================

  // Formattera priser (Det framgår inte vilken valuta priserna är i,
  // men vi antar att de alltid skall visas med 2 decimaler)
  function FormatCurrency(numval) {
    try {
      return numval.toLocaleString(
        undefined,
        { minimumFractionDigits: 2, maximumFractionDigits: 2 }
      );
    } catch (e) {
      return numval.toFixed(2);
    }
  }

  if (typeof String.prototype.endsWith !== "function") {
    String.prototype.endsWith = function (suffix) {
      return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
  }

  //==================================================
  // Anropa servern
  //==================================================

  // Anrop genom BookstoreService.asmx
  function WSMethod(fn, params, successFn) {
    var serverPage = "BookstoreService.asmx";
    ServerCallWebService(serverPage, fn, params, successFn, failedAjaxFn);
  }

  PageLoad();
});
