using System;

namespace Common {
  /// <summary>
  /// Base class for singleton classes
  /// </summary>
  /// <typeparam name="T"></typeparam>
  abstract public class Singleton<T> where T : Singleton<T>, new() {
    private static readonly T _this;
    static Singleton() { _this = new T(); }
    protected Singleton() { Initialize(); }
    public static T Instance { get { return _this; } }
    protected virtual void Initialize() { }
  }
}
