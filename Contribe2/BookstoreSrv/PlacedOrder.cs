using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class PlacedOrder : ICustomerOrder {
    dbBookStore db = dbBookStore.get();

    private class Itemdef {
      public string BookID;
      public int Delivered;
      public int Rest;
      public Itemdef(string BookID, int Delivered, int Rest) {
        this.BookID = BookID;
        this.Delivered = Delivered;
        this.Rest = Rest;
      }
    }
    Dictionary<string, Itemdef> dicOrderedBooks = new Dictionary<string, Itemdef>();

    public ICustomerInfo AddItemsFromCart(string UserID, Cart cart) {
      IEnumerable<ICartItem> cartItems = cart.cartItems;

      lock(cart) {
        foreach (Cart.Item cartItem in cartItems) {
          string BookID = cartItem.book.bookid;
          Book book = db.GetBookByID(BookID);
          int nWanted = cartItem.nItems;
          if (nWanted == 0) {
            continue;
          }

          // If a book is not present in the database then we can deliver 0 items
          int nDelivered = 0;
          int nRest = nWanted;
          if (book != null) {
            nDelivered = book.RetrieveItems(nWanted);
            nRest = nWanted - nDelivered;
            Itemdef itemInOrder;
            lock(dicOrderedBooks) {
              if (dicOrderedBooks.TryGetValue(BookID, out itemInOrder)) {
                itemInOrder.Delivered += nDelivered;
                itemInOrder.Rest += nRest;
              }
              else {
                itemInOrder = new Itemdef(BookID, nDelivered, nRest);
                dicOrderedBooks.Add(BookID, itemInOrder);
              }
            }
          }
        }
        cart.Clear();
      }

      return new CustomerInfo(UserID, cart, this);
    }

    public class Item : ICustomerOrderItem {
      public IBook book { get; }
      public int nDelivered { get; }
      public int nRest { get; }
      public decimal sumPay {
        get { return (nDelivered + nRest) * book.price; }
      }

      public Item(IBook book, int delivered, int rest) {
        this.book = book;
        this.nDelivered = delivered;
        this.nRest = rest;
      }
    }

    public List<ICustomerOrderItem> getBookList() {
      List<ICustomerOrderItem> lst = new List<ICustomerOrderItem>();
      foreach (Itemdef itemdef in dicOrderedBooks.Values) {
        Book book = db.GetBookByID(itemdef.BookID);
        lst.Add(new Item(book, itemdef.Delivered, itemdef.Rest));
      }
      return lst;
    }

    public List<ICustomerOrderItem> orderitems {
      get {
        return getBookList();
      }
    }

    public int nDeliveredBooksinOrder(string BookID) {
      int nBooks = 0;
      Itemdef itemdef;
      if (dicOrderedBooks.TryGetValue(BookID, out itemdef)) {
        nBooks = itemdef.Delivered;
      }
      return nBooks;
    }

    public int nRestBooksinOrder(string BookID) {
      int nBooks = 0;
      Itemdef itemdef;
      if (dicOrderedBooks.TryGetValue(BookID, out itemdef)) {
        nBooks = itemdef.Rest;
      }
      return nBooks;
    }
  }
}