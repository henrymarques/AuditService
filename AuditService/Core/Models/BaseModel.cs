namespace AuditService.Core.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

         public string Id { get; private set; }
    }
}
