jQuery(document).ready(function ($) {

  var nofcalls = 0;
  function ttest() {
    nofcalls += 1;
    $("#kalle").text("nisse " + nofcalls);
  }

  var UserID = "";

  // Logga in
  $("#btnLogin").click(function () {
    UserID = $("#txtLogin").val().trim();
    if (UserID) {
      $("#userid").text(UserID);
      $("#LoggedIn").show();
      $("#NotLoggedIn").hide();
      GetUserInfo();
    }
  });

  // Logga ut
  $("#btnLogout").click(function () {
    UserID = "";
    $("#LoggedIn").hide();
    $("#NotLoggedIn").show();
  });

  // Hämta kundvagn och orderinfo

  function GetUserInfo() {
    var params = ["UserID", UserID];
    PageMethod("GetUserInfo", params, FillUserInfo, failedAjaxFn);
  }

  function FillUserInfo(result) {
    var obj = checkAjaxResult(result);
    if (obj) {
      FillCartRows(obj.cart);
      FillOrderList(obj.customerOrder);
    }
  }

  // Sökfunktion

  $("#btnSearch").click(function () {
    var strSearch = $("#txtSearch").val();
    var params = ["strSearch", strSearch];
    PageMethod("SearchBooks", params, FillSearchResultList, failedAjaxFn);
  });

  function FillSearchResultList(result) {
    var obj = checkAjaxResult(result);
    obj && FillSearchResultRow(obj);
  }

  // Hämta kundvagn

  function GetCart() {
    if (!UserID) {
      return;
    }
    var params = ["UserID", UserID];
    PageMethod("GetCart", params, FillCartList, failedAjaxFn);
  }

  // Ta bort från kundvagn

  function RemoveFromCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = ["UserID", UserID, "BookID", bookid];
    PageMethod("RemoveBook", params, FillCartList, failedAjaxFn);
  }

  // Utför beställning

  $("#btnPlaceOrder").click(function () {
    if (!UserID) {
      alert("Du måste logga in igen");
      return;
    }
    var params = ["UserID", UserID];
    PageMethod("PlaceOrderAllBooksInCart", params, FillOrderList, failedAjaxFn);
  });

  function FillOrderList(result) {
    var obj = checkAjaxResult(result);
    obj && FillOrderRows(obj);
  }


  // Lägga till i kundvagn

  function AddToCart(bookid) {
    if (!UserID) {
      alert("Du måste logga in först");
      return;
    }
    var params = ["UserID", UserID, "BookID", bookid];
    PageMethod("AddBook", params, FillCartList, failedAjaxFn);
  }

  function FillCartList(result) {
    var obj = checkAjaxResult(result);
    obj && FillCartRows(obj);
  }

  // Fyll sökresultat

  function FillSearchResultRow(objResult) {
    var template = $("#SearchresultRowTemplate");
    $("#tblSearchResult tbody > tr").remove();
    for (var i = 0; i < objResult.length; i++) {
      var book = objResult[i];
      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(book.price);
      $(newRow).find(".InStock").text(book.inStock);
      $(newRow).find(".AddBookBtn").attr("bookid", book.bookid).click(function () {
        AddToCart($(this).attr("bookid"));
      });
      var $td = $("<td>").append(
        newRow
      );
      var $tr = $("<tr>").append($td)
      $tr.appendTo("#tblSearchResult");
    }
    if (objResult.length > 0) {
      $("#SearchresultHeader").text("Sökresultat");
    } else {
      $("#SearchresultHeader").text("Inga böcker matcher sökvillkoret");
    }
    
    var apa = "hej";
  }

  // Fyll kundvagninfo

  function FillCartRows(objResult) {
    $("#tblCart tbody > tr").remove();
    var template = $("#CartRowTemplate");
    for (var i = 0; i < objResult.length; i++) {
      var item = objResult[i];
      var book = item.book;
      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(book.price);
      $(newRow).find(".NumItems").text(item.nItems);
      $(newRow).find(".RemoveBookBtn").attr("bookid", book.bookid).click(function () {
        RemoveFromCart($(this).attr("bookid"));
      });
      var $td = $("<td>").append(
        newRow
      );
      var $tr = $("<tr>").append($td)
      $tr.appendTo("#tblCart");
    }
    if (0 == objResult.length) {
      $("#Cartheader").text("Kundvagnen är tom");
    }
    else {
      $("#Cartheader").text("Din kundvagn:");
    }
    var apa = "hej";
  }

  // Fyll orderinfo

  function FillOrderRows(objResult) {
    $("#tblPlacedOrder tbody > tr").remove();
    var template = $("#OrderRowTemplate");
    for (var i = 0; i < objResult.length; i++) {
      var item = objResult[i];
      var book = item.book;

      var newRow = template.clone().removeAttr("id");
      $(newRow).find(".Title").text(book.title);
      $(newRow).find(".Author").text(book.author);
      $(newRow).find(".Price").text(book.price);
      $(newRow).find(".NumDelivered").text(item.delivered);
      $(newRow).find(".NumRest").text(item.rest);
      var $td = $("<td>").append(
        newRow
      );
      var $tr = $("<tr>").append($td)
      $tr.appendTo("#tblPlacedOrder");
    }
    if (0 == objResult.length) {
      $("#Cartheader").text("Detfinns inga beställda varor");
    }
    else {
      $("#Cartheader").text("Beställda varor:");
    }
    var apa = "hej";
    var bpa = "fackets bygg";
  }

  // Rensa kundvagn och orderinfo

  function ClearUserinfo() {
    $("#tblCart tbody > tr").remove();
    $("#tblPlacedOrder tbody > tr").remove();
  }

  // Generella Felinfo-funktioner

  var checkAjaxResult = function (result) {
    succededAjaxFn(result);
    var objResult = JSON && JSON.parse(result.d) || $.parseJSON(result.d);
    if (objResult.error != null) {
      failedAjaxFn(obl.error);
      return null;
    }
    var obj = JSON && JSON.parse(objResult.strValue) || $.parseJSON(objResult.strValue);
    return obj;
  }

  var succededAjaxFn = function (result) {
    $("#result").hide();
    $("#result").text("All OK");
    $("#result").css({ background: "green", padding: "10px", color: "white" });
    // $("<p>" + result.d + "</p>").css({ background: "green", padding: "10px", color: "white" }).appendTo("#result");
    $("#result").fadeIn("slow");
  }

  var failedAjaxFn = function (result) {
    $("#result").hide();
    $("#result").text(result.d || result);
    $("#result").css({ background: "red", padding: "10px", color: "white" });
    //$("<p>Failed : " + result.d + "</p>").css({ background: "red", padding: "10px", color: "white" }).appendTo("#result");
    $("#result").fadeIn("slow");

  }

  function getDateTime() {
    $.ajax({
      type: "POST",
      url: "Default.aspx/CallMe",
      data: "{}",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: OnSuccess,
      failure: function (response) {
        alert("Error: " + response.d);
      }
    });
  }
  function OnSuccess(response) {
    alert("Success: " + response.d);
  }

  $("#DateTimeTest").click(function () {
    getDateTime();
  });
});