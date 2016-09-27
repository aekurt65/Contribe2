using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonClient {

  /// <summary>
  /// Encodes requests and decodes responses. Probably wouldn't
  /// be needed if service was set up properly
  /// </summary>
  abstract public class JsonClient {
    abstract protected string pageName { get; }

    protected JsonClient() {
      InitDicMethodParameterNames();
    }

    // ================================================================
    #region URL
    // ================================================================

    private string strUrlBase { get; set; }
    public void SetUrl(string strUrlBase) {
      Uri uriResult;
      if (!Uri.TryCreate(strUrlBase, UriKind.Absolute, out uriResult) || uriResult.Scheme != Uri.UriSchemeHttp) {
        throw new Common.InfoException(Txt.IncorrectUrlFormat, strUrlBase);
      }

      if (strUrlBase.EndsWith("/")) {
        this.strUrlBase = strUrlBase + pageName;
      }
      else {
        this.strUrlBase = strUrlBase + "/" + pageName;
      }
    }

    private string GetMethodUrl(string methodName) {
      if (string.IsNullOrWhiteSpace(strUrlBase)) {
        throw new Common.InfoException(Txt.MissingUrl);
      }
      return string.Format("{0}/{1}", strUrlBase, methodName);
    }

    #endregion

    // ================================================================
    #region ServerCalls not using Task in interface
    // ================================================================

    Dictionary<string, object> dicTaskResponses = new Dictionary<string, object>();

    public TIResponse CallServerMakeAsync<TIResponse, TResponse>(Enum methodName, params object[] args)
      where TResponse : TIResponse {
      string key = Guid.NewGuid().ToString();
      CallServerMakeAsyncInner<TIResponse, TResponse>(key, methodName.ToString(), args);
      TIResponse response = (TIResponse)dicTaskResponses[key];
      dicTaskResponses.Remove(key);
      return response;
    }

    private async void CallServerMakeAsyncInner<TIResponse, TResponse>(string key, string methodName, params object[] args)
      where TResponse : TIResponse {
      Task<TIResponse> task = Task.Run(() => CallServerAsyncTask<TIResponse, TResponse>(methodName, args));
      TIResponse response = await task;
      dicTaskResponses[key] = response;
    }



    protected TResponse CallServerNoTask<TResponse>(string methodName, params object[] args) {
      string strUrl = GetMethodUrl(methodName);

      ParameterInfo[] arParamInfo = CheckParams(methodName, args);

      string strPostdata = CreatePostdata(args, arParamInfo);

      string strResponse = Post(strUrl, strPostdata);

      return DecodeServiceResultString<TResponse>(strResponse);
    }

    class ServiceResponse<T> : CommonInterface.IServiceReply<T> {
      public string Info { get; set; }
      public string Error { get; set; }
      public T Result { get; set; }
    }

    private class JsonServiceResponse<T> {
      public ServiceResponse<T> d { get; set; }
    }

    private T DecodeServiceResultString<T>(string strResponse) {
      JsonServiceResponse<T> jsonRespons = JsonConvert.DeserializeObject<JsonServiceResponse<T>>(strResponse);
      if (jsonRespons == null || jsonRespons.d == null) {
        throw new Common.InfoException(Txt.ServerCallNoResult);
      }
      else if (jsonRespons.d.Error != null) {
        throw new Exception(jsonRespons.d.Error);
      }
      else if (jsonRespons.d.Info != null) {
        throw new Common.InfoException(jsonRespons.d.Info);
      }
      return jsonRespons.d.Result;
    }

    #endregion

    // ================================================================
    #region Wrapping async ServerCalls
    // ================================================================

    /// <summary>
    /// Called by subclass for methods that reqire a Task as response
    /// </summary>
    /// <typeparam name="TIResponse">Interface type that the method returns</typeparam>
    /// <typeparam name="TResponse">Real class that instantiates the return type</typeparam>
    /// <param name="methodName">An enum value representing the name of the method to call</param>
    /// <param name="args">Arguments for the method call, in proper order</param>
    /// <returns></returns>
    protected Task<TIResponse> CallServerAsync<TIResponse, TResponse>(Enum methodName, params object[] args)
      where TResponse : TIResponse {
      return Task.Run(() => CallServerAsyncTask<TIResponse, TResponse>(methodName.ToString(), args));
    }

    private TIResponse CallServerAsyncTask<TIResponse, TResponse>(string methodName, params object[] args)
      where TResponse : TIResponse {
      return CallServer<TResponse>(methodName, args);
    }

    #endregion

    // ================================================================
    #region Main method for encoding data, making server call and decoding data
    // ================================================================

    private TResponse CallServer<TResponse>(string methodName, params object[] args) {
      string strUrl = GetMethodUrl(methodName);

      ParameterInfo[] arParamInfo = CheckParams(methodName, args);

      string strPostdata = CreatePostdata(args, arParamInfo);

      string strResponse = Post(strUrl, strPostdata);

      return DecodeResultString<TResponse>(strResponse);
    }

    #endregion

    // ================================================================
    #region Handle parameters and parameter types
    // ================================================================

    private Dictionary<string, ParameterInfo[]> dicMethods { get; set; }
    private void InitDicMethodParameterNames() {
      dicMethods = new Dictionary<string, ParameterInfo[]>();
      Type objType = this.GetType();
      Type[] arInterfaces = objType.GetInterfaces();
      foreach (Type @interface in arInterfaces) {
        MethodInfo[] arMethods = @interface.GetMethods();
        foreach (MethodInfo mi in arMethods) {
          dicMethods.Add(mi.Name, mi.GetParameters());
        }
      }
    }

    /// <summary>
    /// Get parameter array for methodName, and checks that given arguments are
    /// correct in number and types.
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    private ParameterInfo[] CheckParams(string methodName, params object[] args) {
      ParameterInfo[] arParamInfo;
      if (!dicMethods.TryGetValue(methodName, out arParamInfo)) {
        throw new Exception(string.Format("Unknown method name {0} in interface.", methodName));
      }
      if (args.Length != arParamInfo.Length) {
        throw new Exception(string.Format("Length of parameter list for method {0} is not correct.", methodName));
      }
      for (int i = 0; i < arParamInfo.Length; i++) {
        Type paramType = arParamInfo[i].ParameterType;
        if (!paramType.IsAssignableFrom(args[i].GetType())) {
          throw new Exception(string.Format("Parameter {0} of method {1} does not have the correct type.", i, methodName));
        }
      }
      return arParamInfo;
    }

    #endregion

    // ================================================================
    #region Encode and post data
    // ================================================================

    /// <summary>
    /// Serializes a dictionary to json format.
    /// This is needed because webservice methods dont seem
    /// to accept dictionaries as parameters????
    /// </summary>
    /// <typeparam name="K">Type of dictionary keys</typeparam>
    /// <typeparam name="V">Type of dictionary values</typeparam>
    /// <param name="dic"></param>
    /// <returns></returns>
    public string SerializeDictionary<K, V>(Dictionary<K, V> dic) {
      return Newtonsoft.Json.JsonConvert.SerializeObject(dic);
    }

    private string CreatePostdata(object[] args, ParameterInfo[] arParamInfo) {
      Dictionary<string, string> dicArgs = new Dictionary<string, string>();
      for (int i = 0; i < args.Length; i++) {
        if (arParamInfo[i].ParameterType == typeof(string)) {
          dicArgs.Add(arParamInfo[i].Name, args[i].ToString());
        }
        else {
          string strEncodedParamValue = Newtonsoft.Json.JsonConvert.SerializeObject(args[i]);
          dicArgs.Add(arParamInfo[i].Name, strEncodedParamValue);
        }
      }
      return Newtonsoft.Json.JsonConvert.SerializeObject(dicArgs);
    }

    private string Post(string strUrl, string strSend) {
      try {
        byte[] postBytes = Encoding.UTF8.GetBytes(strSend);

        // Create a request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
        request.KeepAlive = false;
        request.ProtocolVersion = HttpVersion.Version10;
        request.Method = "POST";
        request.ContentType = "application/json; charset=UTF-8";
        request.ContentLength = postBytes.Length;

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        // Call server and get response
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        return sr.ReadToEnd();
      }
      catch (WebException ex) {
        throw new Common.InfoException(Txt.ServerCallError, ex.Message);
      }
    }

    #endregion

    // ================================================================
    #region Decode Json result
    // ================================================================

    /// <summary>
    /// Fake class resembling Task, because Task's weird behavior
    /// when deserialized if containing an Exception
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class WebserviceResult<T> {
      public T Result { get; set; }
      public int Id { get; set; }
      public Exception Exception { get; set; }
      public int Status { get; set; }
      public bool IsCanceled { get; set; }
      public bool IsCompleted { get; set; }
      public int CreationOptions { get; set; }
      public object AsyncState { get; set; }
      public bool IsFaulted { get; set; }
    }

    private class JsonFakeTask<T> {
      public WebserviceResult<T> d { get; set; }
    }

    private class JsonTask<T> {
      public Task<T> d { get; set; }
    }

    private T DecodeResultString<T>(string strResponse) {

      // Need this so we can differentiate between different types of Exceptions
      JsonSerializerSettings settings = new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Auto
      };

      return DecodeJsonFakeTask<T>(strResponse, settings);
    }

    private T DecodeJsonFakeTask<T>(string strResponse, JsonSerializerSettings settings) {
      JsonFakeTask<T> jsonFakeRespons = JsonConvert.DeserializeObject<JsonFakeTask<T>>(strResponse, settings);
      if (jsonFakeRespons == null || jsonFakeRespons.d == null) {
        throw new Common.InfoException(Txt.ServerCallNoResult);
      }
      else if (jsonFakeRespons.d.Exception != null) {
        throw jsonFakeRespons.d.Exception;
      }
      return jsonFakeRespons.d.Result;
    }

    #endregion
  }
}
