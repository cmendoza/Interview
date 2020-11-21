namespace Interview.BusinessLogic.Common
{
    public abstract class Repository<T> where T : Entity
    {
        protected Repository(OrdersContext context)
        {
            Context = context;
        }

        protected OrdersContext Context { get; }

        public T Get(long id) => Context.Find<T>(id);

        public void Add(T entity) => Context.Set<T>().Add(entity);
    }
}
