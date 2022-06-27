namespace Health.Core.Types.Exceptions
{
    public class AlreadyExistsException : ApplicationException
    {
        public object Entity { get; set; } = null;
        public AlreadyExistsException() : base()
        {

        }

        public AlreadyExistsException(string message) : base(message)
        {

        }

        public AlreadyExistsException(string message, object data) : base(message)
        {
            this.Entity = data;
        }
    }

    public class AlreadyExistsException<TEntity> : AlreadyExistsException
    {
        public new TEntity Entity { get; set; }
        public AlreadyExistsException()
        {

        }

        public AlreadyExistsException(TEntity data) : base()
        {
            this.Entity = data;
        }

        public AlreadyExistsException(string message) : base(message)
        {
            this.Entity = default;
        }

        public AlreadyExistsException(string message, TEntity data) : base(message)
        {
            this.Entity = data;
        }
    }
}
