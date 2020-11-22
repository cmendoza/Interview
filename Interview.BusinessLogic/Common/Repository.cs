namespace Interview.BusinessLogic.Common
{
    internal abstract class Repository<T> where T : Entity
    {
        protected Repository(UnitOfWork unitOfWork) => Context = unitOfWork;

        protected UnitOfWork Context { get; }

        public T Get(long id) => Context.Get<T>(id);

        public void Add(T entity) => Context.Add(entity);
    }
}
