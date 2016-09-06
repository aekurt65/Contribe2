using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {

  /// <summary>
  /// Class to emulate a database containing books.
  /// Now we don't have a real database, we get an initial content of books
  /// from Contribes server and keep in memory as an internal database.
  /// As books are bought they are retrieved from the database, until there
  /// are no more books left in stock. In this version there is no way to fill
  /// the database other than to reset the server.
  /// </summary>
  /// 
  public class dbBookStore {
    static dbBookStore _me = new dbBookStore();
    static public dbBookStore get() { return _me; }

    const string strUri = "http://www.contribe.se/arbetsprov-net/books.json";

    /// <summary>
    /// This is the actual database where the books are stored
    /// </summary>
    private Dictionary<string, Book> dicBooks = new Dictionary<string, Book>();

    /// <summary>
    /// Create the database and fill it with initial content
    /// </summary>
    private dbBookStore(){
      //FillDatabase();
    }

    private class Books {
      public List<Book> books { get; set; }
    }

    private void FillDatabase() {
      // string strRespons = WebCall(strUri);
      string strRespons = "{\"books\": [ " +
          "{\"title\":\"Mastering åäö\", \"author\":\"Average Swede\", \"price\":762, \"inStock\":15}," +
          "{\"title\":\"How To Spend Money\", \"author\":\"Rich Block\", \"price\":1000000, \"inStock\":1}," +
          "{\"title\":\"Generic Title\", \"author\":\"First Author\", \"price\":185.5, \"inStock\":5}," +
          "{\"title\":\"Generic Title\", \"author\":\"Second Author\", \"price\":1748, \"inStock\":3}," +
          "{\"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":999, \"inStock\":20}," +
          "{\"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":499.5, \"inStock\":3}," +
          "{\"title\":\"Desired\", \"author\":\"Rich Bloke\", \"price\":564.5, \"inStock\":0}" +
          "]}";
      Books books = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(strRespons);
      List<Book> lstBooks = books.books;
      foreach (Book book in lstBooks) {
        dicBooks.Add(book.bookid, book);
      }
    }

    /// <summary>
    /// Calls an URI and returns the result in string format
    /// </summary>
    /// <param name="strUrl"></param>
    /// <returns></returns>
    string WebCall(string strUrl) {
      Uri uri = new Uri(strUrl);

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUri);
      request.ProtocolVersion = HttpVersion.Version10;
      request.Method = "GET";
      request.Host = uri.Host;
      request.Credentials = CredentialCache.DefaultCredentials;
      request.Accept = "application/json, text/javascript, */*";
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
      string strRespons = sr.ReadToEnd();
      return strRespons;
    }


    string CreateBookKey() {
      return Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    // IRL with tons of books we'd need indexes, but then we'd also have a real database
    void CreateIndexes(List<Book> lstBooks, string strSearch) {
      // TBD
    }

    public Book GetBookByID(string BookID) {
      Book book;
      dicBooks.TryGetValue(BookID, out book);
      return book;
    }

    /// <summary>
    /// Searches books by title and/or author
    /// </summary>
    /// <param name="strSearch"></param>
    /// <returns>a list of books containing all search strings 
    /// as beginning of words in either title or author field</returns>
    public List<IBook> searchBooks(List<string> lstStrSearch) {
      List<IBook> lstRet = new List<IBook>();
      foreach (Book book in dicBooks.Values) {
        if (DoesMatch(book, lstStrSearch)) {
          lstRet.Add(book);
        }
      }
      return lstRet;
    }

    private bool DoesMatch(IBook book, List<string> lstStrSearch) {
      bool doesMatch = true;
      string[] arWordList = Utils.SplitWhiteChar(book.author, book.title);
      foreach (string str in lstStrSearch) {
        if (!Utils.AnyStringStartsWith(str, arWordList)) {
          doesMatch = false;
          break;
        }
      }
      return doesMatch;
    }


    // Only used for test purpouses
    public Book AddTestBook(Book bookAdd) {
      if (bookAdd == null) {
        throw new ArgumentNullException();
      }

      Book bookDb;
      if (!dicBooks.TryGetValue(bookAdd.bookid, out bookDb)) {
        bookDb = bookAdd;
        dicBooks.Add(bookAdd.bookid, bookAdd);
      }

      return bookDb;
    }

    public Book AddBooks(string title, string author, decimal price, int nAdd) {
      Book bookAdd = null;
      foreach (Book book in dicBooks.Values) {
        if(IsSameBook(book, title, author, price)) {
          book.AddItems(nAdd);
          bookAdd = book;
          break;
        }
      }
      if(bookAdd == null) {
        bookAdd = new Book(title, author, price, nAdd);
        dicBooks.Add(bookAdd.bookid, bookAdd);
      }

      return bookAdd;
    }

    private bool IsSameBook (Book book,string title, string author, decimal price) {
      bool ret = false;
      if (Utils.streq(book.title, title) && Utils.streq(book.author, author) && book.price == price) {
        ret = true;
      }
      return ret;
    }
  }
}
