jQuery(document).ready(function ($) {
  var UserID = "";

  // Start

  function PageLoad() {
    ClearUserinfo();
    $("#errorDialog").hide();
  }

  // Feltest
  $("#Feltest").click(function () {
    var params = ["UserID", UserID];
    PageMethod("ErrorTest", params, HandleSearchResult, failedAjaxFn);
  });


  // Logga in

  $("#btnLogin").click(function () {
    UserID = $("#txtLogin").val().trim();
    if (UserID) {
      $("#userid").text(UserID);
      $("#LoggedIn").show();
      $("#NotLoggedIn").hide();
      GetUserInfo();
    }
    return false;
  });

  // Logga ut

  $("#btnLogout").click(function () {
    UserID = "";
    $("#LoggedIn").hide();
    $("#NotLoggedIn").show();
    ClearUserinfo();
    return false;
  });

  // Hämta kundvagn och orderinfo

  function GetUserInfo() {
    var params = ["UserID", UserID];
    PageMethod("GetUserInfo", params, HandleIUserInfo, failedAjaxFn);
  }

  // Sökfunktion

  $("#btnSearch").click(function () {
    var strSearch = $("#txtSearch").val();
    var params = ["strSearch", strSearch];
    PageMethod("SearchBooks", params, HandleSearchResult, failedAjaxFn);
    return false;
  });

  // Lägga till i kundvagn

  function AddToCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = ["UserID", UserID, "BookID", bookid];
    PageMethod("AddBook", params, HandleICart, failedAjaxFn);
  }

  // Ta bort från kundvagn

  function RemoveFromCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = ["UserID", UserID, "BookID", bookid];
    PageMethod("RemoveBook", params, HandleICart, failedAjaxFn);
  }

  // Utför beställning

  $("#btnPlaceOrder").click(function () {
    if (!UserID) {
      alert("Du måste logga in igen");
      return;
    }
    var params = ["UserID", UserID];
    PageMethod("PlaceOrderAllBooksInCart", params, HandleIUserInfo, failedAjaxFn);
  });

  // Callbackhanterare

  function HandleSearchResult(result) {
    var obj = checkAjaxResult(result);
    obj && FillSearchResultRows(obj);
  }

  function HandleICart(result) {
    var obj = checkAjaxResult(result);
    obj && FillCartRows(obj);
  }

  function HandleIUserInfo(result) {
    var obj = checkAjaxResult(result);
    if (obj) {
      FillCartRows(obj.cart);
      FillOrderRows(obj.customerOrder);
    }
  }

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
    $("#tblCart tbody > tr").remove();
    var template = $("#CartRowTemplate");
    var cartItems = objResult.cartItems;
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
    var orderItems = objResult.orderitems;
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
        $("TextRestnoterade").hide();
      }
      var rowSum = book.price * (item.nDelivered + item.nRest);
      totSum += rowSum;
      $(newRow).find(".Rowsum").text(FormatCurrency(rowSum));

      var $td = $("<td>").append(
        newRow
      );
      var $tr = $("<tr>").append($td)
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

  // Generella Felinfo-funktioner

  function checkAjaxResult(result) {
    var objResult = JSON && JSON.parse(result.d) || $.parseJSON(result.d);
    if (objResult.error != null) {
      failedAjaxFn(objResult);
      return null;
    }
    succededAjaxFn(result);
    var obj = JSON && JSON.parse(objResult.strValue) || $.parseJSON(objResult.strValue);
    return obj;
  }

  function succededAjaxFn(result) {
    $("#errorDialog").hide();
  }

  function failedAjaxFn(result) {
    $("#errorText").text(result.d || result.responseText || result.error || result);
    $("#errorDialog").fadeIn("slow");
  }

  PageLoad();
});