using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using BookstoreInterface;

namespace BookstoreServer {
  public class Books : Common.Singleton<Books> {
    const string strUri = "http://www.contribe.se/arbetsprov-net/books.json";

    /// <summary>
    /// On creation initial content is fetched from 
    /// the Contribe server, unless we are in test mode,
    /// in which case no intial content is added
    /// </summary>
    protected override void Initialize() {
      if (!Utils.IsInUnitTest) {
        FillDatabase();
      }
    }

    /// <summary>
    /// The one and only database with our books
    /// </summary>
    private Dictionary<string, Book> dicBooks = new Dictionary<string, Book>();

    // Used for decoding json-string with books from contribe server
    private class BookList {
      public List<Book> books { get; set; }
    }

    private void FillDatabase() {
      bool isInDevelopment = false;

      string jsonBooks;
      if (isInDevelopment) {
        jsonBooks = "{\"books\": [ " +
            "{\"title\":\"Mastering åäö\", \"author\":\"Average Swede\", \"price\":762, \"inStock\":15}," +
            "{\"title\":\"How To Spend Money\", \"author\":\"Rich Block\", \"price\":1000000, \"inStock\":1}," +
            "{\"title\":\"Generic Title\", \"author\":\"First Author\", \"price\":185.5, \"inStock\":5}," +
            "{\"title\":\"Generic Title\", \"author\":\"Second Author\", \"price\":1748, \"inStock\":3}," +
            "{\"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":999, \"inStock\":20}," +
            "{\"title\":\"Random Sales\", \"author\":\"Cunning Bastard\", \"price\":499.5, \"inStock\":3}," +
            "{\"title\":\"Desired\", \"author\":\"Rich Bloke\", \"price\":564.5, \"inStock\":0}" +
            "]}";
      }
      else {
        using (WebClient webClient = new WebClient()) {
          webClient.Encoding = Encoding.UTF8;
          jsonBooks = webClient.DownloadString(strUri);
        }
      }

      BookList books = Newtonsoft.Json.JsonConvert.DeserializeObject<BookList>(jsonBooks);
      foreach (Book book in books.books) {
        if(book.inStock >= 0) {
          AddBooks(book.title, book.author, book.price, book.inStock);
        }
      }
    }

    /// <summary>
    /// Checks if all book Ids in a list really exist, if not throws an InfoException
    /// </summary>
    /// <param name="bookIds">A list of Book Ids to check if they exist</param>
    public void CheckBookIdsExist(IEnumerable<string> bookIds) {
      foreach (string bookId in bookIds) {
        if (!dicBooks.ContainsKey(bookId)) {
          throw new Common.InfoException(Txt.BookNotExists, bookId);
        }
      }
    }

    /// <summary>
    /// Retrievs a book from the database
    /// </summary>
    /// <param name="BookID"></param>
    /// <returns>Book if found, otherwise null</returns>
    public Book GetBookByID(string BookID) {
      Book book;
      dicBooks.TryGetValue(BookID, out book);
      return book;
    }

    /// <summary>
    /// Searches books by title and/or author
    /// </summary>
    /// <param name="searchString">White space delimited strings which all of
    /// them </param>
    /// <returns>a list of books containing all white space delimited search strings 
    /// in searchString
    /// as beginning of words in either title or author field</returns>
    public List<IBook> searchBooks(string searchString) {
      string[] arSearchStrings = Utils.SplitWhiteChar(searchString);
      List<IBook> lstRet = new List<IBook>();
      foreach (Book book in dicBooks.Values) {
        if (DoesMatch(book, arSearchStrings)) {
          lstRet.Add(book);
        }
      }
      return lstRet;
    }

    private bool DoesMatch(IBook book, IEnumerable<string> lstStrSearch) {
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

    /// <summary>
    /// Adds zero or more books of one type to the database.
    /// If the same book already exists in the database the number of
    /// books of this type is increased, otherwise a new book entry
    /// is created.
    /// The criteria for being the same book is that title, author and price match.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="price"></param>
    /// <param name="nAdd"></param>
    /// <returns></returns>
    public Book AddBooks(string title, string author, decimal price, int nAdd) {
      if (nAdd < 0) {
        throw new ArgumentOutOfRangeException("nAdd");
      }
      Book bookAdd = null;
      foreach (Book book in dicBooks.Values) {
        if (IsSameBook(book, title, author, price)) {
          book.AddItems(nAdd);
          bookAdd = book;
          break;
        }
      }
      if (bookAdd == null) {
        bookAdd = new Book(title, author, price, nAdd);
        dicBooks.Add(bookAdd.bookid, bookAdd);
      }
      return bookAdd;
    }

    private bool IsSameBook(Book book, string title, string author, decimal price) {
      return Utils.streq(book.title, title) && 
        Utils.streq(book.author, author) &&
        book.price == price;
    }

    /// <summary>
    /// Empty database, used for test
    /// </summary>
    public void Clear() {
      dicBooks.Clear();
    }
  }
}
