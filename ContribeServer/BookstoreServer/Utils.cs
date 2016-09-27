using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookstoreServer {

  /// <summary>
  /// Static class containing utility functions
  /// </summary>
  static class Utils {

    /// <summary>
    /// Checks if we are running in unit test mode (i.e. assembly UnitTestFramework is loaded)
    /// </summary>
    static public bool IsInUnitTest {
      get {
        // http://stackoverflow.com/questions/3167617/determine-if-code-is-running-as-part-of-a-unit-test
        const string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
        return AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith(testAssemblyName));
      }
    }

    /// <summary>
    /// Returns an array of all white space separated tokens in parameter strings
    /// </summary>
    /// <param name="strings"></param>
    /// <returns></returns>
    static public string[] SplitWhiteChar(params string[] strings) {
      char[] arSeparators = new char[] { ' ', '\n', '\t' };
      string strJoin = string.Join(" ", strings);
      return strJoin.Split(arSeparators, StringSplitOptions.RemoveEmptyEntries);
    }


    /// <summary>
    /// Checks if any of the strings in ar starts with str
    /// </summary>
    /// <param name="str"></param>
    /// <param name="ar"></param>
    /// <returns></returns>
    static public bool AnyStringStartsWith(string str, string[] ar) {
      return ar.Any(s => s.StartsWith(str, StringComparison.CurrentCultureIgnoreCase));
    }

    /// <summary>
    /// Case insensitive version of string.Equals(str1, str2)
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    static public bool streq(string str1, string str2) {
      return string.Equals(str1, str2, System.StringComparison.CurrentCultureIgnoreCase); ;
    }
  }
}
