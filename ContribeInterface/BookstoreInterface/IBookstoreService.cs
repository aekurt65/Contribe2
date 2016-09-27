using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInterface {
  public interface IBookstoreService {

    /// <summary>
    /// Returns list of books matching a search string.
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    Task<IEnumerable<IBook>> GetBooksAsync(string searchString);

    /// <summary>
    /// Adds a book to a users cart
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="BookID"></param>
    /// <returns></returns>
    Task<ICart> AddBookAsync(string UserID, string BookID);

    /// <summary>
    /// Removes one book from users cart
    /// </summary>
    /// <param name="UserID">User for whom to remove a book from the cart</param>
    /// <param name="BookID"></param>
    /// <returns></returns>
    Task<ICart> RemoveBookAsync(string UserID, string BookID);

    /// <summary>
    /// Place an order with all contents of a users cart
    /// </summary>
    /// <param name="UserID">User for whom to place the order</param>
    /// <returns>Info for customer (Cart and order) after the order is placed.</returns>
    Task<ICustomerInfo> PlaceOrderAllBooksInCartAsync(string UserID);

    /// <summary>
    /// Place order for list of books
    /// </summary>
    /// <param name="UserID">User for whom to place the order</param>
    /// <param name="bookIds">JSON-encoded Dictionary of bookIds to order, 
    /// Key in the dictionary is bookId and value is number of books to order</param>
    /// <returns>Info for customer (Cart and order) after the order is placed.
    /// If one or more of the books in the order are not present in the users cart
    /// then ther order is not processed and an InfoException is thrown</returns>
    Task<ICustomerInfo> PlaceOrderAsync(string UserID, string jsonDicBooksToOrder);

    /// <summary>
    /// Gets information about a user, including contents of the users cart and
    /// information about the users placed orders
    /// </summary>
    /// <param name="UserID">User for whom to gwt information</param>
    /// <returns></returns>
    Task<ICustomerInfo> GetCustomerInfoAsync(string UserID);

    /// <summary>
    /// Test method that always throws Exception
    /// </summary>
    /// <returns>No return object due to an Exception being thrown</returns>
    Task<object> ExceptionTestAsync();

    /// <summary>
    /// Test method that always throws InfoException
    /// </summary>
    /// <returns>No return object due to an IInfoException being thrown</returns>
    Task<object> InformationTestAsync();

    /// <summary>
    /// Test method that takes some time
    /// </summary>
    /// <param name="milliSeconds"></param>
    /// <returns>A string containing information about the time taken by the call</returns>
    Task<string> LongRunningTestAsync(int milliSeconds);

    /// <summary>
    /// Test method that takes some time, not using Task
    /// </summary>
    /// <param name="milliSeconds"></param>
    /// <returns>A string containing information about the time taken by the call</returns>
    string LongRunningTest(int milliSeconds);
  }
}
