namespace BelezaNaWeb.BuildingBlocks.Notifications
{
    public class Notification
    {
        private Notification(string context, string rule, string message)
        {
            Context = context;
            Rule = rule;
            Message = message;
        }

        public string Context { get; set; }

        public string Rule { get; set; }

        public string Message { get; set; }

        public static Notification CreateValidation(string field, string validation, string message)
            => new Notification(field, validation, message);

        public static Notification CreateWithStatusCode(string field, string rule, string message)
            => new Notification(field, rule, message);
    }
}
