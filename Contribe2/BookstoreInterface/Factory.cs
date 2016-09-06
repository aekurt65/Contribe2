using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Contribe2.BookstoreInterface {
  public class Factory {
    static public IBookstoreService getBookstoreServer() {
      return Contribe2.BookstoreSrv.BookstoreService.get();
    }
  }
}