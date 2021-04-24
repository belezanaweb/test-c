namespace Boticario.Domain.Entities
{
    public class Notification
    {
        #region Constructors

        public Notification(string message)
        {
            Message = message;
        }

        #endregion

        #region Attributes

        public string Message { get; }

        #endregion
    }
}