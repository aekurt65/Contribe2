using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contribe2.BookstoreSrv {
  public class UserLocks {
    static Dictionary<string, Object> dic = new Dictionary<string, Object>();
    static public object GetLock(string UserID) {
      object obj;
      lock (dic) {
        if (!dic.TryGetValue(UserID, out obj)) {
          obj = new object();
          dic.Add(UserID, obj);
        }
      }
      return obj;
    }
  }
}