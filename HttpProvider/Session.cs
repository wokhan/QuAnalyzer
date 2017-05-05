using QuAnalyzer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpProvider
{
    public class Session : NotifierHelper
    {
        public int Id { get; set; }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; NotifyPropertyChanged("Selected"); }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; NotifyPropertyChanged("Body"); }
        }

        public string Headers { get; set; }

        private string _contentLength;
        public string ContentLength
        {
            get { return _contentLength; }
            set { _contentLength = value; NotifyPropertyChanged("ContentLength"); }
        }

        private string _contentType;
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; NotifyPropertyChanged("ContentType"); }
        }

        public string Url { get; set; }

        private string _method;
        public string RawMethod
        {
            get { return _method; }
            set { _method = value; NotifyPropertyChanged("RawMethod"); }
        }

        public byte[] RawBody { get; set; }

        public Dictionary<string, string> RawHeaders { get; set; }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        public Fiddler.Session Raw { get; set; }

        internal void Complete(object sender, EventArgs e)
        {
            //Raw.utilDecodeResponse(true);

            //this.Body = Raw.GetResponseBodyAsString();
            this.RawMethod = Raw.RequestMethod;
            this.Status = Raw.responseCode;
            this.Url = Raw.fullUrl;
            //this.ContentType = Raw.ResponseHeaders["Content-Type"];
            //this.ContentLength = Raw.ResponseHeaders["Content-Length"];
        }

        
    }
}
