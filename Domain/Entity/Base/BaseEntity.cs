
namespace Domain.Entity.Base

{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public byte[]? TimeStamp { get; private set; }
    }
}
