namespace TrackingApi.Model
{
    abstract public class BaseEntity<T>
    {
        //protected abstract void Copy<T>(T obj);
        //protected abstract void Equal<T> (T obj) where T : BaseEntity;

        public abstract void Copy(T obj);
        public abstract bool Equal(T obj);
        public abstract override string ToString();
    }
}