namespace Exeption
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
