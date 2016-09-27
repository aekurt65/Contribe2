//==================================================
// Method for Webservice calls
//==================================================

function ServerCallWebService(serverPage, fn, params, successFn, errorFn) {
  var url = serverPage + "/" + fn;
  var argList = JSON.stringify(params);

  $.ajax({
    type: "POST",
    url: url,
    contentType: "application/json; charset=utf-8",
    data: argList,
    dataType: "json",
    success: successFn,
    error: errorFn
  });
}
