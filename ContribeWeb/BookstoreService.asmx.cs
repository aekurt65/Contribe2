using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BookstoreInterface;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Services;

namespace ContribeWeb {
  /// <summary>
  /// Summary description for WebService1
  /// </summary>
  [WebService(Namespace = "http://contribe.se/KurtAebischer")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  [XmlInclude(typeof(BookstoreServer.Book))]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  [System.Web.Script.Services.ScriptService]

  public class BookstoreService : IBookstoreService {

    private BookstoreServer.Bookstore worker = BookstoreServer.Bookstore.Instance;

    #region Interface implementation

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<IEnumerable<IBook>> GetBooksAsync(string searchString) {
      return HandleTaskResponse<IEnumerable<IBook>>(() => worker.GetBooks(searchString));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<ICart> AddBookAsync(string UserID, string BookID) {
      return HandleTaskResponse<ICart>(() => worker.AddBookToCart(UserID, BookID));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<ICart> RemoveBookAsync(string UserID, string BookID) {
      return HandleTaskResponse<ICart>(() => worker.RemoveBookFromCart(UserID, BookID));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<ICustomerInfo> PlaceOrderAllBooksInCartAsync(string UserID) {
      return HandleTaskResponse<ICustomerInfo>(() => worker.PlaceOrderAllbooksInCart(UserID));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<ICustomerInfo> PlaceOrderAsync(string UserID, string jsonDicBooksToOrder) {
      return HandleTaskResponse<ICustomerInfo>(() => worker.PlaceOrder(UserID, jsonDicBooksToOrder));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<ICustomerInfo> GetCustomerInfoAsync(string UserID) {
      return HandleTaskResponse<ICustomerInfo>(() => worker.GetCustomerInfo(UserID));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<object> ExceptionTestAsync() {
      return HandleTaskResponse<object>(() => worker.ExceptionTest());
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<object> InformationTestAsync() {
      return HandleTaskResponse<object>(() => worker.InformationTest());
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Task<string> LongRunningTestAsync(int milliSeconds) {
      return HandleTaskResponse<string>(() => worker.LongRunningTest(milliSeconds));
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string LongRunningTest(int milliSeconds) {
      return worker.LongRunningTest(milliSeconds);
    }

    #endregion

    #region Exception handling

    /// <summary>
    /// Class that, when serialized, may be deserialized as Task,
    /// (if not containing an exception),
    /// but (other than Task) also can be serialized
    /// if containing an exception
    /// </summary>
    /// <typeparam name="T">Actual result type</typeparam>
    private class WebserviceResult<T> {
      public T Result { get; set; }
      public int Id { get; set; }
      public Exception Exception { get; set; }
      public TaskStatus Status { get; set; }
      public bool IsCanceled { get; set; }
      public bool IsCompleted { get; set; }
      public TaskCreationOptions CreationOptions { get; set; }
      public object AsyncState { get; set; }
      public bool IsFaulted { get; set; }
      public WebserviceResult(Task<T> task, Exception ex) {
        this.Result = default(T);
        this.Exception = task.Exception ?? ex;
        this.Id = task.Id;
        this.Status = task.Status;
        this.IsCanceled = task.IsCanceled;
        this.IsCompleted = task.IsCompleted;
        this.CreationOptions = task.CreationOptions;
        this.AsyncState = task.AsyncState;
        this.IsFaulted = task.IsFaulted;
      }
    }

    private class JsonResponse<T> {
      public WebserviceResult<T> d { get; }
      public JsonResponse(Task<T> task, Exception ex) {
        this.d = new WebserviceResult<T>(task, ex);
      }
    }

    /// <summary>
    /// Creates and awaits a task running the function given as parameter.
    /// On success returns the Task object
    /// If an exception is thrown in the task, a fake task object containing
    /// the exception is serialized to the out stream and the thread is interrupted.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="function"></param>
    /// <returns></returns>
    protected Task<T> HandleTaskResponse<T>(Func<T> function) {
      Task<T> task = new Task<T>(function);
      try {
        task.Start();
        task.Wait();
      }
      catch (Exception ex) {
        // A Task containing an exception can't be serialized, so we
        // need create a serializable fake object that 
        // looks like a Task when deserialized, and write
        // it directly to the out stream
        // (Why are we using Task in the interface anyway?)
        JsonResponse<T> jsonRespons = new JsonResponse<T>(task, ex);
        JsonSerializerSettings settings = new JsonSerializerSettings {
          TypeNameHandling = TypeNameHandling.Auto
        };
        string str = JsonConvert.SerializeObject(jsonRespons, settings);
        HttpContext.Current.Response.Write(str);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
      }
      return task;
    }

    #endregion

  }
}
