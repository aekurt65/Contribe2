using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contribe2.BookstoreSrv {
  class Utils {
    static public string[] SplitWhiteChar(params string[] strings) {
      char[] arSeparators = new char[] { ' ', '\n', '\t' };
      string strJoin = string.Join(" ", strings);
      return strJoin.Split(arSeparators, StringSplitOptions.RemoveEmptyEntries);
    }
    static public bool AnyStringStartsWith(string str, string[] ar) {
      bool bolRet = false;
      foreach (string strPart in ar) {
        if (strPart.StartsWith(str, StringComparison.CurrentCultureIgnoreCase)) {
          bolRet = true;
          break;
        }
      }
      return bolRet;
    }

    static public bool streq(string str1, string str2) {
      bool ret = false;
      if(str1 == str2 || str1 != null && str1.Equals(str2,StringComparison.CurrentCultureIgnoreCase)) {
        ret = true;
      }
      return ret;
    }
  }
}
