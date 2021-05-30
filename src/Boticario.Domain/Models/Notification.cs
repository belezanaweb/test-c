namespace Boticario.Domain.Models
{
    public class Notification
    {


        public Notification(string message)
        {
            Message = message;
        }


        public string Message { get; }

     
    }
}
