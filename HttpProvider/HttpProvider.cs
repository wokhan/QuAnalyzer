using HttpProvider;
using QuAnalyzer.Extensions;
using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace QuAnalyzer.DataProviders.HttpProvider
{
    [DataProvider(Category = "Http", Name = "Http sessions provider", Copyright = "Developed by Wokhan Solutions. Based on Telerik FiddlerCore.")]
    [DataContract]
    public class HttpProvider : DataProvider, IDataProvider, IExposedDataProvider
    {
        Dictionary<string, Type> _headers = new Dictionary<string, Type>
        {
            { "RawResponse", typeof(string) }
        };

        public class ResponseClass
        {
            public string RawResponse { get; set; }
        }

        public new Type GetTypedClass(string repository)
        {
            return typeof(ResponseClass);
        }

        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            return _headers;
        }

        private string[] stdHeaders = new[] { "Accept", "Connection", "Content-Length", "Content-Type", "Date", "Expect", "Host", "If-Modified-Since", "Range", "Referrer", "Transfer-Encoding", "User-Agent", "Proxy-Connection" };

        public new IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            var ses = (Session)Repositories[repository];
            
            Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.Default);
            Fiddler.URLMonInterop.SetProxyInProcess("localhost:" + Fiddler.FiddlerApplication.oProxy.ListenPort, "");
            var newses = Fiddler.FiddlerApplication.oProxy.SendRequestAndWait(ses.Raw.RequestHeaders, ses.Raw.requestBodyBytes, null, null);
            var r = newses.GetResponseBodyAsString().Split('\r').Select(s => new ResponseClass() { RawResponse = s }).AsQueryable();
            Fiddler.FiddlerApplication.Shutdown();
            
            return (IQueryable<T>)(r);
        }

        private IEnumerable<ResponseClass> _getdata(StringReader sr)
        {
            string x;
            while ((x = sr.ReadLine()) != null)
            {
                yield return new ResponseClass() { RawResponse = x };
            }

            sr.Close();
        }

        public new void OpenEditor()
        {
            var win = new Browser(this);
            var r = win.ShowDialog();
            Repositories = win.SelectedSession;
        }

        /*public new Dictionary<string, object> GetDefaultRepositories()
        {
            var res = Application.Current.Dispatcher.Invoke<Dictionary<string, object>>(() =>
            {
                var win = new Browser();
                var r = win.ShowDialog();
                return win.SelectedSession;
            });

            return res;
        }*/


        public new bool IsDirectlyBindable
        {
            get { return false; }
        }

        public new string[] RepositoriesColumnNames
        {
            get { return new[] { "Key", "URL" }; }
            set { }
        }
    }
}
