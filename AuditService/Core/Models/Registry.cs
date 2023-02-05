namespace AuditService.Core.Models
{
    public class Registry : BaseModel
    {
        public Registry(string userId, string userIp, string message, DateTime eventDate)
        {
            UserId = userId;
            UserIp = userIp;
            Message = message;
            EventDate = eventDate;
            CreatedAt = DateTime.Now;
        }

        public string UserId { get; private set; }
        public string UserIp { get; private set; }
        public string Message { get; private set; }
        public DateTime EventDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
