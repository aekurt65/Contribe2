using System;
using System.Runtime.Serialization;

namespace Common {
  /// <summary>
  /// Exception that probably should render an 
  /// information dialog shown to he user.
  /// </summary>
  public class InfoException : Exception {
    public InfoException(string msg) : base(msg) { }
    public InfoException(string format, params string[] args) :
      base(string.Format(format, args)) { }
    protected InfoException(
      SerializationInfo info,
      StreamingContext context
    ) : base(info, context) { }
  }
}
