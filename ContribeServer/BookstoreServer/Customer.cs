using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreServer {
  public class Customer : ICustomerInfo{
    static Customer ByID(string userID) {
      return Customers.Instance.GetCustomerByID(userID);
    }

    Books books = Books.Instance;

    public string userid { get { return _userid; } }
    public ICart cart { get { return _cart; } }
    public ICustomerOrder customerOrder { get { return _customerOrder; } }

    private readonly string _userid;
    private readonly Cart _cart;
    private readonly CustomerOrder _customerOrder;

    public Customer(string userID) {
      _userid = userID;
      _cart = new Cart();
      _customerOrder = new CustomerOrder();
    }

    public ICustomerOrder GetOrder() {
      return customerOrder;
    }

    public Cart GetCart() {
      return _cart;
    }

    public ICart AddBookToCart(string bookID) {
      _cart.AddItem(bookID);
      return cart;
    }

    public ICart RemoveBookFromCart(string bookID) {
      _cart.RemoveItem(bookID);
      return cart;
    }

    /// <summary>
    /// Moves all items from the users cart to the users order
    /// </summary>
    /// <returns></returns>
    public ICustomerInfo AddItemsFromCart() {
      lock (cart) {
        foreach (Cart.Item cartItem in cart.cartItems) {
          string bookID = cartItem.book.bookid;
          MoveBookFromCartToOrder(bookID, cartItem.nItems);
        }
        _cart.Clear();
      }

      return this;
    }

    public ICustomerInfo OrderBooks(IDictionary<string, int> dicBooksToorder) {
      books.CheckBookIdsExist(dicBooksToorder.Keys);

      lock (_cart) {
        // Check that all books in the list are present in the users cart
        foreach (string bookID in dicBooksToorder.Keys) {
          int nWanted = dicBooksToorder[bookID];
          if (_cart.nBooksInCart(bookID) < nWanted) {
            throw new Common.InfoException(Txt.CartChanged);
          }
        }
        foreach (string bookID in dicBooksToorder.Keys) {
          int nWanted = dicBooksToorder[bookID];
          MoveBookFromCartToOrder(bookID, nWanted);
        }
      }
      return this;
    }

    private void MoveBookFromCartToOrder(string bookID, int nWanted) {
      int nDelivered = 0;
      int nRest = nWanted;
      Book book = books.GetBookByID(bookID);
      if (book != null) {
        nDelivered = book.RetrieveItems(nWanted);
        nRest = nWanted - nDelivered;
        _customerOrder.AddItems(bookID, nDelivered, nRest);
        _cart.RemoveItem(bookID, nWanted);
      }
    }

    public int nDeliveredBooks(string bookID) {
      return _customerOrder.nDeliveredByBookID(bookID);
    }

    public int nRestBooks(string bookID) {
      return _customerOrder.nRestByBookID(bookID);
    }
  }
}
