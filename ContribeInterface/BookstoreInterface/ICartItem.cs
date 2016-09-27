using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInterface {
  public interface ICartItem {
    IBook book { get; }
    int nItems { get; }
  }
}
