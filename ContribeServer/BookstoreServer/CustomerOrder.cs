using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookstoreInterface;

namespace BookstoreServer {
  public class CustomerOrder : ICustomerOrder {
    private Books dbBooks = Books.Instance;

    private class Item : ICustomerOrderItem {
      public IBook book { get; }
      public int nDelivered { get; }
      public int nRest { get; }

      public Item(IBook book, ItemInfo info) {
        this.book = book;
        this.nDelivered = info.Delivered;
        this.nRest = info.Rest;
      }
    }


    private struct ItemInfo {
      public int Delivered;
      public int Rest;
      public ItemInfo(int Delivered, int Rest) {
        this.Delivered = Delivered;
        this.Rest = Rest;
      }
    }

    private Dictionary<string, ItemInfo> dicOrderedBooks = new Dictionary<string, ItemInfo>();

    public IEnumerable<ICustomerOrderItem> orderItems {
      get {
        List<ICustomerOrderItem> lst = new List<ICustomerOrderItem>();
        foreach (string bookID in dicOrderedBooks.Keys) {
          IBook book = dbBooks.GetBookByID(bookID);
          lst.Add(new Item(book, dicOrderedBooks[bookID]));
        }
        return lst;
      }
    }

    public int nDeliveredByBookID(string BookID) {
      int nBooks = 0;
      ItemInfo itemInfo;
      if (dicOrderedBooks.TryGetValue(BookID, out itemInfo)) {
        nBooks = itemInfo.Delivered;
      }
      return nBooks;
    }


    public int nRestByBookID(string BookID) {
      int nBooks = 0;
      ItemInfo itemInfo;
      if (dicOrderedBooks.TryGetValue(BookID, out itemInfo)) {
        nBooks = itemInfo.Rest;
      }
      return nBooks;
    }

    public void AddItems(string bookID, int nDelivered, int nRest) {
      ItemInfo itemInfo;
      lock (dicOrderedBooks) {
        if (!dicOrderedBooks.TryGetValue(bookID, out itemInfo)) {
          itemInfo = new ItemInfo();
        }
        itemInfo.Delivered += nDelivered;
        itemInfo.Rest += nRest;
        dicOrderedBooks[bookID] = itemInfo;
      }
    }
  }
}