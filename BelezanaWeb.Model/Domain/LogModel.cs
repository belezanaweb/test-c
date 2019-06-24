using System;

namespace BelezanaWeb.Model.Domain
{
    public class LogModel
    {
        public LogModel()
        {
            this.Created = DateTime.Now;
        }


        public string Status { get; set; }
        public string Step { get; set; }
        public string Message { get; set; }
        public string FriendlyMessage { get; set; }
        public string Request { get; set; }
        public object Response { get; set; }
        public string Exception { get; set; }
        public DateTime Created { get; set; }
        public Object Object { get; set; }
        public string Error { get; set; }
    }
}
