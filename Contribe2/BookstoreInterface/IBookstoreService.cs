using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contribe2.BookstoreInterface {
  public interface IBookstoreService {
    /// <summary>
    /// Returns list of books matching a search string.
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    Task<IEnumerable<IBook>> GetBooksAsync(string searchString);

    /// <summary>
    /// Adds a book  to a users cart
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="BookID"></param>
    /// <returns></returns>
    Task<ICart> AddBookAsync(string UserID, string BookID);

    /// <summary>
    /// Removes one book from users cart
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="BookID"></param>
    /// <returns></returns>
    Task<ICart> RemoveBookAsync(string UserID, string BookID);

    /// <summary>
    /// Place an order with all contents of a users cart
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    Task<ICustomerInfo> PlaceOrderAllBooksInCartAsync(string UserID);

    /// <summary>
    /// Gets information about a user, including the users cart and information about
    /// the users placed orders
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    Task<ICustomerInfo> GetCustomerInfo(string UserID);

    Task<ICustomerInfo> ErrorTestAsync(string UserID);

  }
}
