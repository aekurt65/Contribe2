using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterface {
  public interface IServiceReply<T> {

    /// <summary>
    /// Exception information, including message string and stack trace
    /// </summary>
    string Error { get; set; }

    /// <summary>
    /// Error information, should be in a format that can be shown to the end user
    /// </summary>
    string Info { get; set; }

    /// <summary>
    /// The actual return object from the method called
    /// </summary>
    T Result { get; set; }
  }
}
